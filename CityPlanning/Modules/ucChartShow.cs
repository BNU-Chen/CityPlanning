using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using DevExpress.XtraCharts;
using DevExpress.Utils;

namespace CityPlanning.Modules
{
    public partial class ucChartShow : UserControl
    {
        private DataTable dataSource;   //数据源

        public DataTable DataSource    //数据源
        {
            set { this.dataSource = value; }
            get { return this.dataSource; }
        }

        public ucChartShow()
        {
            InitializeComponent();
            this.icbeChartType.SelectedIndex = getIndexByViewType(ViewType.Bar);
            this.checkChartLegend.Checked = true;
            this.checkChartDataLable.Checked = false;
            this.checkAxisXNetworkLine.Checked = true;
            this.checkAxisYNetworkLine.Checked = false;
            this.checkPieDataShowType.Visible = false;
        }

        #region //图标显示设置

        //设置图表显示
        public void SetChartShow(DataTable dt, ViewType vt)
        {
            this.Clear();
            this.DataSource = null;
            this.DataSource = dt.Copy();
            this.icbeChartType.SelectedIndex = getIndexByViewType(vt);
            this.teChartTitle.Text = dt.TableName;
            this.getDataFieldFromDataTable(dt);
            this.cbeAxisXDataField.SelectedIndex = 0;
            this.checkedAxisYDataField.CheckAll();
            try
            {
                XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
                if (diagram != null)
                {
                    diagram.AxisX.GridLines.Visible = this.checkAxisXNetworkLine.Checked;
                    diagram.AxisY.GridLines.Visible = this.checkAxisYNetworkLine.Checked;
                }
            }
            catch { }
            this.chartShowControl.Refresh();
        }

        //图表显示控件重置
        private void ResetChartControl()
        {
            try
            {
                chartAddSeries();
                if (getViewTypByIndex(this.icbeChartType.SelectedIndex) == ViewType.Pie)
                {
                    SetChartTitle(this.dataSource.TableName.Replace("$", ""), Color.Black, new Font("宋体", 24, FontStyle.Bold));// + "-" + this.checkedAxisYDataField.SelectedText, Color.Black
                    this.checkPieDataShowType.Visible = true;
                }
                else
                {
                    SetChartTitle(this.dataSource.TableName.Replace("$", ""), Color.Black, new Font("宋体", 24, FontStyle.Bold));
                    this.checkPieDataShowType.Visible = false;
                }
                this.chartShowControl.Legend.Visible = this.checkChartLegend.Checked;
                XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
                diagram.AxisX.GridLines.Visible = this.checkAxisXNetworkLine.Checked;
                diagram.AxisY.GridLines.Visible = this.checkAxisYNetworkLine.Checked;
            }
            catch { }
        }

        //添加数据系列
        private void chartAddSeries()
        {
            try
            {
                DataTable dt = this.dataSource;
                this.chartShowControl.Series.Clear();
                List<object> val_objs = this.checkedAxisYDataField.Properties.Items.GetCheckedValues();
                ViewType vT = this.getViewTypByIndex(this.icbeChartType.SelectedIndex);
                if (vT == ViewType.Pie) val_objs.RemoveRange(1, val_objs.Count - 1);
                foreach (object val_obj in val_objs)
                {
                    string val = val_obj.ToString();
                    if (dt.Columns[val].DataType.Name == "String") continue;
                    Series series = new Series(val, vT);
                    this.chartShowControl.Series.Add(series);
                    series.DataSource = dt;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    series.ArgumentDataMember = this.cbeAxisXDataField.SelectedItem.ToString();
                    series.ValueScaleType = ScaleType.Numerical;
                    series.ValueDataMembers.AddRange(new string[] { val });
                    if (vT == ViewType.Pie) settingOfPieChart(series);
                }
            }
            catch { }
            //AddPieSeriesViewTitle();
        }

        //设置图表标题
        public void SetChartTitle(String title, Color titleColor, Font titleFont)
        {
            ChartTitle chartTitle = new ChartTitle();
            chartTitle = new ChartTitle();
            chartTitle.Text = title;
            chartTitle.TextColor = titleColor;
            chartTitle.Font = titleFont;
            chartShowControl.Titles.Clear();
            chartShowControl.Titles.Add(chartTitle);
        }

