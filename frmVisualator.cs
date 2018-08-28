using System;
using System.Drawing;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Controls;
using System.IO;
using Pen_and_Paper_Visualator.Class;
using System.Threading;
using System.Xml.XPath;
using System.Xml;

namespace Pen_and_Paper_Visualator
{
    public partial class frmVisualator : System.Windows.Forms.Form
    {
        internal static Control cvEquipmentTab;
        internal static Control cvVehicleTab;
        internal static Control cvInteractivePanel;
        bool cvFormClosing = false;

        FileSystemWatcher chatWatcher = new FileSystemWatcher();
        FileSystemWatcher combatChatWatcher = new FileSystemWatcher();
        FileSystemWatcher mapWatcher = new FileSystemWatcher();
        FileSystemWatcher combatWatcher = new FileSystemWatcher();
        FileSystemWatcher lootWatcher = new FileSystemWatcher();
        FileSystemWatcher storeWatcher = new FileSystemWatcher();
        FileSystemWatcher characterWatcher = new FileSystemWatcher();

        CombatChatTab cvCombatChat = new CombatChatTab();
        ChatTab cvChatAll = new ChatTab();
        Map cvMap = new Map();
        Combat cvCombat = new Combat();
        Loot cvLoot = new Loot();
        Store cvStore = new Store();       

        public frmVisualator()
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
            combatWatcher.Filter = "*.*";
            combatWatcher.Changed += new FileSystemEventHandler(combat_Changed);
            combatWatcher.EnableRaisingEvents = true;

            
            lootWatcher.Path = Global.LootFolder;
            lootWatcher.NotifyFilter = NotifyFilters.LastWrite;
            lootWatcher.Filter = "Loot.xml";
            lootWatcher.Changed += new FileSystemEventHandler(loot_Changed);
            lootWatcher.EnableRaisingEvents = true;

            
            storeWatcher.Path = Global.StoreFolder;
            storeWatcher.NotifyFilter = NotifyFilters.LastWrite;
            storeWatcher.Filter = "Store.xml";
            storeWatcher.Changed += new FileSystemEventHandler(store_Changed);
            storeWatcher.EnableRaisingEvents = true;

            characterWatcher.Path = Global.CharacterFolder;
            characterWatcher.NotifyFilter = NotifyFilters.LastWrite;
            characterWatcher.Filter = "Characters.xml";
            characterWatcher.Changed += new FileSystemEventHandler(character_Changed);
            characterWatcher.EnableRaisingEvents = true;
        }

        private void character_Changed(object sender, FileSystemEventArgs e)
        {
            if (!cvFormClosing)
            {
                while (IsFileLocked(Global.ActiveCharacterXml))
                    Thread.Sleep(1000);
                XmlDocument lvCharactersXml = new XmlDocument();
                lvCharactersXml.Load(Global.ActiveCharacterXml);

                var xNode = lvCharactersXml.SelectSingleNode(String.Format("Character[@Name = '{0}']/Update", Player.Name));

                if (xNode != null && xNode.InnerText != string.Empty)
                {
                    
                }
            }
        }

        private void txtCombatChat_FileChanged(object sender, FileSystemEventArgs e)
        {
            string fileContents;

            using (FileStream stream = new FileStream(Global.CombatChatFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    fileContents = reader.ReadToEnd();
                }
            }

            try
            {
                Invoke((MethodInvoker)delegate ()
                {
                    this.cvCombatChat.CombatChatRtf = fileContents;
                    RichTextBox lvControl = (RichTextBox)cvCombatChat.Controls.Find("txtCombatChat", true)[0];
                    lvControl.SelectionStart = lvControl.Text.Length;
                    lvControl.ScrollToCaret();
                });
            }
            catch (Exception ex) { }
        }

