using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.XPath;
using System.Configuration;
using System.Threading;
using Pen_and_Paper_Visualator.Class;
using System.Xml;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class Combat : UserControl
    {        
        private string cvInitDisplayDragParent;

        private readonly int cvControlHeight = 169;
        private readonly int cvControlWidth = 190;
        private int cvControlTop = 0;
        private int cvControlLeft = 25;
        private int cvControlCount = 0;

        public Combat()
        {
            string[] files = Directory.GetFiles(Global.CombatFolder, "Combat.xml");
            while (IsFileLocked(files[0]))
                Thread.Sleep(1000);
            XPathDocument lvCombatXml = new XPathDocument(Global.CombatXml);
            XPathNavigator lvNav = lvCombatXml.CreateNavigator();
            XPathExpression exp = lvNav.Compile("Combat/Entity");
            exp.AddSort("@Order", XmlSortOrder.Ascending, XmlCaseOrder.UpperFirst, "en-US", XmlDataType.Number);

            XPathNodeIterator lvNodeIter = lvNav.Select(exp);

            while (lvNodeIter.MoveNext())
            {
                string lvID = lvNodeIter.Current.SelectSingleNode("@ID").Value;
                string lvType = lvNodeIter.Current.SelectSingleNode("@Type").Value;

                XPathDocument lvActorXml;

                if (lvType == "NPC")
                {
                    lvActorXml = new XPathDocument(Global.CombatFolder + lvID + ".xml");
                    InitDisplay.DisplayType = Global.CharType.NPC;
                }
                else
                {
                    lvActorXml = new XPathDocument(Global.CharacterFolder + lvID + ".xml");
                    InitDisplay.DisplayType = Global.CharType.Character;
                }
                XPathNavigator lvActorNav = lvActorXml.CreateNavigator();
                XPathNodeIterator nodeIter;

                InitDisplay.CharName = lvActorNav.SelectSingleNode("Character/Background/Name").Value;
                InitDisplay.Type = lvActorNav.SelectSingleNode("Character/Background/Type").Value;
                InitDisplay.ID = lvID;
                InitDisplay.Health = lvActorNav.SelectSingleNode("Character/Attributes/Health/Max").ValueAsInt;
                InitDisplay.Bash = lvActorNav.SelectSingleNode("Character/Attributes/Health/Bash").ValueAsInt;
                InitDisplay.Lethal = lvActorNav.SelectSingleNode("Character/Attributes/Health/Lethal").ValueAsInt;
                InitDisplay.Aggravated = lvActorNav.SelectSingleNode("Character/Attributes/Health/Aggravated").ValueAsInt;
                InitDisplay.WillpowerMax = lvActorNav.SelectSingleNode("Character/Attributes/Willpower/Max").ValueAsInt;
                InitDisplay.WillpowerCurrent = lvActorNav.SelectSingleNode("Character/Attributes/Willpower/Current").ValueAsInt;
                InitDisplay.Image = lvActorNav.SelectSingleNode("Character/Image").Value;

                nodeIter = lvActorNav.Select("Character/Statuses/Status");
                InitDisplay.Status.Clear();
                while (nodeIter.MoveNext())
                {
                    InitDisplay.Status.Add(nodeIter.Current.Value);
                }

                InitDisplay lvActor = new InitDisplay();

                lvActor.DragDrop += Combat_DragDrop;

                if (cvControlCount > 0 && cvControlCount % 3 == 0)
                {
                    cvControlTop += cvControlHeight + 2;
                    cvControlLeft = 25;
                }

                lvActor.Top = cvControlTop;
                lvActor.Left = cvControlLeft;

                this.Controls.Add(lvActor);

                cvControlLeft += cvControlWidth + 25;
                cvControlCount++;
            }
        }

        protected virtual bool IsFileLocked(string file)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void Combat_DragDrop(object sender, DragEventArgs e)
        {
            InitDisplay iDisplay = new InitDisplay();
            iDisplay = (sender as InitDisplay);
            cvInitDisplayDragParent = InitDisplay.ID;

            if (cvInitDisplayDragParent != null && Global.ActorID != null && cvInitDisplayDragParent != Global.ActorID)
            {               
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Global.CombatXml);
                XmlNodeList xNodes = xDoc.SelectNodes("Combat/Entity");

                int lvChildOrder = Convert.ToInt32(xDoc.SelectSingleNode(@"Combat/Entity[@ID='" + Global.ActorID + "']/@Order").Value);
                int lvParentOrder = Convert.ToInt32(xDoc.SelectSingleNode(@"Combat/Entity[@ID='" + cvInitDisplayDragParent + "']/@Order").Value);

                foreach (XmlNode xNode in xNodes)
                {
                    XmlNode xOrderNode = xNode.SelectSingleNode("@Order");
                    int xOrderInt = Convert.ToInt32(xOrderNode.Value);

                    if (xOrderInt > lvParentOrder && xOrderInt < lvChildOrder)
                    {
                        xOrderNode.Value = (Convert.ToInt32(xOrderNode.Value) - 1).ToString();
                    }
                    else if (xOrderInt >= lvChildOrder)
                    {
                        xOrderNode.Value = (Convert.ToInt32(xOrderNode.Value) + 1).ToString();
                    }
                }

                XmlNode xParent = xDoc.SelectSingleNode("Combat/Entity[@ID='" + cvInitDisplayDragParent + "']");
                xParent.Attributes["Order"].Value = lvChildOrder.ToString();

                FileStream lvFS = new FileStream(Global.CombatXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                xDoc.Save(lvFS);
                lvFS.Close();

                Global.ActorID = null;
            }
        }
    }
}
