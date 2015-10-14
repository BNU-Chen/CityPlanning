namespace CityPlanning.Forms
{
    partial class frmAnalysisEcologicalPriceEvaluation
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbPolygonBoundaryMapPath = new System.Windows.Forms.TextBox();
            this.tbLandtypeDistributionMapPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbEcologicalPriceDistributionMapPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbHeliuOrHupoPrice = new System.Windows.Forms.TextBox();
            this.tbShidiPrice = new System.Windows.Forms.TextBox();
            this.tbNongtianPrice = new System.Windows.Forms.TextBox();
            this.tbCaodiPrice = new System.Windows.Forms.TextBox();
            this.tbLindiPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地类分布图：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbPolygonBoundaryMapPath);
            this.groupBox1.Controls.Add(this.tbLandtypeDistributionMapPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(409, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(409, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbPolygonBoundaryMapPath
            // 
            this.tbPolygonBoundaryMapPath.Location = new System.Drawing.Point(103, 49);
            this.tbPolygonBoundaryMapPath.Name = "tbPolygonBoundaryMapPath";
            this.tbPolygonBoundaryMapPath.Size = new System.Drawing.Size(300, 21);
            this.tbPolygonBoundaryMapPath.TabIndex = 3;
            this.tbPolygonBoundaryMapPath.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tbLandtypeDistributionMapPath
            // 
            this.tbLandtypeDistributionMapPath.Location = new System.Drawing.Point(103, 21);
            this.tbLandtypeDistributionMapPath.Name = "tbLandtypeDistributionMapPath";
            this.tbLandtypeDistributionMapPath.Size = new System.Drawing.Size(300, 21);
            this.tbLandtypeDistributionMapPath.TabIndex = 2;
            this.tbLandtypeDistributionMapPath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "面状边界图：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.tbEcologicalPriceDistributionMapPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(408, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "浏览";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbEcologicalPriceDistributionMapPath
            // 
            this.tbEcologicalPriceDistributionMapPath.Location = new System.Drawing.Point(102, 23);
            this.tbEcologicalPriceDistributionMapPath.Name = "tbEcologicalPriceDistributionMapPath";
            this.tbEcologicalPriceDistributionMapPath.Size = new System.Drawing.Size(300, 21);
            this.tbEcologicalPriceDistributionMapPath.TabIndex = 1;
            this.tbEcologicalPriceDistributionMapPath.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "生态物价图：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(340, 237);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(421, 237);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbHeliuOrHupoPrice);
            this.groupBox3.Controls.Add(this.tbShidiPrice);
            this.groupBox3.Controls.Add(this.tbNongtianPrice);
            this.groupBox3.Controls.Add(this.tbCaodiPrice);
            this.groupBox3.Controls.Add(this.tbLindiPrice);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(484, 73);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "地类物价设置（元•hm-2•a-1）";
            // 
            // tbHeliuOrHupoPrice
            // 
            this.tbHeliuOrHupoPrice.Location = new System.Drawing.Point(371, 41);
            this.tbHeliuOrHupoPrice.Name = "tbHeliuOrHupoPrice";
            this.tbHeliuOrHupoPrice.Size = new System.Drawing.Size(80, 21);
            this.tbHeliuOrHupoPrice.TabIndex = 9;
            this.tbHeliuOrHupoPrice.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // tbShidiPrice
            // 
            this.tbShidiPrice.Location = new System.Drawing.Point(285, 41);
            this.tbShidiPrice.Name = "tbShidiPrice";
            this.tbShidiPrice.Size = new System.Drawing.Size(80, 21);
            this.tbShidiPrice.TabIndex = 8;
            this.tbShidiPrice.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // tbNongtianPrice
            // 
            this.tbNongtianPrice.Location = new System.Drawing.Point(199, 41);
            this.tbNongtianPrice.Name = "tbNongtianPrice";
            this.tbNongtianPrice.Size = new System.Drawing.Size(80, 21);
            this.tbNongtianPrice.TabIndex = 7;
            this.tbNongtianPrice.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // tbCaodiPrice
            // 
            this.tbCaodiPrice.Location = new System.Drawing.Point(113, 41);
            this.tbCaodiPrice.Name = "tbCaodiPrice";
            this.tbCaodiPrice.Size = new System.Drawing.Size(80, 21);
            this.tbCaodiPrice.TabIndex = 6;
            this.tbCaodiPrice.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // tbLindiPrice
            // 
            this.tbLindiPrice.Location = new System.Drawing.Point(27, 41);
            this.tbLindiPrice.Name = "tbLindiPrice";
            this.tbLindiPrice.Size = new System.Drawing.Size(80, 21);
            this.tbLindiPrice.TabIndex = 5;
            this.tbLindiPrice.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "河流/湖泊";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "湿  地";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "农  田";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "草  地";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "林  地";
            // 
            // frmAnalysisEcologicalPriceEvaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(508, 272);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAnalysisEcologicalPriceEvaluation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生态服务价值评估";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbLandtypeDistributionMapPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPolygonBoundaryMapPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbEcologicalPriceDistributionMapPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbHeliuOrHupoPrice;
        private System.Windows.Forms.TextBox tbShidiPrice;
        private System.Windows.Forms.TextBox tbNongtianPrice;
        private System.Windows.Forms.TextBox tbCaodiPrice;
        private System.Windows.Forms.TextBox tbLindiPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;

    }
}