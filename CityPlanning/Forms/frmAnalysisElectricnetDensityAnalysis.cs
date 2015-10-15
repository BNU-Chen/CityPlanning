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
    public partial class frmAnalysisElectricnetDensityAnalysis : Form
    {
        private string filePathOfElectricnetDistributionMap;
        private string filePathOfPolygonBoundaryMap;
        private string filePathOfElectricnetDensityMap;
        private bool startAnalysis;

        public string FilePathOfElectricnetDistributionMap
        {
            set 
            { 
                filePathOfElectricnetDistributionMap = value;
                //this.tbElectricnetDistributionMapPath.Text = value;
            }
            get { return filePathOfElectricnetDistributionMap; }
        }
        public string FilePathOfPolygonBoundaryMap
        {
            set 
            { 
                filePathOfPolygonBoundaryMap = value;
                //this.tbPolygonBoundaryMapPath.Text = value;
            }
            get { return filePathOfPolygonBoundaryMap; }
        }
        public string FilePathOfElectricnetDensityMap
        {
            set 
            { 
                filePathOfElectricnetDensityMap = value;
                //this.tbElectricnetDensityMapPath.Text = value;
            }
            get { return filePathOfElectricnetDensityMap; }
        }
        public bool StartAnalysis
        {
            set { startAnalysis = value; }
            get { return startAnalysis; }
        }

        public frmAnalysisElectricnetDensityAnalysis()
        {
            InitializeComponent();
            this.tbElectricnetDistributionMapPath.Text = "";
            this.tbPolygonBoundaryMapPath.Text = "";
            this.tbElectricnetDensityMapPath.Text = "";
        }

        //输入文件（电网分布图）变更按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（电网分布图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfElectricnetDistributionMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbElectricnetDistributionMapPath.Text = openFileDialog.FileName;
        }

        //输入文件（面状边界图）变更按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（面状边界图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfPolygonBoundaryMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbPolygonBoundaryMapPath.Text = openFileDialog.FileName;
        }

        //输出文件（电网密度图）变更按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "输出文件路径（电网密度图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfElectricnetDensityMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbElectricnetDensityMapPath.Text = openFileDialog.FileName;
        }

        //开始分析
        private void button4_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(this.filePathOfElectricnetDistributionMap) || !System.IO.File.Exists(this.filePathOfPolygonBoundaryMap) ||
                !System.IO.File.Exists(this.filePathOfElectricnetDensityMap))
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
            this.filePathOfElectricnetDistributionMap = this.tbElectricnetDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfPolygonBoundaryMap = this.tbPolygonBoundaryMapPath.Text.ToString().Trim();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfElectricnetDensityMap = this.tbElectricnetDensityMapPath.Text.ToString().Trim();
        }
    }
}
