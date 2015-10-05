namespace CityPlanning.Modules
{
    partial class ucImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImageViewer));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsmi_Scale = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmi_20 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_40 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_60 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_80 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_125 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_150 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_FullScale = new System.Windows.Forms.ToolStripDropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(964, 605);
            this.pictureEdit1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Scale,
            this.tsmi_FullScale});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(964, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsmi_Scale
            // 
            this.tsmi_Scale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmi_Scale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_20,
            this.tsmi_40,
            this.tsmi_60,
            this.tsmi_80,
            this.tsmi_100,
            this.tsmi_125,
            this.tsmi_150,
            this.tsmi_200});
            this.tsmi_Scale.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Scale.Image")));
            this.tsmi_Scale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmi_Scale.Name = "tsmi_Scale";
            this.tsmi_Scale.Size = new System.Drawing.Size(47, 20);
            this.tsmi_Scale.Text = "缩放";
            this.tsmi_Scale.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmi_Scale_DropDownItemClicked);
            // 
            // tsmi_20
            // 
            this.tsmi_20.Name = "tsmi_20";
            this.tsmi_20.Size = new System.Drawing.Size(152, 22);
            this.tsmi_20.Text = "20%";
            // 
            // tsmi_40
            // 
            this.tsmi_40.Name = "tsmi_40";
            this.tsmi_40.Size = new System.Drawing.Size(152, 22);
            this.tsmi_40.Text = "40%";
            // 
            // tsmi_60
            // 
            this.tsmi_60.Name = "tsmi_60";
            this.tsmi_60.Size = new System.Drawing.Size(152, 22);
            this.tsmi_60.Text = "60%";
            // 
            // tsmi_80
            // 
            this.tsmi_80.Name = "tsmi_80";
            this.tsmi_80.Size = new System.Drawing.Size(152, 22);
            this.tsmi_80.Text = "80%";
            // 
            // tsmi_100
            // 
            this.tsmi_100.Name = "tsmi_100";
            this.tsmi_100.Size = new System.Drawing.Size(152, 22);
            this.tsmi_100.Text = "100%";
            // 
            // tsmi_125
            // 
            this.tsmi_125.Name = "tsmi_125";
            this.tsmi_125.Size = new System.Drawing.Size(152, 22);
            this.tsmi_125.Text = "125%";
            // 
            // tsmi_150
            // 
            this.tsmi_150.Name = "tsmi_150";
            this.tsmi_150.Size = new System.Drawing.Size(152, 22);
            this.tsmi_150.Text = "150%";
            // 
            // tsmi_200
            // 
            this.tsmi_200.Name = "tsmi_200";
            this.tsmi_200.Size = new System.Drawing.Size(152, 22);
            this.tsmi_200.Text = "200%";
            // 
            // tsmi_FullScale
            // 
            this.tsmi_FullScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmi_FullScale.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_FullScale.Image")));
            this.tsmi_FullScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmi_FullScale.Name = "tsmi_FullScale";
            this.tsmi_FullScale.Size = new System.Drawing.Size(68, 20);
            this.tsmi_FullScale.Text = "默认大小";
            this.tsmi_FullScale.Click += new System.EventHandler(this.tsmi_FullScale_Click);
            // 
            // ucImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "ucImageViewer";
            this.Size = new System.Drawing.Size(964, 605);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton tsmi_Scale;
        private System.Windows.Forms.ToolStripMenuItem tsmi_20;
        private System.Windows.Forms.ToolStripMenuItem tsmi_40;
        private System.Windows.Forms.ToolStripMenuItem tsmi_60;
        private System.Windows.Forms.ToolStripMenuItem tsmi_80;
        private System.Windows.Forms.ToolStripMenuItem tsmi_100;
        private System.Windows.Forms.ToolStripMenuItem tsmi_125;
        private System.Windows.Forms.ToolStripMenuItem tsmi_150;
        private System.Windows.Forms.ToolStripMenuItem tsmi_200;
        private System.Windows.Forms.ToolStripDropDownButton tsmi_FullScale;

    }
}
