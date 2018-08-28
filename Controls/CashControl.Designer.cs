namespace Pen_and_Paper_Visualator.Controls
{
    partial class CashControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgCash1 = new System.Windows.Forms.PictureBox();
            this.imgCash2 = new System.Windows.Forms.PictureBox();
            this.imgCash3 = new System.Windows.Forms.PictureBox();
            this.numCash = new System.Windows.Forms.NumericUpDown();
            this.btnAddCash = new System.Windows.Forms.Button();
            this.btnCash10 = new System.Windows.Forms.Button();
            this.btnCash20 = new System.Windows.Forms.Button();
            this.btnCash50 = new System.Windows.Forms.Button();
            this.btnCash100 = new System.Windows.Forms.Button();
            this.btnCash250 = new System.Windows.Forms.Button();
            this.btnCash500 = new System.Windows.Forms.Button();
            this.btnCash1000 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCash1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCash2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCash3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCash)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCash1
            // 
            this.imgCash1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCash1.Location = new System.Drawing.Point(8, 8);
            this.imgCash1.Name = "imgCash1";
            this.imgCash1.Size = new System.Drawing.Size(84, 81);
            this.imgCash1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCash1.TabIndex = 0;
            this.imgCash1.TabStop = false;
            // 
            // imgCash2
            // 
            this.imgCash2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCash2.Location = new System.Drawing.Point(8, 95);
            this.imgCash2.Name = "imgCash2";
            this.imgCash2.Size = new System.Drawing.Size(84, 81);
            this.imgCash2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCash2.TabIndex = 1;
            this.imgCash2.TabStop = false;
            // 
            // imgCash3
            // 
            this.imgCash3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCash3.Location = new System.Drawing.Point(8, 182);
            this.imgCash3.Name = "imgCash3";
            this.imgCash3.Size = new System.Drawing.Size(84, 81);
            this.imgCash3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCash3.TabIndex = 2;
            this.imgCash3.TabStop = false;
            // 
            // numCash
            // 
            this.numCash.Location = new System.Drawing.Point(189, 21);
            this.numCash.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numCash.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCash.Name = "numCash";
            this.numCash.Size = new System.Drawing.Size(65, 20);
            this.numCash.TabIndex = 5;
            this.numCash.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddCash
            // 
            this.btnAddCash.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddCash.Location = new System.Drawing.Point(102, 19);
            this.btnAddCash.Name = "btnAddCash";
            this.btnAddCash.Size = new System.Drawing.Size(70, 24);
            this.btnAddCash.TabIndex = 23;
            this.btnAddCash.Text = "Add to Loot";
            this.btnAddCash.UseVisualStyleBackColor = false;
            this.btnAddCash.Click += new System.EventHandler(this.btnAddCash_Click);
            // 
            // btnCash10
            // 
            this.btnCash10.BackColor = System.Drawing.SystemColors.Control;
            this.btnCash10.Location = new System.Drawing.Point(102, 56);
            this.btnCash10.Name = "btnCash10";
            this.btnCash10.Size = new System.Drawing.Size(152, 24);
            this.btnCash10.TabIndex = 24;
            this.btnCash10.Text = "Add $10";
            this.btnCash10.UseVisualStyleBackColor = false;
            this.btnCash10.Click += new System.EventHandler(this.btnCash10_Click);
            // 
            // btnCash20
            // 
            this.btnCash20.BackColor = System.Drawing.SystemColors.Control;
            this.btnCash20.Location = new System.Drawing.Point(102, 86);
            this.btnCash20.Name = "btnCash20";
            this.btnCash20.Size = new System.Drawing.Size(152, 24);
            this.btnCash20.TabIndex = 25;
            this.btnCash20.Text = "Add $20";
            this.btnCash20.UseVisualStyleBackColor = false;
            this.btnCash20.Click += new System.EventHandler(this.btnCash20_Click);
            // 
            // btnCash50
            // 
            this.btnCash50.BackColor = System.Drawing.SystemColors.Control;
            this.btnCash50.Location = new System.Drawing.Point(102, 116);
            this.btnCash50.Name = "btnCash50";
            this.btnCash50.Size = new System.Drawing.Size(152, 24);
            this.btnCash50.TabIndex = 26;
            this.btnCash50.Text = "Add $50";
            this.btnCash50.UseVisualStyleBackColor = false;
            this.btnCash50.Click += new System.EventHandler(this.btnCash50_Click);
            // 
            // btnCash100
            // 
            this.btnCash100.BackColor = System.Drawing.SystemColors.Control;
            this.btnCash100.Location = new System.Drawing.Point(102, 146);
            this.btnCash100.Name = "btnCash100";
            this.btnCash100.Size = new System.Drawing.Size(152, 24);
            this.btnCash100.TabIndex = 27;
            this.btnCash100.Text = "Add $100";
            this.btnCash100.UseVisualStyleBackColor = false;
            this.btnCash100.Click += new System.EventHandler(this.btnCash100_Click);
            // 
            // btnCash250
            // 
            this.btnCash250.BackColor = System.Drawing.SystemColors.Control;
            this.btnCash250.Location = new System.Drawing.Point(102, 176);
            this.btnCash250.Name = "btnCash250";
            this.btnCash250.Size = new System.Drawing.Size(152, 24);
            this.btnCash250.TabIndex = 28;
            this.btnCash250.Text = "Add $250";
            this.btnCash250.UseVisualStyleBackColor = false;
            this.btnCash250.Click += new System.EventHandler(this.btnCash250_Click);
            // 
            // btnCash500
            // 
            this.btnCash500.BackColor = System.Drawing.SystemColors.Control;
            this.btnCash500.Location = new System.Drawing.Point(102, 206);
            this.btnCash500.Name = "btnCash500";
            this.btnCash500.Size = new System.Drawing.Size(152, 24);
            this.btnCash500.TabIndex = 29;
            this.btnCash500.Text = "Add $500";
            this.btnCash500.UseVisualStyleBackColor = false;
            this.btnCash500.Click += new System.EventHandler(this.btnCash500_Click);
            // 
            // btnCash1000
            // 
            this.btnCash1000.BackColor = System.Drawing.SystemColors.Control;
            this.btnCash1000.Location = new System.Drawing.Point(102, 236);
            this.btnCash1000.Name = "btnCash1000";
            this.btnCash1000.Size = new System.Drawing.Size(152, 24);
            this.btnCash1000.TabIndex = 30;
            this.btnCash1000.Text = "Add $1000";
            this.btnCash1000.UseVisualStyleBackColor = false;
            this.btnCash1000.Click += new System.EventHandler(this.btnCash1000_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "$";
            // 
            // CashControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numCash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCash1000);
            this.Controls.Add(this.btnCash500);
            this.Controls.Add(this.btnCash250);
            this.Controls.Add(this.btnCash100);
            this.Controls.Add(this.btnCash50);
            this.Controls.Add(this.btnCash20);
            this.Controls.Add(this.btnCash10);
            this.Controls.Add(this.btnAddCash);
            this.Controls.Add(this.imgCash3);
            this.Controls.Add(this.imgCash2);
            this.Controls.Add(this.imgCash1);
            this.Name = "CashControl";
            this.Size = new System.Drawing.Size(262, 276);
            ((System.ComponentModel.ISupportInitialize)(this.imgCash1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCash2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCash3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCash1;
        private System.Windows.Forms.PictureBox imgCash2;
        private System.Windows.Forms.PictureBox imgCash3;
        private System.Windows.Forms.NumericUpDown numCash;
        private System.Windows.Forms.Button btnAddCash;
        private System.Windows.Forms.Button btnCash10;
        private System.Windows.Forms.Button btnCash20;
        private System.Windows.Forms.Button btnCash50;
        private System.Windows.Forms.Button btnCash100;
        private System.Windows.Forms.Button btnCash250;
        private System.Windows.Forms.Button btnCash500;
        private System.Windows.Forms.Button btnCash1000;
        private System.Windows.Forms.Label label1;
    }
}
