namespace Pen_and_Paper_Visualator.Controls
{
    partial class Store
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
            this.pnlItemDisplay = new System.Windows.Forms.Panel();
            this.tabCtrlStock = new System.Windows.Forms.TabControl();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.pnlItems = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageWeapons = new System.Windows.Forms.TabPage();
            this.pnlWeapons = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageArmor = new System.Windows.Forms.TabPage();
            this.pnlArmor = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageVehicles = new System.Windows.Forms.TabPage();
            this.pnlVehicles = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPlayerGear = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.tabCtrlStock.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            this.tabPageWeapons.SuspendLayout();
            this.tabPageArmor.SuspendLayout();
            this.tabPageVehicles.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlItemDisplay
            // 
            this.pnlItemDisplay.Location = new System.Drawing.Point(12, 20);
            this.pnlItemDisplay.Name = "pnlItemDisplay";
            this.pnlItemDisplay.Size = new System.Drawing.Size(264, 278);
            this.pnlItemDisplay.TabIndex = 0;
            // 
            // tabCtrlStock
            // 
            this.tabCtrlStock.Controls.Add(this.tabPageItems);
            this.tabCtrlStock.Controls.Add(this.tabPageWeapons);
            this.tabCtrlStock.Controls.Add(this.tabPageArmor);
            this.tabCtrlStock.Controls.Add(this.tabPageVehicles);
            this.tabCtrlStock.Location = new System.Drawing.Point(292, 20);
            this.tabCtrlStock.Name = "tabCtrlStock";
            this.tabCtrlStock.SelectedIndex = 0;
            this.tabCtrlStock.Size = new System.Drawing.Size(208, 243);
            this.tabCtrlStock.TabIndex = 1;
            // 
            // tabPageItems
            // 
            this.tabPageItems.AutoScroll = true;
            this.tabPageItems.Controls.Add(this.pnlItems);
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems.Size = new System.Drawing.Size(200, 217);
            this.tabPageItems.TabIndex = 0;
            this.tabPageItems.Text = "Items";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // pnlItems
            // 
            this.pnlItems.AutoSize = true;
            this.pnlItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlItems.Location = new System.Drawing.Point(6, 6);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(170, 23);
            this.pnlItems.TabIndex = 0;
            // 
            // tabPageWeapons
            // 
            this.tabPageWeapons.AutoScroll = true;
            this.tabPageWeapons.Controls.Add(this.pnlWeapons);
            this.tabPageWeapons.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeapons.Name = "tabPageWeapons";
            this.tabPageWeapons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeapons.Size = new System.Drawing.Size(200, 217);
            this.tabPageWeapons.TabIndex = 1;
            this.tabPageWeapons.Text = "Weapons";
            this.tabPageWeapons.UseVisualStyleBackColor = true;
            // 
            // pnlWeapons
            // 
            this.pnlWeapons.AutoSize = true;
            this.pnlWeapons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlWeapons.Location = new System.Drawing.Point(6, 6);
            this.pnlWeapons.Name = "pnlWeapons";
            this.pnlWeapons.Size = new System.Drawing.Size(170, 23);
            this.pnlWeapons.TabIndex = 1;
            // 
            // tabPageArmor
            // 
            this.tabPageArmor.AutoScroll = true;
            this.tabPageArmor.Controls.Add(this.pnlArmor);
            this.tabPageArmor.Location = new System.Drawing.Point(4, 22);
            this.tabPageArmor.Name = "tabPageArmor";
            this.tabPageArmor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArmor.Size = new System.Drawing.Size(200, 217);
            this.tabPageArmor.TabIndex = 2;
            this.tabPageArmor.Text = "Armor";
            this.tabPageArmor.UseVisualStyleBackColor = true;
            // 
            // pnlArmor
            // 
            this.pnlArmor.AutoSize = true;
            this.pnlArmor.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlArmor.Location = new System.Drawing.Point(6, 6);
            this.pnlArmor.Name = "pnlArmor";
            this.pnlArmor.Size = new System.Drawing.Size(170, 23);
            this.pnlArmor.TabIndex = 1;
            // 
            // tabPageVehicles
            // 
            this.tabPageVehicles.AutoScroll = true;
            this.tabPageVehicles.Controls.Add(this.pnlVehicles);
            this.tabPageVehicles.Location = new System.Drawing.Point(4, 22);
            this.tabPageVehicles.Name = "tabPageVehicles";
            this.tabPageVehicles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVehicles.Size = new System.Drawing.Size(200, 217);
            this.tabPageVehicles.TabIndex = 3;
            this.tabPageVehicles.Text = "Vehicles";
            this.tabPageVehicles.UseVisualStyleBackColor = true;
            // 
            // pnlVehicles
            // 
            this.pnlVehicles.AutoSize = true;
            this.pnlVehicles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlVehicles.Location = new System.Drawing.Point(6, 6);
            this.pnlVehicles.Name = "pnlVehicles";
            this.pnlVehicles.Size = new System.Drawing.Size(170, 23);
            this.pnlVehicles.TabIndex = 1;
            // 
            // pnlPlayerGear
            // 
            this.pnlPlayerGear.AutoScroll = true;
            this.pnlPlayerGear.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlPlayerGear.Location = new System.Drawing.Point(521, 48);
            this.pnlPlayerGear.Name = "pnlPlayerGear";
            this.pnlPlayerGear.Size = new System.Drawing.Size(189, 211);
            this.pnlPlayerGear.TabIndex = 2;
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBuy.Enabled = false;
            this.btnBuy.ForeColor = System.Drawing.Color.White;
            this.btnBuy.Location = new System.Drawing.Point(332, 275);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(133, 37);
            this.btnBuy.TabIndex = 3;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSell.Enabled = false;
            this.btnSell.ForeColor = System.Drawing.Color.White;
            this.btnSell.Location = new System.Drawing.Point(557, 275);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(129, 37);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.pnlPlayerGear);
            this.Controls.Add(this.tabCtrlStock);
            this.Controls.Add(this.pnlItemDisplay);
            this.Name = "Store";
            this.Size = new System.Drawing.Size(723, 341);
            this.tabCtrlStock.ResumeLayout(false);
            this.tabPageItems.ResumeLayout(false);
            this.tabPageItems.PerformLayout();
            this.tabPageWeapons.ResumeLayout(false);
            this.tabPageWeapons.PerformLayout();
            this.tabPageArmor.ResumeLayout(false);
            this.tabPageArmor.PerformLayout();
            this.tabPageVehicles.ResumeLayout(false);
            this.tabPageVehicles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlItemDisplay;
        private System.Windows.Forms.TabControl tabCtrlStock;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.FlowLayoutPanel pnlItems;
        private System.Windows.Forms.TabPage tabPageWeapons;
        private System.Windows.Forms.FlowLayoutPanel pnlWeapons;
        private System.Windows.Forms.TabPage tabPageArmor;
        private System.Windows.Forms.FlowLayoutPanel pnlArmor;
        private System.Windows.Forms.TabPage tabPageVehicles;
        private System.Windows.Forms.FlowLayoutPanel pnlVehicles;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayerGear;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
    }
}
