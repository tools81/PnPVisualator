namespace Pen_and_Paper_Visualator
{
    partial class frmWelcome
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
            this.pnlImage = new System.Windows.Forms.Panel();
            this.ddlCharacters = new System.Windows.Forms.ListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGM = new System.Windows.Forms.Button();
            this.btnDataFolder = new System.Windows.Forms.Button();
            this.fbdDataFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblDataFolder = new System.Windows.Forms.Label();
            this.chkSounds = new System.Windows.Forms.CheckBox();
            this.pnlImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.BackgroundImage = global::Pen_and_Paper_Visualator.Properties.Resources.WOD_Logo;
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlImage.Controls.Add(this.ddlCharacters);
            this.pnlImage.Location = new System.Drawing.Point(1, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlImage.Size = new System.Drawing.Size(667, 181);
            this.pnlImage.TabIndex = 0;
            // 
            // ddlCharacters
            // 
            this.ddlCharacters.BackColor = System.Drawing.Color.Black;
            this.ddlCharacters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ddlCharacters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCharacters.ForeColor = System.Drawing.Color.White;
            this.ddlCharacters.FormattingEnabled = true;
            this.ddlCharacters.ItemHeight = 20;
            this.ddlCharacters.Location = new System.Drawing.Point(11, 11);
            this.ddlCharacters.Name = "ddlCharacters";
            this.ddlCharacters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlCharacters.Size = new System.Drawing.Size(176, 160);
            this.ddlCharacters.TabIndex = 0;
            this.ddlCharacters.SelectedIndexChanged += new System.EventHandler(this.ddlCharacters_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(13, 211);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(118, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create a Character";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(145, 211);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(118, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load a Character";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(539, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Quit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGM
            // 
            this.btnGM.Location = new System.Drawing.Point(277, 211);
            this.btnGM.Name = "btnGM";
            this.btnGM.Size = new System.Drawing.Size(118, 23);
            this.btnGM.TabIndex = 4;
            this.btnGM.Text = "GM Form";
            this.btnGM.UseVisualStyleBackColor = true;
            this.btnGM.Click += new System.EventHandler(this.btnGM_Click);
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Location = new System.Drawing.Point(410, 211);
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.Size = new System.Drawing.Size(118, 23);
            this.btnDataFolder.TabIndex = 5;
            this.btnDataFolder.Text = "Data Folder";
            this.btnDataFolder.UseVisualStyleBackColor = true;
            this.btnDataFolder.Click += new System.EventHandler(this.btnDataFolder_Click);
            // 
            // lblDataFolder
            // 
            this.lblDataFolder.AutoSize = true;
            this.lblDataFolder.ForeColor = System.Drawing.Color.White;
            this.lblDataFolder.Location = new System.Drawing.Point(370, 189);
            this.lblDataFolder.Name = "lblDataFolder";
            this.lblDataFolder.Size = new System.Drawing.Size(69, 13);
            this.lblDataFolder.TabIndex = 6;
            this.lblDataFolder.Text = "lblDataFolder";
            // 
            // chkSounds
            // 
            this.chkSounds.AutoSize = true;
            this.chkSounds.ForeColor = System.Drawing.Color.White;
            this.chkSounds.Location = new System.Drawing.Point(12, 188);
            this.chkSounds.Name = "chkSounds";
            this.chkSounds.Size = new System.Drawing.Size(85, 17);
            this.chkSounds.TabIndex = 7;
            this.chkSounds.Text = "Play Sounds";
            this.chkSounds.UseVisualStyleBackColor = true;
            this.chkSounds.CheckedChanged += new System.EventHandler(this.chkSounds_CheckedChanged);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(669, 247);
            this.Controls.Add(this.chkSounds);
            this.Controls.Add(this.lblDataFolder);
            this.Controls.Add(this.btnDataFolder);
            this.Controls.Add(this.btnGM);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWelcome";
            this.Text = "frmWelcome";
            this.pnlImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox ddlCharacters;
        private System.Windows.Forms.Button btnGM;
        private System.Windows.Forms.Button btnDataFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdDataFolder;
        private System.Windows.Forms.Label lblDataFolder;
        private System.Windows.Forms.CheckBox chkSounds;
    }
}