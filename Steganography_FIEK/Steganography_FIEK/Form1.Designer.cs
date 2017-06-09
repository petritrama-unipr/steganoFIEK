namespace Steganography_FIEK
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCarrierProp2 = new System.Windows.Forms.Label();
            this.lblCarrierProp1 = new System.Windows.Forms.Label();
            this.btnCarrier = new System.Windows.Forms.Button();
            this.txtCarrier = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSecretProp2 = new System.Windows.Forms.Label();
            this.lblSecretProp1 = new System.Windows.Forms.Label();
            this.btnSecret = new System.Windows.Forms.Button();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSteganography = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSteganography = new System.Windows.Forms.TabPage();
            this.tabSteganoanalysis = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnStegano = new System.Windows.Forms.Button();
            this.txtStegano = new System.Windows.Forms.TextBox();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbSteganoanalysis = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSteganography.SuspendLayout();
            this.tabSteganoanalysis.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCarrierProp2);
            this.groupBox1.Controls.Add(this.lblCarrierProp1);
            this.groupBox1.Controls.Add(this.btnCarrier);
            this.groupBox1.Controls.Add(this.txtCarrier);
            this.groupBox1.Location = new System.Drawing.Point(9, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carrier File (.bmp image or .wav audio)";
            // 
            // lblCarrierProp2
            // 
            this.lblCarrierProp2.ForeColor = System.Drawing.Color.Blue;
            this.lblCarrierProp2.Location = new System.Drawing.Point(159, 53);
            this.lblCarrierProp2.Name = "lblCarrierProp2";
            this.lblCarrierProp2.Size = new System.Drawing.Size(242, 40);
            this.lblCarrierProp2.TabIndex = 3;
            this.lblCarrierProp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCarrierProp1
            // 
            this.lblCarrierProp1.ForeColor = System.Drawing.Color.Navy;
            this.lblCarrierProp1.Location = new System.Drawing.Point(21, 53);
            this.lblCarrierProp1.Name = "lblCarrierProp1";
            this.lblCarrierProp1.Size = new System.Drawing.Size(132, 40);
            this.lblCarrierProp1.TabIndex = 2;
            this.lblCarrierProp1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCarrier
            // 
            this.btnCarrier.Location = new System.Drawing.Point(364, 30);
            this.btnCarrier.Name = "btnCarrier";
            this.btnCarrier.Size = new System.Drawing.Size(30, 20);
            this.btnCarrier.TabIndex = 1;
            this.btnCarrier.Text = "...";
            this.btnCarrier.UseVisualStyleBackColor = true;
            this.btnCarrier.Click += new System.EventHandler(this.btnCarrier_Click);
            // 
            // txtCarrier
            // 
            this.txtCarrier.Location = new System.Drawing.Point(21, 30);
            this.txtCarrier.Name = "txtCarrier";
            this.txtCarrier.Size = new System.Drawing.Size(337, 20);
            this.txtCarrier.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSecretProp2);
            this.groupBox2.Controls.Add(this.lblSecretProp1);
            this.groupBox2.Controls.Add(this.btnSecret);
            this.groupBox2.Controls.Add(this.txtSecret);
            this.groupBox2.Location = new System.Drawing.Point(9, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Secret File (.txt file)";
            // 
            // lblSecretProp2
            // 
            this.lblSecretProp2.ForeColor = System.Drawing.Color.Blue;
            this.lblSecretProp2.Location = new System.Drawing.Point(159, 52);
            this.lblSecretProp2.Name = "lblSecretProp2";
            this.lblSecretProp2.Size = new System.Drawing.Size(242, 40);
            this.lblSecretProp2.TabIndex = 5;
            this.lblSecretProp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSecretProp1
            // 
            this.lblSecretProp1.ForeColor = System.Drawing.Color.Navy;
            this.lblSecretProp1.Location = new System.Drawing.Point(21, 52);
            this.lblSecretProp1.Name = "lblSecretProp1";
            this.lblSecretProp1.Size = new System.Drawing.Size(132, 40);
            this.lblSecretProp1.TabIndex = 4;
            this.lblSecretProp1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSecret
            // 
            this.btnSecret.Location = new System.Drawing.Point(364, 29);
            this.btnSecret.Name = "btnSecret";
            this.btnSecret.Size = new System.Drawing.Size(30, 20);
            this.btnSecret.TabIndex = 1;
            this.btnSecret.Text = "...";
            this.btnSecret.UseVisualStyleBackColor = true;
            this.btnSecret.Click += new System.EventHandler(this.btnSecret_Click);
            // 
            // txtSecret
            // 
            this.txtSecret.Location = new System.Drawing.Point(21, 29);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.Size = new System.Drawing.Size(337, 20);
            this.txtSecret.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSteganography);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(9, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 88);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // cbSteganography
            // 
            this.cbSteganography.FormattingEnabled = true;
            this.cbSteganography.Items.AddRange(new object[] {
            "",
            "LSB - 3 bit/Pixel",
            "PVD"});
            this.cbSteganography.Location = new System.Drawing.Point(174, 38);
            this.cbSteganography.Name = "cbSteganography";
            this.cbSteganography.Size = new System.Drawing.Size(141, 21);
            this.cbSteganography.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steganography Method:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(231, 380);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 36);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHide
            // 
            this.btnHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(109, 380);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(93, 36);
            this.btnHide.TabIndex = 6;
            this.btnHide.Text = "Hide...";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSteganography);
            this.tabControl1.Controls.Add(this.tabSteganoanalysis);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(430, 457);
            this.tabControl1.TabIndex = 7;
            // 
            // tabSteganography
            // 
            this.tabSteganography.Controls.Add(this.groupBox1);
            this.tabSteganography.Controls.Add(this.btnExit);
            this.tabSteganography.Controls.Add(this.btnHide);
            this.tabSteganography.Controls.Add(this.groupBox2);
            this.tabSteganography.Controls.Add(this.groupBox3);
            this.tabSteganography.Location = new System.Drawing.Point(4, 22);
            this.tabSteganography.Name = "tabSteganography";
            this.tabSteganography.Padding = new System.Windows.Forms.Padding(3);
            this.tabSteganography.Size = new System.Drawing.Size(422, 431);
            this.tabSteganography.TabIndex = 0;
            this.tabSteganography.Text = "Steganography";
            this.tabSteganography.UseVisualStyleBackColor = true;
            // 
            // tabSteganoanalysis
            // 
            this.tabSteganoanalysis.Controls.Add(this.groupBox4);
            this.tabSteganoanalysis.Controls.Add(this.btnExit2);
            this.tabSteganoanalysis.Controls.Add(this.btnAnalyze);
            this.tabSteganoanalysis.Controls.Add(this.groupBox5);
            this.tabSteganoanalysis.Controls.Add(this.groupBox6);
            this.tabSteganoanalysis.Location = new System.Drawing.Point(4, 22);
            this.tabSteganoanalysis.Name = "tabSteganoanalysis";
            this.tabSteganoanalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabSteganoanalysis.Size = new System.Drawing.Size(422, 431);
            this.tabSteganoanalysis.TabIndex = 1;
            this.tabSteganoanalysis.Text = "Steganoanalysis";
            this.tabSteganoanalysis.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStegano);
            this.groupBox4.Controls.Add(this.txtStegano);
            this.groupBox4.Location = new System.Drawing.Point(9, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 100);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stegano File";
            // 
            // btnStegano
            // 
            this.btnStegano.Location = new System.Drawing.Point(364, 30);
            this.btnStegano.Name = "btnStegano";
            this.btnStegano.Size = new System.Drawing.Size(30, 20);
            this.btnStegano.TabIndex = 1;
            this.btnStegano.Text = "...";
            this.btnStegano.UseVisualStyleBackColor = true;
            this.btnStegano.Click += new System.EventHandler(this.btnStegano_Click);
            // 
            // txtStegano
            // 
            this.txtStegano.Location = new System.Drawing.Point(21, 30);
            this.txtStegano.Name = "txtStegano";
            this.txtStegano.Size = new System.Drawing.Size(337, 20);
            this.txtStegano.TabIndex = 0;
            // 
            // btnExit2
            // 
            this.btnExit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit2.Location = new System.Drawing.Point(231, 380);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(93, 36);
            this.btnExit2.TabIndex = 10;
            this.btnExit2.Text = "Exit";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit2_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyze.Location = new System.Drawing.Point(30, 380);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(172, 36);
            this.btnAnalyze.TabIndex = 11;
            this.btnAnalyze.Text = "Analyze and Extract...";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(9, 241);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(407, 101);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Steganoanalysis Results";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbSteganoanalysis);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(9, 139);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(407, 88);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Settings";
            // 
            // cbSteganoanalysis
            // 
            this.cbSteganoanalysis.FormattingEnabled = true;
            this.cbSteganoanalysis.Items.AddRange(new object[] {
            "",
            "LSB - 3 bit/Pixel",
            "PVD"});
            this.cbSteganoanalysis.Location = new System.Drawing.Point(174, 38);
            this.cbSteganoanalysis.Name = "cbSteganoanalysis";
            this.cbSteganoanalysis.Size = new System.Drawing.Size(141, 21);
            this.cbSteganoanalysis.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Steganoanalysis Method:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Steganography_FIEK.Properties.Resources.info3;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(417, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::Steganography_FIEK.Properties.Resources.pi_006281;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(454, 481);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SteganoFIEK";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSteganography.ResumeLayout(false);
            this.tabSteganoanalysis.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCarrier;
        private System.Windows.Forms.TextBox txtCarrier;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSecret;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSteganography;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSteganography;
        private System.Windows.Forms.TabPage tabSteganoanalysis;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnStegano;
        private System.Windows.Forms.TextBox txtStegano;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbSteganoanalysis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCarrierProp1;
        private System.Windows.Forms.Label lblCarrierProp2;
        private System.Windows.Forms.Label lblSecretProp2;
        private System.Windows.Forms.Label lblSecretProp1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

