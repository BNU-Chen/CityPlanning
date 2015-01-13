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
        //生成饼状图
        public static void CreatPieChart(ChartControl chart, DataTable dt)
        {
            try
            {
                chart.Series.Clear();
                chart = AddSeries_Pie(chart, dt);

                chart.Legend.Visible = true;
                //生成标题及设置
                ChartTitle cht = new ChartTitle();
                cht.Text = dt.TableName;
                cht.TextColor = Color.Black;
                cht.Font = new Font("宋体", cht.Font.Size, cht.Font.Style);
                chart.Titles.Clear();
                chart.Titles.Add(cht);
            }
            catch
            {
                
            }
        }
        //生成图表（除饼状图）
        public static void CreatChart(ChartControl chart, DataTable dt, ViewType viewType)
        {
            try
            {
                chart.Series.Clear();
                chart = AddSeries(chart, dt, viewType);
                chart = SetXYDiagram(chart);
                //数据系列大于1才显示图例
                if (chart.Series.Count > 1) 
                    chart.Legend.Visible = true;
                else 
                    chart.Legend.Visible = false;
                //生成标题及设置
                ChartTitle cht = new ChartTitle();
                cht.Text = dt.TableName;
                cht.TextColor = Color.Black;
                cht.Font = new Font("宋体", cht.Font.Size, cht.Font.Style);
                chart.Titles.Clear();
                chart.Titles.Add(cht);
            }
            catch
            {
                
            }
        }
        public static void CreatChart(ChartControl chart, DataTable dt, ViewType viewType, String[] vals)
        {
            try
            {
                chart.Series.Clear();
                chart = AddSeries(chart, dt, viewType, vals);
                chart = SetXYDiagram(chart);
                //数据系列大于1才显示图例
                if (chart.Series.Count > 1)
                    chart.Legend.Visible = true;
                else
                    chart.Legend.Visible = false;
                //生成标题及设置
                ChartTitle cht = new ChartTitle();
                cht.Text = dt.TableName;
                cht.TextColor = Color.Black;
                cht.Font = new Font("宋体", cht.Font.Size, cht.Font.Style);
                chart.Titles.Clear();
                chart.Titles.Add(cht);
            }
            catch
            {

            }
        }
        //为图表添加数据系列
        public static ChartControl AddSeries(ChartControl chart, DataTable dt, ViewType viewType)
        {
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].DataType.Name == "String") continue;
                Series series = new Series(dt.Columns[i].ColumnName, viewType);
                chart.Series.Add(series);
                series.DataSource = dt;
                series.ArgumentScaleType = ScaleType.Qualitative;
                series.ArgumentDataMember = dt.Columns[0].ColumnName;
                series.ValueScaleType = ScaleType.Numerical;
                series.ValueDataMembers.AddRange(new string[] { dt.Columns[i].ColumnName });
            }
            return chart;
        }
        public static ChartControl AddSeries(ChartControl chart, DataTable dt, ViewType viewType, String[] vals)
        {
            foreach (string val in vals)
            {
                if (dt.Columns[val].DataType.Name == "String") continue;
                Series series = new Series(dt.Columns[val].ColumnName, viewType);
                chart.Series.Add(series);
                series.DataSource = dt;
                series.ArgumentScaleType = ScaleType.Qualitative;
                series.ArgumentDataMember = dt.Columns[0].ColumnName;
                series.ValueScaleType = ScaleType.Numerical;
                series.ValueDataMembers.AddRange(new string[] { dt.Columns[val].ColumnName });
            }
            return chart;
        }
        public static ChartControl AddSeries_Pie(ChartControl chart, DataTable dt)
        {
            Series series = new Series(dt.Columns[1].ColumnName, ViewType.Pie);
            chart.Series.Add(series);
            series.DataSource = dt;

            series.ArgumentScaleType = ScaleType.Qualitative;
            series.ArgumentDataMember = dt.Columns[0].ColumnName;
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { dt.Columns[1].ColumnName });

            series.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series.Label.PointOptions.ValueNumericOptions.Precision = 0;

            // Detect overlapping of series labels.
            ((PieSeriesLabel)series.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
            // Access the view-type-specific options of the series.
            PieSeriesView myView = (PieSeriesView)series.View;
            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series.Name;

            return chart;
        }
        //设置Diagram属性
        public static ChartControl SetXYDiagram(ChartControl chart)
        {
            XYDiagram diagram = (XYDiagram)chart.Diagram;
            diagram.AxisX.Title.Visible = true;
            diagram.AxisX.Title.Alignment = StringAlignment.Center;
            diagram.AxisX.Title.Text = chart.Series[0].ArgumentDataMember;
            diagram.AxisX.Title.Antialiasing = true;
            diagram.AxisX.Title.Font = new Font("宋体", 10, FontStyle.Bold);
            return chart;
        }
        public static ChartControl SetChartTitle(ChartControl chart, String title)
        {
            ChartTitle cht = new ChartTitle();
            cht.Text = title;
            cht.TextColor = Color.Black;
            cht.Font = new Font("宋体", cht.Font.Size, cht.Font.Style);
            chart.Titles.Clear();
            chart.Titles.Add(cht);
            return chart;
        }
        public static ChartControl SetAxisXChartTitle(ChartControl chart, String Xtitle)
        {
            XYDiagram diagram = (XYDiagram)chart.Diagram;
            diagram.AxisX.Title.Visible = true;
            diagram.AxisX.Title.Alignment = StringAlignment.Center;
            diagram.AxisX.Title.Text = Xtitle;
            diagram.AxisX.Title.Antialiasing = true;
            diagram.AxisX.Title.Font = new Font("宋体", 10, FontStyle.Bold);
            return chart;
        }
        public static ChartControl SetAxisYChartTitle(ChartControl chart, String Ytitle)
        {
            XYDiagram diagram = (XYDiagram)chart.Diagram;
            diagram.AxisY.Title.Visible = true;
            diagram.AxisY.Title.Alignment = StringAlignment.Center;
            diagram.AxisY.Title.Text = Ytitle;
            diagram.AxisY.Title.Antialiasing = true;
            diagram.AxisY.Title.Font = new Font("宋体", 10, FontStyle.Bold);
            return chart;
        }
    }
}
