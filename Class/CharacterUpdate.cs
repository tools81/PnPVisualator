using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class
{
    class CharacterUpdate
    {
        public static void Damage(int pvDamage, Global.DamageType pvDamageType, string pvXml)
        {   
            XPathDocument xPathDoc = new XPathDocument(pvXml);
            XPathNavigator xPathNav = xPathDoc.CreateNavigator();

            int lvHealth = xPathNav.SelectSingleNode("Character/Attributes/Health/Max").ValueAsInt;
            int lvBash = xPathNav.SelectSingleNode("Character/Attributes/Health/Bash").ValueAsInt;
            int lvLethal = xPathNav.SelectSingleNode("Character/Attributes/Health/Lethal").ValueAsInt;
            int lvAggravated = xPathNav.SelectSingleNode("Character/Attributes/Health/Aggravated").ValueAsInt;

            int lvTotal = lvBash + lvLethal + lvAggravated;
            int lvLethalUpgradeAllowance = lvHealth - lvAggravated;
            int lvBashUpgradeAllowance = lvLethalUpgradeAllowance - lvLethal;

            switch (pvDamageType)
            {
                case Global.DamageType.Bash:
                    while (pvDamage > 0)
                    {
                        if (lvTotal < lvHealth)
                        {
                            lvBash++;
                            lvTotal++;
                        }
                        else if (lvBashUpgradeAllowance > 0)
                        {
                            lvBash--;
                            lvLethal++;
                        }
                        else
                        {
                            lvLethal--;
                            lvAggravated++;
                        }
                        pvDamage--;
                    }
                break;
                case Global.DamageType.Lethal:
                    while (pvDamage > 0)
                    {
                        if (lvTotal < lvHealth)
                        {
                            lvLethal++;
                            lvTotal++;
                        }
                        else if (lvLethalUpgradeAllowance > 0)
                        {
                            lvLethal--;
                            lvAggravated++;

                            if (lvBash > 1 && lvTotal > lvHealth)
                            {
                                lvBash--;
                            }
                        }
                        pvDamage--;
                    }
                break;
                case Global.DamageType.Aggravated:
                    while (pvDamage > 0)
                    {
                        if (lvTotal < lvHealth)
                        {
                            lvAggravated++;
                            lvTotal++;

                            if (lvLethal > 1 && lvTotal > lvHealth)
                            {
                                lvLethal--;
                            }
                            else if (lvBash > 1 && lvTotal > lvHealth)
                            {
                                lvBash--;
                            }
                        }
                        pvDamage--;
                    }
                break;
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);

            xDoc.SelectSingleNode("Character/Attributes/Health/Bash").InnerText = lvBash.ToString();
            xDoc.SelectSingleNode("Character/Attributes/Health/Lethal").InnerText = lvLethal.ToString();
            xDoc.SelectSingleNode("Character/Attributes/Health/Aggravated").InnerText = lvAggravated.ToString();

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();

            //TODO: Add notification to Combat chat box
            UpdateCombatXml();
        }        

        public static void Heal(int pvHealPoints, string pvXml, bool pvFull)
        {
            XPathDocument xPathDoc = new XPathDocument(pvXml);
            XPathNavigator xPathNav = xPathDoc.CreateNavigator();

            int lvBash = xPathNav.SelectSingleNode("Character/Attributes/Health/Bash").ValueAsInt;
            int lvLethal = xPathNav.SelectSingleNode("Character/Attributes/Health/Lethal").ValueAsInt;
            int lvAggravated = xPathNav.SelectSingleNode("Character/Attributes/Health/Aggravated").ValueAsInt;

            if (pvFull)
            {
                lvBash = 0;
                lvLethal = 0;
                lvAggravated = 0;
            }
            else
            {
                while (pvHealPoints > 0)
                {
                    if (lvBash > 0)
                        lvBash--;
                    else if (lvLethal > 0)
                        lvLethal--;
                    else if (lvAggravated > 0)
                        lvAggravated--;
                    pvHealPoints--;
                }
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);

            xDoc.SelectSingleNode("Character/Attributes/Health/Bash").InnerText = lvBash.ToString();
            xDoc.SelectSingleNode("Character/Attributes/Health/Lethal").InnerText = lvLethal.ToString();
            xDoc.SelectSingleNode("Character/Attributes/Health/Aggravated").InnerText = lvAggravated.ToString();

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();

            //TODO: Add notification to Combat chat box
            UpdateCombatXml();
        }

        public static void RestoreWill(int WillPoints, string pvXml, bool pvFull)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);

            if (pvFull)
            {
                xDoc.SelectSingleNode("Character/Attributes/Willpower/Current").InnerText = xDoc.SelectSingleNode("Character/Attributes/Willpower/Max").InnerText;
            }
            else
            {
                int currentWill = Convert.ToInt32(xDoc.SelectSingleNode("Character/Attributes/Willpower/Current").InnerText);

                xDoc.SelectSingleNode("Character/Attributes/Willpower/Current").InnerText = Convert.ToString(currentWill + WillPoints);
            }

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();

            //TODO: Add notification to Combat chat box
            UpdateCombatXml();
        }

        public static void SpendWill(int WillPoints, string pvXml)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);

            int currentWill = Convert.ToInt32(xDoc.SelectSingleNode("Character/Attributes/Willpower/Current").InnerText);

            xDoc.SelectSingleNode("Character/Attributes/Willpower/Current").InnerText = Convert.ToString(currentWill - WillPoints);

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();

            //TODO: Add notification to Combat chat box
            UpdateCombatXml();
        }

        public static void AddRemoveStatus(string pvStatusName, string pvXml)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);
            var xNode = xDoc.SelectSingleNode(String.Format("Character/Statuses/Status[text()='{0}']", pvStatusName));

            if (xNode != null)
            {
                xNode.ParentNode.RemoveChild(xNode);
            }
            else
            {
                XmlElement xElement = xDoc.CreateElement("Status");
                xElement.InnerText = pvStatusName;

                XmlNode xStatusesNode = xDoc.SelectSingleNode("Character/Statuses");
                xStatusesNode.InsertAfter(xElement, xStatusesNode.LastChild);
            }

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();

            //TODO: Add notification to Combat chat box
            UpdateCombatXml();
        }

        private static void UpdateCombatXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.CombatXml);

            xDoc.SelectSingleNode("Combat/@Rand").Value = Guid.NewGuid().ToString();

            FileStream lvFS = new FileStream(Global.CombatXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void GrantExperience(int pvExperience, string pvXml)
        {
            Player.Experience += pvExperience;
            ChatboxMessages.PlayerRewardedExperience(Player.Name, pvExperience);
        }

        public static void AddItemToCharacter(string pvItemName, string pvItemType, string pvID, int pvValue = 0)
        {
            if (Global._UserState == Global.UserState.Player)
            {
                AddItem(pvItemName, pvItemType, pvID, Player.Name, pvValue);
            }
        }

        public static void AddItemToCharacter(string pvItemName, string pvItemType, string pvID, string pvPlayerName, int pvValue = 0)
        {
            AddItem(pvItemName, pvItemType, pvID, pvPlayerName, pvValue);            
        }

        //Also handles spending money
        private static void AddItem(string pvItemName, string pvItemType, string pvID, string pvPlayerName, int pvValue)
        {
            string lvCharXml = Global.CharacterFolder + String.Format(@"\{0}.xml", pvPlayerName);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(lvCharXml);

            switch (pvItemType)
            {
                case "Item":
                    XmlElement iElement = xDoc.CreateElement("Item");
                    PopulateElement(pvItemName, pvID, xDoc, iElement);

                    XmlNode iItemNode = xDoc.SelectSingleNode("Character/Equipment/Items");
                    iItemNode.InsertAfter(iElement, iItemNode.LastChild);
                    Global.PlaySound(Global.Sound_Ring, false);
                    ChatboxMessages.PlayerAcquiredItem(pvPlayerName, pvItemName);
                    break;
                case "Weapon":
                    XmlElement wElement = xDoc.CreateElement("Weapon");
                    PopulateElement(pvItemName, pvID, xDoc, wElement);

                    XmlNode wItemNode = xDoc.SelectSingleNode("Character/Equipment/Weapons");
                    wItemNode.InsertAfter(wElement, wItemNode.LastChild);
                    Global.PlaySound(Global.Sound_Grab, false);
                    ChatboxMessages.PlayerAcquiredItem(pvPlayerName, pvItemName);
                    break;
                case "Armor":
                    XmlElement aElement = xDoc.CreateElement("Armor");
                    PopulateElement(pvItemName, pvID, xDoc, aElement);

                    XmlNode aItemNode = xDoc.SelectSingleNode("Character/Equipment/Armors");
                    aItemNode.InsertAfter(aElement, aItemNode.LastChild);
                    Global.PlaySound(Global.Sound_Leather, false);
                    ChatboxMessages.PlayerAcquiredItem(pvPlayerName, pvItemName);
                    break;
                case "Cash":
                    XmlNode cashNode = xDoc.SelectSingleNode("Character/Equipment/Cash");
                    cashNode.InnerText = Convert.ToString(Convert.ToInt32(cashNode.InnerText) + pvValue);
                    Global.PlaySound(Global.Sound_Money, false);
                    if (pvValue > 0)
                        ChatboxMessages.PlayerAcquiredCash(pvPlayerName, pvValue);
                    else
                        ChatboxMessages.PlayerSpentLostCash(pvPlayerName, pvValue);
                    break;
                default:
                    break;
            }

            while (Global.IsFileLocked(Global.NotificationXml))
                Thread.Sleep(1000);
            FileStream lvFS = new FileStream(lvCharXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void RemoveItemFromCharacter(string pvItemName, string pvID, string pvPlayerName)
        {
            RemoveItem(pvItemName, pvID, pvPlayerName);
        }

        private static void RemoveItem(string pvItemName, string pvID, string pvPlayerName)
        {
            string lvCharXml = Global.CharacterFolder + String.Format(@"\{0}.xml", pvPlayerName);
            bool lvFound = false;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(lvCharXml);

            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Character/Equipment");
            XPathNodeIterator xNodeIter = xNav.SelectChildren(XPathNodeType.All);

            while (xNodeIter.MoveNext())
            {
                if (lvFound)
                    break;

                XPathNodeIterator xTypeIter = xNodeIter.Current.SelectChildren(XPathNodeType.All);

                while (xTypeIter.MoveNext())
                {
                    if (xTypeIter.Current.SelectSingleNode("@ID") != null && xTypeIter.Current.SelectSingleNode("@ID").Value.ToLower() == pvID)
                    {
                        xTypeIter.Current.DeleteSelf();
                        lvFound = true;
                        break;
                    }
                }               
            }

            ChatboxMessages.PlayerRemoveLostItem(pvPlayerName, pvItemName);

            while (Global.IsFileLocked(lvCharXml))
                Thread.Sleep(1000);
            FileStream lvFS = new FileStream(lvCharXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        private static void PopulateElement(string pvItemName, string pvID, XmlDocument xDoc, XmlElement iElement)
        {
            XmlAttribute iName = xDoc.CreateAttribute("Name");
            iName.Value = pvItemName;
            iElement.Attributes.Append(iName);
            XmlAttribute iID = xDoc.CreateAttribute("ID");
            iID.Value = pvID;
            iElement.Attributes.Append(iID);
            XmlAttribute iEquipped = xDoc.CreateAttribute("Equipped");
            iEquipped.Value = "false";
            iElement.Attributes.Append(iEquipped);
        }

        public static void EquipUnequipItem(string pvName, bool pvEquip)
        {
            XmlDocument xDocument = new XmlDocument();
            xDocument.Load(Properties.Settings.Default.DataLocation + "Characters/" + Player.Name + ".xml");

            if (xDocument.SelectSingleNode("Character/Equipment/Items/Item[@ID = '" + pvName + "']") != null)
            {
                xDocument.SelectSingleNode("Character/Equipment/Items/Item[@ID = '" + pvName + "']/@Equipped")
                    .Value = pvEquip.ToString().ToLower();
            }
            if (xDocument.SelectSingleNode("Character/Equipment/Weapons/Weapon[@ID = '" + pvName + "']") != null)
            {
                xDocument.SelectSingleNode("Character/Equipment/Weapons/Weapon[@ID = '" + pvName +
                                           "']/@Equipped").Value = pvEquip.ToString().ToLower();
            }
            if (xDocument.SelectSingleNode("Character/Equipment/Armors/Armor[@ID = '" + pvName + "']") != null)
            {
                xDocument.SelectSingleNode("Character/Equipment/Armors/Armor[@ID = '" + pvName + "']/@Equipped")
                    .Value = pvEquip.ToString().ToLower();
            }

            FileStream lvFS =
                new FileStream(Properties.Settings.Default.DataLocation + "Characters/" + Player.Name + ".xml",
                    FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDocument.Save(lvFS);
            lvFS.Close();
        }

        public static void ManageAmmo(string pvXml, string pvWeaponId, int pvAmmo)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);
            var xNode = xDoc.SelectSingleNode(String.Format("Character/Equipment/Weapons/Weapon[@ID='{0}']/Capacity/Current", pvWeaponId));            

            if (xNode != null)
            {
                xNode.InnerText = (Convert.ToInt32(xNode.InnerText) + pvAmmo).ToString();
            }
            else
            {
                //TODO: Exception
            }

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void UpdatePlayerForm(string pvXml, string pvForm)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);
            var xNode = xDoc.SelectSingleNode("Character/Form");
            xNode.InnerText = pvForm;

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void AddBoost(string pvXml, string pvSource, string pvRealm, string pvName, string pvValue)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);
            var xNode = xDoc.SelectSingleNode("Character/Boost");

            XmlElement xElement = xDoc.CreateElement(pvName);
            xElement.InnerText = pvValue;
            XmlAttribute xAttr = xDoc.CreateAttribute("Source");
            xAttr.InnerText = pvSource;
            XmlAttribute xRealmAttr = xDoc.CreateAttribute("Realm");
            xRealmAttr.InnerText = pvRealm;
            xElement.Attributes.Append(xAttr);
            xElement.Attributes.Append(xRealmAttr);

            xNode.InsertAfter(xElement, xNode.LastChild);

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void RemoveBoosts(string pvXml, string pvSource)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pvXml);
            var xNode = xDoc.SelectSingleNode("Character/Boost");

            xNode.RemoveAll();

            FileStream lvFS = new FileStream(pvXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }
    }
}
