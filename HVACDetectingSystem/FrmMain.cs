using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace HVACDetectingSystem
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            //添加menuStrip的分隔符
            this.menuStrip1.Items.Insert(0, new ToolStripSeparator());
            this.menuStrip1.Items.Insert(2, new ToolStripSeparator());
            this.menuStrip1.Items.Insert(4, new ToolStripSeparator());

            //创建登陆窗体并显示
            this.menuStrip1.Enabled = false;    //未登陆前，禁用menustrip
            FrmLogin objFrmLogin = FrmLogin.GetSingleInstance();
            objFrmLogin.LoginCompleted += FrmLogin_LoginCompleted;
            OpenSubForm(objFrmLogin);
        }

        /// <summary>
        /// modbusTcp客户端,由主窗体创建持有
        /// </summary>
        public ModbusTcpClient objTcpClient = ModbusTcpClient.GetSingleInstance();

        #region 子窗体的事件注册的方法

        /// <summary>
        /// 用户登陆成功事件注册的方法
        /// </summary>
        /// <param name="objUser"></param>
        private void FrmLogin_LoginCompleted(Models.User objUser)
        {
            Program.objCurrentUser = objUser;
            toolStripStatusLbl_User.Text = " 登陆用户:" + objUser.UserName;

            ShowMessage(objUser.UserName + "登陆成功");

            //启用menustrip
            this.menuStrip1.Enabled = true;

            //创建型号选择窗体并显示，此时为登录状态
            CloseExistedSubForm();
            FrmType objFrmtype = FrmType.GetSingleInstance();
            objFrmtype.SelectTypeCompleted += Frmtype_SelectTypeCompleted;
            OpenSubForm(objFrmtype);
        }

        /// <summary>
        /// 选择型号成功事件注册的方法
        /// </summary>
        /// <param name="type"></param>
        private void Frmtype_SelectTypeCompleted(string type)
        {
            Program.currentProductType = type;
            ShowMessage("当前产品型号：" + Program.currentProductType);
        }

        #endregion

        #region 嵌入显示子界面窗体

        /// <summary>
        /// 嵌入显示用户登陆窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem用户切换_Click(object sender, EventArgs e)
        {
            //创建登陆窗体并显示，此时为已登陆状态
            CloseExistedSubForm(); //针对单例窗体，先关闭再创建，避免重复打开1个窗体时，已经获取的窗体实例已经被disposed
            FrmLogin objFrmLogin = FrmLogin.GetSingleInstance();
            objFrmLogin.LoginCompleted += FrmLogin_LoginCompleted;
            OpenSubForm(objFrmLogin);
        }

        /// <summary>
        /// 嵌入显示型号选择窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem型号选择_Click(object sender, EventArgs e)
        {
            //创建型号选择窗体并显示
            CloseExistedSubForm();
            FrmType objFrmtype = FrmType.GetSingleInstance();
            objFrmtype.SelectTypeCompleted += Frmtype_SelectTypeCompleted;
            OpenSubForm(objFrmtype);
        }

        private void ToolStripMenuItem参数设置_Click(object sender, EventArgs e)
        {
            //创建参数设置窗体并显示
            CloseExistedSubForm();
            FrmParamSet objFrmParamSet = FrmParamSet.GetSingleInstance();
            OpenSubForm(objFrmParamSet);
        }

        private void ToolStripMenuItem自动检测_Click(object sender, EventArgs e)
        {
            //创建自动检测窗体并显示
            CloseExistedSubForm();
            OpenSubForm(new FrmDetectionAuto(this.objTcpClient));
        }

        private void ToolStripMenuItem报表_Click(object sender, EventArgs e)
        {
            //创建报表窗体并显示
            CloseExistedSubForm();
            OpenSubForm(new FrmReport());
        }

        //private void ToolStripMenuItem手动检测_Click(object sender, EventArgs e)
        //{
        //    //创建手动检测窗体并显示
        //    CloseExistedSubForm();
        //    OpenSubForm(new FrmDetectionManual());
        //}

        private void ToolStripMenuItem退出系统_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        /// <summary>
        /// 消息框中显示消息
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMessage(string msg)
        {
            this.toolStripStatusLbl_Message.Text = msg;
        }

        #region 子窗体嵌入显示

        private void OpenSubForm(Form objFrm)
        {

            //往容器中嵌入新的子窗体
            objFrm.TopLevel = false;  //将子窗体设置成非顶级控件
            objFrm.FormBorderStyle = FormBorderStyle.None;    //去掉窗体的边框   
            objFrm.Parent = this.splitContainer1.Panel1;
            objFrm.Dock = DockStyle.Fill;

            objFrm.Show();
        }

        private void CloseExistedSubForm()
        {
            foreach (Control item in this.splitContainer1.Panel1.Controls)
            {
                //存在则关闭
                if (item is Form objForm)
                {
                    objForm.Close();
                }
            }
        }


        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