        private void store_Changed(object sender, FileSystemEventArgs e)
        {
            if (!cvFormClosing)
            {
                while (IsFileLocked(Global.StoreXml))
                    Thread.Sleep(1000);
                XPathDocument lvStoreXml = new XPathDocument(Global.StoreXml);
                XPathNavigator lvNav = lvStoreXml.CreateNavigator();
                string lvActive = lvNav.SelectSingleNode("Store/@Active").Value;

                if (lvActive == "1")
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.tabPageStore.Controls.Clear();
                        Store lvStore = new Store();
                        lvStore.Width = 723;
                        lvStore.Height = 341;
                        this.tabPageCombat.Controls.Add(lvStore);                        
                    });
                }
                else
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.tabPageStore.Controls.Clear();                        
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
                while (IsFileLocked(Global.CombatXml))
                    Thread.Sleep(1000);
                XPathDocument lvCombatXml = new XPathDocument(Global.CombatXml);
                XPathNavigator lvNav = lvCombatXml.CreateNavigator();
                string lvActive = lvNav.SelectSingleNode("Combat/@Active").Value;

                if (lvActive == "1")
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
                else
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.tabPageCombat.Controls.Clear();                        
                    });
                }
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

            try
            {
                Invoke((MethodInvoker)delegate()
                {
                    this.cvChatAll.ChatRtf = fileContents;
                    RichTextBox lvControl = (RichTextBox)cvChatAll.Controls.Find("txtChat", true)[0];
                    lvControl.SelectionStart = lvControl.Text.Length;
                    lvControl.ScrollToCaret();
                });
            }
            catch(Exception ex) {}
            
            //TODO: Change tab color
        }

        private void map_Changed(object sender, FileSystemEventArgs e)
        {
            if (!cvFormClosing)
            {
                string[] files = Directory.GetFiles(Global.MapFolder, "*.*");
                //files[0] = Path.GetFileName(files[0]);

                if (Path.GetExtension(files[0]) != ".tmp" && Path.GetExtension(files[0]) != ".ini")
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        while (IsFileLocked(files[0]))
                            Thread.Sleep(1000);
                        using (FileStream stream = new FileStream(files[0], FileMode.Open, FileAccess.Read))
                        {
                            this.cvMap.MapImageFile = Image.FromStream(stream);
                        }
                        this.cvMap.Refresh();
                    });
                }
            } 
            //TODO: Change tab color
        }

        private void frmVisualator_Load(object sender, EventArgs e)
        {
            #region Change screen by player type
            switch (Player.Template)
            {
                case Global.Template.Human:
                    Global.Human.SetPlayerTemplateStyle(this);
                    break;
                case Global.Template.Werewolf:
                    Global.Werewolf.SetPlayerTemplateStyle(this);
                    Global.Werewolf.AddFormTab(this);
                    break;
                case Global.Template.Mage:
                    Global.Mage.SetPlayerTemplateStyle(this);
                    break;
                case Global.Template.Hunter:
                    Global.Hunter.SetPlayerTemplateStyle(this);
                    break;
                case Global.Template.Possessed:
                    Global.Possessed.SetPlayerTemplateStyle(this);
                    break;
                default:
                    Global.Vampire.SetPlayerTemplateStyle(this);
                    break;
            }
            #endregion

            PopulateVisualator();
            SetupTabs();

            cvEquipmentTab = tabPageEquipment;
            cvVehicleTab = tabPageVehicle;
            cvInteractivePanel = pnlInteractive;

            tabPageAll.Controls.Add(cvChatAll);
            tabPageChatCombat.Controls.Add(cvCombatChat);
            tabPageMap.Controls.Add(cvMap);           

            XPathDocument lvCombatXml = new XPathDocument(Global.CombatXml);
            XPathNavigator lvNav = lvCombatXml.CreateNavigator();
            string lvActive = lvNav.SelectSingleNode("Combat/@Active").Value;

            if (lvActive == "1")
            {
                cvCombat.Width = 723;
                cvCombat.Height = 341;
                tabPageCombat.Controls.Add(cvCombat);
            }

            XPathDocument lvStoreXml = new XPathDocument(Global.StoreXml);
            lvNav = lvStoreXml.CreateNavigator();
            lvActive = lvNav.SelectSingleNode("Store/@Active").Value;

            if (lvActive == "1")
            {
                cvStore.Width = 723;
                cvStore.Height = 341;
                tabPageStore.Controls.Add(cvStore);
            }

            tabPageLoot.Controls.Add(cvLoot);

            ActivePlayersTab lvParty = new ActivePlayersTab();
            tabPageParty.Controls.Add(lvParty);
        }

        public void SetupTabs()
        {
            tabPageChar.Controls.Clear();
            PlayerTab lvCharPlayer = new PlayerTab();            
            tabPageChar.Controls.Add(lvCharPlayer);

            tabPageStat.Controls.Clear();
            frmStats lvCharStat = new frmStats();           
            tabPageStat.Controls.Add(lvCharStat);

            tabPageTrait.Controls.Clear();
            TraitTab lvCharTrait = new TraitTab();            
            tabPageTrait.Controls.Add(lvCharTrait);

            tabPageEquipment.Controls.Clear();
            EquipmentTab lvCharEquip = new EquipmentTab();            
            tabPageEquipment.Controls.Add(lvCharEquip);

            tabPageVehicle.Controls.Clear();
            VehicleTab lvCharVehicle = new VehicleTab();            
            tabPageVehicle.Controls.Add(lvCharVehicle);

            tabPageActions.Controls.Clear();
            Actions lvActions = new Actions();
            tabPageActions.Controls.Add(lvActions);
        }

        public void PopulateVisualator()
        {
            #region Potency
            Invoke((MethodInvoker)delegate ()
            {
                if (Player.Potency > 0)
                {
                    rdoPotency1.Checked = true;
                }
                if (Player.Potency > 1)
                {
                    rdoPotency2.Checked = true;
                }
                if (Player.Potency > 2)
                {
                    rdoPotency3.Checked = true;
                }
                if (Player.Potency > 3)
                {
                    rdoPotency4.Checked = true;
                }
                if (Player.Potency > 4)
                {
                    rdoPotency5.Checked = true;
                }
                if (Player.Potency > 5)
                {
                    rdoPotency6.Checked = true;
                }
                if (Player.Potency > 6)
                {
                    rdoPotency7.Checked = true;
                }
                if (Player.Potency > 7)
                {
                    rdoPotency8.Checked = true;
                }
                if (Player.Potency > 8)
                {
                    rdoPotency9.Checked = true;
                }
                if (Player.Potency > 9)
                {
                    rdoPotency10.Checked = true;
                }
            });
            #endregion

            #region Humanity
            Invoke((MethodInvoker)delegate ()
            {
                if (Player.Humanity > 0)
                {
                    rdoHumanity1.Checked = true;
                }
                if (Player.Humanity > 1)
                {
                    rdoHumanity2.Checked = true;
                }
                if (Player.Humanity > 2)
                {
                    rdoHumanity3.Checked = true;
                }
                if (Player.Humanity > 3)
                {
                    rdoHumanity4.Checked = true;
                }
                if (Player.Humanity > 4)
                {
                    rdoHumanity5.Checked = true;
                }
                if (Player.Humanity > 5)
                {
                    rdoHumanity6.Checked = true;
                }
                if (Player.Humanity > 6)
                {
                    rdoHumanity7.Checked = true;
                }
                if (Player.Humanity > 7)
                {
                    rdoHumanity8.Checked = true;
                }
                if (Player.Humanity > 8)
                {
                    rdoHumanity9.Checked = true;
                }
                if (Player.Humanity > 9)
                {
                    rdoHumanity10.Checked = true;
                }
            });
            #endregion

            #region Willpower
            Invoke((MethodInvoker)delegate ()
            {
                if (Player.WillpowerMax > 0)
                {
                    rdoWill1.Checked = true;
                }
                if (Player.WillpowerMax > 1)
                {
                    rdoWill2.Checked = true;
                }
                if (Player.WillpowerMax > 2)
                {
                    rdoWill3.Checked = true;
                }
                if (Player.WillpowerMax > 3)
                {
                    rdoWill4.Checked = true;
                }
                if (Player.WillpowerMax > 4)
                {
                    rdoWill5.Checked = true;
                }
                if (Player.WillpowerMax > 5)
                {
                    rdoWill6.Checked = true;
                }
                if (Player.WillpowerMax > 6)
                {
                    rdoWill7.Checked = true;
                }
                if (Player.WillpowerMax > 7)
                {
                    rdoWill8.Checked = true;
                }
                if (Player.WillpowerMax > 8)
                {
                    rdoWill9.Checked = true;
                }
                if (Player.WillpowerMax > 9)
                {
                    rdoWill10.Checked = true;
                }

                if (Player.WillpowerCurrent > 0)
                {
                    chkWill1.Checked = true;
                }
                if (Player.WillpowerCurrent > 1)
                {
                    chkWill2.Checked = true;
                }
                if (Player.WillpowerCurrent > 2)
                {
                    chkWill3.Checked = true;
                }
                if (Player.WillpowerCurrent > 3)
                {
                    chkWill4.Checked = true;
                }
                if (Player.WillpowerCurrent > 4)
                {
                    chkWill5.Checked = true;
                }
                if (Player.WillpowerCurrent > 5)
                {
                    chkWill6.Checked = true;
                }
                if (Player.WillpowerCurrent > 6)
                {
                    chkWill7.Checked = true;
                }
                if (Player.WillpowerCurrent > 7)
                {
                    chkWill8.Checked = true;
                }
                if (Player.WillpowerCurrent > 8)
                {
                    chkWill9.Checked = true;
                }
                if (Player.WillpowerCurrent > 9)
                {
                    chkWill10.Checked = true;
                }
            });
            #endregion

            #region Vitae
            Invoke((MethodInvoker)delegate ()
            {
                if (Player.Vitae > 0)
                {
                    chkVitae1.Checked = true;
                }
                if (Player.Vitae > 1)
                {
                    chkVitae2.Checked = true;
                }
                if (Player.Vitae > 2)
                {
                    chkVitae3.Checked = true;
                }
                if (Player.Vitae > 3)
                {
                    chkVitae4.Checked = true;
                }
                if (Player.Vitae > 4)
                {
                    chkVitae5.Checked = true;
                }
                if (Player.Vitae > 5)
                {
                    chkVitae6.Checked = true;
                }
                if (Player.Vitae > 6)
                {
                    chkVitae7.Checked = true;
                }
                if (Player.Vitae > 7)
                {
                    chkVitae8.Checked = true;
                }
                if (Player.Vitae > 8)
                {
                    chkVitae9.Checked = true;
                }
                if (Player.Vitae > 9)
                {
                    chkVitae10.Checked = true;
                }
                if (Player.Vitae > 10)
                {
                    chkVitae11.Checked = true;
                }
                if (Player.Vitae > 11)
                {
                    chkVitae12.Checked = true;
                }
                if (Player.Vitae > 12)
                {
                    chkVitae13.Checked = true;
                }
                if (Player.Vitae > 13)
                {
                    chkVitae14.Checked = true;
                }
                if (Player.Vitae > 14)
                {
                    chkVitae15.Checked = true;
                }
                if (Player.Vitae > 15)
                {
                    chkVitae16.Checked = true;
                }
                if (Player.Vitae > 16)
                {
                    chkVitae17.Checked = true;
                }
                if (Player.Vitae > 17)
                {
                    chkVitae18.Checked = true;
                }
                if (Player.Vitae > 18)
                {
                    chkVitae19.Checked = true;
                }
                if (Player.Vitae > 19)
                {
                    chkVitae20.Checked = true;
                }
            });
            #endregion

            #region Health
            Invoke((MethodInvoker)delegate()
            {
                rdoHealth1.Checked = false;
                rdoHealth2.Checked = false;
                rdoHealth3.Checked = false;
                rdoHealth4.Checked = false;
                rdoHealth5.Checked = false;
                rdoHealth6.Checked = false;
                rdoHealth7.Checked = false;
                rdoHealth8.Checked = false;
                rdoHealth9.Checked = false;
                rdoHealth10.Checked = false;
                rdoHealth11.Checked = false;
                rdoHealth12.Checked = false;
                if (Player.Health > 0)
                {
                    rdoHealth1.Checked = true;
                }
                if (Player.Health > 1)
                {
                    rdoHealth2.Checked = true;
                }
                if (Player.Health > 2)
                {
                    rdoHealth3.Checked = true;
                }
                if (Player.Health > 3)
                {
                    rdoHealth4.Checked = true;
                }
                if (Player.Health > 4)
                {
                    rdoHealth5.Checked = true;
                }
                if (Player.Health > 5)
                {
                    rdoHealth6.Checked = true;
                }
                if (Player.Health > 6)
                {
                    rdoHealth7.Checked = true;
                }
                if (Player.Health > 7)
                {
                    rdoHealth8.Checked = true;
                }
                if (Player.Health > 8)
                {
                    rdoHealth9.Checked = true;
                }
                if (Player.Health > 9)
                {
                    rdoHealth10.Checked = true;
                }
                if (Player.Health > 10)
                {
                    rdoHealth11.Checked = true;
                }
                if (Player.Health > 11)
                {
                    rdoHealth12.Checked = true;
                }
            });
            UpdateHealthState();

            #endregion

            lblExperience.Text = Player.Experience.ToString();

            if (Convert.ToInt32(lblExperience.Text) > 0)
            {
                Invoke((MethodInvoker)delegate()
                {
                    btnLevelUp.Visible = true;
                });
            }                
        }

        public void RefreshAll()
        {
            PopulateVisualator();
            Thread.Sleep(1000); //Changes didn't have time to take effect without this delay
            SetupTabs();
        }

        public void UpdateHealthState()
        {
            int lvAggravated = Player.Aggravated;
            int lvLethal = Player.Lethal;
            int lvBash = Player.Bash;
            int lvHealthPointIndex = 1;

            while (lvAggravated > 0)
            {
                HealthPoint lvHp = ((HealthPoint) this.Controls.Find("healthPoint" + lvHealthPointIndex, true)[0]);
                lvHp.State = HealthPoint.StateEnum.Aggravated;
                lvHp.SetHealthState();
                lvHealthPointIndex++;
                lvAggravated--;
            }

            while (lvLethal > 0)
            {
                HealthPoint lvHp = ((HealthPoint)this.Controls.Find("healthPoint" + lvHealthPointIndex, true)[0]);
                lvHp.State = HealthPoint.StateEnum.Lethal;
                lvHp.SetHealthState();
                lvHealthPointIndex++;
                lvLethal--;
            }

            while (lvBash > 0)
            {
                HealthPoint lvHp = ((HealthPoint)this.Controls.Find("healthPoint" + lvHealthPointIndex, true)[0]);
                lvHp.State = HealthPoint.StateEnum.Bash;
                lvHp.SetHealthState();
                lvHealthPointIndex++;
                lvBash--;
            }
        }

        public void UpdateEquipmentTab()
        {
            tabPageEquipment.Controls.Clear();
            EquipmentTab lvCharEquip = new EquipmentTab();           
            tabPageEquipment.Controls.Add(lvCharEquip);
        }

        internal static void setPanelToTrade(Trade lvTrade)
        {
            cvInteractivePanel.Controls.Clear();
            cvInteractivePanel.Controls.Add(lvTrade);
        }

        internal static bool isPanelSetToTrade()
        {
            foreach (UserControl lvControl in cvInteractivePanel.Controls)
            {
                if (lvControl.Name == "Trade")
                {
                    return true;
                }
            }
            return false;
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            int lvSuccess = RollDice.Roll(3, 1, 1, 8, 10);
            ChatBox($"Outcome ({RollDice.GetOutcomeList()}) > {lvSuccess.ToString()} Success(es)", "Roll:", (int)RtfHelper.FontColorEnum.White, (int)RtfHelper.FontColorEnum.White);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if ((tabCommunication.SelectedTab.Name == tabPageAll.Name || tabCommunication.SelectedTab.Name == tabPageChatCombat.Name) && txtMessage.Text != "")
            {
                ChatBox(txtMessage.Text, Player.Name + "(" + Player.PlayerName + "):", (int)RtfHelper.FontColorEnum.Blue, (int)RtfHelper.FontColorEnum.OffWhite);
                txtMessage.Text = string.Empty;
            }
            txtMessage.Focus();
        }

        public void ChatBox(string lvMessage, string lvPrefix, int titleColorRtf, int textColorRtf)
        {
            RichTextBox lvControl = (RichTextBox)cvChatAll.Controls.Find("txtChat", true)[0];

            string rfString = RtfHelper.RtfFont() + RtfHelper.RtfColorTable() + @"\fs20\cf" + titleColorRtf.ToString() + @" \par " + lvPrefix + @"{\cf" + textColorRtf.ToString() + " " + lvMessage + "}";

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

        private void frmVisualator_FormClosing(object sender, FormClosingEventArgs e)
        {
            cvFormClosing = true;
            Global.RemoveCombatActor(Player.ShortName, Global.CharType.Character);
            Global.RemoveActiveCharacter(Player.Name);
            Global.StopSound();

            chatWatcher.Dispose();
            combatChatWatcher.Dispose();
            mapWatcher.Dispose();
            combatWatcher.Dispose();
            lootWatcher.Dispose();
            storeWatcher.Dispose();

            Environment.Exit(Environment.ExitCode);
        }

        private void btnLevelUp_Click(object sender, EventArgs e)
        {
            CreateCharacter lvCreateCharacter = new CreateCharacter();

            Form lvForm = new Form();
            lvForm.Controls.Add(lvCreateCharacter);
            lvForm.Width = lvCreateCharacter.Width + 20;
            lvForm.Height = lvCreateCharacter.Height + 20;
            lvForm.Show();
            lvForm.BringToFront();            
        }
    }
}