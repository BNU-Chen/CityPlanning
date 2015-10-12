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
    public delegate void delegateClickEvent(string evtName);
    public partial class ucFeatureAttrItem : UserControl
    {
        public delegateClickEvent ClickEvent;
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

        private void lbl_AttrTitle_Click(object sender, EventArgs e)
        {
            ExeSearchDoc();
        }

        private void lbl_AttrContent_Click(object sender, EventArgs e)
        {
            ExeSearchDoc();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ExeSearchDoc();
        }

        private void ucFeatureAttrItem_Click(object sender, EventArgs e)
        {
            ExeSearchDoc();
        }

        private void ExeSearchDoc()
        {
            ClickEvent(this.lbl_AttrTitle.Text.Trim());
        }
    }
}
