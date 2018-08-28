namespace Pen_and_Paper_Visualator.Controls
{
    partial class CompendiumTab
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Cash");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Armor");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Item");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("NPC");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Weapon");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Vehicle");
            this.treeCompendium = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeCompendium
            // 
            this.treeCompendium.Location = new System.Drawing.Point(3, 3);
            this.treeCompendium.Name = "treeCompendium";
            treeNode1.Name = "nodeCash";
            treeNode1.Text = "Cash";
            treeNode2.Name = "nodeArmor";
            treeNode2.Text = "Armor";
            treeNode3.Name = "nodeItems";
            treeNode3.Text = "Item";
            treeNode4.Name = "nodeNPC";
            treeNode4.Text = "NPC";
            treeNode5.Name = "nodeWeapon";
            treeNode5.Text = "Weapon";
            treeNode6.Name = "nodeVehicle";
            treeNode6.Text = "Vehicle";
            this.treeCompendium.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeCompendium.Size = new System.Drawing.Size(270, 622);
            this.treeCompendium.TabIndex = 0;
            this.treeCompendium.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeCompendium_ItemDrag);
            this.treeCompendium.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCompendium_AfterSelect);
            this.treeCompendium.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeCompendium_MouseDoubleClick);
            // 
            // CompendiumTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeCompendium);
            this.Name = "CompendiumTab";
            this.Size = new System.Drawing.Size(289, 628);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeCompendium;


    }
}
