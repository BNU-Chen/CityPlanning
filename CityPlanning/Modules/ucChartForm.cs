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
        private string sheetName = null;

        public string SheetName
        {
            get { return sheetName; }
            set { sheetName = value; }
        }

        
        public ucChartForm(MainForm _mainFrm)
        {
            InitializeComponent();
            this.mainFrm = _mainFrm;
            this.Size = new Size(600, 400);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
        }

        private void ucChartForm_Activated(object sender, EventArgs e)
        {
            mainFrm.curChartForm = this;
        }

    }
}