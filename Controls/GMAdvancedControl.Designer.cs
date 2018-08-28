namespace Pen_and_Paper_Visualator.Controls
{
    partial class AdvancedGMControl
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
            this.lstActors = new System.Windows.Forms.ListBox();
            this.lstWeapons = new System.Windows.Forms.ListBox();
            this.lstAbilities = new System.Windows.Forms.ListBox();
            this.numDamage = new System.Windows.Forms.NumericUpDown();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEffectedActor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlDamageType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkSuccess = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDamage)).BeginInit();
            this.SuspendLayout();
            // 
            // lstActors
            // 
            this.lstActors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstActors.FormattingEnabled = true;
            this.lstActors.ItemHeight = 16;
            this.lstActors.Location = new System.Drawing.Point(25, 31);
            this.lstActors.Name = "lstActors";
            this.lstActors.Size = new System.Drawing.Size(170, 132);
            this.lstActors.TabIndex = 0;
            this.lstActors.SelectedIndexChanged += new System.EventHandler(this.lstActors_SelectedIndexChanged);
            // 
            // lstWeapons
            // 
            this.lstWeapons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWeapons.FormattingEnabled = true;
            this.lstWeapons.ItemHeight = 16;
            this.lstWeapons.Location = new System.Drawing.Point(217, 31);
            this.lstWeapons.Name = "lstWeapons";
            this.lstWeapons.Size = new System.Drawing.Size(178, 132);
            this.lstWeapons.TabIndex = 1;
            this.lstWeapons.SelectedIndexChanged += new System.EventHandler(this.lstWeapons_SelectedIndexChanged);
            // 
            // lstAbilities
            // 
            this.lstAbilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAbilities.FormattingEnabled = true;
            this.lstAbilities.ItemHeight = 16;
            this.lstAbilities.Location = new System.Drawing.Point(419, 31);
            this.lstAbilities.Name = "lstAbilities";
            this.lstAbilities.Size = new System.Drawing.Size(170, 132);
            this.lstAbilities.TabIndex = 2;
            this.lstAbilities.SelectedIndexChanged += new System.EventHandler(this.lstAbilities_SelectedIndexChanged);
            // 
            // numDamage
            // 
            this.numDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDamage.Location = new System.Drawing.Point(244, 186);
            this.numDamage.Name = "numDamage";
            this.numDamage.Size = new System.Drawing.Size(48, 23);
            this.numDamage.TabIndex = 3;
            this.numDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Turquoise;
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(419, 170);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 39);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(514, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Damage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Effected Actor:";
            // 
            // lblEffectedActor
            // 
            this.lblEffectedActor.AutoSize = true;
            this.lblEffectedActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEffectedActor.Location = new System.Drawing.Point(94, 187);
            this.lblEffectedActor.Name = "lblEffectedActor";
            this.lblEffectedActor.Size = new System.Drawing.Size(37, 13);
            this.lblEffectedActor.TabIndex = 8;
            this.lblEffectedActor.Text = "Actor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Attacked By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "With Weapon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "With Ability";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Type";
            // 
            // ddlDamageType
            // 
            this.ddlDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDamageType.FormattingEnabled = true;
            this.ddlDamageType.Items.AddRange(new object[] {
            "Bash",
            "Lethal",
            "Aggravated"});
            this.ddlDamageType.Location = new System.Drawing.Point(307, 187);
            this.ddlDamageType.Name = "ddlDamageType";
            this.ddlDamageType.Size = new System.Drawing.Size(99, 21);
            this.ddlDamageType.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Success";
            // 
            // chkSuccess
            // 
            this.chkSuccess.AutoSize = true;
            this.chkSuccess.Checked = true;
            this.chkSuccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuccess.Location = new System.Drawing.Point(199, 190);
            this.chkSuccess.Name = "chkSuccess";
            this.chkSuccess.Size = new System.Drawing.Size(15, 14);
            this.chkSuccess.TabIndex = 15;
            this.chkSuccess.UseVisualStyleBackColor = true;
            // 
            // AdvancedGMControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.chkSuccess);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ddlDamageType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEffectedActor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.numDamage);
            this.Controls.Add(this.lstAbilities);
            this.Controls.Add(this.lstWeapons);
            this.Controls.Add(this.lstActors);
            this.Name = "AdvancedGMControl";
            this.Size = new System.Drawing.Size(614, 215);
            ((System.ComponentModel.ISupportInitialize)(this.numDamage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numDamage;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEffectedActor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ListBox lstActors;
        public System.Windows.Forms.ListBox lstWeapons;
        public System.Windows.Forms.ListBox lstAbilities;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlDamageType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkSuccess;
    }
}
