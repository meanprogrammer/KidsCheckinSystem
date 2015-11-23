namespace KIDS_CheckIn_System
{
    partial class frmEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvents));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.dtRegis = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEventTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldEventTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldRegistrationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblID);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.dtRegis);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndTime);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartTime);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtEventTitle);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvEvents);
            this.splitContainer1.Size = new System.Drawing.Size(463, 393);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(463, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Add";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "Edit";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "Save";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton4.Text = "Delete";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // dtRegis
            // 
            this.dtRegis.Enabled = false;
            this.dtRegis.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtRegis.Location = new System.Drawing.Point(127, 138);
            this.dtRegis.Name = "dtRegis";
            this.dtRegis.Size = new System.Drawing.Size(179, 22);
            this.dtRegis.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Registration Time";
            // 
            // dtEndTime
            // 
            this.dtEndTime.Enabled = false;
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEndTime.Location = new System.Drawing.Point(127, 110);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(179, 22);
            this.dtEndTime.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Time";
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "hh:mm tt";
            this.dtStartTime.Enabled = false;
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(127, 82);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(179, 22);
            this.dtStartTime.TabIndex = 4;
            this.dtStartTime.Value = new System.DateTime(2014, 8, 11, 14, 42, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Time";
            // 
            // txtEventTitle
            // 
            this.txtEventTitle.Enabled = false;
            this.txtEventTitle.Location = new System.Drawing.Point(127, 54);
            this.txtEventTitle.Name = "txtEventTitle";
            this.txtEventTitle.Size = new System.Drawing.Size(179, 22);
            this.txtEventTitle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Event Title";
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
            this.fldEventTitle,
            this.fldStartTime,
            this.fldEndTime,
            this.fldRegistrationTime});
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(0, 0);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowHeadersWidth = 10;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(463, 165);
            this.dgvEvents.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // fldEventTitle
            // 
            this.fldEventTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fldEventTitle.HeaderText = "Event Title";
            this.fldEventTitle.Name = "fldEventTitle";
            this.fldEventTitle.ReadOnly = true;
            // 
            // fldStartTime
            // 
            this.fldStartTime.HeaderText = "Start Time";
            this.fldStartTime.Name = "fldStartTime";
            this.fldStartTime.ReadOnly = true;
            // 
            // fldEndTime
            // 
            this.fldEndTime.HeaderText = "End Time";
            this.fldEndTime.Name = "fldEndTime";
            this.fldEndTime.ReadOnly = true;
            // 
            // fldRegistrationTime
            // 
            this.fldRegistrationTime.HeaderText = "Registration Time";
            this.fldRegistrationTime.Name = "fldRegistrationTime";
            this.fldRegistrationTime.ReadOnly = true;
            this.fldRegistrationTime.Width = 151;
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Location = new System.Drawing.Point(394, 183);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(57, 32);
            this.lblID.TabIndex = 9;
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblID.Visible = false;
            // 
            // frmEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 393);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEvents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Events";
            this.Load += new System.EventHandler(this.frmEvents_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.DateTimePicker dtRegis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEventTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldEventTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldRegistrationTime;
        private System.Windows.Forms.Label lblID;
    }
}