        //设置横轴标题
        public void SetAxisXChartTitle(String title, Color titleColor, Font titleFont)
        {
            try
            {
                XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
                diagram.AxisX.Title.Visible = true;
                diagram.AxisX.Title.Antialiasing = true;
                diagram.AxisX.Title.Alignment = StringAlignment.Center;
                diagram.AxisX.Title.Text = title;
                diagram.AxisX.Title.TextColor = titleColor;
                diagram.AxisX.Title.Font = titleFont;
            }
            catch { }
        }

        //设置纵轴标题
        public void SetAxisYChartTitle(String title, Color titleColor, Font titleFont)
        {
            try
            {
                XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
                diagram.AxisY.Title.Visible = true;
                diagram.AxisY.Title.Antialiasing = true;
                diagram.AxisY.Title.Alignment = StringAlignment.Center;
                diagram.AxisY.Title.Text = title;
                diagram.AxisY.Title.TextColor = titleColor;
                diagram.AxisY.Title.Font = titleFont;
            }
            catch { }
        }

        //清空控件内容
        public void Clear()
        {
            this.teChartTitle.Text = "";
            this.teAxisXTitle.Text = "";
            this.teAxisYTitle.Text = "";
            this.cbeAxisXDataField.Properties.Items.Clear();
            this.checkedAxisYDataField.Properties.Items.Clear();
            this.chartShowControl.Series.Clear();
            this.chartShowControl.Titles.Clear();
            this.checkChartLegend.Checked = true;
            this.checkChartDataLable.Checked = false;
            this.checkAxisYNetworkLine.Checked = false;
            this.checkAxisXNetworkLine.Checked = false;
            try
            {
                XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
                if (diagram != null) diagram.Dispose();
            }
            catch { }
        }

        #region //饼状图设置

        //饼状图数据系列设置
        private void settingOfPieChart(Series ser)
        {
            /*
            Series series = new Series(val, vT);
                    this.chartShowControl.Series.Add(series);
                    series.DataSource = dt;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    series.ArgumentDataMember = this.cbeAxisXDataField.SelectedItem.ToString();
                    series.ValueScaleType = ScaleType.Numerical;
                    series.ValueDataMembers.AddRange(new string[] { val });
                    if (vT == ViewType.Pie) settingOfPieChart(series);
            */
            Series series = ser;
            series.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            if(this.checkPieDataShowType.Checked)
                series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            else
                series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Scientific;
            series.Label.PointOptions.ValueNumericOptions.Precision = 0;
            ((PieSeriesLabel)series.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
        }

        //为饼状图添加子标题
        public void AddPieSeriesViewTitle()
        {
            ViewType vT = this.getViewTypByIndex(this.icbeChartType.SelectedIndex);
            if (vT == ViewType.Pie)
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

        //饼状图单击移出事件
        private void chartShowControl_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            ViewType vT = this.getViewTypByIndex(this.icbeChartType.SelectedIndex);
            try
            {
                if (vT == ViewType.Pie)
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

        #endregion

        #endregion

        #region //辅助转换函数

        //根据图表类型获取编号
        private int getIndexByViewType(ViewType vT)
        {
            int index;
            switch (vT)
            {
                case ViewType.Bar:
                    index = 0;
                    break;
                case ViewType.Line:
                    index = 1;
                    break;
                case ViewType.Point:
                    index = 2;
                    break;
                case ViewType.Pie:
                    index = 3;
                    break;
                default:
                    index = 0;
                    break;
            }
            return index;
        }

        //根据编号获取图表类型
        private ViewType getViewTypByIndex(int index)
        {
            ViewType vT;
            switch (index)
            {
                case 0:
                    vT = ViewType.Bar;
                    break;
                case 1:
                    vT = ViewType.Line;
                    break;
                case 2:
                    vT = ViewType.Point;
                    break;
                case 3:
                    vT = ViewType.Pie;
                    break;
                default:
                    vT = ViewType.Bar;
                    break;
            }
            return vT;
        }

        //从数据源获取横纵轴数据字段
        private void getDataFieldFromDataTable(DataTable dt)
        {
            try
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    this.cbeAxisXDataField.Properties.Items.Add(dc.ColumnName);
                    decimal val;
                    if (decimal.TryParse(dt.Rows[0][dc.ColumnName].ToString(), out val))
                        this.checkedAxisYDataField.Properties.Items.Add(dc.ColumnName);
                }
            }
            catch { }
        }

        #endregion

        #region //控件操作事件

        //图例显示变更事件
        private void checkChartLegend_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.chartShowControl.Legend.Visible = this.checkChartLegend.Checked;
                this.chartShowControl.Refresh();
            }
            catch { }
        }

