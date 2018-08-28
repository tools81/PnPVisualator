using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class EquipmentTab : UserControl
    {
        XPathDocument lvItemXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Item.xml");
        XPathDocument lvCharXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Characters/" + Player.Name + ".xml");
        
        public EquipmentTab()
        {
            InitializeComponent();            

            lblMoney.Text = Player.Cash.ToString();

            XPathNavigator nav = lvItemXml.CreateNavigator();
            XPathNavigator equipmentNav = lvCharXml.CreateNavigator().SelectSingleNode("Character/Equipment");

            foreach (string  lvEquipment in Player.Equipment)
            {
                if (!String.IsNullOrEmpty(lvEquipment))
                {
                    string lvName = equipmentNav.SelectSingleNode("Items/Item[@ID = '" + lvEquipment + "']/@Name").Value;

                    Panel pnl = new Panel();
                    pnl.Height = 25;
                    pnl.Width = 156;
                    IconLabel lvIconLabel = new IconLabel();
                    lvIconLabel.Display = lvName;
                    lvIconLabel.Image = nav.SelectSingleNode("Items/Item[@Name = '" + lvName + "']/Image").Value;
                    lvIconLabel.DisplayType = IconLabel.Type.Item;

                    Button btn = new Button();
                    btn.Name = lvEquipment;
                    btn.Height = 24;
                    btn.Width = 24;
                    btn.Left = 130;

                    if (equipmentNav.SelectSingleNode("Items/Item[@ID = '" + lvEquipment + "']/@Equipped").ValueAsBoolean)
                    {
                        btn.Image = Properties.Resources.pack_color;
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.Image = Properties.Resources.pack;
                        btn.BackColor = Color.White;
                    }
                                        
                    pnl.Controls.Add(lvIconLabel);
                    pnl.Controls.Add(btn);
                    pnlItems.Controls.Add(pnl);

                    btn.MouseClick += EquipButton_Clicked;
                    lvIconLabel.MouseClick += IconLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)  
                    {
                        c.MouseClick += (sender, e) => { DescribeItem(lvName); };  
                    }
                }
            }

            foreach (string lvWeapon in Player.Weapon)
            {
                if (!String.IsNullOrEmpty(lvWeapon))
                {
                    string lvName = equipmentNav.SelectSingleNode("Weapons/Weapon[@ID = '" + lvWeapon + "']/@Name").Value;

                    Panel pnl = new Panel();
                    pnl.Height = 25;
                    pnl.Width = 156;
                    IconLabel lvIconLabel = new IconLabel();
                    lvIconLabel.Display = lvName;
                    lvIconLabel.Image = nav.SelectSingleNode("Items/Item[@Name = '" + lvName + "']/Image").Value;

                    Button btn = new Button();
                    btn.Name = lvWeapon;
                    btn.Height = 24;
                    btn.Width = 24;
                    btn.Left = 130;

                    if (equipmentNav.SelectSingleNode("Weapons/Weapon[@ID = '" + lvWeapon + "']/@Equipped").ValueAsBoolean)
                    {
                        btn.Image = Properties.Resources.pack_color;
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.Image = Properties.Resources.pack;
                        btn.BackColor = Color.White;
                    }

                    pnl.Controls.Add(lvIconLabel);
                    pnl.Controls.Add(btn);
                    pnlWeapons.Controls.Add(pnl);

                    btn.MouseClick += EquipButton_Clicked;
                    lvIconLabel.MouseClick += IconLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)
                    {
                        c.MouseClick += (sender, e) => { DescribeItem(lvName); };
                    }
                }
            }

            foreach (string lvArmor in Player.Armor)
            {
                if (!String.IsNullOrEmpty(lvArmor))
                {
                    string lvName = equipmentNav.SelectSingleNode("Armors/Armor[@ID = '" + lvArmor + "']/@Name").Value;

                    Panel pnl = new Panel();
                    pnl.Height = 25;
                    pnl.Width = 156;
                    IconLabel lvIconLabel = new IconLabel();
                    lvIconLabel.Display = lvName;
                    lvIconLabel.Image = nav.SelectSingleNode("Items/Item[@Name = '" + lvName + "']/Image").Value;

                    Button btn = new Button();
                    btn.Name = lvArmor;
                    btn.Height = 24;
                    btn.Width = 24;
                    btn.Left = 130;

                    if (equipmentNav.SelectSingleNode("Armors/Armor[@ID = '" + lvArmor + "']/@Equipped").ValueAsBoolean)
                    {
                        btn.Image = Properties.Resources.pack_color;
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.Image = Properties.Resources.pack;
                        btn.BackColor = Color.White;
                    }

                    pnl.Controls.Add(lvIconLabel);
                    pnl.Controls.Add(btn);
                    pnlArmor.Controls.Add(pnl);

                    btn.MouseClick += EquipButton_Clicked;
                    lvIconLabel.MouseClick += IconLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)
                    {
                        c.MouseClick += (sender, e) => { DescribeItem(lvName); };
                    }
                }
            }
        }

        private void EquipButton_Clicked(object sender, MouseEventArgs e)
        {
            Boolean lvEquip = ((Button) sender).BackColor == Color.White;
            string lvName = ((Button) sender).Name;

            if (lvEquip)
            {
                ((Button)sender).Image = Properties.Resources.pack_color;
                ((Button)sender).BackColor = Color.Green;
            }
            else
            {
                ((Button)sender).Image = Properties.Resources.pack;
                ((Button)sender).BackColor = Color.White;
            }

            CharacterUpdate.EquipUnequipItem(lvName, lvEquip);
            Global.PlaySound(Global.Sound_Equip, false);
        }       

        private void IconLabel_Clicked(object sender, MouseEventArgs e)
        {
            DescribeItem(((IconLabel)sender).Display);
        }

        private void EquipmentTab_Load(object sender, EventArgs e)
        {
            
        }

        private void DescribeItem(string pvLabel)
        {
            XPathNavigator nav = lvItemXml.CreateNavigator();
            XPathNavigator itemNav = nav.SelectSingleNode("Items/Item[@Name = '" + pvLabel + "']");

            switch (itemNav.SelectSingleNode("@Type").Value)
            {
                case "Item":
                    ItemDisplay.ItemName = pvLabel;
                    ItemDisplay.Image = itemNav.SelectSingleNode("Image").Value;
                    ItemDisplay.Cost = itemNav.SelectSingleNode("Cost").ValueAsInt;
                    ItemDisplay.ItemSize = itemNav.SelectSingleNode("Size").ValueAsInt;
                    ItemDisplay.Durability = itemNav.SelectSingleNode("Durability").ValueAsInt;
                    ItemDisplay.Structure = itemNav.SelectSingleNode("Structure").ValueAsInt;
                    ItemDisplay.Description = itemNav.SelectSingleNode("Description").Value;
                    ItemDisplay.Scope = null;
                    ItemDisplay.Damage_Prim = null;
                    ItemDisplay.Damage_Sec = null;
                    ItemDisplay.Capacity = null;
                    ItemDisplay.Def_General = 0;
                    ItemDisplay.Def_Ballistic = 0;
                    ItemDisplay.Range = null;
                    break;
                case "Weapon":
                    ItemDisplay.ItemName = pvLabel;
                    ItemDisplay.Scope = itemNav.SelectSingleNode("Scope").Value;
                    ItemDisplay.Image = itemNav.SelectSingleNode("Image").Value;
                    ItemDisplay.Cost = itemNav.SelectSingleNode("Cost").ValueAsInt;
                    ItemDisplay.ItemSize = itemNav.SelectSingleNode("Size").ValueAsInt;
                    ItemDisplay.Damage_Prim = itemNav.SelectSingleNode("Primary/Damage").Value + "(" + itemNav.SelectSingleNode("Primary/Threat").Value + ")";

                    XPathNavigator secNav = itemNav.SelectSingleNode("Secondary/Damage");
                    if (secNav != null)
                        ItemDisplay.Damage_Sec = itemNav.SelectSingleNode("Secondary/Damage").Value + "(" + itemNav.SelectSingleNode("Secondary/Threat").Value + ")";
                    else
                        ItemDisplay.Damage_Sec = null;

                    XPathNavigator capNav = itemNav.SelectSingleNode("Capacity");
                    if (capNav != null)
                    {
                        ItemDisplay.Capacity = capNav.SelectSingleNode("Current").Value + @"/" +
                                               capNav.SelectSingleNode("Max").Value;
                    }
                    else
                        ItemDisplay.Capacity = null;

                    XPathNavigator mediumNav = itemNav.SelectSingleNode("Range/Medium");
                    XPathNavigator longNav = itemNav.SelectSingleNode("Range/Long");

                    ItemDisplay.Range = itemNav.SelectSingleNode("Range/Short").Value;
                    if (mediumNav != null)
                        ItemDisplay.Range += @"/" + mediumNav.Value;
                    if (longNav != null)
                        ItemDisplay.Range += @"/" + longNav.Value;

                    ItemDisplay.Durability = 0;
                    ItemDisplay.Structure = 0;
                    ItemDisplay.Def_General = 0;
                    ItemDisplay.Def_Ballistic = 0;
                    ItemDisplay.Description = itemNav.SelectSingleNode("Description").Value;                    
                    break;
                case "Armor":
                    ItemDisplay.ItemName = pvLabel;
                    ItemDisplay.Image = itemNav.SelectSingleNode("Image").Value;
                    ItemDisplay.Cost = itemNav.SelectSingleNode("Cost").ValueAsInt;
                    ItemDisplay.Def_General = itemNav.SelectSingleNode("General").ValueAsInt;
                    ItemDisplay.Def_Ballistic = itemNav.SelectSingleNode("Ballistic").ValueAsInt;
                    ItemDisplay.Description = itemNav.SelectSingleNode("Description").Value;
                    ItemDisplay.Durability = 0;
                    ItemDisplay.Structure = 0;
                    ItemDisplay.Scope = null;
                    ItemDisplay.Damage_Prim = null;
                    ItemDisplay.Damage_Sec = null;
                    ItemDisplay.Capacity = null;
                    ItemDisplay.Range = null;
                    break;
            }           

            ItemDisplay iDisplay = new ItemDisplay();
            pnlItemDisplay.Controls.Clear();
            pnlItemDisplay.Controls.Add(iDisplay);
        }

        private void lblKeys_Click(object sender, EventArgs e)
        {
            ItemDisplay.ItemName = "Key Ring";
            ItemDisplay.Image = "Keys_Image.jpg";
            ItemDisplay.Description = "List of keys attained here.";

            ItemDisplay iDisplay = new ItemDisplay();
            pnlItemDisplay.Controls.Clear();
            pnlItemDisplay.Controls.Add(iDisplay);

            Global.PlaySound(Global.Sound_Keys, false);
        }
    }
}
