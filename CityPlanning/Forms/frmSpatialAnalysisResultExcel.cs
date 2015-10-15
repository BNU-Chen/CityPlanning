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

using DevExpress.XtraCharts;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;

using CityPlanning.Modules;

namespace CityPlanning.Forms
{
    public partial class frmSpatialAnalysisResultExcel : Form
    {
        public frmSpatialAnalysisResultExcel()
        {
            InitializeComponent();
            this.spreadsheetControl1.Options.HorizontalScrollbar.Visibility = SpreadsheetScrollbarVisibility.Hidden;
            this.spreadsheetControl1.Options.VerticalScrollbar.Visibility = SpreadsheetScrollbarVisibility.Hidden;
        }

        public frmSpatialAnalysisResultExcel(string filePath)
        {
            InitializeComponent();
            this.spreadsheetControl1.Options.HorizontalScrollbar.Visibility = SpreadsheetScrollbarVisibility.Hidden;
            this.spreadsheetControl1.Options.VerticalScrollbar.Visibility = SpreadsheetScrollbarVisibility.Hidden;
            if (File.Exists(filePath))
                this.spreadsheetControl1.LoadDocument(filePath);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChartShow_Click(object sender, EventArgs e)
        {
            SpreadsheetControl ssc = this.spreadsheetControl1;
            Worksheet worksheet = ssc.Document.Worksheets.ActiveWorksheet;
            DataTable dt = StatisticChart.DataOperation.CreateTablefromWorkSheet(worksheet);

            if (dt != null)
            {
                Form frm = new Form();
                ucChartShow ucChartSh = new ucChartShow();
                frm.Size = new System.Drawing.Size(640, 400);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Text = dt.TableName;
                frm.Controls.Add(ucChartSh);
                ucChartSh.Dock = DockStyle.Fill;
                ucChartSh.SetChartShow(dt, ViewType.Bar);
                ucChartSh.Refresh();
                frm.Show();
            }
        }

        private void spreadsheetControl1_ActiveSheetChanged(object sender, ActiveSheetChangedEventArgs e)
        {
            this.spreadsheetControl1.ActiveWorksheet.ActiveView.ShowHeadings = false;
        }
    }
}
