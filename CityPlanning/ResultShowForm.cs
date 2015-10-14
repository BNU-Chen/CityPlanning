using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CityPlanning
{
    public partial class ResultShowForm : Form
    {
        private DataGridView dataGrid1; 
        public ResultShowForm(string text)
        {
            InitializeComponent();
            this.dataGrid1 = new System.Windows.Forms.DataGridView();
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(400,200);
        }

        private void ResultShowForm_Load(object sender, EventArgs e)
        {
            string strcon = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ConnectionCenter.Config.FTPCatalog+@"\eco.xlsx" + ";Extended Properties=Excel 12.0";
            OleDbConnection myConn = new OleDbConnection(strcon);
            string strcom = "SELECT * FROM[Sheet1$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strcom, myConn);
            System.Data.DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet,"[Sheet1$]");
            myConn.Close();
            dataGrid1 = new DataGridView();
            dataGrid1.DataMember = "[Sheet1$]";
            dataGrid1.DataSource = myDataSet;
        }

        private void ResultShowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.ResFrm = null;
        }
    }
}
