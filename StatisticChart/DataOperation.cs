using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;


namespace StatisticChart
{
    public class DataOperation
    {
        //根据worksheet选中区域数据创建DataTable
        public static DataTable CreateTablefromWorkSheet(Worksheet worksheet)
        {
            DataTable outtable = new DataTable(worksheet.Name);
            CellCollection cells = worksheet.Cells;
            Range range = worksheet.Selection;
            //选中区只有一行不创建表
            if (range.RowCount == 1)
            {
                outtable = null;
                return outtable;
            }
            else
            {
                bool allNumber = true;
                //创建表格，以worksheet中第一行数据为列名，根据第二行数据设置列数据类型
                for (int i = 0; i < range.ColumnCount; i++)
                {
                    int colnum = range.LeftColumnIndex + i;
                    decimal val;
                    bool isnumber = decimal.TryParse(cells[1, colnum].Value.ToString(), out val);
                    if (isnumber)
                        outtable.Columns.Add(cells[0, colnum].Value.ToString(), typeof(decimal));
                    else
                    { 
                        outtable.Columns.Add(cells[0, colnum].Value.ToString(), typeof(string));
                        allNumber = false;
                    }
                        
                }

                //添加数据
                try
                {
                    for (int i = 0; i < range.RowCount; i++)
                    {
                        if (range.TopRowIndex == 0 && i == 0) continue;
                        DataRow row = outtable.NewRow();
                        for (int j = 0; j < range.ColumnCount; j++)
                        {
                            int rownum = range.TopRowIndex + i;
                            int colnum = range.LeftColumnIndex + j;
                            row[j] = cells[rownum, colnum].Value.ToString();
                        }
                        outtable.Rows.Add(row);
                    }
                }
                catch
                {
                    outtable = null;
                }
                if (outtable != null && allNumber == true)
                {
                    outtable = AddAutoColumn(outtable);
                }
                return outtable;
            }
        }
        //对单列数据添加自定义列
        public static DataTable AddAutoColumn(DataTable dt)
        {
            DataColumn autoColumn = new DataColumn("自定义", System.Type.GetType("System.Int32"));
            dt.Columns.Add(autoColumn);
            dt.Columns["自定义"].SetOrdinal(0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = i + 1;
            }
            return dt;
        }
    }
}
