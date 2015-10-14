namespace CityPlanning.Modules
{
    partial class ucChartShow
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChartShow));
            this.chartShowControl = new DevExpress.XtraCharts.ChartControl();
            this.icChartTypeImage = new DevExpress.Utils.ImageCollection(this.components);
            this.labChartType = new DevExpress.XtraEditors.LabelControl();
            this.icbeChartType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labChartTitle = new DevExpress.XtraEditors.LabelControl();
            this.teChartTitle = new DevExpress.XtraEditors.TextEdit();
            this.checkChartLegend = new DevExpress.XtraEditors.CheckEdit();
            this.checkChartDataLable = new DevExpress.XtraEditors.CheckEdit();
            this.labAxisXTitle = new DevExpress.XtraEditors.LabelControl();
            this.teAxisXTitle = new DevExpress.XtraEditors.TextEdit();
            this.labAxisYTitle = new DevExpress.XtraEditors.LabelControl();
            this.teAxisYTitle = new DevExpress.XtraEditors.TextEdit();
            this.checkAxisYNetworkLine = new DevExpress.XtraEditors.CheckEdit();
            this.checkAxisXNetworkLine = new DevExpress.XtraEditors.CheckEdit();
            this.labAxisXDataField = new DevExpress.XtraEditors.LabelControl();
            this.labAxisYDataField = new DevExpress.XtraEditors.LabelControl();
            this.cbeAxisXDataField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkedAxisYDataField = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnSaveAs = new DevExpress.XtraEditors.SimpleButton();
            this.checkPieDataShowType = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chartShowControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icChartTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbeChartType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teChartTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChartLegend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChartDataLable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAxisXTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAxisYTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAxisYNetworkLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAxisXNetworkLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeAxisXDataField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedAxisYDataField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPieDataShowType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chartShowControl
            // 
            this.chartShowControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartShowControl.Location = new System.Drawing.Point(4, 100);
            this.chartShowControl.Margin = new System.Windows.Forms.Padding(5);
            this.chartShowControl.Name = "chartShowControl";
            this.chartShowControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisible = true;
            this.chartShowControl.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chartShowControl.Size = new System.Drawing.Size(640, 380);
            this.chartShowControl.TabIndex = 0;
            this.chartShowControl.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.chartShowControl_ObjectSelected);
            // 
            // icChartTypeImage
            // 
            this.icChartTypeImage.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icChartTypeImage.ImageStream")));
            this.icChartTypeImage.InsertGalleryImage("chart_16x16.png", "images/chart/chart_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/chart_16x16.png"), 0);
            this.icChartTypeImage.Images.SetKeyName(0, "chart_16x16.png");
            this.icChartTypeImage.InsertGalleryImage("line_16x16.png", "images/chart/line_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/line_16x16.png"), 1);
            this.icChartTypeImage.Images.SetKeyName(1, "line_16x16.png");
            this.icChartTypeImage.InsertGalleryImage("point_16x16.png", "images/chart/point_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/point_16x16.png"), 2);
            this.icChartTypeImage.Images.SetKeyName(2, "point_16x16.png");
            this.icChartTypeImage.InsertGalleryImage("pie_16x16.png", "images/chart/pie_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/pie_16x16.png"), 3);
            this.icChartTypeImage.Images.SetKeyName(3, "pie_16x16.png");
            // 
            // labChartType
            // 
            this.labChartType.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labChartType.Location = new System.Drawing.Point(9, 6);
            this.labChartType.Margin = new System.Windows.Forms.Padding(5);
            this.labChartType.Name = "labChartType";
            this.labChartType.Size = new System.Drawing.Size(70, 20);
            this.labChartType.TabIndex = 1;
            this.labChartType.Text = "图表类型：";
            // 
            // icbeChartType
            // 
            this.icbeChartType.EditValue = "柱状图";
            this.icbeChartType.Location = new System.Drawing.Point(95, 3);
            this.icbeChartType.Name = "icbeChartType";
            this.icbeChartType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.icbeChartType.Properties.Appearance.Options.UseFont = true;
            this.icbeChartType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.icbeChartType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbeChartType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("柱状图", "柱状图", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("线状图", "线状图", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("散点图", "散点图", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("饼状图", "饼状图", 3)});
            this.icbeChartType.Properties.LargeImages = this.icChartTypeImage;
            this.icbeChartType.Size = new System.Drawing.Size(120, 26);
            this.icbeChartType.TabIndex = 2;
            this.icbeChartType.SelectedIndexChanged += new System.EventHandler(this.icbeChartType_SelectedIndexChanged);
            // 
            // labChartTitle
            // 
            this.labChartTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labChartTitle.Location = new System.Drawing.Point(225, 6);
            this.labChartTitle.Name = "labChartTitle";
            this.labChartTitle.Size = new System.Drawing.Size(70, 20);
            this.labChartTitle.TabIndex = 3;
            this.labChartTitle.Text = "图表标题：";
            // 
            // teChartTitle
            // 
            this.teChartTitle.Location = new System.Drawing.Point(311, 3);
            this.teChartTitle.Name = "teChartTitle";
            this.teChartTitle.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.teChartTitle.Properties.Appearance.Options.UseFont = true;
            this.teChartTitle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.teChartTitle.Size = new System.Drawing.Size(120, 26);
            this.teChartTitle.TabIndex = 4;
            this.teChartTitle.EditValueChanged += new System.EventHandler(this.teChartTitle_EditValueChanged);
            // 
            // checkChartLegend
            // 
            this.checkChartLegend.Location = new System.Drawing.Point(437, 4);
            this.checkChartLegend.Name = "checkChartLegend";
            this.checkChartLegend.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkChartLegend.Properties.Appearance.Options.UseFont = true;
            this.checkChartLegend.Properties.Caption = "图表图例";
            this.checkChartLegend.Size = new System.Drawing.Size(90, 25);
            this.checkChartLegend.TabIndex = 5;
            this.checkChartLegend.CheckedChanged += new System.EventHandler(this.checkChartLegend_CheckedChanged);
            // 
            // checkChartDataLable
            // 
            this.checkChartDataLable.Location = new System.Drawing.Point(533, 4);
            this.checkChartDataLable.Name = "checkChartDataLable";
            this.checkChartDataLable.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkChartDataLable.Properties.Appearance.Options.UseFont = true;
            this.checkChartDataLable.Properties.Caption = "数据标签";
            this.checkChartDataLable.Size = new System.Drawing.Size(96, 25);
            this.checkChartDataLable.TabIndex = 6;
            this.checkChartDataLable.CheckedChanged += new System.EventHandler(this.checkChartDataLable_CheckedChanged);
            // 
            // labAxisXTitle
            // 
            this.labAxisXTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAxisXTitle.Location = new System.Drawing.Point(9, 36);
            this.labAxisXTitle.Name = "labAxisXTitle";
            this.labAxisXTitle.Size = new System.Drawing.Size(70, 20);
            this.labAxisXTitle.TabIndex = 7;
            this.labAxisXTitle.Text = "横轴标题：";
            // 
            // teAxisXTitle
            // 
            this.teAxisXTitle.Location = new System.Drawing.Point(95, 33);
            this.teAxisXTitle.Name = "teAxisXTitle";
            this.teAxisXTitle.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.teAxisXTitle.Properties.Appearance.Options.UseFont = true;
            this.teAxisXTitle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.teAxisXTitle.Size = new System.Drawing.Size(120, 26);
            this.teAxisXTitle.TabIndex = 8;
            this.teAxisXTitle.EditValueChanged += new System.EventHandler(this.teAxisXTitle_EditValueChanged);
            // 
            // labAxisYTitle
            // 
            this.labAxisYTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAxisYTitle.Location = new System.Drawing.Point(225, 36);
            this.labAxisYTitle.Name = "labAxisYTitle";
            this.labAxisYTitle.Size = new System.Drawing.Size(70, 20);
            this.labAxisYTitle.TabIndex = 9;
            this.labAxisYTitle.Text = "纵轴标题：";
            // 
            // teAxisYTitle
            // 
            this.teAxisYTitle.Location = new System.Drawing.Point(311, 33);
            this.teAxisYTitle.Name = "teAxisYTitle";
            this.teAxisYTitle.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.teAxisYTitle.Properties.Appearance.Options.UseFont = true;
            this.teAxisYTitle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.teAxisYTitle.Size = new System.Drawing.Size(120, 26);
            this.teAxisYTitle.TabIndex = 10;
            this.teAxisYTitle.EditValueChanged += new System.EventHandler(this.teAxisYTitle_EditValueChanged);
            // 
            // checkAxisYNetworkLine
            // 
            this.checkAxisYNetworkLine.Location = new System.Drawing.Point(437, 34);
            this.checkAxisYNetworkLine.Name = "checkAxisYNetworkLine";
            this.checkAxisYNetworkLine.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkAxisYNetworkLine.Properties.Appearance.Options.UseFont = true;
            this.checkAxisYNetworkLine.Properties.Caption = "横网络线";
            this.checkAxisYNetworkLine.Size = new System.Drawing.Size(90, 25);
            this.checkAxisYNetworkLine.TabIndex = 11;
            this.checkAxisYNetworkLine.CheckedChanged += new System.EventHandler(this.checkAxisYNetworkLine_CheckedChanged);
            // 
            // checkAxisXNetworkLine
            // 
            this.checkAxisXNetworkLine.Location = new System.Drawing.Point(533, 34);
            this.checkAxisXNetworkLine.Name = "checkAxisXNetworkLine";
            this.checkAxisXNetworkLine.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkAxisXNetworkLine.Properties.Appearance.Options.UseFont = true;
            this.checkAxisXNetworkLine.Properties.Caption = "纵网络线";
            this.checkAxisXNetworkLine.Size = new System.Drawing.Size(96, 25);
            this.checkAxisXNetworkLine.TabIndex = 12;
            this.checkAxisXNetworkLine.CheckedChanged += new System.EventHandler(this.checkAxisXNetworkLine_CheckedChanged);
            // 
            // labAxisXDataField
            // 
            this.labAxisXDataField.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAxisXDataField.Location = new System.Drawing.Point(9, 66);
            this.labAxisXDataField.Name = "labAxisXDataField";
            this.labAxisXDataField.Size = new System.Drawing.Size(70, 20);
            this.labAxisXDataField.TabIndex = 13;
            this.labAxisXDataField.Text = "横轴字段：";
            // 
            // labAxisYDataField
            // 
            this.labAxisYDataField.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAxisYDataField.Location = new System.Drawing.Point(225, 66);
            this.labAxisYDataField.Name = "labAxisYDataField";
            this.labAxisYDataField.Size = new System.Drawing.Size(70, 20);
            this.labAxisYDataField.TabIndex = 14;
            this.labAxisYDataField.Text = "纵轴字段：";
            // 
            // cbeAxisXDataField
            // 
            this.cbeAxisXDataField.Location = new System.Drawing.Point(95, 63);
            this.cbeAxisXDataField.Name = "cbeAxisXDataField";
            this.cbeAxisXDataField.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbeAxisXDataField.Properties.Appearance.Options.UseFont = true;
            this.cbeAxisXDataField.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cbeAxisXDataField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeAxisXDataField.Size = new System.Drawing.Size(120, 26);
            this.cbeAxisXDataField.TabIndex = 15;
            this.cbeAxisXDataField.SelectedIndexChanged += new System.EventHandler(this.cbeAxisXDataField_SelectedIndexChanged);
            // 
            // checkedAxisYDataField
            // 
            this.checkedAxisYDataField.EditValue = "";
            this.checkedAxisYDataField.Location = new System.Drawing.Point(311, 63);
            this.checkedAxisYDataField.Name = "checkedAxisYDataField";
            this.checkedAxisYDataField.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedAxisYDataField.Properties.Appearance.Options.UseFont = true;
            this.checkedAxisYDataField.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.checkedAxisYDataField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedAxisYDataField.Size = new System.Drawing.Size(120, 26);
            this.checkedAxisYDataField.TabIndex = 16;
            this.checkedAxisYDataField.EditValueChanged += new System.EventHandler(this.checkedAxisYDataField_EditValueChanged);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Image = global::CityPlanning.Properties.Resources.saveAs_16;
            this.btnSaveAs.Location = new System.Drawing.Point(439, 65);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(88, 24);
            this.btnSaveAs.TabIndex = 17;
            this.btnSaveAs.Text = "另存为...";
            this.btnSaveAs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSaveAs_MouseClick);
            // 
            // checkPieDataShowType
            // 
            this.checkPieDataShowType.EditValue = true;
            this.checkPieDataShowType.Location = new System.Drawing.Point(533, 67);
            this.checkPieDataShowType.Name = "checkPieDataShowType";
            this.checkPieDataShowType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkPieDataShowType.Properties.Appearance.Options.UseFont = true;
            this.checkPieDataShowType.Properties.Caption = "百分比";
            this.checkPieDataShowType.Size = new System.Drawing.Size(96, 25);
            this.checkPieDataShowType.TabIndex = 18;
            this.checkPieDataShowType.CheckedChanged += new System.EventHandler(this.checkPieDataShowType_CheckedChanged);
            // 
            // ucChartShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.checkPieDataShowType);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.checkedAxisYDataField);
            this.Controls.Add(this.cbeAxisXDataField);
            this.Controls.Add(this.labAxisYDataField);
            this.Controls.Add(this.labAxisXDataField);
            this.Controls.Add(this.checkAxisXNetworkLine);
            this.Controls.Add(this.checkAxisYNetworkLine);
            this.Controls.Add(this.teAxisYTitle);
            this.Controls.Add(this.labAxisYTitle);
            this.Controls.Add(this.teAxisXTitle);
            this.Controls.Add(this.labAxisXTitle);
            this.Controls.Add(this.checkChartDataLable);
            this.Controls.Add(this.checkChartLegend);
            this.Controls.Add(this.teChartTitle);
            this.Controls.Add(this.labChartTitle);
            this.Controls.Add(this.icbeChartType);
            this.Controls.Add(this.labChartType);
            this.Controls.Add(this.chartShowControl);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucChartShow";
            this.Size = new System.Drawing.Size(648, 480);
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartShowControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icChartTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbeChartType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teChartTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChartLegend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChartDataLable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAxisXTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAxisYTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAxisYNetworkLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAxisXNetworkLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeAxisXDataField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedAxisYDataField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPieDataShowType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartShowControl;
        private DevExpress.Utils.ImageCollection icChartTypeImage;
        private DevExpress.XtraEditors.LabelControl labChartType;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbeChartType;
        private DevExpress.XtraEditors.LabelControl labChartTitle;
        private DevExpress.XtraEditors.TextEdit teChartTitle;
        private DevExpress.XtraEditors.CheckEdit checkChartLegend;
        private DevExpress.XtraEditors.CheckEdit checkChartDataLable;
        private DevExpress.XtraEditors.LabelControl labAxisXTitle;
        private DevExpress.XtraEditors.TextEdit teAxisXTitle;
        private DevExpress.XtraEditors.LabelControl labAxisYTitle;
        private DevExpress.XtraEditors.TextEdit teAxisYTitle;
        private DevExpress.XtraEditors.CheckEdit checkAxisYNetworkLine;
        private DevExpress.XtraEditors.CheckEdit checkAxisXNetworkLine;
        private DevExpress.XtraEditors.LabelControl labAxisXDataField;
        private DevExpress.XtraEditors.LabelControl labAxisYDataField;
        private DevExpress.XtraEditors.ComboBoxEdit cbeAxisXDataField;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedAxisYDataField;
        private DevExpress.XtraEditors.SimpleButton btnSaveAs;
        private DevExpress.XtraEditors.CheckEdit checkPieDataShowType;
    }
}
