namespace KIDS_CheckIn_System
{
    partial class frmCheckOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckOut));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNotification = new System.Windows.Forms.Label();
            this.rbBarcode = new System.Windows.Forms.RadioButton();
            this.rbNFC = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblName3 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.pbLoading = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblKName = new System.Windows.Forms.Label();
            this.pbK1 = new System.Windows.Forms.PictureBox();
            this.tmrReader = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnScan = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbK1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.lblNotification);
            this.panel1.Controls.Add(this.rbBarcode);
            this.panel1.Controls.Add(this.rbNFC);
            this.panel1.Controls.Add(this.btnBarcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 580);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 45);
            this.panel1.TabIndex = 0;
            // 
            // lblNotification
            // 
            this.lblNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotification.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.Location = new System.Drawing.Point(552, 9);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(419, 23);
            this.lblNotification.TabIndex = 11;
            this.lblNotification.Text = "Please Scan Card";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbBarcode
            // 
            this.rbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbBarcode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBarcode.AutoSize = true;
            this.rbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBarcode.Location = new System.Drawing.Point(69, 6);
            this.rbBarcode.Name = "rbBarcode";
            this.rbBarcode.Size = new System.Drawing.Size(79, 30);
            this.rbBarcode.TabIndex = 10;
            this.rbBarcode.Text = "Barcode";
            this.rbBarcode.UseVisualStyleBackColor = true;
            this.rbBarcode.CheckedChanged += new System.EventHandler(this.rbBarcode_CheckedChanged);
            // 
            // rbNFC
            // 
            this.rbNFC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbNFC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbNFC.AutoSize = true;
            this.rbNFC.Checked = true;
            this.rbNFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNFC.Location = new System.Drawing.Point(12, 6);
            this.rbNFC.Name = "rbNFC";
            this.rbNFC.Size = new System.Drawing.Size(51, 30);
            this.rbNFC.TabIndex = 9;
            this.rbNFC.TabStop = true;
            this.rbNFC.Text = "NFC";
            this.rbNFC.UseVisualStyleBackColor = true;
            this.rbNFC.CheckedChanged += new System.EventHandler(this.rbNFC_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblName3);
            this.splitContainer1.Panel1.Controls.Add(this.lblName2);
            this.splitContainer1.Panel1.Controls.Add(this.lblName1);
            this.splitContainer1.Panel1.Controls.Add(this.pb3);
            this.splitContainer1.Panel1.Controls.Add(this.pb2);
            this.splitContainer1.Panel1.Controls.Add(this.pb1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbLoading);
            this.splitContainer1.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainer1.Panel2.Controls.Add(this.btnScan);
            this.splitContainer1.Panel2.Controls.Add(this.lblBirthday);
            this.splitContainer1.Panel2.Controls.Add(this.lblBarcode);
            this.splitContainer1.Panel2.Controls.Add(this.lblKName);
            this.splitContainer1.Panel2.Controls.Add(this.pbK1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Size = new System.Drawing.Size(983, 580);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblName3
            // 
            this.lblName3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName3.AutoSize = true;
            this.lblName3.Location = new System.Drawing.Point(630, 227);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(51, 20);
            this.lblName3.TabIndex = 11;
            this.lblName3.Text = "Name";
            // 
            // lblName2
            // 
            this.lblName2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(400, 227);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(51, 20);
            this.lblName2.TabIndex = 10;
            this.lblName2.Text = "Name";
            // 
            // lblName1
            // 
            this.lblName1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(169, 227);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(51, 20);
            this.lblName1.TabIndex = 9;
            this.lblName1.Text = "Name";
            // 
            // pb3
            // 
            this.pb3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb3.Location = new System.Drawing.Point(633, 49);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(180, 170);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb3.TabIndex = 8;
            this.pb3.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb2.Location = new System.Drawing.Point(403, 49);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(180, 170);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb2.TabIndex = 7;
            this.pb2.TabStop = false;
            // 
            // pb1
            // 
            this.pb1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb1.Location = new System.Drawing.Point(172, 49);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(180, 170);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb1.TabIndex = 6;
            this.pb1.TabStop = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLoading.AutoSize = true;
            this.pbLoading.ForeColor = System.Drawing.Color.DarkRed;
            this.pbLoading.Location = new System.Drawing.Point(287, 0);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(309, 20);
            this.pbLoading.TabIndex = 41;
            this.pbLoading.Text = "Connecting to Paired Devices. Please Wait";
            this.pbLoading.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(532, 163);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(167, 74);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm Check-Out";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblBirthday
            // 
            this.lblBirthday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(529, 133);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(67, 20);
            this.lblBirthday.TabIndex = 9;
            this.lblBirthday.Text = "Birthday";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(529, 95);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(69, 20);
            this.lblBarcode.TabIndex = 8;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblKName
            // 
            this.lblKName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblKName.AutoSize = true;
            this.lblKName.Location = new System.Drawing.Point(529, 61);
            this.lblKName.Name = "lblKName";
            this.lblKName.Size = new System.Drawing.Size(51, 20);
            this.lblKName.TabIndex = 7;
            this.lblKName.Text = "Name";
            // 
            // pbK1
            // 
            this.pbK1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbK1.ErrorImage = null;
            this.pbK1.Image = ((System.Drawing.Image)(resources.GetObject("pbK1.Image")));
            this.pbK1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbK1.InitialImage")));
            this.pbK1.Location = new System.Drawing.Point(303, 50);
            this.pbK1.Name = "pbK1";
            this.pbK1.Size = new System.Drawing.Size(219, 187);
            this.pbK1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbK1.TabIndex = 6;
            this.pbK1.TabStop = false;
            // 
            // tmrReader
            // 
            this.tmrReader.Interval = 1;
            this.tmrReader.Tick += new System.EventHandler(this.tmrReader_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnScan.Location = new System.Drawing.Point(532, 163);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(167, 33);
            this.btnScan.TabIndex = 10;
            this.btnScan.Text = "Scan Barcode";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Visible = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Location = new System.Drawing.Point(154, 12);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(230, 20);
            this.txtBarcode.TabIndex = 12;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Location = new System.Drawing.Point(362, 13);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(22, 19);
            this.btnBarcode.TabIndex = 13;
            this.btnBarcode.Text = "button1";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // frmCheckOut
            // 
            this.AcceptButton = this.btnBarcode;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 625);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Out";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCheckOut_FormClosed);
            this.Load += new System.EventHandler(this.frmCheckOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbK1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblKName;
        private System.Windows.Forms.PictureBox pbK1;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.Timer tmrReader;
        private System.Windows.Forms.RadioButton rbBarcode;
        private System.Windows.Forms.RadioButton rbNFC;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Label pbLoading;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnBarcode;

    }
}