using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityPlanning.Modules
{
    public partial class ucDocumentSearch : UserControl
    {
        public ucDocumentSearch()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string key = this.TextEdit_Filter.Text.Trim();

            if (key.Length == 0)
            {
                this.flowLayoutPanel1.Controls.Clear();
            }
            else
            {
                ucDocumentSearchClip docClip = new ucDocumentSearchClip();
                docClip.Key = key;
                docClip.ClipContext = "this is a test,please check.";
                docClip.Width = flowLayoutPanel1.Width - 6;
                flowLayoutPanel1.Controls.Add(docClip);
                flowLayoutPanel1.Refresh();
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            int width = this.flowLayoutPanel1.Width;
            foreach (Control ctl in this.flowLayoutPanel1.Controls)
            {
                ctl.Width = width;
            }
        }
    }
}
