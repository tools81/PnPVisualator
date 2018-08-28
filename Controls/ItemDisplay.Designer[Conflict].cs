namespace Pen_and_Paper_Visualator.Controls
{
    partial class ItemDisplay
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
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.imgItem = new System.Windows.Forms.PictureBox();
            this.lblActiveItem = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDurabilityText = new System.Windows.Forms.Label();
            this.lblDurability = new System.Windows.Forms.Label();
            this.lblStructureText = new System.Windows.Forms.Label();
            this.lblStucture = new System.Windows.Forms.Label();
            this.lblCostText = new System.Windows.Forms.Label();
            this.lblSizeText = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(3, 175);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(257, 99);
            this.txtDesc.TabIndex = 15;
            this.txtDesc.Text = "";
            // 
            // imgItem
            // 
            this.imgItem.BackColor = System.Drawing.Color.Black;
            this.imgItem.Location = new System.Drawing.Point(3, 21);
            this.imgItem.Name = "imgItem";
            this.imgItem.Size = new System.Drawing.Size(135, 135);
            this.imgItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgItem.TabIndex = 14;
            this.imgItem.TabStop = false;
            // 
            // lblActiveItem
            // 
            this.lblActiveItem.AutoSize = true;
            this.lblActiveItem.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveItem.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActiveItem.Location = new System.Drawing.Point(7, 2);
            this.lblActiveItem.Name = "lblActiveItem";
            this.lblActiveItem.Size = new System.Drawing.Size(0, 17);
            this.lblActiveItem.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.lblDurabilityText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDurability, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStructureText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblStucture, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(141, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(119, 41);
            this.tableLayoutPanel1.TabIndex = 17;
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
            this.lblDurability.Location = new System.Drawing.Point(74, 0);
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
            this.lblStucture.Location = new System.Drawing.Point(74, 20);
            this.lblStucture.Name = "lblStucture";
            this.lblStucture.Size = new System.Drawing.Size(13, 13);
            this.lblStucture.TabIndex = 22;
            this.lblStucture.Text = "0";
            // 
            // lblCostText
            // 
            this.lblCostText.AutoSize = true;
            this.lblCostText.Location = new System.Drawing.Point(3, 159);
            this.lblCostText.Name = "lblCostText";
            this.lblCostText.Size = new System.Drawing.Size(34, 13);
            this.lblCostText.TabIndex = 0;
            this.lblCostText.Text = "Value";
            // 
            // lblSizeText
            // 
            this.lblSizeText.AutoSize = true;
            this.lblSizeText.Location = new System.Drawing.Point(76, 159);
            this.lblSizeText.Name = "lblSizeText";
            this.lblSizeText.Size = new System.Drawing.Size(27, 13);
            this.lblSizeText.TabIndex = 18;
            this.lblSizeText.Text = "Size";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(43, 159);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(13, 13);
            this.lblCost.TabIndex = 19;
            this.lblCost.Text = "0";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(109, 159);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(13, 13);
            this.lblSize.TabIndex = 21;
            this.lblSize.Text = "0";
            // 
            // ItemDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblActiveItem);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.imgItem);
            this.Controls.Add(this.lblSizeText);
            this.Controls.Add(this.lblCostText);
            this.Controls.Add(this.lblCost);
            this.Name = "ItemDisplay";
            this.Size = new System.Drawing.Size(264, 278);
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgItem;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.Label lblActiveItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDurabilityText;
        private System.Windows.Forms.Label lblCostText;
        private System.Windows.Forms.Label lblStucture;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblDurability;
        private System.Windows.Forms.Label lblStructureText;
        private System.Windows.Forms.Label lblSizeText;
        private System.Windows.Forms.Label lblCost;
    }
}
