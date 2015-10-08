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

namespace CityPlanning
{
    public partial class ThreadForm : DevExpress.XtraEditors.XtraForm
    {
        public ThreadForm(int _Min, int _Max)
        {
            InitializeComponent();
            progressBar1.Maximum = _Max;
            progressBar1.Value = progressBar1.Minimum = _Min;
        }
        public void setPos(int value)
        {
            if (value < progressBar1.Maximum)
            {
                progressBar1.Value = value;
                label2.Text = (value * 100 / progressBar1.Maximum).ToString() + "%";
            }
            Application.DoEvents();
        }
        private void ThreadForm_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void ThreadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }
    }
}