namespace KIDS_CheckIn_System.volunteers
{
    partial class frmVolunteerManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVolunteerManagement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkLeading = new System.Windows.Forms.CheckBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVGL = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameOnId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtNFCCode = new System.Windows.Forms.ToolStripTextBox();
            this.btnScan = new System.Windows.Forms.ToolStripButton();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.dgvVolunteers = new System.Windows.Forms.DataGridView();
            this.fldID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldNameOnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldVGL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.counter = new System.Windows.Forms.ToolStripStatusLabel();
            this.drpWeek = new System.Windows.Forms.ToolStripDropDownButton();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Week1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Week2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Week3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Week4 = new System.Windows.Forms.ToolStripMenuItem();
            this.drpStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tmrLogin = new System.Windows.Forms.Timer(this.components);
            this.btnTakePicture = new System.Windows.Forms.Button();
            this.btnbrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolunteers)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnbrowse);
            this.splitContainer1.Panel1.Controls.Add(this.btnTakePicture);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvVolunteers);
            this.splitContainer1.Panel2.Controls.Add(this.cboClass);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.cboService);
            this.splitContainer1.Panel2.Controls.Add(this.cboWeek);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Size = new System.Drawing.Size(663, 644);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkLeading);
            this.groupBox4.Controls.Add(this.txtContactNo);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtVGL);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(12, 252);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(639, 54);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Victory Group Details";
            // 
            // chkLeading
            // 
            this.chkLeading.AutoSize = true;
            this.chkLeading.Location = new System.Drawing.Point(503, 22);
            this.chkLeading.Name = "chkLeading";
            this.chkLeading.Size = new System.Drawing.Size(132, 19);
            this.chkLeading.TabIndex = 9;
            this.chkLeading.Text = "Leading a Group";
            this.chkLeading.UseVisualStyleBackColor = true;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(314, 20);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(160, 23);
            this.txtContactNo.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "Contact No";
            // 
            // txtVGL
            // 
            this.txtVGL.Location = new System.Drawing.Point(65, 20);
            this.txtVGL.Name = "txtVGL";
            this.txtVGL.Size = new System.Drawing.Size(160, 23);
            this.txtVGL.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "Leader";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(515, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(374, 119);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(125, 23);
            this.cboClass.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(311, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "Class";
            // 
            // cboWeek
            // 
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Items.AddRange(new object[] {
            "1st Week",
            "2nd Week",
            "3rd Week",
            "4th Week"});
            this.cboWeek.Location = new System.Drawing.Point(374, 90);
            this.cboWeek.Name = "cboWeek";
            this.cboWeek.Size = new System.Drawing.Size(125, 23);
            this.cboWeek.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Week";
            // 
            // cboService
            // 
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(374, 61);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(125, 23);
            this.cboService.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Service";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtStreet);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(326, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(61, 54);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(258, 23);
            this.txtCity.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "City";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(61, 25);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(258, 23);
            this.txtStreet.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Street";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNameOnId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNickName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 234);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(92, 202);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Mobile";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(92, 173);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(200, 23);
            this.txtMobile.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Email";
            // 
            // txtNameOnId
            // 
            this.txtNameOnId.Location = new System.Drawing.Point(92, 109);
            this.txtNameOnId.Name = "txtNameOnId";
            this.txtNameOnId.Size = new System.Drawing.Size(163, 23);
            this.txtNameOnId.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Name On ID";
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(92, 80);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(163, 23);
            this.txtNickName.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nick Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(92, 51);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(163, 23);
            this.txtLastName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(92, 22);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(163, 23);
            this.txtFirstName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "First Name";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnSave,
            this.btnDelete,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtSearch,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.txtNFCCode,
            this.btnScan,
            this.lblStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 313);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(663, 43);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 40);
            this.btnSave.Tag = "\"\"";
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(36, 40);
            this.btnDelete.Text = "toolStripButton2";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 40);
            this.toolStripLabel1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 43);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(30, 40);
            this.toolStripLabel2.Text = "NFC";
            // 
            // txtNFCCode
            // 
            this.txtNFCCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNFCCode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNFCCode.Name = "txtNFCCode";
            this.txtNFCCode.ReadOnly = true;
            this.txtNFCCode.Size = new System.Drawing.Size(100, 43);
            this.txtNFCCode.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnScan
            // 
            this.btnScan.Image = ((System.Drawing.Image)(resources.GetObject("btnScan.Image")));
            this.btnScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(94, 40);
            this.btnScan.Text = "Scan NFC";
            this.btnScan.ToolTipText = "Click to Enable NFC Card Reader";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 40);
            this.lblStatus.Text = "Status";
            // 
            // dgvVolunteers
            // 
            this.dgvVolunteers.AllowUserToAddRows = false;
            this.dgvVolunteers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvVolunteers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVolunteers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVolunteers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fldID,
            this.fldFirstName,
            this.fldLastName,
            this.fldNickName,
            this.fldNameOnID,
            this.fldService,
            this.fldWeek,
            this.fldClass,
            this.fldMobile,
            this.fldEmail,
            this.fldVGL});
            this.dgvVolunteers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVolunteers.Location = new System.Drawing.Point(0, 0);
            this.dgvVolunteers.Name = "dgvVolunteers";
            this.dgvVolunteers.RowHeadersVisible = false;
            this.dgvVolunteers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVolunteers.Size = new System.Drawing.Size(663, 262);
            this.dgvVolunteers.TabIndex = 1;
            this.dgvVolunteers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVolunteers_CellContentClick);
            // 
            // fldID
            // 
            this.fldID.HeaderText = "ID";
            this.fldID.Name = "fldID";
            this.fldID.ReadOnly = true;
            this.fldID.Width = 60;
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
            // fldNickName
            // 
            this.fldNickName.HeaderText = "Nick Name";
            this.fldNickName.Name = "fldNickName";
            this.fldNickName.ReadOnly = true;
            this.fldNickName.Width = 150;
            // 
            // fldNameOnID
            // 
            this.fldNameOnID.HeaderText = "Name On ID";
            this.fldNameOnID.Name = "fldNameOnID";
            this.fldNameOnID.ReadOnly = true;
            this.fldNameOnID.Width = 150;
            // 
            // fldService
            // 
            this.fldService.HeaderText = "Service";
            this.fldService.Name = "fldService";
            this.fldService.ReadOnly = true;
            this.fldService.Width = 60;
            // 
            // fldWeek
            // 
            this.fldWeek.HeaderText = "Week";
            this.fldWeek.Name = "fldWeek";
            this.fldWeek.ReadOnly = true;
            this.fldWeek.Width = 70;
            // 
            // fldClass
            // 
            this.fldClass.HeaderText = "Class";
            this.fldClass.Name = "fldClass";
            this.fldClass.ReadOnly = true;
            // 
            // fldMobile
            // 
            this.fldMobile.HeaderText = "Mobile";
            this.fldMobile.Name = "fldMobile";
            this.fldMobile.ReadOnly = true;
            // 
            // fldEmail
            // 
            this.fldEmail.HeaderText = "Email";
            this.fldEmail.Name = "fldEmail";
            this.fldEmail.ReadOnly = true;
            this.fldEmail.Width = 200;
            // 
            // fldVGL
            // 
            this.fldVGL.HeaderText = "Victory Group Leader";
            this.fldVGL.Name = "fldVGL";
            this.fldVGL.ReadOnly = true;
            this.fldVGL.Width = 200;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.counter,
            this.drpWeek,
            this.drpStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 262);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(663, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // counter
            // 
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(49, 17);
            this.counter.Text = "Count:0";
            // 
            // drpWeek
            // 
            this.drpWeek.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.drpWeek.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.Week1,
            this.Week2,
            this.Week3,
            this.Week4});
            this.drpWeek.Image = ((System.Drawing.Image)(resources.GetObject("drpWeek.Image")));
            this.drpWeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drpWeek.Name = "drpWeek";
            this.drpWeek.Size = new System.Drawing.Size(50, 20);
            this.drpWeek.Text = "All";
            this.drpWeek.Click += new System.EventHandler(this.drpWeek_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // Week1
            // 
            this.Week1.Name = "Week1";
            this.Week1.Size = new System.Drawing.Size(126, 22);
            this.Week1.Text = "1st Week";
            this.Week1.Click += new System.EventHandler(this.stWeekToolStripMenuItem_Click);
            // 
            // Week2
            // 
            this.Week2.Name = "Week2";
            this.Week2.Size = new System.Drawing.Size(126, 22);
            this.Week2.Text = "2nd Week";
            this.Week2.Click += new System.EventHandler(this.Week2_Click);
            // 
            // Week3
            // 
            this.Week3.Name = "Week3";
            this.Week3.Size = new System.Drawing.Size(126, 22);
            this.Week3.Text = "3rd Week";
            this.Week3.Click += new System.EventHandler(this.Week3_Click);
            // 
            // Week4
            // 
            this.Week4.Name = "Week4";
            this.Week4.Size = new System.Drawing.Size(126, 22);
            this.Week4.Text = "4th Week";
            this.Week4.Click += new System.EventHandler(this.Week4_Click);
            // 
            // drpStatus
            // 
            this.drpStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.notActiveToolStripMenuItem});
            this.drpStatus.Image = ((System.Drawing.Image)(resources.GetObject("drpStatus.Image")));
            this.drpStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drpStatus.Name = "drpStatus";
            this.drpStatus.Size = new System.Drawing.Size(107, 20);
            this.drpStatus.Text = "Status: Active";
            this.drpStatus.Click += new System.EventHandler(this.drpStatus_Click);
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.activeToolStripMenuItem.Text = "Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.activeToolStripMenuItem_Click);
            // 
            // notActiveToolStripMenuItem
            // 
            this.notActiveToolStripMenuItem.Name = "notActiveToolStripMenuItem";
            this.notActiveToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.notActiveToolStripMenuItem.Text = "Not Active";
            this.notActiveToolStripMenuItem.Click += new System.EventHandler(this.notActiveToolStripMenuItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tmrLogin
            // 
            this.tmrLogin.Tick += new System.EventHandler(this.tmrLogin_Tick);
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Location = new System.Drawing.Point(407, 116);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(102, 23);
            this.btnTakePicture.TabIndex = 29;
            this.btnTakePicture.Text = "Take Picture";
            this.btnTakePicture.UseVisualStyleBackColor = true;
            // 
            // btnbrowse
            // 
            this.btnbrowse.Location = new System.Drawing.Point(407, 87);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(102, 23);
            this.btnbrowse.TabIndex = 30;
            this.btnbrowse.Text = "Browse";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // frmVolunteerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 644);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmVolunteerManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volunteer Management";
            this.Load += new System.EventHandler(this.frmVolunteerManagement_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolunteers)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel counter;
        private System.Windows.Forms.ToolStripDropDownButton drpWeek;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Week4;
        private System.Windows.Forms.ToolStripMenuItem Week3;
        private System.Windows.Forms.ToolStripMenuItem Week2;
        private System.Windows.Forms.ToolStripMenuItem Week1;
        private System.Windows.Forms.DataGridView dgvVolunteers;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldNameOnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldService;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldVGL;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameOnId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboWeek;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVGL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkLeading;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtNFCCode;
        private System.Windows.Forms.ToolStripButton btnScan;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripDropDownButton drpStatus;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notActiveToolStripMenuItem;
        private System.Windows.Forms.Timer tmrLogin;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.Button btnTakePicture;
    }
}