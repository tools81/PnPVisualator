namespace Pen_and_Paper_Visualator.Controls
{
    partial class DisciplineTab
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
            this.lblActiveDiscipline = new System.Windows.Forms.Label();
            this.ddlDisciplineLevel = new System.Windows.Forms.ComboBox();
            this.imgDiscipline = new System.Windows.Forms.PictureBox();
            this.pnlDiscDesc = new System.Windows.Forms.Panel();
            this.pnlDiscipline = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDevotion = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDisciplines = new System.Windows.Forms.Label();
            this.lblDevotions = new System.Windows.Forms.Label();
            this.txtDisciplineDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgDiscipline)).BeginInit();
            this.pnlDiscDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblActiveDiscipline
            // 
            this.lblActiveDiscipline.AutoSize = true;
            this.lblActiveDiscipline.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveDiscipline.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActiveDiscipline.Location = new System.Drawing.Point(7, 113);
            this.lblActiveDiscipline.Name = "lblActiveDiscipline";
            this.lblActiveDiscipline.Size = new System.Drawing.Size(41, 17);
            this.lblActiveDiscipline.TabIndex = 29;
            this.lblActiveDiscipline.Text = "Name";
            // 
            // ddlDisciplineLevel
            // 
            this.ddlDisciplineLevel.FormattingEnabled = true;
            this.ddlDisciplineLevel.Location = new System.Drawing.Point(152, 111);
            this.ddlDisciplineLevel.Name = "ddlDisciplineLevel";
            this.ddlDisciplineLevel.Size = new System.Drawing.Size(121, 21);
            this.ddlDisciplineLevel.TabIndex = 31;
            this.ddlDisciplineLevel.SelectedIndexChanged += new System.EventHandler(this.ddlDisciplineLevel_SelectedIndexChanged);
            // 
            // imgDiscipline
            // 
            this.imgDiscipline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgDiscipline.Location = new System.Drawing.Point(10, 6);
            this.imgDiscipline.Name = "imgDiscipline";
            this.imgDiscipline.Size = new System.Drawing.Size(100, 100);
            this.imgDiscipline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDiscipline.TabIndex = 34;
            this.imgDiscipline.TabStop = false;
            // 
            // pnlDiscDesc
            // 
            this.pnlDiscDesc.Controls.Add(this.txtDisciplineDescription);
            this.pnlDiscDesc.Controls.Add(this.imgDiscipline);
            this.pnlDiscDesc.Controls.Add(this.lblActiveDiscipline);
            this.pnlDiscDesc.Controls.Add(this.ddlDisciplineLevel);
            this.pnlDiscDesc.Location = new System.Drawing.Point(6, 338);
            this.pnlDiscDesc.Name = "pnlDiscDesc";
            this.pnlDiscDesc.Size = new System.Drawing.Size(273, 300);
            this.pnlDiscDesc.TabIndex = 36;
            this.pnlDiscDesc.Visible = false;
            // 
            // pnlDiscipline
            // 
            this.pnlDiscipline.Location = new System.Drawing.Point(6, 26);
            this.pnlDiscipline.Name = "pnlDiscipline";
            this.pnlDiscipline.Size = new System.Drawing.Size(273, 193);
            this.pnlDiscipline.TabIndex = 37;
            // 
            // pnlDevotion
            // 
            this.pnlDevotion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlDevotion.Location = new System.Drawing.Point(6, 243);
            this.pnlDevotion.Name = "pnlDevotion";
            this.pnlDevotion.Size = new System.Drawing.Size(273, 89);
            this.pnlDevotion.TabIndex = 38;
            // 
            // lblDisciplines
            // 
            this.lblDisciplines.AutoSize = true;
            this.lblDisciplines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisciplines.Location = new System.Drawing.Point(106, 10);
            this.lblDisciplines.Name = "lblDisciplines";
            this.lblDisciplines.Size = new System.Drawing.Size(68, 13);
            this.lblDisciplines.TabIndex = 39;
            this.lblDisciplines.Text = "Disciplines";
            // 
            // lblDevotions
            // 
            this.lblDevotions.AutoSize = true;
            this.lblDevotions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevotions.Location = new System.Drawing.Point(108, 227);
            this.lblDevotions.Name = "lblDevotions";
            this.lblDevotions.Size = new System.Drawing.Size(64, 13);
            this.lblDevotions.TabIndex = 40;
            this.lblDevotions.Text = "Devotions";
            // 
            // txtDisciplineDescription
            // 
            this.txtDisciplineDescription.Location = new System.Drawing.Point(6, 138);
            this.txtDisciplineDescription.Name = "txtDisciplineDescription";
            this.txtDisciplineDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtDisciplineDescription.Size = new System.Drawing.Size(266, 161);
            this.txtDisciplineDescription.TabIndex = 35;
            this.txtDisciplineDescription.Text = "";
            // 
            // DisciplineTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblDevotions);
            this.Controls.Add(this.lblDisciplines);
            this.Controls.Add(this.pnlDevotion);
            this.Controls.Add(this.pnlDiscipline);
            this.Controls.Add(this.pnlDiscDesc);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "DisciplineTab";
            this.Size = new System.Drawing.Size(286, 652);
            ((System.ComponentModel.ISupportInitialize)(this.imgDiscipline)).EndInit();
            this.pnlDiscDesc.ResumeLayout(false);
            this.pnlDiscDesc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblActiveDiscipline;
        private System.Windows.Forms.ComboBox ddlDisciplineLevel;
        private System.Windows.Forms.PictureBox imgDiscipline;
        private System.Windows.Forms.Panel pnlDiscDesc;
        private System.Windows.Forms.FlowLayoutPanel pnlDiscipline;
        private System.Windows.Forms.FlowLayoutPanel pnlDevotion;
        private System.Windows.Forms.Label lblDisciplines;
        private System.Windows.Forms.Label lblDevotions;
        private System.Windows.Forms.RichTextBox txtDisciplineDescription;
    }
}
