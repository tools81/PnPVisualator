using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class GMControl : UserControl
    {
        private string cvXmlFile;

        private class Status
        {
            public string Name { get; set; }
            public string Text { get; set; }
        }

        public GMControl()
        {
            InitializeComponent();

            SetXmlFile();
            PopulateDropdowns();
            PopulateWeapons();
        }

        private void PopulateWeapons()
        {           
            XPathDocument xDoc = new XPathDocument(cvXmlFile);
            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Character/Equipment");
            XPathNodeIterator xWeapIter = xNav.Select("Weapons/Weapon[@Equipped='true']");

            while (xWeapIter.MoveNext())
            {
                GMWeaponControl.WeaponName = xWeapIter.Current.SelectSingleNode("@Name").Value;
                GMWeaponControl.WeaponId = xWeapIter.Current.SelectSingleNode("@ID").Value;
                if (xWeapIter.Current.SelectSingleNode("Capacity") != null)
                {
                    GMWeaponControl.CapacityCurrent = xWeapIter.Current.SelectSingleNode("Capacity/Current").Value;
                    GMWeaponControl.CapacityMax = xWeapIter.Current.SelectSingleNode("Capacity/Max").Value;
                    GMWeaponControl.ShowAmmoControl = true;
                }
                else
                {
                    GMWeaponControl.CapacityCurrent = "N";
                    GMWeaponControl.CapacityMax = "A";
                    GMWeaponControl.ShowAmmoControl = false;
                }                    

                XPathDocument xWeapDoc = new XPathDocument(Global.ItemXml);
                XPathNavigator xWeapNav = xWeapDoc.CreateNavigator().SelectSingleNode(String.Format("Items/Item[@Name='{0}']", GMWeaponControl.WeaponName));

                string lvBeyondShortRange = String.Empty;
                if (xWeapNav.SelectSingleNode("Range/Medium") != null)
                {
                    lvBeyondShortRange = "/" + xWeapNav.SelectSingleNode("Range/Medium").Value + "/" +
                                        xWeapNav.SelectSingleNode("Range/Long").Value;
                }
                GMWeaponControl.Range = xWeapNav.SelectSingleNode("Range/Short").Value + lvBeyondShortRange;
                GMWeaponControl.Damage = xWeapNav.SelectSingleNode("Primary/Damage").Value;
                GMWeaponControl.Image = Global.ItemImagesFolder + xWeapNav.SelectSingleNode("Image").Value;

                GMWeaponControl weapCtrl = new GMWeaponControl();
                pnlWeapons.Controls.Add(weapCtrl);
            }
        }

        private void PopulateDropdowns()
        {
            XPathDocument xPathDoc = new XPathDocument(Global.StatusXml);
            XPathNavigator xPathNav = xPathDoc.CreateNavigator();
            XPathNodeIterator xNodeIter = xPathNav.Select("Statuses/Status");

            var lvDatasource = new List<Status>();
            lvDatasource.Add(new Status() {Name = "", Text = ""});
            while (xNodeIter.MoveNext())
            {
                lvDatasource.Add(new Status() { Name = xNodeIter.Current.SelectSingleNode("@Name").Value, Text = xNodeIter.Current.SelectSingleNode("@Text").Value});
            }
            cmbStatus.DataSource = lvDatasource;
            cmbStatus.DisplayMember = "Text";
            cmbStatus.ValueMember = "Name";
        }

        public void SetXmlFile()
        {
            if (Global.SelectedActorType == Global.CharType.Character)
                cvXmlFile = Global.CharacterFolder + Global.SelectedActorID + ".xml";
            else if (Global.SelectedActorType == Global.CharType.NPC)
                cvXmlFile = Global.CombatFolder + Global.SelectedActorID + ".xml";
            else
            {
                //TODO: Exception
            }
        }

        private void btnBash_Click(object sender, EventArgs e)
        {
            CharacterUpdate.Damage(Convert.ToInt32(numBash.Value), Global.DamageType.Bash, cvXmlFile);
            numBash.Value = 1;
        }

        private void btnLethal_Click(object sender, EventArgs e)
        {
            CharacterUpdate.Damage(Convert.ToInt32(numLethal.Value), Global.DamageType.Lethal, cvXmlFile);
            numLethal.Value = 1;
        }

        private void btnAggravated_Click(object sender, EventArgs e)
        {
            CharacterUpdate.Damage(Convert.ToInt32(numAggravated.Value), Global.DamageType.Aggravated, cvXmlFile);
            numAggravated.Value = 1;
        }

        private void btnHeal_Click(object sender, EventArgs e)
        {
            CharacterUpdate.Heal(Convert.ToInt32(numHeal.Value), cvXmlFile, false);
            numHeal.Value = 1;
        }

        private void btnHealFull_Click(object sender, EventArgs e)
        {
            CharacterUpdate.Heal(0, cvXmlFile, true);
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Status lvStatus = (Status)cmbStatus.SelectedItem;
            if (lvStatus != null && lvStatus.Name != "")
            {
                CharacterUpdate.AddRemoveStatus(lvStatus.Name, cvXmlFile);
                cmbStatus.SelectedIndex = -1;
            }            
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.CombatXml);
            XmlNodeList xNodes = xDoc.SelectNodes("Combat/Entity");

            foreach (XmlNode xNode in xNodes)
            {
                XmlNode xOrderNode = xNode.SelectSingleNode("@Order");
                int xOrderInt = Convert.ToInt32(xOrderNode.Value);

                if (xOrderNode.Value == "1")
                {
                    xOrderNode.Value = xNodes.Count.ToString();
                }
                else
                {
                    xOrderNode.Value = (Convert.ToInt32(xOrderNode.Value) - 1).ToString();
                }
            }

            FileStream lvFS = new FileStream(Global.CombatXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        private void btnRestoreWill_Click(object sender, EventArgs e)
        {
            CharacterUpdate.RestoreWill(Convert.ToInt32(numRestoreWill.Value), cvXmlFile, false);
        }

        private void btnRestoreWillFull_Click(object sender, EventArgs e)
        {
            CharacterUpdate.RestoreWill(Convert.ToInt32(numRestoreWill.Value), cvXmlFile, true);
        }

        private void btnSpendWill_Click(object sender, EventArgs e)
        {
            CharacterUpdate.SpendWill(Convert.ToInt32(numSpendWill.Value), cvXmlFile);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Global.RemoveCombatActor(Global.SelectedActorID, Global.SelectedActorType);
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            AdvancedGMControl aGMControl = new AdvancedGMControl();

            Global.CustomForm = new CustomForm();
            Global.CustomForm.Controls.Clear();
            Global.CustomForm.Controls.Add(aGMControl);
            Global.CustomForm.Height = 255;
            Global.CustomForm.Width = 634;
            Global.CustomForm.Text = "Combat - Advanced";
            Global.CustomForm.Show();
        }
    }
}
