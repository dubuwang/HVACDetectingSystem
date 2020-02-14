using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Models;
using DAL;

namespace HVACDetectingSystem
{
    public partial class FrmLogin : Form
    {

        #region Constructor 实现单例模式-饿汉式
        private FrmLogin()
        {
            InitializeComponent();
        }
        private static FrmLogin singleInstance = null;
        public static FrmLogin GetSingleInstance()
        {
            if (singleInstance == null||singleInstance.IsDisposed)
            {
                singleInstance = new FrmLogin();
            }
            return singleInstance;
        }
        #endregion

        #region private member

        private UserService objUserService = new UserService();

        #endregion

        #region event
        /// <summary>
        /// 登陆成功事件
        /// </summary>
        public event Action<User> LoginCompleted;

        #endregion

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUserId.Text.Trim().Length == 0 || this.txtPwd.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请输入账号Id和密码", "登陆提示");
                this.txtUserId.Focus();
                return;
            }
            if (!DataValidate.IsInteger(this.txtUserId.Text.Trim()))
            {
                MessageBox.Show("用户名格式错误，必须为正整数", "登陆提示");
                this.txtUserId.Focus();
                return;
            }

            User objUser = new User()
            {
                UserId = Convert.ToInt32(this.txtUserId.Text.Trim()),
                UserPwd = this.txtPwd.Text.Trim()
            };

            //提交数据库验证
            try
            {
                objUser = this.objUserService.AdminLogin(objUser);

                if (objUser != null)
                {
                    //触发登陆成功事件
                    LoginCompleted?.Invoke(objUser);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登陆失败，用户名或密码错误", "登陆提示");
                    this.txtUserId.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登陆账号数据库验证出错：" + ex.Message, "登陆错误");
                return;
            }
        }

        private void btnNLogin_Click(object sender, EventArgs e)
        {
            User objUser = new User()
            {
                UserName = "匿名用户"
            };

            //触发登陆成功事件
            this.LoginCompleted(objUser);

            this.Close();
        }

        
    }
}
