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

using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;

namespace CityPlanning.Forms
{
    public partial class frmAnalysisTrafficNetworkDensity : Form
    {
        private string filePathOfRoadDistributionMap;
        private string filePathOfPolygonBoundaryMap;
        private string filePathOfTrafficDensityMap;
        private bool startAnalysis;

        public string FilePathOfRoadDistributionMap
        {
            set { filePathOfRoadDistributionMap = value; }
            get { return filePathOfRoadDistributionMap; }
        }

        public string FilePathOfPolygonBoundaryMap
        {
            set { filePathOfPolygonBoundaryMap = value; }
            get { return filePathOfPolygonBoundaryMap; }
        }

        public string FilePathOfTrafficDensityMap
        {
            set { filePathOfTrafficDensityMap = value; }
            get { return filePathOfTrafficDensityMap; }
        }

        public bool StartAnalysis
        {
            set { startAnalysis = value; }
            get { return startAnalysis; }
        }

        public frmAnalysisTrafficNetworkDensity()
        {
            InitializeComponent();
            this.tbRoadDistributionMapPath.Text = "";
            this.tbPolygonBoundaryMapPath.Text = "";
            this.tbTrafficDensityMapPath.Text = "";
        }

        //输入文件（道路分布图）变更按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（道路分布图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.tbRoadDistributionMapPath.Text.ToString();
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbRoadDistributionMapPath.Text = openFileDialog.FileName;

            ICommand pCommand;
            pCommand = new ControlsAddDataCommandClass();
            //pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }

        //输入文件（面状边界图）变更按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开输入文件（面状边界图）";
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.tbRoadDistributionMapPath.Text.ToString();
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbPolygonBoundaryMapPath.Text = openFileDialog.FileName;
        }

        //输出文件（交通密度图）变更按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "输出文件路径（交通密度图）";
            //openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "shp文件|*.shp";
            string curDir = this.tbRoadDistributionMapPath.Text.ToString();
            if (curDir != "")
                openFileDialog.InitialDirectory = Path.GetDirectoryName(curDir);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tbTrafficDensityMapPath.Text = openFileDialog.FileName;
        }

        //开始分析
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.filePathOfRoadDistributionMap == "" || this.filePathOfPolygonBoundaryMap == "" ||
                this.filePathOfTrafficDensityMap == "")
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
            this.FilePathOfRoadDistributionMap = this.tbRoadDistributionMapPath.Text.ToString().Trim();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.FilePathOfPolygonBoundaryMap = this.tbPolygonBoundaryMapPath.Text.ToString().Trim();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.FilePathOfTrafficDensityMap = this.tbTrafficDensityMapPath.Text.ToString().Trim();
        }
    }
}
