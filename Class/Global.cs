using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class
{
    public static class Global
    {
        public static readonly string CombatFolder = Properties.Settings.Default.DataLocation + @"Active\Combat\";
        public static readonly string CombatXml = Properties.Settings.Default.DataLocation + @"Active\Combat\Combat.xml";        
        public static readonly string ActiveCharacterXml = Properties.Settings.Default.DataLocation + @"Active\Characters\Characters.xml";
        public static readonly string ChatFolder = Properties.Settings.Default.DataLocation + @"Active\Chat";
        public static readonly string ChatFile = Properties.Settings.Default.DataLocation + @"Active\Chat\General.txt";
        public static readonly string CombatChatFile = Properties.Settings.Default.DataLocation + @"Active\Chat\Combat.txt";
        public static readonly string MapFolder = Properties.Settings.Default.DataLocation + @"Active\Map";
        public static readonly string StoreXml = Properties.Settings.Default.DataLocation + @"Active\Store\Store.xml";
        public static readonly string StoreFolder = Properties.Settings.Default.DataLocation + @"Active\Store\";
        public static readonly string LootXml = Properties.Settings.Default.DataLocation + @"Active\Loot\Loot.xml";
        public static readonly string LootFolder = Properties.Settings.Default.DataLocation + @"Active\Loot\";
        public static readonly string NotificationXml = Properties.Settings.Default.DataLocation + @"Active\Notifications\Notifications.xml";
        public static readonly string NotificationFolder = Properties.Settings.Default.DataLocation + @"Active\Notifications\";
        public static readonly string CharacterFolder = Properties.Settings.Default.DataLocation + @"Characters\";
        public static readonly string CharacterImageFolder = Properties.Settings.Default.DataLocation + @"Character_Images\";
        public static readonly string NpcFolder = Properties.Settings.Default.DataLocation + @"NPC\";
        public static readonly string NpcImageFolder = Properties.Settings.Default.DataLocation + @"NPC_Images\";
        public static readonly string StatusXml = Properties.Settings.Default.DataLocation + @"Lists\Statuses.xml";        
        public static readonly string ItemImagesFolder = Properties.Settings.Default.DataLocation + @"Item_Images\";
        public static readonly string ItemXml = Properties.Settings.Default.DataLocation + @"Lists\Item.xml";
        public static readonly string SoundFolder = Properties.Settings.Default.DataLocation + @"Sounds\";
        public static readonly string MeritXml = Properties.Settings.Default.DataLocation + @"Lists\Merits.xml";
        public static readonly string ActionsXml = Properties.Settings.Default.DataLocation + @"Lists\Actions.xml"; 
        public static readonly string VehicleXml = Properties.Settings.Default.DataLocation + @"Lists\Vehicle.xml";
        public static readonly string CovenantXml = Properties.Settings.Default.DataLocation + @"Lists\Covenants.xml";
        public static readonly string DamageXml = Properties.Settings.Default.DataLocation + @"Lists\Damages.xml";
        public static readonly string FormXml = Properties.Settings.Default.DataLocation + @"Lists\Forms.xml";
        public static readonly string DerangementXml = Properties.Settings.Default.DataLocation + @"Lists\Derangements.xml";
        public static readonly string FlawXml = Properties.Settings.Default.DataLocation + @"Lists\Flaws.xml";
        public static readonly string ViceXml = Properties.Settings.Default.DataLocation + @"Lists\Vices.xml";
        public static readonly string VirtueXml = Properties.Settings.Default.DataLocation + @"Lists\Virtues.xml";
        public static readonly string RuleXml = Properties.Settings.Default.DataLocation + @"Lists\Rules.xml";
        public static System.Media.SoundPlayer MediaPlayer = new System.Media.SoundPlayer();

        public static readonly string Sound_Break = "Break.wav";
        public static readonly string Sound_Reload = "Reload.wav";
        public static readonly string Sound_Equip = "Equip.wav";
        public static readonly string Sound_Keys = "Keys.wav";
        public static readonly string Sound_Leather = "Leather.wav";
        public static readonly string Sound_Ring = "Ring.wav";
        public static readonly string Sound_Money = "Money.wav";
        public static readonly string Sound_Grab = "Grab.wav";
        public static readonly string Sound_Scary = "Scary.wav";
        public static readonly string Sound_Dice = "RollDice.wav";
        public static readonly string Music_Theme = "Theme.wav";
        
        public static GMForm GameManagerForm;
        public static frmVisualator PlayerForm;
        public static Load LoadForm = new Load();
        public static CustomForm CustomForm;

        public static Vampire.Vampire Vampire = new Vampire.Vampire();
        public static Werewolf.Werewolf Werewolf = new Werewolf.Werewolf();
        public static Mage.Mage Mage = new Mage.Mage();
        public static Hunter.Hunter Hunter = new Hunter.Hunter();
        public static Human.Human Human = new Human.Human();
        public static Possessed.Possessed Possessed = new Possessed.Possessed();

        public static string ActorID { get; set; }

        public static string SelectedActorID { get; set; }

        public static CharType SelectedActorType { get; set; }

        public static UserState _UserState;

        public enum UserState
        {
            Player,
            GM
        }

        public static DamageType _DamageType;

        public enum DamageType
        {
            Bash,
            Lethal,
            Aggravated
        }

        public enum CharType
        {
            NPC,
            Character
        }

        public enum Template
        {
            Human,
            Vampire,
            Werewolf,
            Mage,
            Hunter,
            Possessed
        }

        public enum Gender
        {
            Male,
            Female,
            Nondescript
        }

        public static void PlaySound(string pvTrack, bool pvLoop)
        {
            if (Properties.Settings.Default.PlaySounds)
            {
                MediaPlayer.SoundLocation = SoundFolder + pvTrack;
                if (pvLoop)
                    MediaPlayer.PlayLooping();
                else
                    MediaPlayer.Play();
            }
        }

        public static void StopSound()
        {
            MediaPlayer.Stop();
        }

        public static void AddActiveCharacter(string pvName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(ActiveCharacterXml);

            XmlElement xElement = xDoc.CreateElement("Character");
            XmlAttribute xName = xDoc.CreateAttribute("Name");
            xName.Value = pvName;
            XmlAttribute xUpdate = xDoc.CreateAttribute("Update");
            xUpdate.Value = string.Empty;

            xElement.Attributes.Append(xName);
            xElement.Attributes.Append(xUpdate);

            XmlNode xRootNode = xDoc.SelectSingleNode("Characters");
            xRootNode.InsertAfter(xElement, xRootNode.LastChild);

            FileStream lvFS = new FileStream(ActiveCharacterXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void RemoveActiveCharacter(string pvName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(ActiveCharacterXml);

            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Characters/Character[@Name='" + pvName + "']");
            xNav.DeleteSelf();

            FileStream lvFS = new FileStream(ActiveCharacterXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void AddCombatActor(string pvName, string pvType)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(CombatXml);

            XmlElement xElement = xDoc.CreateElement("Entity");
            XmlAttribute xName = xDoc.CreateAttribute("Name");                                 
            XmlAttribute xID = xDoc.CreateAttribute("ID");
            XmlAttribute xOrder = xDoc.CreateAttribute("Order");
            XmlAttribute xType = xDoc.CreateAttribute("Type");
            xName.Value = pvName;

            if (pvType == "NPC")
            {
                Guid npcGuid = Guid.NewGuid();
                File.Copy(NpcFolder + pvName + ".xml", CombatFolder + npcGuid + ".xml");
                xID.Value = npcGuid.ToString();
                xType.Value = pvType;
            }
            else
            {
                xID.Value = pvName;
                xType.Value = pvType;
            }

            DirectoryInfo di = new DirectoryInfo(CombatFolder);
            FileInfo[] files = di.GetFiles();

            xOrder.Value = Convert.ToString(files.Length - 2);            
            xElement.Attributes.Append(xName);
            xElement.Attributes.Append(xID);
            xElement.Attributes.Append(xOrder);
            xElement.Attributes.Append(xType);

            XPathDocument charDocument;
            XPathNavigator charNav;

            if (pvType == "NPC")
            {
                charDocument = new XPathDocument(NpcFolder + pvName + ".xml");
                charNav = charDocument.CreateNavigator();
                ChatboxMessages.CombatAddCombatant(pvName);
            }
            else
            {
                charDocument = new XPathDocument(CharacterFolder + pvName + ".xml");
                charNav = charDocument.CreateNavigator();
            }           

            XmlNode xRootNode = xDoc.SelectSingleNode("Combat");
            xRootNode.InsertAfter(xElement, xRootNode.LastChild);

            FileStream lvFS = new FileStream(CombatXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void RemoveCombatActor(string pvID, CharType pvType)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(CombatXml);

            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Combat/Entity[@ID='" + pvID + "']");
            xNav.DeleteSelf();

            FileStream lvFS = new FileStream(CombatXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();

            if (pvType == CharType.NPC)
            {
                //TODO
            }
        }

        public static void AddLootItem(string pvName, int pvSize, int pvValue, string pvImage, string pvType)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(LootXml);

            XmlElement xElement = xDoc.CreateElement("Item");
            XmlAttribute xName = xDoc.CreateAttribute("Name");
            XmlAttribute xID = xDoc.CreateAttribute("ID");
            XmlAttribute xSize = xDoc.CreateAttribute("Size");
            XmlAttribute xValue = xDoc.CreateAttribute("Value");
            XmlAttribute xImage = xDoc.CreateAttribute("Image");
            XmlAttribute xType = xDoc.CreateAttribute("Type");

            xName.Value = pvName;
            xSize.Value = pvSize.ToString();
            xValue.Value = pvValue.ToString();
            xImage.Value = pvImage;
            Guid itemGuid = Guid.NewGuid();
            xID.Value = itemGuid.ToString();
            xType.Value = pvType;

            xElement.Attributes.Append(xName);
            xElement.Attributes.Append(xID);
            xElement.Attributes.Append(xSize);
            xElement.Attributes.Append(xValue);
            xElement.Attributes.Append(xImage);
            xElement.Attributes.Append(xType);

            XmlNode xRootNode = xDoc.SelectSingleNode("Items");
            xRootNode.InsertAfter(xElement, xRootNode.LastChild);

            FileStream lvFS = new FileStream(LootXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();

            GameManagerForm.ChatBox("New loot has been dropped.", "", (int)RtfHelper.FontColorEnum.Yellow, (int)RtfHelper.FontColorEnum.Yellow);
        }

        public static void RemoveLootItem(string pvID)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(LootXml);

            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Items/Item[@ID='" + pvID + "']");
            xNav.DeleteSelf();

            FileStream lvFS = new FileStream(LootXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void RemoveAllLootItems()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(LootXml);
            XmlNode xNode = xDoc.DocumentElement;

            xNode.RemoveAll();

            FileStream lvFS = new FileStream(LootXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        public static void ShowLoadForm()
        {            
            LoadForm.TopMost = true;
            LoadForm.StartPosition = FormStartPosition.CenterScreen;
            LoadForm.Show();
            LoadForm.Refresh();

            System.Threading.Thread.Sleep(700);
            Application.Idle += OnLoaded;
        }

        private static void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            LoadForm.Hide();
        }

        public static void CloseLoadForm()
        {
            LoadForm.Hide();
        }

        public static Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        public static bool IsFileLocked(string file)
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
