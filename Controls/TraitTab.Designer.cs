namespace Pen_and_Paper_Visualator.Controls
{
    partial class TraitTab
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
            this.lbxMerit = new System.Windows.Forms.ListBox();
            this.lbxFlaw = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblDefense = new System.Windows.Forms.Label();
            this.lblInitiative = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblArmor = new System.Windows.Forms.Label();
            this.lblMeritFlaw = new System.Windows.Forms.Label();
            this.lblDerangements = new System.Windows.Forms.Label();
            this.lbxDerangements = new System.Windows.Forms.ListBox();
            this.pnlRenown = new System.Windows.Forms.Panel();
            this.lblRenown = new System.Windows.Forms.Label();
            this.lblRenownPurity = new System.Windows.Forms.Label();
            this.rdoCunning = new Pen_and_Paper_Visualator.Controls.rdoAbilityRank();
            this.lblRenownGlory = new System.Windows.Forms.Label();
            this.rdoWisdom = new Pen_and_Paper_Visualator.Controls.rdoAbilityRank();
            this.lblRenownHonor = new System.Windows.Forms.Label();
            this.rdoHonor = new Pen_and_Paper_Visualator.Controls.rdoAbilityRank();
            this.lblRenownWisdom = new System.Windows.Forms.Label();
            this.rdoGlory = new Pen_and_Paper_Visualator.Controls.rdoAbilityRank();
            this.lblRenownCunning = new System.Windows.Forms.Label();
            this.rdoPurity = new Pen_and_Paper_Visualator.Controls.rdoAbilityRank();
            this.txtMeritFlawDesc = new System.Windows.Forms.RichTextBox();
            this.pnlRenown.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxMerit
            // 
            this.lbxMerit.FormattingEnabled = true;
            this.lbxMerit.Location = new System.Drawing.Point(62, 145);
            this.lbxMerit.Name = "lbxMerit";
            this.lbxMerit.ScrollAlwaysVisible = true;
            this.lbxMerit.Size = new System.Drawing.Size(161, 69);
            this.lbxMerit.TabIndex = 0;
            this.lbxMerit.SelectedIndexChanged += new System.EventHandler(this.lbxMerit_SelectedIndexChanged);
            // 
            // lbxFlaw
            // 
            this.lbxFlaw.FormattingEnabled = true;
            this.lbxFlaw.Location = new System.Drawing.Point(62, 242);
            this.lbxFlaw.Name = "lbxFlaw";
            this.lbxFlaw.ScrollAlwaysVisible = true;
            this.lbxFlaw.Size = new System.Drawing.Size(161, 43);
            this.lbxFlaw.TabIndex = 1;
            this.lbxFlaw.SelectedIndexChanged += new System.EventHandler(this.lbxFlaw_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Merits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Flaws";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Defense";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Initiative Mod";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Speed";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Armor";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(161, 11);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(25, 13);
            this.lblSize.TabIndex = 9;
            this.lblSize.Text = "size";
            // 
            // lblDefense
            // 
            this.lblDefense.AutoSize = true;
            this.lblDefense.Location = new System.Drawing.Point(161, 33);
            this.lblDefense.Name = "lblDefense";
            this.lblDefense.Size = new System.Drawing.Size(45, 13);
            this.lblDefense.TabIndex = 10;
            this.lblDefense.Text = "defense";
            // 
            // lblInitiative
            // 
            this.lblInitiative.AutoSize = true;
            this.lblInitiative.Location = new System.Drawing.Point(161, 58);
            this.lblInitiative.Name = "lblInitiative";
            this.lblInitiative.Size = new System.Drawing.Size(20, 13);
            this.lblInitiative.TabIndex = 11;
            this.lblInitiative.Text = "init";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(161, 80);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(36, 13);
            this.lblSpeed.TabIndex = 12;
            this.lblSpeed.Text = "speed";
            // 
            // lblArmor
            // 
            this.lblArmor.AutoSize = true;
            this.lblArmor.Location = new System.Drawing.Point(161, 104);
            this.lblArmor.Name = "lblArmor";
            this.lblArmor.Size = new System.Drawing.Size(33, 13);
            this.lblArmor.TabIndex = 13;
            this.lblArmor.Text = "armor";
            // 
            // lblMeritFlaw
            // 
            this.lblMeritFlaw.AutoSize = true;
            this.lblMeritFlaw.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeritFlaw.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMeritFlaw.Location = new System.Drawing.Point(17, 503);
            this.lblMeritFlaw.Name = "lblMeritFlaw";
            this.lblMeritFlaw.Size = new System.Drawing.Size(106, 17);
            this.lblMeritFlaw.TabIndex = 30;
            this.lblMeritFlaw.Text = "ActiveMeritFlaw";
            // 
            // lblDerangements
            // 
            this.lblDerangements.AutoSize = true;
            this.lblDerangements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDerangements.Location = new System.Drawing.Point(96, 299);
            this.lblDerangements.Name = "lblDerangements";
            this.lblDerangements.Size = new System.Drawing.Size(88, 13);
            this.lblDerangements.TabIndex = 33;
            this.lblDerangements.Text = "Derangements";
            // 
            // lbxDerangements
            // 
            this.lbxDerangements.FormattingEnabled = true;
            this.lbxDerangements.Location = new System.Drawing.Point(64, 315);
            this.lbxDerangements.Name = "lbxDerangements";
            this.lbxDerangements.ScrollAlwaysVisible = true;
            this.lbxDerangements.Size = new System.Drawing.Size(161, 43);
            this.lbxDerangements.TabIndex = 32;
            // 
            // pnlRenown
            // 
            this.pnlRenown.Controls.Add(this.lblRenown);
            this.pnlRenown.Controls.Add(this.lblRenownPurity);
            this.pnlRenown.Controls.Add(this.rdoCunning);
            this.pnlRenown.Controls.Add(this.lblRenownGlory);
            this.pnlRenown.Controls.Add(this.rdoWisdom);
            this.pnlRenown.Controls.Add(this.lblRenownHonor);
            this.pnlRenown.Controls.Add(this.rdoHonor);
            this.pnlRenown.Controls.Add(this.lblRenownWisdom);
            this.pnlRenown.Controls.Add(this.rdoGlory);
            this.pnlRenown.Controls.Add(this.lblRenownCunning);
            this.pnlRenown.Controls.Add(this.rdoPurity);
            this.pnlRenown.Location = new System.Drawing.Point(47, 364);
            this.pnlRenown.Name = "pnlRenown";
            this.pnlRenown.Size = new System.Drawing.Size(187, 130);
            this.pnlRenown.TabIndex = 131;
            this.pnlRenown.Visible = false;
            // 
            // lblRenown
            // 
            this.lblRenown.AutoSize = true;
            this.lblRenown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblRenown.Location = new System.Drawing.Point(66, 10);
            this.lblRenown.Name = "lblRenown";
            this.lblRenown.Size = new System.Drawing.Size(59, 15);
            this.lblRenown.TabIndex = 129;
            this.lblRenown.Text = "Renown";
            // 
            // lblRenownPurity
            // 
            this.lblRenownPurity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRenownPurity.AutoSize = true;
            this.lblRenownPurity.Location = new System.Drawing.Point(17, 29);
            this.lblRenownPurity.Name = "lblRenownPurity";
            this.lblRenownPurity.Size = new System.Drawing.Size(33, 13);
            this.lblRenownPurity.TabIndex = 119;
            this.lblRenownPurity.Text = "Purity";
            // 
            // rdoCunning
            // 
            this.rdoCunning.AbilityRank = 0;
            this.rdoCunning.Location = new System.Drawing.Point(68, 101);
            this.rdoCunning.Name = "rdoCunning";
            this.rdoCunning.RadioCount = 5;
            this.rdoCunning.ReadOnly = true;
            this.rdoCunning.Size = new System.Drawing.Size(100, 23);
            this.rdoCunning.TabIndex = 128;
            // 
            // lblRenownGlory
            // 
            this.lblRenownGlory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRenownGlory.AutoSize = true;
            this.lblRenownGlory.Location = new System.Drawing.Point(17, 48);
            this.lblRenownGlory.Name = "lblRenownGlory";
            this.lblRenownGlory.Size = new System.Drawing.Size(31, 13);
            this.lblRenownGlory.TabIndex = 120;
            this.lblRenownGlory.Text = "Glory";
            // 
            // rdoWisdom
            // 
            this.rdoWisdom.AbilityRank = 0;
            this.rdoWisdom.Location = new System.Drawing.Point(68, 82);
            this.rdoWisdom.Name = "rdoWisdom";
            this.rdoWisdom.RadioCount = 5;
            this.rdoWisdom.ReadOnly = true;
            this.rdoWisdom.Size = new System.Drawing.Size(100, 23);
            this.rdoWisdom.TabIndex = 127;
            // 
            // lblRenownHonor
            // 
            this.lblRenownHonor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRenownHonor.AutoSize = true;
            this.lblRenownHonor.Location = new System.Drawing.Point(17, 67);
            this.lblRenownHonor.Name = "lblRenownHonor";
            this.lblRenownHonor.Size = new System.Drawing.Size(36, 13);
            this.lblRenownHonor.TabIndex = 121;
            this.lblRenownHonor.Text = "Honor";
            // 
            // rdoHonor
            // 
            this.rdoHonor.AbilityRank = 0;
            this.rdoHonor.Location = new System.Drawing.Point(68, 63);
            this.rdoHonor.Name = "rdoHonor";
            this.rdoHonor.RadioCount = 5;
            this.rdoHonor.ReadOnly = true;
            this.rdoHonor.Size = new System.Drawing.Size(100, 23);
            this.rdoHonor.TabIndex = 126;
            // 
            // lblRenownWisdom
            // 
            this.lblRenownWisdom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRenownWisdom.AutoSize = true;
            this.lblRenownWisdom.Location = new System.Drawing.Point(17, 86);
            this.lblRenownWisdom.Name = "lblRenownWisdom";
            this.lblRenownWisdom.Size = new System.Drawing.Size(45, 13);
            this.lblRenownWisdom.TabIndex = 122;
            this.lblRenownWisdom.Text = "Wisdom";
            // 
            // rdoGlory
            // 
            this.rdoGlory.AbilityRank = 0;
            this.rdoGlory.Location = new System.Drawing.Point(68, 44);
            this.rdoGlory.Name = "rdoGlory";
            this.rdoGlory.RadioCount = 5;
            this.rdoGlory.ReadOnly = true;
            this.rdoGlory.Size = new System.Drawing.Size(100, 23);
            this.rdoGlory.TabIndex = 125;
            // 
            // lblRenownCunning
            // 
            this.lblRenownCunning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRenownCunning.AutoSize = true;
            this.lblRenownCunning.Location = new System.Drawing.Point(17, 105);
            this.lblRenownCunning.Name = "lblRenownCunning";
            this.lblRenownCunning.Size = new System.Drawing.Size(46, 13);
            this.lblRenownCunning.TabIndex = 123;
            this.lblRenownCunning.Text = "Cunning";
            // 
            // rdoPurity
            // 
            this.rdoPurity.AbilityRank = 0;
            this.rdoPurity.Location = new System.Drawing.Point(68, 25);
            this.rdoPurity.Name = "rdoPurity";
            this.rdoPurity.RadioCount = 5;
            this.rdoPurity.ReadOnly = true;
            this.rdoPurity.Size = new System.Drawing.Size(100, 23);
            this.rdoPurity.TabIndex = 124;
            // 
            // txtMeritFlawDesc
            // 
            this.txtMeritFlawDesc.Location = new System.Drawing.Point(5, 521);
            this.txtMeritFlawDesc.Name = "txtMeritFlawDesc";
            this.txtMeritFlawDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtMeritFlawDesc.Size = new System.Drawing.Size(271, 121);
            this.txtMeritFlawDesc.TabIndex = 132;
            this.txtMeritFlawDesc.Text = "";
            // 
            // TraitTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.txtMeritFlawDesc);
            this.Controls.Add(this.pnlRenown);
            this.Controls.Add(this.lblDerangements);
            this.Controls.Add(this.lbxDerangements);
            this.Controls.Add(this.lblMeritFlaw);
            this.Controls.Add(this.lblArmor);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblInitiative);
            this.Controls.Add(this.lblDefense);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxFlaw);
            this.Controls.Add(this.lbxMerit);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TraitTab";
            this.Size = new System.Drawing.Size(286, 652);
            this.Load += new System.EventHandler(this.TraitTab_Load);
            this.pnlRenown.ResumeLayout(false);
            this.pnlRenown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMerit;
        private System.Windows.Forms.ListBox lbxFlaw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblDefense;
        private System.Windows.Forms.Label lblInitiative;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblArmor;
        private System.Windows.Forms.Label lblMeritFlaw;
        private System.Windows.Forms.Label lblDerangements;
        private System.Windows.Forms.ListBox lbxDerangements;
        private System.Windows.Forms.Panel pnlRenown;
        private System.Windows.Forms.Label lblRenown;
        private System.Windows.Forms.Label lblRenownPurity;
        private rdoAbilityRank rdoCunning;
        private System.Windows.Forms.Label lblRenownGlory;
        private rdoAbilityRank rdoWisdom;
        private System.Windows.Forms.Label lblRenownHonor;
        private rdoAbilityRank rdoHonor;
        private System.Windows.Forms.Label lblRenownWisdom;
        private rdoAbilityRank rdoGlory;
        private System.Windows.Forms.Label lblRenownCunning;
        private rdoAbilityRank rdoPurity;
        private System.Windows.Forms.RichTextBox txtMeritFlawDesc;
    }
}
