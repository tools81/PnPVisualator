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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgItem = new System.Windows.Forms.PictureBox();
            this.lblActiveItem = new System.Windows.Forms.Label();
            this.lblCostText = new System.Windows.Forms.Label();
            this.lblSizeText = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.gridDetails = new System.Windows.Forms.DataGridView();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // imgItem
            // 
            this.imgItem.BackColor = System.Drawing.Color.Black;
            this.imgItem.Location = new System.Drawing.Point(3, 21);
            this.imgItem.Name = "imgItem";
            this.imgItem.Size = new System.Drawing.Size(115, 115);
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
            // lblCostText
            // 
            this.lblCostText.AutoSize = true;
            this.lblCostText.Location = new System.Drawing.Point(3, 139);
            this.lblCostText.Name = "lblCostText";
            this.lblCostText.Size = new System.Drawing.Size(43, 13);
            this.lblCostText.TabIndex = 0;
            this.lblCostText.Text = "Value $";
            // 
            // lblSizeText
            // 
            this.lblSizeText.AutoSize = true;
            this.lblSizeText.Location = new System.Drawing.Point(79, 139);
            this.lblSizeText.Name = "lblSizeText";
            this.lblSizeText.Size = new System.Drawing.Size(27, 13);
            this.lblSizeText.TabIndex = 18;
            this.lblSizeText.Text = "Size";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(43, 139);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(13, 13);
            this.lblCost.TabIndex = 19;
            this.lblCost.Text = "0";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(112, 139);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(13, 13);
            this.lblSize.TabIndex = 21;
            this.lblSize.Text = "0";
            // 
            // gridDetails
            // 
            this.gridDetails.AllowUserToAddRows = false;
            this.gridDetails.AllowUserToDeleteRows = false;
            this.gridDetails.AllowUserToResizeColumns = false;
            this.gridDetails.AllowUserToResizeRows = false;
            this.gridDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter,
            this.Value});
            this.gridDetails.Location = new System.Drawing.Point(122, 3);
            this.gridDetails.MultiSelect = false;
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.ReadOnly = true;
            this.gridDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridDetails.Size = new System.Drawing.Size(137, 149);
            this.gridDetails.TabIndex = 22;
            // 
            // Parameter
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parameter.DefaultCellStyle = dataGridViewCellStyle2;
            this.Parameter.HeaderText = "Parameter";
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            this.Parameter.Width = 67;
            // 
            // Value
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value.DefaultCellStyle = dataGridViewCellStyle3;
            this.Value.HeaderText = "Val";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 70;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(4, 158);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtDesc.Size = new System.Drawing.Size(254, 119);
            this.txtDesc.TabIndex = 23;
            this.txtDesc.Text = "";
            // 
            // ItemDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.gridDetails);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblActiveItem);
            this.Controls.Add(this.imgItem);
            this.Controls.Add(this.lblSizeText);
            this.Controls.Add(this.lblCostText);
            this.Controls.Add(this.lblCost);
            this.Name = "ItemDisplay";
            this.Size = new System.Drawing.Size(264, 278);
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgItem;
        private System.Windows.Forms.Label lblActiveItem;
        private System.Windows.Forms.Label lblCostText;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSizeText;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.DataGridView gridDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.RichTextBox txtDesc;
    }
}
