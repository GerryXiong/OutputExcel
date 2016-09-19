using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutputExcel
{
    public class ExcelHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">需要导出到excel的数据表dt</param>
        /// <param name="saveFileName">存储文件名</param>
        /// <returns></returns>
        public static void DataTableToExcel(System.Data.DataTable dt, string saveFileName)
        {
            if (dt == null) return;
            //-***************获取excel对象***************
            //  string saveFileName = "";
            TimeSpan dateBegin = new TimeSpan(DateTime.Now.Ticks);
            bool fileSaved = false;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.FileName = saveFileName + "-" + DateTime.Today.ToString("yyyy-MM-dd");
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法启动Excel，可能您未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook workbook = xlApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;



            // 列索引，行索引，总列数，总行数                   
            int colIndex = 0;
            int RowIndex = 0;
            int colCount = dt.Columns.Count;
            int RowCount = dt.Rows.Count;


            // *****************获取数据*********************

            // 创建缓存数据
            object[,] objData = new object[RowCount + 1, colCount];
            // 获取列标题
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                objData[RowIndex, colIndex++] = dt.Columns[i].Caption; // dgv.Columns[i].HeaderText;
            }

            // 获取具体数据
            for (RowIndex = 0; RowIndex < RowCount; RowIndex++)
            {
                for (colIndex = 0; colIndex < colCount; colIndex++)
                {
                    objData[RowIndex + 1, colIndex] = dt.Rows[RowIndex][colIndex];
                }

            }


            //*******************设置输出格式******************************

            //设置顶部説明   合并的单元格
            //range = worksheet.Range[xlApp.Cells[1, 1], xlApp.Cells[1, colCount]];
            //range.MergeCells = true;
            //range.RowHeight = 38;
            //range.Font.Bold = true;
            //range.Font.Size = 14;
            //range.Font.ColorIndex = 10;//字体颜色
            //xlApp.ActiveCell.FormulaR1C1 = "导入记录查询结果";

            //特殊数字格式
            //range = worksheet.get_Range(xlApp.Cells[2, colCount], xlApp.Cells[RowCount, colCount]);


            //xlApp.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            //range = worksheet.Range[xlApp.Cells[2, 1], xlApp.Cells[2, colCount]];

            //range.Font.Bold = true;
            //range.RowHeight = 20;


            //********************* 写入Excel*******************
            range = worksheet.Range[xlApp.Cells[1, 1], xlApp.Cells[RowCount + 1, colCount]];
            range.Value2 = objData;
            worksheet.Columns.EntireColumn.AutoFit();
            worksheet.Rows.EntireRow.AutoFit();
            Range rng01 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[RowCount + 1 , 4];
            rng01.ColumnWidth = 20;
            System.Windows.Forms.Application.DoEvents();

            //***************************保存**********************

            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                    fileSaved = true;
                }
                catch (Exception ex)
                {
                    fileSaved = false;
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            else
            {
                fileSaved = false;
            }
            xlApp.Quit();
            GC.Collect();//强行销毁   

            TimeSpan dateEnd = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan tspan = dateBegin.Subtract(dateEnd).Duration();
            //MessageBox.Show("导出成功，用时" + tspan.ToString() + "秒");
            if (fileSaved && System.IO.File.Exists(saveFileName))
                System.Diagnostics.Process.Start(saveFileName); //保存成功后打开此文件
        }
    }



}
