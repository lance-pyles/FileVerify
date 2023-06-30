namespace FileVerify
{
    partial class Form1
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
            this.lblDirectory1 = new System.Windows.Forms.Label();
            this.lblDirectory2 = new System.Windows.Forms.Label();
            this.btnLoadDirectory1 = new System.Windows.Forms.Button();
            this.btnLoadDirectory2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExistsInDirectory1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExistsInDirectory2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHashesMatch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lblCalculatedHashes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDirectory1
            // 
            this.lblDirectory1.AutoSize = true;
            this.lblDirectory1.Location = new System.Drawing.Point(12, 92);
            this.lblDirectory1.Name = "lblDirectory1";
            this.lblDirectory1.Size = new System.Drawing.Size(55, 13);
            this.lblDirectory1.TabIndex = 0;
            this.lblDirectory1.Text = "Directory1";
            // 
            // lblDirectory2
            // 
            this.lblDirectory2.AutoSize = true;
            this.lblDirectory2.Location = new System.Drawing.Point(363, 91);
            this.lblDirectory2.Name = "lblDirectory2";
            this.lblDirectory2.Size = new System.Drawing.Size(55, 13);
            this.lblDirectory2.TabIndex = 1;
            this.lblDirectory2.Text = "Directory2";
            // 
            // btnLoadDirectory1
            // 
            this.btnLoadDirectory1.Location = new System.Drawing.Point(96, 61);
            this.btnLoadDirectory1.Name = "btnLoadDirectory1";
            this.btnLoadDirectory1.Size = new System.Drawing.Size(103, 23);
            this.btnLoadDirectory1.TabIndex = 2;
            this.btnLoadDirectory1.Text = "Load Directory 1";
            this.btnLoadDirectory1.UseVisualStyleBackColor = true;
            this.btnLoadDirectory1.Click += new System.EventHandler(this.btnLoadDirectory1_Click);
            // 
            // btnLoadDirectory2
            // 
            this.btnLoadDirectory2.Location = new System.Drawing.Point(400, 40);
            this.btnLoadDirectory2.Name = "btnLoadDirectory2";
            this.btnLoadDirectory2.Size = new System.Drawing.Size(97, 23);
            this.btnLoadDirectory2.TabIndex = 3;
            this.btnLoadDirectory2.Text = "Load Directory 2";
            this.btnLoadDirectory2.UseVisualStyleBackColor = true;
            this.btnLoadDirectory2.Click += new System.EventHandler(this.btnLoadDirectory2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(603, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 108);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(264, 95);
            this.listBox1.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(366, 107);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(312, 95);
            this.listBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(27, 338);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colExistsInDirectory1,
            this.colExistsInDirectory2,
            this.colHashesMatch});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(335, 308);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(391, 97);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colFileName
            // 
            this.colFileName.Text = "File Name";
            // 
            // colExistsInDirectory1
            // 
            this.colExistsInDirectory1.Text = "In Directory 1";
            // 
            // colExistsInDirectory2
            // 
            this.colExistsInDirectory2.Text = "In Directory 2";
            // 
            // colHashesMatch
            // 
            this.colHashesMatch.Text = "Hashes Match";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // lblCalculatedHashes
            // 
            this.lblCalculatedHashes.AutoSize = true;
            this.lblCalculatedHashes.Location = new System.Drawing.Point(481, 408);
            this.lblCalculatedHashes.Name = "lblCalculatedHashes";
            this.lblCalculatedHashes.Size = new System.Drawing.Size(97, 13);
            this.lblCalculatedHashes.TabIndex = 16;
            this.lblCalculatedHashes.Text = "Calculated hashes:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCalculatedHashes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnLoadDirectory2);
            this.Controls.Add(this.btnLoadDirectory1);
            this.Controls.Add(this.lblDirectory2);
            this.Controls.Add(this.lblDirectory1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirectory1;
        private System.Windows.Forms.Label lblDirectory2;
        private System.Windows.Forms.Button btnLoadDirectory1;
        private System.Windows.Forms.Button btnLoadDirectory2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colExistsInDirectory1;
        private System.Windows.Forms.ColumnHeader colExistsInDirectory2;
        private System.Windows.Forms.ColumnHeader colHashesMatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCalculatedHashes;
    }
}

