using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityPlanning.Forms
{
    public partial class frmAddMapKeyword : Form
    {
        private string sectionName = "";
        private string keyName = "";
        private string curKeys = "";

        public frmAddMapKeyword(string _sectionName,string _keyName)
        {
            InitializeComponent();
            sectionName = _sectionName;
            keyName = _keyName;
        }

        private void btn_AddMapKey_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                return;
            }
            string keywords = "";
            //先获取key
            curKeys = ConnectionCenter.INIFile.IniReadValue(sectionName, keyName);
            //追加key
            if (curKeys == "")
            {
                keywords = this.textBox1.Text.Trim();
            }
            else
            {
                keywords = curKeys +"," + this.textBox1.Text.Trim();
            }
            ConnectionCenter.INIFile.IniWriteValue(sectionName, keyName, keywords);
            this.Close();
            MessageBox.Show("添加成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
