namespace Pen_and_Paper_Visualator.Controls
{
    partial class GMControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnBash = new System.Windows.Forms.Button();
            this.btnLethal = new System.Windows.Forms.Button();
            this.btnAggravated = new System.Windows.Forms.Button();
            this.numBash = new System.Windows.Forms.NumericUpDown();
            this.numLethal = new System.Windows.Forms.NumericUpDown();
            this.numAggravated = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numHeal = new System.Windows.Forms.NumericUpDown();
            this.btnHeal = new System.Windows.Forms.Button();
            this.btnHealFull = new System.Windows.Forms.Button();
            this.btnRestoreWillFull = new System.Windows.Forms.Button();
            this.numRestoreWill = new System.Windows.Forms.NumericUpDown();
            this.btnRestoreWill = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbForm = new System.Windows.Forms.ComboBox();
            this.lblHumanity = new System.Windows.Forms.Label();
            this.lblVitae = new System.Windows.Forms.Label();
            this.numHumanitySubt = new System.Windows.Forms.NumericUpDown();
            this.btnHumanitySubt = new System.Windows.Forms.Button();
            this.numHumanityAdd = new System.Windows.Forms.NumericUpDown();
            this.btnHumanityAdd = new System.Windows.Forms.Button();
            this.numVitaeSubt = new System.Windows.Forms.NumericUpDown();
            this.btnVitaeSubt = new System.Windows.Forms.Button();
            this.numVitaeAdd = new System.Windows.Forms.NumericUpDown();
            this.btnVitaeAdd = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlWeapons = new System.Windows.Forms.FlowLayoutPanel();
            this.numSpendWill = new System.Windows.Forms.NumericUpDown();
            this.btnSpendWill = new System.Windows.Forms.Button();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLethal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAggravated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestoreWill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHumanitySubt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHumanityAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitaeSubt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitaeAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpendWill)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Damage";
            // 
            // btnBash
            // 
            this.btnBash.BackColor = System.Drawing.Color.Yellow;
            this.btnBash.Location = new System.Drawing.Point(0, 53);
            this.btnBash.Name = "btnBash";
            this.btnBash.Size = new System.Drawing.Size(83, 24);
            this.btnBash.TabIndex = 1;
            this.btnBash.Text = "Bash";
            this.btnBash.UseVisualStyleBackColor = false;
            this.btnBash.Click += new System.EventHandler(this.btnBash_Click);
            // 
            // btnLethal
            // 
            this.btnLethal.BackColor = System.Drawing.Color.Orange;
            this.btnLethal.Location = new System.Drawing.Point(0, 84);
            this.btnLethal.Name = "btnLethal";
            this.btnLethal.Size = new System.Drawing.Size(83, 24);
            this.btnLethal.TabIndex = 2;
            this.btnLethal.Text = "Lethal";
            this.btnLethal.UseVisualStyleBackColor = false;
            this.btnLethal.Click += new System.EventHandler(this.btnLethal_Click);
            // 
            // btnAggravated
            // 
            this.btnAggravated.BackColor = System.Drawing.Color.Red;
            this.btnAggravated.Location = new System.Drawing.Point(0, 114);
            this.btnAggravated.Name = "btnAggravated";
            this.btnAggravated.Size = new System.Drawing.Size(83, 24);
            this.btnAggravated.TabIndex = 3;
            this.btnAggravated.Text = "Aggravated";
            this.btnAggravated.UseVisualStyleBackColor = false;
            this.btnAggravated.Click += new System.EventHandler(this.btnAggravated_Click);
            // 
            // numBash
            // 
            this.numBash.Location = new System.Drawing.Point(86, 56);
            this.numBash.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numBash.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBash.Name = "numBash";
            this.numBash.Size = new System.Drawing.Size(36, 20);
            this.numBash.TabIndex = 4;
            this.numBash.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numLethal
            // 
            this.numLethal.Location = new System.Drawing.Point(86, 86);
            this.numLethal.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numLethal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLethal.Name = "numLethal";
            this.numLethal.Size = new System.Drawing.Size(36, 20);
            this.numLethal.TabIndex = 5;
            this.numLethal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numAggravated
            // 
            this.numAggravated.Location = new System.Drawing.Point(86, 116);
            this.numAggravated.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numAggravated.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAggravated.Name = "numAggravated";
            this.numAggravated.Size = new System.Drawing.Size(36, 20);
            this.numAggravated.TabIndex = 6;
            this.numAggravated.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(134, 53);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(105, 21);
            this.cmbStatus.TabIndex = 8;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Healing";
            // 
            // numHeal
            // 
            this.numHeal.Location = new System.Drawing.Point(85, 168);
            this.numHeal.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHeal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeal.Name = "numHeal";
            this.numHeal.Size = new System.Drawing.Size(36, 20);
            this.numHeal.TabIndex = 11;
            this.numHeal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnHeal
            // 
            this.btnHeal.BackColor = System.Drawing.Color.HotPink;
            this.btnHeal.Location = new System.Drawing.Point(-1, 166);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(83, 24);
            this.btnHeal.TabIndex = 10;
            this.btnHeal.Text = "Heal Point";
            this.btnHeal.UseVisualStyleBackColor = false;
            this.btnHeal.Click += new System.EventHandler(this.btnHeal_Click);
            // 
            // btnHealFull
            // 
            this.btnHealFull.BackColor = System.Drawing.Color.DeepPink;
            this.btnHealFull.Location = new System.Drawing.Point(-1, 193);
            this.btnHealFull.Name = "btnHealFull";
            this.btnHealFull.Size = new System.Drawing.Size(83, 24);
            this.btnHealFull.TabIndex = 12;
            this.btnHealFull.Text = "Heal Full";
            this.btnHealFull.UseVisualStyleBackColor = false;
            this.btnHealFull.Click += new System.EventHandler(this.btnHealFull_Click);
            // 
            // btnRestoreWillFull
            // 
            this.btnRestoreWillFull.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRestoreWillFull.Location = new System.Drawing.Point(123, 193);
            this.btnRestoreWillFull.Name = "btnRestoreWillFull";
            this.btnRestoreWillFull.Size = new System.Drawing.Size(83, 24);
            this.btnRestoreWillFull.TabIndex = 16;
            this.btnRestoreWillFull.Text = "Restore Full";
            this.btnRestoreWillFull.UseVisualStyleBackColor = false;
            this.btnRestoreWillFull.Click += new System.EventHandler(this.btnRestoreWillFull_Click);
            // 
            // numRestoreWill
            // 
            this.numRestoreWill.Location = new System.Drawing.Point(208, 168);
            this.numRestoreWill.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRestoreWill.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRestoreWill.Name = "numRestoreWill";
            this.numRestoreWill.Size = new System.Drawing.Size(36, 20);
            this.numRestoreWill.TabIndex = 15;
            this.numRestoreWill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRestoreWill
            // 
            this.btnRestoreWill.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRestoreWill.Location = new System.Drawing.Point(123, 166);
            this.btnRestoreWill.Name = "btnRestoreWill";
            this.btnRestoreWill.Size = new System.Drawing.Size(83, 24);
            this.btnRestoreWill.TabIndex = 14;
            this.btnRestoreWill.Text = "Restore Point";
            this.btnRestoreWill.UseVisualStyleBackColor = false;
            this.btnRestoreWill.Click += new System.EventHandler(this.btnRestoreWill_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Willpower";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(167, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Form";
            // 
            // cmbForm
            // 
            this.cmbForm.FormattingEnabled = true;
            this.cmbForm.Location = new System.Drawing.Point(134, 90);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.Size = new System.Drawing.Size(105, 21);
            this.cmbForm.TabIndex = 18;
            // 
            // lblHumanity
            // 
            this.lblHumanity.AutoSize = true;
            this.lblHumanity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumanity.Location = new System.Drawing.Point(29, 228);
            this.lblHumanity.Name = "lblHumanity";
            this.lblHumanity.Size = new System.Drawing.Size(59, 13);
            this.lblHumanity.TabIndex = 20;
            this.lblHumanity.Text = "Humanity";
            // 
            // lblVitae
            // 
            this.lblVitae.AutoSize = true;
            this.lblVitae.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVitae.Location = new System.Drawing.Point(52, 251);
            this.lblVitae.Name = "lblVitae";
            this.lblVitae.Size = new System.Drawing.Size(36, 13);
            this.lblVitae.TabIndex = 21;
            this.lblVitae.Text = "Vitae";
            // 
            // numHumanitySubt
            // 
            this.numHumanitySubt.Location = new System.Drawing.Point(209, 224);
            this.numHumanitySubt.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHumanitySubt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHumanitySubt.Name = "numHumanitySubt";
            this.numHumanitySubt.Size = new System.Drawing.Size(36, 20);
            this.numHumanitySubt.TabIndex = 29;
            this.numHumanitySubt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnHumanitySubt
            // 
            this.btnHumanitySubt.Location = new System.Drawing.Point(170, 222);
            this.btnHumanitySubt.Name = "btnHumanitySubt";
            this.btnHumanitySubt.Size = new System.Drawing.Size(37, 24);
            this.btnHumanitySubt.TabIndex = 28;
            this.btnHumanitySubt.Text = "Subt";
            this.btnHumanitySubt.UseVisualStyleBackColor = true;
            // 
            // numHumanityAdd
            // 
            this.numHumanityAdd.Location = new System.Drawing.Point(129, 224);
            this.numHumanityAdd.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHumanityAdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHumanityAdd.Name = "numHumanityAdd";
            this.numHumanityAdd.Size = new System.Drawing.Size(36, 20);
            this.numHumanityAdd.TabIndex = 27;
            this.numHumanityAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnHumanityAdd
            // 
            this.btnHumanityAdd.Location = new System.Drawing.Point(92, 222);
            this.btnHumanityAdd.Name = "btnHumanityAdd";
            this.btnHumanityAdd.Size = new System.Drawing.Size(34, 24);
            this.btnHumanityAdd.TabIndex = 26;
            this.btnHumanityAdd.Text = "Add";
            this.btnHumanityAdd.UseVisualStyleBackColor = true;
            // 
            // numVitaeSubt
            // 
            this.numVitaeSubt.Location = new System.Drawing.Point(209, 247);
            this.numVitaeSubt.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numVitaeSubt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVitaeSubt.Name = "numVitaeSubt";
            this.numVitaeSubt.Size = new System.Drawing.Size(36, 20);
            this.numVitaeSubt.TabIndex = 33;
            this.numVitaeSubt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnVitaeSubt
            // 
            this.btnVitaeSubt.Location = new System.Drawing.Point(170, 245);
            this.btnVitaeSubt.Name = "btnVitaeSubt";
            this.btnVitaeSubt.Size = new System.Drawing.Size(37, 24);
            this.btnVitaeSubt.TabIndex = 32;
            this.btnVitaeSubt.Text = "Subt";
            this.btnVitaeSubt.UseVisualStyleBackColor = true;
            // 
            // numVitaeAdd
            // 
            this.numVitaeAdd.Location = new System.Drawing.Point(129, 247);
            this.numVitaeAdd.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numVitaeAdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVitaeAdd.Name = "numVitaeAdd";
            this.numVitaeAdd.Size = new System.Drawing.Size(36, 20);
            this.numVitaeAdd.TabIndex = 31;
            this.numVitaeAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnVitaeAdd
            // 
            this.btnVitaeAdd.Location = new System.Drawing.Point(92, 245);
            this.btnVitaeAdd.Name = "btnVitaeAdd";
            this.btnVitaeAdd.Size = new System.Drawing.Size(34, 24);
            this.btnVitaeAdd.TabIndex = 30;
            this.btnVitaeAdd.Text = "Add";
            this.btnVitaeAdd.UseVisualStyleBackColor = true;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.LimeGreen;
            this.btnFinish.Location = new System.Drawing.Point(170, 5);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(69, 24);
            this.btnFinish.TabIndex = 34;
            this.btnFinish.Text = "Finish Turn";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Break";
            this.dataGridViewImageColumn1.Image = global::Pen_and_Paper_Visualator.Properties.Resources.Break;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Pen_and_Paper_Visualator.Properties.Resources.Break;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 25;
            // 
            // pnlWeapons
            // 
            this.pnlWeapons.Location = new System.Drawing.Point(1, 275);
            this.pnlWeapons.Name = "pnlWeapons";
            this.pnlWeapons.Size = new System.Drawing.Size(244, 226);
            this.pnlWeapons.TabIndex = 36;
            // 
            // numSpendWill
            // 
            this.numSpendWill.Location = new System.Drawing.Point(208, 141);
            this.numSpendWill.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numSpendWill.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpendWill.Name = "numSpendWill";
            this.numSpendWill.Size = new System.Drawing.Size(36, 20);
            this.numSpendWill.TabIndex = 38;
            this.numSpendWill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSpendWill
            // 
            this.btnSpendWill.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnSpendWill.Location = new System.Drawing.Point(123, 139);
            this.btnSpendWill.Name = "btnSpendWill";
            this.btnSpendWill.Size = new System.Drawing.Size(83, 24);
            this.btnSpendWill.TabIndex = 37;
            this.btnSpendWill.Text = "Spend Will";
            this.btnSpendWill.UseVisualStyleBackColor = false;
            this.btnSpendWill.Click += new System.EventHandler(this.btnSpendWill_Click);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.BackColor = System.Drawing.Color.White;
            this.btnAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvanced.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnAdvanced.Location = new System.Drawing.Point(1, 26);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(82, 24);
            this.btnAdvanced.TabIndex = 39;
            this.btnAdvanced.Text = "Advanced";
            this.btnAdvanced.UseVisualStyleBackColor = false;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Firebrick;
            this.btnRemove.Location = new System.Drawing.Point(89, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(76, 24);
            this.btnRemove.TabIndex = 40;
            this.btnRemove.Text = "Remove/Kill";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // GMControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.numSpendWill);
            this.Controls.Add(this.btnSpendWill);
            this.Controls.Add(this.pnlWeapons);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.numVitaeSubt);
            this.Controls.Add(this.btnVitaeSubt);
            this.Controls.Add(this.numVitaeAdd);
            this.Controls.Add(this.btnVitaeAdd);
            this.Controls.Add(this.numHumanitySubt);
            this.Controls.Add(this.btnHumanitySubt);
            this.Controls.Add(this.numHumanityAdd);
            this.Controls.Add(this.btnHumanityAdd);
            this.Controls.Add(this.lblVitae);
            this.Controls.Add(this.lblHumanity);
            this.Controls.Add(this.cmbForm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRestoreWillFull);
            this.Controls.Add(this.numRestoreWill);
            this.Controls.Add(this.btnRestoreWill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHealFull);
            this.Controls.Add(this.numHeal);
            this.Controls.Add(this.btnHeal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numAggravated);
            this.Controls.Add(this.numLethal);
            this.Controls.Add(this.numBash);
            this.Controls.Add(this.btnAggravated);
            this.Controls.Add(this.btnLethal);
            this.Controls.Add(this.btnBash);
            this.Controls.Add(this.label1);
            this.Name = "GMControl";
            this.Size = new System.Drawing.Size(246, 513);
            ((System.ComponentModel.ISupportInitialize)(this.numBash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLethal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAggravated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestoreWill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHumanitySubt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHumanityAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitaeSubt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitaeAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpendWill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBash;
        private System.Windows.Forms.Button btnLethal;
        private System.Windows.Forms.Button btnAggravated;
        private System.Windows.Forms.NumericUpDown numBash;
        private System.Windows.Forms.NumericUpDown numLethal;
        private System.Windows.Forms.NumericUpDown numAggravated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numHeal;
        private System.Windows.Forms.Button btnHeal;
        private System.Windows.Forms.Button btnHealFull;
        private System.Windows.Forms.Button btnRestoreWillFull;
        private System.Windows.Forms.NumericUpDown numRestoreWill;
        private System.Windows.Forms.Button btnRestoreWill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbForm;
        private System.Windows.Forms.Label lblHumanity;
        private System.Windows.Forms.Label lblVitae;
        private System.Windows.Forms.NumericUpDown numHumanitySubt;
        private System.Windows.Forms.Button btnHumanitySubt;
        private System.Windows.Forms.NumericUpDown numHumanityAdd;
        private System.Windows.Forms.Button btnHumanityAdd;
        private System.Windows.Forms.NumericUpDown numVitaeSubt;
        private System.Windows.Forms.Button btnVitaeSubt;
        private System.Windows.Forms.NumericUpDown numVitaeAdd;
        private System.Windows.Forms.Button btnVitaeAdd;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.FlowLayoutPanel pnlWeapons;
        private System.Windows.Forms.NumericUpDown numSpendWill;
        private System.Windows.Forms.Button btnSpendWill;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.Button btnRemove;
    }
}
