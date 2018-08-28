namespace Pen_and_Paper_Visualator.Controls
{
    partial class EquipmentTab
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.gbxWeapon = new System.Windows.Forms.GroupBox();
            this.pnlWeapons = new System.Windows.Forms.FlowLayoutPanel();
            this.gbxArmor = new System.Windows.Forms.GroupBox();
            this.pnlArmor = new System.Windows.Forms.FlowLayoutPanel();
            this.gbxItem = new System.Windows.Forms.GroupBox();
            this.pnlItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblKeys = new System.Windows.Forms.Label();
            this.pnlItemDisplay = new System.Windows.Forms.Panel();
            this.gbxWeapon.SuspendLayout();
            this.gbxArmor.SuspendLayout();
            this.gbxItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cash  $";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(133, 7);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(38, 13);
            this.lblMoney.TabIndex = 2;
            this.lblMoney.Text = "money";
            // 
            // gbxWeapon
            // 
            this.gbxWeapon.BackColor = System.Drawing.SystemColors.Control;
            this.gbxWeapon.Controls.Add(this.pnlWeapons);
            this.gbxWeapon.ForeColor = System.Drawing.Color.Black;
            this.gbxWeapon.Location = new System.Drawing.Point(8, 23);
            this.gbxWeapon.Name = "gbxWeapon";
            this.gbxWeapon.Size = new System.Drawing.Size(272, 103);
            this.gbxWeapon.TabIndex = 8;
            this.gbxWeapon.TabStop = false;
            this.gbxWeapon.Text = "Weapons";
            // 
            // pnlWeapons
            // 
            this.pnlWeapons.AutoScroll = true;
            this.pnlWeapons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlWeapons.Location = new System.Drawing.Point(6, 19);
            this.pnlWeapons.Name = "pnlWeapons";
            this.pnlWeapons.Size = new System.Drawing.Size(261, 78);
            this.pnlWeapons.TabIndex = 19;
            // 
            // gbxArmor
            // 
            this.gbxArmor.BackColor = System.Drawing.SystemColors.Control;
            this.gbxArmor.Controls.Add(this.pnlArmor);
            this.gbxArmor.ForeColor = System.Drawing.Color.Black;
            this.gbxArmor.Location = new System.Drawing.Point(8, 132);
            this.gbxArmor.Name = "gbxArmor";
            this.gbxArmor.Size = new System.Drawing.Size(272, 84);
            this.gbxArmor.TabIndex = 9;
            this.gbxArmor.TabStop = false;
            this.gbxArmor.Text = "Armor";
            // 
            // pnlArmor
            // 
            this.pnlArmor.AutoScroll = true;
            this.pnlArmor.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlArmor.Location = new System.Drawing.Point(6, 19);
            this.pnlArmor.Name = "pnlArmor";
            this.pnlArmor.Size = new System.Drawing.Size(261, 59);
            this.pnlArmor.TabIndex = 18;
            // 
            // gbxItem
            // 
            this.gbxItem.BackColor = System.Drawing.SystemColors.Control;
            this.gbxItem.Controls.Add(this.pnlItems);
            this.gbxItem.ForeColor = System.Drawing.Color.Black;
            this.gbxItem.Location = new System.Drawing.Point(9, 222);
            this.gbxItem.Name = "gbxItem";
            this.gbxItem.Size = new System.Drawing.Size(271, 126);
            this.gbxItem.TabIndex = 10;
            this.gbxItem.TabStop = false;
            this.gbxItem.Text = "Items";
            // 
            // pnlItems
            // 
            this.pnlItems.AutoScroll = true;
            this.pnlItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlItems.Location = new System.Drawing.Point(6, 19);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(261, 101);
            this.pnlItems.TabIndex = 17;
            // 
            // lblKeys
            // 
            this.lblKeys.AutoSize = true;
            this.lblKeys.BackColor = System.Drawing.Color.Gold;
            this.lblKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKeys.ForeColor = System.Drawing.Color.Black;
            this.lblKeys.Location = new System.Drawing.Point(225, 7);
            this.lblKeys.Name = "lblKeys";
            this.lblKeys.Size = new System.Drawing.Size(52, 15);
            this.lblKeys.TabIndex = 15;
            this.lblKeys.Text = "Key Ring";
            this.lblKeys.Click += new System.EventHandler(this.lblKeys_Click);
            // 
            // pnlItemDisplay
            // 
            this.pnlItemDisplay.Location = new System.Drawing.Point(11, 354);
            this.pnlItemDisplay.Name = "pnlItemDisplay";
            this.pnlItemDisplay.Size = new System.Drawing.Size(264, 278);
            this.pnlItemDisplay.TabIndex = 16;
            // 
            // EquipmentTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlItemDisplay);
            this.Controls.Add(this.lblKeys);
            this.Controls.Add(this.gbxItem);
            this.Controls.Add(this.gbxArmor);
            this.Controls.Add(this.gbxWeapon);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "EquipmentTab";
            this.Size = new System.Drawing.Size(290, 652);
            this.Load += new System.EventHandler(this.EquipmentTab_Load);
            this.gbxWeapon.ResumeLayout(false);
            this.gbxArmor.ResumeLayout(false);
            this.gbxItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.GroupBox gbxWeapon;
        private System.Windows.Forms.GroupBox gbxArmor;
        private System.Windows.Forms.GroupBox gbxItem;
        private System.Windows.Forms.Label lblKeys;
        private System.Windows.Forms.Panel pnlItemDisplay;
        private System.Windows.Forms.FlowLayoutPanel pnlItems;
        private System.Windows.Forms.FlowLayoutPanel pnlWeapons;
        private System.Windows.Forms.FlowLayoutPanel pnlArmor;
    }
}
