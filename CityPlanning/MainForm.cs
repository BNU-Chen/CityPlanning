﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;

using System.IO;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using DevExpress.XtraRichEdit;
using DevExpress.XtraCharts;
//using DevExpress.Docs;          //Worksheet专用
using DevExpress.Utils;
//叠置专用
using System.IO;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using System.Threading;
using System.Data.OleDb;
using SharpMap;
using SharpMap.Data.Providers;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.DataSourcesRaster;

//本项目解决方案
using ConnectionCenter;
using GISManager;
using DocumentManager;
using StatisticChart;

namespace CityPlanning
{
    public partial class MainForm : RibbonForm
    {
        #region //变量声明
        private AxMapControl curAxMapControl = null;
        private ImageCollection imageCollectionIcons = null;
        public Modules.ucChartForm curChartForm = null;
        private SpreadsheetControl curSpreadsheetControl = null;
        private RichEditControl curRichEditControl = null;
        
        //地图相关
        private bool isIdentifyMap = false;  //是否开始地图查询
        private Forms.frmMapFeatureAttr pFrmMapFeatureAttr = null;  //地图查询属性框
                
        //自定义类声明
        private int iconCount = 0;

        //模块定义
        public Modules.ucNavigationRDB ucNaviRDB = new Modules.ucNavigationRDB();
        public Modules.ucNavigationFiles ucNaviFiles = new Modules.ucNavigationFiles();
        public Modules.ucDocumentSearch ucDocSearch = new Modules.ucDocumentSearch();
        public Modules.ucDocumentInternalSearch ucDocIntSearch = new Modules.ucDocumentInternalSearch(); //郭海强 添加关键词搜索控件0913
        public Modules.ucNavigationImage ucNavImage = new Modules.ucNavigationImage();  //规划效果图浏览
        public Modules.ucTOCControl ucTocCtrl = new Modules.ucTOCControl();     //地图关联图层面板


        //INI文件相关
        private string curMapKeyName = "";      //当前地图关键词的key

        //叠置分析相关
        private string final = string.Empty;
        private string _Environment = string.Empty;
        private string strInputFeature = string.Empty;
        private string strOverLayFeature = string.Empty;
        private bool DrawPolygon = false;
        private bool startIntersect = false;
        private string tempPath = string.Empty;
        
        //专题分析相关
        public static ResultShowForm ResFrm;
        private bool AlreadyAddMap = false;
        private XtraTabPage curXtraTabPage = null;

        #endregion

        #region //初始化函数
        public MainForm()
        {
            InitializeComponent();
            InitComponent();
            //InitSkinGallery();
            //设置叠置分析环境
            _Environment = Application.StartupPath + @"\TempFiles";
            if(!Directory.Exists(_Environment))
            {
                System.IO.Directory.CreateDirectory(_Environment);
            }
            tempPath = Environment.SpecialFolder.MyDocuments.ToString()+@"\CityTemp";
            if (!Directory.Exists(tempPath))
            {
                System.IO.Directory.CreateDirectory(tempPath);
            }

        }
        //窗体初始化函数 
        private void MainForm_Load(object sender, EventArgs e)
        {
            //启动界面
            frmStartConnectionConfig fscc = new frmStartConnectionConfig(this);
            fscc.ShowDialog();
            this.setMultiDocumentsPath();
        }

        //初始化控件
        private void InitComponent()
        {
            //获取图标
            imageCollectionIcons = ComponentOperator.GetImageCollection();
            this.ucNaviFiles.TreeList.StateImageList = imageCollectionIcons;
            this.ucNaviRDB.TreeList.StateImageList = imageCollectionIcons;
            this.xtraTabControl_Main.Images = imageCollectionIcons;

            ucNaviFiles.Dock = DockStyle.Fill;
            ucNaviRDB.Dock = DockStyle.Fill;
            ucDocSearch.Dock = DockStyle.Fill;
            ucDocIntSearch.Dock = DockStyle.Fill;//郭海强 添加关键词搜索控件0913

            //导航栏双击事件
            this.ucNaviRDB.TreeList.DoubleClick += ucNaviRDB_TreeList_DoubleClick;
            this.ucNaviFiles.TreeList.DoubleClick += ucNaviFiles_TreeList_DoubleClick;
            //导航栏图标
            this.ucNaviRDB.TreeList.GetStateImage +=ucNaviRDB_TreeList_GetStateImage;
            this.ucNaviFiles.TreeList.GetStateImage += ucNaviFiles_TreeList_GetStateImage;
        }
        void InitSkinGallery()
        {
            //SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        #endregion
        
        #region //主页Ribbon按钮事件
        //连接配置
        private void bConnectConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //启动界面
            frmStartConnectionConfig fscc = new frmStartConnectionConfig(null);
            fscc.ShowDialog();
            this.setMultiDocumentsPath();
        }
        //文件配置
        private void bDocConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmSysConfig fSysConfig = new Forms.frmSysConfig();
            fSysConfig.ShowDialog();
            this.setMultiDocumentsPath();
        }

        //用户管理
        private void bUserManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                #region //用户管理
                string tabName = "用户管理";
                //如果已经有这个tabPage
                XtraTabPage ifTabPage = ComponentOperator.IfHasTabPage(tabName, this.xtraTabControl_Main);
                if (ifTabPage != null)
                {
                    this.xtraTabControl_Main.SelectedTabPage = ifTabPage;
                    return;
                }
                //如果不包含该TabPage，则新建
                DataTable dt = SQLServerConnection.GetUserList();
                if (dt == null)
                {
                    MessageBox.Show("获取数据失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //表格控件
                TreeList userTree = new TreeList();
                userTree.KeyFieldName ="id";
                userTree.ParentFieldName = "pid";
                userTree.BeginInit();
                userTree.DataSource = dt;
                userTree.EndInit();

                //icon
                int imgIndex = this.imageCollectionIcons.Images.Keys.IndexOf("user");
                //TabPage
                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = tabName;
                xtp.Controls.Add(userTree);
                if (imgIndex >= 0)
                {
                    Image tableIcon = this.imageCollectionIcons.Images[imgIndex];
                    xtp.Image = tableIcon;
                }
                userTree.Dock = DockStyle.Fill;
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;

                userTree.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                #endregion
            }
            catch
            {
            }
        }
        
