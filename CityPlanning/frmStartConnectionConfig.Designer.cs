namespace CityPlanning
{
    partial class frmStartConnectionConfig
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
            this.components = new System.ComponentModel.Container();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_SysUserName = new DevExpress.XtraEditors.TextEdit();
            this.txt_SysPassword = new DevExpress.XtraEditors.TextEdit();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_ConfigConnections = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_DBCatalogName = new DevExpress.XtraEditors.TextEdit();
            this.txt_DBServerName = new DevExpress.XtraEditors.TextEdit();
            this.txt_DBPassword = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_DBUserName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ftpPort = new DevExpress.XtraEditors.TextEdit();
            this.txt_ftpIP = new DevExpress.XtraEditors.TextEdit();
            this.txt_ftpPassword = new DevExpress.XtraEditors.TextEdit();
            this.txt_ftpUserName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txt_SysUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SysPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBCatalogName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBUserName.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(442, 359);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(442, 386);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "密   码：";
            // 
            // txt_SysUserName
            // 
            this.txt_SysUserName.Location = new System.Drawing.Point(496, 357);
            this.txt_SysUserName.Name = "txt_SysUserName";
            this.txt_SysUserName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_SysUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SysUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_SysUserName.Size = new System.Drawing.Size(118, 18);
            this.txt_SysUserName.TabIndex = 2;
            // 
            // txt_SysPassword
            // 
            this.txt_SysPassword.Location = new System.Drawing.Point(496, 383);
            this.txt_SysPassword.Name = "txt_SysPassword";
            this.txt_SysPassword.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_SysPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txt_SysPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_SysPassword.Properties.PasswordChar = '*';
            this.txt_SysPassword.Size = new System.Drawing.Size(118, 18);
            this.txt_SysPassword.TabIndex = 2;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.btn_Login.Location = new System.Drawing.Point(561, 413);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(53, 25);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.btn_Cancel.Location = new System.Drawing.Point(502, 413);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(53, 25);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_ConfigConnections
            // 
            this.btn_ConfigConnections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConfigConnections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.btn_ConfigConnections.Location = new System.Drawing.Point(443, 413);
            this.btn_ConfigConnections.Name = "btn_ConfigConnections";
            this.btn_ConfigConnections.Size = new System.Drawing.Size(53, 25);
            this.btn_ConfigConnections.TabIndex = 3;
            this.btn_ConfigConnections.Text = "配置";
            this.btn_ConfigConnections.UseVisualStyleBackColor = true;
            this.btn_ConfigConnections.Click += new System.EventHandler(this.btn_ConfigConnections_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Location = new System.Drawing.Point(27, 346);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(399, 100);
            this.panelControl1.TabIndex = 4;
            this.panelControl1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_DBCatalogName);
            this.groupBox2.Controls.Add(this.txt_DBServerName);
            this.groupBox2.Controls.Add(this.txt_DBPassword);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_DBUserName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(199, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "关系数据库";
            // 
            // txt_DBCatalogName
            // 
            this.txt_DBCatalogName.EditValue = "CityPlanning";
            this.txt_DBCatalogName.Location = new System.Drawing.Point(66, 46);
            this.txt_DBCatalogName.Name = "txt_DBCatalogName";
            this.txt_DBCatalogName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_DBCatalogName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_DBCatalogName.Size = new System.Drawing.Size(126, 20);
            this.txt_DBCatalogName.TabIndex = 1;
            // 
            // txt_DBServerName
            // 
            this.txt_DBServerName.EditValue = ".\\sqlexpress";
            this.txt_DBServerName.Location = new System.Drawing.Point(67, 22);
            this.txt_DBServerName.Name = "txt_DBServerName";
            this.txt_DBServerName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_DBServerName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_DBServerName.Size = new System.Drawing.Size(126, 20);
            this.txt_DBServerName.TabIndex = 1;
            // 
            // txt_DBPassword
            // 
            this.txt_DBPassword.EditValue = "sa";
            this.txt_DBPassword.Location = new System.Drawing.Point(132, 70);
            this.txt_DBPassword.Name = "txt_DBPassword";
            this.txt_DBPassword.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_DBPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txt_DBPassword.Properties.PasswordChar = '*';
            this.txt_DBPassword.Size = new System.Drawing.Size(60, 20);
            this.txt_DBPassword.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "数据库：";
            // 
            // txt_DBUserName
            // 
            this.txt_DBUserName.EditValue = "sa";
            this.txt_DBUserName.Location = new System.Drawing.Point(67, 70);
            this.txt_DBUserName.Name = "txt_DBUserName";
            this.txt_DBUserName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_DBUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_DBUserName.Size = new System.Drawing.Size(60, 20);
            this.txt_DBUserName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "服务器：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "用   户：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ftpPort);
            this.groupBox1.Controls.Add(this.txt_ftpIP);
            this.groupBox1.Controls.Add(this.txt_ftpPassword);
            this.groupBox1.Controls.Add(this.txt_ftpUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件数据库";
            // 
            // txt_ftpPort
            // 
            this.txt_ftpPort.Location = new System.Drawing.Point(157, 19);
            this.txt_ftpPort.Name = "txt_ftpPort";
            this.txt_ftpPort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_ftpPort.Properties.Appearance.Options.UseBackColor = true;
            this.txt_ftpPort.Size = new System.Drawing.Size(36, 20);
            this.txt_ftpPort.TabIndex = 1;
            // 
            // txt_ftpIP
            // 
            this.txt_ftpIP.EditValue = "D:\\Develop\\Data\\CityPlanning";
            this.txt_ftpIP.Location = new System.Drawing.Point(67, 19);
            this.txt_ftpIP.Name = "txt_ftpIP";
            this.txt_ftpIP.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_ftpIP.Properties.Appearance.Options.UseBackColor = true;
            this.txt_ftpIP.Size = new System.Drawing.Size(84, 20);
            this.txt_ftpIP.TabIndex = 1;
            // 
            // txt_ftpPassword
            // 
            this.txt_ftpPassword.Location = new System.Drawing.Point(67, 70);
            this.txt_ftpPassword.Name = "txt_ftpPassword";
            this.txt_ftpPassword.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_ftpPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txt_ftpPassword.Properties.PasswordChar = '*';
            this.txt_ftpPassword.Size = new System.Drawing.Size(126, 20);
            this.txt_ftpPassword.TabIndex = 1;
            // 
            // txt_ftpUserName
            // 
            this.txt_ftpUserName.Location = new System.Drawing.Point(67, 46);
            this.txt_ftpUserName.Name = "txt_ftpUserName";
            this.txt_ftpUserName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.txt_ftpUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_ftpUserName.Size = new System.Drawing.Size(126, 20);
            this.txt_ftpUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "密   码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "地   址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmStartConnectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::CityPlanning.Properties.Resources.CityPlanningLogo;
            this.ClientSize = new System.Drawing.Size(647, 483);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btn_ConfigConnections);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_SysPassword);
            this.Controls.Add(this.txt_SysUserName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStartConnectionConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStartConnectionConfig";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStartConnectionConfig_FormClosed);
            this.Load += new System.EventHandler(this.frmStartConnectionConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_SysUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SysPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBCatalogName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DBUserName.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ftpUserName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_SysUserName;
        private DevExpress.XtraEditors.TextEdit txt_SysPassword;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_ConfigConnections;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txt_ftpIP;
        private DevExpress.XtraEditors.TextEdit txt_ftpPassword;
        private DevExpress.XtraEditors.TextEdit txt_ftpUserName;
        private DevExpress.XtraEditors.TextEdit txt_DBServerName;
        private DevExpress.XtraEditors.TextEdit txt_DBPassword;
        private DevExpress.XtraEditors.TextEdit txt_DBUserName;
        private DevExpress.XtraEditors.TextEdit txt_ftpPort;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txt_DBCatalogName;
        private System.Windows.Forms.Label label7;
    }
}