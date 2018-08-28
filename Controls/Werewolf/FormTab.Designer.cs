namespace Pen_and_Paper_Visualator.Controls.Werewolf
{
    partial class FormTab
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
            this.rdoHishu = new System.Windows.Forms.RadioButton();
            this.rdoDalu = new System.Windows.Forms.RadioButton();
            this.rdoGauru = new System.Windows.Forms.RadioButton();
            this.rdoUrshul = new System.Windows.Forms.RadioButton();
            this.rdoUrhan = new System.Windows.Forms.RadioButton();
            this.imgForm = new System.Windows.Forms.PictureBox();
            this.txtTraits = new System.Windows.Forms.TextBox();
            this.lblTraits = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlForms = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgForm)).BeginInit();
            this.pnlForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoHishu
            // 
            this.rdoHishu.AutoSize = true;
            this.rdoHishu.Location = new System.Drawing.Point(57, 21);
            this.rdoHishu.Name = "rdoHishu";
            this.rdoHishu.Size = new System.Drawing.Size(52, 17);
            this.rdoHishu.TabIndex = 0;
            this.rdoHishu.TabStop = true;
            this.rdoHishu.Text = "Hishu";
            this.rdoHishu.UseVisualStyleBackColor = true;
            // 
            // rdoDalu
            // 
            this.rdoDalu.AutoSize = true;
            this.rdoDalu.Location = new System.Drawing.Point(57, 44);
            this.rdoDalu.Name = "rdoDalu";
            this.rdoDalu.Size = new System.Drawing.Size(47, 17);
            this.rdoDalu.TabIndex = 1;
            this.rdoDalu.TabStop = true;
            this.rdoDalu.Text = "Dalu";
            this.rdoDalu.UseVisualStyleBackColor = true;
            // 
            // rdoGauru
            // 
            this.rdoGauru.AutoSize = true;
            this.rdoGauru.Location = new System.Drawing.Point(57, 67);
            this.rdoGauru.Name = "rdoGauru";
            this.rdoGauru.Size = new System.Drawing.Size(54, 17);
            this.rdoGauru.TabIndex = 2;
            this.rdoGauru.TabStop = true;
            this.rdoGauru.Text = "Gauru";
            this.rdoGauru.UseVisualStyleBackColor = true;
            // 
            // rdoUrshul
            // 
            this.rdoUrshul.AutoSize = true;
            this.rdoUrshul.Location = new System.Drawing.Point(57, 90);
            this.rdoUrshul.Name = "rdoUrshul";
            this.rdoUrshul.Size = new System.Drawing.Size(55, 17);
            this.rdoUrshul.TabIndex = 3;
            this.rdoUrshul.TabStop = true;
            this.rdoUrshul.Text = "Urshul";
            this.rdoUrshul.UseVisualStyleBackColor = true;
            // 
            // rdoUrhan
            // 
            this.rdoUrhan.AutoSize = true;
            this.rdoUrhan.Location = new System.Drawing.Point(57, 113);
            this.rdoUrhan.Name = "rdoUrhan";
            this.rdoUrhan.Size = new System.Drawing.Size(54, 17);
            this.rdoUrhan.TabIndex = 4;
            this.rdoUrhan.TabStop = true;
            this.rdoUrhan.Text = "Urhan";
            this.rdoUrhan.UseVisualStyleBackColor = true;
            // 
            // imgForm
            // 
            this.imgForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgForm.Location = new System.Drawing.Point(64, 167);
            this.imgForm.Name = "imgForm";
            this.imgForm.Size = new System.Drawing.Size(159, 159);
            this.imgForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgForm.TabIndex = 5;
            this.imgForm.TabStop = false;
            // 
            // txtTraits
            // 
            this.txtTraits.Location = new System.Drawing.Point(24, 353);
            this.txtTraits.Multiline = true;
            this.txtTraits.Name = "txtTraits";
            this.txtTraits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTraits.Size = new System.Drawing.Size(239, 96);
            this.txtTraits.TabIndex = 6;
            // 
            // lblTraits
            // 
            this.lblTraits.AutoSize = true;
            this.lblTraits.Location = new System.Drawing.Point(31, 337);
            this.lblTraits.Name = "lblTraits";
            this.lblTraits.Size = new System.Drawing.Size(33, 13);
            this.lblTraits.TabIndex = 7;
            this.lblTraits.Text = "Traits";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(24, 475);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtDescription.Size = new System.Drawing.Size(238, 158);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(31, 459);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Description";
            // 
            // pnlForms
            // 
            this.pnlForms.Controls.Add(this.rdoGauru);
            this.pnlForms.Controls.Add(this.rdoHishu);
            this.pnlForms.Controls.Add(this.rdoDalu);
            this.pnlForms.Controls.Add(this.rdoUrshul);
            this.pnlForms.Controls.Add(this.rdoUrhan);
            this.pnlForms.Location = new System.Drawing.Point(63, 10);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(159, 145);
            this.pnlForms.TabIndex = 10;
            // 
            // FormTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlForms);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblTraits);
            this.Controls.Add(this.txtTraits);
            this.Controls.Add(this.imgForm);
            this.Name = "FormTab";
            this.Size = new System.Drawing.Size(286, 652);
            ((System.ComponentModel.ISupportInitialize)(this.imgForm)).EndInit();
            this.pnlForms.ResumeLayout(false);
            this.pnlForms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoHishu;
        private System.Windows.Forms.RadioButton rdoDalu;
        private System.Windows.Forms.RadioButton rdoGauru;
        private System.Windows.Forms.RadioButton rdoUrshul;
        private System.Windows.Forms.RadioButton rdoUrhan;
        private System.Windows.Forms.PictureBox imgForm;
        private System.Windows.Forms.TextBox txtTraits;
        private System.Windows.Forms.Label lblTraits;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlForms;
    }
}