        //全部文档
        private void bGalleryDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenAllPlanDocs();
        }
        //规划文本
        private void bGalleryPlanDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenPlanDoc();
        }
        //规划说明
        private void bGalleryPlanDesc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenPlanDesc();
        }
        //专题报告
        private void bGalleryThematicDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenThematicDocs();
        }
        //规划地图
        private void bGalleryGeodatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenPlanMaps();
        }

        //规划图集
        private void bGalleryImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenPlanImgs();
        }
        //关系数据库
        private void bGalleryRelationalDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucNaviRDB);

            DataTable dt = SQLServerConnection.GetDatabaseSchema();
            if (dt == null)
            {
                MessageBox.Show("没有获取到数据。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }
            this.ucNaviRDB.TreeList.KeyFieldName = "id";     //主要显示内容
            this.ucNaviRDB.TreeList.ParentFieldName = "TABLE_CATALOG";     //目录
            //this.ucNaviRDB.TreeList.ImageIndexFieldName = "ext";
            this.ucNaviRDB.TreeList.DataSource = dt;    //数据库
            DevExpress.XtraTreeList.Columns.TreeListColumnCollection col = this.ucNaviRDB.TreeList.Columns;
            this.ucNaviRDB.TreeList.Columns["TABLE_NAME"].SortOrder = SortOrder.Ascending;      //排序
            //显示内容
            for (int i = 0; i < ucNaviRDB.TreeList.Columns.Count; i++)
            {
                if (ucNaviRDB.TreeList.Columns[i].FieldName != "TABLE_NAME")
                {
                    ucNaviRDB.TreeList.Columns[i].Visible = false;
                }
            }
        }

        //三维地图
        private void bGallery3DMap_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        //关于我们
        private void bAboutUs_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmAbout fAbout = new Forms.frmAbout();
            fAbout.ShowDialog();
        }
        #endregion

        #region //左侧导航栏事件
        //关系数据库导航栏双击事件
        private void ucNaviRDB_TreeList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeList tree = sender as TreeList;
                TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
                if (hi.Node != null)
                {                    
                    string nodeName = (string)hi.Node["TABLE_NAME"];
                    //如果已经有这个tabPage
                    XtraTabPage ifTabPage = ComponentOperator.IfHasTabPage(nodeName, this.xtraTabControl_Main);
                    if (ifTabPage != null)
                    {
                        this.xtraTabControl_Main.SelectedTabPage = ifTabPage;
                        return;
                    }
                    //如果不包含该TabPage，则新建
                    DataTable dt = SQLServerConnection.GetDataByTableName(nodeName);
                    if(dt == null)
                    {
                        MessageBox.Show("获取数据失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //表格控件
                    SpreadsheetControl ssc = new SpreadsheetControl();                    
                    IWorkbook workbook = ssc.Document;
                    workbook.BeginUpdate();
                    Worksheet worksheet = workbook.Worksheets[0];
                    worksheet.Name = nodeName;
                    worksheet.Import(dt,true, 0, 0);        //import方法需要添加DevExpress.Docs命名空间
                    workbook.EndUpdate();
                    
                    //icon
                    int imgIndex = this.imageCollectionIcons.Images.Keys.IndexOf("table");
                    
                    //TabPage
                    XtraTabPage xtp = new XtraTabPage();                    
                    xtp.Text = nodeName;
                    xtp.Controls.Add(ssc);
                    if (imgIndex >= 0)
                    {
                        Image tableIcon = this.imageCollectionIcons.Images[imgIndex];
                        xtp.Image = tableIcon;
                    }
                    ssc.Dock = DockStyle.Fill;
                    this.xtraTabControl_Main.TabPages.Add(xtp);
                    this.xtraTabControl_Main.SelectedTabPage = xtp;
                    
                    ssc.Refresh();
                    xtp.Refresh();
                    this.xtraTabControl_Main.Refresh();
                    this.Refresh();
                }
            }
            catch
            {
            }
        }
        
        //文件数据导航栏双击事件
        private void ucNaviFiles_TreeList_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node == null)
            {
                return;
            }
            string nodeName = (string)hi.Node["name"];
            string extension = (string)hi.Node["ext"];
            //icon
            int iconIndex = this.imageCollectionIcons.Images.Keys.IndexOf(extension);
            Control openFileTool = null;
            try
            {
                //如果已经有这个tabPage
                XtraTabPage ifTabPage = ComponentOperator.IfHasTabPage(nodeName, this.xtraTabControl_Main);
                if (ifTabPage != null)
                {
                    this.xtraTabControl_Main.SelectedTabPage = ifTabPage;
                    return;
                }
                //如果是文件夹，则返回
                string type = (string)hi.Node["type"];
                if (type == "Folder")
                {
                    return;
                }
                //如果文件不存在
                string path = (string)hi.Node["path"];
                if (!File.Exists(path))
                {
                    MessageBox.Show("文件已丢失，请刷新文件目录后再尝试打开。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //如果不包含该TabPage，则新建                
                string fileType = ComponentOperator.GetFileTypeByExtension(extension);
                switch (fileType)
                {
                    case "":
                        if (MessageBox.Show("本系统暂不支持该格式[" + extension + "]的文件，是否尝试使用系统默认程序打开？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(path);
                        }
                        return;
                    case "RichTextEdit":
                        RichEditControl rec = new RichEditControl();
                        rec.LoadDocument(path);
                        openFileTool = rec;
                        break;
                    case "SpreadSheet"://表格控件
                        SpreadsheetControl ssc = new SpreadsheetControl();
                        ssc.LoadDocument(path);
                        openFileTool = ssc;
                        break;
                    case "MapControl":
                        AxMapControl mapControl = new AxMapControl();
                        mapControl.BeginInit();     //必须有begin和end
                        mapControl.Location = new System.Drawing.Point(0, 0);
                        mapControl.Name = "mapControl1";
                        mapControl.Dock = DockStyle.Fill;
                        //MapControl不支持先声明，后设置，故而直接设置
                        XtraTabPage xtp = new XtraTabPage();
                        xtp.Text = nodeName;
                        xtp.Controls.Add(mapControl);
                        if (iconIndex >= 0)
                        {
                            Image tableIcon = this.imageCollectionIcons.Images[iconIndex];
                            xtp.Image = tableIcon;
                        }
                        mapControl.Dock = DockStyle.Fill;
                        this.xtraTabControl_Main.TabPages.Add(xtp);
                        this.xtraTabControl_Main.SelectedTabPage = xtp;
                        mapControl.EndInit();       //必须有begin和end

                        mapControl.Refresh();
                        xtp.Refresh();
                        this.xtraTabControl_Main.Refresh();
                        this.Refresh();

                        mapControl.LoadMxFile(path);

                        //获取地图关键词
                        curMapKeyName = nodeName;
                        SetMapKeywords();
                        break;
                    case "Image":
                        Modules.ucImageViewer ucImage = new Modules.ucImageViewer();
                        ucImage.ImagePath = path;
                        XtraTabPage xtpImage = new XtraTabPage();
                        xtpImage.Text = nodeName;
                        xtpImage.Controls.Add(ucImage);
                        ucImage.Dock = DockStyle.Fill;
                        this.xtraTabControl_Main.TabPages.Add(xtpImage);
                        this.xtraTabControl_Main.SelectedTabPage = xtpImage;
                        this.Refresh();                        
                        break;
                    case "PdfViewer":
                        DevExpress.XtraPdfViewer.PdfViewer pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
                        pdfViewer.LoadDocument(path);
                        XtraTabPage xtpPdf = new XtraTabPage();
                        xtpPdf.Text = nodeName;
                        xtpPdf.Controls.Add(pdfViewer);
                        pdfViewer.Dock = DockStyle.Fill;
                        this.xtraTabControl_Main.TabPages.Add(xtpPdf);
                        this.xtraTabControl_Main.SelectedTabPage = xtpPdf;
                        this.Refresh();
                        break;
                    default:
                        return;
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                if (openFileTool != null )
                {
                    //TabPage
                    XtraTabPage xtp = new XtraTabPage();
                    xtp.Text = nodeName;
                    if (iconIndex >= 0)
                    {
                        Image tableIcon = this.imageCollectionIcons.Images[iconIndex];
                        xtp.Image = tableIcon;
                    }
                    xtp.Controls.Add(openFileTool);
                    openFileTool.Dock = DockStyle.Fill;
                    this.xtraTabControl_Main.TabPages.Add(xtp);
                    this.xtraTabControl_Main.SelectedTabPage = xtp;

                    openFileTool.Refresh();
                    xtp.Refresh();
                    this.xtraTabControl_Main.Refresh();
                    this.Refresh();
                }
            }
        }
        //关系数据库导航栏图标
        private void ucNaviRDB_TreeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            int imgIndex = this.imageCollectionIcons.Images.Keys.IndexOf("table");
            if (imgIndex >= 0)
            {
                e.NodeImageIndex = imgIndex;
            }

        }
        //文件数据库导航栏图标
        private void ucNaviFiles_TreeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            string extension = (string)e.Node["ext"];
            if(extension == "folder")
            {
                extension = "folderclose";
            }
            int imgIndex = this.imageCollectionIcons.Images.Keys.IndexOf(extension);
            if (imgIndex >= 0)
            {
                e.NodeImageIndex = imgIndex;
            }
            else
            {
                imgIndex = this.imageCollectionIcons.Images.Keys.IndexOf("generic");
                e.NodeImageIndex = imgIndex;
            }

        }
        #endregion

        #region //主显示区Tab事件
        //TabPage关闭
        private void xtraTabControl_Main_CloseButtonClick(object sender, EventArgs e)
        {            
            try
            {
                if (this.xtraTabControl_Main.SelectedTabPage.Text == this.xtraTabPage_Home.Text)
                {
                    return; //如果是关闭主页，则返回
                }
                XtraTabPage tabPage = this.xtraTabControl_Main.SelectedTabPage;
                //int tabIndex = this.xtraTabControl_Main.SelectedTabPageIndex;
                this.xtraTabControl_Main.SelectedTabPageIndex -= 1;
                this.xtraTabControl_Main.TabPages.Remove(tabPage);
                tabPage.Dispose();
                GC.Collect();
            }
            catch
            {
            }
        }
        //中键关闭tabPage
        private void xtraTabControl_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.IsMiddle())
            {
                XtraTabControl xtc = sender as XtraTabControl;
                System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);
                DevExpress.XtraTab.ViewInfo.XtraTabHitInfo xthi = xtc.CalcHitInfo(pos);

                if (xthi.Page.Text == this.xtraTabPage_Home.Text)
                {
                    return; //如果是关闭主页，则返回
                }
                this.xtraTabControl_Main.TabPages.Remove(xthi.Page);
                xthi.Page.Dispose();
                GC.Collect();
            }
        }
        //TabPage切换事件
        private void xtraTabControl_Main_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        { 
            //根据TabPage，选择性显示
            XtraTabPage tabPage = e.Page;
            foreach (Control control in tabPage.Controls)
            {
                if (control is SpreadsheetControl)
                {
                    SpreadsheetControl ssc = (SpreadsheetControl)control;
                    this.spreadsheetBarController1.SpreadsheetControl = ssc;
                    this.ribbonPageCategory_xls.Visible = true;
                    this.ribbonPageCategory_doc.Visible = false;
                    this.ribbonPageCategory_map.Visible = false;
                    this.ribbonControl.SelectedPage = this.ribbonPageCategory_xls.Pages[0];
                    break;
                }
                else if (control is RichEditControl)
                {
                    RichEditControl rec = (RichEditControl)control;
                    this.richEditBarController1.RichEditControl = rec;
                    this.ribbonPageCategory_xls.Visible = false;
                    this.ribbonPageCategory_doc.Visible = true;
                    this.ribbonPageCategory_map.Visible = false;
                    this.ribbonControl.SelectedPage = this.ribbonPageCategory_doc.Pages[0];
                    break;
                }
                else if (control is AxMapControl)
                {
                    curAxMapControl = (AxMapControl)control;
                    this.ribbonPageCategory_xls.Visible = false;
                    this.ribbonPageCategory_doc.Visible = false;
                    this.ribbonPageCategory_map.Visible = true;
                    this.ribbonControl.SelectedPage = this.ribbonPageCategory_map.Pages[0];
                    curAxMapControl.OnMouseUp += curAxMapControl_OnMouseUp;
                    curAxMapControl.OnMouseDown += curAxMapControl_OnMouseDown;
                    curAxMapControl.OnMouseMove += curAxMapControl_OnMouseMove;

                    //TOCControl
                    ucTocCtrl.TOCControl.SetBuddyControl(curAxMapControl);
                    ucTocCtrl.TOCControl.Refresh();

                    //地图关键词
                    curMapKeyName = tabPage.Text;
                    SetMapKeywords();
                    break;
                }
                else
                {
                    //先隐藏所有ribbonPageCategory
                    this.ribbonControl.SelectedPage = this.homeRibbonPage;
                    this.ribbonPageCategory_xls.Visible = false;
                    this.ribbonPageCategory_doc.Visible = false;
                    this.ribbonPageCategory_map.Visible = false;
                }
            }
        }
        

        #region //ChartButton生成统计图表
        //柱状图
        private void BarChartButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control control = this.xtraTabControl_Main.SelectedTabPage.Controls[0];
            if (control is SpreadsheetControl)
            {
                SpreadsheetControl ssc = (SpreadsheetControl)control;
                Worksheet worksheet = ssc.Document.Worksheets.ActiveWorksheet;
                DataTable dt = StatisticChart.DataOperation.CreateTablefromWorkSheet(worksheet);
                
                if (dt != null)
                {
                    Modules.ucChartForm ucc = new Modules.ucChartForm(this);
                    ucc.Icon = Icon.FromHandle(((Bitmap)BarChartButton.Glyph).GetHicon());
                    ucc.DataSource = dt.Copy();
                    ucc.Range = worksheet.Selection;
                    ucc.ViewType = ViewType.Bar;
                    StatisticChart.ShowOperation.CreatChart(ucc.ChartControl, dt, ucc.ViewType);
                    ucc.Activated += curChartForm_Activated;
                    ucc.Show();
                    ResetFieldComboBox(curChartForm.VariableField, curChartForm.ValueField);
                }
            }
        }
        //折线图
        private void LineChartButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control control = this.xtraTabControl_Main.SelectedTabPage.Controls[0];
            if (control is SpreadsheetControl)
            {
                SpreadsheetControl ssc = (SpreadsheetControl)control;
                Worksheet worksheet = ssc.Document.Worksheets.ActiveWorksheet;
                DataTable dt = StatisticChart.DataOperation.CreateTablefromWorkSheet(worksheet);

                if (dt != null)
                {
                    Modules.ucChartForm ucc = new Modules.ucChartForm(this);
                    ucc.Icon = Icon.FromHandle(((Bitmap)LineChartButton.Glyph).GetHicon());
                    ucc.DataSource = dt.Copy();
                    ucc.Range = worksheet.Selection;
                    ucc.ViewType = ViewType.Line;
                    StatisticChart.ShowOperation.CreatChart(ucc.ChartControl, dt, ucc.ViewType);
                    ucc.Activated += curChartForm_Activated;
                    ucc.Show();
                    ResetFieldComboBox(curChartForm.VariableField, curChartForm.ValueField);
                }
            }
        }
        //散点图
        private void PointChartButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control control = this.xtraTabControl_Main.SelectedTabPage.Controls[0];
            if (control is SpreadsheetControl)
            {
                SpreadsheetControl ssc = (SpreadsheetControl)control;
                Worksheet worksheet = ssc.Document.Worksheets.ActiveWorksheet;
                DataTable dt = StatisticChart.DataOperation.CreateTablefromWorkSheet(worksheet);
                
                if (dt != null)
                {
                    Modules.ucChartForm ucc = new Modules.ucChartForm(this);
                    ucc.Icon = Icon.FromHandle(((Bitmap)PointChartButton.Glyph).GetHicon());
                    ucc.DataSource = dt.Copy();
                    ucc.Range = worksheet.Selection;
                    ucc.ViewType = ViewType.Point;
                    StatisticChart.ShowOperation.CreatChart(ucc.ChartControl, dt, ucc.ViewType);
                    ucc.Activated += curChartForm_Activated;
                    ucc.Show();
                    ResetFieldComboBox(curChartForm.VariableField, curChartForm.ValueField);
                }
            }
        }
        //饼状图
        private void PieChartButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control control = this.xtraTabControl_Main.SelectedTabPage.Controls[0];
            if (control is SpreadsheetControl)
            {
                SpreadsheetControl ssc = (SpreadsheetControl)control;
                Worksheet worksheet = ssc.Document.Worksheets.ActiveWorksheet;
                DataTable dt = StatisticChart.DataOperation.CreateTablefromWorkSheet(worksheet);

                if (dt != null)
                {
                    Modules.ucChartForm ucc = new Modules.ucChartForm(this);
                    ucc.Icon = Icon.FromHandle(((Bitmap)PieChartButton.Glyph).GetHicon());
                    ucc.DataSource = dt.Copy();
                    ucc.Range = worksheet.Selection;
                    ucc.ViewType = ViewType.Pie;
                    StatisticChart.ShowOperation.CreatPieChart(ucc.ChartControl, dt);
                    ucc.Activated += curChartForm_Activated;
                    ucc.Show();
                    ResetFieldComboBox(curChartForm.VariableField, curChartForm.ValueField);
                }
            }
        }
        //切换图表窗口，对应显示worksheet原数据
        private void curChartForm_Activated(object sender, EventArgs e)
        {
            XtraTabPage ifTabPage = ComponentOperator.IfHasTabPage(curChartForm.DataSource.TableName, this.xtraTabControl_Main);
            if (ifTabPage != null && curChartForm != null)
            {
                this.xtraTabControl_Main.SelectedTabPage = ifTabPage;
                Control control = ifTabPage.Controls[0];
                if (control is SpreadsheetControl)
                {
                    curSpreadsheetControl = (SpreadsheetControl)control;
                    curSpreadsheetControl.Selection = curChartForm.Range;
                    curSpreadsheetControl.Refresh();
                }
                ResetFieldComboBox(curChartForm.VariableField, curChartForm.ValueField);
            }
        }
        //重设字段选择控件内容
        private void ResetFieldComboBox(List<string> vars, List<string> vals)
        {
            AxisXCombobox.EditValue = null;
            AxisYCombobox.EditValue = null;
            repositoryItemComboBox1.Items.Clear();
            repositoryItemCheckedComboBoxEdit1.Items.Clear();
            foreach (string var in vars) repositoryItemComboBox1.Items.Add(var);
            foreach (string val in vals) repositoryItemCheckedComboBoxEdit1.Items.Add(val);
        }
        //重选变量字段
        private void AxisXCombobox_EditValueChanged(object sender, EventArgs e)
        {
            if (curChartForm == null || AxisXCombobox.EditValue == null) return;
            DataTable dt = curChartForm.DataSource;
            string var = AxisXCombobox.EditValue.ToString();
            dt.Columns[var].SetOrdinal(0);
            if(curChartForm.ViewType == ViewType.Pie)
                StatisticChart.ShowOperation.CreatPieChart(curChartForm.ChartControl, dt);
            else if(curChartForm.ViewType == ViewType.Bar || curChartForm.ViewType == ViewType.Line || curChartForm.ViewType == ViewType.Point)
                StatisticChart.ShowOperation.CreatChart(curChartForm.ChartControl, dt, curChartForm.ViewType);
        }
        //重选数据字段
        private void AxisYCombobox_EditValueChanged(object sender, EventArgs e)
        {
            if (curChartForm == null || AxisYCombobox.EditValue == null) return;
            DataTable dt = curChartForm.DataSource;
            string[] vals = AxisYCombobox.EditValue.ToString().Replace(", ", ",").Split(',');
            if (curChartForm.ViewType == ViewType.Pie)
            {
                dt.Columns[vals[0]].SetOrdinal(1);
                StatisticChart.ShowOperation.CreatPieChart(curChartForm.ChartControl, dt);
            }
            else if (curChartForm.ViewType == ViewType.Bar || curChartForm.ViewType == ViewType.Line || curChartForm.ViewType == ViewType.Point)
                StatisticChart.ShowOperation.CreatChart(curChartForm.ChartControl, dt, curChartForm.ViewType, vals);
        }
        //设置图表标题
        private void ChartTitlebarEditItem_EditValueChanged(object sender, EventArgs e)
        {
            if (curChartForm == null || ChartTitlebarEditItem.EditValue.ToString() == "") return;
            curChartForm.ChartControl = StatisticChart.ShowOperation.SetChartTitle(curChartForm.ChartControl,
                ChartTitlebarEditItem.EditValue.ToString());
        }
        //设置横坐标标题
        private void AxisXTitlebarEditItem_EditValueChanged(object sender, EventArgs e)
        {
            if (curChartForm == null || AxisXTitlebarEditItem.EditValue.ToString() == "" || curChartForm.ViewType==ViewType.Pie) return;
            curChartForm.ChartControl = StatisticChart.ShowOperation.SetAxisXChartTitle(curChartForm.ChartControl,
                AxisXTitlebarEditItem.EditValue.ToString());
        }
        //设置纵坐标标题
        private void AxisYTitlebarEditItem_EditValueChanged(object sender, EventArgs e)
        {
            if (curChartForm == null || AxisYTitlebarEditItem.EditValue.ToString() == "" || curChartForm.ViewType == ViewType.Pie) return;
            curChartForm.ChartControl = StatisticChart.ShowOperation.SetAxisYChartTitle(curChartForm.ChartControl,
                AxisYTitlebarEditItem.EditValue.ToString());
        }
        #endregion

        #endregion

        #region //地图工具按钮事件
        
        #region //地图关键词
        //添加地图关键词
        private void bMap_AddKeyword_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage curTabPage = this.xtraTabControl_Main.SelectedTabPage;
            Control curFirstChildControl = curTabPage.Controls[0];
            if(curFirstChildControl is AxMapControl)
            {
                //curMapKeyName = curTabPage.Text;
                Forms.frmAddMapKeyword frmAddKey = new Forms.frmAddMapKeyword(ConnectionCenter.Config.MapKeywordSection, curMapKeyName);
                frmAddKey.FormClosed += frmAddKey_FormClosed;
                frmAddKey.ShowDialog();
            }
            //if()
        }
        //当窗体关闭时，刷新地图关键词
        void frmAddKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetMapKeywords();
        }
        //设置地图关键词
        private void SetMapKeywords()
        {
            this.ribbonGallery_MapKeywords.Gallery.Groups.Clear();
            this.ribbonGallery_MapKeywords.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleCheck;
            string mapKeywords = ConnectionCenter.INIFile.IniReadValue(ConnectionCenter.Config.MapKeywordSection, curMapKeyName);
            if(mapKeywords.Length == 0){
                return;
            }
            string[] keys = mapKeywords.Split(',');
            //添加到Gallery
            //this.ribbonGallery_MapKeywords.Gallery.Images = ribbonImageCollectionLarge;
            GalleryItemGroup itemGroup1 = new GalleryItemGroup();
            this.ribbonGallery_MapKeywords.Gallery.Groups.Add(itemGroup1);
            // Create gallery items and add them to the group. 
            List<GalleryItem> galleryItemList = new List<GalleryItem>();
            foreach (string key in keys)
            {
                GalleryItem item1 = new GalleryItem();
                item1.Caption = key;
                item1.Value = key;
                item1.ItemClick += item1_ItemClick;                
                galleryItemList.Add(item1);
            }
            GalleryItem[] galleryItems = galleryItemList.ToArray();
            itemGroup1.Items.AddRange(galleryItems);
            // Specify the number of items to display horizontally. 
            ribbonGallery_MapKeywords.Gallery.ColumnCount = 3;
            //throw new NotImplementedException();
        }
        //地图关键词搜索文档
        void item1_ItemClick(object sender, GalleryItemClickEventArgs e)
        {            
            GalleryItem item = (GalleryItem)sender;
            string keyword = item.Caption;
            SearchInPlanDoc(keyword);
        }
        //删除关键词
        private void bMap_RemoveKeyword_ItemClick(object sender, ItemClickEventArgs e)
        {
            int count = this.ribbonGallery_MapKeywords.Gallery.Groups.Count;
            List<GalleryItem> items = this.ribbonGallery_MapKeywords.Gallery.GetCheckedItems();
            if (items.Count == 0)
            {
                MessageBox.Show("选中关键词后再进行删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (GalleryItem item in items)
            {
                this.ribbonGallery_MapKeywords.Gallery.Groups[0].Items.Remove(item);
            }
            GalleryItemCollection itemsCol = this.ribbonGallery_MapKeywords.Gallery.Groups[0].Items;
            if (itemsCol.Count > 0)
            {
                List<string> keyList = new List<string>();
                foreach (GalleryItem item in itemsCol)
                {
                    keyList.Add(item.Caption);
                }
                string keys = string.Join(",", keyList);
                ConnectionCenter.INIFile.IniWriteValue(ConnectionCenter.Config.MapKeywordSection, curMapKeyName, keys);
            }
        }
        #endregion 
        
        #region //地图关联表
        //private void 
        #endregion

        //打开图层列表
        private void bMapLayers_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucTocCtrl);
            ucTocCtrl.Dock = DockStyle.Fill;
            ucTocCtrl.TOCControl.SetBuddyControl(curAxMapControl);
        }
        //打开地图
        private void bGalleryOpenMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;    //单选
            ofd.Title = "选择地图文件";
            ofd.Filter = "mxd文件|*.mxd";
            ofd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                if (fi.Exists)
                {
                    curAxMapControl.LoadMxFile(fi.FullName);
                    curAxMapControl.ActiveView.Refresh();
                }
            }
        }

        #region //GIS Tools
        //重置按钮
        private void bMapToolNull_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.setNull(curAxMapControl);
        }
        //添加图层
        private void bMapAddLayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.AddData(curAxMapControl);
        }

        private void bMapOutput_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.ExportImage(curAxMapControl.ActiveView);
        }
        //平移
        private void bMapPan_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.Pan(curAxMapControl);
        }
        //放大
        private void bMapZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.ZoomIn(curAxMapControl);
        }
        //缩小
        private void bMapZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.ZoomOut(curAxMapControl);
        }
        //全图
        private void bMapFullExtent_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.FullExtend(curAxMapControl);
        }
        //逐级放大
        private void bMapScaleIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.ZoomInFix(curAxMapControl);
        }
        //逐级缩小
        private void bMapScaleOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            GISTools.ZoomOutFix(curAxMapControl);
        }

        private void bMapQueryByPoint_ItemClick(object sender, ItemClickEventArgs e)
        {            
            GISManager.GISTools.setNull(curAxMapControl);

            isIdentifyMap = this.bMapQueryByPoint.Down;
            if (isIdentifyMap)
            {
                //curAxMapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
                GISTools.SelectFeature(curAxMapControl);
            }
            else
            {
                //curAxMapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
                curAxMapControl.Map.ClearSelection();
                curAxMapControl.Refresh();
            }
        }
        #endregion
        #endregion

        #region //文档搜索按钮
        private void bDoc_InitDocument_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bDoc_Search_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();

            this.panelControl_Navigation.Controls.Add(ucDocSearch);            
        }

        //郭海强 添加关键词搜索控件0913
        private void bDoc_InternalSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control control = this.xtraTabControl_Main.SelectedTabPage.Controls[0];
            if (control is RichEditControl)
            {
                this.panelControl_Navigation.Controls.Clear();
                ucDocIntSearch.setInitializationSearchResult();
                this.panelControl_Navigation.Controls.Add(ucDocIntSearch);
                ucDocIntSearch.XtraTabPage = this.xtraTabControl_Main.SelectedTabPage;
            }
        }

        //郭海强 添加文本、说明及专题文档路径1008
        private void setMultiDocumentsPath()
        {
            List<string> documentPaths = new List<string>();
            documentPaths.Add(ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDoc);
            documentPaths.Add(ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDesc);
            DataTable dt = ConnectionCenter.ConnLocalDisk.getDataTable(ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicMap);
            foreach (DataRow dr in dt.Rows)
                documentPaths.Add(dr["path"].ToString());
            ucDocIntSearch.DocumentPathCollection = documentPaths;
        }

        //郭海强 测试图表显示控件0922
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control control = this.xtraTabControl_Main.SelectedTabPage.Controls[0];
            if (control is SpreadsheetControl)
            {
                SpreadsheetControl ssc = (SpreadsheetControl)control;
                Worksheet worksheet = ssc.Document.Worksheets.ActiveWorksheet;
                DataTable dt = StatisticChart.DataOperation.CreateTablefromWorkSheet(worksheet);

                if (dt != null)
                {
                    Modules.ucChartShow ucChSh = new Modules.ucChartShow();
                    XtraTabPage xtp = new XtraTabPage();
                    xtp.Text = dt.TableName;
                    xtp.Controls.Add(ucChSh);
                    ucChSh.Dock = DockStyle.Fill;
                    this.xtraTabControl_Main.TabPages.Add(xtp);
                    this.xtraTabControl_Main.SelectedTabPage = xtp;
                    ucChSh.SetChartShow(dt, ViewType.Bar);
                    ucChSh.Refresh();
                    xtp.Refresh();
                    this.xtraTabControl_Main.Refresh();
                    this.Refresh();
                }
            }
        }

        #endregion
        
        #region //MapControl 事件
        //鼠标点击
        void curAxMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                curAxMapControl.ActiveView.ScreenDisplay.PanStart(curAxMapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));
                curAxMapControl.MousePointer = esriControlsMousePointer.esriPointerPan;
            }
        }
        //鼠标移动
        void curAxMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 4 && curAxMapControl.ActiveView != null)
            {
                curAxMapControl.ActiveView.ScreenDisplay.PanMoveTo(curAxMapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));
            }
        }
        //鼠标抬起
        void curAxMapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 1)  //左键
            {       
                //属性查询
                if (isIdentifyMap)
                {
                   // IFeat GISManager.GISHandler.GetFirstSelectionFeature(curAxMapControl);
                    int featureCount = curAxMapControl.Map.SelectionCount;
                    if (featureCount > 0)
                    {
                        DataTable dt = GISManager.GISHandler.GetFirstSelectionFeatureAttr(curAxMapControl);
                        if (dt.Rows.Count == 0)
                        {
                            return;
                        }
                        Control control = (Control)sender;
                        System.Drawing.Point pt = control.PointToScreen(new System.Drawing.Point(e.x, e.y));

                        if (pFrmMapFeatureAttr == null || pFrmMapFeatureAttr.IsDisposed)
                        {
                            pFrmMapFeatureAttr = new Forms.frmMapFeatureAttr();
                            pFrmMapFeatureAttr.AttrDataTable = dt;
                            pFrmMapFeatureAttr.Location = pt;
                            pFrmMapFeatureAttr.delegateSearch += new Forms.delegateSearchDoc(SearchInPlanDoc);
                            pFrmMapFeatureAttr.Show();
                        }
                        else
                        {
                            pFrmMapFeatureAttr.Visible = false;
                            pFrmMapFeatureAttr.AttrDataTable = dt;
                            pFrmMapFeatureAttr.Location = pt;
                            pFrmMapFeatureAttr.delegateSearch += new Forms.delegateSearchDoc(SearchInPlanDoc);
                            pFrmMapFeatureAttr.BringToFront();
                            pFrmMapFeatureAttr.Visible = true;
                        }


                    }
                }
            }
            else if (e.button == 2) //右键
            {
               
            }
            else if (e.button == 4 && curAxMapControl.ActiveView != null)   //中键
            {
                curAxMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
                curAxMapControl.ActiveView.ScreenDisplay.PanStop();
                curAxMapControl.ActiveView.Refresh();
            }
        }

        #endregion

        #region //主页搜索TabPage相关
        //点击进行搜索
        private void Query_button_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string keyword = this.Query_button.Text.Trim();
            //SearchInDoc(keyword, ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDoc);
            SearchInPlanDoc(keyword);
        }
        //enter键搜索
        private void Query_button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = this.Query_button.Text.Trim();
                SearchInPlanDoc(keyword);
                //SearchInDoc(keyword, ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDoc);
            }
        }
        
        //主页大小变化，布局跟随改变
        private void xtraTabPage_Home_SizeChanged(object sender, EventArgs e)
        {
            int lx = (this.xtraTabPage_Home.Width - this.panel_HomeSearch.Width)/2;
            int ly = (this.xtraTabPage_Home.Height - this.panel_HomeSearch.Height) / 5 * 2;
            this.panel_HomeSearch.Location = new System.Drawing.Point(lx, ly);

        }
        //规划文本
        private void sb_HomePlanDoc_Click(object sender, EventArgs e)
        {
            OpenPlanDoc();
        }
        //规划说明
        private void sb_HomePlanDesc_Click(object sender, EventArgs e)
        {
            OpenPlanDesc();
        }
        //专题报告
        private void sb_HomePlanThematic_Click(object sender, EventArgs e)
        {
            OpenThematicDocs();
        }
        //规划地图
        private void sb_HomePlanMap_Click(object sender, EventArgs e)
        {
            OpenPlanMaps();
        }
        //规划图集
        private void sb_HomePlanImg_Click(object sender, EventArgs e)
        {
            OpenPlanImgs();
        }
        #endregion

        #region //通用函数
        #region//搜索文本
        //搜索文本
        public void SearchInPlanDoc(string keyword)
        {
            SearchInDoc(keyword, ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDoc);
        }

        //搜索说明
        public void SearchInPlanDesc(string keyword)
        {
            SearchInDoc(keyword, ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDesc);
        }

        //搜索专题报告
        public void SearchInThematicDoc(string keyword)
        {
            SearchInDoc(keyword, ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicMap);
        }

        //搜索函数
        public void SearchInDoc(string keyword, string path)
        {
            if (keyword == "")
            {
                return;
            }
            if (!File.Exists(path))
            {
                return;
            }
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucDocIntSearch);
            ucDocIntSearch.SearchFromDocument(keyword, path, this.xtraTabControl_Main.SelectedTabPage);
        }
        #endregion

        #region //打开规划文件目录
        //全部规划文档
        private void OpenAllPlanDocs()
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucNaviFiles);
            ucNaviFiles.SourceFolder = ConnectionCenter.Config.FTPCatalog;
            ucNaviFiles.FetchFiles();
        }
        //规划文本
        private void OpenPlanDoc()
        {
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDoc;
            OpenDocInTabPage(path);
        }
        //规划说明
        private void OpenPlanDesc()
        {
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanDesc;
            OpenDocInTabPage(path);
        }
        //专题报告
        private void OpenThematicDocs()
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucNaviFiles);
            ucNaviFiles.SourceFolder = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicMap;
            ucNaviFiles.FetchFiles();
        }
        //规划地图
        private void OpenPlanMaps()
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucNaviFiles);
            ucNaviFiles.SourceFolder = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanMap;
            ucNaviFiles.FetchFiles();
        }
        //规划图集
        private void OpenPlanImgs()
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucNavImage);
            ucNavImage.XTabControl = this.xtraTabControl_Main;
            ucNavImage.ImageFolderPath = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanImg;
            ucNavImage.Dock = DockStyle.Fill;
        }
        //在tab中打开文档
        private void OpenDocInTabPage(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }
            string fileName = System.IO.Path.GetFileName(path);
            string fileExt = System.IO.Path.GetExtension(path);
            //如果已经有这个tabPage
            XtraTabPage ifTabPage = ComponentOperator.IfHasTabPage(fileName, this.xtraTabControl_Main);
            if (ifTabPage != null)
            {
                this.xtraTabControl_Main.SelectedTabPage = ifTabPage;
            }
            else
            {
                int iconIndex = this.imageCollectionIcons.Images.Keys.IndexOf(fileExt);
                RichEditControl rec = new RichEditControl();
                rec.LoadDocument(path);
                if (rec != null)
                {
                    //TabPage
                    XtraTabPage xtp = new XtraTabPage();
                    xtp.Text = fileName;
                    if (iconIndex >= 0)
                    {
                        Image tableIcon = this.imageCollectionIcons.Images[iconIndex];
                        xtp.Image = tableIcon;
                    }
                    xtp.Controls.Add(rec);
                    rec.Dock = DockStyle.Fill;
                    this.xtraTabControl_Main.TabPages.Add(xtp);
                    this.xtraTabControl_Main.SelectedTabPage = xtp;
                }
            }
        }
