using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;
using Common;
using System.Linq;


namespace HVACDetectingSystem
{
    public partial class FrmDetectionAuto : Form
    {
        #region constructor

        public FrmDetectionAuto()
        {
            InitializeComponent();

            //创建该窗体时，有可能未选择产品型号
            lblTitle.Text = Program.currentProductType + "空调总成生产线";
            listParam = XMLService.GetParamsByType(Program.currentProductType);

            DataGridViewStyle.DoubleBuffered(dgvParam, true);
            dgvParam.AutoGenerateColumns = false;

            if (listParam != null)
            {
                UpdateDgvParam(GetDetectedListParam(listParam));
            }

            //初始化定时器
            timerCheckComm.Interval = 5000; //每5s
            timerCheckComm.Enabled = true;  //启动

        }

        public FrmDetectionAuto(ModbusTcpClient client) : this()
        {
            //获取tcp客户端
            objTcpClient = client;
            //异步连接服务端
            Task.Run(new Action(ConnectServer));
        }

        #endregion

        #region private member

        /// <summary>
        /// 当前型号产品的参数集合
        /// </summary>
        private List<Param> listParam;

        /// <summary>
        /// 当前检测的HVAC
        /// </summary>
        private HVAC currentDetectedHVAC = null;

        private HVACService objHVACService = new HVACService();

        /// <summary>
        /// 检测过的HVAC产品集合
        /// </summary>
        private List<HVAC> listHVAC = new List<HVAC>();

        private ModbusTcpClient objTcpClient;

        /// <summary>
        /// 合格数量
        /// </summary>
        private int passNum = 0;

        private int unPassNum = 0;

        #endregion

        /// <summary>
        /// 开始检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Program.currentProductType == null)
            {
                MessageBox.Show("未选择产品型号，请选择型号后进行检测", "检测提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.btnStart.Enabled = false;
            this.btnStart.Text = "检测中";

            //1.封装1台当前型号的HVAC
            HVAC objHVAC = new HVAC
            {
                Type = Program.currentProductType,
                Params = CopyListParams(listParam),
                DetectTime = DateTime.Now
            };
            
            //2.将页面展示的HVAC设为该HVAC
            currentDetectedHVAC = objHVAC;

            // 2. 读取PLC检测的数据
            if (!ReadParams(objHVAC))
            {
                MessageBox.Show("读取检测数据错误");
                this.btnStart.Enabled = true;
                this.btnStart.Text = "开始检测";
                return;
            }
            
            //3.  判断HVAC是否合格
            CheckPassed(objHVAC);

            // 4.显示HVAC的 IsDetected参数
            UpdateDgvParam(GetDetectedListParam(objHVAC.Params));
            SetDgvIsPassedColor(dgvParam);

            // 5.显示HVAC的 非IsDetected参数
            this.LFaceDef_Sponge.LanternBackground = objHVAC.Params[24].Value == 1f ? Color.LimeGreen : Color.Red;
            this.LExpansion_Sponge.LanternBackground = objHVAC.Params[25].Value == 1f ? Color.LimeGreen : Color.Red;
            this.LTube_Direction.LanternBackground = objHVAC.Params[26].Value == 1f ? Color.LimeGreen : Color.Red;
            this.LWind_Sponge.LanternBackground = objHVAC.Params[27].Value == 1f ? Color.LimeGreen : Color.Red;
            

            // 6.更新合格数
            if (objHVAC.IsPassed == "合格")
            {
                passNum++;
            }
            else if (objHVAC.IsPassed == "不合格")
            {
                unPassNum++;
            }
            ShowPassNum();

            this.btnStart.Enabled = true;
            this.btnStart.Text = "开始检测";
        }

        /// <summary>
        /// 窗体关闭前，释放一些资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDetectionAuto_FormClosing(object sender, FormClosingEventArgs e)
        {
            objTcpClient.CloseConnect();
            timerCheckComm.Dispose();
        }

        #region private methods

        private void UpdateDgvParam(List<Param> list)
        {
            dgvParam.DataSource = null;
            dgvParam.DataSource = list;
        }

        private void SetDgvIsPassedColor(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[4].Style.BackColor = dgv.Rows[i].Cells[4].Value.ToString() == "合格" ? Color.LawnGreen : Color.Red;

            }
        }

        /// <summary>
        /// 连接服务端 "127.0.0.1"  500
        /// </summary>
        private void ConnectServer()
        {
            if (!objTcpClient.IsConnected)
            {
                objTcpClient.Connect("127.0.0.1", 500, 500, 500, 500);
            }

            this.Invoke(new Action(() => { LComm.LanternBackground = objTcpClient.IsConnected ? Color.LimeGreen : Color.Red; }));
        }

        private void ShowPassNum()
        {
            this.txtPass.Text = passNum.ToString();
            this.txtUnPass.Text = unPassNum.ToString();
        }

        private List<Param> GetDetectedListParam(List<Param> listP)
        {
            List<Param> list = new List<Param>();
            foreach (var item in listP)
            {
                if (item.IsDetected == "1")
                {
                    list.Add(item);
                }
            }
            return list;
        }

