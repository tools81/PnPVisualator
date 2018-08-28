using System;
using System.Drawing;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Controls;
using System.IO;
using Pen_and_Paper_Visualator.Class;
using System.Configuration;
using System.Threading;
using System.Xml.XPath;
using System.Xml;
using Pen_and_Paper_Visualator.Controls.DisplayTypes;

namespace Pen_and_Paper_Visualator
{
    public partial class GMForm : System.Windows.Forms.Form
    {
        bool cvFormClosing = false;
        ChatTab cvChatAll = new ChatTab();
        CombatChatTab cvCombatChat = new CombatChatTab();
        CompendiumTab cvCompTab = new CompendiumTab();
        ReferenceTab cvReferenceTab = new ReferenceTab();
        Map cvMap = new Map();
        Combat cvCombat = new Combat();
        Loot cvLoot = new Loot();
        NotificationTab cvNotificationTab = new NotificationTab();
        internal static Control cvPanelSelected;

        FileSystemWatcher chatWatcher = new FileSystemWatcher();
        FileSystemWatcher combatChatWatcher = new FileSystemWatcher();
        FileSystemWatcher mapWatcher = new FileSystemWatcher();
        FileSystemWatcher combatWatcher = new FileSystemWatcher();
        FileSystemWatcher lootWatcher = new FileSystemWatcher();
        FileSystemWatcher storeWatcher = new FileSystemWatcher();
        FileSystemWatcher notificationWatcher = new FileSystemWatcher();

        public GMForm()
        {
            InitializeComponent();

            chatWatcher.Path = Global.ChatFolder;
            chatWatcher.NotifyFilter = NotifyFilters.LastWrite;
            chatWatcher.Filter = "General.txt";
            chatWatcher.Changed += new FileSystemEventHandler(txtChat_FileChanged);
            chatWatcher.EnableRaisingEvents = true;

            combatChatWatcher.Path = Global.ChatFolder;
            combatChatWatcher.NotifyFilter = NotifyFilters.LastWrite;
            combatChatWatcher.Filter = "Combat.txt";
            combatChatWatcher.Changed += new FileSystemEventHandler(txtCombatChat_FileChanged);
            combatChatWatcher.EnableRaisingEvents = true;

            mapWatcher.Path = Global.MapFolder;
            mapWatcher.NotifyFilter = NotifyFilters.LastWrite;
            mapWatcher.Filter = "*.*";
            mapWatcher.Changed += new FileSystemEventHandler(map_Changed);
            mapWatcher.EnableRaisingEvents = true;

            combatWatcher.Path = Global.CombatFolder;
            combatWatcher.NotifyFilter = NotifyFilters.LastWrite;
            combatWatcher.Filter = "Combat.xml";
            combatWatcher.Changed += new FileSystemEventHandler(combat_Changed);
            combatWatcher.EnableRaisingEvents = true;

            lootWatcher.Path = Global.LootFolder;
            lootWatcher.NotifyFilter = NotifyFilters.LastWrite;
            lootWatcher.Filter = "Loot.xml";
            lootWatcher.Changed += new FileSystemEventHandler(loot_Changed);
            lootWatcher.EnableRaisingEvents = true;

            notificationWatcher.Path = Global.NotificationFolder;
            notificationWatcher.NotifyFilter = NotifyFilters.LastWrite;
            notificationWatcher.Filter = "Notifications.xml";
            notificationWatcher.Changed += new FileSystemEventHandler(notification_Changed);
            notificationWatcher.EnableRaisingEvents = true;

            PopulateCharactersForDeleteMenuStrip();
        }

        private void PopulateCharactersForDeleteMenuStrip()
        {
            deleteACharacterToolStripMenuItem.DropDownItems.Clear();

            DirectoryInfo dir = new DirectoryInfo(Global.CharacterFolder);
            FileInfo[] lvFile;
            lvFile = dir.GetFiles("*.xml");
            ToolStripMenuItem[] menuItem = new ToolStripMenuItem[lvFile.Length];

            for (int i = 0; i < lvFile.Length; i++)
            {
                menuItem[i] = new ToolStripMenuItem();
                menuItem[i].Name = $"char{Path.GetFileNameWithoutExtension(lvFile[i].Name)}";
                menuItem[i].Text = Path.GetFileNameWithoutExtension(lvFile[i].Name);
                menuItem[i].Click += new EventHandler(DeleteCharacterClickHandler);
            }

            deleteACharacterToolStripMenuItem.DropDownItems.AddRange(menuItem);
        }