#endregion
       
       
        #region//叠置分析所需方法
        //坐标点赋坐标
        private IPoint GetGeo(double x, double y)
        {
            IPoint pt = new ESRI.ArcGIS.Geometry.Point();
            ISpatialReferenceFactory pFactory = new SpatialReferenceEnvironmentClass();
            IGeometry geo = (IGeometry)pt;
            //geo.SpatialReference=pFactory.CreateProjectedCoordinateSystem((int)esriSRGeoCSType);
            geo.Project(pFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCS3Type.esriSRGeoCS_Xian1980));
            return pt;
        }
        //提取mxd中shp?
        private void extractShp(string MxFilePath)
        {
            IMapDocument pMapDoc = new MapDocumentClass();
            IFeatureLayer pFeatureLayer;
            pMapDoc.Open(MxFilePath,"");
            for(int i=0; i<=pMapDoc.MapCount-1; i++)
            {
                pFeatureLayer=pMapDoc.get_Layer(i,i) as IFeatureLayer;
                File.Copy(pFeatureLayer.ToString(), tempPath, true);
            }
        }


        //叠置分析
        private void StartIntersect(string strInputFeature, string strOverLayFeature)
        {
            string outputPath = tempPath+@"\Result.shp";
            string in_features = string.Format("{0};{1}", strInputFeature, strOverLayFeature);
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            gp.SetEnvironmentValue("workspace", _Environment);
            Intersect intsect = new Intersect();
            intsect.in_features = in_features;
            intsect.out_feature_class = outputPath;
            intsect.cluster_tolerance = "0.0001";
            intsect.join_attributes = "ALL";
            intsect.output_type = "INPUT";
            try
            {
                gp.Execute(intsect, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("GeoProcessor Error!\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DirectoryInfo direct = new DirectoryInfo(_Environment);
            FileInfo[] fileInfos = direct.GetFiles("Result.*", SearchOption.AllDirectories);
            for (int i = 0; i < fileInfos.Count(); i++)
            {
                string afterFile = fileInfos[i].Name.Substring(fileInfos[i].Name.LastIndexOf("."));
                string target = final.Substring(0, final.LastIndexOf(".")) + afterFile;
                if (File.Exists(target))
                    File.Delete(target);
                File.Move(fileInfos[i].FullName, target);

            }
        }

        //绘制多边形
        private void DrawMapShape(IGeometry pGeom)
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 220;
            pColor.Green = 112;
            pColor.Blue = 60;
            //新建一个绘制图形的填充符号
            ISimpleFillSymbol pFillsyl = new SimpleFillSymbolClass();
            pFillsyl.Color = pColor;
            object oFillsyl = pFillsyl;
            curAxMapControl.DrawShape(pGeom, ref oFillsyl);
        }

        //叠置结果生成饼图
        private void CreatResultPie(string dbfPath)
        {
             string OpenFileName = dbfPath.Trim();
            string dbfFilePath = System.IO.Path.GetDirectoryName(OpenFileName);
            string dbfFileName = System.IO.Path.GetFileName(OpenFileName);

            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(dbfFilePath, 0);
            IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
            if (pFeatureWorkspace != null)
            {
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(dbfFileName);
                if (pFeatureClass != null)
                {
                    //创建空DataTable
                    DataTable dt = new DataTable();
                    DataColumn dc = null;

                    for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
                    {
                        dc = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                        dt.Columns.Add(dc);
                    }
                    //读入数据至DataTable
                    IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                    IFeature pFeature = pFeatureCursor.NextFeature();
                    DataRow dr = null;
                    while (pFeature != null)
                    {
                        dr = dt.NewRow();
                        for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
                        {
                            if (pFeatureClass.FindField(pFeatureClass.ShapeFieldName) == j)
                            {
                                dr[j] = pFeatureClass.ShapeType.ToString();
                            }
                            else
                            {
                                dr[j] = pFeature.get_Value(j).ToString();
                            }
                        }
                        dt.Rows.Add(dr);
                        pFeature = pFeatureCursor.NextFeature();
                    }
                    double JZQArea = ColumnSum(dt, "JZQMJ");
                    double NYDArea = ColumnSum(dt, "NYDMJ");
                    double GDArea = ColumnSum(dt, "GDMJ");
                    double JBNTArea = ColumnSum(dt, "JBNTMJ");


                    DataTable pDataTable = new DataTable();
                    DataColumn pDataColumn = null;
                    //pDataColumn = pDataTable.Columns.Add("ID", Type.GetType("System.Int32"));
                    //pDataColumn.AutoIncrement = true;
                    //pDataColumn.AutoIncrementSeed = 1;
                    //pDataColumn.AutoIncrementStep = 1;
                    //pDataColumn.AllowDBNull = false;

                    //pDataColumn = pDataTable.Columns.Add("居住区面积", Type.GetType("System.Double"));
                    //pDataColumn = pDataTable.Columns.Add("农用地面积", Type.GetType("System.Double"));
                    //pDataColumn = pDataTable.Columns.Add("工地面积", Type.GetType("System.Double"));
                    //pDataColumn = pDataTable.Columns.Add("基本农田面积", Type.GetType("System.Double"));
                    pDataColumn = pDataTable.Columns.Add("用地类型", Type.GetType("System.String"));
                    pDataColumn = pDataTable.Columns.Add("占地面积", Type.GetType("System.Double"));

                    DataRow pDataRow = pDataTable.NewRow();
                    pDataRow["用地类型"] = "居住地";
                    pDataRow["占地面积"] = JZQArea;
                    pDataTable.Rows.Add(pDataRow);

                    DataRow pDataRow1 = pDataTable.NewRow();
                    pDataRow1["用地类型"] = "农用地";
                    pDataRow1["占地面积"] = NYDArea;
                    pDataTable.Rows.Add(pDataRow1);

                    DataRow pDataRow2 = pDataTable.NewRow();
                    pDataRow2["用地类型"] = "工地";
                    pDataRow2["占地面积"] = GDArea;
                    pDataTable.Rows.Add(pDataRow2);

                    DataRow pDataRow3 = pDataTable.NewRow();
                    pDataRow3["用地类型"] = "基本农田";
                    pDataRow3["占地面积"] = JBNTArea;
                    pDataTable.Rows.Add(pDataRow3);

                    if (pDataTable != null)
                    {
                        Modules.ucChartForm ucc = new Modules.ucChartForm(this);
                        ucc.Icon = Icon.FromHandle(((Bitmap)PieChartButton.Glyph).GetHicon());
                        ucc.DataSource = pDataTable.Copy();
                        //ucc.Range = pDataTable;
                        ucc.StartPosition = FormStartPosition.Manual;
                        //ucc.Right = xtraTabPage_Home.Right;
                        //ucc.Left = Screen.PrimaryScreen.WorkingArea.Width - ucc.Width;
                        ucc.Left = 250;
                        //ucc.Top = ucc.Height;
                        ucc.Top = 200;
                        ucc.Size = new Size(300,200);
                        ucc.ViewType = ViewType.Pie;
                        StatisticChart.ShowOperation.CreatPieChart(ucc.ChartControl, pDataTable);
                        ucc.Activated += curChartForm_Activated;
                        ucc.Show();
                        ResetFieldComboBox(curChartForm.VariableField, curChartForm.ValueField);
                    }
                }
            }
        }

        //字段求和
        double ColumnSum(DataTable dt, string ColumnName)
        {
            double d = 0;
            foreach (DataRow row in dt.Rows)
            {
                d += double.Parse(row[ColumnName].ToString());
            }
            return d;
        }

        //加载红线地图?
        private void LoadRedLine()
        {
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanMap + @"\18.沈阳经济区红线融合图.mxd";
            curAxMapControl.LoadMxFile(path);
            curAxMapControl.ActiveView.Refresh();
        }
        //读取叠置结果属性?
        private void ReadResultDbf()
        {

        }
        #endregion

        #region//叠置分析事件
       
        //坐标导入事件
        private void bCoorInputButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            //读取坐标文件
            DrawPolygon = false;
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            op.Filter = "文本文件(*.txt)|*.txt|excel文件(*.xls)|*.xls";
           
            if (op.ShowDialog(this) == DialogResult.OK)
                 {
                     string fullPath=op.FileName;
                     string extension = System.IO.Path.GetExtension(fullPath);

                     #region  //判断shp是否已经存在，如果存在则删除
                     string inSHPpath =tempPath+@"\test.shp";
                     string shpDirName = System.IO.Path.GetDirectoryName(inSHPpath);
                     string shpName1 = System.IO.Path.GetFileNameWithoutExtension(inSHPpath);
                     string shpFullName = shpName1 + ".shp";
                     string prjName = shpName1 + ".prj";
                     string dbfName = shpName1 + ".dbf";
                     string shxName = shpName1 + ".shx";
                     string sbnName = shpName1 + ".sbn";
                     string xmlName = shpName1 + ".shp.xml";
                     string sbxName = shpName1 + ".sbx";
                     if (System.IO.File.Exists(shpDirName + "\\" + shpFullName))
                         System.IO.File.Delete(shpDirName + "\\" + shpFullName);
                     if (System.IO.File.Exists(shpDirName + "\\" + prjName))
                         System.IO.File.Delete(shpDirName + "\\" + prjName);
                     if (System.IO.File.Exists(shpDirName + "\\" + dbfName))
                         System.IO.File.Delete(shpDirName + "\\" + dbfName);
                     if (System.IO.File.Exists(shpDirName + "\\" + shxName))
                         System.IO.File.Delete(shpDirName + "\\" + shxName);
                     if (System.IO.File.Exists(shpDirName + "\\" + sbnName))
                         System.IO.File.Delete(shpDirName + "\\" + sbnName);
                     if (System.IO.File.Exists(shpDirName + "\\" + xmlName))
                         System.IO.File.Delete(shpDirName + "\\" + xmlName);
                     if (System.IO.File.Exists(shpDirName + "\\" + sbxName))
                         System.IO.File.Delete(shpDirName + "\\" + sbxName);

                     #endregion

                     #region// 开始生成shp
                     string shpName = System.IO.Path.GetFileNameWithoutExtension(inSHPpath);   //获取生成的矢量

                     //打开生成shapefile的工作空间；
                     IFeatureWorkspace pFWS = null;
                     IWorkspaceFactory pWSF = new ShapefileWorkspaceFactory();
                     pFWS = pWSF.OpenFromFile(shpDirName, 0) as IFeatureWorkspace;

                     //开始添加属性字段；
                     IFields fields = new FieldsClass();
                     IFieldsEdit fieldsEdit = (IFieldsEdit)fields;

                     //添加字段“OID”；
                     IField oidField = new FieldClass();
                     IFieldEdit oidFieldEdit = (IFieldEdit)oidField;
                     oidFieldEdit.Name_2 = "OID";
                     oidFieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
                     fieldsEdit.AddField(oidField);

                     //设置生成图的空间坐标参考系统；
                     IGeometryDef geometryDef = new GeometryDefClass();
                     IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
                     geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                     ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                     // ISpatialReference spatialReference = new UnknownCoordinateSystemClass();
                     IProjectedCoordinateSystem spatialReference = spatialReferenceFactory.CreateProjectedCoordinateSystem((int)esriSRProjCS4Type.esriSRProjCS_Xian1980_GK_Zone_21);


                     ISpatialReferenceResolution spatialReferenceResolution = (ISpatialReferenceResolution)spatialReference;
                     spatialReferenceResolution.ConstructFromHorizon();
                     ISpatialReferenceTolerance spatialReferenceTolerance = (ISpatialReferenceTolerance)spatialReference;
                     spatialReferenceTolerance.SetDefaultXYTolerance();
                     geometryDefEdit.SpatialReference_2 = spatialReference;

                     //添加字段“Shape”;
                     IField geometryField = new FieldClass();
                     IFieldEdit geometryFieldEdit = (IFieldEdit)geometryField;
                     geometryFieldEdit.Name_2 = "Shape";
                     geometryFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                     geometryFieldEdit.GeometryDef_2 = geometryDef;
                     fieldsEdit.AddField(geometryField);


                     IField nameField = new FieldClass();
                     IFieldEdit nameFieldEdit = (IFieldEdit)nameField;

                     //添加字段“经度X”；
                     nameField = new FieldClass();
                     nameFieldEdit = (IFieldEdit)nameField;
                     nameFieldEdit.Name_2 = "经度X";
                     nameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                     nameFieldEdit.Length_2 = 20;
                     fieldsEdit.AddField(nameField);

                     //添加字段“纬度Y”；
                     nameField = new FieldClass();
                     nameFieldEdit = (IFieldEdit)nameField;
                     nameFieldEdit.Name_2 = "纬度Y";
                     nameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                     nameFieldEdit.Length_2 = 20;
                     fieldsEdit.AddField(nameField);

                     //添加面积（改动）
                     nameField = new FieldClass();
                     nameFieldEdit = (IFieldEdit)nameField;
                     nameFieldEdit.Name_2 = "面积";
                     nameFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                     fieldsEdit.AddField(nameField);

                     IFieldChecker fieldChecker = new FieldCheckerClass();
                     IEnumFieldError enumFieldError = null;
                     IFields validatedFields = null;
                     fieldChecker.ValidateWorkspace = (IWorkspace)pFWS;
                     fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

                     //在工作空间中生成FeatureClass;
                     IFeatureClass pNewFeaCls = pFWS.CreateFeatureClass(shpName, validatedFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                     IFeature feature = null;
                     //feature = pNewFeaCls.CreateFeature();


              #region//Read TXT      
                if(extension==".txt")
                     {
                string[] str = null;
                IPoint pt = new PointClass();
                IPointCollection polygon = new PolygonClass();
                object missing = Type.Missing;
                IPointArray pts = new PointArrayClass();
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[0-9\.,]*$");
                System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"[0-9\.,°']");
                string txtPath = op.FileName;
                //"F:\\坐标转shp\\坐标序列文件\\新建文本文档.txt";
                StreamReader objread = new StreamReader(txtPath);
                while (!objread.EndOfStream)
                {
                    string tt = objread.ReadLine();
                    if (reg.IsMatch(tt) || reg1.IsMatch(tt))
                    {
                        feature = pNewFeaCls.CreateFeature();
                        str = tt.Split(',');
                        if (str.Length > 2)
                        {
                            if (str[2] != "" && reg.IsMatch(str[2]))
                            {
                                //IPointCollection polygon = new PolygonClass();
                                pt = new PointClass();
                                pt.PutCoords(double.Parse(str[1]), double.Parse(str[2]));
                                GetGeo(pt.X, pt.Y);
                                pts.Add(pt);
                                polygon.AddPoint(pt, ref missing, ref missing);
                                feature.Shape = polygon as IGeometry;

                                feature.Store();
                                feature.set_Value(2, pt.X.ToString());
                                feature.set_Value(3, pt.Y.ToString());
                                feature.Store();
                                IMap pmap = curAxMapControl.Map;
                                IActiveView pactive = pmap as IActiveView;

                                IPolygonElement pmarke = new PolygonElementClass();
                                IElement pele = pmarke as IElement;
                                pele.Geometry = polygon as IGeometry;
                                IGraphicsContainer pgra;
                                pgra = pmap as IGraphicsContainer;
                                pgra.AddElement(pmarke as IElement, 0);
                                pactive.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                            }
                            else if (reg1.IsMatch(str[1]))
                            {
                                //IPointCollection polygon = new PolygonClass();
                                string[] stt = null;
                                stt = str[1].Split('°');
                                string a = stt[0];
                                string[] A = System.Text.RegularExpressions.Regex.Split(stt[1], "'");
                                string b = A[0];

                                string c = System.Text.RegularExpressions.Regex.Replace(A[1], @"[^\d.\d]", "");
                                string[] rtt = null;
                                rtt = str[2].Split('°');
                                string d = rtt[0];
                                string[] B = System.Text.RegularExpressions.Regex.Split(rtt[1], "'");
                                string f = B[0];
                                string g = System.Text.RegularExpressions.Regex.Replace(B[1], @"[^\d.\d]", "");
                                double log = Convert.ToDouble(a) + Convert.ToDouble(b) / 60 + Convert.ToDouble(c) / 3600;
                                double lat = Convert.ToDouble(d) + Convert.ToDouble(f) / 60 + Convert.ToDouble(g) / 3600;
                                pt = new PointClass();
                                pt.PutCoords(log, lat);

                                pts.Add(pt);
                                polygon.AddPoint(pt, ref missing, ref missing);
                                feature.Shape = polygon as IGeometry;

                                feature.Store();
                                feature.set_Value(2, pt.X.ToString());
                                feature.set_Value(3, pt.Y.ToString());
                                feature.Store();
                                IMap pmap = curAxMapControl.Map;
                                IActiveView pactive = pmap as IActiveView;

                                IPolygonElement pmarke = new PolygonElementClass();
                                IElement pele = pmarke as IElement;
                                pele.Geometry = polygon as IGeometry;
                                IGraphicsContainer pgra;
                                pgra = pmap as IGraphicsContainer;
                                pgra.AddElement(pmarke as IElement, 0);
                                pactive.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                            }
                        }
                        if (str.Length < 3)
                        {
                            // IPointCollection polygon = new PolygonClass();
                            pt.PutCoords(double.Parse(str[0]), double.Parse(str[1]));
                            GetGeo(pt.X, pt.Y);
                            pts.Add(pt);
                            polygon.AddPoint(pt, ref missing, ref missing);
                            IMap pmap = curAxMapControl.Map;
                            IActiveView pactive = pmap as IActiveView;

                            IPolygonElement pmarke = new PolygonElementClass();
                            IElement pele = pmarke as IElement;
                            pele.Geometry = polygon as IGeometry;
                            IGraphicsContainer pgra;
                            pgra = pmap as IGraphicsContainer;
                            pgra.AddElement(pmarke as IElement, 0);
                            pactive.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                            feature.Shape = polygon as IGeometry;
                            feature.Store();
                            feature.set_Value(2, pt.X.ToString());
                            feature.set_Value(3, pt.Y.ToString());
                            feature.Store();
                        }
                    }
                }
                #endregion

                IPolygon pGontxt = polygon as IPolygon;
                IArea pAreatxt = pGontxt as IArea;
                double stxt = pAreatxt.Area/1000000;//
                double Stxt = Math.Abs(stxt);
                MessageBox.Show("该区域面积为：" + Convert.ToDouble(Stxt).ToString("0.000") + "平方公里（km2）", "项目区面积");
                string DirPath = tempPath;
                AxMapControl mapControl = new AxMapControl();
                mapControl = curAxMapControl;
                mapControl.AddShapeFile(DirPath, "test.shp");
                //mapControl.Refresh();
              #endregion

                     #region//Read Excel
                    //代码有问题，无法连接至excel
                if (extension==".xls")
                    {
                        //添加feature;
                        //F:\坐标转shp\坐标序列文件\土地样例.xls
                        string strcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+op.FileName+";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                        OleDbConnection con = new OleDbConnection(strcon);
                        con.Open();
                        string sheetname = "";
                        //string[] sheetnamelist = null;
                        System.Data.DataTable dd = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "table" });
                        for (int j = 0; j < dd.Rows.Count; j++)
                        {
                            sheetname = dd.Rows[j]["table_name"].ToString();
                        }

                        string strExcel = "select * from [" + sheetname + "]";
                        OleDbDataAdapter comm = new OleDbDataAdapter(strExcel, con);
                        DataSet ds = new DataSet();
                        comm.Fill(ds, "[" + sheetname + "]");
                        con.Close();
                        DataTable dt = ds.Tables[0];

                        IPointArray pArray = new PointArrayClass();
                        IPoint pPoint = new PointClass();
                        IPointCollection pPolygon = new PolygonClass();
                        object Missing = Type.Missing;
                        //esriSRGeoCS3Type.esriSRGeoCS_Xian1980 
                        for (int i = 0; i < dt.Rows.Count - 1; i++)
                        {
                            //polygon = new PolygonClass();
                            feature = pNewFeaCls.CreateFeature();
                            string a = dt.Rows[i].ItemArray[1].ToString();
                            string b = dt.Rows[i].ItemArray[2].ToString();
                            //string a = dt.Rows[i][0].ToString();
                            //string b = dt.Rows[i][1].ToString();
                            pPoint.PutCoords(double.Parse(a), double.Parse(b));
                            //  GetGeo(pt.X, pt.Y);
                            pArray.Add(pPoint);

                            pPolygon.AddPoint(pPoint, ref missing, ref missing);
                            if (pPolygon.PointCount > 0)
                            {
                                IClone pClone = pPolygon.get_Point(0) as IClone;
                                IPoint endpoint = pClone.Clone() as IPoint;
                                pPolygon.AddPoint(endpoint, ref Missing, ref Missing);
                            }

                            feature.Shape = pPolygon as IGeometry;
                            feature.Store();
                            IMap pmap = curAxMapControl.Map;
                            IActiveView pactive = pmap as IActiveView;
                            IPolygonElement pmark = new PolygonElementClass();

                            IElement pele = pmark as IElement;
                            pele.Geometry = pPolygon as IGeometry;

                            IGraphicsContainer pgra = pmap as IGraphicsContainer;
                            pgra.AddElement(pmark as IElement, 0);
                            pactive.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                            feature.set_Value(2, pt.X.ToString());
                            feature.set_Value(3, pt.Y.ToString());
                            feature.Store();
                        }
                        IPolygon pGonxls = pPolygon as IPolygon;
                        IArea pAreaxls = pGonxls as IArea;
                        double sxls = pAreaxls.Area / 1000000;//
                        double Sxls = Math.Abs(sxls);
                        MessageBox.Show("该区域面积为：" + Convert.ToDouble(Sxls).ToString("0.000") + "平方公里（km2）", "项目区面积");
                        AxMapControl mapControl1 = new AxMapControl();
                        mapControl1 = curAxMapControl;
                        mapControl1.AddShapeFile(DirPath, "test.shp");
                        #endregion

                    }

                if (MessageBox.Show("开始分析?", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //read shp of mxd
                    string strInputFeaturePath = ConnectionCenter.Config.FTPCatalog+ConnectionCenter.Config.PlanMap+@"\shp\GHJBNTJZQ（处理后）.shp";
                    string strInputFeatureName = System.IO.Path.GetFileNameWithoutExtension(strInputFeaturePath);// "GHJBNTJZQ（处理后）.shp";
                    FileInfo fileInfo = new FileInfo(strInputFeaturePath);
                    DirectoryInfo direct = fileInfo.Directory;
                    FileInfo[] fileinfos = direct.GetFiles(string.Format("{0}.*", fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf("."))));
                    for (int i = 0; i < fileinfos.Count(); i++)
                    {
                        File.Copy(fileinfos[i].FullName, _Environment + @"\" + fileinfos[i].Name, true);
                    }
                    this.strInputFeature = fileInfo.Name;

                    string strOverLayFeaturePath = tempPath + @"\test.shp";
                    string strOverLayFeatureName = "test.shp";
                    //string strOverLayFeatureName = System.IO.Path.GetFileNameWithoutExtension(strOverLayFeaturePath);
                    FileInfo fileInfo1 = new FileInfo(strOverLayFeaturePath);
                    DirectoryInfo direct1 = fileInfo1.Directory;
                    FileInfo[] fileinfos1 = direct1.GetFiles(string.Format("{0}.*", fileInfo1.Name.Substring(0, fileInfo1.Name.LastIndexOf("."))));
                    for (int i = 0; i < fileinfos1.Count(); i++)
                    {
                        File.Copy(fileinfos1[i].FullName, _Environment + @"\" + fileinfos1[i].Name, true);
                    }
                    this.strOverLayFeature = fileInfo1.Name;

                    this.StartIntersect(strInputFeature, strOverLayFeature);
                    //分析进度条
                    ThreadForm thr = new ThreadForm(0, 100);
                    thr.Show(this);
                    for (int i = 0; i < 100; i++)
                    {
                        thr.setPos(i);
                        Thread.Sleep(20);
                    }
                    thr.Close();
                    //添加叠置结果图
                    mapControl.ClearLayers();
                    mapControl.LoadMxFile(ConnectionCenter.Config.FTPCatalog+ConnectionCenter.Config.PlanMap+@"\18.沈阳经济区红线融合图.mxd");
                    mapControl.AddShapeFile(DirPath, "Result.shp");
                    mapControl.Refresh();
                    string dbfPath = tempPath + @"\Result.dbf";
                    CreatResultPie(dbfPath);
                }
              }
            }//ifdiag
        }

        //手动绘制事件
        private void bManualDrawButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            // MousePointer属性可以改变鼠标指针的样式
            curAxMapControl.MousePointer =
            esriControlsMousePointer.esriPointerCrosshair;
            DrawPolygon = true;
            ////开始叠置分析
            //if (startIntersect)
            //{
            //}
        }

        //鼠标单击绘制事件
        private void mapControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1) //== MouseButtons.Left)
            {
                if (DrawPolygon)
                {
                    IGeometry pPolygon = curAxMapControl.TrackPolygon();
                    //刷新地图
                    DrawMapShape(pPolygon);
                    curAxMapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
                    //curAxMapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                    if (pPolygon != null && !pPolygon.IsEmpty)
                    {
                        #region//生成shp
                        string inSHPpath = tempPath + @"\draw.shp";
                        string shpDirName = System.IO.Path.GetDirectoryName(inSHPpath);
                        string shpName1 = System.IO.Path.GetFileNameWithoutExtension(inSHPpath);
                        string shpFullName = shpName1 + ".shp";
                        string prjName = shpName1 + ".prj";
                        string dbfName = shpName1 + ".dbf";
                        string shxName = shpName1 + ".shx";
                        string sbnName = shpName1 + ".sbn";
                        string xmlName = shpName1 + ".shp.xml";
                        string sbxName = shpName1 + ".sbx";
                        if (System.IO.File.Exists(shpDirName + "\\" + shpFullName))
                            System.IO.File.Delete(shpDirName + "\\" + shpFullName);
                        if (System.IO.File.Exists(shpDirName + "\\" + prjName))
                            System.IO.File.Delete(shpDirName + "\\" + prjName);
                        if (System.IO.File.Exists(shpDirName + "\\" + dbfName))
                            System.IO.File.Delete(shpDirName + "\\" + dbfName);
                        if (System.IO.File.Exists(shpDirName + "\\" + shxName))
                            System.IO.File.Delete(shpDirName +"\\"+ shxName);
                        if (System.IO.File.Exists(shpDirName + "\\" + sbnName))
                            System.IO.File.Delete(shpDirName + "\\" + sbnName);
                        if (System.IO.File.Exists(shpDirName + "\\" + xmlName))
                            System.IO.File.Delete(shpDirName + "\\" + xmlName);
                        if (System.IO.File.Exists(shpDirName + "\\" + sbxName))
                            System.IO.File.Delete(shpDirName + "\\" + sbxName);

                        string shpName = System.IO.Path.GetFileNameWithoutExtension(inSHPpath);   //获取生成的矢量

                        //打开生成shapefile的工作空间；
                        IFeatureWorkspace pFWS = null;
                        IWorkspaceFactory pWSF = new ShapefileWorkspaceFactory();
                        pFWS = pWSF.OpenFromFile(shpDirName, 0) as IFeatureWorkspace;

                        //开始添加属性字段；
                        IFields fields = new FieldsClass();
                        IFieldsEdit fieldsEdit = (IFieldsEdit)fields;

                        //添加字段“OID”；
                        IField oidField = new FieldClass();
                        IFieldEdit oidFieldEdit = (IFieldEdit)oidField;
                        oidFieldEdit.Name_2 = "OID";
                        oidFieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
                        fieldsEdit.AddField(oidField);

                        //设置生成图的空间坐标参考系统；
                        IGeometryDef geometryDef = new GeometryDefClass();
                        IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
                        geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                        ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                        //ISpatialReference spatialReference = new UnknownCoordinateSystemClass();
                        IProjectedCoordinateSystem spatialReference = spatialReferenceFactory.CreateProjectedCoordinateSystem((int)esriSRProjCS4Type.esriSRProjCS_Xian1980_GK_Zone_21);

                        ISpatialReferenceResolution spatialReferenceResolution = (ISpatialReferenceResolution)spatialReference;
                        spatialReferenceResolution.ConstructFromHorizon();
                        ISpatialReferenceTolerance spatialReferenceTolerance = (ISpatialReferenceTolerance)spatialReference;
                        spatialReferenceTolerance.SetDefaultXYTolerance();
                        geometryDefEdit.SpatialReference_2 = spatialReference;

                        //添加字段“Shape”;
                        IField geometryField = new FieldClass();
                        IFieldEdit geometryFieldEdit = (IFieldEdit)geometryField;
                        geometryFieldEdit.Name_2 = "Shape";
                        geometryFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                        geometryFieldEdit.GeometryDef_2 = geometryDef;
                        fieldsEdit.AddField(geometryField);


                        IField nameField = new FieldClass();
                        IFieldEdit nameFieldEdit = (IFieldEdit)nameField;

                        //添加字段“经度X”；
                        nameField = new FieldClass();
                        nameFieldEdit = (IFieldEdit)nameField;
                        nameFieldEdit.Name_2 = "经度X";
                        nameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                        nameFieldEdit.Length_2 = 20;
                        fieldsEdit.AddField(nameField);

                        //添加字段“纬度Y”；
                        nameField = new FieldClass();
                        nameFieldEdit = (IFieldEdit)nameField;
                        nameFieldEdit.Name_2 = "纬度Y";
                        nameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                        nameFieldEdit.Length_2 = 20;
                        fieldsEdit.AddField(nameField);

                        //添加面积（改动）
                        nameField = new FieldClass();
                        nameFieldEdit = (IFieldEdit)nameField;
                        nameFieldEdit.Name_2 = "面积";
                        nameFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                        fieldsEdit.AddField(nameField);


                        IFieldChecker fieldChecker = new FieldCheckerClass();
                        IEnumFieldError enumFieldError = null;
                        IFields validatedFields = null;
                        fieldChecker.ValidateWorkspace = (IWorkspace)pFWS;
                        fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

                        //在工作空间中生成FeatureClass;
                        IFeatureClass pNewFeaCls = pFWS.CreateFeatureClass(shpName, validatedFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                        IFeature feature = null;
                        //feature = pNewFeaCls.CreateFeature();
                        #endregion


                        //object missing = Type.Missing;
                        IPointCollection pPointColl = pPolygon as IPointCollection;

                        for (int i = 0; i < pPointColl.PointCount; i++)
                        {
                            feature = pNewFeaCls.CreateFeature();
                            IPoint pt = pPointColl.get_Point(i);
                            //GetGeo(pt.X, pt.Y);
                            //pts.Add(pt);
                            // pPointColl.AddPoint(pt, ref missing, ref missing);
                            feature.Shape = pPointColl as IGeometry;

                            feature.Store();
                            feature.set_Value(2, pt.X.ToString());
                            feature.set_Value(3, pt.Y.ToString());
                            feature.Store();

                        }
                        IMap pmap = curAxMapControl.Map;
                        IActiveView pactive = pmap as IActiveView;

                        IPolygonElement pmarke = new PolygonElementClass();
                        IElement pele = pmarke as IElement;
                        pele.Geometry = pPointColl as IGeometry;
                        IGraphicsContainer pgra;
                        pgra = pmap as IGraphicsContainer;
                        pgra.AddElement(pmarke as IElement, 0);
                        pactive.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        IPolygon pGon = pPolygon as IPolygon;
                        IArea pArea = pGon as IArea;
                        double s = pArea.Area/1000000 ;//
                        double ss= Math.Abs(s);
                        MessageBox.Show("该区域面积为：" + Convert.ToDouble(ss).ToString("0.000") + "平方公里（km2）", "项目区面积");
                        // IPointArray pts = new PointArrayClass();
                        //if (MessageBox.Show("确定绘制？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        //{
                            pgra.DeleteAllElements();
                            this.curAxMapControl.Refresh();
                        //}
                    }
                    string DirPath = tempPath;
                    AxMapControl mapControl = new AxMapControl();
                    mapControl = curAxMapControl;
                    mapControl.AddShapeFile(DirPath, "draw.shp");
                    mapControl.Refresh();
                    if (MessageBox.Show("开始分析?", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //read shp of mxd
                        string strInputFeaturePath = ConnectionCenter.Config.FTPCatalog+ConnectionCenter.Config.PlanMap+@"\shp\GHJBNTJZQ（处理后）.shp";
                        string strInputFeatureName = System.IO.Path.GetFileNameWithoutExtension(strInputFeaturePath); //"GHJBNTJZQ（处理后）.shp";
                        FileInfo fileInfo = new FileInfo(strInputFeaturePath);
                        DirectoryInfo direct = fileInfo.Directory;
                        FileInfo[] fileinfos = direct.GetFiles(string.Format("{0}.*", fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf("."))));
                        for (int i = 0; i < fileinfos.Count(); i++)
                        {
                            File.Copy(fileinfos[i].FullName, _Environment + @"\" + fileinfos[i].Name, true);
                        }
                        this.strInputFeature = fileInfo.Name;

                        string strOverLayFeaturePath = tempPath+@"\draw.shp";
                        string strOverLayFeatureName = "draw.shp";
                        //string strOverLayFeatureName = System.IO.Path.GetFileNameWithoutExtension(strOverLayFeaturePath);
                        FileInfo fileInfo1 = new FileInfo(strOverLayFeaturePath);
                        DirectoryInfo direct1 = fileInfo1.Directory;
                        FileInfo[] fileinfos1 = direct1.GetFiles(string.Format("{0}.*", fileInfo1.Name.Substring(0, fileInfo1.Name.LastIndexOf("."))));
                        for (int i = 0; i < fileinfos1.Count(); i++)
                        {
                            File.Copy(fileinfos1[i].FullName, _Environment + @"\" + fileinfos1[i].Name, true);
                        }
                        this.strOverLayFeature = fileInfo1.Name;

                        this.StartIntersect(strInputFeature, strOverLayFeature);
                        ThreadForm thr = new ThreadForm(0, 100);
                        thr.Show(this);
                        for (int i = 0; i < 100; i++)
                        {
                            thr.setPos(i);
                            Thread.Sleep(20);
                            //if(i==95)
                            //{
                            //    break;
                            //}
                        }
                        thr.Close();
                        mapControl.ClearLayers();
                        string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanMap + @"\18.沈阳经济区红线融合图.mxd";
                        mapControl.LoadMxFile(path);
                        mapControl.AddShapeFile(DirPath, "Result.shp");
                        mapControl.Refresh();
                        string dbfPath =ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.PlanMap + @"\shp\GHJBNTJZQ（处理后）.dbf";
                        CreatResultPie(dbfPath);
                        RichEditControl rec = new RichEditControl();
                        rec.Refresh();
                        XtraTabPage xtp = new XtraTabPage();
                        xtp.Refresh();
                        this.xtraTabControl_Main.Refresh();
                        this.Refresh();
                    }
                    DrawPolygon = false;
                    //startIntersect = true;
                }
            }
        }
        #endregion 
        #endregion

        #region 专题图
        //地图打开事件
        private void bOpenRedLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxMapControl mapControl = new AxMapControl();
            mapControl.BeginInit();     //必须有begin和end
            mapControl.Location = new System.Drawing.Point(0, 0);
            mapControl.Name = "mapControl1";
            mapControl.Dock = DockStyle.Fill;
            mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
            //MapControl不支持先声明，后设置，故而直接设置

            XtraTabPage xtp = new XtraTabPage();
            xtp.Text = "基本红线示意图";
            //resourses路径获取
            Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
            xtp.Image = image;
            xtp.Controls.Add(mapControl);
            this.xtraTabControl_Main.TabPages.Add(xtp);
            this.xtraTabControl_Main.SelectedTabPage = xtp;
            mapControl.EndInit();       //必须有begin和end

            mapControl.Refresh();
            xtp.Refresh();
            this.xtraTabControl_Main.Refresh();
            this.Refresh();
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.RedLineMap;
            mapControl.LoadMxFile(path);
            mapControl.ActiveView.Refresh();
            AlreadyAddMap = true;
        }

        //清除分析事件
        private void bClearAnalysis_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxMapControl mapControl = new AxMapControl();
            mapControl = curAxMapControl;
            mapControl.ClearLayers();
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.RedLineMap;
            mapControl.LoadMxFile(path);
            mapControl.Refresh();
        }

        #endregion

        #region //专题图分析事件
        private void ribbonGallery_MapAnalysis_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            string itemCaption = e.Item.Caption;
            switch (itemCaption)
            {
                case "交通网络密度":
                    TranspNetDensity();
                    break;
                case "电力网络密度":
                    ElecNetDensity();
                    break;
                case "综合灾害风险":
                    IntDisasterRisk();
                    break;
                case "生态服务价值":
                    EcoServiceValue();
                    break;
                case "水文分析":
                    HydroAnalysis();
                    break;
                case "洪涝损失分析":
                    FloodLoss();
                    break;
                case "GDP重心转移":
                    GDPCenterTransfer();
                    break;

            }
        }

        //交通网络密度图
        private void TranspNetDensity()
        {
            //加载进度条
            ThreadForm thr = new ThreadForm(0, 100);
            thr.Show(this);
            for (int i = 0; i < 100; i++)
            {
                thr.setPos(i);
                Thread.Sleep(40);
            }
            thr.Close();
            //加载结果图
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicTraffic;
            if(AlreadyAddMap)
            {
                curXtraTabPage.Text = "交通网络密度图";
                curAxMapControl.ClearLayers();
                curAxMapControl.LoadMxFile(path);
                curAxMapControl.ActiveView.Refresh();
            }
            else
            {
                AxMapControl mapControl = new AxMapControl();
                mapControl.BeginInit();     //必须有begin和end
                mapControl.Location = new System.Drawing.Point(0, 0);
                mapControl.Name = "mapControl1";
                mapControl.Dock = DockStyle.Fill;
                mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
                //MapControl不支持先声明，后设置，故而直接设置

                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = "交通网络密度图";
                //resourses路径获取
                Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
                xtp.Image = image;
                xtp.Controls.Add(mapControl);
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;
                mapControl.EndInit();       //必须有begin和end

                mapControl.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                mapControl.LoadMxFile(path);
                mapControl.ActiveView.Refresh();
                AlreadyAddMap = true;
            }
            //分析结果文字显示
            //窗体显示唯一
            if (ResFrm == null)
            {
                string Text = "交通网络密度分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
            }
            else
            {
                ResFrm.Close();
                string Text = "交通网络密度分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
                ResFrm.Activate();
            }
        }

        //电力网络密度图
        private void ElecNetDensity()
        {
            //加载进度条
            ThreadForm thr = new ThreadForm(0, 100);
            thr.Show(this);
            for (int i = 0; i < 100; i++)
            {
                thr.setPos(i);
                Thread.Sleep(40);
            }
            thr.Close();
            //加载结果图
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicElectricity;
            if (AlreadyAddMap)
            {
                curXtraTabPage.Text = "电力网络密度图";
                curAxMapControl.ClearLayers();
                curAxMapControl.LoadMxFile(path);
                curAxMapControl.ActiveView.Refresh();
            }
            else
            {
                AxMapControl mapControl = new AxMapControl();
                mapControl.BeginInit();     //必须有begin和end
                mapControl.Location = new System.Drawing.Point(0, 0);
                mapControl.Name = "mapControl1";
                mapControl.Dock = DockStyle.Fill;
                mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
                //MapControl不支持先声明，后设置，故而直接设置

                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = "电力网络密度图";
                //resourses路径获取
                Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
                xtp.Image = image;
                xtp.Controls.Add(mapControl);
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;
                mapControl.EndInit();       //必须有begin和end

                mapControl.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                mapControl.LoadMxFile(path);
                mapControl.ActiveView.Refresh();
                AlreadyAddMap = true;
            }
            //分析结果文字显示
            if (ResFrm == null)
            {
                string Text = "电力网络密度分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
            }
            else
            {
                ResFrm.Close();
                string Text = "电力网络密度分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
                ResFrm.Activate();
            }
        }

        //综合灾害风险图
        private void IntDisasterRisk()
        {
            //加载进度条
            ThreadForm thr = new ThreadForm(0, 100);
            thr.Show(this);
            for (int i = 0; i < 100; i++)
            {
                thr.setPos(i);
                Thread.Sleep(40);
            }
            thr.Close();
            //加载结果图
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicDisaster;
            if (AlreadyAddMap)
            {
                curXtraTabPage.Text = "综合灾害风险图";
                curAxMapControl.ClearLayers();
                curAxMapControl.LoadMxFile(path);
                curAxMapControl.ActiveView.Refresh();
            }
            else
            {
                AxMapControl mapControl = new AxMapControl();
                mapControl.BeginInit();     //必须有begin和end
                mapControl.Location = new System.Drawing.Point(0, 0);
                mapControl.Name = "mapControl1";
                mapControl.Dock = DockStyle.Fill;
                mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
                //MapControl不支持先声明，后设置，故而直接设置

                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = "综合灾害风险图";
                //resourses路径获取
                Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
                xtp.Image = image;
                xtp.Controls.Add(mapControl);
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;
                mapControl.EndInit();       //必须有begin和end

                mapControl.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                mapControl.LoadMxFile(path);
                mapControl.ActiveView.Refresh();
                AlreadyAddMap = true;
            }
            //分析结果文字显示
            if (ResFrm == null)
            {
                string Text = "综合灾害风险分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
            }
            else
            {
                ResFrm.Close();
                string Text = "综合灾害风险分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
                ResFrm.Activate();
            }
        }

        //生态服务价值图
        private void EcoServiceValue()
        {
            //加载进度条
            ThreadForm thr = new ThreadForm(0, 100);
            thr.Show(this);
            for (int i = 0; i < 100; i++)
            {
                thr.setPos(i);
                Thread.Sleep(50);
            }
            thr.Close();
            //加载结果图
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicZoology;
            if (AlreadyAddMap)
            {
                curXtraTabPage.Text = "生态服务价值图";
                curAxMapControl.ClearLayers();
                curAxMapControl.LoadMxFile(path);
                curAxMapControl.ActiveView.Refresh();
            }
            else
            {
                AxMapControl mapControl = new AxMapControl();
                mapControl.BeginInit();     //必须有begin和end
                mapControl.Location = new System.Drawing.Point(0, 0);
                mapControl.Name = "mapControl1";
                mapControl.Dock = DockStyle.Fill;
                mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
                //MapControl不支持先声明，后设置，故而直接设置

                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = "生态服务价值图";
                //resourses路径获取
                Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
                xtp.Image = image;
                xtp.Controls.Add(mapControl);
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;
                mapControl.EndInit();       //必须有begin和end

                mapControl.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                mapControl.LoadMxFile(path);
                mapControl.ActiveView.Refresh();
                AlreadyAddMap = true;
            }
            //分析结果文字显示
            if (ResFrm == null)
            {
                string Text = "生态服务价值分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
            }
            else
            {
                ResFrm.Close();
                string Text = "生态服务价值分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
                ResFrm.Activate();
            }
        }

        //水文分析图
        private void HydroAnalysis()
        {
            //加载进度条
            ThreadForm thr = new ThreadForm(0, 100);
            thr.Show(this);
            for (int i = 0; i < 100; i++)
            {
                thr.setPos(i);
                Thread.Sleep(40);
            }
            thr.Close();
            //加载结果图
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicHydrology;
            if (AlreadyAddMap)
            {
                curXtraTabPage.Text = "水文分析图";
                curAxMapControl.ClearLayers();
                curAxMapControl.LoadMxFile(path);
                curAxMapControl.ActiveView.Refresh();
            }
            else
            {
                AxMapControl mapControl = new AxMapControl();
                mapControl.BeginInit();     //必须有begin和end
                mapControl.Location = new System.Drawing.Point(0, 0);
                mapControl.Name = "mapControl1";
                mapControl.Dock = DockStyle.Fill;
                mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
                //MapControl不支持先声明，后设置，故而直接设置

                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = "水文分析图";
                //resourses路径获取
                Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
                xtp.Image = image;
                xtp.Controls.Add(mapControl);
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;
                mapControl.EndInit();       //必须有begin和end

                mapControl.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                mapControl.LoadMxFile(path);
                mapControl.ActiveView.Refresh();
                AlreadyAddMap = true;
            }
            //分析结果文字显示
            if (ResFrm == null)
            {
                string Text = "水文分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
            }
            else
            {
                ResFrm.Close();
                string Text = "水文分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
                ResFrm.Activate();
            }
        }

        //洪涝损失分析图
        private void FloodLoss()
        {
            //加载进度条
            ThreadForm thr = new ThreadForm(0, 100);
            thr.Show(this);
            for (int i = 0; i < 100; i++)
            {
                thr.setPos(i);
                Thread.Sleep(50);
            }
            thr.Close();
            //加载结果图
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicFlood;
            if (AlreadyAddMap)
            {
                curXtraTabPage.Text = "洪涝损失分析图";
                curAxMapControl.ClearLayers();
                curAxMapControl.LoadMxFile(path);
                curAxMapControl.ActiveView.Refresh();
            }
            else
            {
                AxMapControl mapControl = new AxMapControl();
                mapControl.BeginInit();     //必须有begin和end
                mapControl.Location = new System.Drawing.Point(0, 0);
                mapControl.Name = "mapControl1";
                mapControl.Dock = DockStyle.Fill;
                mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
                //MapControl不支持先声明，后设置，故而直接设置

                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = "洪涝损失分析图";
                //resourses路径获取
                Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
                xtp.Image = image;
                xtp.Controls.Add(mapControl);
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;
                mapControl.EndInit();       //必须有begin和end

                mapControl.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                mapControl.LoadMxFile(path);
                mapControl.ActiveView.Refresh();
                AlreadyAddMap = true;
            }
            //分析结果文字显示
            if (ResFrm == null)
            {
                string Text = "洪涝损失分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
            }
            else
            {
                ResFrm.Close();
                string Text = "洪涝损失分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
                ResFrm.Activate();
            }
        }

        //GDP重心转移图
        private void GDPCenterTransfer()
        {
            //加载进度条
            ThreadForm thr = new ThreadForm(0, 100);
            thr.Show(this);
            for (int i = 0; i < 100; i++)
            {
                thr.setPos(i);
                Thread.Sleep(60);
            }
            thr.Close();
            //加载结果图
            string path = ConnectionCenter.Config.FTPCatalog + ConnectionCenter.Config.ThematicGDPTrans;
            if (AlreadyAddMap)
            {
                curXtraTabPage.Text = "GDP重心转移图";
                curAxMapControl.ClearLayers();
                curAxMapControl.LoadMxFile(path);
                curAxMapControl.ActiveView.Refresh();
            }
            else
            {
                AxMapControl mapControl = new AxMapControl();
                mapControl.BeginInit();     //必须有begin和end
                mapControl.Location = new System.Drawing.Point(0, 0);
                mapControl.Name = "mapControl1";
                mapControl.Dock = DockStyle.Fill;
                mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
                //MapControl不支持先声明，后设置，故而直接设置

                XtraTabPage xtp = new XtraTabPage();
                xtp.Text = "GDP重心转移图";
                //resourses路径获取
                Bitmap image = new Bitmap(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString()) + @"\Resources\Globe-16.jpg");
                xtp.Image = image;
                xtp.Controls.Add(mapControl);
                this.xtraTabControl_Main.TabPages.Add(xtp);
                this.xtraTabControl_Main.SelectedTabPage = xtp;
                mapControl.EndInit();       //必须有begin和end

                mapControl.Refresh();
                xtp.Refresh();
                this.xtraTabControl_Main.Refresh();
                this.Refresh();
                mapControl.LoadMxFile(path);
                mapControl.ActiveView.Refresh();
                AlreadyAddMap = true;
            }
            //分析结果文字显示
            if (ResFrm == null)
            {
                string Text = "GDP重心转移分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
            }
            else
            {
                ResFrm.Close();
                string Text = "GDP重心转移分析结果如下：";
                ResFrm = new ResultShowForm(Text);
                ResFrm.Left = 250;
                ResFrm.Top = 200;
                ResFrm.Show();
                ResFrm.Activate();
            }
        }
        #endregion




    }
}