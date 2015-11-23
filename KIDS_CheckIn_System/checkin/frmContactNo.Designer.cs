namespace KIDS_CheckIn_System.checkin
{
    partial class frmContactNo
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
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.fldFetchers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldRelationship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContacts
            // 
            this.dgvContacts.AllowUserToAddRows = false;
            this.dgvContacts.AllowUserToDeleteRows = false;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fldFetchers,
            this.fldRelationship,
            this.fldContactNo});
            this.dgvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContacts.Location = new System.Drawing.Point(0, 0);
            this.dgvContacts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowHeadersVisible = false;
            this.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContacts.Size = new System.Drawing.Size(603, 185);
            this.dgvContacts.TabIndex = 0;
            // 
            // fldFetchers
            // 
            this.fldFetchers.HeaderText = "Fetchers Name";
            this.fldFetchers.Name = "fldFetchers";
            this.fldFetchers.ReadOnly = true;
            this.fldFetchers.Width = 200;
            // 
            // fldRelationship
            // 
            this.fldRelationship.HeaderText = "Relationship";
            this.fldRelationship.Name = "fldRelationship";
            this.fldRelationship.ReadOnly = true;
            this.fldRelationship.Width = 150;
            // 
            // fldContactNo
            // 
            this.fldContactNo.HeaderText = "Contact No";
            this.fldContactNo.Name = "fldContactNo";
            this.fldContactNo.ReadOnly = true;
            this.fldContactNo.Width = 250;
            // 
            // frmContactNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 185);
            this.Controls.Add(this.dgvContacts);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmContactNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fetcher\'s Contact Nos";
            this.Load += new System.EventHandler(this.frmContactNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldFetchers;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldRelationship;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldContactNo;
    }
}