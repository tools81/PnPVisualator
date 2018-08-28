using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;
using System.IO;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class CreateCharacter : UserControl
    {
        #region Private Fields
        private int cvAttrTotal;
        private int cvSkillTotal;
        private int cvSpecialtyTotal;
        private int cvMeritTotal;
        private int cvHumanityTotal;
        private int cvWillpowerTotal;
        private string cvImage;
        private bool cvMortal;
        private string cvTemplate;
        private int cvPotencyTotal;
        private bool cvCreation = true;

        private const int cvAttributeCost = 5;
        private const int cvAttributeMax = 5;
        private const int cvSkillCost = 3;
        private const int cvSkillMax = 5;
        private const int cvSpecialtyCost = 3; //not multiplied by rank
        private const int cvMeritCost = 2;
        private const int cvHumanityCost = 3; //aka Harmony(Vampire); aka Essence(Werewolf); aka Wisdom(Mage); aka Morality(Possessed)        
        private const int cvWillpowerCost = 8; //not multiplied by rank
        private const int cvMeritPool = 7;

        private List<TabPage> cvTabPages = new List<TabPage>();
        private List<string[,]> cvMerits = new List<String[,]>(); 
        private List<string[]> cvFlaws = new List<string[]>(); 

        private XPathDocument cvTemplateXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Templates.xml");
        private XPathDocument cvMeritXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Merits.xml");
        private XPathDocument cvFlawXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Flaws.xml");
        private XPathDocument cvClanXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Clans.xml");
        private XPathDocument cvCovenantXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Covenants.xml");
        private XPathDocument cvViceXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Vices.xml");
        private XPathDocument cvVirtueXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Virtues.xml");
        private XPathDocument cvDisciplineXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Discipline.xml");
        private XPathDocument cvGiftsXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Gifts.xml");   
        private XPathDocument cvIndexXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Index.xml");

        //TODO
        //private XPathDocument cvDerangementsXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Derangements.xml");

        XPathNavigator cvCloneEquip;
        XPathNavigator cvCloneVehicles;

        private List<string[,]> cvMeritBoosts = new List<string[,]>();

        private List<Control> ControlList = new List<Control>();

        //These are boost value provided by Merits, Flaws, etc
        private int _Speed = 0;
        private int _Initiative = 0;
        private int _Defense = 0;
        private int _Size = 0;
        private int _Health = 0;
        private int _Willpower = 0;
        private int _Humanity = 0;
        private int _BloodPotency = 0;
        #endregion

        #region Template Class Init
        Class.Create.Human _human;
        Class.Create.Hunter _hunter;
        Class.Create.Mage _mage;
        Class.Create.Vampire _vampire;
        Class.Create.Werewolf _werewolf;
        Class.Create.Possessed _possessed;
        #endregion

        #region Constructor
        public CreateCharacter()
        {
            InitializeComponent();

            Global.ShowLoadForm();

            _human = new Class.Create.Human(this);
            _hunter = new Class.Create.Hunter(this);
            _mage = new Class.Create.Mage(this);
            _vampire = new Class.Create.Vampire(this);
            _werewolf = new Class.Create.Werewolf(this);
            _possessed = new Class.Create.Possessed(this);


            foreach (TabPage tab in tabCreate.TabPages)
            {
                cvTabPages.Add(tab);
            }

            WireEventHandlers();

            PopulateLists();

            _vampire.Populate();
            _werewolf.Populate();
            _mage.Populate();
            //TODO
            //_hunter.Populate();
            //_possessed.Populate();

            if (!String.IsNullOrEmpty(Player.Name))
            {
                cvCreation = false;
                pnlCreationHelper.Visible = false;
                LoadCharacter();
                txtName.Enabled = false;              
                cvAttrTotal = AttributeTotal();
                cvSkillTotal = SkillTotal();
                cvSpecialtyTotal = SkillSpecialTotal();
                cvMeritTotal = MeritTotal();
                cvHumanityTotal = HumanityTotal();
                cvWillpowerTotal = WillpowerTotal();
                rdoHumanity.Enabled = true;
                rdoWillpower.Enabled = true;
            }

            tabCreate.BackColor = Color.Transparent;

            foreach (TabPage lvTab in tabCreate.TabPages)
            {
                foreach (Control lvControl in lvTab.Controls)
                {
                    string b = lvControl.Name;
                    if (lvControl is TableLayoutPanel)
                    {
                        foreach (Control lvSubControl in lvControl.Controls)
                        {
                            if (lvSubControl is rdoAbilityRank)
                            {
                                ((rdoAbilityRank)lvSubControl).rdoAbilityRankClicked += new rdoAbilityRank.rdoAbilityRankClickedHandler(rdoAbilityRank_Click);
                            }
                        }
                    }

                    if (lvControl is rdoAbilityRank)
                    {
                        ((rdoAbilityRank)lvControl).rdoAbilityRankClicked += new rdoAbilityRank.rdoAbilityRankClickedHandler(rdoAbilityRank_Click);
                    }
                }
            }            

            UpdateStats();            
        }
        #endregion

        #region Level up Costs
        private int AttributeTotal()
        {
            int n = cvAttributeMax;
            int sum = 0;

            while (n != 0)
            {                
                if (n <= rdoIntelligence.AbilityRank)
                    sum += n;
                if (n <= rdoWits.AbilityRank)
                    sum += n;
                if (n <= rdoResolve.AbilityRank)
                    sum += n;

                n -= 1;
            }
            n = cvAttributeMax;

            while (n != 0)
            {
                if (n <= rdoStrength.AbilityRank)
                    sum += n;
                if (n <= rdoDexterity.AbilityRank)
                    sum += n;
                if (n <= rdoStamina.AbilityRank)
                    sum += n;

                n -= 1;
            }
            n = cvAttributeMax;

            while (n != 0)
            {
                if (n <= rdoPresence.AbilityRank)
                    sum += n;
                if (n <= rdoManipulation.AbilityRank)
                    sum += n;
                if (n <= rdoComposure.AbilityRank)
                    sum += n;

                n -= 1;
            }

            return sum * cvAttributeCost;
        }

        private int SkillTotal()
        {
            int n = cvSkillMax;
            int sum = 0;

            while (n != 0)
            {
                if(n <= rdoAcademics.AbilityRank)
                    sum +=n;
                if(n <= rdoComputer.AbilityRank)
                    sum +=n;
                if(n <= rdoCrafts.AbilityRank)
                    sum +=n;
                if(n <= rdoInvestigation.AbilityRank)
                    sum +=n;
                if(n <= rdoMedicine.AbilityRank)
                    sum +=n;
                if(n <= rdoOccult.AbilityRank)
                    sum +=n;
                if(n <= rdoPolitics.AbilityRank)
                    sum +=n;
                if(n <= rdoScience.AbilityRank)
                    sum +=n;
                if(n <= rdoAthletics.AbilityRank)
                    sum +=n;
                if(n <= rdoBrawl.AbilityRank)
                    sum +=n;
                if(n <= rdoDrive.AbilityRank)
                    sum +=n;
                if(n <= rdoFirearms.AbilityRank)
                    sum +=n;
                if(n <= rdoLarceny.AbilityRank)
                    sum +=n;
                if(n <= rdoStealth.AbilityRank)
                    sum +=n;
                if(n <= rdoSurvival.AbilityRank)
                    sum +=n;
                if(n <= rdoWeaponry.AbilityRank)
                    sum +=n;
                if(n <= rdoAnimalKen.AbilityRank)
                    sum +=n;
                if(n <= rdoEmpathy.AbilityRank)
                    sum +=n;
                if(n <= rdoExpression.AbilityRank)
                    sum +=n;
                if(n <= rdoIntimidation.AbilityRank)
                    sum +=n;
                if(n <= rdoPersuasion.AbilityRank)
                    sum +=n;
                if(n <= rdoSocialize.AbilityRank)
                    sum +=n;
                if(n <= rdoStreetwise.AbilityRank)
                    sum +=n;
                if(n <= rdoSubterfuge.AbilityRank)
                    sum +=n;

                n -= 1;
            }

            return sum * cvSkillCost;
        }

        private int SkillSpecialTotal()
        {
            return chkListSpecialties.SelectedItems.Count * cvSpecialtyCost;
        }

        private int MeritTotal()
        {
            int sum = 0;

            foreach (Control cntrl in pnlMerits.Controls)
            {
                if (cntrl.GetType() == typeof(CheckBox))
                {
                    CheckBox cbx = ((CheckBox)cntrl);
                    if (cbx.Checked)
                    {
                        rdoAbilityRank rank = (rdoAbilityRank)this.Controls.Find("rdoMerit" + cbx.Text.Replace(" ", String.Empty), true)[0];
                        sum += rank.AbilityRank * cvMeritCost;
                    }
                }
            }

            return sum;
        }

        private int HumanityTotal()
        {
            return rdoHumanity.AbilityRank * cvHumanityCost;
        }

        private int WillpowerTotal()
        {
            return (rdoWillpower.AbilityRank) * cvWillpowerCost;
        }
        #endregion

        #region Load Character for Edit
        private void LoadCharacter()
        {
            txtName.Enabled = false;
            cvImage = Player.Image;
            lblExperience.Text = Player.Experience.ToString();
            txtName.Text = Player.Name;
            txtPlayer.Text = Player.PlayerName;

            foreach (var item in ddlTemplate.Items)
            {
                if ((string)item == Player.Template.ToString())
                {
                    ddlTemplate.SelectedItem = item;
                    break;
                }                    
            }

            ddlClan.SelectedText = Player.Clan;
            ddlCovenant.SelectedText = Player.Covenant;
            ddlVice.SelectedText = Player.Vice;
            ddlVirtue.SelectedText = Player.Virtue;
            ddlGender.SelectedText = Player.Gender.ToString();
            numCash.Value = Player.Cash;
            txtChronicle.Text = Player.Chronicle;
            txtConcept.Text = Player.Concept;
            rdoIntelligence.AbilityRank = Player.Intelligence;
            rdoIntelligence.Refresh();
            rdoWits.AbilityRank = Player.Wits;
            rdoWits.Refresh();
            rdoResolve.AbilityRank = Player.Resolve;
            rdoResolve.Refresh();
            rdoStrength.AbilityRank = Player.Strength;
            rdoStrength.Refresh();
            rdoDexterity.AbilityRank = Player.Dexterity;
            rdoDexterity.Refresh();
            rdoStamina.AbilityRank = Player.Stamina;
            rdoStamina.Refresh();
            rdoPresence.AbilityRank = Player.Presence;
            rdoPresence.Refresh();
            rdoManipulation.AbilityRank = Player.Manipulation;
            rdoManipulation.Refresh();
            rdoComposure.AbilityRank = Player.Composure;
            rdoComposure.Refresh();
            imgCharacter.ImageLocation = Global.CharacterImageFolder + Player.Image;

            rdoAcademics.AbilityRank = Player.Academics;
            rdoComputer.AbilityRank = Player.Computer;
            rdoCrafts.AbilityRank = Player.Crafts;
            rdoInvestigation.AbilityRank = Player.Investigation;
            rdoMedicine.AbilityRank = Player.Medicine;
            rdoOccult.AbilityRank = Player.Occult;
            rdoPolitics.AbilityRank = Player.Politics;
            rdoScience.AbilityRank = Player.Science;
            rdoAthletics.AbilityRank = Player.Athletics;
            rdoBrawl.AbilityRank = Player.Brawl;
            rdoDrive.AbilityRank = Player.Drive;
            rdoFirearms.AbilityRank = Player.Firearms;
            rdoLarceny.AbilityRank = Player.Larceny;
            rdoStealth.AbilityRank = Player.Stealth;
            rdoSurvival.AbilityRank = Player.Survival;
            rdoAnimalKen.AbilityRank = Player.AnimalKen;
            rdoEmpathy.AbilityRank = Player.Empathy;
            rdoExpression.AbilityRank = Player.Expression;
            rdoIntimidation.AbilityRank = Player.Intimidation;
            rdoPersuasion.AbilityRank = Player.Persuasion;
            rdoSocialize.AbilityRank = Player.Socialize;
            rdoStreetwise.AbilityRank = Player.Streetwise;
            rdoSubterfuge.AbilityRank = Player.Subterfuge;

            foreach (var pair in Player.Specialize_Skill)
            {
                chkListSpecialties.Items.Add(pair.Value + ":" + pair.Key);
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }

            //TODO: Vitae
            rdoHumanity.AbilityRank = Player.Humanity;
            rdoHumanity.Refresh();
            rdoWillpower.AbilityRank = Player.WillpowerMax;
            rdoWillpower.Refresh();
            //TODO: Renown
            foreach (KeyValuePair<string, int> m in Player.Merit)
            {
                ((CheckBox)pnlMerits.Controls.Find("cbxMerit" + m.Key.Replace(" ", String.Empty), true)[0]).Checked = true;
                ((rdoAbilityRank)pnlMerits.Controls.Find("rdoMerit" + m.Key.Replace(" ", String.Empty), true)[0]).AbilityRank = m.Value;
            }

            foreach (string lvFlaw in Player.Flaw)
            {
                foreach (Control lvControl in tabTraits.Controls)
                {
                    if (lvControl.Name.Contains("ddlFlaw") && ((ComboBox)(lvControl)).SelectedItem == null)
                    {
                        ((ComboBox)(lvControl)).SelectedItem = lvFlaw;
                        break;
                    }
                }
            }                       

            switch (Player.Template)
            {
                case Global.Template.Vampire:
                    _vampire.Load();
                    break;
                case Global.Template.Werewolf:
                    _werewolf.Load();
                    break;
                case Global.Template.Mage:
                    _mage.Load();
                    break;
                case Global.Template.Hunter:
                    _hunter.Load();
                    break;
                case Global.Template.Possessed:
                    _possessed.Load();
                    break;
                default:
                    break;
            }
        }       
        #endregion

        #region Prepare Screen
        private void UpdateStats()
        {
            //Size 5 is common for Humans
            lblSize.Text = (5 + _Size).ToString();
            //Initiative is determined by the sum of Dexterity + Composure
            lblInit.Text = Convert.ToString(rdoDexterity.AbilityRank + rdoComposure.AbilityRank + _Initiative);
            //Speed is determined by the sum of Strength + Dexterity + 5
            lblSpeed.Text = Convert.ToString(rdoStrength.AbilityRank + rdoDexterity.AbilityRank + 5 + _Speed);
            //Health is determined by the sum of Stamina and Size
            rdoHealth.AbilityRank = rdoStamina.AbilityRank + Convert.ToInt32(lblSize.Text);
            rdoHealth.Refresh();
            // Defense is determined by the lower number between Wits and Dexterity
            if (rdoWits.AbilityRank < rdoDexterity.AbilityRank) 
                lblDefense.Text = (rdoWits.AbilityRank + _Defense).ToString();
            else 
                lblDefense.Text = (rdoDexterity.AbilityRank + _Defense).ToString();

            if (cvCreation)
            {
                int lvPower = CheckMaxAtCreation(rdoIntelligence.AbilityRank) + CheckMaxAtCreation(rdoWits.AbilityRank) + CheckMaxAtCreation(rdoResolve.AbilityRank) - 3;
                int lvFinesse = CheckMaxAtCreation(rdoStrength.AbilityRank) + CheckMaxAtCreation(rdoDexterity.AbilityRank) + CheckMaxAtCreation(rdoStamina.AbilityRank) - 3;
                int lvResistance = CheckMaxAtCreation(rdoPresence.AbilityRank) + CheckMaxAtCreation(rdoManipulation.AbilityRank) + CheckMaxAtCreation(rdoComposure.AbilityRank) - 3;
                cvAttrTotal = lvPower + lvFinesse + lvResistance;

                int lvMental = CheckMaxAtCreation(rdoAcademics.AbilityRank) + CheckMaxAtCreation(rdoComputer.AbilityRank) + CheckMaxAtCreation(rdoCrafts.AbilityRank) + CheckMaxAtCreation(rdoInvestigation.AbilityRank) +
                                CheckMaxAtCreation(rdoMedicine.AbilityRank) + CheckMaxAtCreation(rdoOccult.AbilityRank) + CheckMaxAtCreation(rdoPolitics.AbilityRank) + CheckMaxAtCreation(rdoScience.AbilityRank);
                int lvPhysical = CheckMaxAtCreation(rdoAthletics.AbilityRank) + CheckMaxAtCreation(rdoBrawl.AbilityRank) + CheckMaxAtCreation(rdoDrive.AbilityRank) + CheckMaxAtCreation(rdoFirearms.AbilityRank) +
                                CheckMaxAtCreation(rdoLarceny.AbilityRank) + CheckMaxAtCreation(rdoStealth.AbilityRank) + CheckMaxAtCreation(rdoSurvival.AbilityRank) + CheckMaxAtCreation(rdoWeaponry.AbilityRank);
                int lvSocial = CheckMaxAtCreation(rdoAnimalKen.AbilityRank) + CheckMaxAtCreation(rdoEmpathy.AbilityRank) + CheckMaxAtCreation(rdoExpression.AbilityRank) + CheckMaxAtCreation(rdoIntimidation.AbilityRank) +
                                CheckMaxAtCreation(rdoPersuasion.AbilityRank) + CheckMaxAtCreation(rdoSocialize.AbilityRank) + CheckMaxAtCreation(rdoStreetwise.AbilityRank) + CheckMaxAtCreation(rdoSubterfuge.AbilityRank);
                cvSkillTotal = lvMental + lvPhysical + lvSocial;

                rdoPotency.AbilityRank = 1 + _BloodPotency;
                rdoPotency.Refresh();                
                //Morality/Humanity starts at 7 for character creation
                rdoHumanity.AbilityRank = 7 + _Humanity;
                rdoHumanity.Refresh();
                //Willpower is determined by the sum of Resolve + Composure
                rdoWillpower.AbilityRank = rdoResolve.AbilityRank + rdoComposure.AbilityRank + _Willpower;
                rdoWillpower.Refresh();

                UpdateAttributePools(lvPower, lvFinesse, lvResistance);
                UpdateSkillPools(lvMental, lvPhysical, lvSocial);

                lblPrimMerit.Text = (Convert.ToInt32(lblPrimMerit.Text) - cvMeritTotal - cvPotencyTotal).ToString();

                Class.Create.ErrorHandler.CheckAttributes(lvPower, lvFinesse, lvResistance);
                Class.Create.ErrorHandler.CheckSkills(lvMental, lvPhysical, lvSocial);
                Class.Create.ErrorHandler.CheckMerits(cvMeritTotal + cvPotencyTotal);
            }
            else //Loaded Character for Level Up
            {                
                if (cvAttrTotal > 0)
                {
                    int lvAttrTotal = AttributeTotal();
                    int lvSkillTotal = SkillTotal();
                    int lvSkillSpecialTotal = SkillSpecialTotal();
                    int lvMeritTotal = MeritTotal();
                    int lvHumanityTotal = HumanityTotal();

                    Player.Experience += cvAttrTotal - lvAttrTotal;
                    cvAttrTotal = lvAttrTotal;
                    Player.Experience += cvSkillTotal - lvSkillTotal;
                    cvSkillTotal = lvSkillTotal;
                    Player.Experience += cvSpecialtyTotal - lvSkillSpecialTotal;
                    cvSpecialtyTotal = lvSkillSpecialTotal;
                    Player.Experience += cvMeritTotal - lvMeritTotal;
                    cvMeritTotal = lvMeritTotal;
                    Player.Experience += cvHumanityTotal - lvHumanityTotal;
                    cvHumanityTotal = lvHumanityTotal;

                    switch (cvTemplate)
                    {
                        case "Vampire":
                            _vampire.ExperienceCount();
                            break;
                        case "Werewolf":
                            _werewolf.ExperienceCount();
                            break;
                        case "Mage":
                            _mage.ExperienceCount();
                            break;
                        case "Hunter":
                            _hunter.ExperienceCount();
                            break;
                        case "Possessed":
                            _possessed.ExperienceCount();
                            break;
                        default:
                            break;
                    }

                    if (rdoWillpower.AbilityRank < rdoResolve.AbilityRank + rdoComposure.AbilityRank)
                    {
                        rdoWillpower.AbilityRank = rdoResolve.AbilityRank + rdoComposure.AbilityRank + _Willpower;
                        rdoWillpower.Refresh();
                    }
                    else
                    {
                        int lvWillpowerTotal = WillpowerTotal();
                        Player.Experience += cvWillpowerTotal - lvWillpowerTotal;
                        cvWillpowerTotal = lvWillpowerTotal;
                    }

                    lblExperience.Text = Player.Experience.ToString();
                }                
            }                       
        }

        private void UpdateAttributePools(int powerPool, int finessePool, int resistancePool)
        {
            if (powerPool == 5 || finessePool == 5 || resistancePool == 5)
                lblPrimAttr.Text = "0";
            else
                lblPrimAttr.Text = "5";
            if (powerPool == 4 || finessePool == 4 || resistancePool == 4)
                lblSecAttr.Text = "0";
            else
                lblSecAttr.Text = "4";
            if (powerPool == 3 || finessePool == 3 || resistancePool == 3)
                lblTertAttr.Text = "0";
            else
                lblTertAttr.Text = "3";
            if (powerPool + finessePool + resistancePool >= 12)
            {
                lblPrimAttr.Text = "0";
                lblSecAttr.Text = "0";
                lblTertAttr.Text = "0";
            }
        }

        private void UpdateSkillPools(int mentalPool, int physicalPool, int socialPool)
        {
            if (mentalPool == 11 || physicalPool == 11 || socialPool == 11)
                lblPrimSkill.Text = "0";
            else
                lblPrimSkill.Text = "11";
            if (mentalPool == 7 || physicalPool == 7 || socialPool == 7)
                lblSecSkill.Text = "0";
            else
                lblSecSkill.Text = "7";
            if (mentalPool == 4 || physicalPool == 4 || socialPool == 4)
                lblTertSkill.Text = "0";
            else
                lblTertSkill.Text = "4";
            if (mentalPool + physicalPool + socialPool >= 22)
            {
                lblPrimSkill.Text = "0";
                lblSecSkill.Text = "0";
                lblTertSkill.Text = "0";
            }
        }

        //Have to add an extra point if an ability is maxed out at creation
        private int CheckMaxAtCreation(int abilityRank)
        {
            if (cvCreation)
            {
                if (abilityRank > 0 && abilityRank % 5 == 0)
                    return 6;
                else
                    return abilityRank;
            }
            else
                return abilityRank;
        }

        private void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.ShowLoadForm();

            tabCreate.Visible = true;
            tabCreate.SelectedIndex = 0;

            XPathNavigator nav = cvTemplateXml.CreateNavigator();
            cvMortal = nav.SelectSingleNode("Templates/Template[@Name='" + ddlTemplate.SelectedItem + "']/Mortal").ValueAsBoolean;
            cvTemplate = ddlTemplate.SelectedItem.ToString();              

            ShowHideTabs(ddlTemplate.SelectedItem.ToString());
            PopulateSubLists(ddlTemplate.SelectedItem.ToString());

            SetClassLabelText();

            //tabTraits.Refresh();
        }

        private void SetClassLabelText()
        {
            switch (ddlTemplate.SelectedItem.ToString())
            {
                case "Vampire":
                    _vampire.Screen();
                    break;
                case "Werewolf":
                    _werewolf.Screen();
                    break;
                case "Hunter":
                    _hunter.Screen();
                    break;
                case "Mage":
                    _mage.Screen();
                    break;
                case "Possessed":
                    _possessed.Screen();
                    break;
                case "Human":
                    _human.Screen();
                    break;
                default:
                    break;
            }
        }

        public void ShowControls(bool vis)
        {
            lblCovenant.Visible = vis;
            lblClan.Visible = vis;
            ddlCovenant.Visible = vis;
            ddlClan.Visible = vis;

            if (cvMortal)
            {
                pnlNonMortal.Visible = false;
                lblDiscText.Visible = false;
                lblPrimDisc.Visible = false;
                lblSecDisc.Visible = false;
                lblTertDisc.Visible = false;
            }                
            else
            {
                pnlNonMortal.Visible = true;
                lblDiscText.Visible = true;
                lblPrimDisc.Visible = true;
                lblSecDisc.Visible = true;
                lblTertDisc.Visible = true;
            }                

            if (cvTemplate == "Werewolf")
            {
                pnlWerewolfSkillsInfo.Visible = true;
                pnlRenown.Visible = true;
            }                
            else
            {
                pnlWerewolfSkillsInfo.Visible = false;
                pnlRenown.Visible = false;
            }                

            if (cvTemplate == "Vampire")
                pnlVampireAttributeInfo.Visible = true;
            else
                pnlVampireAttributeInfo.Visible = false;
        }

        private void PopulateLists()
        {
            XPathNavigator nav = cvTemplateXml.CreateNavigator();
            XPathNodeIterator nodeIter;
            nodeIter = nav.Select("Templates/Template/@Name");

            ddlTemplate.Items.Clear();
            while (nodeIter.MoveNext())
            {
                ddlTemplate.Items.Add(nodeIter.Current.Value);
            }

            nav = cvFlawXml.CreateNavigator();
            nodeIter = nav.Select("Flaws/Flaw");

            foreach (Control lvControl in tabTraits.Controls)
            {
                if (lvControl.Name.StartsWith("ddlFlaw"))
                {
                    ((ComboBox)lvControl).Items.Clear();
                    ((ComboBox)lvControl).Items.Add("");
                    ((ComboBox)lvControl).SelectedIndexChanged += Flaw_IndexChanged;
                }
            }
            while (nodeIter.MoveNext())
            {
                foreach (Control lvControl in tabTraits.Controls)
                {
                    if (lvControl.Name.StartsWith("ddlFlaw"))
                    {
                        ((ComboBox)lvControl).Items.Add(nodeIter.Current.SelectSingleNode("@Name").Value);
                    }
                }
            }

            nav = cvMeritXml.CreateNavigator();
            nodeIter = nav.Select("Merits/Merit");
            pnlMerits.Controls.Clear();

            while (nodeIter.MoveNext())
            {
                CheckBox cbx = new CheckBox();
                cbx.Name = "cbxMerit" + nodeIter.Current.SelectSingleNode("@Name").Value.Replace(" ", String.Empty);
                cbx.Text = nodeIter.Current.SelectSingleNode("@Name").Value;
                cbx.Width = 170;
                rdoAbilityRank ar = new rdoAbilityRank();
                ar.Height = 25;
                ar.Name = "rdoMerit" + nodeIter.Current.SelectSingleNode("@Name").Value.Replace(" ", String.Empty);
                ar.RadioCount = Convert.ToInt32(nodeIter.Current.SelectSingleNode("Max").Value);
                ar.AbilityRank = Convert.ToInt32(nodeIter.Current.SelectSingleNode("Min").Value);

                cbx.CheckedChanged += cbxMerit_CheckChanged;
                cbx.MouseHover += cbxMerit_MouseHover;
                //cbx.MouseClick += cbxMerit_Click;
                ar.GotFocus += rdoMerit_Clicked;

                if (ar.RadioCount == ar.AbilityRank)
                    ar.ReadOnly = true;

                XPathNavigator mortalNav = nodeIter.Current.SelectSingleNode("Prerequisite/Mortal");
                XPathNavigator templateNav = nodeIter.Current.SelectSingleNode("Prerequisite/Template");
                XPathNavigator creationNav = nodeIter.Current.SelectSingleNode("Prerequisite/AtCreation");
                XPathNodeIterator attributeNav = nodeIter.Current.Select("Prerequisite/Attribute");
                XPathNodeIterator skillNav = nodeIter.Current.Select("Prerequisite/Skill");

                if (creationNav != null &&
                    ((creationNav.ValueAsBoolean && !cvCreation) ||
                    (!creationNav.ValueAsBoolean && cvCreation)))
                {
                    cbx.ForeColor = Color.Red;
                    cbx.Checked = false;
                    cbx.AutoCheck = false;
                    ar.ReadOnly = true;
                }


                if (mortalNav != null &&
                    ((mortalNav.ValueAsBoolean && !cvMortal) ||
                    (!mortalNav.ValueAsBoolean && cvMortal)))
                {
                    cbx.ForeColor = Color.Red;
                    cbx.Checked = false;
                    cbx.AutoCheck = false;
                    ar.ReadOnly = true;
                }

                if (templateNav != null && templateNav.Value != cvTemplate)
                {
                    cbx.ForeColor = Color.Red;
                    cbx.Checked = false;
                    cbx.AutoCheck = false;
                    ar.ReadOnly = true;
                }

                if (attributeNav.Count > 0)
                {
                    while (attributeNav.MoveNext())
                    {
                        if (((rdoAbilityRank)tabStats.Controls.Find("rdo" + attributeNav.Current.Value, true)[0]).AbilityRank <
                            attributeNav.Current.SelectSingleNode("@Value").ValueAsInt)
                        {
                            cbx.ForeColor = Color.Red;
                            cbx.Checked = false;
                            cbx.AutoCheck = false;
                            ar.ReadOnly = true;
                        }
                    }
                }

                if (skillNav.Count > 0)
                {
                    while (skillNav.MoveNext())
                    {
                        if (((rdoAbilityRank)tabSkills.Controls.Find("rdo" + skillNav.Current.Value, true)[0]).AbilityRank <
                            skillNav.Current.SelectSingleNode("@Value").ValueAsInt)
                        {
                            cbx.ForeColor = Color.Red;
                            cbx.Checked = false;
                            cbx.AutoCheck = false;
                            ar.ReadOnly = true;
                        }
                    }
                }

                pnlMerits.Controls.Add(cbx);
                pnlMerits.Controls.Add(ar);
                pnlMerits.SetFlowBreak(ar, true);
            }                        
        }        

        private bool ValidatePreRequisites(XPathNodeIterator nodeIter)
        {
            Boolean lvMeritBool = true;
            Boolean lvCovenantBool = true;
            XPathNavigator nodePreReq = nodeIter.Current.SelectSingleNode("Prerequisite");
            if (nodePreReq != null)
            {
                XPathNodeIterator nodeIterPreReq = nodePreReq.SelectChildren(XPathNodeType.All);

                while (nodeIterPreReq.MoveNext())
                {
                    XPathNavigator wNav = nodeIterPreReq.Current;
                    switch (wNav.Name)
                    {
                        case "Merit":                            
                            for (int i = 0; i < cvMerits.Count; i++)
                            {
                                if (cvMerits[i][0, 0] != wNav.Value ||
                                    Convert.ToInt32(cvMerits[i][0, 1]) < wNav.SelectSingleNode("@Level").ValueAsInt)
                                    lvMeritBool = false;
                                else
                                {
                                    lvMeritBool = true;
                                    break;
                                }
                            }
                            break;
                        case "Covenant":
                            if (ddlCovenant.SelectedItem == null)
                            {
                                lvCovenantBool = false;
                                break;
                            }
                            if (wNav.Value != ddlCovenant.SelectedItem.ToString())
                                lvCovenantBool = false;
                            else
                            {
                                lvCovenantBool = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return lvMeritBool && lvCovenantBool;
        }        

        private void PopulateSubLists(string pvTemplate)
        {
            ddlClan.Items.Clear();
            ddlCovenant.Items.Clear();
            ddlVice.Items.Clear();
            ddlVirtue.Items.Clear();
           
            XPathNavigator nav = cvClanXml.CreateNavigator();
            XPathNodeIterator nodeIter;
            nodeIter = nav.Select("Clans/Template[@Name='" + pvTemplate + "']/Clan");

            while (nodeIter.MoveNext())
            {                
                ddlClan.Items.Add(nodeIter.Current.SelectSingleNode("@Name").Value);
            }
           
            nav = cvCovenantXml.CreateNavigator();
            nodeIter = nav.Select("Covenants/Template[@Name='" + pvTemplate + "']/Covenant");

            while (nodeIter.MoveNext())
            {               
                ddlCovenant.Items.Add(nodeIter.Current.SelectSingleNode("@Name").Value);
            }
            
            nav = cvViceXml.CreateNavigator();
            nodeIter = nav.Select("Vices/Vice");

            while (nodeIter.MoveNext())
            {
                ddlVice.Items.Add(nodeIter.Current.SelectSingleNode("@Name").Value);
            }
            
            nav = cvVirtueXml.CreateNavigator();
            nodeIter = nav.Select("Virtues/Virtue");

            while (nodeIter.MoveNext())
            {
                ddlVirtue.Items.Add(nodeIter.Current.SelectSingleNode("@Name").Value);
            }            
        }                

        private void ShowHideTabs(string pvTemplate)
        {
            XPathNavigator nav = cvTemplateXml.CreateNavigator();
            XPathNodeIterator nodeIter;
            nodeIter = nav.Select("Templates/Template[@Name='" + pvTemplate + "']/Remove/Tab");

            while (nodeIter.MoveNext())
            {
                if (tabCreate.TabPages.ContainsKey(nodeIter.Current.SelectSingleNode("@Name").Value)) tabCreate.TabPages.Remove(tabCreate.TabPages[nodeIter.Current.SelectSingleNode("@Name").Value]);
            }

            nodeIter = nav.Select("Templates/Template[@Name='" + pvTemplate + "']/Add/Tab");

            while (nodeIter.MoveNext())
            {
                if (!tabCreate.TabPages.ContainsKey(nodeIter.Current.SelectSingleNode("@Name").Value))
                {
                    tabCreate.TabPages.Add(cvTabPages.Find(x => x.Name == nodeIter.Current.SelectSingleNode("@Name").Value));
                }
            }

            nodeIter = nav.Select("Templates/Template[@Name='" + pvTemplate + "']/Mortal");

            while (nodeIter.MoveNext())
            {
                if (nodeIter.Current.Value == "True")
                    pnlNonMortal.Visible = false;
                else
                    pnlNonMortal.Visible = true;
            }
        }

        private void rdoAbilityRank_Click()
        {           
            PopulateLists();
            UpdateStats();            
        }
        #endregion        

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPlayer.Text))
            {
                lblMessage.Text = "Please enter the player's name";
                lblMessage.Visible = true;
                return;
            }
            if (String.IsNullOrEmpty(txtName.Text))
            {
                lblMessage.Text = "Please enter a name for the character";
                lblMessage.Visible = true;
                return;
            }
            if (String.IsNullOrEmpty(cvImage))
            {
                cvImage = Global.CharacterImageFolder + "silhouette.jpg";
            }
            if (!String.IsNullOrEmpty(Class.Create.ErrorHandler.Errors.ToString()))
            {
                lblMessage.Text = Class.Create.ErrorHandler.Errors.ToString();
                lblMessage.Visible = true;
                return;
            }            

            if (!cvCreation)
            {
                XPathDocument xDoc = new XPathDocument(Global.CharacterFolder + Player.Name + ".xml");
                cvCloneEquip = xDoc.CreateNavigator().SelectSingleNode("Character/Equipment");
                cvCloneVehicles = xDoc.CreateNavigator().SelectSingleNode("Character/Vehicles");
            }
            else
            {
                if (!File.Exists(Global.CharacterImageFolder + cvImage))
                {
                    imgCharacter.Image.Save(Global.CharacterImageFolder + cvImage);
                }               
            }
            
            XmlTextWriter textWriter = new XmlTextWriter(Global.CharacterFolder + txtName.Text + ".xml", null);
            textWriter.WriteStartDocument();

            textWriter.WriteStartElement("Character");

            textWriter.WriteStartElement("Background");
            textWriter.WriteStartElement("Name");
            textWriter.WriteString(txtName.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Type");
            textWriter.WriteString(ddlTemplate.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Player");
            textWriter.WriteString(txtPlayer.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Experience");
            textWriter.WriteString("0");
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Concept");
            textWriter.WriteString(txtConcept.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Clan");
            textWriter.WriteString(ddlClan.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Virtue");
            textWriter.WriteString(ddlVirtue.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Vice");
            textWriter.WriteString(ddlVice.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Covenant");
            textWriter.WriteString(ddlCovenant.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Coterie");
            textWriter.WriteString("None");
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Chronicle");
            textWriter.WriteString(txtChronicle.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Gender");
            textWriter.WriteString(ddlGender.Text);
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Attributes");
            textWriter.WriteStartElement("Willpower");
            textWriter.WriteStartElement("Max");
            textWriter.WriteString(rdoWillpower.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Current");
            textWriter.WriteString(rdoWillpower.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Humanity");
            textWriter.WriteString(rdoHumanity.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Health");
            textWriter.WriteStartElement("Max");
            textWriter.WriteString(rdoHealth.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Bash");
            textWriter.WriteString("0");
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Lethal");
            textWriter.WriteString("0");
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Aggravated");
            textWriter.WriteString("0");
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("BloodPotency");
            textWriter.WriteString(rdoPotency.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Vitae");
            textWriter.WriteString((rdoVitae1.AbilityRank + rdoVitae2.AbilityRank).ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Size");
            textWriter.WriteString(lblSize.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Defense");
            textWriter.WriteString(lblDefense.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Initiative");
            textWriter.WriteString(lblInit.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Speed");
            textWriter.WriteString(lblSpeed.Text);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Armor");
            textWriter.WriteString("0");
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Stats");
            textWriter.WriteStartElement("Intelligence");
            textWriter.WriteString(rdoIntelligence.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Wits");
            textWriter.WriteString(rdoWits.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Resolve");
            textWriter.WriteString(rdoResolve.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Strength");
            textWriter.WriteString(rdoStrength.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Dexterity");
            textWriter.WriteString(rdoDexterity.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Stamina");
            textWriter.WriteString(rdoStamina.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Presence");
            textWriter.WriteString(rdoPresence.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Manipulation");
            textWriter.WriteString(rdoManipulation.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Composure");
            textWriter.WriteString(rdoComposure.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Academics");
            textWriter.WriteString(rdoAcademics.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Computer");
            textWriter.WriteString(rdoComputer.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Investigation");
            textWriter.WriteString(rdoInvestigation.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Medicine");
            textWriter.WriteString(rdoMedicine.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Occult");
            textWriter.WriteString(rdoOccult.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Politics");
            textWriter.WriteString(rdoPolitics.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Science");
            textWriter.WriteString(rdoScience.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Athletics");
            textWriter.WriteString(rdoAthletics.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Brawl");
            textWriter.WriteString(rdoBrawl.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Drive");
            textWriter.WriteString(rdoDrive.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Firearms");
            textWriter.WriteString(rdoFirearms.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Stealth");
            textWriter.WriteString(rdoStealth.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Survival");
            textWriter.WriteString(rdoSurvival.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Weaponry");
            textWriter.WriteString(rdoWeaponry.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("AnimalKen");
            textWriter.WriteString(rdoAnimalKen.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Empathy");
            textWriter.WriteString(rdoEmpathy.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Intimidation");
            textWriter.WriteString(rdoIntimidation.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Persuasion");
            textWriter.WriteString(rdoPersuasion.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Socialize");
            textWriter.WriteString(rdoSocialize.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Streetwise");
            textWriter.WriteString(rdoStreetwise.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Subterfuge");
            textWriter.WriteString(rdoSubterfuge.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Expression");
            textWriter.WriteString(rdoExpression.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Larceny");
            textWriter.WriteString(rdoLarceny.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Crafts");
            textWriter.WriteString(rdoCrafts.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Specializations"); 
            foreach (string lvBox in chkListSpecialties.CheckedItems)
            {
                textWriter.WriteStartElement(lvBox.Substring(0,lvBox.IndexOf(":")));
                textWriter.WriteString(lvBox.Substring(lvBox.LastIndexOf(":") + 1));
                textWriter.WriteEndElement();
            }
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Merits");
            foreach (Control lvControl in pnlMerits.Controls)
            {
                if (lvControl.Name.StartsWith("cbxMerit") && ((CheckBox) lvControl).Checked)
                {
                    string lvMerit = ((CheckBox)lvControl).Text;
                    textWriter.WriteStartElement("Merit");
                    textWriter.WriteStartAttribute("Name");
                    textWriter.WriteString(lvMerit);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteStartAttribute("Level");
                    textWriter.WriteString(((rdoAbilityRank)pnlMerits.Controls.Find("rdoMerit" + lvControl.Text.Replace(" ", ""), true)[0]).AbilityRank.ToString());
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();
                }
            }
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Flaws");
            foreach (Control lvControl in tabTraits.Controls)
            {
                if (lvControl.Name.StartsWith("ddlFlaw") && ((ComboBox)lvControl).SelectedIndex != -1 && ((ComboBox)lvControl).Text != "")
                {
                    string lvFlaw = ((ComboBox)lvControl).Text;
                    textWriter.WriteStartElement("Flaw");
                    textWriter.WriteStartAttribute("Name");
                    textWriter.WriteString(lvFlaw);
                    textWriter.WriteEndAttribute();
                    //textWriter.WriteString(lvFlaw);
                    textWriter.WriteEndElement();
                }
            }
            textWriter.WriteEndElement();

            switch (cvTemplate)
            {
                case "Vampire":
                    _vampire.Save(textWriter);
                    break;
                case "Werewolf":
                    _werewolf.Save(textWriter);
                    break;
                case "Mage":
                    _mage.Save(textWriter);
                    break;
                case "Hunter":
                    //TODO _hunter.Save(textWriter);
                    break;
                case "Possessed":
                    //TODO _possessed.Save(textWriter);
                    break;
                default:
                    break;
            }

            if (!cvCreation)
            {
                textWriter.WriteString(cvCloneEquip.InnerXml);
                textWriter.WriteString(cvCloneVehicles.InnerXml);
            }
            else
            {
                textWriter.WriteStartElement("Equipment");
                textWriter.WriteStartElement("Cash");
                textWriter.WriteString(numCash.Value.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Armors");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Weapons");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Items");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("Vehicles");
                textWriter.WriteEndElement();
            }                      

            textWriter.WriteStartElement("Image");
            textWriter.WriteString(cvImage);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Statuses");
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Boost");
            textWriter.WriteEndElement();

            textWriter.WriteEndDocument();
            textWriter.Close();

            lblMessage.Text = "Save Character Successful!";
            lblMessage.ForeColor = Color.LawnGreen;
            lblMessage.Visible = true;
        }        
        #endregion

        #region Specialty Skills
        private void ddlAcademics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Academics:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlAcademics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Academics:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlComputer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Computer:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlComputer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Computer:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlCrafts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Crafts:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlCrafts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Crafts:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlInvestigation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Investigation:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlInvestigation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Investigation:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Medicine:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlMedicine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Medicine:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlOccult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Occult:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlOccult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Occult:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlPolitics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Politics:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlPolitics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Politics:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlScience_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Science:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlScience_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Science:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlAthletics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Athletics:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlAthletics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Athletics:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlBrawl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Brawl:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlBrawl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Brawl:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Drive:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlDrive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Drive:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlFirearms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Firearms:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlFirearms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Firearms:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlLarceny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Larceny:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlLarceny_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Larceny:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlStealth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Stealth:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlStealth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Stealth:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlSurvival_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Survival:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlSurvival_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Survival:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlWeaponry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Weaponry:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlWeaponry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Weaponry:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlAnimalKen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Animal Ken:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlAnimalKen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Animal Ken:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlEmpathy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Empathy:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlEmpathy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Empathy:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlExpression_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Expression:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlExpression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Expression:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlIntimidation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Intimidation:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlIntimidation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Intimidation:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlPersuasion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Persuasion:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlPersuasion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Persuasion:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlSocialize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Socialize:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlSocialize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Socialize:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlStreetwise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Streetwise:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlStreetwise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Streetwise:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlSubterfuge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                chkListSpecialties.Items.Add("Subterfuge:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void ddlSubterfuge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                chkListSpecialties.Items.Add("Subterfuge:" + ((ComboBox)sender).Text);
                ((ComboBox)sender).Text = String.Empty;
                chkListSpecialties.SetItemCheckState(chkListSpecialties.Items.Count - 1, CheckState.Checked);
            }
        }

        private void chkListSpecialties_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < chkListSpecialties.Items.Count; i++)
            {
                if (chkListSpecialties.SelectedIndex == i)
                {
                    chkListSpecialties.Items.RemoveAt(i);
                }

            }
        }

        private void PurchaseSpecialty()
        {
            if (!cvCreation)
            {

            }
        }
        #endregion                

        #region Merit Control
        private void cbxMerit_CheckChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            rdoAbilityRank rank = (rdoAbilityRank)this.Controls.Find("rdoMerit" + cbx.Text.Replace(" ", String.Empty), true)[0];

            if (cbx.Checked)
                cvMeritTotal += rank.AbilityRank;
            else
                cvMeritTotal -= rank.AbilityRank;

            PopMeritsList();

            lblPrimMerit.Text = (cvMeritPool - cvMeritTotal - cvPotencyTotal).ToString();
        }

        private void cbxMerit_MouseHover(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            cbx.Cursor = Cursors.Help;
            cbxMerit_Click(sender);
        }

        private void cbxMerit_Click(object sender) //, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //    return;
            CheckBox cbx = (CheckBox)sender;
            XPathNavigator xNav = cvMeritXml.CreateNavigator().SelectSingleNode(String.Format("Merits/Merit[@Name='{0}']", cbx.Text));

            XPathNodeIterator xAttributeNodeIter = xNav.Select("Prerequisite/Attribute");
            XPathNodeIterator xSkillNodeIter = xNav.Select("Prerequisite/Skill");
            XPathNavigator xTemplateNav = xNav.SelectSingleNode("Prerequisite/Template");
            XPathNavigator xMortalNav = xNav.SelectSingleNode("Prerequisite/Mortal");
            XPathNavigator xCreationNav = xNav.SelectSingleNode("Prerequisite/AtCreation");

            lblActiveItem.Text = cbx.Text;
            //txtDescription.Rtf = Global.PlainTextToRtf(xNav.SelectSingleNode(String.Format("Merits/Merit[@Name='{0}']/Description", cbx.Text)).Value);
            string rtf = RtfHelper.Begin();

            if (xAttributeNodeIter.Count > 0 || xSkillNodeIter.Count > 0 || xTemplateNav != null || xMortalNav != null)
            {
                RtfHelper.Bold(ref rtf, "Prerequisites");
                RtfHelper.EndLine(ref rtf);

                if (xCreationNav != null &&
                    ((xCreationNav.ValueAsBoolean && !cvCreation) ||
                    (!xCreationNav.ValueAsBoolean && cvCreation)))
                {
                    RtfHelper.Bold(ref rtf, "At Creation Only");
                    RtfHelper.EndLine(ref rtf);
                }
                else if (xCreationNav != null)
                {
                    RtfHelper.ConvertText(ref rtf, "At Creation Only");
                    RtfHelper.EndLine(ref rtf);
                }

                if (xMortalNav != null &&
                    ((xMortalNav.ValueAsBoolean && !cvMortal) ||
                    (!xMortalNav.ValueAsBoolean && cvMortal)))
                {
                    RtfHelper.Bold(ref rtf, "Mortal");
                    RtfHelper.EndLine(ref rtf);
                }
                else if (xMortalNav != null)
                {
                    RtfHelper.ConvertText(ref rtf, "Mortal");
                    RtfHelper.EndLine(ref rtf);
                }

                if (xTemplateNav != null && xTemplateNav.Value != cvTemplate)
                {
                    RtfHelper.Bold(ref rtf, xTemplateNav.Value);
                    RtfHelper.EndLine(ref rtf);
                }
                else if (xTemplateNav != null)
                {
                    RtfHelper.ConvertText(ref rtf, xTemplateNav.Value);
                    RtfHelper.EndLine(ref rtf);
                }

                if (xAttributeNodeIter.Count > 0)
                {
                    while (xAttributeNodeIter.MoveNext())
                    {
                        if (((rdoAbilityRank)tabStats.Controls.Find("rdo" + xAttributeNodeIter.Current.Value, true)[0]).AbilityRank <
                            xAttributeNodeIter.Current.SelectSingleNode("@Value").ValueAsInt)
                        {
                            RtfHelper.Bold(ref rtf, xAttributeNodeIter.Current.Value + ":" + xAttributeNodeIter.Current.SelectSingleNode("@Value"));
                            RtfHelper.EndLine(ref rtf);
                        }
                        else
                        {
                            RtfHelper.ConvertText(ref rtf, xAttributeNodeIter.Current.Value + ":" + xAttributeNodeIter.Current.SelectSingleNode("@Value"));
                            RtfHelper.EndLine(ref rtf);
                        }
                    }
                }

                if (xSkillNodeIter.Count > 0)
                {
                    while (xSkillNodeIter.MoveNext())
                    {
                        if (((rdoAbilityRank)tabSkills.Controls.Find("rdo" + xSkillNodeIter.Current.Value, true)[0]).AbilityRank <
                            xSkillNodeIter.Current.SelectSingleNode("@Value").ValueAsInt)
                        {
                            RtfHelper.Bold(ref rtf, xSkillNodeIter.Current.Value + ":" + xSkillNodeIter.Current.SelectSingleNode("@Value"));
                            RtfHelper.EndLine(ref rtf);
                        }
                        else
                        {
                            RtfHelper.ConvertText(ref rtf, xSkillNodeIter.Current.Value + ":" + xSkillNodeIter.Current.SelectSingleNode("@Value"));
                            RtfHelper.EndLine(ref rtf);
                        }
                    }
                }

                RtfHelper.EndLine(ref rtf);
            }
            
            RtfHelper.ConvertText(ref rtf, xNav.SelectSingleNode("Description").Value);
            RtfHelper.End(ref rtf);
            txtDescription.Rtf = rtf;
        }

        private void rdoMerit_Clicked(object sender, EventArgs e)
        {
            PopMeritsList();
        }

        private void PopMeritsList()
        {
            CheckBox cbx;
            rdoAbilityRank rank;
            cvMerits.Clear();
            foreach (Control lvControl in pnlMerits.Controls)
            {
                if (lvControl.Name.StartsWith("cbxMerit") && ((CheckBox) lvControl).Checked)
                {
                    cbx = ((CheckBox) lvControl);
                    rank = (rdoAbilityRank) this.Controls.Find("rdoMerit" + cbx.Text.Replace(" ", String.Empty), true)[0];
                    cvMerits.Add(new string[,] {{cbx.Text, rank.AbilityRank.ToString()}});
                }
            }
            AssignAllBoosts();
        }

        private void AssignMeritBoosts()
        {
            foreach (String[,] merit in cvMerits)
            {
                XPathNavigator meritNav =
                    cvMeritXml.CreateNavigator().SelectSingleNode(String.Format("Merits/Merit[@Name='{0}']/Benefit", merit.GetValue(0,0)));
                if (meritNav != null)
                {
                    XPathNodeIterator benefitStatIter = meritNav.SelectChildren(XPathNodeType.All);
                    while (benefitStatIter.MoveNext())
                    {
                        string lvBoost = benefitStatIter.Current.Value;
                        int lvIncrease = benefitStatIter.Current.SelectSingleNode("@Value").ValueAsInt;
                        int lvMultiplier = Convert.ToInt32(merit.GetValue(0, 1));
                        bool lvByRank = benefitStatIter.Current.SelectSingleNode("@PerRank").ValueAsBoolean;

                        UpdateBoosts(lvBoost, lvByRank, lvIncrease, lvMultiplier);
                    }
                }                
            }

            UpdateStats();
        }        
        #endregion

        #region Flaw Control
        private void Flaw_IndexChanged(object sender, EventArgs e)
        {
            ComboBox flawCombo = ((ComboBox)sender);
            if (flawCombo.SelectedIndex > 0 && flawCombo.SelectedItem.ToString() != "")
            {
                lblActiveItem.Text = flawCombo.SelectedItem.ToString();
                XPathNavigator flawNav = cvFlawXml.CreateNavigator().SelectSingleNode(String.Format("Flaws/Flaw[@Name='{0}']", flawCombo.SelectedItem.ToString()));                
                txtDescription.Text = flawNav.SelectSingleNode("Description").Value;
            }
            
            cvFlaws.Clear();

            if (ddlFlaw1.SelectedIndex > 0 && ddlFlaw1.SelectedItem.ToString() != "")
                cvFlaws.Add(new string[] {ddlFlaw1.SelectedItem.ToString()});
            if (ddlFlaw2.SelectedIndex > 0 && ddlFlaw2.SelectedItem.ToString() != "")
                cvFlaws.Add(new string[] { ddlFlaw2.SelectedItem.ToString() });
            if (ddlFlaw3.SelectedIndex > 0 && ddlFlaw3.SelectedItem.ToString() != "")
                cvFlaws.Add(new string[] { ddlFlaw3.SelectedItem.ToString() });

            AssignAllBoosts();
        }

        private void AssignFlawDetriments()
        {
            //TODO
            //ResetBoosts();
            //AssignMeritBoosts();

            foreach (string[] flaw in cvFlaws)
            {
                XPathNavigator flawNav =
                    cvFlawXml.CreateNavigator().SelectSingleNode(String.Format("Flaws/Flaw[@Name='{0}']/Detriment", flaw[0]));
                if (flawNav != null)
                {
                    XPathNodeIterator detrimentIter = flawNav.SelectChildren(XPathNodeType.All);
                    while (detrimentIter.MoveNext())
                    {
                        string lvDetriment = detrimentIter.Current.Value;
                        int lvDecrease = detrimentIter.Current.SelectSingleNode("@Value").ValueAsInt * -1;

                        UpdateBoosts(lvDetriment, false, lvDecrease, 1);
                    }
                }
            }

            UpdateStats();
        }
        #endregion

        #region Label Help
        private void WireEventHandlers()
        {
            GetAllControls(this);
            foreach (Label aLabel in ControlList)
            {
                aLabel.MouseClick += label_Click;
                aLabel.MouseHover += label_Hover;
            }
        }

        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c is Label) ControlList.Add(c);
            }
        }

        public void label_Hover(object sender, EventArgs e)
        {
            Control lbl = (Control)sender;
            lbl.Cursor = Cursors.Help;           
        }

        public void label_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            Control lbl = (Control)sender;
            XPathNavigator nav = cvIndexXml.CreateNavigator().SelectSingleNode(String.Format("Index/Label[@Name='{0}']",lbl.Name));
            XPathNavigator templateNav = cvIndexXml.CreateNavigator().SelectSingleNode(String.Format("Index/Label[@Name='{0}']/Template[@Name='{1}']", lbl.Name, cvTemplate));

            if (templateNav != null)
            {
                lblActiveItem.Text = templateNav.SelectSingleNode("Display").Value;
                string rtf = RtfHelper.Begin();
                RtfHelper.ConvertText(ref rtf, templateNav.SelectSingleNode("Description").Value);
                RtfHelper.End(ref rtf);
                txtDescription.Rtf = rtf;
            }
            else if (nav != null)
            {
                lblActiveItem.Text = nav.SelectSingleNode("Display").Value;
                string rtf = RtfHelper.Begin();
                RtfHelper.ConvertText(ref rtf, nav.SelectSingleNode("Description").Value);
                RtfHelper.End(ref rtf);
                txtDescription.Rtf = rtf;
            }
        }
        #endregion       

        #region Handle Boosts
        private void AssignAllBoosts()
        {
            ResetBoosts();
            AssignMeritBoosts();
            AssignFlawDetriments();
        }

        private void ResetBoosts()
        {
            _Speed = 0;
            _Initiative = 0;
            _Defense = 0;
            _Size = 0;
            _Health = 0;
            _Willpower = 0;
            _Humanity = 0;
        }

        private void UpdateBoosts(string lvBoost, bool lvByRank, int lvIncrease, int lvMultiplier)
        {
            switch (lvBoost)
            {
                case "Size":
                    _Size += lvByRank ? lvIncrease * lvMultiplier : lvIncrease;
                    break;
                case "Speed":
                    _Speed += lvByRank ? lvIncrease * lvMultiplier : lvIncrease;
                    break;
                case "Defense":
                    _Defense += lvByRank ? lvIncrease * lvMultiplier : lvIncrease;
                    break;
                case "Initiative":
                    _Initiative += lvByRank ? lvIncrease * lvMultiplier : lvIncrease;
                    break;
                case "Health":
                    _Health += lvByRank ? lvIncrease * lvMultiplier : lvIncrease;
                    break;
                case "Willpower":
                    _Willpower += lvByRank ? lvIncrease * lvMultiplier : lvIncrease;
                    break;
                case "Humanity":
                    _Humanity += lvByRank ? lvIncrease * lvMultiplier : lvIncrease;
                    break;
            }
        }
        #endregion

        #region User Actions
        private void rdoPotency_rdoAbilityRankClicked()
        {
            cvPotencyTotal = rdoPotency.AbilityRank * 3;
            _BloodPotency = rdoPotency.AbilityRank - 1;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string lvImageLoc;

            ofdCharImage.InitialDirectory = Global.CharacterImageFolder;
            ofdCharImage.RestoreDirectory = true;

            if (ofdCharImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lvImageLoc = ofdCharImage.FileName;
                    cvImage = ofdCharImage.SafeFileName;
                    imgCharacter.ImageLocation = lvImageLoc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void ddlCovenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateLists();

            switch (cvTemplate)
            {
                case "Werewolf":
                    _werewolf.SetAuspiceSkills(ddlCovenant.Text);
                    if (!String.IsNullOrEmpty(ddlClan.Text))
                    {
                        _werewolf.SetTribeGift(ddlClan.Text);
                        _werewolf.SetTribeRenown(ddlClan.Text);
                    }
                    break;
                default:
                    break;
            }
        }

        private void ddlClan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            XPathNavigator xNav;

            switch (cvTemplate)
            {
                case "Werewolf":
                    xNav = cvClanXml.CreateNavigator().SelectSingleNode(String.Format("Clans/Template[@Name='{0}']/Clan[@Name='{1}']", "Werewolf", cbx.Text));
                    _werewolf.SetTribeGift(ddlClan.Text);
                    _werewolf.SetTribeRenown(ddlClan.Text);
                    break;
                case "Mage":
                    xNav = cvClanXml.CreateNavigator().SelectSingleNode(String.Format("Clans/Template[@Name='{0}']/Clan[@Name='{1}']", "Mage", cbx.Text));
                    break;
                case "Hunter":
                    xNav = cvClanXml.CreateNavigator().SelectSingleNode(String.Format("Clans/Template[@Name='{0}']/Clan[@Name='{1}']", "Hunter", cbx.Text));
                    break;
                default:
                    xNav = cvClanXml.CreateNavigator().SelectSingleNode(String.Format("Clans/Template[@Name='{0}']/Clan[@Name='{1}']", "Vampire", cbx.Text));
                    _vampire.SetClanDisciplines(ddlClan.Text);
                    _vampire.SetClanAttributes(ddlClan.Text);
                    break;
            }            

            lblActiveItem.Text = cbx.Text;
            string rtf = RtfHelper.Begin();
            RtfHelper.ConvertText(ref rtf, xNav.SelectSingleNode("Description").Value);
            RtfHelper.End(ref rtf);
            txtDescription.Rtf = rtf;
        }

        private void tabCreate_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Global.ShowLoadForm();
        }
        #endregion

        #region Potency
        private void rdoPotency_Click(object sender, EventArgs e)
        {
            if (cvCreation)
            {
                cvMeritTotal = cvMeritPool - (rdoPotency.AbilityRank * 3) - 3;
            }
        }
        #endregion        
    }
}
