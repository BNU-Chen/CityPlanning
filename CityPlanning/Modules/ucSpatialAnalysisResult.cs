using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace CityPlanning.Modules
{
    public partial class ucSpatialAnalysisResult : UserControl
    {
        public AxMapControl AxMapControl1
        {
            get { return this.axMapControl1; }
        }

        public AxMapControl AxMapControl2
        {
            get { return this.axMapControl2; }
        }

        public ucSpatialAnalysisResult(string originalFilePath, string resultFilePath)
        {
            InitializeComponent();
            if (this.axMapControl1.CheckMxFile(originalFilePath))
                this.axMapControl1.LoadMxFile(originalFilePath);
            if (this.axMapControl2.CheckMxFile(resultFilePath))
                this.axMapControl2.LoadMxFile(resultFilePath);
            this.axMapControl1.Refresh();
            this.axMapControl2.Refresh();

            this.axMapControl1.OnMouseDown += axMapControl1_OnMouseDown;
            this.axMapControl1.OnMouseMove += axMapControl1_OnMouseMove;
            this.axMapControl1.OnMouseUp += axMapControl1_OnMouseUp;

            this.axMapControl2.OnMouseUp += axMapControl2_OnMouseUp;
            this.axMapControl2.OnMouseMove += axMapControl2_OnMouseMove;
            this.axMapControl2.OnMouseDown += axMapControl2_OnMouseDown;
        }

        #region //鼠标中键移动地图优化
        void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                axMapControl2.ActiveView.ScreenDisplay.PanStart(axMapControl2.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));
                axMapControl2.MousePointer = esriControlsMousePointer.esriPointerPan;
            }
        }

        void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 4 && axMapControl2.ActiveView != null)
            {
                axMapControl2.ActiveView.ScreenDisplay.PanMoveTo(axMapControl2.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));
            }
        }

        void axMapControl2_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 4 && axMapControl2.ActiveView != null)   //中键
            {
                axMapControl2.MousePointer = esriControlsMousePointer.esriPointerArrow;
                axMapControl2.ActiveView.ScreenDisplay.PanStop();
                axMapControl2.ActiveView.Refresh();
            }
        }

        void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 4 && axMapControl1.ActiveView != null)   //中键
            {
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerArrow;
                axMapControl1.ActiveView.ScreenDisplay.PanStop();
                axMapControl1.ActiveView.Refresh();
            }
        }

        void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 4 && axMapControl1.ActiveView != null)
            {
                axMapControl1.ActiveView.ScreenDisplay.PanMoveTo(axMapControl1.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));
            }
        }

        void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {            
            if (e.button == 4)
            {
                axMapControl1.ActiveView.ScreenDisplay.PanStart(axMapControl1.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
            }
        }
        #endregion

        //控件大小变更事件
        private void ucSpatialAnalysisResult_SizeChanged(object sender, EventArgs e)
        {
            this.axMapControl1.Location = new Point(3, 3);
            this.axMapControl2.Location = new Point(this.Size.Width / 2 + 3, 3);
            this.axMapControl1.Size = new Size((this.Size.Width - 9) / 2, this.Size.Height - 6);
            this.axMapControl2.Size = new Size((this.Size.Width - 9) / 2, this.Size.Height - 6);
            this.axMapControl1.Extent = this.axMapControl1.FullExtent;
            this.axMapControl2.Extent = this.axMapControl1.Extent;
            this.axMapControl1.Refresh();
            this.axMapControl2.Refresh();
        }

        //显示范围同步变更
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            if (this.axMapControl1.Focused && !this.axMapControl2.Focused)
            {
                this.axMapControl2.Extent = this.axMapControl1.Extent;
                this.axMapControl2.Refresh();
            }
        }
        private void axMapControl2_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            if (this.axMapControl2.Focused && !this.axMapControl1.Focused)
            {
                this.axMapControl1.Extent = this.axMapControl2.Extent;
                this.axMapControl1.Refresh();
            }
        }
    }
}
