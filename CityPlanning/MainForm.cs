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

using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using DevExpress.XtraRichEdit;
//using DevExpress.Docs;          //Worksheet专用

using ESRI.ArcGIS.Controls;


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
        
        //自定义类声明

        //模块定义
        public Modules.ucNavigationRDB ucNaviRDB = new Modules.ucNavigationRDB();
        public Modules.ucNavigationFiles ucNaviFiles = new Modules.ucNavigationFiles();

        #endregion

        #region //初始化函数
        public MainForm()
        {
            InitializeComponent();
            InitComponent();
            //InitSkinGallery();
        }
        //窗体初始化函数
        private void MainForm_Load(object sender, EventArgs e)
        {
            //启动界面
            frmStartConnectionConfig fscc = new frmStartConnectionConfig(this);
            fscc.ShowDialog();
        }

        //初始化连接,由初始化界面调用
        public void InitConnection()
        {
            
        }

        //初始化控件
        private void InitComponent()
        {
            ucNaviFiles.Dock = DockStyle.Fill;
            ucNaviRDB.Dock = DockStyle.Fill;

            this.ucNaviRDB.TreeList.DoubleClick += ucNaviRDB_TreeList_DoubleClick;
            this.ucNaviFiles.TreeList.DoubleClick += ucNaviFiles_TreeList_DoubleClick;

        }
        void InitSkinGallery()
        {
            //SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        #endregion

        #region //关于
        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void iHelp_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region //主页Ribbon按钮事件
        //连接配置
        private void bConnectConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //启动界面
            frmStartConnectionConfig fscc = new frmStartConnectionConfig(null);
            fscc.ShowDialog();
        }
        
        //空间数据库
        private void bGalleryGeodatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
        //关系数据库
        private void bGalleryRelationalDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();
            this.panelControl_Navigation.Controls.Add(ucNaviRDB);

            DataTable dt = SQLServerConnection.GetDatabaseSchema();
            if (dt == null)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }
            this.ucNaviRDB.TreeList.KeyFieldName = "id";     //主要显示内容
            this.ucNaviRDB.TreeList.ParentFieldName = "TABLE_CATALOG";     //目录
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
        //文档
        private void bGalleryDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.panelControl_Navigation.Controls.Clear();            
            this.panelControl_Navigation.Controls.Add(ucNaviFiles);
            string path = FTPConnection.FtpIP;
            DataTable dt = ConnectionCenter.ConnLocalDisk.getDataTable(path);
            if (dt == null)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }
            ucNaviFiles.TreeList.KeyFieldName = "id";
            ucNaviFiles.TreeList.ParentFieldName = "pid";
            ucNaviFiles.TreeList.DataSource = dt;

            //按名称排序
            ucNaviFiles.TreeList.BeginSort();
            ucNaviFiles.TreeList.Columns["type"].SortOrder = SortOrder.Descending;
            ucNaviFiles.TreeList.Columns["name"].SortOrder = SortOrder.Ascending;
            ucNaviFiles.TreeList.EndSort();

            //隐藏除"name"的列
            for (int i = 0; i < ucNaviFiles.TreeList.Columns.Count; i++)
            {
                if (ucNaviFiles.TreeList.Columns[i].FieldName != "name")
                {
                    ucNaviFiles.TreeList.Columns[i].Visible = false;
                }
            }
        }
        //三维地图
        private void bGallery3DMap_ItemClick(object sender, ItemClickEventArgs e)
        {

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
                    //TabPage
                    XtraTabPage xtp = new XtraTabPage();                    
                    xtp.Text = nodeName;
                    xtp.Controls.Add(ssc);
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
                string extension = (string)hi.Node["ext"];
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
                        mapControl.Name = "mapControl";
                        mapControl.Dock = DockStyle.Fill;
                        //MapControl不支持先声明，后设置，故而直接设置
                        XtraTabPage xtp = new XtraTabPage();
                        xtp.Text = nodeName;
                        xtp.Controls.Add(mapControl);
                        mapControl.Dock = DockStyle.Fill;
                        this.xtraTabControl_Main.TabPages.Add(xtp);
                        this.xtraTabControl_Main.SelectedTabPage = xtp;
                        mapControl.EndInit();       //必须有begin和end

                        mapControl.Refresh();
                        xtp.Refresh();
                        this.xtraTabControl_Main.Refresh();
                        this.Refresh();

                        mapControl.LoadMxFile(path);
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
        #endregion

        #region //主显示区事件
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
        //TabPage切换函数
        private void ShowSpecificsRibbonPage(Control _control)
        {
            
        }
        #endregion
        
        #region //地图工具按钮事件
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

        }
        #endregion
        
    }
}