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
using DAL;
using Models;

namespace HVACDetectingSystem
{
    public partial class FrmParamSet : Form
    {
        #region constructor
        private FrmParamSet()
        {
            InitializeComponent();

            //初始化型号下拉框
            cboType.Items.Add("D01");
            cboType.Items.Add("D02");
            cboType.Items.Add("D03");
            cboType.SelectedIndex = 0;

            //设置dgv
            DataGridViewStyle.DoubleBuffered(this.dgvParamSet, true);
            this.dgvParamSet.AutoGenerateColumns = false;

            //根据当前型号，读取显示参数列表
            if (Program.currentProductType != null)
            {
                selectedType = Program.currentProductType;
                listParam = XMLService.GetParamsByType(Program.currentProductType);
                UpdateDgvParamSet();
            }
        }
        private static FrmParamSet singleInstance;
        public static FrmParamSet GetSingleInstance()
        {
            if (singleInstance == null || singleInstance.IsDisposed)
            {
                singleInstance = new FrmParamSet();
            }
            return singleInstance;
        }
        #endregion

        /// <summary>
        /// 检测参数集合
        /// </summary>
        private List<Param> listParam;

        private string selectedType;

        /// <summary>
        /// 根据型号读取显示参数列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (cboType.Text.Trim())
            {
                case "D01":
                    selectedType = "D01";
                    listParam = XMLService.GetParamsByType("D01");
                    break;
                case "D02":
                    selectedType = "D02";
                    listParam = XMLService.GetParamsByType("D02");
                    break;
                case "D03":
                    selectedType = "D03";
                    listParam = XMLService.GetParamsByType("D03");
                    break;
                default:
                    break;
            }
            UpdateDgvParamSet();
        }

        private void UpdateDgvParamSet()
        {
            lblSet.Text = selectedType + " 参 数 设 置";
            dgvParamSet.DataSource = null;
            dgvParamSet.DataSource = listParam;
        }

        /// <summary>
        /// 将dgv列表中的参数设置保存至xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //保存前信息确认
            DialogResult result = MessageBox.Show("确定保存" + selectedType + "型号的参数设置吗？", "保存提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK) return;

            //遍历dgv封装修改对象
            for (int i = 0; i < dgvParamSet.Rows.Count; i++)//遍历每1行
            {
                //修改每1行对应的param对象
                if (listParam[i].Note == dgvParamSet.Rows[i].Cells[0].Value.ToString())
                {
                    listParam[i].ValueUpper = Convert.ToSingle(dgvParamSet.Rows[i].Cells[1].Value);
                    listParam[i].ValueLower = Convert.ToSingle(dgvParamSet.Rows[i].Cells[2].Value);
                }
            }

            if (XMLService.SaveParamsByType(listParam,selectedType))
            {
                MessageBox.Show(selectedType + "型号的参数保存成功", "保存提示",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(selectedType + "型号的参数保存失败", "保存提示",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
