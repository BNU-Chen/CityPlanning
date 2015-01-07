using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace StatisticChart
{
    public class ShowOperation
    {
        public static bool CreatBarChart(ChartControl chart, DataTable dt)
        {
            if (dt.Columns.Count == 1)
            {
                DataColumn autoColumn = new DataColumn("自定义", System.Type.GetType("System.Int32"));
                dt.Columns.Add(autoColumn);
                dt.Columns["自定义"].SetOrdinal(0);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = i + 1;
                }
            }

            bool suc = true;
            try
            {
                Series series = new Series(dt.Columns[1].ColumnName, ViewType.Bar);
                chart.Series.Add(series);
                series.DataSource = dt;

                series.ArgumentScaleType = ScaleType.Qualitative;
                series.ArgumentDataMember = dt.Columns[0].ColumnName;
                series.ValueScaleType = ScaleType.Numerical;
                series.ValueDataMembers.AddRange(new string[] { dt.Columns[1].ColumnName });

                //((SideBySideBarSeriesView)series.View).ColorEach = true;

                XYDiagram diagram = (XYDiagram)chart.Diagram;
                //Y轴标注不显示？？？郭海强
                diagram.AxisY.Title.Visible = true;
                diagram.AxisY.Title.Alignment = StringAlignment.Center;
                diagram.AxisY.Title.Text = dt.Columns[1].ColumnName;
                diagram.AxisY.Title.Antialiasing = true;
                diagram.AxisY.Title.Font = new Font("宋体", 10, FontStyle.Bold);

                diagram.AxisX.Title.Visible = true;
                diagram.AxisX.Title.Alignment = StringAlignment.Center;
                diagram.AxisX.Title.Text = dt.Columns[0].ColumnName;
                diagram.AxisX.Title.Antialiasing = true;
                diagram.AxisX.Title.Font = new Font("宋体", 10, FontStyle.Bold);

                chart.Legend.Visible = false;
                //生成标题及设置
                ChartTitle cht = new ChartTitle();
                cht.Text = dt.TableName;
                cht.TextColor = Color.Black;
                cht.Font = new Font("宋体", cht.Font.Size, cht.Font.Style);
                chart.Titles.Add(cht);
            }
            catch
            {
                suc = false;
            }
            return suc;
        }
    }
}
