namespace Pen_and_Paper_Visualator.Controls
{
    partial class IconLabel
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
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.lblString = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // imgIcon
            // 
            this.imgIcon.BackColor = System.Drawing.Color.Black;
            this.imgIcon.Location = new System.Drawing.Point(4, 2);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(20, 20);
            this.imgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgIcon.TabIndex = 0;
            this.imgIcon.TabStop = false;
            // 
            // lblString
            // 
            this.lblString.AutoSize = true;
            this.lblString.Location = new System.Drawing.Point(33, 6);
            this.lblString.Name = "lblString";
            this.lblString.Size = new System.Drawing.Size(35, 13);
            this.lblString.TabIndex = 1;
            this.lblString.Text = "label1";
            // 
            // IconLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblString);
            this.Controls.Add(this.imgIcon);
            this.Name = "IconLabel";
            this.Size = new System.Drawing.Size(130, 23);
            this.Load += new System.EventHandler(this.IconLabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgIcon;
        private System.Windows.Forms.Label lblString;
    }
}
