using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class CreateItem : UserControl
    {
        public CreateItem()
        {
            InitializeComponent();
        }

        public string cvImage;
        public string imgItem;

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlType.SelectedItem.ToString())
            {
                case "Armor":
                    pnlCostDurability.Visible = true;
                    pnlArmor.Visible = true;
                    pnlSizeStructure.Visible = false;
                    pnlWeapon.Visible = false;
                    pnlVehicle.Visible = false;
                    break;
                case "Weapon":
                    pnlCostDurability.Visible = true;
                    pnlArmor.Visible = false;
                    pnlSizeStructure.Visible = true;
                    pnlWeapon.Visible = true;
                    pnlVehicle.Visible = false;
                    break;
                case "Item":
                    pnlCostDurability.Visible = true;
                    pnlArmor.Visible = false;
                    pnlSizeStructure.Visible = true;
                    pnlWeapon.Visible = false;
                    pnlVehicle.Visible = false;
                    break;
                case "Vehicle":
                    pnlCostDurability.Visible = true;
                    pnlArmor.Visible = false;
                    pnlSizeStructure.Visible = true;
                    pnlWeapon.Visible = false;
                    pnlVehicle.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string lvImageLoc;

            ofdItemImage.InitialDirectory = "c:\\";
            ofdItemImage.RestoreDirectory = true;

            if (ofdItemImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lvImageLoc = ofdItemImage.FileName;
                    cvImage = ofdItemImage.SafeFileName;
                    imgItemImage.ImageLocation = lvImageLoc;
                    imgItemImage.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Properties.Settings.Default.DataLocation + Properties.Settings.Default.DataLocation + "Lists/Item.xml");

                XmlElement xElement = xDoc.CreateElement("Item");
                XmlAttribute xName = xDoc.CreateAttribute("Name");
                XmlAttribute xType = xDoc.CreateAttribute("Type");
                xName.Value = txtName.Text;
                xType.Value = ddlType.SelectedItem.ToString();

                xElement.SetAttributeNode(xName);
                xElement.SetAttributeNode(xType);

                XmlElement xDurability = xDoc.CreateElement("Durability");
                xDurability.InnerText = rdoDurability.AbilityRank.ToString();
                XmlElement xCost = xDoc.CreateElement("Cost");
                xCost.InnerText = rdoCost.AbilityRank.ToString();
                XmlElement xImage = xDoc.CreateElement("Image");
                xImage.InnerText = cvImage;
                XmlElement xDescription = xDoc.CreateElement("Description");
                xDescription.InnerText = txtItemDescription.Text;

                switch (ddlType.SelectedItem.ToString())
                {
                    case "Armor":
                        XmlElement xGeneral = xDoc.CreateElement("General");
                        xGeneral.InnerText = rdoArmorGeneral.AbilityRank.ToString();
                        XmlElement xBallistic = xDoc.CreateElement("Ballistic");
                        xBallistic.InnerText = rdoArmorBallistic.AbilityRank.ToString();
                        XmlElement xThreatDown = xDoc.CreateElement("Threat_Down");
                        xThreatDown.InnerText = (chkThreatDown.Checked) ? "Y" : "N";
                        XmlElement xRequirement = xDoc.CreateElement("Requirement");
                        xRequirement.InnerText = rdoArmorRequirement.AbilityRank.ToString();
                        XmlElement xDefPen = xDoc.CreateElement("Defense_Penalty");
                        xDefPen.InnerText = rdoArmorDefPenalty.AbilityRank.ToString();
                        XmlElement xSpeedPen = xDoc.CreateElement("Speed_Penalty");
                        xSpeedPen.InnerText = rdoArmorSpeedPenalty.AbilityRank.ToString();

                        xElement.AppendChild(xGeneral);
                        xElement.AppendChild(xBallistic);
                        xElement.AppendChild(xThreatDown);
                        xElement.AppendChild(xRequirement);
                        xElement.AppendChild(xDefPen);
                        xElement.AppendChild(xSpeedPen);
                        xElement.AppendChild(xDurability);
                        xElement.AppendChild(xCost);
                        xElement.AppendChild(xImage);
                        xElement.AppendChild(xDescription);

                        xDoc.DocumentElement.InsertAfter(xElement, xDoc.DocumentElement.LastChild);

                        FileStream lvArmorFS = new FileStream(Properties.Settings.Default.DataLocation + "Lists/Item.xml", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                        xDoc.Save(lvArmorFS);
                        break;
                    case "Weapon":
                        XmlElement xPrimary = xDoc.CreateElement("Primary");
                        XmlElement xRange = xDoc.CreateElement("Range");
                        XmlElement xDamage = xDoc.CreateElement("Damage");
                        XmlElement xThreat = xDoc.CreateElement("Threat");
                        xRange.InnerText = numWeapPrimRange.Value.ToString();
                        xDamage.InnerText = numWeapPrimDamage.Value.ToString();
                        xThreat.InnerText = ddlWeapPrimType.SelectedItem.ToString();
                        xPrimary.AppendChild(xRange);
                        xPrimary.AppendChild(xDamage);
                        xPrimary.AppendChild(xThreat);

                        xElement.AppendChild(xPrimary);

                        if (ddlWeapSecType.SelectedIndex != -1)
                        {
                            XmlElement xSecondary = xDoc.CreateElement("Secondary");
                            xRange = xDoc.CreateElement("Range");
                            xDamage = xDoc.CreateElement("Damage");
                            xThreat = xDoc.CreateElement("Threat");
                            xRange.InnerText = numWeapSecRange.Value.ToString();
                            xDamage.InnerText = numWeapSecDamage.Value.ToString();
                            xThreat.InnerText = ddlWeapSecType.SelectedItem.ToString();
                            xSecondary.AppendChild(xRange);
                            xSecondary.AppendChild(xDamage);
                            xSecondary.AppendChild(xThreat);

                            xElement.AppendChild(xSecondary);
                        }
                        if (ddlWeapTertType.SelectedIndex != -1)
                        {
                            XmlElement xTertiary = xDoc.CreateElement("Tertiary");
                            xRange = xDoc.CreateElement("Range");
                            xDamage = xDoc.CreateElement("Damage");
                            xThreat = xDoc.CreateElement("Threat");
                            xRange.InnerText = numWeapTertRange.Value.ToString();
                            xDamage.InnerText = numWeapTertDamage.Value.ToString();
                            xThreat.InnerText = ddlWeapTertType.SelectedItem.ToString();
                            xTertiary.AppendChild(xRange);
                            xTertiary.AppendChild(xDamage);
                            xTertiary.AppendChild(xThreat);

                            xElement.AppendChild(xTertiary);
                        }

                        XmlElement xWeapRequirement = xDoc.CreateElement("Requirement");
                        xWeapRequirement.InnerText = rdoWeapRequirement.AbilityRank.ToString();
                        XmlElement xTrained = xDoc.CreateElement("Trained");
                        xTrained.InnerText = (chkWeapTrained.Checked) ? "Y" : "N";
                        XmlElement xMaterial = xDoc.CreateElement("Material");
                        xMaterial.InnerText = ddlWeapMaterial.SelectedItem.ToString();
                        XmlElement xSize = xDoc.CreateElement("Size");
                        xSize.InnerText = rdoSize.AbilityRank.ToString();
                        XmlElement xStructure = xDoc.CreateElement("Structure");
                        xStructure.InnerText = rdoStructure.AbilityRank.ToString();

                        xElement.AppendChild(xWeapRequirement);
                        xElement.AppendChild(xTrained);
                        xElement.AppendChild(xMaterial);
                        xElement.AppendChild(xDurability);
                        xElement.AppendChild(xSize);
                        xElement.AppendChild(xCost);
                        xElement.AppendChild(xStructure);
                        xElement.AppendChild(xImage);
                        xElement.AppendChild(xDescription);

                        xDoc.DocumentElement.InsertAfter(xElement, xDoc.DocumentElement.LastChild);

                        FileStream lvWeapFS = new FileStream(Properties.Settings.Default.DataLocation + "Lists/Item.xml", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                        xDoc.Save(lvWeapFS);
                        break;
                    case "Item":
                        XmlElement xItemSize = xDoc.CreateElement("Size");
                        xItemSize.InnerText = rdoSize.AbilityRank.ToString();
                        XmlElement xItemStructure = xDoc.CreateElement("Structure");
                        xItemStructure.InnerText = rdoStructure.AbilityRank.ToString();

                        xElement.AppendChild(xDurability);
                        xElement.AppendChild(xItemSize);
                        xElement.AppendChild(xCost);
                        xElement.AppendChild(xItemStructure);
                        xElement.AppendChild(xImage);
                        xElement.AppendChild(xDescription);

                        xDoc.DocumentElement.InsertAfter(xElement, xDoc.DocumentElement.LastChild);

                        FileStream lvItemFS = new FileStream(Properties.Settings.Default.DataLocation + "Lists/Item.xml", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                        xDoc.Save(lvItemFS);
                        break;
                    case "Vehicle":
                        xDoc.Load(Properties.Settings.Default.DataLocation + "Lists/Vehicle.xml");

                        xElement = xDoc.CreateElement("Vehicle");
                        xName = xDoc.CreateAttribute("Name");
                        xName.Value = txtName.Text;

                        xElement.SetAttributeNode(xName);

                        xDurability = xDoc.CreateElement("Durability");
                        xDurability.InnerText = rdoDurability.AbilityRank.ToString();
                        xCost = xDoc.CreateElement("Cost");
                        xCost.InnerText = rdoCost.AbilityRank.ToString();
                        xImage = xDoc.CreateElement("Image");
                        xImage.InnerText = cvImage;
                        xDescription = xDoc.CreateElement("Description");
                        xDescription.InnerText = txtItemDescription.Text;
                        XmlElement xVehSize = xDoc.CreateElement("Size");
                        xVehSize.InnerText = rdoSize.AbilityRank.ToString();
                        XmlElement xVehStructure = xDoc.CreateElement("Structure");
                        xVehStructure.InnerText = rdoStructure.AbilityRank.ToString();
                        XmlElement xAcceleration = xDoc.CreateElement("Acceleration");
                        xAcceleration.InnerText = numVehAcc.Value.ToString();
                        XmlElement xSafe_Speed = xDoc.CreateElement("Safe_Speed");
                        xSafe_Speed.InnerText = numVehSafe.Value.ToString();
                        XmlElement xSpeed = xDoc.CreateElement("Speed");
                        xSpeed.InnerText = numVehSpeed.Value.ToString();
                        XmlElement xHandling = xDoc.CreateElement("Handling");
                        xHandling.InnerText = numVehHandle.ToString();
                        XmlElement xOccupancy = xDoc.CreateElement("Occupancy");
                        xOccupancy.InnerText = numVehOcc.Value.ToString();
                        XmlElement xCapacity = xDoc.CreateElement("Capacity");
                        xCapacity.InnerText = numVehCap.Value.ToString();

                        xElement.AppendChild(xDurability);
                        xElement.AppendChild(xVehSize);
                        xElement.AppendChild(xAcceleration);
                        xElement.AppendChild(xSafe_Speed);
                        xElement.AppendChild(xSpeed);
                        xElement.AppendChild(xHandling);
                        xElement.AppendChild(xCost);
                        xElement.AppendChild(xOccupancy);
                        xElement.AppendChild(xVehStructure);
                        xElement.AppendChild(xCapacity);
                        xElement.AppendChild(xDescription);
                        xElement.AppendChild(xImage);

                        xDoc.DocumentElement.InsertAfter(xElement, xDoc.DocumentElement.LastChild);

                        FileStream lvVehFS = new FileStream(Properties.Settings.Default.DataLocation + "Lists/Vehicle.xml", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                        xDoc.Save(lvVehFS);
                        break;
                    default:
                        break;
                }

                if (imgItemImage.ImageLocation != null)
                {
                    string lvPath = "Item_Images/" + cvImage;
                    if (imgItemImage.ImageLocation != null && ddlType.SelectedItem == "Vehicle")
                    {
                        lvPath = "Vehicle_Images/" + cvImage;
                    }

                    using (FileStream fs = File.Create(ofdItemImage.FileName)) {}

                    File.Delete(lvPath);

                    File.Copy(ofdItemImage.FileName, lvPath);
                }                

                lblConfirm.Text = "The item was successfully saved.";
            }
            catch (Exception ex)
            {
                lblConfirm.Text = "An error occured.  ~" + ex.Message; 
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }
    }
}
