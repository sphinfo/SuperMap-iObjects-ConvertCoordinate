namespace BToGRS80
{
    partial class SampleForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBesselControlPoint = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGRS80PCS = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnToGRS80 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbGRS80ControlPoint = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnToBessel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBesselPCS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDatasource = new System.Windows.Forms.TextBox();
            this.txtSourceDataset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTranslateDataset = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBesselControlPoint);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGRS80PCS);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.btnToGRS80);
            this.groupBox1.Location = new System.Drawing.Point(11, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 120);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GRS80 타원체로 변환";
            // 
            // cbBesselControlPoint
            // 
            this.cbBesselControlPoint.FormattingEnabled = true;
            this.cbBesselControlPoint.Items.AddRange(new object[] {
            "중부",
            "서부",
            "동부",
            "동해",
            "제주도"});
            this.cbBesselControlPoint.Location = new System.Drawing.Point(93, 22);
            this.cbBesselControlPoint.Name = "cbBesselControlPoint";
            this.cbBesselControlPoint.Size = new System.Drawing.Size(440, 20);
            this.cbBesselControlPoint.TabIndex = 23;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(282, 85);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(122, 21);
            this.textBox5.TabIndex = 22;
            this.textBox5.Text = "0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(117, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(122, 21);
            this.textBox4.TabIndex = 22;
            this.textBox4.Text = "0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Offset(m)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "Bessel 원점";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "GRS80(PCS)";
            // 
            // txtGRS80PCS
            // 
            this.txtGRS80PCS.Location = new System.Drawing.Point(93, 49);
            this.txtGRS80PCS.Name = "txtGRS80PCS";
            this.txtGRS80PCS.Size = new System.Drawing.Size(440, 21);
            this.txtGRS80PCS.TabIndex = 19;
            this.txtGRS80PCS.Text = "C:\\Data\\좌표계\\projection\\PCS_ITRF2000(GRS80)_TM(중부원점).prj";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, -86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "GRS80(PCS)";
            // 
            // btnToGRS80
            // 
            this.btnToGRS80.Location = new System.Drawing.Point(425, 79);
            this.btnToGRS80.Name = "btnToGRS80";
            this.btnToGRS80.Size = new System.Drawing.Size(108, 30);
            this.btnToGRS80.TabIndex = 7;
            this.btnToGRS80.Text = "GRS80으로 변환";
            this.btnToGRS80.UseVisualStyleBackColor = true;
            this.btnToGRS80.Click += new System.EventHandler(this.btnToGRS80_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbGRS80ControlPoint);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.btnToBessel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtBesselPCS);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(11, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 129);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bessel 타원체로 변환";
            // 
            // cbGRS80ControlPoint
            // 
            this.cbGRS80ControlPoint.FormattingEnabled = true;
            this.cbGRS80ControlPoint.Items.AddRange(new object[] {
            "중부",
            "서부",
            "동부",
            "동해"});
            this.cbGRS80ControlPoint.Location = new System.Drawing.Point(93, 20);
            this.cbGRS80ControlPoint.Name = "cbGRS80ControlPoint";
            this.cbGRS80ControlPoint.Size = new System.Drawing.Size(446, 20);
            this.cbGRS80ControlPoint.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "GRS80 원점";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(282, 86);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(122, 21);
            this.textBox7.TabIndex = 22;
            this.textBox7.Text = "0";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(117, 86);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(122, 21);
            this.textBox6.TabIndex = 22;
            this.textBox6.Text = "0";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnToBessel
            // 
            this.btnToBessel.Location = new System.Drawing.Point(431, 80);
            this.btnToBessel.Name = "btnToBessel";
            this.btnToBessel.Size = new System.Drawing.Size(108, 30);
            this.btnToBessel.TabIndex = 20;
            this.btnToBessel.Text = "Bessel로 변환";
            this.btnToBessel.UseVisualStyleBackColor = true;
            this.btnToBessel.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "Y:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 12);
            this.label17.TabIndex = 19;
            this.label17.Text = "Bessel(PCS)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "X:";
            // 
            // txtBesselPCS
            // 
            this.txtBesselPCS.Location = new System.Drawing.Point(93, 50);
            this.txtBesselPCS.Name = "txtBesselPCS";
            this.txtBesselPCS.Size = new System.Drawing.Size(446, 21);
            this.txtBesselPCS.TabIndex = 18;
            this.txtBesselPCS.Text = "C:\\Data\\좌표계\\projection\\PCS_BESSEL_TM(중부원점).prj";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "Offset(m)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "데이터 소스";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 24);
            this.label12.TabIndex = 25;
            this.label12.Text = "원본 데이터 셋 \r\n(PCS)";
            // 
            // txtDatasource
            // 
            this.txtDatasource.Location = new System.Drawing.Point(111, 25);
            this.txtDatasource.Name = "txtDatasource";
            this.txtDatasource.Size = new System.Drawing.Size(444, 21);
            this.txtDatasource.TabIndex = 23;
            this.txtDatasource.Text = "C:\\Data\\좌표변환\\좌표변환.udb";
            // 
            // txtSourceDataset
            // 
            this.txtSourceDataset.Location = new System.Drawing.Point(111, 57);
            this.txtSourceDataset.Name = "txtSourceDataset";
            this.txtSourceDataset.Size = new System.Drawing.Size(444, 21);
            this.txtSourceDataset.TabIndex = 24;
            this.txtSourceDataset.Text = "IDX_B030_BESSEL_PCS_Orgin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 24);
            this.label5.TabIndex = 27;
            this.label5.Text = "변환 데이터 셋\r\n(PCS)";
            // 
            // txtTranslateDataset
            // 
            this.txtTranslateDataset.Location = new System.Drawing.Point(111, 84);
            this.txtTranslateDataset.Name = "txtTranslateDataset";
            this.txtTranslateDataset.Size = new System.Drawing.Size(444, 21);
            this.txtTranslateDataset.TabIndex = 26;
            this.txtTranslateDataset.Text = "IDX5000_GRS80_9_지리원_32";
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 486);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTranslateDataset);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSourceDataset);
            this.Controls.Add(this.txtDatasource);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SampleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 좌표계 변환";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGRS80PCS;
        private System.Windows.Forms.Button btnToGRS80;
        private System.Windows.Forms.Button btnToBessel;
        private System.Windows.Forms.TextBox txtBesselPCS;
        private System.Windows.Forms.TextBox txtDatasource;
        private System.Windows.Forms.TextBox txtSourceDataset;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTranslateDataset;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBesselControlPoint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbGRS80ControlPoint;
        private System.Windows.Forms.Label label10;
    }
}