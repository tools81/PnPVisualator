using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class Store : UserControl
    {
        private string _buySelectedItemName;
        private int _buySelectedItemCost;
        private string _buyItemType;
        private string _sellSelectedItemName;
        private int _sellSelectedItemCost;
        private string _sellItemType;
        private Guid _sellSelectedID;

        private enum TransactionType
        {
            Buy,
            Sell
        }

        public Store()
        {
            InitializeComponent();

            XPathDocument xDoc = new XPathDocument(Global.ItemXml);
            FillPanel(xDoc, pnlItems, "Item");
            FillPanel(xDoc, pnlWeapons, "Weapon");
            FillPanel(xDoc, pnlArmor, "Armor");

            XPathDocument xVehDoc = new XPathDocument(Global.VehicleXml);
            FillPanel(xVehDoc, pnlVehicles, "Vehicle");

            FillSellPanel();
        }

        private void FillSellPanel()
        {
            XPathDocument xItemDoc = new XPathDocument(Global.ItemXml);
            XPathNavigator xItemNav = xItemDoc.CreateNavigator();
            XPathDocument xVehDoc = new XPathDocument(Global.VehicleXml);
            XPathNavigator xVehNav = xVehDoc.CreateNavigator();
            XPathDocument lvCharXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Characters/" + Player.Name + ".xml");
            XPathNavigator equipmentNav = lvCharXml.CreateNavigator().SelectSingleNode("Character/Equipment");

            foreach (string lvItem in Player.Equipment)
            {
                if (!String.IsNullOrEmpty(lvItem))
                {
                    string lvName = equipmentNav.SelectSingleNode("Items/Item[@ID = '" + lvItem + "']/@Name").Value;

                    IconLabel lvIconLabel = new IconLabel();
                    lvIconLabel.DisplayType = IconLabel.Type.Item;
                    lvIconLabel.Display = lvName;
                    lvIconLabel.Image = xItemNav.SelectSingleNode(String.Format("Items/Item[@Name='{0}']/Image", lvName)).Value;
                    lvIconLabel.ID = new Guid(lvItem);
                    lvIconLabel.Width = 170;

                    lvIconLabel.MouseClick += IconLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)
                    {
                        c.MouseClick += (sender, e) => { DescribeItem(lvIconLabel.Display, TransactionType.Sell, lvIconLabel.ID); };
                    }

                    pnlPlayerGear.Controls.Add(lvIconLabel);
                }                
            }

            foreach (var lvWeap in Player.Weapon)
            {
                if (!string.IsNullOrEmpty(lvWeap))
                {
                    string lvWeapName = equipmentNav.SelectSingleNode("Weapons/Weapon[@ID = '" + lvWeap + "']/@Name").Value;

                    IconLabel lvIconLabel = new IconLabel();
                    lvIconLabel.DisplayType = IconLabel.Type.Item;
                    lvIconLabel.Display = lvWeapName;
                    lvIconLabel.Image = xItemNav.SelectSingleNode(String.Format("Items/Item[@Name='{0}']/Image", lvWeapName)).Value;
                    lvIconLabel.ID = new Guid(lvWeap);
                    lvIconLabel.Width = 170;

                    lvIconLabel.MouseClick += IconLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)
                    {
                        c.MouseClick += (sender, e) => { DescribeItem(lvIconLabel.Display, TransactionType.Sell, lvIconLabel.ID); };
                    }

                    pnlPlayerGear.Controls.Add(lvIconLabel);
                }
            }

            foreach (var lvArmor in Player.Armor)
            {
                if (!string.IsNullOrEmpty(lvArmor))
                {
                    string lvArmorName = equipmentNav.SelectSingleNode("Armors/Armor[@ID = '" + lvArmor + "']/@Name").Value;

                    IconLabel lvIconLabel = new IconLabel();
                    lvIconLabel.DisplayType = IconLabel.Type.Item;
                    lvIconLabel.Display = lvArmorName;
                    lvIconLabel.Image = xItemNav.SelectSingleNode(String.Format("Items/Item[@Name='{0}']/Image", lvArmorName)).Value;
                    lvIconLabel.ID = new Guid(lvArmor);
                    lvIconLabel.Width = 170;

                    lvIconLabel.MouseClick += IconLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)
                    {
                        c.MouseClick += (sender, e) => { DescribeItem(lvIconLabel.Display, TransactionType.Sell, lvIconLabel.ID); };
                    }

                    pnlPlayerGear.Controls.Add(lvIconLabel);
                }
            }

            foreach (Guid lvVeh in Player.Vehicle)
            {
                XPathNavigator playerVehNav = lvCharXml.CreateNavigator().SelectSingleNode(String.Format("Character/Vehicles/Vehicle[@ID='{0}']/@Name", lvVeh.ToString()));
                IconLabel lvIconLabel = new IconLabel();
                lvIconLabel.DisplayType = IconLabel.Type.Vehicle;
                lvIconLabel.Display = playerVehNav.Value;
                lvIconLabel.Image = xVehNav.SelectSingleNode(String.Format("Vehicles/Vehicle[@Name='{0}']/Image", playerVehNav.Value)).Value;
                lvIconLabel.Width = 170;

                lvIconLabel.MouseClick += IconVehicleLabel_Clicked;
                foreach (Control c in lvIconLabel.Controls)
                {
                    c.MouseClick += (sender, e) => { DescribeVehicle(lvIconLabel.Display, TransactionType.Sell); };
                }

                pnlPlayerGear.Controls.Add(lvIconLabel);           
            }
        }

        private void FillPanel(XPathDocument xDoc, FlowLayoutPanel lvPanel, string lvItemType)
        {
            XPathNavigator xNav = xDoc.CreateNavigator();
            XPathExpression exp = lvItemType != "Vehicle" ? xNav.Compile(String.Format("Items/Item[@Type='{0}']", lvItemType)) : xNav.Compile("Vehicles/Vehicle");
            exp.AddSort("@Name", XmlSortOrder.Ascending, XmlCaseOrder.UpperFirst, "en-US", XmlDataType.Text);
            XPathNodeIterator xNodeIter = xNav.Select(exp);

            while (xNodeIter.MoveNext())
            {
                IconLabel lvIconLabel = new IconLabel();
                lvIconLabel.DisplayType = lvItemType != "Vehicle" ? IconLabel.Type.Item : IconLabel.Type.Vehicle;
                lvIconLabel.Display = xNodeIter.Current.SelectSingleNode("@Name").Value;
                lvIconLabel.Image = xNodeIter.Current.SelectSingleNode("Image").Value;
                lvIconLabel.Width = 170;

                if (lvItemType != "Vehicle")
                {
                    lvIconLabel.MouseClick += IconLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)
                    {
                        c.MouseClick += (sender, e) => { DescribeItem(lvIconLabel.Display, TransactionType.Buy); };
                    }
                } 
                else
                {
                    lvIconLabel.MouseClick += IconVehicleLabel_Clicked;
                    foreach (Control c in lvIconLabel.Controls)
                    {
                        c.MouseClick += (sender, e) => { DescribeVehicle(lvIconLabel.Display, TransactionType.Buy); };
                    }
                }               

                lvPanel.Controls.Add(lvIconLabel);
            }
        }       

        private void IconLabel_Clicked(object sender, MouseEventArgs e)
        {
            if (((IconLabel)sender).Parent == pnlPlayerGear)
            {
                DescribeItem(((IconLabel)sender).Display, TransactionType.Sell, ((IconLabel)sender).ID);
            } 
            else
            {
                DescribeItem(((IconLabel)sender).Display, TransactionType.Buy);
            }           
        }

        private void IconVehicleLabel_Clicked(object sender, MouseEventArgs e)
        {
            if (((IconLabel)sender).Parent == pnlPlayerGear)
            {
                DescribeVehicle(((IconLabel)sender).Display, TransactionType.Sell);
            }
            else
            {
                DescribeVehicle(((IconLabel)sender).Display, TransactionType.Buy);
            }
        }

        private void DescribeItem(string pvLabel, TransactionType pvType, Guid pvID = new Guid())
        {
            XPathDocument xDoc = new XPathDocument(Global.ItemXml);
            XPathNavigator nav = xDoc.CreateNavigator();
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
                    break;
                case "Weapon":
                    ItemDisplay.ItemName = pvLabel;
                    ItemDisplay.Image = itemNav.SelectSingleNode("Image").Value;
                    ItemDisplay.Cost = itemNav.SelectSingleNode("Cost").ValueAsInt;
                    ItemDisplay.ItemSize = itemNav.SelectSingleNode("Size").ValueAsInt;
                    //ItemDisplay.Durability = itemNav.SelectSingleNode("Durability").ValueAsInt;
                    //ItemDisplay.Structure = itemNav.SelectSingleNode("Structure").ValueAsInt;
                    ItemDisplay.Description = itemNav.SelectSingleNode("Description").Value;
                    break;
                case "Armor":
                    ItemDisplay.ItemName = pvLabel;
                    ItemDisplay.Image = itemNav.SelectSingleNode("Image").Value;
                    ItemDisplay.Cost = itemNav.SelectSingleNode("Cost").ValueAsInt;
                    //ItemDisplay.Durability = itemNav.SelectSingleNode("Durability").ValueAsInt;
                    ItemDisplay.Description = itemNav.SelectSingleNode("Description").Value;
                    break;
            }

            if (pvType == TransactionType.Buy)
            {
                _buySelectedItemName = ItemDisplay.ItemName;
                _buySelectedItemCost = ItemDisplay.Cost;
                _buyItemType = itemNav.SelectSingleNode("@Type").Value;
                btnBuy.Enabled = true;
                btnSell.Enabled = false;
            }
            else
            {
                _sellSelectedItemName = ItemDisplay.ItemName;
                _sellSelectedItemCost = ItemDisplay.Cost;
                _sellItemType = itemNav.SelectSingleNode("@Type").Value;
                _sellSelectedID = pvID;
                btnBuy.Enabled = false;
                btnSell.Enabled = true;
            }            

            ItemDisplay iDisplay = new ItemDisplay();
            pnlItemDisplay.Controls.Clear();
            pnlItemDisplay.Controls.Add(iDisplay);
        }

        private void DescribeVehicle(string display, TransactionType pvType)
        {
            XPathDocument xDoc = new XPathDocument(Global.VehicleXml);
            XPathNavigator nav = xDoc.CreateNavigator();
            XPathNavigator vehicleNav = nav.SelectSingleNode("Vehicles/Vehicle[@Name = '" + display + "']");

            VehicleDisplay.VehicleName = display;
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

            if (pvType == TransactionType.Buy)
            {
                _buySelectedItemName = ItemDisplay.ItemName;
                _buySelectedItemCost = ItemDisplay.Cost;
                _buyItemType = "Vehicle";
            }
            else
            {
                _sellSelectedItemName = ItemDisplay.ItemName;
                _sellSelectedItemCost = ItemDisplay.Cost;
                _sellItemType = "Vehicle";
                //TODO: _sellSelectedID
            }

            VehicleDisplay vDisplay = new VehicleDisplay();
            pnlItemDisplay.Controls.Clear();
            pnlItemDisplay.Controls.Add(vDisplay);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                ItemBuyRequest buyReq = new ItemBuyRequest(_buySelectedItemName, _buySelectedItemCost, Player.Name, _buyItemType);
                ChatboxMessages.PlayerRequestPurchase(Player.Name, _buySelectedItemName);               
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            try
            {
                ItemSellRequest sellReq = new ItemSellRequest(_sellSelectedItemName, _sellSelectedItemCost, Player.Name, _sellSelectedID, _sellItemType);
                ChatboxMessages.PlayerRequestSell(Player.Name, _sellSelectedItemName);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
