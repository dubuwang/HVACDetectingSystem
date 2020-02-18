using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DAL;
using Models;

namespace HVACDetectingSystem
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();

            this.cboType.Items.Add("日报表");
            this.cboType.Items.Add("月度报表");
            this.cboType.Items.Add("年度报表");
            this.cboType.SelectedIndex = 0;

            //dgv
            this.dgvReport.AutoGenerateColumns = false;
            Common.DataGridViewStyle.DoubleBuffered(dgvReport, true);
        }

        private List<HVAC> currentListH;

        private HVACService objHVACService = new HVACService();

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.Text)
            {
                case "日报表":
                    dtp.CustomFormat = "yyyy-MM-dd";
                    break;
                case "月度报表":
                    dtp.CustomFormat = "yyyy-MM";
                    break;
                case "年度报表":
                    dtp.CustomFormat = "yyyy";
                    break;
                default:
                    break;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DateTime time = dtp.Value;
            string reportType = cboType.Text.Trim();

            try
            {
                currentListH = objHVACService.GetHVACSByTime(time, reportType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询出现错误，原因："+ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateDgv(currentListH);
        }

        private void UpdateDgv(List<HVAC> list)
        {
            dgvReport.DataSource = null;
            dgvReport.DataSource = list;
        }


        private void dgvReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1&&this.dgvReport.Rows[e.RowIndex].Cells[0].Value.ToString()!=null)
            {
                if (currentListH[e.RowIndex] == null) return;

                try
                {
                    currentListH[e.RowIndex].Params = objHVACService.GetParamsByHvacId(currentListH[e.RowIndex].HvacId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取产品详细参数信息出现错误，原因：" + ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                new FrmProduct(currentListH[e.RowIndex]).ShowDialog();
                
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            
            //文件后缀列表    
            sfd.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
            //默然路径是系统当前路径    
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); 
            if (sfd.ShowDialog() == DialogResult.Cancel) return;
            string fileName = sfd.FileName;

            if (dgvReport.DataSource == null) return;

            if (NPOIService.DgvToExcel(fileName, dgvReport))
            {
                MessageBox.Show("文件保存成功", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("文件保存失败", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
