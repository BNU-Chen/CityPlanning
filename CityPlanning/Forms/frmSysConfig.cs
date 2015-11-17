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
    public partial class frmSysConfig : Form
    {

        private string DataPath = "";       //当前数据路径

        public frmSysConfig()
        {
            InitializeComponent();
        }

        private void frmSysConfig_Load(object sender, EventArgs e)
        {
            DataPath = ConnectionCenter.Config.FTPCatalog;

            this.txt_PlanDoc.Text = ConnectionCenter.Config.PlanDoc;
            this.txt_PlanDesc.Text = ConnectionCenter.Config.PlanDesc;
            this.txt_ThematicMap.Text = ConnectionCenter.Config.ThematicMap;
            this.txt_PlanImg.Text = ConnectionCenter.Config.PlanImg;
            this.txt_PlanMap.Text = ConnectionCenter.Config.PlanMap;
            
            this.txt_RedLineMap.Text = ConnectionCenter.Config.RedLineMap;
            this.txt_ThematicTrafficNet.Text = ConnectionCenter.Config.ThematicTraffic;
            this.txt_ThematicElectricityNet.Text = ConnectionCenter.Config.ThematicElectricity;
            this.txt_ThematicDisaster.Text = ConnectionCenter.Config.ThematicDisaster;
            this.txt_ThematicZoology.Text = ConnectionCenter.Config.ThematicZoology;
            this.txt_ThematicGDPTrans.Text = ConnectionCenter.Config.ThematicGDPTrans;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            ConnectionCenter.Config.PlanDoc = this.txt_PlanDoc.Text;
            ConnectionCenter.Config.PlanDesc = this.txt_PlanDesc.Text;
            ConnectionCenter.Config.ThematicMap = this.txt_ThematicMap.Text;
            ConnectionCenter.Config.PlanImg = this.txt_PlanImg.Text;
            ConnectionCenter.Config.PlanMap = this.txt_PlanMap.Text;

            ConnectionCenter.Config.RedLineMap = this.txt_RedLineMap.Text;
            ConnectionCenter.Config.ThematicTraffic = this.txt_ThematicTrafficNet.Text;
            ConnectionCenter.Config.ThematicElectricity = this.txt_ThematicElectricityNet.Text;
            ConnectionCenter.Config.ThematicDisaster = this.txt_ThematicDisaster.Text;
            ConnectionCenter.Config.ThematicZoology = this.txt_ThematicZoology.Text;
            ConnectionCenter.Config.ThematicGDPTrans = this.txt_ThematicGDPTrans.Text;

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region //规划数据 按钮
        //规划文本
        private void btn_SetPlanDoc_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_PlanDoc);
        }

        private void btn_OpenPlanDoc_Click(object sender, EventArgs e)
        {
            OpenPath(this.txt_PlanDoc.Text);
        }
        //规划说明
        private void btn_SetPlanDesc_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_PlanDesc);
        }

        private void btn_OpenPlanDesc_Click(object sender, EventArgs e)
        {
            OpenPath(this.txt_PlanDesc.Text);
        }
        //专题图
        private void btn_SetThematicMap_Click(object sender, EventArgs e)
        {
            SetFolderPath(this.txt_ThematicMap);
        }

        private void btn_OpenThematicMap_Click(object sender, EventArgs e)
        {
            OpenPath(this.txt_ThematicMap.Text);
        }
        //规划图件
        private void btn_SetPlanImg_Click(object sender, EventArgs e)
        {
            SetFolderPath(this.txt_PlanImg);
        }

        private void btn_OpenPlanImg_Click(object sender, EventArgs e)
        {
            OpenPath(this.txt_PlanImg.Text);
        }
        //规划地图
        private void btn_SetPlanMap_Click(object sender, EventArgs e)
        {
            SetFolderPath(this.txt_PlanMap);
        }

        private void btn_OpenPlanMap_Click(object sender, EventArgs e)
        {
            OpenPath(this.txt_PlanMap.Text);
        }
        #endregion 

        #region //专题图集 按钮
        //基本红线地图
        private void btn_SetRedLineMap_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_RedLineMap);
        }

        private void btn_OpenRedLineMap_Click(object sender, EventArgs e)
        {
            OpenFullPath(this.txt_RedLineMap.Text.Trim());
        }
        //交通网络
        private void btn_SetThematicTrafficNet_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_ThematicTrafficNet);
        }

        private void btn_OpenThematicTrafficNet_Click(object sender, EventArgs e)
        {
            OpenFullPath(this.txt_ThematicTrafficNet.Text);
        }
        //电力网络
        private void btn_SetThematicElectricityNet_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_ThematicElectricityNet);
        }

        private void btn_OpenThematicElectricityNet_Click(object sender, EventArgs e)
        {
            OpenFullPath(this.txt_ThematicElectricityNet.Text);
        }
        //灾害风险
        private void btn_SetThematicDisaster_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_ThematicDisaster);
        }

        private void btn_OpenThematicDisaster_Click(object sender, EventArgs e)
        {
            OpenFullPath(this.txt_ThematicDisaster.Text);
        }
        //生态服务
        private void btn_SetThematicZoology_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_ThematicZoology);
        }

        private void btn_OpenThematicZoology_Click(object sender, EventArgs e)
        {
            OpenFullPath(this.txt_ThematicZoology.Text);
        }
        //GDP重心转移
        private void btn_SetThematicGDPTrans_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_ThematicGDPTrans);
        }

        private void btn_OpenThematicGDPTrans_Click(object sender, EventArgs e)
        {
            OpenFullPath(this.txt_ThematicGDPTrans.Text);
        }
        #endregion

        #region //设置路径函数
        //设置路径
        private void SetFilePath(TextBox txtBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "设定路径";
            ofd.Multiselect = false;
            if (Directory.Exists(DataPath))
            {
                ofd.InitialDirectory = DataPath;
            }
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    string selectPath = ofd.FileName;
                    if (selectPath.Contains(DataPath))
                    {
                        txtBox.Text = selectPath.Substring(DataPath.Length, selectPath.Length - DataPath.Length);
                    }
                    else
                    {
                        MessageBox.Show("您没有在指定文件夹内指定路径，请重新选择");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("您选择的文件不存在，请重新选择");
                    return;
                }
            }
        }
        private void SetFolderPath(TextBox txtBox)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DataPath != "")
            {
                if (Directory.Exists(DataPath))
                {
                    fbd.SelectedPath = DataPath;
                }
            }
            fbd.Description = "设定路径";
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectPath = fbd.SelectedPath;
                if (selectPath.Contains(DataPath))
                {
                    txtBox.Text = selectPath.Substring(DataPath.Length, selectPath.Length - DataPath.Length);
                }
                else
                {
                    MessageBox.Show("您没有在指定文件夹内指定路径，请重新选择");
                    return;
                }
            }
        }

        //打开路径
        private void OpenPath(string path)
        {
            string fullPath = DataPath + path.Trim();
            bool flag = false;
            if (File.Exists(fullPath))
            {
                flag = true;
            }
            else if (Directory.Exists(fullPath))
            {
                flag = true;
            }
            if (!flag)
            {
                MessageBox.Show("路径不存在，请重新设置。");
                return;
            }
            System.Diagnostics.Process.Start("Explorer", "/select," + fullPath);
        }

        private void OpenFullPath(string path)
        {
            string fullPath = path.Trim();
            bool flag = false;
            if (File.Exists(fullPath))
            {
                flag = true;
            }
            else if (Directory.Exists(fullPath))
            {
                flag = true;
            }
            if (!flag)
            {
                MessageBox.Show("路径不存在，请重新设置。");
                return;
            }
            System.Diagnostics.Process.Start("Explorer", "/select," + fullPath);
        }
        #endregion
    }
}