        private void txtCombatChat_FileChanged(object sender, FileSystemEventArgs e)
        {
            string fileContents;

            using (FileStream stream = new FileStream(Global.ChatFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    fileContents = reader.ReadToEnd();
                }
            }
            Invoke((MethodInvoker)delegate ()
            {
                this.cvCombatChat.CombatChatRtf = fileContents;
                RichTextBox lvControl = (RichTextBox)cvCombatChat.Controls.Find("txtCombatChat", true)[0];
                lvControl.SelectionStart = lvControl.Text.Length;
                lvControl.ScrollToCaret();
            });
        }

        private void notification_Changed(object sender, FileSystemEventArgs e)
        {
            if (!cvFormClosing)
            {
                while (IsFileLocked(Global.NotificationXml))
                    Thread.Sleep(1000);
                if (!cvFormClosing)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.tabPageNotifications.Controls.Clear();
                        NotificationTab lvNotificationTab = new NotificationTab();
                        lvNotificationTab.Width = 723;
                        lvNotificationTab.Height = 341;
                        this.tabPageNotifications.Controls.Add(lvNotificationTab);
                    });
                }
            }
        }

        private void loot_Changed(object sender, FileSystemEventArgs e)
        {
            if (!cvFormClosing)
            {
                Invoke((MethodInvoker)delegate()
                {
                    this.tabPageLoot.Controls.Clear();
                    Loot lvLoot = new Loot();
                    lvLoot.Width = 723;
                    lvLoot.Height = 341;
                    this.tabPageLoot.Controls.Add(lvLoot);
                });
            }
        }

        private void combat_Changed(object sender, FileSystemEventArgs e)
        {   
            if (!cvFormClosing)
            {
                Invoke((MethodInvoker)delegate()
                {
                    this.tabPageCombat.Controls.Clear();
                    Combat lvCombat = new Combat();
                    lvCombat.Width = 723;
                    lvCombat.Height = 341;
                    this.tabPageCombat.Controls.Add(lvCombat);
                }); 
            }                      
        }        

        public void txtChat_FileChanged(object sender, FileSystemEventArgs e)
        {
            string fileContents;

            using (FileStream stream = new FileStream(Global.ChatFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    fileContents = reader.ReadToEnd();
                }
            }
            Invoke((MethodInvoker)delegate()
            {                
                this.cvChatAll.ChatRtf = fileContents;
                RichTextBox lvControl = (RichTextBox)cvChatAll.Controls.Find("txtChat", true)[0];
                lvControl.Refresh();
                lvControl.SelectionStart = lvControl.Text.Length;
                lvControl.ScrollToCaret();
            });
        }

        private void map_Changed(object sender, FileSystemEventArgs e)
        {
            if (!cvFormClosing)
            {
                string[] files = Directory.GetFiles(Global.MapFolder, "*.*");

                if (files.Length < 1)
                    tabPageMap.Controls.Clear();

                if (Path.GetExtension(files[0]) != ".tmp" && Path.GetExtension(files[0]) != ".ini")
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        while (IsFileLocked(files[0]))
                            Thread.Sleep(1000);
                        using (FileStream stream = new FileStream(files[0], FileMode.Open, FileAccess.Read))
                        {
                            this.cvMap.MapImageFile = Image.FromStream(stream);
                            ChatboxMessages.MapAvailable();
                        }
                        this.cvMap.Refresh();                        
                    });
                } 
            }                    
        }

        private void GMForm_Load(object sender, EventArgs e)
        {
            tabPageAll.Controls.Add(cvChatAll);
            tabPageChatCombat.Controls.Add(cvCombatChat);
            tabPageMap.Controls.Add(cvMap);
            cvCombat.Width = 723;
            cvCombat.Height = 341;
            tabPageCombat.Controls.Add(cvCombat);
            tabPageLoot.Controls.Add(cvLoot);

            tabPageCompendium.Controls.Add(cvCompTab);
            tabPageReference.Controls.Add(cvReferenceTab);
            tabPageNotifications.Controls.Add(cvNotificationTab);
            cvPanelSelected = pnlSelected;
        }

        internal static void setPanelSelectedCash(CashControl pvCashControl)
        {
            cvPanelSelected.Controls.Clear();
            cvPanelSelected.Controls.Add(pvCashControl);
        }

        internal static void setPanelSelectedItem(ItemDisplay pvItemDisplay)
        {
            cvPanelSelected.Controls.Clear();
            cvPanelSelected.Controls.Add(pvItemDisplay);
        }

        internal static void setPanelSelectedItem(RtfDisplay pvRtfDisplay)
        {
            cvPanelSelected.Controls.Clear();
            cvPanelSelected.Controls.Add(pvRtfDisplay);
        }

        internal static void setPanelSelectedChar(CharDisplay pvCharDisplay)
        {
            cvPanelSelected.Controls.Clear();
            cvPanelSelected.Controls.Add(pvCharDisplay);
        }

        internal static void setPanelSelectedVehicle(VehicleDisplay pvVehicleDisplay)
        {
            cvPanelSelected.Controls.Clear();
            cvPanelSelected.Controls.Add(pvVehicleDisplay);
        }

        internal static void setPanelSelectedGMControl(GMControl pvControl)
        {
            cvPanelSelected.Controls.Clear();
            cvPanelSelected.Controls.Add(pvControl);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if ((tabCommunication.SelectedTab.Name == tabPageAll.Name || tabCommunication.SelectedTab.Name == tabPageChatCombat.Name) && txtMessage.Text != "")
            {
                ChatBox(txtMessage.Text, "GM:", (int)RtfHelper.FontColorEnum.OffWhite, (int)RtfHelper.FontColorEnum.OffWhite);
                txtMessage.Text = string.Empty;
            }
            txtMessage.Focus();
        }

        public void ChatBox(string lvMessage, string lvPrefix, int titleColorRtf, int textColorRtf)
        {
            RichTextBox lvControl = (RichTextBox)cvChatAll.Controls.Find("txtChat", true)[0];

            string rfString = RtfHelper.RtfFont() + RtfHelper.RtfColorTable() + @"\fs20\cf" + titleColorRtf.ToString() + @" \par " + lvPrefix + @"\cf" + textColorRtf.ToString() + " " + lvMessage;

            using (FileStream stream = new FileStream(Properties.Settings.Default.DataLocation + @"Active\Chat\General.txt", FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(rfString);
                writer.Flush();
                writer.Close();
            }

            btnSend.Focus();
        }

        public void CombatChatBox(string lvMessage, string lvPrefix, int titleColorRtf, int textColorRtf)
        {
            RichTextBox lvControl = (RichTextBox)cvCombatChat.Controls.Find("txtCombatChat", true)[0];

            string rfString = RtfHelper.RtfFont() + RtfHelper.RtfColorTable() + @"\fs20\cf" + titleColorRtf.ToString() + @" \par " + lvPrefix + @"{\cf" + textColorRtf.ToString() + " " + lvMessage + "}";

            using (FileStream stream = new FileStream(Properties.Settings.Default.DataLocation + @"Active\Chat\Combat.txt", FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(rfString);
                writer.Flush();
                writer.Close();
            }

            btnSend.Focus();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSend_Click(sender, new EventArgs());
                txtMessage.Focus();
            }
        }

        private void txtMessage_Enter(object sender, EventArgs e)
        {
            if (txtMessage.Text == "\r\n")
            {
                txtMessage.Text = string.Empty;
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateItem lvCreateItem = new CreateItem();
            pnlDisplay.Controls.Clear();
            pnlDisplay.Controls.Add(lvCreateItem);
            pnlDisplay.BringToFront();
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCharacter lvCreateCharacter = new CreateCharacter();
            pnlDisplay.Controls.Clear();
            pnlDisplay.Controls.Add(lvCreateCharacter);
            pnlDisplay.BringToFront();
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

        private void archiveChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Global.ChatFolder, "*.txt");
            
            foreach (string file in files)
            {
                if (Path.GetFileName(file) == "General.txt")
                {
                    File.Move(file,
                        Properties.Settings.Default.DataLocation + @"Archive\Chat\" +
                        DateTime.Now.ToString("yyyy-MM-d H-mm-ss tt") + "-General.txt");
                    File.Create(file).Close();
                    File.WriteAllText(file, "");                
                }
            }
        }

        private void archiveCombatChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Global.ChatFolder, "*.txt");

            foreach (string file in files)
            {
                if (Path.GetFileName(file) == "Combat.txt")
                {
                    File.Move(file,
                        Properties.Settings.Default.DataLocation + @"Archive\Chat\" +
                        DateTime.Now.ToString("yyyy-MM-d H-mm-ss tt") + "-Combat.txt");
                    File.Create(file).Close();
                    File.WriteAllText(file, "");
                }
            }
        }

        private void GMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Global.MapFolder);
            cvFormClosing = true;

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            DirectoryInfo diCombat = new DirectoryInfo(Global.CombatFolder);

            foreach (FileInfo file in diCombat.GetFiles())
            {
                if (Path.GetFileNameWithoutExtension(file.FullName) != "Combat" && Path.GetExtension(file.FullName) != ".TMP" && Path.GetExtension(file.FullName) != ".ini")
                {
                    Global.RemoveCombatActor(Path.GetFileNameWithoutExtension(file.FullName), Global.CharType.NPC);
                    file.Delete();
                }                
            }

            chatWatcher.Dispose();
            combatChatWatcher.Dispose();
            mapWatcher.Dispose();
            combatWatcher.Dispose();
            lootWatcher.Dispose();
            storeWatcher.Dispose();
            notificationWatcher.Dispose();

            Global.RemoveAllLootItems();
            Environment.Exit(Environment.ExitCode);
        }

        private void beginCombatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.CombatXml);

            XmlNode xNode = xDoc.SelectSingleNode("Combat/@Active");

            if (xNode.Value == "0")
            {
                xNode.Value = "1";
                ChatBox("Combat has initiated.", "", (int)RtfHelper.FontColorEnum.Yellow, (int)RtfHelper.FontColorEnum.Yellow);
            }
            else
            {
                xNode.Value = "0";
                ChatBox("Combat has ended.", "", (int)RtfHelper.FontColorEnum.Yellow, (int)RtfHelper.FontColorEnum.Yellow);
            }

            FileStream lvFS = new FileStream(Global.CombatXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openCloseShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.StoreXml);

            XmlNode xNode = xDoc.SelectSingleNode("Store/@Active");

            if (xNode.Value == "0")
            {
                xNode.Value = "1";
                ChatBox("The shop is now open.", "", (int)RtfHelper.FontColorEnum.Yellow, (int)RtfHelper.FontColorEnum.Yellow);
            }
            else
            {
                xNode.Value = "0";
                ChatBox("The shop has closed.", "", (int)RtfHelper.FontColorEnum.Yellow, (int)RtfHelper.FontColorEnum.Yellow);
            }

            FileStream lvFS = new FileStream(Global.StoreXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        private void DeleteCharacterClickHandler(object sender, EventArgs e)
        {
            string characterName = ((ToolStripMenuItem)sender).Text;
            string message = $"Are you sure you want to delete character {characterName}?";

            if (MessageBox.Show(message, "Delete Character", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                File.Delete($"{Global.CharacterFolder}{characterName}.xml");
            }

            PopulateCharactersForDeleteMenuStrip();
        }

        private void distributeXPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GMAdministerExperience adminExp = new GMAdministerExperience();

            Global.CustomForm = new CustomForm();
            Global.CustomForm.Controls.Clear();
            Global.CustomForm.Controls.Add(adminExp);
            Global.CustomForm.Height = 520;
            Global.CustomForm.Width = 320;
            Global.CustomForm.Text = "Distribute XP";
            Global.CustomForm.Show();
        }
    }
}