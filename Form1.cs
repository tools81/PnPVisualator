using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Controls;
using System.IO;
using Pen_and_Paper_Visualator.Class;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Pen_and_Paper_Visualator
{
    internal partial class frmVisualator : System.Windows.Forms.Form
    {
        private Audio cvAudio;

        ChatTab cvChatCombat = new ChatTab();
        ChatTab cvChatAll = new ChatTab();

        public frmVisualator()
        {
            InitializeComponent();

            //Server.Connect();
        }
        //NOTE  Add combat order list
        //NOTE  Add status label - Poisoned, Driving, Overencumbered, etc

        private void frmVisualator_Load(object sender, EventArgs e)
        {
            Client.Connect();

            cvAudio = new Audio("Theme.mp3");
            cvAudio.Ending += new System.EventHandler(this.Music_ClipEnded);
            
            Player.Merit = new string[10];
            Player.Flaw = new string[10];
            Player.Equipment = new string[10];
            Player.Weapon = new string[5];
            Player.Armor = new string[3];
            Player.Discipline = new string[9];
            Player.Disc_Level = new int[9];
            Player.Vehicle = new string[4];

            Discipline.DisciplineTable = new DataTable();
            Discipline.DisciplineTable.Columns.Add("Name");
            Discipline.DisciplineTable.Columns.Add("Level");
            Discipline.DisciplineTable.Columns.Add("LevelName");
            Discipline.DisciplineTable.Columns.Add("Action");
            Discipline.DisciplineTable.Columns.Add("Attribute");
            Discipline.DisciplineTable.Columns.Add("Skill");
            Discipline.DisciplineTable.Columns.Add("Willpower_Cost");
            Discipline.DisciplineTable.Columns.Add("Vitae_Cost");
            Discipline.DisciplineTable.Columns.Add("Resist_Attribute");
            Discipline.DisciplineTable.Columns.Add("Resist_Skill");
            Discipline.DisciplineTable.Columns.Add("Description");
            Discipline.DisciplineTable.Columns.Add("Image");

            Trait.TraitTable = new DataTable();
            Trait.TraitTable.Columns.Add("Name");
            Trait.TraitTable.Columns.Add("Type");
            Trait.TraitTable.Columns.Add("Cost");
            Trait.TraitTable.Columns.Add("Attribute");
            Trait.TraitTable.Columns.Add("Skill");
            Trait.TraitTable.Columns.Add("Bonus");
            Trait.TraitTable.Columns.Add("Impairment");
            Trait.TraitTable.Columns.Add("Automatic");
            Trait.TraitTable.Columns.Add("Description");

            Player.Vehicle_Cargo = new DataTable();
            Player.Vehicle_Cargo.Columns.Add("VehicleIndex");
            Player.Vehicle_Cargo.Columns.Add("Item");


            using (StreamReader r = new StreamReader("Disciplines\\Discipline.txt"))
            {
                int x = 0;
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    x++;
                    int i = line.IndexOf("=") + 1;
                    if (line.StartsWith("Discipline")) Discipline.Name = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Level")) Discipline.Level = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Name")) Discipline.LevelName = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Action")) Discipline.Action = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Attribute")) Discipline.Attribute = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Skill")) Discipline.Skill = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Willpower_Cost")) Discipline.Willpower_Cost = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Vitae_Cost")) Discipline.Vitae_Cost = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Resist_Attribute")) Discipline.Resist_Attribute = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Resist_Skill")) Discipline.Resist_Skill = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Description")) Discipline.Description = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Image")) Discipline.Image = line.Substring(i, line.Length - i);

                    if (x > 11)
                    {
                                    Discipline.DisciplineTable.Rows.Add(Discipline.Name, Discipline.Level, Discipline.LevelName,
                                                        Discipline.Action,
                                                        Discipline.Attribute, Discipline.Skill,
                                                        Discipline.Willpower_Cost, Discipline.Vitae_Cost,
                                                        Discipline.Resist_Attribute,
                                                        Discipline.Resist_Skill, Discipline.Description, 
                                                        Discipline.Image);
                        x = 0;
                    }
                }
            }

            using (StreamReader r = new StreamReader("Traits\\Trait.txt"))
            {
                int x = 0;
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    x++;
                    int i = line.IndexOf("=") + 1;
                    if (line.StartsWith("Name")) Trait.Name = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Type")) Trait.Type = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Cost")) Trait.Cost = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Attribute")) Trait.Attribute = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Skill")) Trait.Skill = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Bonus")) Trait.Bonus = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Impairment")) Trait.Impairment = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Automatic")) Trait.Automatic = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Description")) Trait.Description = line.Substring(i, line.Length - i);

                    if (x > 8)
                    {
                        Trait.TraitTable.Rows.Add(Trait.Name, Trait.Type, Trait.Cost,
                                            Trait.Attribute, Trait.Skill,
                                            Trait.Bonus, Trait.Impairment,
                                            Trait.Automatic,
                                            Trait.Description);
                        x = 0;
                    }
                }
            }
            //TODO: set character to a global variable
            using (StreamReader r = new StreamReader("Characters\\Coco.txt"))
            {
                int m = 0;
                int f = 0;
                int q = 0;
                int w = 0;
                int a = 0;
                int d = 0;
                int l = 0;
                int v = 0;

                string line;
                while ((line = r.ReadLine()) != null)
                {
                    int i = line.IndexOf("=") + 1;
                    if (line.StartsWith("Name")) Player.Name = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Type")) Player.Type = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Player")) Player.PlayerName = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Experience")) Player.Experience = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Concept")) Player.Concept = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Clan")) Player.Clan = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Virtue")) Player.Virtue = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Covenant")) Player.Covenant = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Chronicle")) Player.Chronicle = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Vice")) Player.Vice = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Coterie")) Player.Coterie = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Image")) Player.Image = line.Substring(i, line.Length - i);
                    if (line.StartsWith("Intelligence")) Player.Intelligence = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Wits")) Player.Wits = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Resolve")) Player.Resolve = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Strength")) Player.Strength = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Dexterity")) Player.Dexterity = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Stamina")) Player.Stamina = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Presence")) Player.Presence = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Manipulation")) Player.Manipulation = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Composure")) Player.Composure = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Academics")) Player.Academics = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Computer")) Player.Computer = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Investigation")) Player.Investigation = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Medicine")) Player.Medicine = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Occult")) Player.Occult = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Politics")) Player.Politics = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Science")) Player.Science = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Athletics")) Player.Athletics = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Brawl")) Player.Brawl = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Drive")) Player.Drive = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Firearms")) Player.Firearms = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Stealth")) Player.Stealth = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Survival")) Player.Survival = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Weaponry")) Player.Weaponry = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("AnimalKen")) Player.AnimalKen = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Empathy")) Player.Empathy = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Intimidation")) Player.Intimidation = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Persuasion")) Player.Persuasion = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Socialize")) Player.Socialize = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Streetwise")) Player.Streetwise = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Subterfuge")) Player.Subterfuge = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Expression")) Player.Expression = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Larceny")) Player.Larceny = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Crafts")) Player.Crafts = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Willpower")) Player.Willpower = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Humanity")) Player.Humanity = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Health")) Player.Health = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("BloodPotency")) Player.Potency = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Vitae")) Player.Vitae = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Size")) Player.Size = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Defense")) Player.Defense = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Initiative")) Player.Initiative = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Cash")) Player.Cash = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Speed")) Player.Speed = Convert.ToInt32(line.Substring(i, line.Length - i));
                    if (line.StartsWith("Merit"))
                    {
                        Player.Merit.SetValue(line.Substring(i, line.Length - i), m);
                        m++;
                    }
                    if (line.StartsWith("Flaw"))
                    {
                        Player.Flaw.SetValue(line.Substring(i, line.Length - i), f);
                        f++;
                    }
                    if (line.StartsWith("Equipment"))
                    {
                        Player.Equipment.SetValue(line.Substring(i, line.Length - i), q);
                        q++;
                    }
                    if (line.StartsWith("Weapons"))
                    {
                        Player.Weapon.SetValue(line.Substring(i, line.Length - i), w);
                        w++;
                    }
                    if (line.StartsWith("Armor"))
                    {
                        Player.Armor.SetValue(line.Substring(i, line.Length - i), a);
                        a++;
                    }
                    if (line.StartsWith("Discipline"))
                    {
                        Player.Discipline.SetValue(line.Substring(i, line.Length - i), d);
                        d++;
                    }
                    if (line.StartsWith("Disc_Level"))
                    {
                        Player.Disc_Level.SetValue(Convert.ToInt32(line.Substring(i, line.Length - i)), l);
                        l++;
                    }
                    if (line.StartsWith("Vehicle"))
                    {
                        Player.Vehicle.SetValue(line.Substring(i, line.Length - i), v);
                        v++;
                    }
                    if (line.StartsWith("Cargo"))
                    {
                        Player.Vehicle_Cargo.Rows.Add(v - 1, line.Substring(i, line.Length - i));
                    }
                }
            }
            
            #region Change screen by player type
            switch (Player.Type)
            {
                case "Werewolf":                    
                    this.BackColor = Color.Sienna;
                    pnlInteractive.BackgroundImage = Properties.Resources.Wolf_Logo;
                    tabPageDiscipline.Text = "Rites";
                    lblVitae.Text = "Essence";
                    lblPotency.Text = "Primal Urge";
                    lblHumanity.Text = "Harmony";
                    break;
                case "Mage":
                    this.BackColor = Color.DarkGreen;
                    pnlInteractive.BackgroundImage = Properties.Resources.Mage_Logo;
                    tabPageDiscipline.Text = "Spells";
                    lblVitae.Text = "Mana";
                    lblPotency.Text = "Gnosis";
                    lblHumanity.Text = "Wisdom";
                    break;
                case "Hunter":
                    this.BackColor = Color.Black;
                    pnlInteractive.BackgroundImage = Properties.Resources.Hunter_Logo;
                    tabPageDiscipline.Text = "Tactics";
                    lblVitae.Text = "Unused";
                    lblPotency.Text = "Unused";
                    lblHumanity.Text = "Morality";
                    break;
                default:
                    this.BackColor = Color.DarkRed;
                    pnlInteractive.BackgroundImage = Properties.Resources.Vamp_Logo;
                    break;
            }
