using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;

namespace Pen_and_Paper_Visualator.Class
{   
    class Notification<T>
    {        
        private Type _Type;

        public enum Type
        {
            RequestPurchase,
            RequestSell,
            RequestTrade
        }

        public void PublishNotification(T t, Type lvType)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.NotificationXml);
            XmlNode xRootNode = xDoc.SelectSingleNode("Notifications");
            XmlElement xElement;

            switch (lvType)
            {
                case Type.RequestPurchase:
                    TradeObject lvBuyTO = t as TradeObject;
                    xElement = xDoc.CreateElement("RequestPurchase");

                    XmlAttribute xBuyName = xDoc.CreateAttribute("Item");
                    xBuyName.Value = lvBuyTO.itemName;
                    xElement.Attributes.Append(xBuyName);
                    XmlAttribute xBuyCost = xDoc.CreateAttribute("Cost");
                    xBuyCost.Value = lvBuyTO.itemCost.ToString();
                    xElement.Attributes.Append(xBuyCost);
                    XmlAttribute xBuyChar = xDoc.CreateAttribute("Character");
                    xBuyChar.Value = lvBuyTO.character;
                    xElement.Attributes.Append(xBuyChar);
                    XmlAttribute xBuyType = xDoc.CreateAttribute("Type");
                    xBuyType.Value = lvBuyTO.itemType;
                    xElement.Attributes.Append(xBuyType);
                    XmlAttribute xBuyID = xDoc.CreateAttribute("ID");
                    xBuyID.Value = lvBuyTO.itemID.ToString();
                    xElement.Attributes.Append(xBuyID);
                    XmlElement xBuyMessage = xDoc.CreateElement("Message");
                    xBuyMessage.InnerText = lvBuyTO.message;
                    xElement.InsertAfter(xBuyMessage, xElement.LastChild);
                    xRootNode.InsertAfter(xElement, xRootNode.LastChild);
                    break;
                case Type.RequestSell:
                    TradeObject lvSellTO = t as TradeObject;
                    xElement = xDoc.CreateElement("RequestSell");

                    XmlAttribute xSellName = xDoc.CreateAttribute("Item");
                    xSellName.Value = lvSellTO.itemName;
                    xElement.Attributes.Append(xSellName);
                    XmlAttribute xSellCost = xDoc.CreateAttribute("Cost");
                    xSellCost.Value = lvSellTO.itemCost.ToString();
                    xElement.Attributes.Append(xSellCost);
                    XmlAttribute xSellChar = xDoc.CreateAttribute("Character");
                    xSellChar.Value = lvSellTO.character;
                    xElement.Attributes.Append(xSellChar);
                    XmlAttribute xSellType = xDoc.CreateAttribute("Type");
                    xSellType.Value = lvSellTO.itemType;
                    xElement.Attributes.Append(xSellType);
                    XmlAttribute xSellID = xDoc.CreateAttribute("ID");
                    xSellID.Value = lvSellTO.itemID.ToString();
                    xElement.Attributes.Append(xSellID);
                    XmlElement xSellMessage = xDoc.CreateElement("Message");
                    xSellMessage.InnerText = lvSellTO.message;
                    xElement.InsertAfter(xSellMessage, xElement.LastChild);
                    xRootNode.InsertAfter(xElement, xRootNode.LastChild);
                    break;
                case Type.RequestTrade:
                    TradeObject lvTO = t as TradeObject;
                    xElement = xDoc.CreateElement("RequestTrade");

                    XmlElement xFirstPartyItems = xDoc.CreateElement("FirstParty");
                    XmlAttribute xFirstPartyName = xDoc.CreateAttribute("Name");
                    xFirstPartyName.Value = lvTO.firstParty;
                    xFirstPartyItems.Attributes.Append(xFirstPartyName);

                    foreach (Guid lvFirstGuid in lvTO.firstPartyItems)
                    {
                        XmlElement xItemGuidElement = xDoc.CreateElement("Item");
                        xItemGuidElement.InnerText = lvFirstGuid.ToString();
                        xFirstPartyItems.InsertAfter(xItemGuidElement, xFirstPartyItems.LastChild);
                    }
                    xElement.InsertAfter(xFirstPartyItems, xElement.LastChild);

                    XmlElement xSecondPartyItems = xDoc.CreateElement("SecondParty");
                    XmlAttribute xSecondPartyName = xDoc.CreateAttribute("Name");
                    xSecondPartyName.Value = lvTO.secondParty;
                    xSecondPartyItems.Attributes.Append(xSecondPartyName);

                    foreach (Guid lvSecondGuid in lvTO.firstPartyItems)
                    {
                        XmlElement xItemGuidElement = xDoc.CreateElement("Item");
                        xItemGuidElement.InnerText = lvSecondGuid.ToString();
                        xSecondPartyItems.InsertAfter(xItemGuidElement, xSecondPartyItems.LastChild);
                    }
                    xElement.InsertAfter(xFirstPartyItems, xElement.LastChild);

                    xRootNode.InsertAfter(xElement, xRootNode.LastChild);
                    break;
                default:
                    break;
            }

            FileStream lvFS = new FileStream(Global.NotificationXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }
    }

    class ItemBuyRequest
    {
        public ItemBuyRequest(string itemName, int itemCost, string playerName, string itemType)
        {
            string lvMessage = String.Format("{0} has requested to purchase a {1}, which has a default value of ${2}.", playerName, itemName, itemCost);

            TradeObject lvTO = new TradeObject();
            lvTO.character = playerName;
            lvTO.itemName = itemName;
            lvTO.itemCost = itemCost;
            lvTO.itemID = new Guid();
            lvTO.itemType = itemType;
            lvTO.message = lvMessage;

            Notification<TradeObject> notif = new Notification<TradeObject>();
            notif.PublishNotification(lvTO, Notification<TradeObject>.Type.RequestPurchase);
        }
    }

    class ItemSellRequest
    {
        public ItemSellRequest(string itemName, int itemCost, string playerName, Guid itemID, string itemType)
        {
            string lvMessage = String.Format("{0} has requested to sell a {1}, which has a default value of ${2}.", playerName, itemName, itemCost);

            TradeObject lvTO = new TradeObject();
            lvTO.character = playerName;
            lvTO.itemName = itemName;
            lvTO.itemCost = itemCost;
            lvTO.itemID = itemID;
            lvTO.itemType = itemType;
            lvTO.message = lvMessage;

            Notification<TradeObject> notif = new Notification<TradeObject>();
            notif.PublishNotification(lvTO, Notification<TradeObject>.Type.RequestSell);
        }
    }

    class TradeRequest
    {
        public TradeRequest(List<Guid> firstPartyItems, List<Guid> secondPartyItems, string firstPartyPlayerName, string secondPartyPlayerName)
        {
            string lvMessage = String.Format("{0} has requested to make a trade with you.", firstPartyPlayerName);

            TradeObject lvTO = new TradeObject();
            lvTO.firstParty = firstPartyPlayerName;
            lvTO.secondParty = secondPartyPlayerName;
            lvTO.firstPartyItems = firstPartyItems;
            lvTO.secondPartyItems = secondPartyItems;
            lvTO.message = lvMessage;

            Notification<TradeObject> notif = new Notification<TradeObject>();
            notif.PublishNotification(lvTO, Notification<TradeObject>.Type.RequestTrade);
        }
    }
}
