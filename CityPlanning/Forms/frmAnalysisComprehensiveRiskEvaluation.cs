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
    public partial class frmAnalysisComprehensiveRiskEvaluation : Form
    {
        private string filePathOfEarthquakeDistributionMap;
        private string filePathOfFloodDistributionMap;
        private string filePathOfSandyDistributionMap;
        private string filePathOfOtherDistributionMap;
        private string filePathOfPolygonBoundaryMap;
        private string filePathOfEvaluationResultMap;
        private bool startAnalysis;

        public string FilePathOfEarthquakeDistributionMap
        {
            set 
            { 
                filePathOfEarthquakeDistributionMap = value;
                //this.tbEarthquakeDistributionMapPath.Text = value;
            }
            get { return filePathOfEarthquakeDistributionMap; }
        }
        public string FilePathOfFloodDistributionMap
        {
            set 
            { 
                filePathOfFloodDistributionMap = value;
                //this.tbFloodDistributionMapPath.Text = value;
            }
            get { return filePathOfFloodDistributionMap; }
        }
        public string FilePathOfSandyDistributionMap
        {
            set 
            { 
                filePathOfSandyDistributionMap = value;
                //this.tbSandyDistributionMapPath.Text = value;
            }
            get { return filePathOfSandyDistributionMap; }
        }
        public string FilePathOfOtherDistributionMap
        {
            set 
            { 
                filePathOfOtherDistributionMap = value;
                //this.tbOtherDistributionMapPath.Text = value;
            }
            get { return filePathOfOtherDistributionMap; }
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
        public string FilePathOfEvaluationResultMap
        {
            set 
            { 
                filePathOfEvaluationResultMap = value;
                //this.tbEvaluationResultMapPath.Text = value;
            }
            get { return filePathOfEvaluationResultMap; }
        }
        public bool StartAnalysis
        {
            set { startAnalysis = value; }
            get { return startAnalysis; }
        }

        public frmAnalysisComprehensiveRiskEvaluation()
        {
            InitializeComponent();
            this.tbEarthquakeDistributionMapPath.Text = "";
            this.tbFloodDistributionMapPath.Text = "";
            this.tbEvaluationResultMapPath.Text = "";
            this.tbSandyDistributionMapPath.Text = "";
            this.tbOtherDistributionMapPath.Text = "";
            this.tbPolygonBoundaryMapPath.Text = "";
        }

        //输入文件（地震分布图）变更按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（地震分布图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfEarthquakeDistributionMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbEarthquakeDistributionMapPath.Text = openFileDialog.FileName;
        }
        //输入文件（洪涝分布图）变更按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（洪涝分布图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfFloodDistributionMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbFloodDistributionMapPath.Text = openFileDialog.FileName;
        }
        //输出文件（评估结果图）变更按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "输出文件路径（评估结果图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfEvaluationResultMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbEvaluationResultMapPath.Text = openFileDialog.FileName;
        }
        //输入文件（沙化分布图）变更按钮点击事件
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（沙化分布图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfSandyDistributionMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbSandyDistributionMapPath.Text = openFileDialog.FileName;
        }
        //输入文件（其他灾害图）变更按钮点击事件
        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（其他灾害图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfPolygonBoundaryMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbOtherDistributionMapPath.Text = openFileDialog.FileName;
        }
        //输入文件（面状边界图）变更按钮点击事件
        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（面状边界图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfPolygonBoundaryMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbPolygonBoundaryMapPath.Text = openFileDialog.FileName;
        }

        //开始分析
        private void button4_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(this.filePathOfEarthquakeDistributionMap) || !System.IO.File.Exists(this.filePathOfFloodDistributionMap) ||
                !System.IO.File.Exists(this.filePathOfSandyDistributionMap) || !System.IO.File.Exists(this.filePathOfOtherDistributionMap) ||
                !System.IO.File.Exists(this.filePathOfPolygonBoundaryMap) || !System.IO.File.Exists(this.filePathOfEvaluationResultMap))
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
            this.filePathOfEarthquakeDistributionMap = this.tbEarthquakeDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfFloodDistributionMap = this.tbFloodDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfEvaluationResultMap = this.tbEvaluationResultMapPath.Text.ToString().Trim();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfSandyDistributionMap = this.tbSandyDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfOtherDistributionMap = this.tbOtherDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfPolygonBoundaryMap = this.tbPolygonBoundaryMapPath.Text.ToString().Trim();
        }
    }
}
