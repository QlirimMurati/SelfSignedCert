//
// This code was written by Keith Brown, and may be freely used.
// Want to learn more about .NET? Visit pluralsight.com today!
//
namespace Pluralsight.Crypto.UI
{
    partial class GenerateSelfSignedCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateSelfSignedCertForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpValidTo = new System.Windows.Forms.DateTimePicker();
            this.dtpValidFrom = new System.Windows.Forms.DateTimePicker();
            this.cboKeySize = new System.Windows.Forms.ComboBox();
            this.txtDN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveAsPFX = new System.Windows.Forms.Button();
            this.btnSaveToCertStore = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboStoreName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboStoreLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lnkTitle = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnVerifiy = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtCert = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpValidTo);
            this.groupBox1.Controls.Add(this.dtpValidFrom);
            this.groupBox1.Controls.Add(this.cboKeySize);
            this.groupBox1.Controls.Add(this.txtDN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 165);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "certificate info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "We recommend 2048 or greater!";
            // 
            // dtpValidTo
            // 
            this.dtpValidTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpValidTo.Location = new System.Drawing.Point(165, 110);
            this.dtpValidTo.Name = "dtpValidTo";
            this.dtpValidTo.Size = new System.Drawing.Size(94, 20);
            this.dtpValidTo.TabIndex = 4;
            // 
            // dtpValidFrom
            // 
            this.dtpValidFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpValidFrom.Location = new System.Drawing.Point(165, 81);
            this.dtpValidFrom.Name = "dtpValidFrom";
            this.dtpValidFrom.Size = new System.Drawing.Size(94, 20);
            this.dtpValidFrom.TabIndex = 4;
            // 
            // cboKeySize
            // 
            this.cboKeySize.FormattingEnabled = true;
            this.cboKeySize.Items.AddRange(new object[] {
            "384",
            "512",
            "1024",
            "2048",
            "4096",
            "8192",
            "16384"});
            this.cboKeySize.Location = new System.Drawing.Point(165, 54);
            this.cboKeySize.Name = "cboKeySize";
            this.cboKeySize.Size = new System.Drawing.Size(94, 21);
            this.cboKeySize.TabIndex = 3;
            this.toolTip.SetToolTip(this.cboKeySize, "This should be a valid RSA key size.");
            this.cboKeySize.Validating += new System.ComponentModel.CancelEventHandler(this.cboKeySize_Validating);
            // 
            // txtDN
            // 
            this.txtDN.Location = new System.Drawing.Point(165, 27);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(335, 20);
            this.txtDN.TabIndex = 2;
            this.toolTip.SetToolTip(this.txtDN, "This must be a distinguished name (DN) such as \"cn=test\" or, \"cn=foo,o=pluralsigh" +
        "t\", etc.");
            this.txtDN.Validating += new System.ComponentModel.CancelEventHandler(this.txtDN_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Valid to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Valid from";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Key size (bits):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x509 Certificate Name";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // toolTip
            // 
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // btnSaveAsPFX
            // 
            this.btnSaveAsPFX.Location = new System.Drawing.Point(41, 43);
            this.btnSaveAsPFX.Name = "btnSaveAsPFX";
            this.btnSaveAsPFX.Size = new System.Drawing.Size(147, 23);
            this.btnSaveAsPFX.TabIndex = 2;
            this.btnSaveAsPFX.Text = "Save to PFX file";
            this.btnSaveAsPFX.UseVisualStyleBackColor = true;
            this.btnSaveAsPFX.Click += new System.EventHandler(this.btnSaveAsPFX_Click);
            // 
            // btnSaveToCertStore
            // 
            this.btnSaveToCertStore.Location = new System.Drawing.Point(198, 23);
            this.btnSaveToCertStore.Name = "btnSaveToCertStore";
            this.btnSaveToCertStore.Size = new System.Drawing.Size(53, 37);
            this.btnSaveToCertStore.TabIndex = 2;
            this.btnSaveToCertStore.Text = "Save";
            this.btnSaveToCertStore.UseVisualStyleBackColor = true;
            this.btnSaveToCertStore.Click += new System.EventHandler(this.btnSaveToCertStore_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.btnSaveAsPFX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 76);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "save as PFX";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 17);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(131, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Password:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboStoreName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cboStoreLocation);
            this.groupBox3.Controls.Add(this.btnSaveToCertStore);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(247, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 76);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "save to cert store";
            // 
            // cboStoreName
            // 
            this.cboStoreName.FormattingEnabled = true;
            this.cboStoreName.Items.AddRange(new object[] {
            "",
            "My"});
            this.cboStoreName.Location = new System.Drawing.Point(74, 45);
            this.cboStoreName.Name = "cboStoreName";
            this.cboStoreName.Size = new System.Drawing.Size(105, 21);
            this.cboStoreName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Store:";
            // 
            // cboStoreLocation
            // 
            this.cboStoreLocation.FormattingEnabled = true;
            this.cboStoreLocation.Items.AddRange(new object[] {
            "",
            "CurrentUser"});
            this.cboStoreLocation.Location = new System.Drawing.Point(74, 17);
            this.cboStoreLocation.Name = "cboStoreLocation";
            this.cboStoreLocation.Size = new System.Drawing.Size(105, 21);
            this.cboStoreLocation.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Location:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 528);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "FIEK 2018, All rights reserved";
            // 
            // lnkTitle
            // 
            this.lnkTitle.Image = ((System.Drawing.Image)(resources.GetObject("lnkTitle.Image")));
            this.lnkTitle.Location = new System.Drawing.Point(2, 10);
            this.lnkTitle.Name = "lnkTitle";
            this.lnkTitle.Size = new System.Drawing.Size(527, 80);
            this.lnkTitle.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(363, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 24);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(68, 91);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(280, 20);
            this.txtSave.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-3, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Save XML";
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(68, 126);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(98, 24);
            this.btnSign.TabIndex = 16;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnVerifiy
            // 
            this.btnVerifiy.Location = new System.Drawing.Point(172, 127);
            this.btnVerifiy.Name = "btnVerifiy";
            this.btnVerifiy.Size = new System.Drawing.Size(96, 24);
            this.btnVerifiy.TabIndex = 15;
            this.btnVerifiy.Text = "Verify";
            this.btnVerifiy.UseVisualStyleBackColor = true;
            this.btnVerifiy.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(363, 57);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(113, 24);
            this.btnFile.TabIndex = 12;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(68, 57);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(280, 20);
            this.txtFile.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-3, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Upload XML";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(363, 19);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(113, 24);
            this.btnUpload.TabIndex = 20;
            this.btnUpload.Text = "...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtCert
            // 
            this.txtCert.Location = new System.Drawing.Point(68, 19);
            this.txtCert.Name = "txtCert";
            this.txtCert.Size = new System.Drawing.Size(280, 20);
            this.txtCert.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-3, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Upload cert";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUpload);
            this.groupBox4.Controls.Add(this.txtCert);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.txtSave);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.btnSign);
            this.groupBox4.Controls.Add(this.btnVerifiy);
            this.groupBox4.Controls.Add(this.btnFile);
            this.groupBox4.Controls.Add(this.txtFile);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(22, 359);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(490, 154);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sign certificate";
            // 
            // GenerateSelfSignedCertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 550);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lnkTitle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerateSelfSignedCertForm";
            this.Text = "FIEK\'s Self-Cert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKeySize;
        private System.Windows.Forms.TextBox txtDN;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnSaveAsPFX;
        private System.Windows.Forms.Button btnSaveToCertStore;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpValidTo;
        private System.Windows.Forms.DateTimePicker dtpValidFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStoreName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboStoreLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel lnkTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtCert;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnVerifiy;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

