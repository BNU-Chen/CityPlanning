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

using DevExpress.XtraEditors.Repository;

namespace CityPlanning.Modules
{
    public partial class ucImageViewer : UserControl
    {
        private string imagePath = "";

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                if (File.Exists(imagePath))
                {

                    this.pictureEdit1.Image = new Bitmap(imagePath);
                    this.pictureEdit1.Properties.ZoomPercent = 50;
                    this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                    this.Refresh();
                }
            }
        }
        public ucImageViewer()
        {
            InitializeComponent();
            
            pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            pictureEdit1.Properties.ShowScrollBars = true;
            pictureEdit1.Properties.AllowScrollViaMouseDrag = true;
            this.pictureEdit1.MouseWheel += pictureEdit1_MouseWheel;
        }

        void pictureEdit1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            //throw new NotImplementedException();
        }

        private void tsmi_Scale_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string itemName = e.ClickedItem.Name;
            int scalePercent = 50;
            switch(itemName)
            {
                case "tsmi_20":
                    scalePercent = 20;
                    break;
                case "tsmi_40":
                    scalePercent = 40;
                    break;
                case "tsmi_60":
                    scalePercent = 60;
                    break;
                case "tsmi_80":
                    scalePercent = 80;
                    break;
                case "tsmi_100":
                    scalePercent = 100;
                    break;
                case "tsmi_125":
                    scalePercent = 125;
                    break;
                case "tsmi_150":
                    scalePercent = 150;
                    break;
                case "tsmi_200":
                    scalePercent = 200;
                    break;
                default:
                    scalePercent = 50;
                    break;
            }
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            this.pictureEdit1.Properties.ZoomPercent = scalePercent;
        }

        private void tsmi_FullScale_Click(object sender, EventArgs e)
        {
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
        }

    }
}
