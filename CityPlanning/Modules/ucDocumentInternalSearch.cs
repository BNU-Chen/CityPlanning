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

using DevExpress.XtraTab;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace CityPlanning.Modules
{
    public partial class ucDocumentInternalSearch : UserControl
    {
        private XtraTabPage xtraTabPage;
        private bool imageFlag; //btn_Search按钮背景图片
        private List<string> documentPathCollection = new List<string>();
        private List<DocumentRange> documentRangeCollection = new List<DocumentRange>();
        private List<Paragraph> paragraphCollection = new List<Paragraph>();
        private List<ReadOnlyRichTextBox> readOnlyRichTextBoxCollection = new List<ReadOnlyRichTextBox>();
        private List<RichTextBox> roRichTextBoxCollection = new List<RichTextBox>();
        private bool multiDocumentSearch = false;

        public XtraTabPage XtraTabPage
        {
            set { xtraTabPage = value; }
            get { return xtraTabPage; }
        }

        public List<string> DocumentPathCollection
        {
            set { documentPathCollection = value; }
            get { return documentPathCollection; }
        }

        #region //构造函数
        public ucDocumentInternalSearch()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(flowLayoutPanel1_MouseWheel);
            this.xtraTabPage = new XtraTabPage();
            RichEditControl richEditControl = new RichEditControl();
            richEditControl.Dock = DockStyle.Fill;
            this.xtraTabPage.Controls.Add(richEditControl);
            this.imageFlag = true;
        }

        //构造函数
        public ucDocumentInternalSearch(XtraTabPage xtraTabPage)
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(flowLayoutPanel1_MouseWheel);
            Control control = this.xtraTabPage.Controls[0];
            if (control is RichEditControl) this.xtraTabPage = xtraTabPage;
            this.imageFlag = true;
        }
        #endregion

        #region //控件响应事件
        //搜索按钮单击事件
        private void btn_Search_Click(object sender, EventArgs e)
        {
            //控件状态恢复
            this.setInitializationSearchResult();
            this.SearchResultInfoChange();
            if (!imageFlag) te_KeyWord.Text = "";
        }

        //搜索栏Enter键事件
        private void TextEdit_Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //控件状态恢复
                this.setInitializationSearchResult();
                this.KeyWordSearch();
            }
        }

        //鼠标单击事件，文档位置响应
        private void flowLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                ReadOnlyRichTextBox roRTBControl = (ReadOnlyRichTextBox)sender;
                if (roRTBControl != null)
                {
                    if (this.multiDocumentSearch)
                    {
                        this.multiDocumentSearch = false;
                        this.cbe_SearchRange.SelectedIndex = -1;
                        this.SearchFromDocument(this.te_KeyWord.Text.Trim(), roRTBControl.Tag.ToString(), this.xtraTabPage);
                    }
                    else
                        MoveToParagraph(roRTBControl.Paragraph);
                }
            }
            catch { }
        }

        //鼠标滚轮事件
        private void flowLayoutPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                this.flowLayoutPanel.Focus();
            }
            catch
            { }
        }

        //关键词控件文本值变更事件
        private void te_KeyWord_EditValueChanged(object sender, EventArgs e)
        {
            if (te_KeyWord.Text == "")
            {
                btn_Search.BackgroundImage = global::CityPlanning.Properties.Resources.search_16;
                imageFlag = true;
            }
            else
            {
                btn_Search.BackgroundImage = global::CityPlanning.Properties.Resources.delete_16;
                imageFlag = false;
            }
        }

        //搜索范围变更事件
        private void cbe_SearchRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                setInitializationSearchResult();
                int selectedIndex = this.cbe_SearchRange.SelectedIndex;
                List<string> documentPaths = new List<string>();
                switch (selectedIndex)
                {
                    case 0:
                        this.multiDocumentSearch = false;
                        this.SearchFromDocument(this.te_KeyWord.Text.Trim(), this.documentPathCollection[0], this.xtraTabPage);
                        break;
                    case 1:
                        this.multiDocumentSearch = false;
                        this.SearchFromDocument(this.te_KeyWord.Text.Trim(), this.documentPathCollection[1], this.xtraTabPage);
                        break;
                    case 2:
                        this.multiDocumentSearch = true;
                        documentPaths = this.documentPathCollection.GetRange(2, 8);
                        this.SearchFromDocuments(this.te_KeyWord.Text.Trim(), documentPaths, this.xtraTabPage);
                        break;
                    case 3:
                        this.multiDocumentSearch = true;
                        documentPaths = this.documentPathCollection.GetRange(0, 10);
                        this.SearchFromDocuments(this.te_KeyWord.Text.Trim(), documentPaths, this.xtraTabPage);
                        break;
                    default:
                        this.multiDocumentSearch = false;
                        //this.SearchFromDocument(this.te_KeyWord.Text.Trim(), this.documentPathCollection[0], this.xtraTabPage);
                        break;
                }

                this.xtraTabPage.Refresh();
            }
            catch { }
        }
        #endregion

        #region //搜索相关函数
        //关键词搜索
        private bool KeyWordSearch()
        {
            try
            {
                this.documentRangeCollection = this.getDocumentRangeCollectionByKeyWord(this.te_KeyWord.Text.Trim(), this.getRichEditControl().Document);
                this.paragraphCollection = this.getParagraphCollectionByDocumentRangeCollection(this.documentRangeCollection, this.getRichEditControl().Document);
                this.readOnlyRichTextBoxCollection = this.getReadOnlyRichTextBoxCollectionByParagrapheCollection(this.te_KeyWord.Text.Trim(), this.paragraphCollection, this.getRichEditControl().Document);
                this.AddRichTextBoxToFlowLayoutPanal(this.readOnlyRichTextBoxCollection);
                if (this.documentRangeCollection.Count != 0) 
                {
                    this.MoveToParagraph(this.paragraphCollection[0]);
                    this.DocumentKeyWordHighlightSet();
                }
                this.SearchResultInfoChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //根据关键字返回关键字在文档中的位置集合
        private List<DocumentRange> getDocumentRangeCollectionByKeyWord(string keyWord, Document searchDocument)
        {
            List<DocumentRange> documentRangeCollection = new List<DocumentRange>();
            try
            {
                if (keyWord != "" && searchDocument != null)
                {
                    //搜索参数设置
                    SearchOptions sOptions = SearchOptions.None;
                    SearchDirection sDirection = SearchDirection.Forward;
                    DocumentRange sRange = searchDocument.Range;
                    //开始搜索
                    ISearchResult _SearchResult = searchDocument.StartSearch(keyWord, sOptions, sDirection, sRange);
                    this.documentRangeCollection.Clear();
                    while (_SearchResult.FindNext()) documentRangeCollection.Add(_SearchResult.CurrentResult);
                }
                return documentRangeCollection;
            }
            catch
            {
                return documentRangeCollection;
            }
        }

        //根据关键字位置集合返回所在段落集合
        private List<Paragraph> getParagraphCollectionByDocumentRangeCollection(List<DocumentRange> documentRangeCollection, Document searchDocument)
        {
            List<Paragraph> paragraphCollection = new List<Paragraph>();
            if (documentRangeCollection.Count != 0)
            {
                Paragraph par_Cur = searchDocument.GetParagraph(documentRangeCollection[0].Start);
                for (int i = 1; i < documentRangeCollection.Count; i++)
                {
                    Paragraph par_Next = searchDocument.GetParagraph(documentRangeCollection[i].Start);
                    if (!par_Cur.Equals(par_Next))
                    {
                        paragraphCollection.Add(par_Cur);
                        par_Cur = par_Next;
                    }
                }
            }
            return paragraphCollection;
        }

        //根据段落集合生成ReadOnlyRichTextBox控件集合
        private List<ReadOnlyRichTextBox> getReadOnlyRichTextBoxCollectionByParagrapheCollection(string keyWord, List<Paragraph> paragraphCollection, Document searchDocument)
        {
            List<ReadOnlyRichTextBox> readOnlyRichTextBoxCollection = new List<ReadOnlyRichTextBox>();
            if (paragraphCollection.Count != 0 && searchDocument != null)
            {
                for (int i = 0; i < paragraphCollection.Count; i++)
                {
                    ReadOnlyRichTextBox roRTB = new ReadOnlyRichTextBox();

                    roRTB.MouseClick += new MouseEventHandler(this.flowLayoutPanel_MouseClick);
                    roRTB.MouseWheel += new MouseEventHandler(flowLayoutPanel1_MouseWheel);
                    roRTB.Width = this.flowLayoutPanel.Width - 25;
                    Paragraph paragraph = paragraphCollection[i];
                    roRTB.Paragraph = paragraph;
                    string par_Text = searchDocument.GetText(paragraph.Range);
                    int startPosition = 0;
                    while (par_Text.IndexOf(keyWord, startPosition) >= 0)
                    {
                        int curPosition = par_Text.IndexOf(keyWord, startPosition);
                        roRTB.Select(curPosition, keyWord.Length);
                        roRTB.SelectionColor = Color.Red;
                        startPosition = curPosition + keyWord.Length;
                    }
                    roRTB.Text = par_Text + "\n\n" + this.xtraTabPage.Text;
                    readOnlyRichTextBoxCollection.Add(roRTB);
                }
            }
            return readOnlyRichTextBoxCollection;
        }

        //添加ReadOnlyRichTextBox控件至flowLayoutPanel
        private void AddRichTextBoxToFlowLayoutPanal(List<ReadOnlyRichTextBox> readOnlyRichTextBoxCollection)
        {
            foreach (ReadOnlyRichTextBox readOnlyRichTextBox in readOnlyRichTextBoxCollection)
                this.flowLayoutPanel.Controls.Add(readOnlyRichTextBox);
            this.flowLayoutPanel.Refresh();
        }

        //根据文档搜索结果生成ReadOnlyRichTextBox控件
        private ReadOnlyRichTextBox getReadOnlyRichTextBoxOfMultiDocumentSearch(string filePath, int resultCount)
        {
            ReadOnlyRichTextBox roRTB = new ReadOnlyRichTextBox();
            roRTB.MouseClick += new MouseEventHandler(this.flowLayoutPanel_MouseClick);
            roRTB.MouseWheel += new MouseEventHandler(flowLayoutPanel1_MouseWheel);
            roRTB.Width = this.flowLayoutPanel.Width - 25;
            roRTB.Text = Path.GetFileNameWithoutExtension(filePath) + "\n共搜索到关键字：" + resultCount.ToString() + "处";
            roRTB.Tag = filePath;
            return roRTB;
        }
        #endregion

        #region //显示相关函数
        //文档中关键字高亮显示
        private void DocumentKeyWordHighlightSet()
        {
            Document searchDocument = this.getSearchDocument();
            foreach (DocumentRange documentRange in this.documentRangeCollection)
            {
                CharacterProperties cp = searchDocument.BeginUpdateCharacters(documentRange);
                cp.ForeColor = Color.Red;          //字体颜色
                cp.BackColor = Color.Yellow;       //背景色
                searchDocument.EndUpdateCharacters(cp);
            }
        }

        //文档颜色恢复
        private void DocumentCharacterPropertiesReset()
        {
            try
            {
                Document searchDocument = this.getSearchDocument();
                if (searchDocument != null)
                {
                    CharacterProperties cp = searchDocument.BeginUpdateCharacters(searchDocument.Range);
                    cp.ForeColor = Color.Black;  //字体颜色
                    cp.BackColor = Color.White;  //背景色
                    searchDocument.EndUpdateCharacters(cp);
                }
            }
            catch { }
        }

        //文档显示位置滚动至指定段落
        private void MoveToParagraph(Paragraph paragraph)
        {
            RichEditControl richEditControl = this.getRichEditControl();
            Document searchDocument = this.getSearchDocument();
            if (searchDocument != null)
            {
                searchDocument.Selection = searchDocument.CreateRange(paragraph.Range.Start, 0);
                richEditControl.ScrollToCaret();
                searchDocument.Selection = searchDocument.CreateRange(paragraph.Range.End, 0);
                richEditControl.ScrollToCaret();
                searchDocument.Selection = paragraph.Range;
            }
        }

        //搜索结果提示信息变更
        private void SearchResultInfoChange()
        {
            if (this.documentRangeCollection.Count == 0)
                this.lblSearchResultInfo.Text = "搜索结果：";
            else
                this.lblSearchResultInfo.Text = "搜索结果：" + this.documentRangeCollection.Count + "个";
        }
        #endregion

        #region //辅助函数
        //获取当前搜索文档
        private Document getSearchDocument()
        {
            try
            {
                RichEditControl richEditControl = this.getRichEditControl();
                if (richEditControl == null) return null;
                Document searchDocument = richEditControl.Document;
                return searchDocument;
            }
            catch
            {
                return null;
            }
        }

        //自XtraTabPage获取RichEditControl
        private RichEditControl getRichEditControl()
        {
            try
            {
                Control control = this.xtraTabPage.Controls[0];
                if (control is RichEditControl)
                {
                    RichEditControl richEditControl = (RichEditControl)control;
                    return richEditControl;
                }
                else return null;
            }
            catch
            {
                return null;
            }
        }

        //根据文件后缀按相应方式打开文件
        private bool OpenDocumentFile(string documentPath, RichEditControl richEditControl)
        {
            if (!File.Exists(documentPath)) return false;
            string extName = Path.GetExtension(documentPath); //记录文件扩展名
            DocumentFormat documentFormat;  //打开方式

            switch (extName)
            {
                case ".doc":
                    documentFormat = DocumentFormat.Doc;
                    break;
                case ".docx":
                    documentFormat = DocumentFormat.OpenXml;
                    break;
                case ".epub":
                    documentFormat = DocumentFormat.ePub;
                    break;
                case ".html":
                    documentFormat = DocumentFormat.Html;
                    break;
                case ".mht":
                    documentFormat = DocumentFormat.Mht;
                    break;
                case ".odt":
                    documentFormat = DocumentFormat.OpenDocument;
                    break;
                case ".txt":
                    documentFormat = DocumentFormat.PlainText;
                    break;
                case ".rtf":
                    documentFormat = DocumentFormat.Rtf;
                    break;
                case ".xml":
                    documentFormat = DocumentFormat.WordML;
                    break;
                default:
                    documentFormat = DocumentFormat.Undefined;
                    break;
            }
            try
            {
                richEditControl.LoadDocument(documentPath, documentFormat);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        //初始化搜索结果变量
        public void setInitializationSearchResult()
        {
            this.documentRangeCollection = new List<DocumentRange>();
            this.paragraphCollection = new List<Paragraph>();
            this.flowLayoutPanel.Controls.Clear();
            this.SearchResultInfoChange();
            DocumentCharacterPropertiesReset();
        }
        #endregion

        #region //公共函数，外部调用
        //根据关键字及文档路径搜索，外部调用方法
        public bool SearchFromDocument(string keyWord, string documentPath, XtraTabPage xtraTabPage)
        {
            try
            {
                this.xtraTabPage = xtraTabPage;
                this.xtraTabPage.Controls.Clear();
                this.xtraTabPage.Text = Path.GetFileName(documentPath);
                RichEditControl richEditControl = new RichEditControl();
                richEditControl.Dock = DockStyle.Fill;
                this.xtraTabPage.Controls.Add(richEditControl);
                if (!OpenDocumentFile(documentPath, richEditControl) || keyWord == "") return false;
                this.te_KeyWord.Text = keyWord;
                this.Refresh();
                this.setInitializationSearchResult();
                if (this.KeyWordSearch())
                {
                    this.SearchResultInfoChange();
                    this.xtraTabPage.Refresh();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
        //根据关键字及文档路径搜索，外部调用方法
        public bool SearchFromDocuments(string keyWord, List<string> documentPaths, XtraTabPage xtraTabPage)
        {
            try
            {
                if (keyWord == "") return false;
                this.te_KeyWord.Text = keyWord;
                this.xtraTabPage = xtraTabPage;
                this.xtraTabPage.Controls.Clear();
                this.xtraTabPage.Text = "";
                this.xtraTabPage.Refresh();
                foreach (string documentPath in documentPaths)
                {
                    RichEditControl richEditControl = new RichEditControl();
                    if (OpenDocumentFile(documentPath, richEditControl))
                    {
                        string text = richEditControl.Document.GetText(richEditControl.Document.Range);
                        if (text == null) continue;
                        richEditControl.Dispose();
                        int searchPosetion = 0;
                        int keyWordCount = 0;
                        int curKeyWordPosetion = text.IndexOf(keyWord, searchPosetion);
                        while (curKeyWordPosetion != -1)
                        {
                            keyWordCount += 1;
                            searchPosetion = curKeyWordPosetion + keyWord.Length;
                            curKeyWordPosetion = text.IndexOf(keyWord, searchPosetion);
                        }
                        ReadOnlyRichTextBox roRTB = this.getReadOnlyRichTextBoxOfMultiDocumentSearch(documentPath, keyWordCount);
                        this.flowLayoutPanel.Controls.Add(roRTB);
                    }
                    this.flowLayoutPanel.Refresh();
                }
                this.multiDocumentSearch = true;
                //控件状态恢复
                this.Refresh();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    /// <summary>
    /// 自定义控件：完全用户只读的RichTextBox
    /// </summary>
    public class ReadOnlyRichTextBox : RichTextBox  //  完全用户只读的RichTextBox
    {
        private const int WM_SETFOCUS = 0x7;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private Paragraph paragraph;

        public Paragraph Paragraph
        {
            set { paragraph = value; }
            get { return paragraph; }
        }

        /// <summary>
        /// 构造函数：设置指针样式
        /// </summary>
        public ReadOnlyRichTextBox()    // 构造函数：设置指针样式
        {
            this.Cursor = Cursors.Arrow;    //设置鼠标样式   
            this.ScrollBars = RichTextBoxScrollBars.None;
            this.ReadOnly = true;
        }
        /*
        /// <summary>
        /// 屏蔽控件所有鼠标消息的发送
        /// </summary>
        /// <param name="m">消息</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS
                || m.Msg == WM_KEYDOWN
                || m.Msg == WM_KEYUP
                //|| m.Msg == WM_LBUTTONDOWN
                //|| m.Msg == WM_LBUTTONUP
                //|| m.Msg == WM_LBUTTONDBLCLK
                || m.Msg == WM_RBUTTONDOWN
                || m.Msg == WM_RBUTTONUP
                || m.Msg == WM_RBUTTONDBLCLK
                )
            {
                return;
            }
            base.WndProc(ref m);
        }
        */
        protected override void OnContentsResized(ContentsResizedEventArgs e)
        {
            this.Height = e.NewRectangle.Height + 10;
            base.OnContentsResized(e);
        }
    }
}
