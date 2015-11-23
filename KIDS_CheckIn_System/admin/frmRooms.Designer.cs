namespace KIDS_CheckIn_System.admin
{
    partial class frmRooms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRooms));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxCap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAge2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAge1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.lblID = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldAge1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldAge2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldMaxCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldEnableAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(255, 41);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 38);
            this.toolStripButton3.Text = "Edit";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 38);
            this.toolStripButton2.Text = "Save";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 38);
            this.toolStripButton4.Text = "Delete";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtRoom);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvEvents);
            this.splitContainer1.Panel2.Controls.Add(this.txtAge1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.cboGroup);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtMaxCap);
            this.splitContainer1.Panel2.Controls.Add(this.txtAge2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.chkAll);
            this.splitContainer1.Size = new System.Drawing.Size(255, 400);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 2;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAll.Location = new System.Drawing.Point(208, 162);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(134, 16);
            this.chkAll.TabIndex = 10;
            this.chkAll.Text = "Enable on All Group";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            // 
            // cboGroup
            // 
            this.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(294, 110);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(121, 20);
            this.cboGroup.TabIndex = 9;
            this.cboGroup.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Group";
            this.label5.Visible = false;
            // 
            // txtMaxCap
            // 
            this.txtMaxCap.Location = new System.Drawing.Point(294, 136);
            this.txtMaxCap.MaxLength = 3;
            this.txtMaxCap.Name = "txtMaxCap";
            this.txtMaxCap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMaxCap.Size = new System.Drawing.Size(48, 20);
            this.txtMaxCap.TabIndex = 7;
            this.txtMaxCap.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Capacity";
            this.label4.Visible = false;
            // 
            // txtAge2
            // 
            this.txtAge2.Location = new System.Drawing.Point(107, 164);
            this.txtAge2.MaxLength = 2;
            this.txtAge2.Name = "txtAge2";
            this.txtAge2.Size = new System.Drawing.Size(50, 20);
            this.txtAge2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "To Age";
            // 
            // txtAge1
            // 
            this.txtAge1.Location = new System.Drawing.Point(107, 138);
            this.txtAge1.MaxLength = 2;
            this.txtAge1.Name = "txtAge1";
            this.txtAge1.Size = new System.Drawing.Size(50, 20);
            this.txtAge1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "From Age";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(88, 18);
            this.txtRoom.MaxLength = 50;
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(118, 20);
            this.txtRoom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room Name";
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvEvents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.fldRoom,
            this.fldAge1,
            this.fldAge2,
            this.fldMaxCap,
            this.fldGroup,
            this.fldEnableAll});
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(0, 0);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowHeadersVisible = false;
            this.dgvEvents.RowHeadersWidth = 10;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(255, 336);
            this.dgvEvents.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Location = new System.Drawing.Point(164, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(79, 25);
            this.lblID.TabIndex = 10;
            this.lblID.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // fldRoom
            // 
            this.fldRoom.HeaderText = "Room";
            this.fldRoom.Name = "fldRoom";
            this.fldRoom.ReadOnly = true;
            this.fldRoom.Width = 200;
            // 
            // fldAge1
            // 
            this.fldAge1.HeaderText = "From Age";
            this.fldAge1.Name = "fldAge1";
            this.fldAge1.ReadOnly = true;
            this.fldAge1.Visible = false;
            // 
            // fldAge2
            // 
            this.fldAge2.HeaderText = "To Age";
            this.fldAge2.Name = "fldAge2";
            this.fldAge2.ReadOnly = true;
            this.fldAge2.Visible = false;
            // 
            // fldMaxCap
            // 
            this.fldMaxCap.HeaderText = "Max";
            this.fldMaxCap.Name = "fldMaxCap";
            this.fldMaxCap.ReadOnly = true;
            this.fldMaxCap.Visible = false;
            this.fldMaxCap.Width = 50;
            // 
            // fldGroup
            // 
            this.fldGroup.HeaderText = "Group";
            this.fldGroup.Name = "fldGroup";
            this.fldGroup.ReadOnly = true;
            this.fldGroup.Visible = false;
            // 
            // fldEnableAll
            // 
            this.fldEnableAll.HeaderText = "Enable On ALl";
            this.fldEnableAll.Name = "fldEnableAll";
            this.fldEnableAll.ReadOnly = true;
            this.fldEnableAll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fldEnableAll.Visible = false;
            // 
            // frmRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 441);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRooms";
            this.Text = "Room Maintenance";
            this.Load += new System.EventHandler(this.frmRooms_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxCap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAge2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAge1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGroup;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldAge1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldAge2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldMaxCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldEnableAll;

    }
}