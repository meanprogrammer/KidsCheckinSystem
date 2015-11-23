namespace KIDS_CheckIn_System
{
    partial class frmVolunteers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVolunteers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLogout = new System.Windows.Forms.RadioButton();
            this.rbLogin = new System.Windows.Forms.RadioButton();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fldID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrLogin = new System.Windows.Forms.Timer(this.components);
            this.lblNotification = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblDateTime);
            this.splitContainer1.Panel1.Controls.Add(this.lblNotification);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblClass);
            this.splitContainer1.Panel1.Controls.Add(this.lblWeek);
            this.splitContainer1.Panel1.Controls.Add(this.lblService);
            this.splitContainer1.Panel1.Controls.Add(this.lblName);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(903, 669);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbLogout);
            this.groupBox1.Controls.Add(this.rbLogin);
            this.groupBox1.Location = new System.Drawing.Point(786, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // rbLogout
            // 
            this.rbLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbLogout.AutoSize = true;
            this.rbLogout.Location = new System.Drawing.Point(27, 47);
            this.rbLogout.Name = "rbLogout";
            this.rbLogout.Size = new System.Drawing.Size(75, 19);
            this.rbLogout.TabIndex = 1;
            this.rbLogout.TabStop = true;
            this.rbLogout.Text = "Log Out";
            this.rbLogout.UseVisualStyleBackColor = true;
            // 
            // rbLogin
            // 
            this.rbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbLogin.AutoSize = true;
            this.rbLogin.Checked = true;
            this.rbLogin.Location = new System.Drawing.Point(27, 22);
            this.rbLogin.Name = "rbLogin";
            this.rbLogin.Size = new System.Drawing.Size(64, 19);
            this.rbLogin.TabIndex = 0;
            this.rbLogin.TabStop = true;
            this.rbLogin.Text = "Log In";
            this.rbLogin.UseVisualStyleBackColor = true;
            // 
            // lblClass
            // 
            this.lblClass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(429, 244);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(43, 15);
            this.lblClass.TabIndex = 4;
            this.lblClass.Text = "Class";
            // 
            // lblWeek
            // 
            this.lblWeek.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(556, 197);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(42, 15);
            this.lblWeek.TabIndex = 3;
            this.lblWeek.Text = "Week";
            // 
            // lblService
            // 
            this.lblService.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(302, 197);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(57, 15);
            this.lblService.TabIndex = 2;
            this.lblService.Text = "Service";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(396, 160);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(119, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Volunteers Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(373, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fldID,
            this.fldFirstName,
            this.fldLastName,
            this.fldService,
            this.Week,
            this.Column1,
            this.fldTimeIn,
            this.fldTimeOut});
            this.dataGridView1.Location = new System.Drawing.Point(12, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(879, 272);
            this.dataGridView1.TabIndex = 0;
            // 
            // fldID
            // 
            this.fldID.HeaderText = "ID";
            this.fldID.Name = "fldID";
            this.fldID.ReadOnly = true;
            this.fldID.Width = 70;
            // 
            // fldFirstName
            // 
            this.fldFirstName.HeaderText = "First Name";
            this.fldFirstName.Name = "fldFirstName";
            this.fldFirstName.ReadOnly = true;
            this.fldFirstName.Width = 150;
            // 
            // fldLastName
            // 
            this.fldLastName.HeaderText = "Last Name";
            this.fldLastName.Name = "fldLastName";
            this.fldLastName.ReadOnly = true;
            this.fldLastName.Width = 150;
            // 
            // fldService
            // 
            this.fldService.HeaderText = "Service";
            this.fldService.Name = "fldService";
            this.fldService.ReadOnly = true;
            // 
            // Week
            // 
            this.Week.HeaderText = "Week";
            this.Week.Name = "Week";
            this.Week.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Class";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // fldTimeIn
            // 
            this.fldTimeIn.HeaderText = "Time In";
            this.fldTimeIn.Name = "fldTimeIn";
            this.fldTimeIn.ReadOnly = true;
            // 
            // fldTimeOut
            // 
            this.fldTimeOut.HeaderText = "Time Out";
            this.fldTimeOut.Name = "fldTimeOut";
            this.fldTimeOut.ReadOnly = true;
            // 
            // tmrLogin
            // 
            this.tmrLogin.Enabled = true;
            this.tmrLogin.Tick += new System.EventHandler(this.tmrLogin_Tick);
            // 
            // lblNotification
            // 
            this.lblNotification.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNotification.AutoSize = true;
            this.lblNotification.Location = new System.Drawing.Point(396, 338);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(122, 15);
            this.lblNotification.TabIndex = 6;
            this.lblNotification.Text = "Please Scan Card";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.Location = new System.Drawing.Point(559, 12);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(332, 21);
            this.lblDateTime.TabIndex = 7;
            this.lblDateTime.Text = "Please Scan Card";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmVolunteers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(903, 669);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmVolunteers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volunteer Checkin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVolunteers_FormClosed);
            this.Load += new System.EventHandler(this.frmVolunteers_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldTimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldTimeOut;
        private System.Windows.Forms.Timer tmrLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLogout;
        private System.Windows.Forms.RadioButton rbLogin;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
    }
}