        //数据标签显示变更事件
        private void checkChartDataLable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkChartDataLable.Checked)
                    foreach (Series ser in this.chartShowControl.Series)
                    {
                        ser.LabelsVisibility = DefaultBoolean.True;
                        ser.Label.ResolveOverlappingMode = ResolveOverlappingMode.HideOverlapped;
                    }
                else
                    foreach (Series ser in this.chartShowControl.Series)
                        ser.LabelsVisibility = DefaultBoolean.False;
                this.chartShowControl.Refresh();
            }
            catch { }
        }

        //横轴网络线变更事件
        private void checkAxisXNetworkLine_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
                diagram.AxisX.GridLines.Visible = this.checkAxisXNetworkLine.Checked;
                this.chartShowControl.Refresh();
            }
            catch { }
        }

        //纵轴网络线变更事件
        private void checkAxisYNetworkLine_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                XYDiagram diagram = (XYDiagram)(this.chartShowControl).Diagram;
                diagram.AxisY.GridLines.Visible = this.checkAxisYNetworkLine.Checked;
                this.chartShowControl.Refresh();
            }
            catch { }
        }

        //图表类型变更事件
        private void icbeChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.Clear();
            ResetChartControl();
            this.chartShowControl.Refresh();
        }

        //图表横轴数据字段变更事件
        private void cbeAxisXDataField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<object> checkedItems = this.checkedAxisYDataField.Properties.Items.GetCheckedValues();
                if (checkedItems.Count == 0) return;
                else ResetChartControl();
            }
            catch { }
        }

        //图表纵轴数据字段变更事件
        private void checkedAxisYDataField_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                List<object> checkedItems = this.checkedAxisYDataField.Properties.Items.GetCheckedValues();
                if (checkedItems.Count == 0) return;
                else ResetChartControl();
            }
            catch { }
        }

        //图表标题变更事件
        private void teChartTitle_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetChartTitle(this.teChartTitle.Text, Color.Black, new Font("宋体", 24, FontStyle.Bold));
            }
            catch { }
        }

        //图表横轴标题变更事件
        private void teAxisXTitle_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetAxisXChartTitle(this.teAxisXTitle.Text, Color.Black, new Font("宋体", 16, FontStyle.Bold));
            }
            catch { }
        }

        //图表纵轴标题变更事件
        private void teAxisYTitle_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetAxisYChartTitle(this.teAxisYTitle.Text, Color.Black, new Font("宋体", 16, FontStyle.Bold));
            }
            catch { }
        }

        //图标输出
        private void btnSaveAs_MouseClick(object sender, MouseEventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "PDF文件（*.pdf）|*.pdf|Excel文件（*.xls）|*.xls|JPG文件（*.jpg）|*.jpg|PNG文件（*.png）|*.png|TIF文件（*.tif）|*.tif|BMP文件（*.bmp）|*.bmp";
            saveFileDlg.RestoreDirectory = true;
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = saveFileDlg.FileName.ToString();
                string fileNameExt = Path.GetExtension(localFilePath);
                switch (fileNameExt)
                {
                    case ".pdf":
                        this.chartShowControl.ExportToPdf(localFilePath);
                        break;
                    case ".xls":
                        this.chartShowControl.ExportToXls(localFilePath);
                        break;
                    case ".jpg":
                        this.chartShowControl.ExportToImage(localFilePath, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        this.chartShowControl.ExportToImage(localFilePath, ImageFormat.Png);
                        break;
                    case ".tif":
                        this.chartShowControl.ExportToImage(localFilePath, ImageFormat.Tiff);
                        break;
                    case ".bmp":
                        this.chartShowControl.ExportToImage(localFilePath, ImageFormat.Bmp);
                        break;
                    default: break;
                }
            }
        }

        //饼状图数据显示方式，百分比/数据
        private void checkPieDataShowType_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkPieDataShowType.Checked == true)
                foreach (Series series in this.chartShowControl.Series)
                    series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            else
                foreach (Series series in this.chartShowControl.Series)
                    series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.General;
        }

        #endregion


        
    }
}
