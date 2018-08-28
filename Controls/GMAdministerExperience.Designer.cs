namespace Pen_and_Paper_Visualator.Controls
{
    partial class GMAdministerExperience
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
            this.pnlCharacters = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDistribute = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlCharacters
            // 
            this.pnlCharacters.Location = new System.Drawing.Point(5, 6);
            this.pnlCharacters.Name = "pnlCharacters";
            this.pnlCharacters.Size = new System.Drawing.Size(284, 419);
            this.pnlCharacters.TabIndex = 0;
            // 
            // btnDistribute
            // 
            this.btnDistribute.Location = new System.Drawing.Point(117, 431);
            this.btnDistribute.Name = "btnDistribute";
            this.btnDistribute.Size = new System.Drawing.Size(83, 33);
            this.btnDistribute.TabIndex = 1;
            this.btnDistribute.Text = "Distribute";
            this.btnDistribute.UseVisualStyleBackColor = true;
            this.btnDistribute.Click += new System.EventHandler(this.btnDistribute_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(206, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GMAdministerExperience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDistribute);
            this.Controls.Add(this.pnlCharacters);
            this.Name = "GMAdministerExperience";
            this.Size = new System.Drawing.Size(293, 481);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlCharacters;
        private System.Windows.Forms.Button btnDistribute;
        private System.Windows.Forms.Button btnCancel;
    }
}
