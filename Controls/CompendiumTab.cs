using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.Xml.XPath;
using System.Configuration;
using System.IO;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class CompendiumTab : UserControl
    {
        private XPathDocument cvItemXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Item.xml");
        private XPathDocument cvVehicleXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Vehicle.xml");
        private string cvNpcFolder = Properties.Settings.Default.DataLocation + @"NPC";

        public CompendiumTab()
        {
            InitializeComponent();

            PopulateNodes();
        }

        private void PopulateNodes()
        {
            XPathNavigator nav = cvItemXml.CreateNavigator();
            XPathExpression exp = nav.Compile("Items/Item[@Type='Item']");
            exp.AddSort("@Name", XmlSortOrder.Ascending, XmlCaseOrder.UpperFirst, "en-US", XmlDataType.Text);
            XPathNodeIterator nodeIter = nav.Select(exp);

            while (nodeIter.MoveNext())
            {
                treeCompendium.Nodes["nodeItems"].Nodes.Add(nodeIter.Current.SelectSingleNode("@Name").ToString());
            }

            exp = nav.Compile("Items/Item[@Type='Armor']");
            exp.AddSort("@Name", XmlSortOrder.Ascending, XmlCaseOrder.UpperFirst, "en-US", XmlDataType.Text);
            nodeIter = nav.Select(exp);

            while (nodeIter.MoveNext())
            {
                treeCompendium.Nodes["nodeArmor"].Nodes.Add(nodeIter.Current.SelectSingleNode("@Name").ToString());
            }

            exp = nav.Compile("Items/Item[@Type='Weapon']");
            exp.AddSort("@Name", XmlSortOrder.Ascending, XmlCaseOrder.UpperFirst, "en-US", XmlDataType.Text);
            nodeIter = nav.Select(exp);

            while (nodeIter.MoveNext())
            {
                treeCompendium.Nodes["nodeWeapon"].Nodes.Add(nodeIter.Current.SelectSingleNode("@Name").ToString());
            }

            nav = cvVehicleXml.CreateNavigator();
            exp = nav.Compile("Vehicles/Vehicle");
            exp.AddSort("@Name", XmlSortOrder.Ascending, XmlCaseOrder.UpperFirst, "en-US", XmlDataType.Text);
            nodeIter = nav.Select(exp);

            while (nodeIter.MoveNext())
            {
                treeCompendium.Nodes["nodeVehicle"].Nodes.Add(nodeIter.Current.SelectSingleNode("@Name").ToString());
            }

            string[] files = Directory.GetFiles(cvNpcFolder, "*.xml");

            foreach (string lvFile in files)
            {
                treeCompendium.Nodes["nodeNPC"].Nodes.Add(Path.GetFileNameWithoutExtension(lvFile));
            }
        }

        private void treeCompendium_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Cash")
            {
                CashControl cControl = new CashControl();
                GMForm.setPanelSelectedCash(cControl);
            }
            else if (e.Node.Parent != null)
            {
                switch (e.Node.Parent.Text)
                {
                    case "Item":
                        XPathNavigator itemNav = cvItemXml.CreateNavigator().SelectSingleNode("Items/Item[@Name = '" + e.Node.Text + "']");

                        ItemDisplay.ItemName = e.Node.Text;
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

                        ItemDisplay iDisplay = new ItemDisplay();
                        GMForm.setPanelSelectedItem(iDisplay);
                        break;
                    case "Weapon":
                        XPathNavigator weaponNav = cvItemXml.CreateNavigator().SelectSingleNode("Items/Item[@Name = '" + e.Node.Text + "']");

                        ItemDisplay.ItemName = e.Node.Text;
                        ItemDisplay.Scope = weaponNav.SelectSingleNode("Scope").Value;
                        ItemDisplay.Image = weaponNav.SelectSingleNode("Image").Value;
                        ItemDisplay.Cost = weaponNav.SelectSingleNode("Cost").ValueAsInt;
                        ItemDisplay.ItemSize = weaponNav.SelectSingleNode("Size").ValueAsInt;
                        ItemDisplay.Damage_Prim = weaponNav.SelectSingleNode("Primary/Damage").Value + "(" + weaponNav.SelectSingleNode("Primary/Threat").Value + ")";;

                        XPathNavigator secNav = weaponNav.SelectSingleNode("Secondary/Damage");
                        if (secNav != null)
                            ItemDisplay.Damage_Sec = weaponNav.SelectSingleNode("Secondary/Damage").Value + "(" + weaponNav.SelectSingleNode("Secondary/Threat").Value + ")";
                        else
                            ItemDisplay.Damage_Sec = null;

                        XPathNavigator mediumNav = weaponNav.SelectSingleNode("Range/Medium");
                        XPathNavigator longNav = weaponNav.SelectSingleNode("Range/Long");

                        ItemDisplay.Range = weaponNav.SelectSingleNode("Range/Short").Value;
                        if (mediumNav != null)
                            ItemDisplay.Range += @"/" + mediumNav.Value;
                        if (longNav != null)
                            ItemDisplay.Range += @"/" + longNav.Value;

                        ItemDisplay.Durability = 0;
                        ItemDisplay.Structure = 0;
                        ItemDisplay.Def_General = 0;
                        ItemDisplay.Def_Ballistic = 0;

                        ItemDisplay.Description = weaponNav.SelectSingleNode("Description").Value;

                        ItemDisplay wDisplay = new ItemDisplay();
                        GMForm.setPanelSelectedItem(wDisplay);
                        break;
                    case "Armor":
                        XPathNavigator armorNav = cvItemXml.CreateNavigator().SelectSingleNode("Items/Item[@Name = '" + e.Node.Text + "']");

                        ItemDisplay.ItemName = e.Node.Text;
                        ItemDisplay.Image = armorNav.SelectSingleNode("Image").Value;
                        ItemDisplay.Cost = armorNav.SelectSingleNode("Cost").ValueAsInt;
                        ItemDisplay.Def_General = armorNav.SelectSingleNode("General").ValueAsInt;
                        ItemDisplay.Def_Ballistic = armorNav.SelectSingleNode("Ballistic").ValueAsInt;
                        ItemDisplay.Description = armorNav.SelectSingleNode("Description").Value;
                        ItemDisplay.Durability = 0;
                        ItemDisplay.Structure = 0;
                        ItemDisplay.Scope = null;
                        ItemDisplay.Damage_Prim = null;
                        ItemDisplay.Damage_Sec = null;
                        ItemDisplay.Capacity = null;
                        ItemDisplay.Range = null;

                        ItemDisplay aDisplay = new ItemDisplay();
                        GMForm.setPanelSelectedItem(aDisplay);
                        break;
                    case "Vehicle":
                        XPathNavigator vehicleNav = cvVehicleXml.CreateNavigator().SelectSingleNode("Vehicles/Vehicle[@Name = '" + e.Node.Text + "']");

                        VehicleDisplay.VehicleName = e.Node.Text;
                        VehicleDisplay.Image = vehicleNav.SelectSingleNode("Image").Value;
                        VehicleDisplay.Cost = vehicleNav.SelectSingleNode("Cost").ValueAsInt;
                        VehicleDisplay.ItemSize = vehicleNav.SelectSingleNode("Size").ValueAsInt;
                        VehicleDisplay.Durability = vehicleNav.SelectSingleNode("Durability").ValueAsInt;
                        VehicleDisplay.Structure = vehicleNav.SelectSingleNode("Structure").ValueAsInt;
                        VehicleDisplay.Acceleration = vehicleNav.SelectSingleNode("Acceleration").ValueAsInt;
                        VehicleDisplay.Speed = vehicleNav.SelectSingleNode("Speed").ValueAsInt;
                        VehicleDisplay.Safe_Speed = vehicleNav.SelectSingleNode("Safe_Speed").ValueAsInt;
                        VehicleDisplay.Handling = vehicleNav.SelectSingleNode("Handling").ValueAsInt;
                        VehicleDisplay.Occupancy = vehicleNav.SelectSingleNode("Occupancy").ValueAsInt;
                        VehicleDisplay.Capacity = vehicleNav.SelectSingleNode("Capacity").ValueAsInt;
                        VehicleDisplay.Description = vehicleNav.SelectSingleNode("Description").Value;

                        VehicleDisplay vDisplay = new VehicleDisplay();
                        GMForm.setPanelSelectedVehicle(vDisplay);
                        break;
                    case "NPC":
                        XPathDocument lvNPCxml = new XPathDocument(Properties.Settings.Default.DataLocation + @"NPC/" + e.Node.Text + ".xml");
                        XPathNavigator npcNav = lvNPCxml.CreateNavigator();                        

                        CharDisplay.CharName = npcNav.SelectSingleNode("Character/Background/Name").Value;
                        CharDisplay.Type = npcNav.SelectSingleNode("Character/Background/Type").Value;
                        CharDisplay.Health = npcNav.SelectSingleNode("Character/Attributes/Health/Max").ValueAsInt;
                        CharDisplay.Bash = npcNav.SelectSingleNode("Character/Attributes/Health/Bash").ValueAsInt;
                        CharDisplay.Lethal = npcNav.SelectSingleNode("Character/Attributes/Health/Lethal").ValueAsInt;
                        CharDisplay.Aggravated = npcNav.SelectSingleNode("Character/Attributes/Health/Aggravated").ValueAsInt;
                        CharDisplay.WillpowerMax = npcNav.SelectSingleNode("Character/Attributes/Willpower/Max").ValueAsInt;
                        CharDisplay.WillpowerCurrent = npcNav.SelectSingleNode("Character/Attributes/Willpower/Current").ValueAsInt;
                        CharDisplay.Image = npcNav.SelectSingleNode("Character/Image").Value;
                        CharDisplay.DisplayType = Global.CharType.NPC;
                        CharDisplay lvChar = new CharDisplay();

                        CharDisplay cDisplay = new CharDisplay();
                        GMForm.setPanelSelectedChar(cDisplay);
                        break;
                    default:
                        break;
                }
            }           
        }

        private void treeCompendium_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string selected = ((TreeNode) e.Item).Text;
            DoDragDrop(selected, DragDropEffects.Move);
        }

        private void treeCompendium_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeCompendium.SelectedNode != null)
            {
                string lvName = treeCompendium.SelectedNode.Text;

                string lvParentNode = "";
                foreach (Control lvControl in this.Controls)
                {
                    if (lvControl is TreeView)
                    {
                        foreach (TreeNode tNode in ((TreeView)lvControl).Nodes)
                        {
                            foreach (TreeNode cNode in tNode.Nodes)
                            {
                                if (cNode.Text == lvName)
                                    lvParentNode = tNode.Text;
                            }
                        }
                    }
                }

                switch (lvParentNode)
                {
                    case "NPC":
                        Global.AddCombatActor(lvName, "NPC");
                        break;
                    case "Item":
                        XPathNavigator itemNav = cvItemXml.CreateNavigator().SelectSingleNode("Items/Item[@Name = '" + lvName + "']");
                        Global.AddLootItem(lvName, itemNav.SelectSingleNode("Size").ValueAsInt, itemNav.SelectSingleNode("Cost").ValueAsInt,
                            itemNav.SelectSingleNode("Image").Value, itemNav.SelectSingleNode("@Type").Value);
                        break;
                    default:
                        break;
                }
            }            
        }
    }
}
