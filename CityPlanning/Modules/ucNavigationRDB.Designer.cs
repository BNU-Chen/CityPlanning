namespace CityPlanning.Modules
{
    partial class ucNavigationRDB
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
            this.TreeListTables = new DevExpress.XtraTreeList.TreeList();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.TextEdit_Filter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Filter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeListTables
            // 
            this.TreeListTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeListTables.Location = new System.Drawing.Point(0, 39);
            this.TreeListTables.Name = "TreeListTables";
            this.TreeListTables.OptionsBehavior.Editable = false;
            this.TreeListTables.OptionsBehavior.EnableFiltering = true;
            this.TreeListTables.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.TreeListTables.OptionsView.ShowAutoFilterRow = true;
            this.TreeListTables.OptionsView.ShowColumns = false;
            this.TreeListTables.OptionsView.ShowHorzLines = false;
            this.TreeListTables.OptionsView.ShowIndicator = false;
            this.TreeListTables.OptionsView.ShowVertLines = false;
            this.TreeListTables.RowHeight = 25;
            this.TreeListTables.Size = new System.Drawing.Size(234, 406);
            this.TreeListTables.TabIndex = 7;
            this.TreeListTables.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.TextEdit_Filter);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(234, 38);
            this.panelControl1.TabIndex = 8;
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
            this.TextEdit_Filter.Size = new System.Drawing.Size(194, 24);
            this.TextEdit_Filter.TabIndex = 4;
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
            // ucNavigationRDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.TreeListTables);
            this.Name = "ucNavigationRDB";
            this.Size = new System.Drawing.Size(234, 445);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Filter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList TreeListTables;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit TextEdit_Filter;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}
