namespace CityPlanning.Modules
{
    partial class ucNavigationFiles
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.TextEdit_Filter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TreeListFiles = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Filter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.TextEdit_Filter);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(246, 38);
            this.panelControl1.TabIndex = 5;
            // 
            // TextEdit_Filter
            // 
            this.TextEdit_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextEdit_Filter.Location = new System.Drawing.Point(35, 9);
            this.TextEdit_Filter.Name = "TextEdit_Filter";
            this.TextEdit_Filter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextEdit_Filter.Properties.Appearance.Options.UseFont = true;
            this.TextEdit_Filter.Size = new System.Drawing.Size(206, 24);
            this.TextEdit_Filter.TabIndex = 4;
            this.TextEdit_Filter.EditValueChanged += new System.EventHandler(this.textEdit_Filter_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(5, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "搜索";
            // 
            // TreeListFiles
            // 
            this.TreeListFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeListFiles.Location = new System.Drawing.Point(0, 39);
            this.TreeListFiles.Name = "TreeListFiles";
            this.TreeListFiles.OptionsBehavior.Editable = false;
            this.TreeListFiles.OptionsBehavior.EnableFiltering = true;
            this.TreeListFiles.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.TreeListFiles.OptionsView.ShowAutoFilterRow = true;
            this.TreeListFiles.OptionsView.ShowColumns = false;
            this.TreeListFiles.OptionsView.ShowHorzLines = false;
            this.TreeListFiles.OptionsView.ShowIndicator = false;
            this.TreeListFiles.OptionsView.ShowVertLines = false;
            this.TreeListFiles.RowHeight = 25;
            this.TreeListFiles.Size = new System.Drawing.Size(246, 482);
            this.TreeListFiles.TabIndex = 6;
            this.TreeListFiles.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.TreeListFiles.ColumnFilterChanged += new System.EventHandler(this.treeList1_ColumnFilterChanged);
            // 
            // ucNavigationFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreeListFiles);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucNavigationFiles";
            this.Size = new System.Drawing.Size(246, 521);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Filter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit TextEdit_Filter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList TreeListFiles;
    }
}
