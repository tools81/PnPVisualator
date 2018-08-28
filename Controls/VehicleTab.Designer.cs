namespace Pen_and_Paper_Visualator.Controls
{
    partial class VehicleTab
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
            this.gbxGarage = new System.Windows.Forms.GroupBox();
            this.pnlVehicles = new System.Windows.Forms.FlowLayoutPanel();
            this.lblActiveVehicle = new System.Windows.Forms.Label();
            this.tabVehicle = new System.Windows.Forms.TabControl();
            this.tabPageDescription = new System.Windows.Forms.TabPage();
            this.tabPageCargo = new System.Windows.Forms.TabPage();
            this.lblActiveItem = new System.Windows.Forms.Label();
            this.gbxItem = new System.Windows.Forms.GroupBox();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblRetrieve = new System.Windows.Forms.Label();
            this.lblItem12 = new System.Windows.Forms.Label();
            this.lblItem11 = new System.Windows.Forms.Label();
            this.lblItem10 = new System.Windows.Forms.Label();
            this.lblItem9 = new System.Windows.Forms.Label();
            this.lblItem16 = new System.Windows.Forms.Label();
            this.lblItem15 = new System.Windows.Forms.Label();
            this.lblItem14 = new System.Windows.Forms.Label();
            this.lblItem13 = new System.Windows.Forms.Label();
            this.lblItem8 = new System.Windows.Forms.Label();
            this.lblItem7 = new System.Windows.Forms.Label();
            this.lblItem6 = new System.Windows.Forms.Label();
            this.lblItem5 = new System.Windows.Forms.Label();
            this.lblItem4 = new System.Windows.Forms.Label();
            this.lblItem3 = new System.Windows.Forms.Label();
            this.lblItem2 = new System.Windows.Forms.Label();
            this.lblItem1 = new System.Windows.Forms.Label();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.imgItem = new System.Windows.Forms.PictureBox();
            this.gbxGarage.SuspendLayout();
            this.tabVehicle.SuspendLayout();
            this.tabPageCargo.SuspendLayout();
            this.gbxItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxGarage
            // 
            this.gbxGarage.Controls.Add(this.pnlVehicles);
            this.gbxGarage.ForeColor = System.Drawing.Color.Black;
            this.gbxGarage.Location = new System.Drawing.Point(5, 14);
            this.gbxGarage.Name = "gbxGarage";
            this.gbxGarage.Size = new System.Drawing.Size(276, 172);
            this.gbxGarage.TabIndex = 9;
            this.gbxGarage.TabStop = false;
            this.gbxGarage.Text = "Garage";
            // 
            // pnlVehicles
            // 
            this.pnlVehicles.AutoScroll = true;
            this.pnlVehicles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlVehicles.Location = new System.Drawing.Point(6, 18);
            this.pnlVehicles.Name = "pnlVehicles";
            this.pnlVehicles.Size = new System.Drawing.Size(264, 148);
            this.pnlVehicles.TabIndex = 20;
            // 
            // lblActiveVehicle
            // 
            this.lblActiveVehicle.AutoSize = true;
            this.lblActiveVehicle.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveVehicle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActiveVehicle.Location = new System.Drawing.Point(11, 206);
            this.lblActiveVehicle.Name = "lblActiveVehicle";
            this.lblActiveVehicle.Size = new System.Drawing.Size(0, 17);
            this.lblActiveVehicle.TabIndex = 15;
            this.lblActiveVehicle.Visible = false;
            // 
            // tabVehicle
            // 
            this.tabVehicle.Controls.Add(this.tabPageDescription);
            this.tabVehicle.Controls.Add(this.tabPageCargo);
            this.tabVehicle.Location = new System.Drawing.Point(5, 276);
            this.tabVehicle.Name = "tabVehicle";
            this.tabVehicle.SelectedIndex = 0;
            this.tabVehicle.Size = new System.Drawing.Size(276, 350);
            this.tabVehicle.TabIndex = 18;
            // 
            // tabPageDescription
            // 
            this.tabPageDescription.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDescription.Location = new System.Drawing.Point(4, 22);
            this.tabPageDescription.Name = "tabPageDescription";
            this.tabPageDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDescription.Size = new System.Drawing.Size(268, 324);
            this.tabPageDescription.TabIndex = 0;
            this.tabPageDescription.Text = "Description";
            // 
            // tabPageCargo
            // 
            this.tabPageCargo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCargo.Controls.Add(this.lblActiveItem);
            this.tabPageCargo.Controls.Add(this.gbxItem);
            this.tabPageCargo.Controls.Add(this.txtItemDescription);
            this.tabPageCargo.Controls.Add(this.imgItem);
            this.tabPageCargo.Location = new System.Drawing.Point(4, 22);
            this.tabPageCargo.Name = "tabPageCargo";
            this.tabPageCargo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCargo.Size = new System.Drawing.Size(268, 324);
            this.tabPageCargo.TabIndex = 1;
            this.tabPageCargo.Text = "Cargo";
            // 
            // lblActiveItem
            // 
            this.lblActiveItem.AutoSize = true;
            this.lblActiveItem.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveItem.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActiveItem.Location = new System.Drawing.Point(14, 215);
            this.lblActiveItem.Name = "lblActiveItem";
            this.lblActiveItem.Size = new System.Drawing.Size(0, 17);
            this.lblActiveItem.TabIndex = 30;
            // 
            // gbxItem
            // 
            this.gbxItem.BackColor = System.Drawing.SystemColors.Control;
            this.gbxItem.Controls.Add(this.lblAdd);
            this.gbxItem.Controls.Add(this.lblRetrieve);
            this.gbxItem.Controls.Add(this.lblItem12);
            this.gbxItem.Controls.Add(this.lblItem11);
            this.gbxItem.Controls.Add(this.lblItem10);
            this.gbxItem.Controls.Add(this.lblItem9);
            this.gbxItem.Controls.Add(this.lblItem16);
            this.gbxItem.Controls.Add(this.lblItem15);
            this.gbxItem.Controls.Add(this.lblItem14);
            this.gbxItem.Controls.Add(this.lblItem13);
            this.gbxItem.Controls.Add(this.lblItem8);
            this.gbxItem.Controls.Add(this.lblItem7);
            this.gbxItem.Controls.Add(this.lblItem6);
            this.gbxItem.Controls.Add(this.lblItem5);
            this.gbxItem.Controls.Add(this.lblItem4);
            this.gbxItem.Controls.Add(this.lblItem3);
            this.gbxItem.Controls.Add(this.lblItem2);
            this.gbxItem.Controls.Add(this.lblItem1);
            this.gbxItem.ForeColor = System.Drawing.Color.Black;
            this.gbxItem.Location = new System.Drawing.Point(0, 6);
            this.gbxItem.Name = "gbxItem";
            this.gbxItem.Size = new System.Drawing.Size(247, 206);
            this.gbxItem.TabIndex = 17;
            this.gbxItem.TabStop = false;
            this.gbxItem.Text = "Items";
            this.gbxItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.gbxItem_DragDrop);
            this.gbxItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.gbxItem_DragEnter);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAdd.ForeColor = System.Drawing.Color.White;
            this.lblAdd.Location = new System.Drawing.Point(176, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(51, 15);
            this.lblAdd.TabIndex = 31;
            this.lblAdd.Text = "Add Item";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // lblRetrieve
            // 
            this.lblRetrieve.AutoSize = true;
            this.lblRetrieve.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblRetrieve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRetrieve.ForeColor = System.Drawing.Color.White;
            this.lblRetrieve.Location = new System.Drawing.Point(65, 0);
            this.lblRetrieve.Name = "lblRetrieve";
            this.lblRetrieve.Size = new System.Drawing.Size(49, 15);
            this.lblRetrieve.TabIndex = 19;
            this.lblRetrieve.Text = "Retrieve";
            this.lblRetrieve.Click += new System.EventHandler(this.lblRetrieve_Click);
            // 
            // lblItem12
            // 
            this.lblItem12.AutoSize = true;
            this.lblItem12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem12.Location = new System.Drawing.Point(136, 88);
            this.lblItem12.Name = "lblItem12";
            this.lblItem12.Size = new System.Drawing.Size(16, 13);
            this.lblItem12.TabIndex = 30;
            this.lblItem12.Text = "...";
            this.lblItem12.Click += new System.EventHandler(this.lblItem12_Click);
            // 
            // lblItem11
            // 
            this.lblItem11.AutoSize = true;
            this.lblItem11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem11.Location = new System.Drawing.Point(136, 65);
            this.lblItem11.Name = "lblItem11";
            this.lblItem11.Size = new System.Drawing.Size(16, 13);
            this.lblItem11.TabIndex = 29;
            this.lblItem11.Text = "...";
            this.lblItem11.Click += new System.EventHandler(this.lblItem11_Click);
            // 
            // lblItem10
            // 
            this.lblItem10.AutoSize = true;
            this.lblItem10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem10.Location = new System.Drawing.Point(136, 41);
            this.lblItem10.Name = "lblItem10";
            this.lblItem10.Size = new System.Drawing.Size(16, 13);
            this.lblItem10.TabIndex = 28;
            this.lblItem10.Text = "...";
            this.lblItem10.Click += new System.EventHandler(this.lblItem10_Click);
            // 
            // lblItem9
            // 
            this.lblItem9.AutoSize = true;
            this.lblItem9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem9.Location = new System.Drawing.Point(136, 18);
            this.lblItem9.Name = "lblItem9";
            this.lblItem9.Size = new System.Drawing.Size(16, 13);
            this.lblItem9.TabIndex = 27;
            this.lblItem9.Text = "...";
            this.lblItem9.Click += new System.EventHandler(this.lblItem9_Click);
            // 
            // lblItem16
            // 
            this.lblItem16.AutoSize = true;
            this.lblItem16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem16.Location = new System.Drawing.Point(136, 181);
            this.lblItem16.Name = "lblItem16";
            this.lblItem16.Size = new System.Drawing.Size(16, 13);
            this.lblItem16.TabIndex = 26;
            this.lblItem16.Text = "...";
            this.lblItem16.Click += new System.EventHandler(this.lblItem16_Click);
            // 
            // lblItem15
            // 
            this.lblItem15.AutoSize = true;
            this.lblItem15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem15.Location = new System.Drawing.Point(136, 158);
            this.lblItem15.Name = "lblItem15";
            this.lblItem15.Size = new System.Drawing.Size(16, 13);
            this.lblItem15.TabIndex = 25;
            this.lblItem15.Text = "...";
            this.lblItem15.Click += new System.EventHandler(this.lblItem15_Click);
            // 
            // lblItem14
            // 
            this.lblItem14.AutoSize = true;
            this.lblItem14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem14.Location = new System.Drawing.Point(136, 134);
            this.lblItem14.Name = "lblItem14";
            this.lblItem14.Size = new System.Drawing.Size(16, 13);
            this.lblItem14.TabIndex = 24;
            this.lblItem14.Text = "...";
            this.lblItem14.Click += new System.EventHandler(this.lblItem14_Click);
            // 
            // lblItem13
            // 
            this.lblItem13.AutoSize = true;
            this.lblItem13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem13.Location = new System.Drawing.Point(136, 111);
            this.lblItem13.Name = "lblItem13";
            this.lblItem13.Size = new System.Drawing.Size(16, 13);
            this.lblItem13.TabIndex = 23;
            this.lblItem13.Text = "...";
            this.lblItem13.Click += new System.EventHandler(this.lblItem13_Click);
            // 
            // lblItem8
            // 
            this.lblItem8.AutoSize = true;
            this.lblItem8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem8.Location = new System.Drawing.Point(21, 181);
            this.lblItem8.Name = "lblItem8";
            this.lblItem8.Size = new System.Drawing.Size(16, 13);
            this.lblItem8.TabIndex = 18;
            this.lblItem8.Text = "...";
            this.lblItem8.Click += new System.EventHandler(this.lblItem8_Click);
            // 
            // lblItem7
            // 
            this.lblItem7.AutoSize = true;
            this.lblItem7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem7.Location = new System.Drawing.Point(21, 158);
            this.lblItem7.Name = "lblItem7";
            this.lblItem7.Size = new System.Drawing.Size(16, 13);
            this.lblItem7.TabIndex = 17;
            this.lblItem7.Text = "...";
            this.lblItem7.Click += new System.EventHandler(this.lblItem7_Click);
            // 
            // lblItem6
            // 
            this.lblItem6.AutoSize = true;
            this.lblItem6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem6.Location = new System.Drawing.Point(21, 134);
            this.lblItem6.Name = "lblItem6";
            this.lblItem6.Size = new System.Drawing.Size(16, 13);
            this.lblItem6.TabIndex = 16;
            this.lblItem6.Text = "...";
            this.lblItem6.Click += new System.EventHandler(this.lblItem6_Click);
            // 
            // lblItem5
            // 
            this.lblItem5.AutoSize = true;
            this.lblItem5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem5.Location = new System.Drawing.Point(21, 111);
            this.lblItem5.Name = "lblItem5";
            this.lblItem5.Size = new System.Drawing.Size(16, 13);
            this.lblItem5.TabIndex = 15;
            this.lblItem5.Text = "...";
            this.lblItem5.Click += new System.EventHandler(this.lblItem5_Click);
            // 
            // lblItem4
            // 
            this.lblItem4.AutoSize = true;
            this.lblItem4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem4.Location = new System.Drawing.Point(21, 88);
            this.lblItem4.Name = "lblItem4";
            this.lblItem4.Size = new System.Drawing.Size(16, 13);
            this.lblItem4.TabIndex = 14;
            this.lblItem4.Text = "...";
            this.lblItem4.Click += new System.EventHandler(this.lblItem4_Click);
            // 
            // lblItem3
            // 
            this.lblItem3.AutoSize = true;
            this.lblItem3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem3.Location = new System.Drawing.Point(21, 65);
            this.lblItem3.Name = "lblItem3";
            this.lblItem3.Size = new System.Drawing.Size(16, 13);
            this.lblItem3.TabIndex = 13;
            this.lblItem3.Text = "...";
            this.lblItem3.Click += new System.EventHandler(this.lblItem3_Click);
            // 
            // lblItem2
            // 
            this.lblItem2.AutoSize = true;
            this.lblItem2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem2.Location = new System.Drawing.Point(21, 41);
            this.lblItem2.Name = "lblItem2";
            this.lblItem2.Size = new System.Drawing.Size(16, 13);
            this.lblItem2.TabIndex = 12;
            this.lblItem2.Text = "...";
            this.lblItem2.Click += new System.EventHandler(this.lblItem2_Click);
            // 
            // lblItem1
            // 
            this.lblItem1.AutoSize = true;
            this.lblItem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItem1.Location = new System.Drawing.Point(21, 18);
            this.lblItem1.Name = "lblItem1";
            this.lblItem1.Size = new System.Drawing.Size(16, 13);
            this.lblItem1.TabIndex = 11;
            this.lblItem1.Text = "...";
            this.lblItem1.Click += new System.EventHandler(this.lblItem1_Click);
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemDescription.Location = new System.Drawing.Point(3, 235);
            this.txtItemDescription.Multiline = true;
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.ReadOnly = true;
            this.txtItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItemDescription.Size = new System.Drawing.Size(143, 83);
            this.txtItemDescription.TabIndex = 16;
            // 
            // imgItem
            // 
            this.imgItem.Location = new System.Drawing.Point(147, 218);
            this.imgItem.Name = "imgItem";
            this.imgItem.Size = new System.Drawing.Size(100, 100);
            this.imgItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgItem.TabIndex = 15;
            this.imgItem.TabStop = false;
            // 
            // VehicleTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tabVehicle);
            this.Controls.Add(this.lblActiveVehicle);
            this.Controls.Add(this.gbxGarage);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "VehicleTab";
            this.Size = new System.Drawing.Size(286, 652);
            this.gbxGarage.ResumeLayout(false);
            this.tabVehicle.ResumeLayout(false);
            this.tabPageCargo.ResumeLayout(false);
            this.tabPageCargo.PerformLayout();
            this.gbxItem.ResumeLayout(false);
            this.gbxItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxGarage;
        private System.Windows.Forms.Label lblActiveVehicle;
        private System.Windows.Forms.TabControl tabVehicle;
        private System.Windows.Forms.TabPage tabPageDescription;
        private System.Windows.Forms.TabPage tabPageCargo;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.PictureBox imgItem;
        private System.Windows.Forms.GroupBox gbxItem;
        private System.Windows.Forms.Label lblItem16;
        private System.Windows.Forms.Label lblItem15;
        private System.Windows.Forms.Label lblItem14;
        private System.Windows.Forms.Label lblItem13;
        private System.Windows.Forms.Label lblItem8;
        private System.Windows.Forms.Label lblItem7;
        private System.Windows.Forms.Label lblItem6;
        private System.Windows.Forms.Label lblItem5;
        private System.Windows.Forms.Label lblItem4;
        private System.Windows.Forms.Label lblItem3;
        private System.Windows.Forms.Label lblItem2;
        private System.Windows.Forms.Label lblItem1;
        private System.Windows.Forms.Label lblItem12;
        private System.Windows.Forms.Label lblItem11;
        private System.Windows.Forms.Label lblItem10;
        private System.Windows.Forms.Label lblItem9;
        private System.Windows.Forms.Label lblActiveItem;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblRetrieve;
        private System.Windows.Forms.FlowLayoutPanel pnlVehicles;
    }
}
