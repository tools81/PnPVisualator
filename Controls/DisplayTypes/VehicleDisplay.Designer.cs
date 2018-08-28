namespace Pen_and_Paper_Visualator.Controls
{
    partial class VehicleDisplay
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
            this.lblActiveVehicle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblCapacityText = new System.Windows.Forms.Label();
            this.lblOccupancy = new System.Windows.Forms.Label();
            this.lblHandling = new System.Windows.Forms.Label();
            this.lblMaxSpeed = new System.Windows.Forms.Label();
            this.lblSafeSpeed = new System.Windows.Forms.Label();
            this.lblDurabilityText = new System.Windows.Forms.Label();
            this.lblDurability = new System.Windows.Forms.Label();
            this.lblStructureText = new System.Windows.Forms.Label();
            this.lblStucture = new System.Windows.Forms.Label();
            this.lblAccelerationText = new System.Windows.Forms.Label();
            this.lblSafeSpeedText = new System.Windows.Forms.Label();
            this.lblMaxSpeedText = new System.Windows.Forms.Label();
            this.lblHandlingText = new System.Windows.Forms.Label();
            this.lblOccupancyText = new System.Windows.Forms.Label();
            this.lblAcceleration = new System.Windows.Forms.Label();
            this.imgVehicle = new System.Windows.Forms.PictureBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSizeText = new System.Windows.Forms.Label();
            this.lblCostText = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblActiveVehicle
            // 
            this.lblActiveVehicle.AutoSize = true;
            this.lblActiveVehicle.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveVehicle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActiveVehicle.Location = new System.Drawing.Point(7, 2);
            this.lblActiveVehicle.Name = "lblActiveVehicle";
            this.lblActiveVehicle.Size = new System.Drawing.Size(0, 17);
            this.lblActiveVehicle.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.lblCapacity, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblCapacityText, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblOccupancy, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblHandling, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblMaxSpeed, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblSafeSpeed, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDurabilityText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDurability, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStructureText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblStucture, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAccelerationText, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSafeSpeedText, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMaxSpeedText, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblHandlingText, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblOccupancyText, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblAcceleration, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(141, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(119, 157);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(80, 140);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(13, 13);
            this.lblCapacity.TabIndex = 22;
            this.lblCapacity.Text = "0";
            // 
            // lblCapacityText
            // 
            this.lblCapacityText.AutoSize = true;
            this.lblCapacityText.Location = new System.Drawing.Point(3, 140);
            this.lblCapacityText.Name = "lblCapacityText";
            this.lblCapacityText.Size = new System.Drawing.Size(48, 13);
            this.lblCapacityText.TabIndex = 28;
            this.lblCapacityText.Text = "Capacity";
            // 
            // lblOccupancy
            // 
            this.lblOccupancy.AutoSize = true;
            this.lblOccupancy.Location = new System.Drawing.Point(80, 120);
            this.lblOccupancy.Name = "lblOccupancy";
            this.lblOccupancy.Size = new System.Drawing.Size(13, 13);
            this.lblOccupancy.TabIndex = 21;
            this.lblOccupancy.Text = "0";
            // 
            // lblHandling
            // 
            this.lblHandling.AutoSize = true;
            this.lblHandling.Location = new System.Drawing.Point(80, 100);
            this.lblHandling.Name = "lblHandling";
            this.lblHandling.Size = new System.Drawing.Size(13, 13);
            this.lblHandling.TabIndex = 21;
            this.lblHandling.Text = "0";
            // 
            // lblMaxSpeed
            // 
            this.lblMaxSpeed.AutoSize = true;
            this.lblMaxSpeed.Location = new System.Drawing.Point(80, 80);
            this.lblMaxSpeed.Name = "lblMaxSpeed";
            this.lblMaxSpeed.Size = new System.Drawing.Size(13, 13);
            this.lblMaxSpeed.TabIndex = 21;
            this.lblMaxSpeed.Text = "0";
            // 
            // lblSafeSpeed
            // 
            this.lblSafeSpeed.AutoSize = true;
            this.lblSafeSpeed.Location = new System.Drawing.Point(80, 60);
            this.lblSafeSpeed.Name = "lblSafeSpeed";
            this.lblSafeSpeed.Size = new System.Drawing.Size(13, 13);
            this.lblSafeSpeed.TabIndex = 21;
            this.lblSafeSpeed.Text = "0";
            // 
            // lblDurabilityText
            // 
            this.lblDurabilityText.AutoSize = true;
            this.lblDurabilityText.Location = new System.Drawing.Point(3, 0);
            this.lblDurabilityText.Name = "lblDurabilityText";
            this.lblDurabilityText.Size = new System.Drawing.Size(50, 13);
            this.lblDurabilityText.TabIndex = 18;
            this.lblDurabilityText.Text = "Durability";
            // 
            // lblDurability
            // 
            this.lblDurability.AutoSize = true;
            this.lblDurability.Location = new System.Drawing.Point(80, 0);
            this.lblDurability.Name = "lblDurability";
            this.lblDurability.Size = new System.Drawing.Size(13, 13);
            this.lblDurability.TabIndex = 20;
            this.lblDurability.Text = "0";
            // 
            // lblStructureText
            // 
            this.lblStructureText.AutoSize = true;
            this.lblStructureText.Location = new System.Drawing.Point(3, 20);
            this.lblStructureText.Name = "lblStructureText";
            this.lblStructureText.Size = new System.Drawing.Size(50, 13);
            this.lblStructureText.TabIndex = 18;
            this.lblStructureText.Text = "Structure";
            // 
            // lblStucture
            // 
            this.lblStucture.AutoSize = true;
            this.lblStucture.Location = new System.Drawing.Point(80, 20);
            this.lblStucture.Name = "lblStucture";
            this.lblStucture.Size = new System.Drawing.Size(13, 13);
            this.lblStucture.TabIndex = 22;
            this.lblStucture.Text = "0";
            // 
            // lblAccelerationText
            // 
            this.lblAccelerationText.AutoSize = true;
            this.lblAccelerationText.Location = new System.Drawing.Point(3, 40);
            this.lblAccelerationText.Name = "lblAccelerationText";
            this.lblAccelerationText.Size = new System.Drawing.Size(66, 13);
            this.lblAccelerationText.TabIndex = 23;
            this.lblAccelerationText.Text = "Acceleration";
            // 
            // lblSafeSpeedText
            // 
            this.lblSafeSpeedText.AutoSize = true;
            this.lblSafeSpeedText.Location = new System.Drawing.Point(3, 60);
            this.lblSafeSpeedText.Name = "lblSafeSpeedText";
            this.lblSafeSpeedText.Size = new System.Drawing.Size(63, 13);
            this.lblSafeSpeedText.TabIndex = 24;
            this.lblSafeSpeedText.Text = "Safe Speed";
            // 
            // lblMaxSpeedText
            // 
            this.lblMaxSpeedText.AutoSize = true;
            this.lblMaxSpeedText.Location = new System.Drawing.Point(3, 80);
            this.lblMaxSpeedText.Name = "lblMaxSpeedText";
            this.lblMaxSpeedText.Size = new System.Drawing.Size(61, 13);
            this.lblMaxSpeedText.TabIndex = 25;
            this.lblMaxSpeedText.Text = "Max Speed";
            // 
            // lblHandlingText
            // 
            this.lblHandlingText.AutoSize = true;
            this.lblHandlingText.Location = new System.Drawing.Point(3, 100);
            this.lblHandlingText.Name = "lblHandlingText";
            this.lblHandlingText.Size = new System.Drawing.Size(49, 13);
            this.lblHandlingText.TabIndex = 26;
            this.lblHandlingText.Text = "Handling";
            // 
            // lblOccupancyText
            // 
            this.lblOccupancyText.AutoSize = true;
            this.lblOccupancyText.Location = new System.Drawing.Point(3, 120);
            this.lblOccupancyText.Name = "lblOccupancyText";
            this.lblOccupancyText.Size = new System.Drawing.Size(62, 13);
            this.lblOccupancyText.TabIndex = 27;
            this.lblOccupancyText.Text = "Occupancy";
            // 
            // lblAcceleration
            // 
            this.lblAcceleration.AutoSize = true;
            this.lblAcceleration.Location = new System.Drawing.Point(80, 40);
            this.lblAcceleration.Name = "lblAcceleration";
            this.lblAcceleration.Size = new System.Drawing.Size(13, 13);
            this.lblAcceleration.TabIndex = 28;
            this.lblAcceleration.Text = "0";
            // 
            // imgVehicle
            // 
            this.imgVehicle.BackColor = System.Drawing.Color.Black;
            this.imgVehicle.Location = new System.Drawing.Point(3, 21);
            this.imgVehicle.Name = "imgVehicle";
            this.imgVehicle.Size = new System.Drawing.Size(135, 135);
            this.imgVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgVehicle.TabIndex = 17;
            this.imgVehicle.TabStop = false;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(122, 160);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(13, 13);
            this.lblSize.TabIndex = 25;
            this.lblSize.Text = "0";
            // 
            // lblSizeText
            // 
            this.lblSizeText.AutoSize = true;
            this.lblSizeText.Location = new System.Drawing.Point(89, 160);
            this.lblSizeText.Name = "lblSizeText";
            this.lblSizeText.Size = new System.Drawing.Size(27, 13);
            this.lblSizeText.TabIndex = 23;
            this.lblSizeText.Text = "Size";
            // 
            // lblCostText
            // 
            this.lblCostText.AutoSize = true;
            this.lblCostText.Location = new System.Drawing.Point(3, 160);
            this.lblCostText.Name = "lblCostText";
            this.lblCostText.Size = new System.Drawing.Size(43, 13);
            this.lblCostText.TabIndex = 22;
            this.lblCostText.Text = "Value $";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(43, 160);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(13, 13);
            this.lblCost.TabIndex = 24;
            this.lblCost.Text = "0";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(3, 178);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtDesc.Size = new System.Drawing.Size(256, 99);
            this.txtDesc.TabIndex = 26;
            this.txtDesc.Text = "";
            // 
            // VehicleDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblSizeText);
            this.Controls.Add(this.lblCostText);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblActiveVehicle);
            this.Controls.Add(this.imgVehicle);
            this.Name = "VehicleDisplay";
            this.Size = new System.Drawing.Size(264, 278);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblActiveVehicle;
        private System.Windows.Forms.PictureBox imgVehicle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDurabilityText;
        private System.Windows.Forms.Label lblDurability;
        private System.Windows.Forms.Label lblStructureText;
        private System.Windows.Forms.Label lblStucture;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblCapacityText;
        private System.Windows.Forms.Label lblOccupancy;
        private System.Windows.Forms.Label lblHandling;
        private System.Windows.Forms.Label lblMaxSpeed;
        private System.Windows.Forms.Label lblSafeSpeed;
        private System.Windows.Forms.Label lblAccelerationText;
        private System.Windows.Forms.Label lblSafeSpeedText;
        private System.Windows.Forms.Label lblMaxSpeedText;
        private System.Windows.Forms.Label lblHandlingText;
        private System.Windows.Forms.Label lblOccupancyText;
        private System.Windows.Forms.Label lblAcceleration;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSizeText;
        private System.Windows.Forms.Label lblCostText;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.RichTextBox txtDesc;
    }
}
