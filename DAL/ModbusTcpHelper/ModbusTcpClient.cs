using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DAL

{
    /// <summary>
    /// ModbusTcp通讯客户端类，可以通过此客户端连接远程服务器进行ModBusTcp/Ip通讯
    /// </summary>
    public class ModbusTcpClient : IDisposable
    {
        #region 实现单例模式-饿汉式
        private ModbusTcpClient() { }
        private static ModbusTcpClient singleInstance = new ModbusTcpClient();
        public static ModbusTcpClient GetSingleInstance()
        {
            if (singleInstance == null || singleInstance.isDisposed)
            {
                singleInstance = new ModbusTcpClient();
            }
            return singleInstance;
        }

        #endregion

        #region 字段、属性

        /// <summary>
        /// 通讯Socket
        /// </summary>
        private Socket socketClient = null;

        private bool isConnected = false;
        /// <summary>
        /// Socket是否连接
        /// </summary>
        public bool IsConnected
        {
            get { return isConnected; }
        }

        // ManualResetEvent instances signal completion.
        /// <summary>
        /// Socket连接信号量
        /// </summary>
        private ManualResetEvent connectDone = new ManualResetEvent(false);

        #endregion

        #region 连接服务端相关方法

        /// <summary>
        /// 连接服务端
        /// 异常：System.TimeoutException
        /// <param name="ip">服务端Ip</param>
        /// <param name="port">服务端Port</param>
        /// <param name="timeoutConnect">连接超时时间</param>
        /// <param name="receiveTimeout">Socket.ReceiveTimeout</param>
        /// <param name="sendTimeout">Socket.SendTimeout</param>
        /// <returns></returns>
        public bool Connect(string ip, int port, int connectTimeout, int receiveTimeout, int sendTimeout)
        {
            if (socketClient == null)
            {
                try
                {
                    socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {
                        //socketTcpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 200);
                        //ReceiveTimeout 属性确定同步Read方法在能够接收数据之前保持阻塞状态的时间量
                        ReceiveTimeout = receiveTimeout,
                        SendTimeout = sendTimeout
                    };
                }
                catch (Exception e)
                {
                    //异常写入日志
                    this.WriteErrorLog("socketTcpClient = new Socket()出错：" + e.Message);
                    return false;
                }
            }

            //判断isConnected属性
            if (isConnected) return true;

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
            this.connectDone.Reset();//将事件状态设置非终止状态，导致线程阻止
            try
            {
                //异步连接
                socketClient.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socketClient);
                //等待超时时间
                if (connectDone.WaitOne(connectTimeout, false))
                {
                    //ConnectCallback()完成，在超时时间内收到了连接信号
                    return isConnected;
                }
                else
                {
                    //超时时间内未收到信号
                    throw new TimeoutException("Scoket超过自定时间未连接上");
                }
            }
            catch (TimeoutException ex)
            {
                this.WriteErrorLog("Socket连接超时：" + ex.Message);
                return isConnected;
            }
            catch (Exception e)
            {
                //异常写入日志
                this.WriteErrorLog("socketTcpClient.Connect()出错：" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// 关闭与服务端的通讯连接，释放socket资源
        /// </summary>
        /// <returns></returns>
        public bool CloseConnect()
        {
            if (socketClient == null) return true;
            try
            {
                this.isConnected = false;

                socketClient.Shutdown(SocketShutdown.Both);//如果套接字尚未连接就调用，将抛异常
                socketClient.Close();
                socketClient = null;
                return true;
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("CloseConnect()出错：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// BeginConnect回调方法
        /// </summary>
        /// <param name="ar"></param>
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                this.isConnected = false;
                Socket socketClient = (Socket)ar.AsyncState;
                if (socketClient != null)
                {
                    socketClient.EndConnect(ar);
                    this.isConnected = true;
                }
            }
            catch (Exception e)
            {
                this.WriteErrorLog("ConnectCallback()出错：" + e.Message);
                this.isConnected = false;
            }
            finally
            {
                // Signal that the connection has been made.
                this.connectDone.Set(); //释放信号，将事件状态设置为终止状态
            }
        }



        #endregion

        #region 同步读取ModbusTcp服务端的数据

        #region 读输出线圈  功能码0x01
        /// <summary>
        /// 读输出线圈 0XXXX 状态  功能码0x01
        /// 报文中地址00000对应设备中00001地址
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="length">线圈数量</param>
        /// <param name="transId">传输消息Id</param>
        /// <returns></returns>
        public byte[] ReadCoilStatus(int startAddress, int length, ushort transId)
        {
            if (!this.isConnected) return null;

            //1. 创建Modubus请求ADU数据包(MBAP报文头+PDU)
            byte[] dataADU = new byte[12];

            //2. 添加MBAP报文头：
            //byte[0]  byte[1] :  事务元标识符：用于事务处理配对。在响应中，MODBUS服务器复制请求的事务处理标识符。这里在以太网传输中存在一个问题，就是先发后至，我们可以利用这个事务处理标识符做一个TCP序列号，来防止这种情况所造成的数据收发错乱（这个事务处理标识符我们统一使用0x00，0x01）
            //byte[2]  byte[3]：  协议标识符，modbus协议标识符为0x00，0x00
            //byte[4]  byte[5]：  长度域是：下一个域的字节数，包括单元标识符和数据域。
            //byte[6]：           单元标识符：该设备的编号。（可以使用PLC的IP地址标识）对 TCP/IP 来说，利用IP地址寻址MODBUS服务器；
            dataADU[0] = BitConverter.GetBytes(transId)[1];
            dataADU[1] = BitConverter.GetBytes(transId)[0];
            dataADU[2] = 0x00;
            dataADU[3] = 0x00;
            dataADU[4] = 0x00;
            dataADU[5] = 0x06;
            dataADU[6] = 0xff;  //应于服务器设置的slave id 相对应

            //3. 添加PDU数据域(功能码+数据)
            dataADU[7] = 0x01;                          //功能码

            dataADU[8] = (byte)(startAddress / 256);    //起始地址高字节
            dataADU[9] = ((byte)(startAddress % 256));  //起始地址低字节
            dataADU[10] = ((byte)(length / 256));       //读取数据长度高字节
            dataADU[11] = ((byte)(length % 256));       //读取数据长度低字节

            //4. 发送ADU报文
            try
            {
                socketClient.Send(dataADU);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Send(dataADU)出错：" + ex.Message);
                return null;
            }

            //5. 接收回应报文
            byte[] receiveData = new byte[256];//缓冲区中的数据总量不超过256byte，一次读256byte，防止残余数据影响下次读取
            int receiveByteCount = 0;
            try
            {
                receiveByteCount = socketClient.Receive(receiveData);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Receive(receiveData)出错：" + ex.Message);
                return null;
            }

            //回应报文示例:
            //byte[0]  byte[1] :    消息号，我们之前写发送指令的时候，是多少，这里就是多少。
            //byte[2]  byte[3]：    必须都为0，代表这是modbus 通信
            //byte[4]  byte[5]：    指示byte[5]后面的所有字节数，你数数看是不是4个？所以这里是00 04，如果后面共有100个，那么这里就是 00 64
            //byte[6]：             站号，之前我们写了FF，那么这里也就是FF
            //byte[7]：             功能码，我们之前写了01的功能码，这里也是01，和我们发送的指令是一致的
            //byte[8]：             指示byte[8]后面跟随的字节数量，因为跟在byte[8]后面的就是真实的数据，我们最终想要的结果就在byte[8]后面
            //byte[9]。。。：        数据字节

            //6. 处理回应报文
            //6.1 校验接收的字节长度
            int coilByteCount = length % 8 == 0 ? length / 8 : length / 8 + 1;
            if (receiveByteCount < (9 + coilByteCount)) return null;

            //6.2 校验回应报文的字节长度和消息标识
            List<byte> listData = receiveData.ToList<byte>();
            listData.RemoveRange(receiveByteCount, listData.Count - receiveByteCount);//移除多余项
            if (listData.Count == (9 + coilByteCount))
            {
                //6.3 如果报文长度正确，则校验消息标识符
                if (listData[0] == dataADU[0] && listData[1] == dataADU[1])
                {
                    //移除报文头，剩余纯数据字节
                    listData.RemoveRange(0, 9);
                    //返回读取的纯数据
                    return listData.ToArray();
                }
                else
                {
                    return null;
                }
            }
            else //6.4 listData.Count >= (9 + coilByteCount,多读了残余数据，从残余数据中筛选出回应报文
            {
                return null;
            }
        }
        #endregion

        #region 读保持型寄存器 功能码0x03
        /// <summary>
        /// 读保持寄存器 4XXXX 值。0x03
        /// 报文中寄存器起始地址 00000 对应设备中 40001 地址
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="length">寄存器数量</param>
        /// <param name="transId">传输消息Id</param>
        /// <returns></returns>
        public byte[] ReadHoldingRegisters(int startAddress, int length, ushort transId)
        {
            if (!this.isConnected) return null;

            //1. 创建Modubus请求ADU数据包(MBAP报文头+PDU)
            byte[] dataADU = new byte[12];

            //2. 添加MBAP报文头：
            dataADU[0] = BitConverter.GetBytes(transId)[1];  //byte[0]  byte[1] :  事务元标识符
            dataADU[1] = BitConverter.GetBytes(transId)[0];
            dataADU[2] = 0x00;  //byte[2]  byte[3]：  协议标识符
            dataADU[3] = 0x00;
            dataADU[4] = 0x00;  //byte[4]  byte[5]：  长度域
            dataADU[5] = 0x06;
            dataADU[6] = 0xff;  //byte[6]：单元标识符

            //3. 添加PDU数据域(功能码+数据)
            dataADU[7] = 0x03;                          //功能码
            dataADU[8] = (byte)(startAddress / 256);    //起始地址高字节
            dataADU[9] = ((byte)(startAddress % 256));  //起始地址低字节
            dataADU[10] = ((byte)(length / 256));       //读取寄存器数量高字节
            dataADU[11] = ((byte)(length % 256));       //读取寄存器数量低字节

            //4. 发送ADU报文
            try
            {
                socketClient.Send(dataADU);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Send(dataADU)出错：" + ex.Message);
                return null;
            }

            //5. 接收回应报文
            byte[] receiveData = new byte[256];//缓冲区中的数据总量不超过256byte，一次读256byte，防止残余数据影响下次读取
            int receiveByteCount = 0;
            try
            {
                receiveByteCount = socketClient.Receive(receiveData);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Receive(receiveData)出错：" + ex.Message);
                return null;
            }

            //6. 处理回应报文
            //6.1 校验接收的字节长度
            int registerByteCount = length * 2;//一个寄存器占两个字节
            if (receiveByteCount < (9 + registerByteCount)) return null;

            //6.2 校验回应报文的字节长度和消息标识
            List<byte> listData = receiveData.ToList<byte>();
            listData.RemoveRange(receiveByteCount, listData.Count - receiveByteCount);//移除多余项
            if (listData.Count == (9 + registerByteCount))//接收的字节数为（ 9+ 寄存器数*2）
            {
                //6.3 如果报文长度正确，则校验消息标识符
                if (listData[0] == dataADU[0] && listData[1] == dataADU[1])
                {
                    //移除报文头，剩余纯数据字节
                    listData.RemoveRange(0, 9);
                    //返回读取的纯数据
                    return listData.ToArray();
                }
                else
                {
                    return null;
                }
            }
            else //6.4 listData.Count >= (9 + coilByteCount,多读了残余数据，从残余数据中筛选出回应报文
            {
                return null;
            }
        }

        #endregion

        #region 强制单线圈 功能码0x05
        /// <summary>
        /// 强制单线圈 0XXXX 值 功能码0x05
        /// 报文中地址00000对应设备中00001地址
        /// </summary>
        /// <param name="coilAddress">线圈地址</param>
        /// <param name="OnOff">强制通或者断</param>
        /// <param name="transId">传输消息Id</param>
        /// <returns></returns>
        public bool ForceSingleCoil(int coilAddress, bool OnOff, int transId)
        {
            if (!this.isConnected) return false;

            //1. 创建Modubus请求ADU数据包(MBAP报文头+PDU)
            byte[] dataADU = new byte[12];

            //2. 添加MBAP报文头：
            dataADU[0] = (byte)(transId / 256);  //byte[0]  byte[1] :  事务元标识符Hi Lo
            dataADU[1] = (byte)(transId % 256);
            dataADU[2] = 0x00;  //byte[2]  byte[3]：  协议标识符
            dataADU[3] = 0x00;
            dataADU[4] = 0x00;  //byte[4]  byte[5]：  长度域
            dataADU[5] = 0x06;
            dataADU[6] = 0xff;  //byte[6]：单元标识符

            //3. 添加PDU数据域(功能码+数据)
            dataADU[7] = 0x05;                                  //功能码
            dataADU[8] = (byte)(coilAddress / 256);             //线圈地址高字节
            dataADU[9] = ((byte)(coilAddress % 256));           //线圈地址低字节
            dataADU[10] = OnOff ? (byte)0xff : (byte)0x00;      //通断标志高字节 FF00:置线圈 ON;0000:置线圈OFF。
            dataADU[11] = (byte)0x00;                           //通断标志低字节

            //4. 发送ADU报文
            try
            {
                socketClient.Send(dataADU);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Send(dataADU)出错：" + ex.Message);
                return false;
            }

            //5. 接收回应报文回应报文应与发送报文一致
            byte[] receiveData = new byte[256];//缓冲区中的数据总量不超过256byte，一次读256byte，防止残余数据影响下次读取
            int receiveByteCount = 0;
            try
            {
                receiveByteCount = socketClient.Receive(receiveData);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Receive(receiveData)出错：" + ex.Message);
                return false;
            }

            //6. 处理回应报文,回应报文应与发送报文一致

            //6.1 校验回应报文的字节长度
            if (receiveByteCount < 12) return false;

            Array.Resize(ref receiveData, receiveByteCount); //将一维数组的元素数更改为指定的新大小。
            if (receiveData.Length == 12)
            {
                //6.2 如果报文长度正确，则校验回应报文与发送报文是否一致
                if (Enumerable.SequenceEqual<byte>(dataADU, receiveData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //6.3 listData.Count >= (9 + coilByteCount),多读了残余数据，从残余数据中筛选出回应报文
            {
                return false;
            }
        }

        #endregion

        #region 预置单保持寄存器 功能码Ox06
        /// <summary>
        /// 预置单保持寄存器 4XXXX 值 功能码Ox06
        /// 报文中寄存器起始地址 00000 对应设备中 40001 地址
        /// </summary>
        /// <param name="regAddr">寄存器地址</param>
        /// <param name="value">写入数据值UInt16</param>
        /// <param name="transId">传输消息Id</param>
        /// <returns></returns>
        public bool PresetSingleRegster(int regAddr, UInt16 value, int transId)
        {
            if (!this.isConnected) return false;

            //1. 创建Modubus请求ADU数据包(MBAP报文头+PDU)
            byte[] dataADU = new byte[12];

            //2. 添加MBAP报文头：
            dataADU[0] = (byte)(transId / 256);  //byte[0]  byte[1] :  事务元标识符Hi Lo
            dataADU[1] = (byte)(transId % 256);
            dataADU[2] = 0x00;  //byte[2]  byte[3]：  协议标识符
            dataADU[3] = 0x00;
            dataADU[4] = 0x00;  //byte[4]  byte[5]：  长度域
            dataADU[5] = 0x06;
            dataADU[6] = 0xff;  //byte[6]：单元标识符

            //3. 添加PDU数据域(功能码+数据)
            dataADU[7] = 0x06;                                  //功能码
            dataADU[8] = (byte)(regAddr / 256);                 //地址高字节
            dataADU[9] = ((byte)(regAddr % 256));               //地址低字节
            dataADU[10] = ((byte)(value / 256));                //数据值高字节
            dataADU[11] = ((byte)(value % 256));                //数据值低字节

            //4. 发送ADU报文
            try
            {
                socketClient.Send(dataADU);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Send(dataADU)出错：" + ex.Message);
                return false;
            }

            //5. 接收回应报文

            byte[] receiveData = new byte[256];//缓冲区中的数据总量不超过256byte，一次读256byte，防止残余数据影响下次读取
            int receiveByteCount = 0;
            try
            {
                receiveByteCount = socketClient.Receive(receiveData);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Receive(receiveData)出错：" + ex.Message);
                return false;
            }

            //6. 处理回应报文,回应报文应与发送报文一致

            //6.1 校验回应报文的字节长度
            if (receiveByteCount < 12) return false;

            Array.Resize(ref receiveData, receiveByteCount); //将一维数组的元素数更改为指定的新大小。
            if (receiveData.Length == 12)
            {
                //6.2 如果报文长度正确，则校验回应报文与发送报文是否一致
                if (Enumerable.SequenceEqual<byte>(dataADU, receiveData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //6.3 listData.Count >= (9 + coilByteCount,多读了残余数据，从残余数据中筛选出回应报文
            {
                return false;
            }

        }

        #endregion

        #region 强制多线圈 功能码0x0F
        /// <summary>
        /// 将多个连续线圈 0XXXX 强置为 ON/OFF 状态 功能码0x0F
        /// 报文中地址00000对应设备中00001地址
        /// </summary>
        /// <param name="startAddr">线圈起始地址</param>
        /// <param name="coilStatus">写入的线圈状态</param>
        /// <param name="coilNums">写入线圈数</param>
        /// <param name="transId">传输消息Id</param>
        /// <returns></returns>
        public bool ForceMultipleCoils(int startAddr, byte[] coilStatus, int coilNums, int transId)
        {
            if (!this.isConnected) return false;

            //1. 创建Modubus请求ADU数据包(MBAP报文头+PDU)
            byte[] dataADU = new byte[13 + coilStatus.Length];

            //2. 添加MBAP报文头：
            dataADU[0] = (byte)(transId / 256);  //byte[0]  byte[1] :  事务元标识符Hi Lo
            dataADU[1] = (byte)(transId % 256);
            dataADU[2] = 0x00;  //byte[2]  byte[3]：  协议标识符
            dataADU[3] = 0x00;
            dataADU[4] = 0x00;  //byte[4]  byte[5]：  长度域
            dataADU[5] = (byte)(7 + coilStatus.Length);
            dataADU[6] = 0xff;  //byte[6]：单元标识符

            //3. 添加PDU数据域(功能码+数据)
            dataADU[7] = 0x0F;                                //功能码
            dataADU[8] = (byte)(startAddr / 256);             //线圈起始地址高字节
            dataADU[9] = ((byte)(startAddr % 256));           //线圈起始地址低字节
            dataADU[10] = (byte)(coilNums / 256);             //线圈数高位
            dataADU[11] = (byte)(coilNums % 256);             //线圈数低位
            dataADU[12] = (byte)(coilStatus.Length);          //线圈状态字节计数

            for (int i = 0; i < coilStatus.Length; i++)       //线圈状态字节
            {
                dataADU[13 + i] = coilStatus[i];
            }

            //4. 发送ADU报文
            try
            {
                socketClient.Send(dataADU);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Send(dataADU)出错：" + ex.Message);
                return false;
            }

            //5. 接收回应报文
            byte[] receiveData = new byte[256];//缓冲区中的数据总量不超过256byte，一次读256byte，防止残余数据影响下次读取
            int receiveByteCount = 0;
            try
            {
                receiveByteCount = socketClient.Receive(receiveData);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Receive(receiveData)出错：" + ex.Message);
                return false;
            }

            //6. 处理回应报文: 回应报文与发送报文的前12个字节应一致，除了长度域字节

            //6.1 校验回应报文的字节长度
            if (receiveByteCount < 12) return false;

            Array.Resize(ref receiveData, receiveByteCount); //将一维数组的元素数更改为指定的新大小。
            if (receiveData.Length == 12)
            {
                //6.2 如果报文长度正确，则校验回应报文与发送报文的前12个字节是否一致
                Array.Resize(ref dataADU, 12);//将发送报文截取出前12个字节
                dataADU[5] = 0x06;            //将第5个字节长度域改为6
                if (Enumerable.SequenceEqual<byte>(dataADU, receiveData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //6.3 listData.Count >= (9 + coilByteCount),多读了残余数据，从残余数据中筛选出回应报文
            {
                return false;
            }

        }

        #endregion

        #region 预置多寄存器 功能码0x10
        /// <summary>
        /// 预置多个保持寄存器值 4XXXX
        /// 1个寄存器对应2个字节，
        /// </summary>
        /// <param name="startAddr">寄存器起始地址</param>
        /// <param name="value">寄存器数据字节，第0个字节：第一个寄存器数据高位，第1个字节：第一个寄存器数据低位，依此类推</param>
        /// <param name="transId">传输消息Id</param>
        /// <returns></returns>
        public bool PresetMultipleRegisters(int startAddr, byte[] value, int transId)
        {
            if (!this.isConnected) return false;

            //1. 创建Modubus请求ADU数据包(MBAP报文头+PDU)
            byte[] dataADU = new byte[13 + value.Length];

            //2. 添加MBAP报文头：
            dataADU[0] = (byte)(transId / 256);  //byte[0]  byte[1] :  事务元标识符Hi Lo
            dataADU[1] = (byte)(transId % 256);
            dataADU[2] = 0x00;  //byte[2]  byte[3]：  协议标识符
            dataADU[3] = 0x00;
            dataADU[4] = 0x00;  //byte[4]  byte[5]：  长度域
            dataADU[5] = (byte)(7 + value.Length);
            dataADU[6] = 0xff;  //byte[6]：单元标识符

            //3. 添加PDU数据域(功能码+数据)
            dataADU[7] = 0x10;                                //功能码
            dataADU[8] = (byte)(startAddr / 256);             //寄存器起始地址高字节
            dataADU[9] = ((byte)(startAddr % 256));           //寄存器起始地址低字节
            dataADU[10] = (byte)(value.Length / 256);         //寄存器数高位
            dataADU[11] = (byte)(value.Length % 256);         //寄存器数低位
            dataADU[12] = (byte)(value.Length);               //字节计数
            for (int i = 0; i < value.Length; i++)
            {
                dataADU[13 + i] = value[i];
            }

            //4. 发送ADU报文
            try
            {
                socketClient.Send(dataADU);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Send(dataADU)出错：" + ex.Message);
                return false;
            }

            //5. 接收回应报文
            byte[] receiveData = new byte[256];//缓冲区中的数据总量不超过256byte，一次读256byte，防止残余数据影响下次读取
            int receiveByteCount = 0;
            try
            {
                receiveByteCount = socketClient.Receive(receiveData);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.Receive(receiveData)出错：" + ex.Message);
                return false;
            }

            //6. 处理回应报文: 回应报文与发送报文的前12个字节应一致，除了长度域字节

            //6.1 校验回应报文的字节长度
            if (receiveByteCount < 12) return false;

            Array.Resize(ref receiveData, receiveByteCount); //将一维数组的元素数更改为指定的新大小。
            if (receiveData.Length == 12)
            {
                //6.2 如果报文长度正确，则校验回应报文与发送报文的前12个字节是否一致
                Array.Resize(ref dataADU, 12);//将发送报文截取出前12个字节
                dataADU[5] = 0x06;            //将第5个字节长度域改为6
                if (Enumerable.SequenceEqual<byte>(dataADU, receiveData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //6.3 listData.Count >= (9 + coilByteCount),多读了残余数据，从残余数据中筛选出回应报文
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region 异步读取ModbusTcp服务端的数据

        #region 读输出线圈  功能码0x01

        /// <summary>
        /// ReadCoilStatusCompleted事件的委托，byte[] data 为服务端回送的报文
        /// </summary>
        /// <param name="data"></param>
        public delegate void ReadCoilStatusCompletedHandler(byte[] data);
        /// <summary>
        /// 异步读输出线圈 0XXXX 状态(功能码0x01)的完成事件，byte[]data是服务端回送的报文
        /// </summary>
        public event ReadCoilStatusCompletedHandler ReadCoilStatusCompleted;
        /// <summary>
        /// 异步读输出线圈 0XXXX 状态(功能码0x01)
        /// </summary>
        /// <param name="startAddr"></param>
        /// <param name="length"></param>
        /// <param name="transId"></param>
        /// <returns></returns>
        public bool ReadCoilStatusAsync(int startAddr, int length, int transId)
        {
            if (!this.isConnected) return false;

            //1. 创建Modubus请求ADU数据包(MBAP报文头+PDU)
            byte[] dataADU = new byte[12];

            //2. 添加MBAP报文头：
            //byte[0]  byte[1] :  事务元标识符：用于事务处理配对。在响应中，MODBUS服务器复制请求的事务处理标识符。这里在以太网传输中存在一个问题，就是先发后至，我们可以利用这个事务处理标识符做一个TCP序列号，来防止这种情况所造成的数据收发错乱（这个事务处理标识符我们统一使用0x00，0x01）
            //byte[2]  byte[3]：  协议标识符，modbus协议标识符为0x00，0x00
            //byte[4]  byte[5]：  长度域是：下一个域的字节数，包括单元标识符和数据域。
            //byte[6]：           单元标识符：该设备的编号。必需使用值0xFF。
            dataADU[0] = (byte)(transId / 256);
            dataADU[1] = (byte)(transId % 256);
            dataADU[2] = 0x00;
            dataADU[3] = 0x00;
            dataADU[4] = 0x00;
            dataADU[5] = 0x06;
            dataADU[6] = 0xff;

            //3. 添加PDU数据域(功能码+数据)
            dataADU[7] = 0x01;                          //功能码

            dataADU[8] = (byte)(startAddr / 256);    //起始地址高字节
            dataADU[9] = ((byte)(startAddr % 256));  //起始地址低字节
            dataADU[10] = ((byte)(length / 256));       //读取数据长度高字节
            dataADU[11] = ((byte)(length % 256));       //读取数据长度低字节

            //4. 发送ADU报文
            try
            {
                socketClient.BeginSend(dataADU, 0, dataADU.Length, 0, new AsyncCallback(SendReadCoilStatusCallback), socketClient);
                return true;
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socketTcpClient.BeginSend出错：" + ex.Message);
                return false;
            }
        }

        private void SendReadCoilStatusCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            try
            {
                int byteSend = socket.EndSend(ar);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socket.EndSend()出错：" + ex.Message);
                return;
            }
            StateObject state = new StateObject();
            state.workSocket = socket;
            try
            {
                socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(ReceiveCoilStatus), state);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socket.BeginReceive()出错：" + ex.Message);
                return;
            }

        }

        private void ReceiveCoilStatus(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket socket = state.workSocket;
            int bytesRead = 0;
            try
            {
                bytesRead = socket.EndReceive(ar);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("socket.EndReceive()出错：" + ex.Message);
                return;
            }

            //读取的数据在state.buffer中

            //触发读取完成事件
            this.ReadCoilStatusCompleted(state.buffer);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far. 

                // Get the rest of the data.
            }
            else
            {
                // All the data has arrived; put it in response.

                // Signal that all bytes have been received.
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// 将异常信息写入日志文本
        /// </summary>
        /// <param name="msg"></param>
        private void WriteErrorLog(string msg)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream("ModbusTcpErrorlog", FileMode.Append);
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString() + ": " + msg);
            }
            catch (Exception)
            {
                //不作处理
            }
            finally
            {
                //在sw.Close()执行完毕后，其实fs已经被关闭了。因此fs.Close()其实是可以省略的。
                //当然，这样的写法不会有任何问题，因为Dispose不会被执行两次。
                if (sw != null) sw.Close();
                if (fs != null) fs.Close();//这两行代码不能交换顺序，必须先sw.Close()
            }
        }

        public bool CompareArray(byte[] bt1, byte[] bt2)
        {
            var len1 = bt1.Length;
            var len2 = bt2.Length;
            if (len1 != len2)
            {
                return false;
            }
            for (var i = 0; i < len1; i++)
            {
                if (bt1[i] != bt2[i])
                    return false;
            }
            return true;
        }

        #region 心跳检测

        /// <summary>
        /// 设置socket的心跳检测为开启
        /// </summary>
        /// <param name="socket"></param>
        private void StartKeepAlive(Socket socket)
        {
            socket.IOControl(IOControlCode.KeepAliveValues, GetKeepAliveData(), null);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
        }
        
        private byte[] GetKeepAliveData()
        {
            uint dummy = 0;
            byte[] inOptionValues = new byte[Marshal.SizeOf(dummy) * 3];

            BitConverter.GetBytes((uint)1).CopyTo(inOptionValues, 0);//是否启用Keep-Alive
            //10min
            BitConverter.GetBytes((uint)600000).CopyTo(inOptionValues, Marshal.SizeOf(dummy));//keep-alive间隔,多长时间开始第一次探测        
            BitConverter.GetBytes((uint)500).CopyTo(inOptionValues, Marshal.SizeOf(dummy) * 2);//探测时间间隔           
            return inOptionValues;
        }

        /// <summary>
        /// socket连接检测定时器
        /// </summary>
        private System.Timers.Timer timerCheck;

        /// <summary>
        /// 定时检测中，socket断开连接事件
        /// </summary>
        public event Action SocketDisconnected;

        /// <summary>
        /// 开启检测定时器
        /// </summary>
        public void StartCheckAlive()
        {
            timerCheck = new System.Timers.Timer
            {
                Interval = 600000   //10min
            };
            timerCheck.Elapsed += TimerCheckElapsed;
            timerCheck.Enabled = true;  //启动定时器

        }

        /// <summary>
        /// 关闭定时检测，释放timer资源
        /// </summary>
        public void CloseCheckAlive()
        {
            timerCheck.Stop();
            timerCheck.Dispose();
        }

        private void TimerCheckElapsed(object sender, ElapsedEventArgs e)
        {
            if (this.socketClient != null && this.socketClient.Connected)
            {
                if (CheckTcpState(this.socketClient))
                {
                    //socket状态为TcpState.Established
                }
                else
                {
                    //socket断开连接，触发断开连接事件
                    SocketDisconnected();
                }
            }
        }
        
        /// <summary>
        /// This function will check if client is still connected with server 
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public bool CheckTcpState(Socket socket)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation c in tcpConnections)
            {
                TcpState stateOfConnection = c.State;
                if (c.LocalEndPoint.Equals(socket.LocalEndPoint) && c.RemoteEndPoint.Equals(socket.RemoteEndPoint))
                {
                    if (stateOfConnection == TcpState.Established)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        
        #endregion

        #region 实现IDisposable接口的Dispose()

        /// <summary>
        /// 释放标记
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// 为了防止忘记显示地调用Dispose方法
        /// </summary>
        ~ModbusTcpClient()
        {
            //注意，不能在析构函数中释放托管资源，因为析构函数是有垃圾回收器调用的，可能在析构函数调用之前，类包含的托管资源已经被回收了，从而导致无法预知的结果。
            //终结器调用的时候，传入必须为false，表示不需要处理托管资源
            Dispose(false);
        }

        /// <summary>
        /// ModbusTcp通讯客户端的关闭，释放资源，如socket资源
        /// 非必需的，只是为了更符合其他语言的规范，如C++、java
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务
        /// </summary>
        public void Dispose()
        {
            //必须为True，
            Dispose(true);

            //通知垃圾回收器不再调用终结器
            //GC.SuppressFinalize(this);

        }

        /// <summary>
        /// 非密封类可重写的Dispose方法，方便子类继承时可重写
        /// 释放资源时区分对待托管资源和非托管资源，而实现自IDisposable的Dispose方法调用时，传入的是true，而终结器调用的时候，传入的是false，当传入true时代表要同时处理托管资源和非托管资源；而传入false则只需要处理非托管资源即可。
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            //清理托管资源
            if (disposing)
            {

            }
            //清理非托管资源
            if (socketClient != null)
            {
                //释放socket
                //socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Close();
                socketClient = null;
                singleInstance = null;
            }
            isDisposed = true;
        }
        #endregion

        #region 其他待测试的方法

        /// <summary>
        /// 判断一个Socket是否已连接，此方法有待测试
        /// </summary>
        /// <param name="client"></param>
        /// <returns>返回False表示处于未连接状态</returns>
        private bool IsSocketConnected(Socket client)
        {
            bool blockingState = client.Blocking;

            //如果您需要确定连接的当前状态，请进行非阻止、零字节的 Send 调用。
            //如果该调用成功返回或引发 WAEWOULDBLOCK 错误代码 (10035)，则该套接字仍然处于连接状态；
            //否则，该套接字不再处于连接状态。
            try
            {
                //当服务器断开时，调用send仍然可以成功！！！！！！
                byte[] tmp = new byte[1];
                client.Blocking = false;
                client.Send(tmp, 1, 0);
                return true;    // Connected
            }
            catch (SocketException e)
            {
                // 产生 10035 == WSAEWOULDBLOCK 错误，说明被阻止了，但是还是连接的
                if (e.NativeErrorCode.Equals(10035))
                    return true;    // Still Connected, but the Send would block
                else
                    return false;   //Disconnected
            }
            finally
            {
                client.Blocking = blockingState;    // 恢复Scoket的阻止模式
            }
        }

        #endregion
    }
}
