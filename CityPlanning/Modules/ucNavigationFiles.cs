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

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
//using DevExpress.Data.Filtering;

namespace CityPlanning.Modules
{    
    public partial class ucNavigationFiles : UserControl
    {
        private TreeListNode curNode = null;
        public MainForm frmMain = null;
        public string  SourceFolder = "";

        public ucNavigationFiles()
        {
            InitializeComponent();
            //Init();
        }

        //private void Init()
        //{            
        //    //this.TreeList.OptionsBehavior.EnableFiltering = true;
        //    //TreeList.OptionsFilter.FilterMode = FilterMode.Smart;

        //}

        public DevExpress.XtraTreeList.TreeList TreeList
        {
            get { return this.TreeListFiles; }
            //set { this.treeList1 = value; }
        }

        //创建过滤器
        private void textEdit_Filter_EditValueChanged(object sender, EventArgs e)
        {
            TreeListFiles.FilterNodes();
        }

        private void TreeListFiles_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList tree = (TreeList)sender;
            Point pt = tree.PointToClient(Control.MousePosition);
            
            TreeListHitInfo hi = tree.CalcHitInfo(pt);
            if (hi.Node == null)
            {
                return;
            }
            curNode = hi.Node;            

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(Control.MousePosition);               
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string curpath = (string)curNode["path"];
            switch (e.ClickedItem.Name.ToLower())
            {
                case "tsmi_addfiles":
                    AddFiles();
                    break;
                case "tsmi_deletefile":
                    DialogResult dr = MessageBox.Show("确定删除么？", "提示",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        File.Delete(curpath);
                        FetchFiles();
                    }
                    else
                    {
                        return;
                    }
                    break;
                case "tsmi_defaultopenfile":
                    System.Diagnostics.Process.Start(curpath);
                    break;
            }
        }

        private void AddFiles()
        {
            string nodePath = (string)curNode["path"];
            string nodeType = (string)curNode["type"];
            string destFolder = "";
            if (nodeType.ToLower() == "file")
            {
                if (File.Exists(nodePath))
                {
                    destFolder = Path.GetDirectoryName(nodePath);
                }
                else
                {
                    return;
                }
            }
            else if (nodeType.ToLower() == "folder")
            {
                if (Directory.Exists(nodePath))
                {
                    destFolder = nodePath;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择要导入的文件";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ofd.Filter = "*.*所有文件格式|*.*";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] paths = ofd.FileNames;
                string path = "";
                for (int i = 0; i < paths.Length; i++)
                {
                    path = paths[i];
                    string filename = Path.GetFileName(path);
                    string destPath = Path.Combine(destFolder, filename);
                    File.Copy(path, destPath, true);
                }
                FetchFiles();
                //MessageBox.Show(path);
            }
        }

        public void FetchFiles()
        {
            //SourceFolder

            string path = SourceFolder;
            DataTable dt = ConnectionCenter.ConnLocalDisk.getDataTable(path);
            if (dt == null)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }
            TreeListFiles.KeyFieldName = "id";
            TreeListFiles.ParentFieldName = "pid";
            TreeListFiles.DataSource = dt;

            //按名称排序
            TreeListFiles.BeginSort();
            TreeListFiles.Columns["type"].SortOrder = SortOrder.Descending;
            TreeListFiles.Columns["name"].SortOrder = SortOrder.Ascending;
            TreeListFiles.EndSort();

            //隐藏除"name"的列
            for (int i = 0; i < TreeListFiles.Columns.Count; i++)
            {
                if (TreeListFiles.Columns[i].FieldName != "name")
                {
                    TreeListFiles.Columns[i].Visible = false;
                }
            }
            if (dt.Rows.Count < 100)
            {
                this.TreeListFiles.ExpandAll();
            }
        }

        private void TreeListFiles_FilterNode(object sender, FilterNodeEventArgs e)
        {
            string filterText = this.TextEdit_Filter.Text.Trim();
            if (filterText == "")
            {
                return;
            }
            string NodeText = e.Node.GetDisplayText("name");
            if (NodeText == "")
            {
                return;
            }
            bool IsVisible = NodeText.ToUpper().IndexOf(filterText.ToUpper()) >= 0;
            if (IsVisible)
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode Node = e.Node.ParentNode;
                while (Node != null)
                {
                    if (!Node.Visible)
                    {
                        Node.Visible = true;
                        Node = Node.ParentNode;
                    }
                    else
                        break;
                }

            }
            e.Node.Visible = IsVisible;
            e.Handled = true;            
        }
    }
}
