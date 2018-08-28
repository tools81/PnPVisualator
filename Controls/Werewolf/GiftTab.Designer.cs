namespace Pen_and_Paper_Visualator.Controls
{
    partial class GiftTab
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
            this.pnlGiftDesc = new System.Windows.Forms.Panel();
            this.imgGift = new System.Windows.Forms.PictureBox();
            this.lblActiveGift = new System.Windows.Forms.Label();
            this.pnlGifts = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuspiceAbility = new System.Windows.Forms.Label();
            this.pnlRites = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiftDescription = new System.Windows.Forms.RichTextBox();
            this.pnlGiftDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGift)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGiftDesc
            // 
            this.pnlGiftDesc.Controls.Add(this.txtGiftDescription);
            this.pnlGiftDesc.Controls.Add(this.imgGift);
            this.pnlGiftDesc.Controls.Add(this.lblActiveGift);
            this.pnlGiftDesc.Location = new System.Drawing.Point(4, 403);
            this.pnlGiftDesc.Name = "pnlGiftDesc";
            this.pnlGiftDesc.Size = new System.Drawing.Size(273, 246);
            this.pnlGiftDesc.TabIndex = 37;
            this.pnlGiftDesc.Visible = false;
            // 
            // imgGift
            // 
            this.imgGift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgGift.Location = new System.Drawing.Point(10, 6);
            this.imgGift.Name = "imgGift";
            this.imgGift.Size = new System.Drawing.Size(100, 100);
            this.imgGift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgGift.TabIndex = 34;
            this.imgGift.TabStop = false;
            // 
            // lblActiveGift
            // 
            this.lblActiveGift.AutoSize = true;
            this.lblActiveGift.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveGift.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActiveGift.Location = new System.Drawing.Point(116, 89);
            this.lblActiveGift.Name = "lblActiveGift";
            this.lblActiveGift.Size = new System.Drawing.Size(41, 17);
            this.lblActiveGift.TabIndex = 29;
            this.lblActiveGift.Text = "Name";
            // 
            // pnlGifts
            // 
            this.pnlGifts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlGifts.Location = new System.Drawing.Point(7, 31);
            this.pnlGifts.Name = "pnlGifts";
            this.pnlGifts.Size = new System.Drawing.Size(269, 178);
            this.pnlGifts.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Auspice Ability:";
            // 
            // lblAuspiceAbility
            // 
            this.lblAuspiceAbility.AutoSize = true;
            this.lblAuspiceAbility.Location = new System.Drawing.Point(111, 365);
            this.lblAuspiceAbility.Name = "lblAuspiceAbility";
            this.lblAuspiceAbility.Size = new System.Drawing.Size(33, 13);
            this.lblAuspiceAbility.TabIndex = 40;
            this.lblAuspiceAbility.Text = "ability";
            this.lblAuspiceAbility.Click += new System.EventHandler(this.lblAuspiceAbility_Click);
            // 
            // pnlRites
            // 
            this.pnlRites.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlRites.Location = new System.Drawing.Point(7, 228);
            this.pnlRites.Name = "pnlRites";
            this.pnlRites.Size = new System.Drawing.Size(269, 134);
            this.pnlRites.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Gifts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Rites";
            // 
            // txtGiftDescription
            // 
            this.txtGiftDescription.Location = new System.Drawing.Point(5, 113);
            this.txtGiftDescription.Name = "txtGiftDescription";
            this.txtGiftDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtGiftDescription.Size = new System.Drawing.Size(266, 132);
            this.txtGiftDescription.TabIndex = 35;
            this.txtGiftDescription.Text = "";
            // 
            // GiftTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlRites);
            this.Controls.Add(this.lblAuspiceAbility);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlGifts);
            this.Controls.Add(this.pnlGiftDesc);
            this.Name = "GiftTab";
            this.Size = new System.Drawing.Size(286, 652);
            this.pnlGiftDesc.ResumeLayout(false);
            this.pnlGiftDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGift)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGiftDesc;
        private System.Windows.Forms.PictureBox imgGift;
        private System.Windows.Forms.Label lblActiveGift;
        private System.Windows.Forms.FlowLayoutPanel pnlGifts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAuspiceAbility;
        private System.Windows.Forms.FlowLayoutPanel pnlRites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtGiftDescription;
    }
}
