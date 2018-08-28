namespace Pen_and_Paper_Visualator.Controls
{
    partial class GMWeaponControl
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
            this.lblAmmoText = new System.Windows.Forms.Label();
            this.lblAmmo = new System.Windows.Forms.Label();
            this.numSubt = new System.Windows.Forms.NumericUpDown();
            this.btnSubt = new System.Windows.Forms.Button();
            this.numAdd = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.imgAmmo = new System.Windows.Forms.PictureBox();
            this.imgBreak = new System.Windows.Forms.PictureBox();
            this.imgWeapon = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDamageText = new System.Windows.Forms.Label();
            this.lblDamage = new System.Windows.Forms.Label();
            this.lblRangeText = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.pnlAmmoControl = new System.Windows.Forms.Panel();
            this.lblWeaponId = new System.Windows.Forms.Label();
            this.lblCapacityCurrent = new System.Windows.Forms.Label();
            this.lblCapacityMax = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSubt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAmmo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWeapon)).BeginInit();
            this.pnlAmmoControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAmmoText
            // 
            this.lblAmmoText.AutoSize = true;
            this.lblAmmoText.Location = new System.Drawing.Point(87, 65);
            this.lblAmmoText.Name = "lblAmmoText";
            this.lblAmmoText.Size = new System.Drawing.Size(36, 13);
            this.lblAmmoText.TabIndex = 0;
            this.lblAmmoText.Text = "Ammo";
            // 
            // lblAmmo
            // 
            this.lblAmmo.AutoSize = true;
            this.lblAmmo.Location = new System.Drawing.Point(137, 65);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(24, 13);
            this.lblAmmo.TabIndex = 1;
            this.lblAmmo.Text = "0/0";
            // 
            // numSubt
            // 
            this.numSubt.Location = new System.Drawing.Point(158, 5);
            this.numSubt.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numSubt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSubt.Name = "numSubt";
            this.numSubt.Size = new System.Drawing.Size(36, 20);
            this.numSubt.TabIndex = 29;
            this.numSubt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSubt
            // 
            this.btnSubt.Location = new System.Drawing.Point(119, 3);
            this.btnSubt.Name = "btnSubt";
            this.btnSubt.Size = new System.Drawing.Size(37, 24);
            this.btnSubt.TabIndex = 28;
            this.btnSubt.Text = "Subt";
            this.btnSubt.UseVisualStyleBackColor = true;
            this.btnSubt.Click += new System.EventHandler(this.btnSubt_Click);
            // 
            // numAdd
            // 
            this.numAdd.Location = new System.Drawing.Point(78, 5);
            this.numAdd.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numAdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAdd.Name = "numAdd";
            this.numAdd.Size = new System.Drawing.Size(36, 20);
            this.numAdd.TabIndex = 27;
            this.numAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Location = new System.Drawing.Point(41, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 24);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // imgAmmo
            // 
            this.imgAmmo.BackgroundImage = global::Pen_and_Paper_Visualator.Properties.Resources.bullet;
            this.imgAmmo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgAmmo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgAmmo.Location = new System.Drawing.Point(14, 3);
            this.imgAmmo.Name = "imgAmmo";
            this.imgAmmo.Size = new System.Drawing.Size(24, 24);
            this.imgAmmo.TabIndex = 30;
            this.imgAmmo.TabStop = false;
            this.imgAmmo.Click += new System.EventHandler(this.imgAmmo_Click);
            // 
            // imgBreak
            // 
            this.imgBreak.BackColor = System.Drawing.Color.Red;
            this.imgBreak.BackgroundImage = global::Pen_and_Paper_Visualator.Properties.Resources.Break;
            this.imgBreak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgBreak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBreak.Location = new System.Drawing.Point(202, 27);
            this.imgBreak.Name = "imgBreak";
            this.imgBreak.Size = new System.Drawing.Size(36, 39);
            this.imgBreak.TabIndex = 31;
            this.imgBreak.TabStop = false;
            this.imgBreak.Click += new System.EventHandler(this.imgBreak_Click);
            // 
            // imgWeapon
            // 
            this.imgWeapon.BackColor = System.Drawing.Color.Black;
            this.imgWeapon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgWeapon.Location = new System.Drawing.Point(2, 3);
            this.imgWeapon.Name = "imgWeapon";
            this.imgWeapon.Size = new System.Drawing.Size(75, 75);
            this.imgWeapon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgWeapon.TabIndex = 32;
            this.imgWeapon.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(83, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 16);
            this.lblName.TabIndex = 33;
            this.lblName.Text = "label1";
            // 
            // lblDamageText
            // 
            this.lblDamageText.AutoSize = true;
            this.lblDamageText.Location = new System.Drawing.Point(87, 25);
            this.lblDamageText.Name = "lblDamageText";
            this.lblDamageText.Size = new System.Drawing.Size(47, 13);
            this.lblDamageText.TabIndex = 34;
            this.lblDamageText.Text = "Damage";
            // 
            // lblDamage
            // 
            this.lblDamage.AutoSize = true;
            this.lblDamage.Location = new System.Drawing.Point(137, 25);
            this.lblDamage.Name = "lblDamage";
            this.lblDamage.Size = new System.Drawing.Size(13, 13);
            this.lblDamage.TabIndex = 35;
            this.lblDamage.Text = "0";
            // 
            // lblRangeText
            // 
            this.lblRangeText.AutoSize = true;
            this.lblRangeText.Location = new System.Drawing.Point(87, 45);
            this.lblRangeText.Name = "lblRangeText";
            this.lblRangeText.Size = new System.Drawing.Size(39, 13);
            this.lblRangeText.TabIndex = 36;
            this.lblRangeText.Text = "Range";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(137, 45);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(35, 13);
            this.lblRange.TabIndex = 37;
            this.lblRange.Text = "0/0/0";
            // 
            // pnlAmmoControl
            // 
            this.pnlAmmoControl.Controls.Add(this.btnAdd);
            this.pnlAmmoControl.Controls.Add(this.numAdd);
            this.pnlAmmoControl.Controls.Add(this.btnSubt);
            this.pnlAmmoControl.Controls.Add(this.numSubt);
            this.pnlAmmoControl.Controls.Add(this.imgAmmo);
            this.pnlAmmoControl.Location = new System.Drawing.Point(22, 80);
            this.pnlAmmoControl.Name = "pnlAmmoControl";
            this.pnlAmmoControl.Size = new System.Drawing.Size(199, 30);
            this.pnlAmmoControl.TabIndex = 38;
            // 
            // lblWeaponId
            // 
            this.lblWeaponId.AutoSize = true;
            this.lblWeaponId.Location = new System.Drawing.Point(189, 5);
            this.lblWeaponId.Name = "lblWeaponId";
            this.lblWeaponId.Size = new System.Drawing.Size(13, 13);
            this.lblWeaponId.TabIndex = 39;
            this.lblWeaponId.Text = "_";
            this.lblWeaponId.Visible = false;
            // 
            // lblCapacityCurrent
            // 
            this.lblCapacityCurrent.AutoSize = true;
            this.lblCapacityCurrent.Location = new System.Drawing.Point(208, 5);
            this.lblCapacityCurrent.Name = "lblCapacityCurrent";
            this.lblCapacityCurrent.Size = new System.Drawing.Size(13, 13);
            this.lblCapacityCurrent.TabIndex = 40;
            this.lblCapacityCurrent.Text = "0";
            this.lblCapacityCurrent.Visible = false;
            // 
            // lblCapacityMax
            // 
            this.lblCapacityMax.AutoSize = true;
            this.lblCapacityMax.Location = new System.Drawing.Point(223, 5);
            this.lblCapacityMax.Name = "lblCapacityMax";
            this.lblCapacityMax.Size = new System.Drawing.Size(13, 13);
            this.lblCapacityMax.TabIndex = 41;
            this.lblCapacityMax.Text = "0";
            this.lblCapacityMax.Visible = false;
            // 
            // GMWeaponControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblCapacityMax);
            this.Controls.Add(this.lblCapacityCurrent);
            this.Controls.Add(this.lblWeaponId);
            this.Controls.Add(this.pnlAmmoControl);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.lblRangeText);
            this.Controls.Add(this.lblDamage);
            this.Controls.Add(this.lblDamageText);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.imgWeapon);
            this.Controls.Add(this.imgBreak);
            this.Controls.Add(this.lblAmmoText);
            this.Controls.Add(this.lblAmmo);
            this.Name = "GMWeaponControl";
            this.Size = new System.Drawing.Size(242, 110);
            ((System.ComponentModel.ISupportInitialize)(this.numSubt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAmmo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWeapon)).EndInit();
            this.pnlAmmoControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmmoText;
        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.NumericUpDown numSubt;
        private System.Windows.Forms.Button btnSubt;
        private System.Windows.Forms.NumericUpDown numAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox imgAmmo;
        private System.Windows.Forms.PictureBox imgBreak;
        private System.Windows.Forms.PictureBox imgWeapon;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDamageText;
        private System.Windows.Forms.Label lblDamage;
        private System.Windows.Forms.Label lblRangeText;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Panel pnlAmmoControl;
        private System.Windows.Forms.Label lblWeaponId;
        private System.Windows.Forms.Label lblCapacityCurrent;
        private System.Windows.Forms.Label lblCapacityMax;
    }
}
