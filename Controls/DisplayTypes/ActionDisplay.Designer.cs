namespace Pen_and_Paper_Visualator.Controls
{
    partial class ActionDisplay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.lblExtended = new System.Windows.Forms.Label();
            this.gridDetails = new System.Windows.Forms.DataGridView();
            this.gridContested = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContested)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(134, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Action Name";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(217, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 31);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "00";
            // 
            // lblSuccess
            // 
            this.lblSuccess.Location = new System.Drawing.Point(3, 233);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(260, 35);
            this.lblSuccess.TabIndex = 2;
            this.lblSuccess.Text = "Success qualifications";
            // 
            // lblExtended
            // 
            this.lblExtended.Location = new System.Drawing.Point(3, 203);
            this.lblExtended.Name = "lblExtended";
            this.lblExtended.Size = new System.Drawing.Size(260, 30);
            this.lblExtended.TabIndex = 3;
            this.lblExtended.Text = "Extended qualifications";
            // 
            // gridDetails
            // 
            this.gridDetails.AllowUserToAddRows = false;
            this.gridDetails.AllowUserToDeleteRows = false;
            this.gridDetails.AllowUserToResizeColumns = false;
            this.gridDetails.AllowUserToResizeRows = false;
            this.gridDetails.BackgroundColor = System.Drawing.Color.Black;
            this.gridDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridDetails.Location = new System.Drawing.Point(3, 34);
            this.gridDetails.MultiSelect = false;
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.ReadOnly = true;
            this.gridDetails.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.gridDetails.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridDetails.Size = new System.Drawing.Size(262, 85);
            this.gridDetails.TabIndex = 23;
            // 
            // gridContested
            // 
            this.gridContested.AllowUserToAddRows = false;
            this.gridContested.AllowUserToDeleteRows = false;
            this.gridContested.AllowUserToResizeColumns = false;
            this.gridContested.AllowUserToResizeRows = false;
            this.gridContested.BackgroundColor = System.Drawing.Color.Black;
            this.gridContested.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridContested.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridContested.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridContested.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridContested.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridContested.Location = new System.Drawing.Point(3, 125);
            this.gridContested.MultiSelect = false;
            this.gridContested.Name = "gridContested";
            this.gridContested.ReadOnly = true;
            this.gridContested.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.gridContested.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridContested.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridContested.Size = new System.Drawing.Size(262, 75);
            this.gridContested.TabIndex = 24;
            // 
            // ActionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.gridContested);
            this.Controls.Add(this.gridDetails);
            this.Controls.Add(this.lblExtended);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblName);
            this.ForeColor = System.Drawing.Color.Goldenrod;
            this.Name = "ActionDisplay";
            this.Size = new System.Drawing.Size(268, 268);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContested)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label lblExtended;
        private System.Windows.Forms.DataGridView gridDetails;
        private System.Windows.Forms.DataGridView gridContested;
    }
}
