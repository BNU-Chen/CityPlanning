using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraCharts;

namespace CityPlanning.Modules
{
    public partial class ucChartShow : UserControl
    {
        private ViewType chartViewType; //图表类型
        private ChartTitle chartTitle;  //图表标题
        private string axisXChartTitle; //横轴标题
        private string axisYChartTitle; //纵轴标题
        private DataTable dataSource;   //数据源
        private string axisXField;      //横轴字段名
        private List<string> axisYFields;   //纵轴字段名
        private List<Color> seriesColors;   //系列颜色
        private bool showSeriesLabels;  //显示系列标签
        private bool showLegend;        //显示图例

        public ViewType ChartViewType   //图表类型
        {
            set { this.chartViewType = value; }
            get { return this.chartViewType; }
        }

        public ChartTitle ChartTitle   //图表标题
        {
            set { this.chartTitle = value; }
            get { return this.chartTitle; }
        }

        public string AxisXChartTitle  //横轴标题
        {
            set { this.axisXChartTitle = value; }
            get { return this.axisXChartTitle; }
        }

        public string AxisYChartTitle  //纵轴标题
        {
            set { this.axisYChartTitle = value; }
            get { return this.axisYChartTitle; }
        }

        public DataTable DataSource    //数据源
        {
            set { this.dataSource = value; }
            get { return this.dataSource; }
        }

        public string AxisXField       //横轴字段名
        {
            set { this.axisXField = value; }
            get { return this.axisXField; }
        }

        public List<string> AxisYFields    //纵轴字段名
        {
            set { this.axisYFields = value; }
            get { return this.axisYFields; }
        }

        public List<Color> SeriesColors    //系列颜色
        {
            set { this.seriesColors = value; }
            get { return this.seriesColors; }
        }

        public bool ShowSeriesLabels   //显示系列标签
        {
            set { this.showSeriesLabels = value; }
            get { return this.showSeriesLabels; }
        }

        public bool ShowLegend         //显示图例
        {
            set { this.showLegend = value; }
            get { return this.showLegend; }
        }

        public ucChartShow()
        {
            InitializeComponent();
            this.ChartViewType=ViewType.Bar;
            this.AxisYFields=new List<string>();   //纵轴字段名
            this.SeriesColors = new List<Color>();   //系列颜色
            this.ShowSeriesLabels = true;  //显示系列标签
            this.ShowLegend = true;        //显示图例
        }

        public void SetChartShow(DataTable dt, ViewType vt, string xField, List<string> AxisYFields)
        {
            this.DataSource = dt;
            this.ChartViewType = vt;
            this.AxisXField = xField;
            this.AxisYFields = new List<string>();
            //if (this.ChartViewType == ViewType.Pie) this.AxisYFields.Add(AxisYFields[0]);
            //else foreach (string filed in AxisYFields) this.AxisYFields.Add(filed);
            foreach (string filed in AxisYFields) this.AxisYFields.Add(filed);
            //GetAxisYFields();
            ResetChartControl();
        }

        //从数据源获取纵轴显示字段
        private void GetAxisYFields()
        {
            DataTable dt = this.dataSource;
            if (dt != null)
            {
                if (this.axisXField == null || this.axisXField == "") this.axisXField = dt.Columns[0].ColumnName;
                foreach (DataColumn cl in dt.Columns)
                {
                    if (cl.ColumnName != this.axisXField) this.axisYFields.Add(cl.ColumnName);
                }
            }
        }

        //图表显示控件重置
        private void ResetChartControl()
        {
            chartAddSeries();
            if (this.chartViewType == ViewType.Pie && this.AxisYFields.Count == 1) 
            {
                SetChartTitle(this.dataSource.TableName.Replace("$", "") + "-" + this.axisYFields[0], Color.Black, new Font("宋体", 24, FontStyle.Bold));
            }
            else 
            {
                SetChartTitle(this.dataSource.TableName.Replace("$", ""), Color.Black, new Font("宋体", 24, FontStyle.Bold));
                if (this.chartViewType != ViewType.Pie) SetAxisXChartTitle(this.axisXField, Color.Black, new Font("宋体", 10, FontStyle.Regular));
            }
            SetLegend(true);
        }

