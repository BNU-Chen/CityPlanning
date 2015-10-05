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

namespace CityPlanning.Modules
{
    public partial class ucImageThumb : UserControl
    {
        private string imagePath = "";

        public string ImagePath
        {
            get { return imagePath; }
            set 
            { 
                imagePath = value;
                if(!File.Exists(imagePath))
                {
                    this.lbl_title.Text = "图片不存在";
                    return;
                }
                string fileName = Path.GetFileName(imagePath);
                this.lbl_title.Text = SetTitle(fileName);
                this.pictureEdit1.Image = new Bitmap(imagePath);
                this.pictureEdit1.Tag = fileName;
                this.pictureEdit1.ToolTip = fileName;
                
            }
        }
        public string ImageTitle
        {
            get
            {
                return this.lbl_title.Text;
            }
        }
        public DevExpress.XtraEditors.PictureEdit PicBox
        {
            get
            {
                return this.pictureEdit1;
            }
        }
        public ucImageThumb()
        {
            InitializeComponent();
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
        }

        private string SetTitle(string title)
        {
            string setTitle = "图片未命名";
            int len = title.Length;
            if (len >16)
            {
                string ahead = title.Substring(0, 8);
                string behind = title.Substring(len - 8, 4);
                setTitle = ahead + "..." + behind;
            }else if (len >0 && len <= 16)
            {
                setTitle = title.Substring(0,len-4);
            }
            return setTitle;
        }
    }
}
