using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;
using System.Threading;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class ActivePlayersTab : UserControl
    {
        private readonly FileSystemWatcher characterWatcher = new FileSystemWatcher();

        public ActivePlayersTab()
        {
            InitializeComponent();

            if (String.IsNullOrEmpty(characterWatcher.Path))
            {
                characterWatcher.Path = Global.CharacterFolder;
                characterWatcher.NotifyFilter = NotifyFilters.LastWrite;
                characterWatcher.Filter = "*.xml";
                characterWatcher.Changed += new FileSystemEventHandler(characterFolder_Changed);
                characterWatcher.EnableRaisingEvents = true;
            }           

            RetrieveCharacter();
        }

        private void RetrieveCharacter()
        {
            bool lvInvoke = false;
            try
            {
                foreach (Control lvControl in this.Controls)
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        this.Controls.Remove(lvControl);
                    });
                    lvInvoke = true;
                }
            }
            catch (Exception ex) { }

            XPathDocument lvActiveCharXml = new XPathDocument(Global.ActiveCharacterXml);
            XPathNavigator lvActiveNav = lvActiveCharXml.CreateNavigator();
            XPathNodeIterator lvActiveNodeIter = lvActiveNav.Select("Characters/Character");

            int yPosition = 0;

            while (lvActiveNodeIter.MoveNext())
            {
                while (IsFileLocked(Global.CharacterFolder + String.Format(@"{0}.xml", lvActiveNodeIter.Current.SelectSingleNode("@Name").Value)))
                    Thread.Sleep(1000);
                XPathDocument lvCharXml = new XPathDocument(Global.CharacterFolder + String.Format(@"{0}.xml", lvActiveNodeIter.Current.SelectSingleNode("@Name").Value));
                XPathNavigator nav = lvCharXml.CreateNavigator();
                XPathNodeIterator nodeIter;

                CharDisplay.CharName = nav.SelectSingleNode("Character/Background/Name").Value;
                CharDisplay.Type = nav.SelectSingleNode("Character/Background/Type").Value;
                CharDisplay.Health = nav.SelectSingleNode("Character/Attributes/Health/Max").ValueAsInt;
                CharDisplay.Bash = nav.SelectSingleNode("Character/Attributes/Health/Bash").ValueAsInt;
                CharDisplay.Lethal = nav.SelectSingleNode("Character/Attributes/Health/Lethal").ValueAsInt;
                CharDisplay.Aggravated = nav.SelectSingleNode("Character/Attributes/Health/Aggravated").ValueAsInt;
                CharDisplay.WillpowerMax = nav.SelectSingleNode("Character/Attributes/Willpower/Max").ValueAsInt;
                CharDisplay.WillpowerCurrent = nav.SelectSingleNode("Character/Attributes/Willpower/Current").ValueAsInt;
                CharDisplay.Image = nav.SelectSingleNode("Character/Image").Value;
                CharDisplay.DisplayType = Global.CharType.Character;

                nodeIter = nav.Select("Character/Statuses/Status");

                while (nodeIter.MoveNext())
                {
                    CharDisplay.Status.Add(nodeIter.Current.Value);
                }

                CharDisplay lvChar = new CharDisplay();
                lvChar.Location = new Point(10, yPosition);

                yPosition += 276;

                if (lvInvoke)
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        this.Controls.Add(lvChar);
                    });
                }
                else
                {
                    this.Controls.Add(lvChar);
                }
            }

            //string[] files = Directory.GetFiles(Global.CharacterFolder, "*.xml");
            //int yPosition = 0;

            //foreach (string file in files)
            //{
            //    XPathDocument lvCharXml = new XPathDocument(file);
            //    XPathNavigator nav = lvCharXml.CreateNavigator();
            //    XPathNodeIterator nodeIter;

            //    CharDisplay.CharName = nav.SelectSingleNode("Character/Background/Name").Value;
            //    CharDisplay.Type = nav.SelectSingleNode("Character/Background/Type").Value;
            //    CharDisplay.Health = nav.SelectSingleNode("Character/Attributes/Health/Max").ValueAsInt;
            //    CharDisplay.Bash = nav.SelectSingleNode("Character/Attributes/Health/Bash").ValueAsInt;
            //    CharDisplay.Lethal = nav.SelectSingleNode("Character/Attributes/Health/Lethal").ValueAsInt;
            //    CharDisplay.Aggravated = nav.SelectSingleNode("Character/Attributes/Health/Aggravated").ValueAsInt;
            //    CharDisplay.Willpower = nav.SelectSingleNode("Character/Attributes/Willpower/Max").ValueAsInt;
            //    CharDisplay.Image = nav.SelectSingleNode("Character/Image").Value;
            //    CharDisplay.DisplayType = Global.CharType.Character;

            //    nodeIter = nav.Select("Character/Statuses/Status");

            //    while (nodeIter.MoveNext())
            //    {
            //        CharDisplay.Status.Add(nodeIter.Current.Value);
            //    }

            //    CharDisplay lvChar = new CharDisplay();
            //    lvChar.Location = new Point(10, yPosition);

            //    yPosition += 180;

            //    if (lvInvoke)
            //    {
            //        Invoke((MethodInvoker)delegate()
            //        {
            //            this.Controls.Add(lvChar);
            //        });
            //    }
            //    else
            //    {
            //        this.Controls.Add(lvChar);
            //    }               
            //}
        }

        private void characterFolder_Changed(object sender, FileSystemEventArgs e)
        {
            RetrieveCharacter();
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
    }
}
