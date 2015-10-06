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
        //INI 
        private string DocConfigSection = "DocConfig";
        private string KeyPlanDoc = "PlanDoc";
        private string KeyPlanDesc = "PlanDesc";
        private string KeyThematicMap = "ThematicMap";
        private string KeyPlanImg = "PlanImg";
        private string KeyPlanMap = "PlanMap";

        private string FTPSection = "FTP";
        private string FTPCatalog = "catalog";

        //
        private string DataPath = "";

        public frmSysConfig()
        {
            InitializeComponent();
        }

        private void frmSysConfig_Load(object sender, EventArgs e)
        {
            DataPath = ConnectionCenter.INIFile.IniReadValue(FTPSection, FTPCatalog);

            this.txt_PlanDoc.Text = ConnectionCenter.INIFile.IniReadValue(DocConfigSection, KeyPlanDoc);
            this.txt_PlanDesc.Text = ConnectionCenter.INIFile.IniReadValue(DocConfigSection, KeyPlanDesc);
            this.txt_ThematicMap.Text = ConnectionCenter.INIFile.IniReadValue(DocConfigSection, KeyThematicMap);
            this.txt_PlanImg.Text = ConnectionCenter.INIFile.IniReadValue(DocConfigSection, KeyPlanImg);
            this.txt_PlanMap.Text = ConnectionCenter.INIFile.IniReadValue(DocConfigSection, KeyPlanMap);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            ConnectionCenter.INIFile.IniWriteValue(DocConfigSection, KeyPlanDoc, this.txt_PlanDoc.Text);
            ConnectionCenter.INIFile.IniWriteValue(DocConfigSection, KeyPlanDesc, this.txt_PlanDesc.Text);
            ConnectionCenter.INIFile.IniWriteValue(DocConfigSection, KeyThematicMap, this.txt_ThematicMap.Text);
            ConnectionCenter.INIFile.IniWriteValue(DocConfigSection, KeyPlanImg, this.txt_PlanImg.Text);
            ConnectionCenter.INIFile.IniWriteValue(DocConfigSection, KeyPlanMap, this.txt_PlanMap.Text);

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            string fullPath = DataPath + path;
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
    }
}
