namespace KIDS_CheckIn_System
{
    partial class frmClaimStubs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvReport
            // 
            this.gvReport.AllowUserToAddRows = false;
            this.gvReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gvReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.NickName,
            this.StudentID,
            this.Age,
            this.Group,
            this.Birthday,
            this.ID});
            this.gvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvReport.Location = new System.Drawing.Point(0, 0);
            this.gvReport.Name = "gvReport";
            this.gvReport.RowHeadersVisible = false;
            this.gvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvReport.Size = new System.Drawing.Size(379, 278);
            this.gvReport.TabIndex = 4;
            this.gvReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvReport_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 44);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(292, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FirstName.Width = 200;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LastName.Width = 200;
            // 
            // NickName
            // 
            this.NickName.HeaderText = "Nick Name";
            this.NickName.Name = "NickName";
            this.NickName.ReadOnly = true;
            this.NickName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NickName.Width = 150;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "Barcode";
            this.StudentID.Name = "StudentID";
            this.StudentID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StudentID.Width = 150;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Age.Width = 80;
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Birthday
            // 
            this.Birthday.HeaderText = "Birthday";
            this.Birthday.Name = "Birthday";
            this.Birthday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Birthday.Width = 250;
            // 
            // ID
            // 
            this.ID.HeaderText = "Claim Stub";
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmClaimStubs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 322);
            this.Controls.Add(this.gvReport);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmClaimStubs";
            this.Text = "Claim Stubs for Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClaimStubs_FormClosed);
            this.Load += new System.EventHandler(this.frmClaimStubs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ID;
        private System.Windows.Forms.Timer timer1;

    }
}