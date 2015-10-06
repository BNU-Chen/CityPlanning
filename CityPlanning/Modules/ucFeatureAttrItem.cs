using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityPlanning.Modules
{
    public partial class ucFeatureAttrItem : UserControl
    {
        public ucFeatureAttrItem()
        {
            InitializeComponent();
        }

        //设置标题
        public string AttrTitle
        {
            get { return this.lbl_AttrTitle.Text; }
            set { this.lbl_AttrTitle.Text = value; }
        }

        //设置内容
        public string AttrContent
        {
            get { return this.lbl_AttrContent.Text; }
            set { this.lbl_AttrContent.Text = value; }
        }

        //设置控件宽度
        public int ControlWidth
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = ControlWidth;
            }
        }

        private void SetControlWidth(string text1, string text2)
        {
            //int len1 = text1.Length;
            //int len2 = text2.Length;
            //int maxLen = len1 > len2 ? len1 : len2;
            //if()
        }
    }
}
