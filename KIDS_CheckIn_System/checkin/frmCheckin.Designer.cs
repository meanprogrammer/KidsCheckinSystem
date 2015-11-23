namespace KIDS_CheckIn_System
{
    partial class frmCheckin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckin));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtService = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAge2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAge1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KidID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pic1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pFetchers = new System.Windows.Forms.Panel();
            this.lblName3 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNFC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAllergies = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBirthday = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbImageKid = new System.Windows.Forms.PictureBox();
            this.pkids = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblKName = new System.Windows.Forms.Label();
            this.pbK1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBarcode = new System.Windows.Forms.RadioButton();
            this.rbNFC = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCheckout = new System.Windows.Forms.RadioButton();
            this.rbCheckin = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrReader = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.pFetchers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageKid)).BeginInit();
            this.pkids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbK1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtService);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txtAge2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtAge1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblDateTime);
            this.splitContainer1.Panel1.Controls.Add(this.txtRoom);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 782);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtService
            // 
            this.txtService.Location = new System.Drawing.Point(496, 27);
            this.txtService.Name = "txtService";
            this.txtService.ReadOnly = true;
            this.txtService.Size = new System.Drawing.Size(163, 25);
            this.txtService.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Service";
            // 
            // txtAge2
            // 
            this.txtAge2.Location = new System.Drawing.Point(365, 27);
            this.txtAge2.Name = "txtAge2";
            this.txtAge2.ReadOnly = true;
            this.txtAge2.Size = new System.Drawing.Size(62, 25);
            this.txtAge2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "To";
            // 
            // txtAge1
            // 
            this.txtAge1.Location = new System.Drawing.Point(268, 27);
            this.txtAge1.Name = "txtAge1";
            this.txtAge1.ReadOnly = true;
            this.txtAge1.Size = new System.Drawing.Size(62, 25);
            this.txtAge1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "From Age";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.Location = new System.Drawing.Point(1009, 30);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(259, 17);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "Date and Time";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(66, 27);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.Size = new System.Drawing.Size(118, 25);
            this.txtRoom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1280, 707);
            this.splitContainer2.SplitterDistance = 230;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KidID,
            this.Pic1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(230, 707);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // KidID
            // 
            this.KidID.HeaderText = "KidID";
            this.KidID.Name = "KidID";
            this.KidID.ReadOnly = true;
            this.KidID.Visible = false;
            this.KidID.Width = 5;
            // 
            // Pic1
            // 
            this.Pic1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pic1.DividerWidth = 1;
            this.Pic1.HeaderText = "Kids";
            this.Pic1.Image = ((System.Drawing.Image)(resources.GetObject("Pic1.Image")));
            this.Pic1.Name = "Pic1";
            this.Pic1.ReadOnly = true;
            this.Pic1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pic1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pFetchers);
            this.splitContainer3.Panel1.Controls.Add(this.txtBarcode);
            this.splitContainer3.Panel1.Controls.Add(this.label8);
            this.splitContainer3.Panel1.Controls.Add(this.txtNFC);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.txtAllergies);
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            this.splitContainer3.Panel1.Controls.Add(this.txtBirthday);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.txtName);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.pbImageKid);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pkids);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer3.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer3.Panel2.Controls.Add(this.linkLabel1);
            this.splitContainer3.Panel2.Controls.Add(this.txtNote);
            this.splitContainer3.Size = new System.Drawing.Size(1046, 662);
            this.splitContainer3.SplitterDistance = 355;
            this.splitContainer3.TabIndex = 1;
            // 
            // pFetchers
            // 
            this.pFetchers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pFetchers.Controls.Add(this.lblName3);
            this.pFetchers.Controls.Add(this.lblName2);
            this.pFetchers.Controls.Add(this.lblName1);
            this.pFetchers.Controls.Add(this.pb3);
            this.pFetchers.Controls.Add(this.pb2);
            this.pFetchers.Controls.Add(this.pb1);
            this.pFetchers.Location = new System.Drawing.Point(-1, 3);
            this.pFetchers.Name = "pFetchers";
            this.pFetchers.Size = new System.Drawing.Size(1045, 349);
            this.pFetchers.TabIndex = 19;
            this.pFetchers.Visible = false;
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Location = new System.Drawing.Point(640, 221);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(47, 17);
            this.lblName3.TabIndex = 5;
            this.lblName3.Text = "Name";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(410, 221);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(47, 17);
            this.lblName2.TabIndex = 4;
            this.lblName2.Text = "Name";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(179, 221);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(47, 17);
            this.lblName1.TabIndex = 3;
            this.lblName1.Text = "Name";
            // 
            // pb3
            // 
            this.pb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb3.Location = new System.Drawing.Point(643, 43);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(180, 170);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb3.TabIndex = 2;
            this.pb3.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb2.Location = new System.Drawing.Point(413, 43);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(180, 170);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb2.TabIndex = 1;
            this.pb2.TabStop = false;
            // 
            // pb1
            // 
            this.pb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb1.Location = new System.Drawing.Point(182, 43);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(180, 170);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtBarcode.Location = new System.Drawing.Point(583, 269);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(221, 25);
            this.txtBarcode.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(514, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Barcode";
            // 
            // txtNFC
            // 
            this.txtNFC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNFC.Location = new System.Drawing.Point(583, 238);
            this.txtNFC.Name = "txtNFC";
            this.txtNFC.ReadOnly = true;
            this.txtNFC.Size = new System.Drawing.Size(221, 25);
            this.txtNFC.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(514, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "NFC";
            // 
            // txtAllergies
            // 
            this.txtAllergies.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAllergies.Location = new System.Drawing.Point(439, 300);
            this.txtAllergies.Name = "txtAllergies";
            this.txtAllergies.ReadOnly = true;
            this.txtAllergies.Size = new System.Drawing.Size(221, 25);
            this.txtAllergies.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Allergies";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtBirthday.Location = new System.Drawing.Point(287, 269);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.ReadOnly = true;
            this.txtBirthday.Size = new System.Drawing.Size(221, 25);
            this.txtBirthday.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Birthday";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtName.Location = new System.Drawing.Point(287, 238);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(221, 25);
            this.txtName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            // 
            // pbImageKid
            // 
            this.pbImageKid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbImageKid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImageKid.Location = new System.Drawing.Point(412, 29);
            this.pbImageKid.Name = "pbImageKid";
            this.pbImageKid.Size = new System.Drawing.Size(262, 203);
            this.pbImageKid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImageKid.TabIndex = 8;
            this.pbImageKid.TabStop = false;
            // 
            // pkids
            // 
            this.pkids.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pkids.Controls.Add(this.btnConfirm);
            this.pkids.Controls.Add(this.btnScan);
            this.pkids.Controls.Add(this.lblBirthday);
            this.pkids.Controls.Add(this.lblBarcode);
            this.pkids.Controls.Add(this.lblKName);
            this.pkids.Controls.Add(this.pbK1);
            this.pkids.Location = new System.Drawing.Point(-1, 3);
            this.pkids.Name = "pkids";
            this.pkids.Size = new System.Drawing.Size(1045, 241);
            this.pkids.TabIndex = 20;
            this.pkids.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(446, 168);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(147, 23);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm Check-Out";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(446, 139);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(114, 23);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Scan Barcode";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(443, 109);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(61, 17);
            this.lblBirthday.TabIndex = 3;
            this.lblBirthday.Text = "Birthday";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(443, 71);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(63, 17);
            this.lblBarcode.TabIndex = 2;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblKName
            // 
            this.lblKName.AutoSize = true;
            this.lblKName.Location = new System.Drawing.Point(443, 37);
            this.lblKName.Name = "lblKName";
            this.lblKName.Size = new System.Drawing.Size(47, 17);
            this.lblKName.TabIndex = 1;
            this.lblKName.Text = "Name";
            // 
            // pbK1
            // 
            this.pbK1.ErrorImage = null;
            this.pbK1.Image = ((System.Drawing.Image)(resources.GetObject("pbK1.Image")));
            this.pbK1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbK1.InitialImage")));
            this.pbK1.Location = new System.Drawing.Point(217, 26);
            this.pbK1.Name = "pbK1";
            this.pbK1.Size = new System.Drawing.Size(219, 187);
            this.pbK1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbK1.TabIndex = 0;
            this.pbK1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbBarcode);
            this.groupBox1.Controls.Add(this.rbNFC);
            this.groupBox1.Location = new System.Drawing.Point(9, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 46);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // rbBarcode
            // 
            this.rbBarcode.AutoSize = true;
            this.rbBarcode.Location = new System.Drawing.Point(108, 18);
            this.rbBarcode.Name = "rbBarcode";
            this.rbBarcode.Size = new System.Drawing.Size(81, 21);
            this.rbBarcode.TabIndex = 6;
            this.rbBarcode.Text = "Barcode";
            this.rbBarcode.UseVisualStyleBackColor = true;
            this.rbBarcode.CheckedChanged += new System.EventHandler(this.rbBarcode_CheckedChanged);
            // 
            // rbNFC
            // 
            this.rbNFC.AutoSize = true;
            this.rbNFC.Checked = true;
            this.rbNFC.Location = new System.Drawing.Point(16, 18);
            this.rbNFC.Name = "rbNFC";
            this.rbNFC.Size = new System.Drawing.Size(56, 21);
            this.rbNFC.TabIndex = 5;
            this.rbNFC.TabStop = true;
            this.rbNFC.Text = "NFC";
            this.rbNFC.UseVisualStyleBackColor = true;
            this.rbNFC.CheckedChanged += new System.EventHandler(this.rbNFC_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(979, 254);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(67, 17);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add Note";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Location = new System.Drawing.Point(8, 29);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(1046, 219);
            this.txtNote.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCheckout);
            this.panel1.Controls.Add(this.rbCheckin);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 662);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 45);
            this.panel1.TabIndex = 0;
            // 
            // rbCheckout
            // 
            this.rbCheckout.AutoSize = true;
            this.rbCheckout.Location = new System.Drawing.Point(100, 12);
            this.rbCheckout.Name = "rbCheckout";
            this.rbCheckout.Size = new System.Drawing.Size(97, 21);
            this.rbCheckout.TabIndex = 2;
            this.rbCheckout.Text = "Check-Out";
            this.rbCheckout.UseVisualStyleBackColor = true;
            // 
            // rbCheckin
            // 
            this.rbCheckin.AutoSize = true;
            this.rbCheckin.Checked = true;
            this.rbCheckin.Location = new System.Drawing.Point(8, 12);
            this.rbCheckin.Name = "rbCheckin";
            this.rbCheckin.Size = new System.Drawing.Size(86, 21);
            this.rbCheckin.TabIndex = 1;
            this.rbCheckin.TabStop = true;
            this.rbCheckin.Text = "Check-IN";
            this.rbCheckin.UseVisualStyleBackColor = true;
            this.rbCheckin.CheckedChanged += new System.EventHandler(this.rbCheckin_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(959, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrReader
            // 
            this.tmrReader.Enabled = true;
            this.tmrReader.Tick += new System.EventHandler(this.tmrReader_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmCheckin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 782);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCheckin";
            this.Text = "Checkin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCheckin_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.pFetchers.ResumeLayout(false);
            this.pFetchers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageKid)).EndInit();
            this.pkids.ResumeLayout(false);
            this.pkids.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbK1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtAge2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAge1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer tmrReader;
        private System.Windows.Forms.DataGridViewTextBoxColumn KidID;
        private System.Windows.Forms.DataGridViewImageColumn Pic1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBirthday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbImageKid;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNFC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbCheckout;
        private System.Windows.Forms.RadioButton rbCheckin;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbBarcode;
        private System.Windows.Forms.RadioButton rbNFC;
        private System.Windows.Forms.Panel pFetchers;
        private System.Windows.Forms.Panel pkids;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.PictureBox pbK1;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblKName;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Timer timer2;
    }
}