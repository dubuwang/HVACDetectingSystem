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
using Common;

namespace HVACDetectingSystem
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        public FrmProduct(HVAC objHVAC) : this()
        {
            this.txtId.Text = objHVAC.HvacId.ToString();
            this.txtIsPassed.Text = objHVAC.IsPassed;
            this.txtTime.Text = objHVAC.DetectTime.ToString();
            this.txtType.Text = objHVAC.Type.ToString();

            this.dgv1.AutoGenerateColumns = false;
            Common.DataGridViewStyle.DoubleBuffered(dgv1, true);
            this.dgv1.DataSource = objHVAC.Params;
        }
    }
}
