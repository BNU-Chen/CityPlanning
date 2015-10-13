namespace CityPlanning.Forms
{
    partial class frmSysConfig
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
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_OpenPlanMap = new System.Windows.Forms.Button();
            this.btn_OpenPlanImg = new System.Windows.Forms.Button();
            this.btn_OpenThematicMap = new System.Windows.Forms.Button();
            this.btn_OpenPlanDesc = new System.Windows.Forms.Button();
            this.btn_OpenPlanDoc = new System.Windows.Forms.Button();
            this.btn_SetPlanMap = new System.Windows.Forms.Button();
            this.btn_SetPlanImg = new System.Windows.Forms.Button();
            this.btn_SetThematicMap = new System.Windows.Forms.Button();
            this.btn_SetPlanDesc = new System.Windows.Forms.Button();
            this.btn_SetPlanDoc = new System.Windows.Forms.Button();
            this.txt_PlanMap = new System.Windows.Forms.TextBox();
            this.txt_PlanImg = new System.Windows.Forms.TextBox();
            this.txt_ThematicMap = new System.Windows.Forms.TextBox();
            this.txt_PlanDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PlanDoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_OpenRedLineMap = new System.Windows.Forms.Button();
            this.btn_SetRedLineMap = new System.Windows.Forms.Button();
            this.txt_RedLineMap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_OpenThematicGDPTrans = new System.Windows.Forms.Button();
            this.btn_SetThematicGDPTrans = new System.Windows.Forms.Button();
            this.btn_OpenThematicZoology = new System.Windows.Forms.Button();
            this.btn_OpenThematicDisaster = new System.Windows.Forms.Button();
            this.btn_SetThematicZoology = new System.Windows.Forms.Button();
            this.txt_ThematicGDPTrans = new System.Windows.Forms.TextBox();
            this.btn_SetThematicDisaster = new System.Windows.Forms.Button();
            this.btn_OpenThematicElectricityNet = new System.Windows.Forms.Button();
            this.btn_SetThematicElectricityNet = new System.Windows.Forms.Button();
            this.txt_ThematicZoology = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_ThematicDisaster = new System.Windows.Forms.TextBox();
            this.btn_OpenThematicTrafficNet = new System.Windows.Forms.Button();
            this.txt_ThematicElectricityNet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_SetThematicTrafficNet = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ThematicTrafficNet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Submit
            // 
            this.btn_Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Submit.Location = new System.Drawing.Point(454, 229);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 1;
            this.btn_Submit.Text = "确定";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(373, 229);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 213);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_OpenPlanMap);
            this.tabPage1.Controls.Add(this.btn_OpenPlanImg);
            this.tabPage1.Controls.Add(this.btn_OpenThematicMap);
            this.tabPage1.Controls.Add(this.btn_OpenPlanDesc);
            this.tabPage1.Controls.Add(this.btn_OpenPlanDoc);
            this.tabPage1.Controls.Add(this.btn_SetPlanMap);
            this.tabPage1.Controls.Add(this.btn_SetPlanImg);
            this.tabPage1.Controls.Add(this.btn_SetThematicMap);
            this.tabPage1.Controls.Add(this.btn_SetPlanDesc);
            this.tabPage1.Controls.Add(this.btn_SetPlanDoc);
            this.tabPage1.Controls.Add(this.txt_PlanMap);
            this.tabPage1.Controls.Add(this.txt_PlanImg);
            this.tabPage1.Controls.Add(this.txt_ThematicMap);
            this.tabPage1.Controls.Add(this.txt_PlanDesc);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_PlanDoc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(535, 187);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "规划文档路径";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_OpenPlanMap
            // 
            this.btn_OpenPlanMap.Location = new System.Drawing.Point(478, 144);
            this.btn_OpenPlanMap.Name = "btn_OpenPlanMap";
            this.btn_OpenPlanMap.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenPlanMap.TabIndex = 24;
            this.btn_OpenPlanMap.Text = "打开";
            this.btn_OpenPlanMap.UseVisualStyleBackColor = true;
            this.btn_OpenPlanMap.Click += new System.EventHandler(this.btn_OpenPlanMap_Click);
            // 
            // btn_OpenPlanImg
            // 
            this.btn_OpenPlanImg.Location = new System.Drawing.Point(478, 112);
            this.btn_OpenPlanImg.Name = "btn_OpenPlanImg";
            this.btn_OpenPlanImg.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenPlanImg.TabIndex = 23;
            this.btn_OpenPlanImg.Text = "打开";
            this.btn_OpenPlanImg.UseVisualStyleBackColor = true;
            this.btn_OpenPlanImg.Click += new System.EventHandler(this.btn_OpenPlanImg_Click);
            // 
            // btn_OpenThematicMap
            // 
            this.btn_OpenThematicMap.Location = new System.Drawing.Point(478, 79);
            this.btn_OpenThematicMap.Name = "btn_OpenThematicMap";
            this.btn_OpenThematicMap.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenThematicMap.TabIndex = 22;
            this.btn_OpenThematicMap.Text = "打开";
            this.btn_OpenThematicMap.UseVisualStyleBackColor = true;
            this.btn_OpenThematicMap.Click += new System.EventHandler(this.btn_OpenThematicMap_Click);
            // 
            // btn_OpenPlanDesc
            // 
            this.btn_OpenPlanDesc.Location = new System.Drawing.Point(478, 46);
            this.btn_OpenPlanDesc.Name = "btn_OpenPlanDesc";
            this.btn_OpenPlanDesc.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenPlanDesc.TabIndex = 21;
            this.btn_OpenPlanDesc.Text = "打开";
            this.btn_OpenPlanDesc.UseVisualStyleBackColor = true;
            this.btn_OpenPlanDesc.Click += new System.EventHandler(this.btn_OpenPlanDesc_Click);
            // 
            // btn_OpenPlanDoc
            // 
            this.btn_OpenPlanDoc.Location = new System.Drawing.Point(478, 14);
            this.btn_OpenPlanDoc.Name = "btn_OpenPlanDoc";
            this.btn_OpenPlanDoc.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenPlanDoc.TabIndex = 19;
            this.btn_OpenPlanDoc.Text = "打开";
            this.btn_OpenPlanDoc.UseVisualStyleBackColor = true;
            this.btn_OpenPlanDoc.Click += new System.EventHandler(this.btn_OpenPlanDoc_Click);
            // 
            // btn_SetPlanMap
            // 
            this.btn_SetPlanMap.Location = new System.Drawing.Point(425, 144);
            this.btn_SetPlanMap.Name = "btn_SetPlanMap";
            this.btn_SetPlanMap.Size = new System.Drawing.Size(47, 23);
            this.btn_SetPlanMap.TabIndex = 18;
            this.btn_SetPlanMap.Text = "选择";
            this.btn_SetPlanMap.UseVisualStyleBackColor = true;
            this.btn_SetPlanMap.Click += new System.EventHandler(this.btn_SetPlanMap_Click);
            // 
            // btn_SetPlanImg
            // 
            this.btn_SetPlanImg.Location = new System.Drawing.Point(425, 112);
            this.btn_SetPlanImg.Name = "btn_SetPlanImg";
            this.btn_SetPlanImg.Size = new System.Drawing.Size(47, 23);
            this.btn_SetPlanImg.TabIndex = 17;
            this.btn_SetPlanImg.Text = "选择";
            this.btn_SetPlanImg.UseVisualStyleBackColor = true;
            this.btn_SetPlanImg.Click += new System.EventHandler(this.btn_SetPlanImg_Click);
            // 
            // btn_SetThematicMap
            // 
            this.btn_SetThematicMap.Location = new System.Drawing.Point(425, 79);
            this.btn_SetThematicMap.Name = "btn_SetThematicMap";
            this.btn_SetThematicMap.Size = new System.Drawing.Size(47, 23);
            this.btn_SetThematicMap.TabIndex = 16;
            this.btn_SetThematicMap.Text = "选择";
            this.btn_SetThematicMap.UseVisualStyleBackColor = true;
            this.btn_SetThematicMap.Click += new System.EventHandler(this.btn_SetThematicMap_Click);
            // 
            // btn_SetPlanDesc
            // 
            this.btn_SetPlanDesc.Location = new System.Drawing.Point(425, 46);
            this.btn_SetPlanDesc.Name = "btn_SetPlanDesc";
            this.btn_SetPlanDesc.Size = new System.Drawing.Size(47, 23);
            this.btn_SetPlanDesc.TabIndex = 25;
            this.btn_SetPlanDesc.Text = "选择";
            this.btn_SetPlanDesc.UseVisualStyleBackColor = true;
            this.btn_SetPlanDesc.Click += new System.EventHandler(this.btn_SetPlanDesc_Click);
            // 
            // btn_SetPlanDoc
            // 
            this.btn_SetPlanDoc.Location = new System.Drawing.Point(425, 14);
            this.btn_SetPlanDoc.Name = "btn_SetPlanDoc";
            this.btn_SetPlanDoc.Size = new System.Drawing.Size(47, 23);
            this.btn_SetPlanDoc.TabIndex = 15;
            this.btn_SetPlanDoc.Text = "选择";
            this.btn_SetPlanDoc.UseVisualStyleBackColor = true;
            this.btn_SetPlanDoc.Click += new System.EventHandler(this.btn_SetPlanDoc_Click);
            // 
            // txt_PlanMap
            // 
            this.txt_PlanMap.Location = new System.Drawing.Point(76, 144);
            this.txt_PlanMap.Name = "txt_PlanMap";
            this.txt_PlanMap.Size = new System.Drawing.Size(343, 21);
            this.txt_PlanMap.TabIndex = 12;
            // 
            // txt_PlanImg
            // 
            this.txt_PlanImg.Location = new System.Drawing.Point(76, 112);
            this.txt_PlanImg.Name = "txt_PlanImg";
            this.txt_PlanImg.Size = new System.Drawing.Size(343, 21);
            this.txt_PlanImg.TabIndex = 11;
            // 
            // txt_ThematicMap
            // 
            this.txt_ThematicMap.Location = new System.Drawing.Point(76, 79);
            this.txt_ThematicMap.Name = "txt_ThematicMap";
            this.txt_ThematicMap.Size = new System.Drawing.Size(343, 21);
            this.txt_ThematicMap.TabIndex = 10;
            // 
            // txt_PlanDesc
            // 
            this.txt_PlanDesc.Location = new System.Drawing.Point(76, 46);
            this.txt_PlanDesc.Name = "txt_PlanDesc";
            this.txt_PlanDesc.Size = new System.Drawing.Size(343, 21);
            this.txt_PlanDesc.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "规划地图：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "规划图件：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "专题报告：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "规划说明：";
            // 
            // txt_PlanDoc
            // 
            this.txt_PlanDoc.Location = new System.Drawing.Point(76, 14);
            this.txt_PlanDoc.Name = "txt_PlanDoc";
            this.txt_PlanDoc.Size = new System.Drawing.Size(343, 21);
            this.txt_PlanDoc.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "规划文本：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_OpenRedLineMap);
            this.tabPage2.Controls.Add(this.btn_SetRedLineMap);
            this.tabPage2.Controls.Add(this.txt_RedLineMap);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btn_OpenThematicGDPTrans);
            this.tabPage2.Controls.Add(this.btn_SetThematicGDPTrans);
            this.tabPage2.Controls.Add(this.btn_OpenThematicZoology);
            this.tabPage2.Controls.Add(this.btn_OpenThematicDisaster);
            this.tabPage2.Controls.Add(this.btn_SetThematicZoology);
            this.tabPage2.Controls.Add(this.txt_ThematicGDPTrans);
            this.tabPage2.Controls.Add(this.btn_SetThematicDisaster);
            this.tabPage2.Controls.Add(this.btn_OpenThematicElectricityNet);
            this.tabPage2.Controls.Add(this.btn_SetThematicElectricityNet);
            this.tabPage2.Controls.Add(this.txt_ThematicZoology);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txt_ThematicDisaster);
            this.tabPage2.Controls.Add(this.btn_OpenThematicTrafficNet);
            this.tabPage2.Controls.Add(this.txt_ThematicElectricityNet);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btn_SetThematicTrafficNet);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txt_ThematicTrafficNet);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(535, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "专题分析地图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_OpenRedLineMap
            // 
            this.btn_OpenRedLineMap.Location = new System.Drawing.Point(479, 12);
            this.btn_OpenRedLineMap.Name = "btn_OpenRedLineMap";
            this.btn_OpenRedLineMap.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenRedLineMap.TabIndex = 34;
            this.btn_OpenRedLineMap.Text = "打开";
            this.btn_OpenRedLineMap.UseVisualStyleBackColor = true;
            this.btn_OpenRedLineMap.Click += new System.EventHandler(this.btn_OpenRedLineMap_Click);
            // 
            // btn_SetRedLineMap
            // 
            this.btn_SetRedLineMap.Location = new System.Drawing.Point(426, 12);
            this.btn_SetRedLineMap.Name = "btn_SetRedLineMap";
            this.btn_SetRedLineMap.Size = new System.Drawing.Size(47, 23);
            this.btn_SetRedLineMap.TabIndex = 33;
            this.btn_SetRedLineMap.Text = "选择";
            this.btn_SetRedLineMap.UseVisualStyleBackColor = true;
            this.btn_SetRedLineMap.Click += new System.EventHandler(this.btn_SetRedLineMap_Click);
            // 
            // txt_RedLineMap
            // 
            this.txt_RedLineMap.Location = new System.Drawing.Point(77, 12);
            this.txt_RedLineMap.Name = "txt_RedLineMap";
            this.txt_RedLineMap.Size = new System.Drawing.Size(343, 21);
            this.txt_RedLineMap.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "基本红线：";
            // 
            // btn_OpenThematicGDPTrans
            // 
            this.btn_OpenThematicGDPTrans.Location = new System.Drawing.Point(478, 162);
            this.btn_OpenThematicGDPTrans.Name = "btn_OpenThematicGDPTrans";
            this.btn_OpenThematicGDPTrans.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenThematicGDPTrans.TabIndex = 30;
            this.btn_OpenThematicGDPTrans.Text = "打开";
            this.btn_OpenThematicGDPTrans.UseVisualStyleBackColor = true;
            this.btn_OpenThematicGDPTrans.Click += new System.EventHandler(this.btn_OpenThematicGDPTrans_Click);
            // 
            // btn_SetThematicGDPTrans
            // 
            this.btn_SetThematicGDPTrans.Location = new System.Drawing.Point(425, 162);
            this.btn_SetThematicGDPTrans.Name = "btn_SetThematicGDPTrans";
            this.btn_SetThematicGDPTrans.Size = new System.Drawing.Size(47, 23);
            this.btn_SetThematicGDPTrans.TabIndex = 29;
            this.btn_SetThematicGDPTrans.Text = "选择";
            this.btn_SetThematicGDPTrans.UseVisualStyleBackColor = true;
            this.btn_SetThematicGDPTrans.Click += new System.EventHandler(this.btn_SetThematicGDPTrans_Click);
            // 
            // btn_OpenThematicZoology
            // 
            this.btn_OpenThematicZoology.Location = new System.Drawing.Point(478, 130);
            this.btn_OpenThematicZoology.Name = "btn_OpenThematicZoology";
            this.btn_OpenThematicZoology.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenThematicZoology.TabIndex = 30;
            this.btn_OpenThematicZoology.Text = "打开";
            this.btn_OpenThematicZoology.UseVisualStyleBackColor = true;
            this.btn_OpenThematicZoology.Click += new System.EventHandler(this.btn_OpenThematicZoology_Click);
            // 
            // btn_OpenThematicDisaster
            // 
            this.btn_OpenThematicDisaster.Location = new System.Drawing.Point(478, 101);
            this.btn_OpenThematicDisaster.Name = "btn_OpenThematicDisaster";
            this.btn_OpenThematicDisaster.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenThematicDisaster.TabIndex = 30;
            this.btn_OpenThematicDisaster.Text = "打开";
            this.btn_OpenThematicDisaster.UseVisualStyleBackColor = true;
            this.btn_OpenThematicDisaster.Click += new System.EventHandler(this.btn_OpenThematicDisaster_Click);
            // 
            // btn_SetThematicZoology
            // 
            this.btn_SetThematicZoology.Location = new System.Drawing.Point(425, 130);
            this.btn_SetThematicZoology.Name = "btn_SetThematicZoology";
            this.btn_SetThematicZoology.Size = new System.Drawing.Size(47, 23);
            this.btn_SetThematicZoology.TabIndex = 29;
            this.btn_SetThematicZoology.Text = "选择";
            this.btn_SetThematicZoology.UseVisualStyleBackColor = true;
            this.btn_SetThematicZoology.Click += new System.EventHandler(this.btn_SetThematicZoology_Click);
            // 
            // txt_ThematicGDPTrans
            // 
            this.txt_ThematicGDPTrans.Location = new System.Drawing.Point(76, 162);
            this.txt_ThematicGDPTrans.Name = "txt_ThematicGDPTrans";
            this.txt_ThematicGDPTrans.Size = new System.Drawing.Size(343, 21);
            this.txt_ThematicGDPTrans.TabIndex = 28;
            // 
            // btn_OpenThematicElectricityNet
            // 
            this.btn_OpenThematicElectricityNet.Location = new System.Drawing.Point(478, 72);
            this.btn_OpenThematicElectricityNet.Name = "btn_OpenThematicElectricityNet";
            this.btn_OpenThematicElectricityNet.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenThematicElectricityNet.TabIndex = 30;
            this.btn_OpenThematicElectricityNet.Text = "打开";
            this.btn_OpenThematicElectricityNet.UseVisualStyleBackColor = true;
            this.btn_OpenThematicElectricityNet.Click += new System.EventHandler(this.btn_OpenThematicElectricityNet_Click);
            
            // 
            // btn_SetThematicDisaster
            // 
            this.btn_SetThematicDisaster.Location = new System.Drawing.Point(425, 101);
            this.btn_SetThematicDisaster.Name = "btn_SetThematicDisaster";
            this.btn_SetThematicDisaster.Size = new System.Drawing.Size(47, 23);
            this.btn_SetThematicDisaster.TabIndex = 29;
            this.btn_SetThematicDisaster.Text = "选择";
            this.btn_SetThematicDisaster.UseVisualStyleBackColor = true;
            this.btn_SetThematicDisaster.Click += new System.EventHandler(this.btn_SetThematicDisaster_Click);
            //
            // btn_SetThematicElectricityNet
            // 
            this.btn_SetThematicElectricityNet.Location = new System.Drawing.Point(425, 72);
            this.btn_SetThematicElectricityNet.Name = "btn_SetThematicElectricityNet";
            this.btn_SetThematicElectricityNet.Size = new System.Drawing.Size(47, 23);
            this.btn_SetThematicElectricityNet.TabIndex = 29;
            this.btn_SetThematicElectricityNet.Text = "选择";
            this.btn_SetThematicElectricityNet.UseVisualStyleBackColor = true;
            this.btn_SetThematicElectricityNet.Click += new System.EventHandler(this.btn_SetThematicElectricityNet_Click);
            // 
            // txt_ThematicZoology
            // 
            this.txt_ThematicZoology.Location = new System.Drawing.Point(76, 130);
            this.txt_ThematicZoology.Name = "txt_ThematicZoology";
            this.txt_ThematicZoology.Size = new System.Drawing.Size(343, 21);
            this.txt_ThematicZoology.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "GDP转移：";
            // 
            // txt_ThematicDisaster
            // 
            this.txt_ThematicDisaster.Location = new System.Drawing.Point(76, 101);
            this.txt_ThematicDisaster.Name = "txt_ThematicDisaster";
            this.txt_ThematicDisaster.Size = new System.Drawing.Size(343, 21);
            this.txt_ThematicDisaster.TabIndex = 28;
            // 
            // btn_OpenThematicTrafficNet
            // 
            this.btn_OpenThematicTrafficNet.Location = new System.Drawing.Point(479, 43);
            this.btn_OpenThematicTrafficNet.Name = "btn_OpenThematicTrafficNet";
            this.btn_OpenThematicTrafficNet.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenThematicTrafficNet.TabIndex = 30;
            this.btn_OpenThematicTrafficNet.Text = "打开";
            this.btn_OpenThematicTrafficNet.UseVisualStyleBackColor = true;
            this.btn_OpenThematicTrafficNet.Click += new System.EventHandler(this.btn_OpenThematicTrafficNet_Click);
            // 
            // txt_ThematicElectricityNet
            // 
            this.txt_ThematicElectricityNet.Location = new System.Drawing.Point(76, 72);
            this.txt_ThematicElectricityNet.Name = "txt_ThematicElectricityNet";
            this.txt_ThematicElectricityNet.Size = new System.Drawing.Size(343, 21);
            this.txt_ThematicElectricityNet.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "生态服务：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "灾害风险：";
            // 
            // btn_SetThematicTrafficNet
            // 
            this.btn_SetThematicTrafficNet.Location = new System.Drawing.Point(426, 43);
            this.btn_SetThematicTrafficNet.Name = "btn_SetThematicTrafficNet";
            this.btn_SetThematicTrafficNet.Size = new System.Drawing.Size(47, 23);
            this.btn_SetThematicTrafficNet.TabIndex = 29;
            this.btn_SetThematicTrafficNet.Text = "选择";
            this.btn_SetThematicTrafficNet.UseVisualStyleBackColor = true;
            this.btn_SetThematicTrafficNet.Click += new System.EventHandler(this.btn_SetThematicTrafficNet_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "电力网络：";
            // 
            // txt_ThematicTrafficNet
            // 
            this.txt_ThematicTrafficNet.Location = new System.Drawing.Point(77, 43);
            this.txt_ThematicTrafficNet.Name = "txt_ThematicTrafficNet";
            this.txt_ThematicTrafficNet.Size = new System.Drawing.Size(343, 21);
            this.txt_ThematicTrafficNet.TabIndex = 28;  
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "交通网络：";
            // 
            // frmSysConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 264);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSysConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统文件配置";
            this.Load += new System.EventHandler(this.frmSysConfig_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_OpenPlanMap;
        private System.Windows.Forms.Button btn_OpenPlanImg;
        private System.Windows.Forms.Button btn_OpenThematicMap;
        private System.Windows.Forms.Button btn_OpenPlanDesc;
        private System.Windows.Forms.Button btn_OpenPlanDoc;
        private System.Windows.Forms.Button btn_SetPlanMap;
        private System.Windows.Forms.Button btn_SetPlanImg;
        private System.Windows.Forms.Button btn_SetThematicMap;
        private System.Windows.Forms.Button btn_SetPlanDesc;
        private System.Windows.Forms.Button btn_SetPlanDoc;
        private System.Windows.Forms.TextBox txt_PlanMap;
        private System.Windows.Forms.TextBox txt_PlanImg;
        private System.Windows.Forms.TextBox txt_ThematicMap;
        private System.Windows.Forms.TextBox txt_PlanDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PlanDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_OpenThematicTrafficNet;
        private System.Windows.Forms.Button btn_SetThematicTrafficNet;
        private System.Windows.Forms.TextBox txt_ThematicTrafficNet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_OpenThematicElectricityNet;
        private System.Windows.Forms.Button btn_SetThematicElectricityNet;
        private System.Windows.Forms.TextBox txt_ThematicElectricityNet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_OpenThematicDisaster;
        private System.Windows.Forms.Button btn_SetThematicDisaster;
        private System.Windows.Forms.TextBox txt_ThematicDisaster;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_OpenThematicZoology;
        private System.Windows.Forms.Button btn_SetThematicZoology;
        private System.Windows.Forms.TextBox txt_ThematicZoology;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_OpenThematicGDPTrans;
        private System.Windows.Forms.Button btn_SetThematicGDPTrans;
        private System.Windows.Forms.TextBox txt_ThematicGDPTrans;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_OpenRedLineMap;
        private System.Windows.Forms.Button btn_SetRedLineMap;
        private System.Windows.Forms.TextBox txt_RedLineMap;
        private System.Windows.Forms.Label label6;
    }
}