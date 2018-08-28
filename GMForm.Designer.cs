namespace Pen_and_Paper_Visualator
{
    partial class GMForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.riteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginCombatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCloseShopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributeXPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCommunication = new System.Windows.Forms.TabControl();
            this.tabPageAll = new System.Windows.Forms.TabPage();
            this.tabPageChatCombat = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCompendium = new System.Windows.Forms.TabPage();
            this.tabPageReference = new System.Windows.Forms.TabPage();
            this.tabPageNotifications = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.tabArea = new System.Windows.Forms.TabControl();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.tabPageCombat = new System.Windows.Forms.TabPage();
            this.tabPageLoot = new System.Windows.Forms.TabPage();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlSelected = new System.Windows.Forms.Panel();
            this.deleteACharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveCombatChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endowmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devotionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabCommunication.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.tabArea.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem,
            this.nPCToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.disciplineToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playerToolStripMenuItem.Text = "Player";
            this.playerToolStripMenuItem.Click += new System.EventHandler(this.playerToolStripMenuItem_Click);
            // 
            // nPCToolStripMenuItem
            // 
            this.nPCToolStripMenuItem.Name = "nPCToolStripMenuItem";
            this.nPCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nPCToolStripMenuItem.Text = "NPC";
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemToolStripMenuItem1,
            this.weaponToolStripMenuItem,
            this.armorToolStripMenuItem,
            this.vehicleToolStripMenuItem});
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.itemToolStripMenuItem.Text = "Equipment";
            this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
            // 
            // disciplineToolStripMenuItem
            // 
            this.disciplineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disciplineToolStripMenuItem1,
            this.devotionToolStripMenuItem,
            this.giftToolStripMenuItem,
            this.riteToolStripMenuItem,
            this.roteToolStripMenuItem,
            this.endowmentToolStripMenuItem});
            this.disciplineToolStripMenuItem.Name = "disciplineToolStripMenuItem";
            this.disciplineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disciplineToolStripMenuItem.Text = "Ability";
            // 
            // disciplineToolStripMenuItem1
            // 
            this.disciplineToolStripMenuItem1.Name = "disciplineToolStripMenuItem1";
            this.disciplineToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.disciplineToolStripMenuItem1.Text = "Discipline";
            // 
            // riteToolStripMenuItem
            // 
            this.riteToolStripMenuItem.Name = "riteToolStripMenuItem";
            this.riteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.riteToolStripMenuItem.Text = "Rite";
            // 
            // roteToolStripMenuItem
            // 
            this.roteToolStripMenuItem.Name = "roteToolStripMenuItem";
            this.roteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.roteToolStripMenuItem.Text = "Rote";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginCombatToolStripMenuItem,
            this.openCloseShopToolStripMenuItem,
            this.distributeXPToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // beginCombatToolStripMenuItem
            // 
            this.beginCombatToolStripMenuItem.Name = "beginCombatToolStripMenuItem";
            this.beginCombatToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.beginCombatToolStripMenuItem.Text = "Begin/End Combat";
            this.beginCombatToolStripMenuItem.Click += new System.EventHandler(this.beginCombatToolStripMenuItem_Click);
            // 
            // openCloseShopToolStripMenuItem
            // 
            this.openCloseShopToolStripMenuItem.Name = "openCloseShopToolStripMenuItem";
            this.openCloseShopToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openCloseShopToolStripMenuItem.Text = "Open/Close Shop";
            this.openCloseShopToolStripMenuItem.Click += new System.EventHandler(this.openCloseShopToolStripMenuItem_Click);
            // 
            // distributeXPToolStripMenuItem
            // 
            this.distributeXPToolStripMenuItem.Name = "distributeXPToolStripMenuItem";
            this.distributeXPToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.distributeXPToolStripMenuItem.Text = "Distribute XP";
            this.distributeXPToolStripMenuItem.Click += new System.EventHandler(this.distributeXPToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archiveChatToolStripMenuItem,
            this.archiveCombatChatToolStripMenuItem,
            this.deleteACharacterToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // archiveChatToolStripMenuItem
            // 
            this.archiveChatToolStripMenuItem.Name = "archiveChatToolStripMenuItem";
            this.archiveChatToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.archiveChatToolStripMenuItem.Text = "Archive Chat";
            this.archiveChatToolStripMenuItem.Click += new System.EventHandler(this.archiveChatToolStripMenuItem_Click);
            // 
            // tabCommunication
            // 
            this.tabCommunication.Controls.Add(this.tabPageAll);
            this.tabCommunication.Controls.Add(this.tabPageChatCombat);
            this.tabCommunication.Location = new System.Drawing.Point(276, 411);
            this.tabCommunication.Name = "tabCommunication";
            this.tabCommunication.SelectedIndex = 0;
            this.tabCommunication.Size = new System.Drawing.Size(457, 239);
            this.tabCommunication.TabIndex = 4;
            // 
            // tabPageAll
            // 
            this.tabPageAll.Location = new System.Drawing.Point(4, 22);
            this.tabPageAll.Name = "tabPageAll";
            this.tabPageAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAll.Size = new System.Drawing.Size(449, 213);
            this.tabPageAll.TabIndex = 1;
            this.tabPageAll.Text = "All";
            this.tabPageAll.UseVisualStyleBackColor = true;
            // 
            // tabPageChatCombat
            // 
            this.tabPageChatCombat.Location = new System.Drawing.Point(4, 22);
            this.tabPageChatCombat.Name = "tabPageChatCombat";
            this.tabPageChatCombat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChatCombat.Size = new System.Drawing.Size(449, 213);
            this.tabPageChatCombat.TabIndex = 0;
            this.tabPageChatCombat.Text = "Combat";
            this.tabPageChatCombat.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPageCompendium);
            this.tabControl1.Controls.Add(this.tabPageReference);
            this.tabControl1.Controls.Add(this.tabPageNotifications);
            this.tabControl1.Location = new System.Drawing.Point(739, 25);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(313, 660);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPageCompendium
            // 
            this.tabPageCompendium.Location = new System.Drawing.Point(4, 4);
            this.tabPageCompendium.Name = "tabPageCompendium";
            this.tabPageCompendium.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompendium.Size = new System.Drawing.Size(286, 652);
            this.tabPageCompendium.TabIndex = 1;
            this.tabPageCompendium.Text = "Compendium";
            this.tabPageCompendium.UseVisualStyleBackColor = true;
            // 
            // tabPageReference
            // 
            this.tabPageReference.Location = new System.Drawing.Point(4, 4);
            this.tabPageReference.Name = "tabPageReference";
            this.tabPageReference.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReference.Size = new System.Drawing.Size(286, 652);
            this.tabPageReference.TabIndex = 2;
            this.tabPageReference.Text = "Reference";
            this.tabPageReference.UseVisualStyleBackColor = true;
            // 
            // tabPageNotifications
            // 
            this.tabPageNotifications.Location = new System.Drawing.Point(4, 4);
            this.tabPageNotifications.Name = "tabPageNotifications";
            this.tabPageNotifications.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotifications.Size = new System.Drawing.Size(286, 652);
            this.tabPageNotifications.TabIndex = 3;
            this.tabPageNotifications.Text = "Notifications";
            this.tabPageNotifications.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(654, 656);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AllowDrop = true;
            this.txtMessage.Location = new System.Drawing.Point(276, 654);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(372, 25);
            this.txtMessage.TabIndex = 6;
            this.txtMessage.Enter += new System.EventHandler(this.txtMessage_Enter);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.SystemColors.Control;
            this.pnlForm.Controls.Add(this.tabArea);
            this.pnlForm.Controls.Add(this.tabControl1);
            this.pnlForm.Controls.Add(this.tabCommunication);
            this.pnlForm.Controls.Add(this.pnlDisplay);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1064, 685);
            this.pnlForm.TabIndex = 8;
            // 
            // tabArea
            // 
            this.tabArea.AllowDrop = true;
            this.tabArea.Controls.Add(this.tabPageMap);
            this.tabArea.Controls.Add(this.tabPageCombat);
            this.tabArea.Controls.Add(this.tabPageLoot);
            this.tabArea.Location = new System.Drawing.Point(6, 27);
            this.tabArea.Name = "tabArea";
            this.tabArea.SelectedIndex = 0;
            this.tabArea.Size = new System.Drawing.Size(731, 367);
            this.tabArea.TabIndex = 80;
            // 
            // tabPageMap
            // 
            this.tabPageMap.BackColor = System.Drawing.Color.Black;
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(723, 341);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "Map";
            // 
            // tabPageCombat
            // 
            this.tabPageCombat.Location = new System.Drawing.Point(4, 22);
            this.tabPageCombat.Name = "tabPageCombat";
            this.tabPageCombat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCombat.Size = new System.Drawing.Size(723, 341);
            this.tabPageCombat.TabIndex = 1;
            this.tabPageCombat.Text = "Combat";
            this.tabPageCombat.UseVisualStyleBackColor = true;
            // 
            // tabPageLoot
            // 
            this.tabPageLoot.Location = new System.Drawing.Point(4, 22);
            this.tabPageLoot.Name = "tabPageLoot";
            this.tabPageLoot.Size = new System.Drawing.Size(723, 341);
            this.tabPageLoot.TabIndex = 2;
            this.tabPageLoot.Text = "Loot";
            this.tabPageLoot.UseVisualStyleBackColor = true;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.pnlSelected);
            this.pnlDisplay.Controls.Add(this.btnSend);
            this.pnlDisplay.Controls.Add(this.txtMessage);
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(1064, 685);
            this.pnlDisplay.TabIndex = 81;
            // 
            // pnlSelected
            // 
            this.pnlSelected.AutoScroll = true;
            this.pnlSelected.Location = new System.Drawing.Point(6, 401);
            this.pnlSelected.Name = "pnlSelected";
            this.pnlSelected.Size = new System.Drawing.Size(264, 278);
            this.pnlSelected.TabIndex = 8;
            // 
            // deleteACharacterToolStripMenuItem
            // 
            this.deleteACharacterToolStripMenuItem.Name = "deleteACharacterToolStripMenuItem";
            this.deleteACharacterToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deleteACharacterToolStripMenuItem.Text = "Delete a Character";
            // 
            // archiveCombatChatToolStripMenuItem
            // 
            this.archiveCombatChatToolStripMenuItem.Name = "archiveCombatChatToolStripMenuItem";
            this.archiveCombatChatToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.archiveCombatChatToolStripMenuItem.Text = "Archive Combat Chat";
            this.archiveCombatChatToolStripMenuItem.Click += new System.EventHandler(this.archiveCombatChatToolStripMenuItem_Click);
            // 
            // endowmentToolStripMenuItem
            // 
            this.endowmentToolStripMenuItem.Name = "endowmentToolStripMenuItem";
            this.endowmentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.endowmentToolStripMenuItem.Text = "Endowment";
            // 
            // giftToolStripMenuItem
            // 
            this.giftToolStripMenuItem.Name = "giftToolStripMenuItem";
            this.giftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.giftToolStripMenuItem.Text = "Gift";
            // 
            // devotionToolStripMenuItem
            // 
            this.devotionToolStripMenuItem.Name = "devotionToolStripMenuItem";
            this.devotionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.devotionToolStripMenuItem.Text = "Devotion";
            // 
            // itemToolStripMenuItem1
            // 
            this.itemToolStripMenuItem1.Name = "itemToolStripMenuItem1";
            this.itemToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.itemToolStripMenuItem1.Text = "Item";
            // 
            // weaponToolStripMenuItem
            // 
            this.weaponToolStripMenuItem.Name = "weaponToolStripMenuItem";
            this.weaponToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.weaponToolStripMenuItem.Text = "Weapon";
            // 
            // armorToolStripMenuItem
            // 
            this.armorToolStripMenuItem.Name = "armorToolStripMenuItem";
            this.armorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.armorToolStripMenuItem.Text = "Armor";
            // 
            // vehicleToolStripMenuItem
            // 
            this.vehicleToolStripMenuItem.Name = "vehicleToolStripMenuItem";
            this.vehicleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vehicleToolStripMenuItem.Text = "Vehicle";
            // 
            // GMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 684);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlForm);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GMForm";
            this.Text = "GMForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GMForm_FormClosing);
            this.Load += new System.EventHandler(this.GMForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabCommunication.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.tabArea.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            this.pnlDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplineToolStripMenuItem;
        private System.Windows.Forms.TabControl tabCommunication;
        private System.Windows.Forms.TabPage tabPageChatCombat;
        private System.Windows.Forms.TabPage tabPageAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCompendium;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ToolStripMenuItem disciplineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem riteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beginCombatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distributeXPToolStripMenuItem;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TabControl tabArea;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.TabPage tabPageCombat;
        private System.Windows.Forms.TabPage tabPageLoot;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveChatToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSelected;
        private System.Windows.Forms.TabPage tabPageReference;
        private System.Windows.Forms.ToolStripMenuItem openCloseShopToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageNotifications;
        private System.Windows.Forms.ToolStripMenuItem deleteACharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveCombatChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem weaponToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devotionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endowmentToolStripMenuItem;
    }
}