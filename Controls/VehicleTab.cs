using System;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class VehicleTab : UserControl
    {
        private Control cvControl;
        private string cvSelectedItem;

        XPathDocument cvVehicleXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Vehicle.xml");
        XPathNavigator nav;

        public VehicleTab()
        {
            InitializeComponent();

            gbxItem.AllowDrop = true;

            Vehicle.Vehicle_Cargo = new string[16];

            nav = cvVehicleXml.CreateNavigator();
            XPathDocument lvCharXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Characters/" + Player.Name + ".xml");

            foreach (Guid lvVehicle in Player.Vehicle)
            {
                XPathNavigator playerVehNav = lvCharXml.CreateNavigator().SelectSingleNode(String.Format("Character/Vehicles/Vehicle[@ID='{0}']/@Name", lvVehicle.ToString()));
                IconLabel lvIconLabel = new IconLabel();
                lvIconLabel.Display = playerVehNav.Value;
                lvIconLabel.Image = nav.SelectSingleNode("Vehicles/Vehicle[@Name = '" + playerVehNav.Value + "']/Image").Value;
                lvIconLabel.DisplayType = IconLabel.Type.Vehicle;

                pnlVehicles.Controls.Add(lvIconLabel);

                foreach (Control c in lvIconLabel.Controls)
                {
                    c.MouseClick += (sender, e) => { DescribeVehicle(playerVehNav.Value); };
                }
            }
        }

        private void DescribeVehicle(string pvVehName)
        {
            //TODO: GetCargo();

            XPathNavigator nav = cvVehicleXml.CreateNavigator();
            XPathNavigator vehicleNav = nav.SelectSingleNode("Vehicles/Vehicle[@Name = '" + pvVehName + "']");

            lblActiveVehicle.Text = vehicleNav.SelectSingleNode("@Name").Value;
            VehicleDisplay.VehicleName = vehicleNav.SelectSingleNode("@Name").Value;
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
            tabPageDescription.Controls.Clear();
            tabPageDescription.Controls.Add(vDisplay);
        }

        private void GetCargo()
        {
            ClearCargoList();
            XPathDocument lvCharXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Characters/" + Player.ShortName + ".xml");
            XPathNavigator nav = lvCharXml.CreateNavigator();

            for (int i = 0; i < nav.SelectSingleNode("Character/Vehicles/Vehicle[@Name='" + lblActiveVehicle.Text + "']/Cargo").SelectChildren("Item", "").Count; i++)
            {
                string lvItem = nav.SelectSingleNode("Character/Vehicles/Vehicle[@Name='" + lblActiveVehicle.Text + "']/Cargo/Item[position()=" + (i + 1) + "]").Value;
                if (!String.IsNullOrEmpty(lvItem))
                {
                    cvControl = gbxItem.Controls.Find("lblItem" + (i + 1), false)[0];
                    if (cvControl.Text == "...")
                    {
                        cvControl.Text = lvItem;
                    }
                }
            }
        }

        private void ClearCargoList()
        {
            foreach (Label pvLabel in gbxItem.Controls)
            {
                pvLabel.Text = "...";
            }

            lblRetrieve.Text = "Retrieve";
            lblAdd.Text = "Add Item";
            lblActiveItem.Text = "";
            txtItemDescription.Text = "";
            imgItem.Image = null;
        }

        private void ItemDescription(string pvItem)
        {
            XPathDocument lvItemXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Item.xml");
            XPathNavigator lvNav = lvItemXml.CreateNavigator();

            if (pvItem != "...")
            {                     
                txtItemDescription.Text = lvNav.SelectSingleNode("Items/Item[@Name = '" + pvItem + "']/Description").Value;
                imgItem.ImageLocation = Properties.Settings.Default.DataLocation + "Item_Images\\" + lvNav.SelectSingleNode("Items/Item[@Name = '" + pvItem + "']/Image").Value;
                lblActiveItem.Text = pvItem;
            }
            else return;
        }

        private void lblItem1_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem1.Text);
            cvSelectedItem = lblItem1.Text;
        }

        private void lblItem2_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem2.Text);
            cvSelectedItem = lblItem2.Text;
        }

        private void lblItem3_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem3.Text);
            cvSelectedItem = lblItem3.Text;
        }

        private void lblItem4_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem4.Text);
            cvSelectedItem = lblItem4.Text;
        }

        private void lblItem5_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem5.Text);
            cvSelectedItem = lblItem5.Text;
        }

        private void lblItem6_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem6.Text);
            cvSelectedItem = lblItem6.Text;
        }

        private void lblItem7_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem7.Text);
            cvSelectedItem = lblItem7.Text;
        }

        private void lblItem8_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem8.Text);
            cvSelectedItem = lblItem8.Text;
        }

        private void lblItem9_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem9.Text);
            cvSelectedItem = lblItem9.Text;
        }

        private void lblItem10_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem10.Text);
            cvSelectedItem = lblItem10.Text;
        }

        private void lblItem11_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem11.Text);
            cvSelectedItem = lblItem11.Text;
        }

        private void lblItem12_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem12.Text);
            cvSelectedItem = lblItem12.Text;
        }

        private void lblItem13_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem13.Text);
            cvSelectedItem = lblItem13.Text;
        }

        private void lblItem14_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem14.Text);
            cvSelectedItem = lblItem14.Text;
        }

        private void lblItem15_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem15.Text);
            cvSelectedItem = lblItem15.Text;
        }

        private void lblItem16_Click(object sender, EventArgs e)
        {
            ItemDescription(lblItem16.Text);
            cvSelectedItem = lblItem16.Text;
        }

        private void lblRetrieve_Click(object sender, EventArgs e)
        {
            if (lblActiveItem.Text != "")
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Properties.Settings.Default.DataLocation + "Characters/" + Player.ShortName + ".xml");

                XmlNode xNode = xDoc.SelectSingleNode("Character/Vehicles/Vehicle[@Name='" + lblActiveVehicle.Text + "']/Cargo/Item[text()='" + lblActiveItem.Text + "']");
                string lvType = xNode.Attributes.GetNamedItem("Type").Value;
                xNode.ParentNode.RemoveChild(xNode);

                XmlElement xElement = xDoc.CreateElement(lvType);
                XmlAttribute xName = xDoc.CreateAttribute("Name");
                xName.Value = lblActiveItem.Text;
                xElement.Attributes.Append(xName);

                XmlNode xEquipNode = xDoc.SelectSingleNode("Character/Equipment/" + lvType + "s");
                xEquipNode.InsertAfter(xElement, xEquipNode.LastChild);

                FileStream lvFS = new FileStream(Properties.Settings.Default.DataLocation + "Characters/" + Player.ShortName + ".xml", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                xDoc.Save(lvFS);
                lvFS.Close();

                ClearCargoList();
                GetCargo();

                Character_Init cInit = new Character_Init(Player.ShortName);

                if (frmVisualator.isPanelSetToTrade())
                {
                    Trade lvTrade = new Trade();
                    frmVisualator.setPanelToTrade(lvTrade);
                }
            }
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            Trade lvTrade = new Trade();
            frmVisualator.setPanelToTrade(lvTrade);
        }

        private void gbxItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void gbxItem_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string lvName = e.Data.GetData(DataFormats.Text).ToString();
                int i = gbxItem.Controls.Count;
                foreach (Control lvControl in gbxItem.Controls)
                {
                    if (lvControl is Label)
                    {
                        if (lvControl.Text == "...")
                        {
                            lvControl.Text = lvName;
                            break;
                        }
                    }
                }

                XPathDocument lvItemXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Item.xml");
                XPathNavigator nav = lvItemXml.CreateNavigator();

                string lvType = nav.SelectSingleNode("Items/Item[@Name='" + lvName + "']/@Type").Value;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Properties.Settings.Default.DataLocation + "Characters/" + Player.ShortName + ".xml");

                XmlNode xNode = xDoc.SelectSingleNode("Character/Equipment/" + lvType + "s/" + lvType +"[@Name='" + lvName + "']");
                xNode.ParentNode.RemoveChild(xNode);

                XmlElement xElement = xDoc.CreateElement("Item");
                XmlAttribute xType = xDoc.CreateAttribute("Type");
                xType.Value = lvType;
                xElement.Attributes.Append(xType);
                xElement.InnerText = lvName;

                XmlNode xEquipNode = xDoc.SelectSingleNode("Character/Vehicles/Vehicle[@Name='" + lblActiveVehicle.Text + "']/Cargo");
                xEquipNode.InsertAfter(xElement, xEquipNode.LastChild);

                FileStream lvFS = new FileStream(Properties.Settings.Default.DataLocation + "Characters/" + Player.ShortName + ".xml", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                xDoc.Save(lvFS);
                lvFS.Close();

                ClearCargoList();
                GetCargo();

                Character_Init cInit = new Character_Init(Player.ShortName);

                Trade lvTrade = new Trade();
                frmVisualator.setPanelToTrade(lvTrade);
            }
        }
    }
}
