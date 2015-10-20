using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Customization;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace CityPlanning
{
    public partial class frmMapSelection : Form
    {
        private string mainFloderPath;
        private Size cardSize;

        public frmMapSelection()
        {
            InitializeComponent();
        }

        private void frmMapSelection_Load(object sender, EventArgs e)
        {
            cardSize = new Size(this.Size.Width / 2, this.Size.Height / 2);
            mainFloderPath = @"F:\项目资料\项目-沈阳经济开发区\项目 - 沈阳经济区\图集\经济区图册正面";
            SetGridControlView(mainFloderPath, cardSize);
        }

        private void SetGridControlView(string imageFloderPath, Size cardSize)
        {
            string[] filePathes = Directory.GetFiles(imageFloderPath, "*.jpg");
            DataTable dt = CreatDatatableOfFiles(filePathes, new Size(400, 300));
            
            this.gridControl1.DataSource = dt;
            this.gridControl1.ViewCollection.Clear();
            LayoutView lView = new LayoutView(this.gridControl1);
            this.gridControl1.MainView = lView;
            ResetLayoutView(lView);
            lView.CardMinSize = cardSize;
            LayoutViewColumn colFileName = lView.Columns.AddField("文件名");
            LayoutViewColumn colFilePath = lView.Columns.AddField("文件路径");
            LayoutViewColumn colPhoto = lView.Columns.AddField("图片文件");
            LayoutViewField fieldFileName = colFileName.LayoutViewField;
            LayoutViewField fieldFilePath = colFilePath.LayoutViewField;
            LayoutViewField fieldPhoto = colPhoto.LayoutViewField;
            colFileName.Visible = true;
            fieldPhoto.Move(new LayoutItemDragController(fieldPhoto, fieldFileName, InsertLocation.After, LayoutType.Vertical));
            //fieldFilePath.Move(new LayoutItemDragController(fieldFilePath, fieldPhoto, InsertLocation.After, LayoutType.Vertical));

            RepositoryItemPictureEdit riPictureEdit = this.gridControl1.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            riPictureEdit.SizeMode = PictureSizeMode.Stretch;
            colPhoto.ColumnEdit = riPictureEdit;

            fieldFileName.TextVisible = false;
            fieldFilePath.TextVisible = false;
            fieldPhoto.Text = "  ";

            colFileName.OptionsColumn.ReadOnly = true;
            colFilePath.OptionsColumn.ReadOnly = true;
            colPhoto.OptionsColumn.ReadOnly = true;
            colFileName.Visible = false;
            colFilePath.Visible = false;
            lView.CardCaptionFormat = "{2}    第{0}幅，共{1}幅";
        }

        private void ResetLayoutView(LayoutView layoutView)
        {
            try
            {
                layoutView.OptionsCustomization.AllowFilter = false;
                layoutView.OptionsCustomization.AllowSort = false;
                LayoutViewOptionsView layoutViewOptionsView = (LayoutViewOptionsView)layoutView.OptionsView;
                layoutViewOptionsView.ViewMode = LayoutViewMode.Carousel;
                layoutViewOptionsView.ShowHeaderPanel = false;
                layoutViewOptionsView.ShowCardExpandButton = false;
                layoutViewOptionsView.ShowCardExpandButton = false;
                layoutView.Columns.Clear();
            }
            catch { }
        }

        private DataTable CreatDatatableOfFiles( string[] filePathes,  Size  imageSize)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("文件名", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("文件路径", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("图片文件", typeof(Image)));
            
            foreach (string filePath in filePathes)
            {
                DataRow newRow;
                newRow = dt.NewRow();
                newRow["文件名"] = Path.GetFileNameWithoutExtension(filePath);
                newRow["文件路径"] = filePath;
                Image resImage = Image.FromFile(filePath);
                Image resImage1 = resImage.GetThumbnailImage(imageSize.Width, imageSize.Height, null, IntPtr.Zero);
                newRow["图片文件"] = resImage1;
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        private void btnStatusMap_Click(object sender, EventArgs e)
        {
            SetGridControlView(mainFloderPath + "\\现状图", cardSize);
        }

        private void btnPlanMap_Click(object sender, EventArgs e)
        {
            SetGridControlView(mainFloderPath + "\\规划图", cardSize);
        }

        private void btnAnalysisMap_Click(object sender, EventArgs e)
        {
            SetGridControlView(mainFloderPath + "\\分析图", cardSize);
        }
    }
}
