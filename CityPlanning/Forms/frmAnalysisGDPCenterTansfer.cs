using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CityPlanning.Forms
{
    public partial class frmAnalysisGDPCenterTansfer : Form
    {
        private string filePathOfCityCenterDistributionMap;
        private string filePathOfGDPStatisticalTable;
        private string filePathOfEconomicCenterTransferMap;
        private bool startAnalysis;

        public string FilePathOfCityCenterDistributionMap
        {
            set { filePathOfCityCenterDistributionMap = value; }
            get { return filePathOfCityCenterDistributionMap; }
        }

        public string FilePathOfGDPStatisticalTable
        {
            set { filePathOfGDPStatisticalTable = value; }
            get { return filePathOfGDPStatisticalTable; }
        }

        public string FilePathOfEconomicCenterTransferMap
        {
            set { filePathOfEconomicCenterTransferMap = value; }
            get { return filePathOfEconomicCenterTransferMap; }
        }

        public bool StartAnalysis
        {
            set { startAnalysis = value; }
            get { return startAnalysis; }
        }

        public frmAnalysisGDPCenterTansfer()
        {
            InitializeComponent();
            this.tbCityCenterDistributionMapPath.Text = "";
            this.tbGDPStatisticalTablePath.Text = "";
            this.tbEconomicCenterTransferMapPath.Text = "";
        }

        //输入文件（城市中心分布图）变更按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（城市中心分布图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.tbCityCenterDistributionMapPath.Text.ToString();
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbCityCenterDistributionMapPath.Text = openFileDialog.FileName;
        }

        //输入文件（历年GDP统计表）变更按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（历年GDP统计表）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Excel文件|*.xls|*.xlsx";
            string curDir = this.tbCityCenterDistributionMapPath.Text.ToString();
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbGDPStatisticalTablePath.Text = openFileDialog.FileName;
        }

        //输出文件（交通密度图）变更按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "输出文件路径（交通密度图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.tbCityCenterDistributionMapPath.Text.ToString();
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbEconomicCenterTransferMapPath.Text = openFileDialog.FileName;
        }

        //开始分析
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.filePathOfCityCenterDistributionMap == "" || this.filePathOfGDPStatisticalTable == "" ||
                this.filePathOfEconomicCenterTransferMap == "")
            {
                MessageBox.Show("分析设置未完成，请完成设置再开始分析！");
                return;
            }
            this.StartAnalysis = true;
            this.Close();
        }

        //取消分析
        private void button5_Click(object sender, EventArgs e)
        {
            this.StartAnalysis = false;
            this.Close();
        }

        //文件路径文本框内容变更事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.FilePathOfCityCenterDistributionMap = this.tbCityCenterDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.FilePathOfGDPStatisticalTable = this.tbGDPStatisticalTablePath.Text.ToString().Trim();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.FilePathOfEconomicCenterTransferMap = this.tbEconomicCenterTransferMapPath.Text.ToString().Trim();
        }
    }
}
