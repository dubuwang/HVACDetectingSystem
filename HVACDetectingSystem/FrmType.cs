using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVACDetectingSystem
{
    public partial class FrmType : Form
    {
        #region 单例模式
        private FrmType()
        {
            InitializeComponent();
        }

        private static FrmType singleInstance;
        public static FrmType GetSingleInstance()
        {
            if (singleInstance == null||singleInstance.IsDisposed)
            {
                singleInstance = new FrmType();
            }
            return singleInstance;
        }

        #endregion

        public event Action<string> SelectTypeCompleted;

        private void btnD01_Click(object sender, EventArgs e)
        {
            
            SelectTypeCompleted?.Invoke(btnD01.Text);
            this.Close();
        }

        private void btnD02_Click(object sender, EventArgs e)
        {
            
            SelectTypeCompleted?.Invoke(btnD02.Text);
            this.Close();
        }

        private void btnD03_Click(object sender, EventArgs e)
        {
           
            SelectTypeCompleted?.Invoke(btnD03.Text);
            this.Close();
        }


    }
}
