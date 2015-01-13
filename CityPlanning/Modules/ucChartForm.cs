using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Spreadsheet;

namespace CityPlanning.Modules
{
    public partial class ucChartForm : DevExpress.XtraEditors.XtraForm
    {
        private MainForm mainFrm = null;
        private Range range = null;
        private ViewType viewType;
        private DataTable dataSource = null;
        private List<string> variableField = new List<string>();
        private List<string> valueField = new List<string>();

        public List<string> VariableField
        {
            get { return variableField; }
            set { variableField = value; }
        }

        public List<string> ValueField
        {
            get { return valueField; }
            set { valueField = value; }
        }

        public DataTable DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        public ViewType ViewType
        {
            get { return viewType; }
            set { viewType = value; }
        }

        public ChartControl ChartControl
        {
            get { return this.chartControl1; }
            set { this.chartControl1 = value; }
        }

        public Range Range
        {
            get { return range; }
            set { range = value; }
        }
        public ucChartForm(MainForm _mainFrm)
        {
            InitializeComponent();
            this.mainFrm = _mainFrm;
            this.Size = new Size(600, 400);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.MinimizeBox = false;
        }

        private void ucChartForm_Activated(object sender, EventArgs e)
        {
            mainFrm.curChartForm = this;
        }

        private void ucChartForm_Load(object sender, EventArgs e)
        {

            this.Text = "柱状图-" + dataSource.TableName;
            foreach (DataColumn col in dataSource.Columns)
            {
                variableField.Add(col.ColumnName);
                if (col.DataType.IsValueType)
                    valueField.Add(col.ColumnName);
            }
        }

        private void chartControl1_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            if (viewType == ViewType.Pie)
            {
                Series series1 = chartControl1.Series[0];
                SeriesPoint sp = e.HitInfo.SeriesPoint;

                bool sp_exploded = false;
                foreach (SeriesPoint spp in ((PieSeriesView)series1.View).ExplodedPoints)
                {
                    if (sp == spp) sp_exploded = true;
                }

                if (sp_exploded == true) ((PieSeriesView)series1.View).ExplodedPoints.Remove(sp);
                else if (e.HitInfo.SeriesPoint != null)
                    ((PieSeriesView)series1.View).ExplodedPoints.Add(e.HitInfo.SeriesPoint);
            }
        }
    }
}