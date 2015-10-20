namespace CityPlanning
{
    partial class frmMapSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.btnStatusMap = new System.Windows.Forms.Button();
            this.btnPlanMap = new System.Windows.Forms.Button();
            this.btnAnalysisMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutView1
            // 
            this.layoutView1.CardMinSize = new System.Drawing.Size(280, 196);
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.layoutViewColumn1});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 54);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(784, 510);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.Caption = "layoutViewColumn1";
            this.layoutViewColumn1.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(250, 20);
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(111, 14);
            this.layoutViewField_layoutViewColumn1.TextToControlDistance = 5;
            // 
            // btnStatusMap
            // 
            this.btnStatusMap.AutoSize = true;
            this.btnStatusMap.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStatusMap.Location = new System.Drawing.Point(132, 9);
            this.btnStatusMap.Name = "btnStatusMap";
            this.btnStatusMap.Size = new System.Drawing.Size(116, 39);
            this.btnStatusMap.TabIndex = 1;
            this.btnStatusMap.Text = "现状图";
            this.btnStatusMap.UseVisualStyleBackColor = true;
            this.btnStatusMap.Click += new System.EventHandler(this.btnStatusMap_Click);
            // 
            // btnPlanMap
            // 
            this.btnPlanMap.AutoSize = true;
            this.btnPlanMap.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlanMap.Location = new System.Drawing.Point(334, 9);
            this.btnPlanMap.Name = "btnPlanMap";
            this.btnPlanMap.Size = new System.Drawing.Size(116, 39);
            this.btnPlanMap.TabIndex = 2;
            this.btnPlanMap.Text = "规划图";
            this.btnPlanMap.UseVisualStyleBackColor = true;
            this.btnPlanMap.Click += new System.EventHandler(this.btnPlanMap_Click);
            // 
            // btnAnalysisMap
            // 
            this.btnAnalysisMap.AutoSize = true;
            this.btnAnalysisMap.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAnalysisMap.Location = new System.Drawing.Point(536, 9);
            this.btnAnalysisMap.Name = "btnAnalysisMap";
            this.btnAnalysisMap.Size = new System.Drawing.Size(116, 39);
            this.btnAnalysisMap.TabIndex = 3;
            this.btnAnalysisMap.Text = "分析图";
            this.btnAnalysisMap.UseVisualStyleBackColor = true;
            this.btnAnalysisMap.Click += new System.EventHandler(this.btnAnalysisMap_Click);
            // 
            // frmMapSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.btnAnalysisMap);
            this.Controls.Add(this.btnPlanMap);
            this.Controls.Add(this.btnStatusMap);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMapSelection";
            this.Load += new System.EventHandler(this.frmMapSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private System.Windows.Forms.Button btnStatusMap;
        private System.Windows.Forms.Button btnPlanMap;
        private System.Windows.Forms.Button btnAnalysisMap;


    }
}