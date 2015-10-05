using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using DevExpress.XtraTab;

namespace CityPlanning.Modules
{
    public partial class ucNavigationImage : UserControl
    {
        private string imageFolderPath = "";    //图片文件夹
        private string thumbImagePath = "";     //缩略图文件夹
        private XtraTabControl xTabControl = null;

        public XtraTabControl XTabControl
        {
            get { return xTabControl; }
            set { xTabControl = value; }
        }
        
        public string ImageFolderPath
        {
            get { return imageFolderPath; }
            set 
            { 
                imageFolderPath = value;
                thumbImagePath = imageFolderPath+ "\\thumb";

                if (!Directory.Exists(imageFolderPath))
                {
                    return;
                }
                if (!Directory.Exists(thumbImagePath))
                {
                    return;
                }
                GetImages(thumbImagePath);
            }
        }


        public ucNavigationImage()
        {
            InitializeComponent();
            //this.MouseWheel += new MouseEventHandler(flowLayoutPanel1_MouseWheel);
        }

        void flowLayoutPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                this.flowLayoutPanel1.Focus();
            }
            catch
            { }
            //throw new NotImplementedException();
        }

        private void GetImages(string path)
        {
            string[] files = Directory.GetFiles(path, "*.jpg");
            this.flowLayoutPanel1.Controls.Clear();
            foreach (string file in files)
            {
                ucImageThumb ucThumb = new ucImageThumb();
                ucThumb.Size = new System.Drawing.Size(160, 120);
                ucThumb.ImagePath = file;
                ucThumb.PicBox.Click +=ucThumb_Click;
                ucThumb.PicBox.MouseWheel += flowLayoutPanel1_MouseWheel;
                this.flowLayoutPanel1.Controls.Add(ucThumb);
            }
        }

        void ucThumb_Click(object sender, EventArgs e)
        {

            DevExpress.XtraEditors.PictureEdit ucImg = (DevExpress.XtraEditors.PictureEdit)sender;
            string fileName = Convert.ToString(ucImg.Tag);
            string filePathOfBigPicture = imageFolderPath +"\\"+ fileName;
            string path = Convert.ToString(filePathOfBigPicture);

            //如果已经有这个tabPage
            XtraTabPage ifTabPage = ComponentOperator.IfHasTabPage(".jpg", xTabControl);
            if (ifTabPage != null)
            {
                this.xTabControl.SelectedTabPage = ifTabPage;
                ifTabPage.Text = fileName;
                Control control = ifTabPage.Controls[0];
                if(control is ucImageViewer)
                {
                    ucImageViewer ucViewer = control as ucImageViewer;
                    ucViewer.ImagePath = path;
                }
                return;
            }
            //如果不包含该TabPage，则新建
            ucImageViewer ucImage = new ucImageViewer();
            ucImage.ImagePath = path;

            XtraTabPage xtp = new XtraTabPage();
            xtp.Text = fileName;
            xtp.Controls.Add(ucImage);
            ucImage.Dock = DockStyle.Fill;
            xTabControl.TabPages.Add(xtp);
            xTabControl.SelectedTabPage = xtp;
        }
    }
}
