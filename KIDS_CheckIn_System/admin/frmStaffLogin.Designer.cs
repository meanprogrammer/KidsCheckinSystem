namespace KIDS_CheckIn_System.admin
{
    partial class frmStaffLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffLogin));
            this.gbStaffName = new System.Windows.Forms.GroupBox();
            this.lblNFC = new System.Windows.Forms.Label();
            this.lblNotification = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbStaffName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStaffName
            // 
            this.gbStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStaffName.BackColor = System.Drawing.Color.Transparent;
            this.gbStaffName.Controls.Add(this.lblNFC);
            this.gbStaffName.Location = new System.Drawing.Point(12, 35);
            this.gbStaffName.Name = "gbStaffName";
            this.gbStaffName.Size = new System.Drawing.Size(330, 116);
            this.gbStaffName.TabIndex = 0;
            this.gbStaffName.TabStop = false;
            this.gbStaffName.Text = "Staff Name";
            // 
            // lblNFC
            // 
            this.lblNFC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNFC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNFC.Location = new System.Drawing.Point(6, 29);
            this.lblNFC.Name = "lblNFC";
            this.lblNFC.Size = new System.Drawing.Size(318, 69);
            this.lblNFC.TabIndex = 0;
            this.lblNFC.Text = "NFC Code";
            this.lblNFC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.BackColor = System.Drawing.Color.Transparent;
            this.lblNotification.Location = new System.Drawing.Point(12, 9);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(122, 15);
            this.lblNotification.TabIndex = 1;
            this.lblNotification.Text = "Please Scan Card";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 157);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmStaffLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 189);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.gbStaffName);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "frmStaffLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStaffLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmStaffLogin_Load);
            this.gbStaffName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStaffName;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblNFC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCancel;
    }
}