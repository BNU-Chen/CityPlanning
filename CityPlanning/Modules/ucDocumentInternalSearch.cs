using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace CityPlanning.Modules
{
    public partial class ucDocumentInternalSearch : UserControl
    {
        private string keyWord; //搜索关键字
        private Document searchDocument;   //检索文档
        private RichEditControl richEditControl;  //关联RichEditControl空间
        private bool imageFlag; //btn_Search按钮背景图片

        public RichEditControl RichEditControl
        {
            set { richEditControl = value; 
                this.searchDocument = richEditControl.Document; }
            get { return richEditControl; }
        }

        public ucDocumentInternalSearch()
        {
            InitializeComponent();
        }

        //构造函数
        public ucDocumentInternalSearch(RichEditControl richEditControl)
        {
            InitializeComponent();
            this.richEditControl = richEditControl;
            this.searchDocument = this.richEditControl.Document;
            this.imageFlag = true;
        }

        //搜索按钮单击事件
        private void btn_Search_Click(object sender, EventArgs e)
        {
            //控件状态恢复
            flowLayoutPanel.Controls.Clear();
            DocumentCharacterPropertiesReset();
            if (!imageFlag) te_KeyWord.Text = "";
        }

        //关键词搜索
        private void KeyWordSearch()
        {
            keyWord = this.te_KeyWord.Text.Trim();
            if (keyWord != "" && searchDocument != null)
            {
                //搜索参数设置
                SearchOptions sOptions = SearchOptions.None;
                SearchDirection sDirection = SearchDirection.Forward;
                DocumentRange sRange = searchDocument.Range;
                //开始搜索
                ISearchResult _SearchResult = searchDocument.StartSearch(keyWord, sOptions, sDirection, sRange);
                bool findNext = _SearchResult.FindNext();
                if (_SearchResult.CurrentResult == null) return;
                Paragraph par_temp = searchDocument.GetParagraph(_SearchResult.CurrentResult.Start);
                Paragraph par_Cur = searchDocument.GetParagraph(_SearchResult.CurrentResult.Start);
                while (findNext)
                {
                    CharacterProperties cp = searchDocument.BeginUpdateCharacters(_SearchResult.CurrentResult);
                    cp.ForeColor = Color.Red;          //字体颜色
                    cp.BackColor = Color.Yellow;       //背景色
                    searchDocument.EndUpdateCharacters(cp);
                    Paragraph par_Next = searchDocument.GetParagraph(_SearchResult.CurrentResult.Start);

                    if (!par_Cur.Equals(par_Next))
                    {
                        AddRichTextBoxToFlowLayoutPanal(par_Cur);
                        par_Cur = par_Next;
                    }
                    findNext = _SearchResult.FindNext();
                }
                MoveToParagraph(par_temp);
            }
        }

        //搜索栏Enter键事件
        private void TextEdit_Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //控件状态恢复
                flowLayoutPanel.Controls.Clear();
                DocumentCharacterPropertiesReset();
                KeyWordSearch();
            } 
        }

        //文档颜色恢复，从搜索状态
        private void DocumentCharacterPropertiesReset()
        {
            CharacterProperties cp = searchDocument.BeginUpdateCharacters(searchDocument.Range);
            cp.ForeColor = Color.Black;          //字体颜色
            cp.BackColor = Color.White;       //背景色
            searchDocument.EndUpdateCharacters(cp);
        }

        //添加ReadOnlyRichTextBox控件至flowLayoutPanel1
        private bool AddRichTextBoxToFlowLayoutPanal( Paragraph paragraph )
        {
            try
            {
                ReadOnlyRichTextBox roRTB = new ReadOnlyRichTextBox();
                roRTB.MouseDoubleClick += new MouseEventHandler(this.flowLayoutPanel_MouseDoubleClick);
                roRTB.Width = flowLayoutPanel.Width - 25;
                roRTB.Paragraph = paragraph;
                string par_String = searchDocument.GetRtfText(paragraph.Range);
                roRTB.Rtf = par_String;
                string par_Text = roRTB.Text;
                roRTB.Clear();
                roRTB.Text = par_Text;
                flowLayoutPanel.Controls.Add(roRTB);
                int startPosition = 0;
                while (par_Text.IndexOf(keyWord, startPosition) >= 0)
                {
                    int curPosition = par_Text.IndexOf(keyWord, startPosition);
                    roRTB.Select(curPosition, keyWord.Length);
                    roRTB.SelectionColor = Color.Red;
                    startPosition = curPosition + keyWord.Length;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //鼠标双击事件，文档位置响应
        private void flowLayoutPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ReadOnlyRichTextBox roRTBControl = (ReadOnlyRichTextBox)sender;
                if (roRTBControl != null)
                {
                    MoveToParagraph(roRTBControl.Paragraph);
                }
            }
            catch { }
        }

        //文档显示位置滚动至指定段落
        private void MoveToParagraph(Paragraph paragraph)
        {
            searchDocument.Selection = searchDocument.CreateRange(paragraph.Range.Start, 0);
            richEditControl.ScrollToCaret();
            searchDocument.Selection = searchDocument.CreateRange(paragraph.Range.End, 0);
            richEditControl.ScrollToCaret();
            searchDocument.Selection = paragraph.Range;
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
        }

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

        protected override void OnContentsResized(ContentsResizedEventArgs e)
        {
            this.Height = e.NewRectangle.Height + 10;
            base.OnContentsResized(e);
        }
    }
}