        private void CheckPassed(HVAC objHVAC)
        {
            objHVAC.IsPassed = "合格";
            foreach (var item in objHVAC.Params)
            {
                if (item.IsDetected == "1")
                {
                    if (item.Value >= item.ValueLower && item.Value <= item.ValueUpper)
                    {
                        item.IsPassed = "合格";
                    }
                    else
                    {
                        item.IsPassed = "不合格";
                        if (objHVAC.IsPassed == "合格") objHVAC.IsPassed = "不合格";
                    }
                }
                else if (item.IsDetected == "0")
                {
                    if (item.Value == 1f)
                    {
                        item.IsPassed = "合格";
                    }
                    else
                    {
                        item.IsPassed = "不合格";
                        if (objHVAC.IsPassed == "合格") objHVAC.IsPassed = "不合格";
                    }
                }
            }

        }

        private bool ReadParams(HVAC hvac)
        {
            //1.读取保持寄存器的数据,从40000 读到 40046，寄存器数量48
            byte[] b1 = objTcpClient.ReadHoldingRegisters(0, 48, 0);
            //2.处理数据
            if (b1 != null)
            {
                //遍历modbus地址为4区的param
                foreach (Param item in hvac.Params)
                {
                    if (item.ModubsAddr[0] == '4')    //4xxxx
                    {
                        // 40002 => 002 => 4 
                        int start = int.Parse(item.ModubsAddr.Substring(2, 3)) * 2;
                        byte[] data = new byte[4] { b1[start], b1[start + 1], b1[start + 2], b1[start + 3] };
                        data = ReverseFormatDCBA(data);
                        item.Value = BitConverter.ToSingle(data, 0);    //startIndex处的字节为高位字节
                    }
                }
            }
            else
            {
                return false;
            }

            //3.读取输入线圈状态，从00000读到00003，共4个线圈，起始地址为0
            byte[] b2 = objTcpClient.ReadCoilStatus(0, 4, 0);
            if (b2 != null)
            {
                foreach (Param item in hvac.Params)
                {
                    if (item.ModubsAddr[0] == '0')
                    {
                        //获取该变量的相对地址，相对地址为绝对地址减去读取起始地址
                        //此处读取起始地址为0，则相对地址即为modbus绝对地址的尾数
                        int i = int.Parse(item.ModubsAddr.Substring(2, 3));

                        //将第0个字节转换成2进制形式的字符串 11011010
                        string str = Convert.ToString(b2[0], 2).PadLeft(8, '0');

                        char c = str[7 - i];

                        item.Value = (c == '1' ? 1f : 0f);

                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        private byte[] ReverseFormatCDBA(byte[] buff)
        {
            byte[] res = new byte[buff.Length];
            if (buff.Length == 4)
            {
                res[0] = buff[2];
                res[1] = buff[3];
                res[2] = buff[0];
                res[3] = buff[1];
            }
            return res;
        }

        private byte[] ReverseFormatBADC(byte[] buff)
        {
            byte[] res = new byte[buff.Length];
            if (buff.Length == 4)
            {
                res[0] = buff[1];
                res[1] = buff[0];
                res[2] = buff[3];
                res[3] = buff[2];
            }
            return res;
        }

        private byte[] ReverseFormatDCBA(byte[] buff)
        {
            byte[] res = new byte[buff.Length];
            if (buff.Length == 4)
            {
                res[0] = buff[3];
                res[1] = buff[2];
                res[2] = buff[1];
                res[3] = buff[0];
            }
            return res;
        }

        private List<Param> CopyListParams(List<Param> list)
        {
            List<Param> listp = new List<Param>();
            foreach (var item in list)
            {
                Param p = new Param()
                {
                    Value = item.Value,
                    ValueLower = item.ValueLower,
                    ValueUpper = item.ValueUpper,
                    ParamName = item.ParamName,
                    ModubsAddr = item.ModubsAddr,
                    IsDetected = item.IsDetected,
                    IsPassed = item.IsPassed,
                    Note = item.Note
                };
                listp.Add(p);
            }
            return listp;
        }
        #endregion


        private void timerCheckComm_Tick(object sender, EventArgs e)
        {
            LComm.LanternBackground = objTcpClient.IsConnected ? Color.LimeGreen : Color.Red;
        }

        /// <summary>
        /// 将当前检测的HVAC添加至数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentDetectedHVAC == null)
            {
                MessageBox.Show("没有当前检测产品信息", "保存提示");
                return;
            }
            int HvacId = 0;
            //1.存储HVAC
            try
            {
                HvacId = objHVACService.AddHVAC(currentDetectedHVAC);
            }
            catch (Exception ex)
            {
                MessageBox.Show("存储HVAC产品失败，原因：" + ex.Message);
                return;
            }
            if (HvacId == 0)
            {
                MessageBox.Show("存储HVAC产品出现错误，HVACId=" + HvacId.ToString());
                return;
            }

            //至此获取了该台HVAC的Id,HVAC产品存储成功   
            //2.存储HVAC的参数信息
            try
            {
                if (objHVACService.AddParams(currentDetectedHVAC, HvacId))
                {
                    MessageBox.Show("HVAC产品信息和参数信息存储成功，HVACId=" + HvacId.ToString());
                }
                else
                {
                    MessageBox.Show("存储HVAC的参数信息失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("存储HVAC产品失败，原因：" + ex.Message);
                return;
            }
        }
    }
}
