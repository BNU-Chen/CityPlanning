using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
namespace CityPlanning.Modules
{
    public partial class ucTOCControl : UserControl
    {
        public AxTOCControl TOCControl
        {
            get
            {
                return this.axTOCControl1;
            }
        }
        public ucTOCControl()
        {
            InitializeComponent();
        }
    }
}
