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
    public partial class ucDocumentSearchClip : UserControl
    {
        private string clipContext = "";
        private string key = "";

        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        public string ClipContext
        {
            get
            {
                return clipContext;
            }
            set
            {
                this.richTextBox1.Rtf = ConvertString2RTF(value, key);
            }
        }

        public ucDocumentSearchClip()
        {
            InitializeComponent();
        }

        private string ConvertString2RTF(string str,string key)
        {
            string rtf = "";
            try
            {
                int index = str.IndexOf(key, 0);
                if (index > 0)
                {
                    
                    string head = str.Substring(0, index);
                    string foot = str.Substring(index + key.Length, str.Length - index - key.Length);
                    rtf = @"{\rtf1\utf8 " + head + @"{\b " + key + @"} " + foot + @"}";
                    //rtf =  string.Format(@"{{\rtf1\ansi {0} \b {1} \b0 {2} }}",head,key,foot);
                }
                else
                {
                    rtf = @"{\rtf1\ansi " + str + "}";
                }
            }
            catch
            {
            }
            return rtf;
        }
    }
}