        //添加数据系列
        private void chartAddSeries()
        {
            try
            {
                DataTable dt = this.dataSource;
                this.chartShowControl.Series.Clear();
                foreach (string val in this.axisYFields)
                {
                    if (dt.Columns[val].DataType.Name == "String") continue;
                    Series series = new Series(val, this.chartViewType);
                    this.chartShowControl.Series.Add(series);
                    series.DataSource = dt;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    series.ArgumentDataMember = this.axisXField;
                    series.ValueScaleType = ScaleType.Numerical;
                    series.ValueDataMembers.AddRange(new string[] { val });
                    if (this.ChartViewType == ViewType.Pie) settingOfPieChart(series);
                }
            }
            catch { }
            AddPieSeriesViewTitle();
        }

        //饼状图数据系列设置
        private void settingOfPieChart( Series ser )
        {
            Series series = ser;
            series.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series.Label.PointOptions.ValueNumericOptions.Precision = 0;
            ((PieSeriesLabel)series.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
        }

        //设置图表标题
        public void SetChartTitle(String title, Color titleColor, Font titleFont)
        {
            ChartTitle chartTitle = new ChartTitle();
            chartTitle = new ChartTitle();
            chartTitle.Text = title;
            chartTitle.TextColor = Color.Black;
            chartTitle.Font = titleFont;
            chartShowControl.Titles.Clear();
            chartShowControl.Titles.Add(chartTitle);
        }

        //设置横轴标题
        public void SetAxisXChartTitle(String title, Color titleColor, Font titleFont)
        {
            XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
            diagram.AxisX.Title.Visible = true;
            diagram.AxisX.Title.Antialiasing = true;
            diagram.AxisX.Title.Alignment = StringAlignment.Center;
            diagram.AxisX.Title.Text = title;
            diagram.AxisX.Title.TextColor = titleColor;
            diagram.AxisX.Title.Font = titleFont;
        }

        //设置纵轴标题
        public void SetAxisYChartTitle(String title, Color titleColor, Font titleFont)
        {
            XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
            diagram.AxisY.Title.Visible = true;
            diagram.AxisY.Title.Antialiasing = true;
            diagram.AxisY.Title.Alignment = StringAlignment.Center;
            diagram.AxisY.Title.Text = title;
            diagram.AxisY.Title.TextColor = titleColor;
            diagram.AxisY.Title.Font = titleFont;
        }

        //设置图例显示
        public void SetLegend(bool showOrNot)
        {
            this.chartShowControl.Legend.Visible = showOrNot;
        }

        //为饼状图添加子标题
        public void AddPieSeriesViewTitle()
        {
            if (this.ChartViewType == ViewType.Pie)
            {
                try
                {
                    foreach (Series ser in this.chartShowControl.Series)
                    {
                        PieSeriesView myView = (PieSeriesView)ser.View;
                        myView.Titles.Add(new SeriesTitle());
                        myView.Titles[0].Text = ser.Name;
                    }
                }
                catch { }
            }
        }

        //清空控件内容
        public void Clear()
        {
            this.chartShowControl.Series.Clear();
            this.chartShowControl.Titles.Clear();
            XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
            diagram.Dispose();
        }

        //饼状图单击移出事件
        private void chartShowControl_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            try
            {
                if (this.ChartViewType == ViewType.Pie)
                {
                    Series ser = (Series)e.HitInfo.Series;
                    SeriesPoint sp = e.HitInfo.SeriesPoint;

                    bool sp_exploded = false;
                    foreach (SeriesPoint spp in ((PieSeriesView)ser.View).ExplodedPoints)
                    {
                        if (sp == spp) sp_exploded = true;
                    }

                    if (sp_exploded == true) ((PieSeriesView)ser.View).ExplodedPoints.Remove(sp);
                    else if (e.HitInfo.SeriesPoint != null)
                        ((PieSeriesView)ser.View).ExplodedPoints.Add(e.HitInfo.SeriesPoint);
                }
            }
            catch { }
        }
    }
}
