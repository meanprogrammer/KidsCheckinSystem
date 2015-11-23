namespace KIDS_CheckIn_System.admin
{
    partial class frmEventRoom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtMaxCap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtAgeTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgeFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fldID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldAgeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldAgeTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldMaxCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtMaxCap);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.txtAgeTo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtAgeFrom);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cboRoom);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(344, 370);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtMaxCap
            // 
            this.txtMaxCap.Location = new System.Drawing.Point(289, 51);
            this.txtMaxCap.MaxLength = 3;
            this.txtMaxCap.Name = "txtMaxCap";
            this.txtMaxCap.Size = new System.Drawing.Size(48, 23);
            this.txtMaxCap.TabIndex = 9;
            this.txtMaxCap.Text = "0";
            this.txtMaxCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxCap.Click += new System.EventHandler(this.txtMaxCap_Click);
            this.txtMaxCap.TextChanged += new System.EventHandler(this.txtMaxCap_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Cap.";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 86);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtAgeTo
            // 
            this.txtAgeTo.Location = new System.Drawing.Point(166, 51);
            this.txtAgeTo.MaxLength = 2;
            this.txtAgeTo.Name = "txtAgeTo";
            this.txtAgeTo.Size = new System.Drawing.Size(48, 23);
            this.txtAgeTo.TabIndex = 6;
            this.txtAgeTo.Text = "0";
            this.txtAgeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAgeTo.Click += new System.EventHandler(this.txtAgeTo_Click);
            this.txtAgeTo.TextChanged += new System.EventHandler(this.txtAgeTo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "To";
            // 
            // txtAgeFrom
            // 
            this.txtAgeFrom.Location = new System.Drawing.Point(83, 51);
            this.txtAgeFrom.MaxLength = 2;
            this.txtAgeFrom.Name = "txtAgeFrom";
            this.txtAgeFrom.Size = new System.Drawing.Size(48, 23);
            this.txtAgeFrom.TabIndex = 4;
            this.txtAgeFrom.Text = "0";
            this.txtAgeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAgeFrom.Click += new System.EventHandler(this.txtAgeFrom_Click);
            this.txtAgeFrom.TextChanged += new System.EventHandler(this.txtAgeFrom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "From Age";
            // 
            // cboRoom
            // 
            this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(83, 18);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(159, 23);
            this.cboRoom.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 86);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(165, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fldID,
            this.fldRoom,
            this.fldAgeFrom,
            this.fldAgeTo,
            this.fldMaxCapacity});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(344, 252);
            this.dataGridView1.TabIndex = 1;
            // 
            // fldID
            // 
            this.fldID.HeaderText = "ID";
            this.fldID.Name = "fldID";
            this.fldID.ReadOnly = true;
            this.fldID.Visible = false;
            // 
            // fldRoom
            // 
            this.fldRoom.HeaderText = "Room";
            this.fldRoom.Name = "fldRoom";
            this.fldRoom.ReadOnly = true;
            this.fldRoom.Width = 141;
            // 
            // fldAgeFrom
            // 
            this.fldAgeFrom.HeaderText = "Age From";
            this.fldAgeFrom.Name = "fldAgeFrom";
            this.fldAgeFrom.ReadOnly = true;
            this.fldAgeFrom.Width = 50;
            // 
            // fldAgeTo
            // 
            this.fldAgeTo.HeaderText = "Age To";
            this.fldAgeTo.Name = "fldAgeTo";
            this.fldAgeTo.ReadOnly = true;
            this.fldAgeTo.Width = 50;
            // 
            // fldMaxCapacity
            // 
            this.fldMaxCapacity.HeaderText = "Max Cap";
            this.fldMaxCapacity.Name = "fldMaxCapacity";
            this.fldMaxCapacity.ReadOnly = true;
            // 
            // frmEventRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 370);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmEventRoom";
            this.Text = "Rooms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEventRoom_FormClosing);
            this.Load += new System.EventHandler(this.frmEventRoom_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAgeTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtMaxCap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldAgeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldAgeTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldMaxCapacity;

    }
}