namespace KIDS_CheckIn_System
{
    partial class frmPoints
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rb300 = new System.Windows.Forms.RadioButton();
            this.rb500 = new System.Windows.Forms.RadioButton();
            this.rb200 = new System.Windows.Forms.RadioButton();
            this.rb100 = new System.Windows.Forms.RadioButton();
            this.rb1000 = new System.Windows.Forms.RadioButton();
            this.rb50 = new System.Windows.Forms.RadioButton();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.lbltotalpoints = new System.Windows.Forms.Label();
            this.lblAddPoints = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrReader = new System.Windows.Forms.Timer(this.components);
            this.lblReader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblReader);
            this.splitContainer1.Panel1.Controls.Add(this.rb300);
            this.splitContainer1.Panel1.Controls.Add(this.rb500);
            this.splitContainer1.Panel1.Controls.Add(this.rb200);
            this.splitContainer1.Panel1.Controls.Add(this.rb100);
            this.splitContainer1.Panel1.Controls.Add(this.rb1000);
            this.splitContainer1.Panel1.Controls.Add(this.rb50);
            this.splitContainer1.Panel1.Controls.Add(this.rb20);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbltotalpoints);
            this.splitContainer1.Panel2.Controls.Add(this.lblAddPoints);
            this.splitContainer1.Panel2.Controls.Add(this.lblPoints);
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.lblName);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(668, 529);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 0;
            // 
            // rb300
            // 
            this.rb300.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb300.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb300.Location = new System.Drawing.Point(30, 264);
            this.rb300.Name = "rb300";
            this.rb300.Size = new System.Drawing.Size(240, 69);
            this.rb300.TabIndex = 6;
            this.rb300.TabStop = true;
            this.rb300.Text = "300";
            this.rb300.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb300.UseVisualStyleBackColor = true;
            this.rb300.CheckedChanged += new System.EventHandler(this.rb300_CheckedChanged);
            // 
            // rb500
            // 
            this.rb500.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb500.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb500.Location = new System.Drawing.Point(30, 339);
            this.rb500.Name = "rb500";
            this.rb500.Size = new System.Drawing.Size(240, 69);
            this.rb500.TabIndex = 5;
            this.rb500.TabStop = true;
            this.rb500.Text = "500";
            this.rb500.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb500.UseVisualStyleBackColor = true;
            this.rb500.CheckedChanged += new System.EventHandler(this.rb500_CheckedChanged);
            // 
            // rb200
            // 
            this.rb200.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb200.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb200.Location = new System.Drawing.Point(30, 189);
            this.rb200.Name = "rb200";
            this.rb200.Size = new System.Drawing.Size(240, 69);
            this.rb200.TabIndex = 4;
            this.rb200.TabStop = true;
            this.rb200.Text = "200";
            this.rb200.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb200.UseVisualStyleBackColor = true;
            this.rb200.CheckedChanged += new System.EventHandler(this.rb200_CheckedChanged);
            // 
            // rb100
            // 
            this.rb100.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb100.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb100.Location = new System.Drawing.Point(30, 114);
            this.rb100.Name = "rb100";
            this.rb100.Size = new System.Drawing.Size(240, 69);
            this.rb100.TabIndex = 3;
            this.rb100.TabStop = true;
            this.rb100.Text = "100";
            this.rb100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb100.UseVisualStyleBackColor = true;
            this.rb100.CheckedChanged += new System.EventHandler(this.rb100_CheckedChanged);
            // 
            // rb1000
            // 
            this.rb1000.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb1000.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1000.Location = new System.Drawing.Point(30, 414);
            this.rb1000.Name = "rb1000";
            this.rb1000.Size = new System.Drawing.Size(240, 69);
            this.rb1000.TabIndex = 2;
            this.rb1000.TabStop = true;
            this.rb1000.Text = "1000";
            this.rb1000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb1000.UseVisualStyleBackColor = true;
            this.rb1000.CheckedChanged += new System.EventHandler(this.rb1000_CheckedChanged);
            // 
            // rb50
            // 
            this.rb50.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb50.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb50.Location = new System.Drawing.Point(30, 39);
            this.rb50.Name = "rb50";
            this.rb50.Size = new System.Drawing.Size(240, 69);
            this.rb50.TabIndex = 1;
            this.rb50.TabStop = true;
            this.rb50.Text = "50";
            this.rb50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb50.UseVisualStyleBackColor = true;
            this.rb50.CheckedChanged += new System.EventHandler(this.rb50_CheckedChanged);
            // 
            // rb20
            // 
            this.rb20.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb20.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb20.Location = new System.Drawing.Point(30, 39);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(240, 69);
            this.rb20.TabIndex = 0;
            this.rb20.TabStop = true;
            this.rb20.Text = "20";
            this.rb20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb20.UseVisualStyleBackColor = true;
            this.rb20.Visible = false;
            this.rb20.CheckedChanged += new System.EventHandler(this.rb20_CheckedChanged);
            // 
            // lbltotalpoints
            // 
            this.lbltotalpoints.AutoSize = true;
            this.lbltotalpoints.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalpoints.Location = new System.Drawing.Point(79, 339);
            this.lbltotalpoints.Name = "lbltotalpoints";
            this.lbltotalpoints.Size = new System.Drawing.Size(125, 19);
            this.lbltotalpoints.TabIndex = 6;
            this.lbltotalpoints.Text = "TOTAL POINTS";
            // 
            // lblAddPoints
            // 
            this.lblAddPoints.AutoSize = true;
            this.lblAddPoints.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPoints.Location = new System.Drawing.Point(79, 305);
            this.lblAddPoints.Name = "lblAddPoints";
            this.lblAddPoints.Size = new System.Drawing.Size(171, 19);
            this.lblAddPoints.TabIndex = 5;
            this.lblAddPoints.Text = "ADDITIONAL POINTS";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(79, 275);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(154, 19);
            this.lblPoints.TabIndex = 4;
            this.lblPoints.Text = "CURRENT POINTS";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(127, 459);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 58);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(242, 459);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 58);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(79, 245);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "{Name of Kid}";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(82, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tmrReader
            // 
            this.tmrReader.Enabled = true;
            this.tmrReader.Tick += new System.EventHandler(this.tmrReader_Tick);
            // 
            // lblReader
            // 
            this.lblReader.AutoSize = true;
            this.lblReader.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReader.ForeColor = System.Drawing.Color.Green;
            this.lblReader.Location = new System.Drawing.Point(26, 498);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(65, 22);
            this.lblReader.TabIndex = 7;
            this.lblReader.Text = "label1";
            // 
            // frmPoints
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(668, 529);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPoints";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Points";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPoints_FormClosed);
            this.Load += new System.EventHandler(this.frmPoints_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rb500;
        private System.Windows.Forms.RadioButton rb200;
        private System.Windows.Forms.RadioButton rb100;
        private System.Windows.Forms.RadioButton rb1000;
        private System.Windows.Forms.RadioButton rb50;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lbltotalpoints;
        private System.Windows.Forms.Label lblAddPoints;
        private System.Windows.Forms.Timer tmrReader;
        private System.Windows.Forms.RadioButton rb300;
        private System.Windows.Forms.Label lblReader;
    }
}