#endregion

            #region Potency
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
#endregion

            #region Humanity
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
            #endregion

            #region Willpower
            if (Player.Willpower > 0)
            {
                rdoWill1.Checked = true;
                chkWill1.Checked = true;
            }
            if (Player.Willpower > 1)
            {
                rdoWill2.Checked = true;
                chkWill2.Checked = true;
            }
            if (Player.Willpower > 2)
            {
                rdoWill3.Checked = true;
                chkWill3.Checked = true;
            }
            if (Player.Willpower > 3)
            {
                rdoWill4.Checked = true;
                chkWill4.Checked = true;
            }
            if (Player.Willpower > 4)
            {
                rdoWill5.Checked = true;
                chkWill5.Checked = true;
            }
            if (Player.Willpower > 5)
            {
                rdoWill6.Checked = true;
                chkWill6.Checked = true;
            }
            if (Player.Willpower > 6)
            {
                rdoWill7.Checked = true;
                chkWill7.Checked = true;
            }
            if (Player.Willpower > 7)
            {
                rdoWill8.Checked = true;
                chkWill8.Checked = true;
            }
            if (Player.Willpower > 8)
            {
                rdoWill9.Checked = true;
                chkWill9.Checked = true;
            }
            if (Player.Willpower > 9)
            {
                rdoWill10.Checked = true;
                chkWill10.Checked = true;
            }
            #endregion

            #region Health
            if (Player.Health > 0)
            {
                rdoHealth1.Checked = true;
                chkHealth1.Checked = true;
            }
            if (Player.Health > 1)
            {
                rdoHealth2.Checked = true;
                chkHealth2.Checked = true;
            }
            if (Player.Health > 2)
            {
                rdoHealth3.Checked = true;
                chkHealth3.Checked = true;
            }
            if (Player.Health > 3)
            {
                rdoHealth4.Checked = true;
                chkHealth4.Checked = true;
            }
            if (Player.Health > 4)
            {
                rdoHealth5.Checked = true;
                chkHealth5.Checked = true;
            }
            if (Player.Health > 5)
            {
                rdoHealth6.Checked = true;
                chkHealth6.Checked = true;
            }
            if (Player.Health > 6)
            {
                rdoHealth7.Checked = true;
                chkHealth7.Checked = true;
            }
            if (Player.Health > 7)
            {
                rdoHealth8.Checked = true;
                chkHealth8.Checked = true;
            }
            if (Player.Health > 8)
            {
                rdoHealth9.Checked = true;
                chkHealth9.Checked = true;
            }
            if (Player.Health > 9)
            {
                rdoHealth10.Checked = true;
                chkHealth10.Checked = true;
            }
            if (Player.Health > 10)
            {
                rdoHealth11.Checked = true;
                chkHealth11.Checked = true;
            }
            if (Player.Health > 11)
            {
                rdoHealth12.Checked = true;
                chkHealth12.Checked = true;
            }
            #endregion

            #region Vitae
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
            #endregion

            lblExperience.Text = Player.Experience.ToString();

            PlayerTab lvCharPlayer = new PlayerTab();
            tabPageChar.Controls.Add(lvCharPlayer);

            frmStats lvCharStat = new frmStats();
            tabPageStat.Controls.Add(lvCharStat);

            TraitTab lvCharTrait = new TraitTab();
            tabPageTrait.Controls.Add(lvCharTrait);

            DisciplineTab lvCharDisc = new DisciplineTab();
            tabPageDiscipline.Controls.Add(lvCharDisc);

            EquipmentTab lvCharEquip = new EquipmentTab();
            tabPageEquipment.Controls.Add(lvCharEquip);

            VehicleTab lvCharVehicle = new VehicleTab();
            tabPageVehicle.Controls.Add(lvCharVehicle);

            tabPageCombat.Controls.Add(cvChatCombat);
            tabPageAll.Controls.Add(cvChatAll);
        }

        private void Music_ClipEnded(object sender, EventArgs e)
        {
            cvAudio.Stop();
            cvAudio.Play();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Music Off")
            {
                cvAudio.Stop();
                label3.Text = "Music On";
            }
            else
            {
                cvAudio.Play();
                label3.Text = "Music Off";
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            int lvSuccess = RollDice.Roll(3, 2, 0, 8);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if ((tabCommunication.SelectedTab.Name == tabPageAll.Name || tabCommunication.SelectedTab.Name == tabPageCombat.Name) && txtMessage.Text != "")
            {
                RichTextBox lvControl = (RichTextBox)cvChatAll.Controls.Find("txtChat", true)[0];
                lvControl.Text += "You: ";
                lvControl.Text += txtMessage.Text + "\r\n";

                lvControl.SelectionStart = lvControl.Find("You:");
                lvControl.SelectionColor = Color.LightBlue;
                lvControl.SelectionStart = lvControl.Find(txtMessage.Text);
                lvControl.SelectionColor = Color.White;

                txtMessage.Text = string.Empty;
                btnSend.Focus();
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSend_Click(sender, new EventArgs());
            }
        }

        private void txtMessage_Enter(object sender, EventArgs e)
        {
            if (txtMessage.Text == "\r\n")
            {
                txtMessage.Text = string.Empty;
            }
        }
    }
}