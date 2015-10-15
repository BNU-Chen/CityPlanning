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
    public partial class frmAnalysisEcologicalPriceEvaluation : Form
    {
        private string filePathOfLandtypeDistributionMap;
        private string filePathOfPolygonBoundaryMap;
        private string filePathOfEcologicalPriceDistributionMap;
        private double lindiPrice;
        private double caodiPrice;
        private double nongtianPrice;
        private double shidiPrice;
        private double heliuOrHupoPrice;
        private bool startAnalysis;

        public string FilePathOfLandtypeDistributionMap
        {
            set 
            { 
                filePathOfLandtypeDistributionMap = value;
                //this.tbLandtypeDistributionMapPath.Text = value;
            }
            get { return filePathOfLandtypeDistributionMap; }
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
        public string FilePathOfEcologicalPriceDistributionMap
        {
            set 
            { 
                filePathOfEcologicalPriceDistributionMap = value;
                //this.tbEcologicalPriceDistributionMapPath.Text = value;
            }
            get { return filePathOfEcologicalPriceDistributionMap; }
        }

        public double LindiPrice
        {
            set { lindiPrice = value; }
            get { return lindiPrice; }
        }

        public double CaodiPrice
        {
            set { caodiPrice = value; }
            get { return caodiPrice; }
        }

        public double NongtianPrice
        {
            set { nongtianPrice = value; }
            get { return nongtianPrice; }
        }

        public double ShidiPrice
        {
            set { shidiPrice = value; }
            get { return shidiPrice; }
        }

        public double HeliuOrHupoPrice
        {
            set { heliuOrHupoPrice = value; }
            get { return heliuOrHupoPrice; }
        }

        public bool StartAnalysis
        {
            set { startAnalysis = value; }
            get { return startAnalysis; }
        }

        public frmAnalysisEcologicalPriceEvaluation()
        {
            InitializeComponent();
            this.tbLandtypeDistributionMapPath.Text = "";
            this.tbPolygonBoundaryMapPath.Text = "";
            this.tbEcologicalPriceDistributionMapPath.Text = "";
            this.tbLindiPrice.Text = "12628.69";
            this.tbCaodiPrice.Text = "5241.00";
            this.tbNongtianPrice.Text = "3547.89";
            this.tbShidiPrice.Text = "24597.21";
            this.tbHeliuOrHupoPrice.Text = "20366.69";
        }

        //输入文件（地类分布图）变更按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（地类分布图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfLandtypeDistributionMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbLandtypeDistributionMapPath.Text = openFileDialog.FileName;
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

        //输出文件（生态物价图）变更按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "输出文件路径（生态物价图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.filePathOfEcologicalPriceDistributionMap;
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbEcologicalPriceDistributionMapPath.Text = openFileDialog.FileName;
        }

        //开始分析
        private void button4_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(this.filePathOfLandtypeDistributionMap) || !System.IO.File.Exists(this.filePathOfPolygonBoundaryMap) ||
                !System.IO.File.Exists(this.filePathOfEcologicalPriceDistributionMap) || this.lindiPrice == 0.0 || this.caodiPrice == 0.0 || 
                this.nongtianPrice == 0.0 || this.shidiPrice == 0.0 || this.heliuOrHupoPrice == 0.0)
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
            this.filePathOfLandtypeDistributionMap = this.tbLandtypeDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfPolygonBoundaryMap = this.tbPolygonBoundaryMapPath.Text.ToString().Trim();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.filePathOfEcologicalPriceDistributionMap = this.tbEcologicalPriceDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(this.tbLindiPrice.Text.ToString().Trim());
            this.LindiPrice = price;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(this.tbCaodiPrice.Text.ToString().Trim());
            this.CaodiPrice = price;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(this.tbNongtianPrice.Text.ToString().Trim());
            this.NongtianPrice = price;
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(this.tbShidiPrice.Text.ToString().Trim());
            this.ShidiPrice = price;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(this.tbHeliuOrHupoPrice.Text.ToString().Trim());
            this.HeliuOrHupoPrice = price;
        }
    }
}
