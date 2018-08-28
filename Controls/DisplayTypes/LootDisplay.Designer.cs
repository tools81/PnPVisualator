namespace Pen_and_Paper_Visualator.Controls
{
    partial class LootDisplay
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSizeText = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblValueText = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.imgItem = new System.Windows.Forms.PictureBox();
            this.lblType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblName.Location = new System.Drawing.Point(3, 125);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 17);
            this.lblName.TabIndex = 167;
            this.lblName.Text = "Name";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(29, 150);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(13, 13);
            this.lblSize.TabIndex = 171;
            this.lblSize.Text = "0";
            // 
            // lblSizeText
            // 
            this.lblSizeText.AutoSize = true;
            this.lblSizeText.Location = new System.Drawing.Point(3, 150);
            this.lblSizeText.Name = "lblSizeText";
            this.lblSizeText.Size = new System.Drawing.Size(27, 13);
            this.lblSizeText.TabIndex = 170;
            this.lblSizeText.Text = "Size";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(87, 150);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(13, 13);
            this.lblValue.TabIndex = 173;
            this.lblValue.Text = "0";
            // 
            // lblValueText
            // 
            this.lblValueText.AutoSize = true;
            this.lblValueText.Location = new System.Drawing.Point(48, 150);
            this.lblValueText.Name = "lblValueText";
            this.lblValueText.Size = new System.Drawing.Size(43, 13);
            this.lblValueText.TabIndex = 172;
            this.lblValueText.Text = "Value $";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 4);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 13);
            this.lblID.TabIndex = 174;
            this.lblID.Text = "lblID";
            this.lblID.Visible = false;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.BackColor = System.Drawing.Color.Transparent;
            this.btnRetrieve.Location = new System.Drawing.Point(117, 4);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(25, 23);
            this.btnRetrieve.TabIndex = 175;
            this.btnRetrieve.Text = "+";
            this.btnRetrieve.UseVisualStyleBackColor = false;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // imgItem
            // 
            this.imgItem.BackColor = System.Drawing.Color.Black;
            this.imgItem.Location = new System.Drawing.Point(4, 4);
            this.imgItem.Name = "imgItem";
            this.imgItem.Size = new System.Drawing.Size(138, 138);
            this.imgItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgItem.TabIndex = 0;
            this.imgItem.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(3, 18);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 13);
            this.lblType.TabIndex = 176;
            this.lblType.Text = "lblType";
            this.lblType.Visible = false;
            // 
            // LootDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblValueText);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblSizeText);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.imgItem);
            this.Name = "LootDisplay";
            this.Size = new System.Drawing.Size(146, 169);
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgItem;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSizeText;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblValueText;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label lblType;
    }
}
