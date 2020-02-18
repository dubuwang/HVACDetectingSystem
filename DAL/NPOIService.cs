using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Windows.Forms;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace DAL
{
    public class NPOIService
    {
        #region DataGridView 转出至Excle文件

        public static bool DgvToExcel(string fileName, DataGridView dgv)
        {
            #region 获取文件路径
            //SaveFileDialog sfd = new SaveFileDialog();
            ////文件后缀列表    
            //sfd.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx ";
            ////默然路径是系统当前路径    
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //if (sfd.ShowDialog() == DialogResult.Cancel) return false;
            //string fileName = sfd.FileName;
            #endregion

            //【1】基于NPOI创建工作簿和工作表对象
            HSSFWorkbook hssf = new HSSFWorkbook();   //2007以下版本 .xls
            XSSFWorkbook xssf = new XSSFWorkbook();   //2007以上版本 .xlsx
            //根据不同的office版本创建不同的工作簿对象
            //根据文件后缀名判断office版本，创建不同的工作簿对象
            IWorkbook workBook = null;
            string extension = Path.GetExtension(fileName);
            if (extension == ".xls")
            {
                workBook = hssf;
            }
            else if (extension == ".xlsx")
            {
                workBook = xssf;
            }
            else
            {
                //文件后缀有错误
                return false;
            }

            //【2】创建工作表
            ISheet sheet = workBook.CreateSheet("sheet1");

            //【3】循环生成列标题和设置样式
            IRow rowTitle = sheet.CreateRow(0);
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                ICell cell = rowTitle.CreateCell(i);                    //创建单元格 
                cell.SetCellValue(dgv.Columns[i].HeaderText.Trim());    // 设置行标题
                SetCellStyle(workBook, cell);                           //设置单元格边框 
                SetColumnWidth(sheet, i, 20);                           //设置列宽   
            }

            //【4】循环生成各行数据
            for (int i = 0; i < dgv.RowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    
                    ICell cell = row.CreateCell(j);
                    cell.SetCellValue(dgv.Rows[i].Cells[j].Value.ToString().Trim());  //赋值
                    SetCellStyle(workBook, cell);
                }
            }

            //【5】保存为Excel文件
            using (FileStream fs = File.OpenWrite(fileName))
            {
                workBook.Write(fs);
                return true;
            }
        }

        #endregion


        #region 辅助方法

        /// <summary>
        /// 设置cell单元格边框的公共方法
        /// </summary>
        /// <param name="workBook">接口类型的工作簿，能适应不同版本</param>
        /// <param name="cell">cell单元格对象</param>
        private static void SetCellStyle(IWorkbook workBook, ICell cell)
        {
            ICellStyle style = workBook.CreateCellStyle();
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Center;//水平对齐
            style.VerticalAlignment = VerticalAlignment.Center;//垂直对齐
            //设置字体
            IFont font = workBook.CreateFont();
            font.FontName = "微软雅黑";
            // 字体高度
            font.FontHeightInPoints=12 ;
            font.Color = IndexedColors.Green.Index;   //字体颜色         
            //font.Color =(short )FontColor .Red  ;
            style.SetFont(font);
            cell.CellStyle = style;
        }
        /// <summary>
        /// 设置cell单元格列宽的公共方法
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index">第几列</param>
        /// <param name="width">具体宽度值</param>
        private static void SetColumnWidth(ISheet sheet, int index, int width)
        {
            sheet.SetColumnWidth(index, width * 256);
        }

        #endregion

    }
}
