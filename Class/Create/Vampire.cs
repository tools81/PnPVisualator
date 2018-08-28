using Pen_and_Paper_Visualator.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class.Create
{
    class Vampire
    {
        private CreateCharacter _formCreation;        
        private XPathDocument cvDisciplineXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Discipline.xml");
        private XPathDocument cvDevotionXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Devotions.xml");
        private XPathDocument cvClanXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Clans.xml");
        private XPathDocument cvCovenantXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Covenants.xml");
        private XPathDocument cvTemplateXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Templates.xml");
        private string _Disc_Img_Folder = Properties.Settings.Default.DataLocation + @"Discipline_Images\";

        private int _disciplineTotal;
        private int _bloodPotencyTotal;
        private int _devotionTotal;

        private const int _knownDisciplineCost = 5;
        private const int _unknownDisciplineCost = 7;
        private const int _lesserDisciplineCost = 2;
        private const int _bloodPotencyCost = 8;

        public Vampire(CreateCharacter createChar)
        {
            _formCreation = createChar;            
        }

        public void Populate()
        {
            PopulateDisciplines();
            PopulateDevotions();
        }

        public void Load()
        {
            LoadCharacterDisciplines();
            SetClanDisciplines(Player.Clan);
            SetClanAttributes(Player.Clan);
            LoadBloodPotency();            
        }

        public void Screen()
        {
            _formCreation.lblCovenant.Text = "Covenant";
            _formCreation.lblClan.Text = "Clan";
            _formCreation.lblDiscText.Text = "Discipline:";
            _formCreation.lblHumanity.Text = "Humanity";
            _formCreation.lblPotency.Text = "Blood Potency";
            _formCreation.lblVitae.Text = "Vitae";
            _formCreation.ShowControls(true);
        }

        public void Save(XmlTextWriter xmlTextWriter)
        {
            SaveDisciplines(xmlTextWriter);
            SaveDevotions(xmlTextWriter);
        }

        public void ExperienceCount()
        {
            int lvDiscTotal = DisciplineTotal();
            int lvPotencyTotal = BloodPotencyTotal();
            int lvDevotionTotal = DevotionTotal();

            Player.Experience += _disciplineTotal - lvDiscTotal;
            _disciplineTotal = lvDiscTotal;
            Player.Experience += _bloodPotencyTotal - lvPotencyTotal;
            _bloodPotencyTotal = lvPotencyTotal;
            Player.Experience += _devotionTotal - lvDevotionTotal;
            _devotionTotal = lvDevotionTotal;
        }

        #region Disciplines
        private void PopulateDisciplines()
        {
            //TODO: The Coils of the Dragon
            XPathNavigator nav = cvDisciplineXml.CreateNavigator();
            XPathNodeIterator nodeIter = nav.Select("Disciplines/Discipline");
            _formCreation.pnlDisciplines.Controls.Clear();

            while (nodeIter.MoveNext())
            {
                Label lbl = new Label();
                lbl.Name = "lblDisc" + nodeIter.Current.SelectSingleNode("@Name").Value.Replace(" ", String.Empty);
                lbl.Text = nodeIter.Current.SelectSingleNode("@Name").Value;
                lbl.Height = 28;
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                rdoAbilityRank ar = new rdoAbilityRank();
                ar.Name = "rdoDisc" + nodeIter.Current.SelectSingleNode("@Name").Value.Replace(" ", String.Empty);
                ar.RadioCount = 5;
                ar.AbilityRank = 0;
                ar.Height = 25;

                lbl.MouseHover += lblDisc_MouseHover;
                lbl.MouseClick += lblDisc_Click;
                ar.GotFocus += rdoDisc_Clicked;

                _formCreation.pnlDisciplines.Controls.Add(lbl);
                _formCreation.pnlDisciplines.Controls.Add(ar);
                _formCreation.pnlDisciplines.SetFlowBreak(ar, true);
            }
        }

        public void LoadCharacterDisciplines()
        {
            foreach (KeyValuePair<string, int> d in Player.Discipline)
            {
                if (!String.IsNullOrEmpty(d.Key))
                {
                    rdoAbilityRank rdoDisc = (rdoAbilityRank)_formCreation.pnlDisciplines.Controls.Find("rdoDisc" + d.Key.Replace(" ", String.Empty), true)[0];
                    rdoDisc.AbilityRank = d.Value;
                    rdoDisc.Refresh();
                }
            }

            _disciplineTotal = DisciplineTotal();
        }

        public void SaveDisciplines(XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Disciplines");

            foreach (Control lvControl in _formCreation.pnlDisciplines.Controls)
            {
                if (lvControl.GetType() == typeof(rdoAbilityRank) && ((rdoAbilityRank)lvControl).AbilityRank > 0)
                {
                    rdoAbilityRank ar = ((rdoAbilityRank)lvControl);
                    Control lbl = _formCreation.pnlDisciplines.Controls.Find("lblDisc" + ar.Name.Replace("rdoDisc", String.Empty), true)[0];

                    textWriter.WriteStartElement("Discipline");
                    textWriter.WriteStartAttribute("Name");
                    textWriter.WriteString(lbl.Text);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteStartAttribute("Level");
                    textWriter.WriteString(ar.AbilityRank.ToString());
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();
                }
            }

            textWriter.WriteEndElement();
        }

        private int DisciplineTotal()
        {
            int sum = 0;

            foreach (Control cntrl in _formCreation.pnlDisciplines.Controls)
            {
                if (cntrl.GetType() == typeof(Label))
                {
                    Label lbl = (Label)cntrl;
                    rdoAbilityRank rank = (rdoAbilityRank)_formCreation.pnlDisciplines.Controls.Find("rdoDisc" + lbl.Text.Replace(" ", String.Empty), true)[0];

                    XPathNodeIterator clanDiscIter = cvClanXml.CreateNavigator().Select(String.Format("Clans/Template[@Name='{0}']/Clan[@Name='{1}']/Disciplines/Discipline", Player.Template, Player.Clan));

                    bool match = false;
                    while (clanDiscIter.MoveNext())
                    {
                        match = clanDiscIter.Current.Value == lbl.Text ? true : false;
                        if (match)
                            break;
                    }

                    if (lbl.Text == "Crúac" || lbl.Text == "Theban Sorcery")
                        sum += rank.AbilityRank * _lesserDisciplineCost;
                    else if (match)
                        sum += rank.AbilityRank * _knownDisciplineCost;
                    else
                        sum += rank.AbilityRank * _unknownDisciplineCost;
                }
            }

            return sum;
        }
        
        public void lblDisc_MouseHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Cursor = Cursors.Help;
        }

        public void lblDisc_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;
            Label lbl = (Label)sender;
            XPathNavigator xNav = cvDisciplineXml.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name=\"{lbl.Text}\"]");

            _formCreation.lblActiveItem.Text = lbl.Text;
            string rtf = RtfHelper.Begin();
            RtfHelper.ConvertText(ref rtf, xNav.SelectSingleNode("Description").Value);
            RtfHelper.End(ref rtf);
            _formCreation.txtDescription.Rtf = rtf;
        }

        public void rdoDisc_Clicked(object sender, EventArgs e)
        {
            rdoAbilityRank rank = (rdoAbilityRank)sender;
            String lvDiscName = rank.Name.Replace("rdoDisc", String.Empty);
            Label lbl = (Label)_formCreation.Controls.Find("lblDisc" + lvDiscName, true)[0];

            if (lbl == null)
            {
                throw new Exception();
            }
            else
            {
                if (rank.AbilityRank > 0)
                {
                    PopulateDiscDetail(lbl.Text, rank.AbilityRank);
                }
            }

            //_disciplineTotal = 0;
            //foreach (Control lvControl in _formCreation.Controls)
            //{
            //    if (lvControl.GetType() == typeof(rdoAbilityRank))
            //    {
            //        _disciplineTotal += ((rdoAbilityRank)lvControl).AbilityRank;
            //    }
            //}
        }

        public void PopulateDiscDetail(string name, int rank)
        {
            _formCreation.pnlDiscDetail.Visible = true;
            XPathNavigator nav = cvDisciplineXml.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name=\"{name}\"]/Sub[@Level='{rank}']");
            
            _formCreation.lblDiscName.Text = nav.SelectSingleNode("@LevelName").Value;
            _formCreation.lblDiscAttribute.Text = nav.SelectSingleNode("Attribute").Value;
            _formCreation.lblDiscSkill.Text = nav.SelectSingleNode("Skill").Value;
            _formCreation.lblDiscVitaeCost.Text = nav.SelectSingleNode("Vitae_Cost").Value;
            _formCreation.lblDiscWillCost.Text = nav.SelectSingleNode("Willpower_Cost").Value;
            _formCreation.txtDiscDetail.Text = nav.SelectSingleNode("Description").Value;
            nav.MoveToParent();
            _formCreation.imgDisc.ImageLocation = _Disc_Img_Folder + nav.SelectSingleNode("@Image").Value;
        }

        public void SetClanDisciplines(string lvClan)
        {
            XPathNodeIterator xClanIter = cvClanXml.CreateNavigator().Select(String.Format("Clans/Template[@Name='Vampire']/Clan[@Name='{0}']/Disciplines/Discipline", lvClan));

            foreach (Control lvControl in _formCreation.pnlDisciplines.Controls)
            {
                if (lvControl.GetType() == typeof(Label))
                    ((Label)lvControl).ForeColor = SystemColors.ControlText;
            }

            while (xClanIter.MoveNext())
            {
                foreach (Control lvControl in _formCreation.pnlDisciplines.Controls)
                {
                    if (lvControl.GetType() == typeof(Label) && lvControl.Text == xClanIter.Current.Value)
                    {
                        Label lbl = ((Label)lvControl);
                        lbl.ForeColor = Color.DarkGoldenrod;
                    }
                }
            }
        }

        public void SetClanAttributes(string lvClan)
        {
            XPathNodeIterator xClanIter = cvClanXml.CreateNavigator().Select(String.Format("Clans/Template[@Name='Vampire']/Clan[@Name='{0}']/Attributes/Attribute", lvClan));

            foreach (Control lvControl in _formCreation.tblAttributes.Controls)
            {
                if (lvControl.GetType() == typeof(Label))
                    ((Label)lvControl).ForeColor = SystemColors.ControlText;
            }

            while (xClanIter.MoveNext())
            {
                foreach (Control lvControl in _formCreation.tblAttributes.Controls)
                {
                    if (lvControl.GetType() == typeof(Label) && lvControl.Text == xClanIter.Current.Value)
                    {
                        Label lbl = ((Label)lvControl);
                        lbl.ForeColor = Color.DarkGoldenrod;
                    }
                }
            }
            //tblAttributes.Refresh();
        }
        #endregion

        #region Devotions
        private void PopulateDevotions()
        {
            XPathNavigator nav = cvDevotionXml.CreateNavigator();
            XPathNodeIterator nodeIter = nav.Select("Devotions/Devotion");
            _formCreation.pnlDevotions.Controls.Clear();

            int metPrereqs = 0;

            while (nodeIter.MoveNext())
            {
                XPathNodeIterator prereqIter = nodeIter.Current.Select("Prerequisite/Discipline");

                if (Player.Name != null)
                {
                    while (prereqIter.MoveNext())
                    {
                        foreach (KeyValuePair<string, int> d in Player.Discipline)
                        {
                            if (d.Key == prereqIter.Current.Value && d.Value >= prereqIter.Current.SelectSingleNode("@Level").ValueAsInt)
                            {
                                metPrereqs++;
                            }
                        }
                    }
                }                               

                CheckBox cbx = new CheckBox();
                cbx.Name = "cbxDevotion" + nodeIter.Current.SelectSingleNode("@Name").Value.Replace(" ", String.Empty);
                cbx.Text = nodeIter.Current.SelectSingleNode("@Name").Value;
                cbx.Width = 140;
                cbx.Height = 28;

                if (Player.Name == null || metPrereqs < prereqIter.Count)
                {
                    cbx.ForeColor = Color.Red;
                    cbx.Checked = false;
                    cbx.AutoCheck = false;
                }

                cbx.MouseHover += Devotion_Hover;
                cbx.CheckedChanged += Devotion_CheckChanged;
                Label lbl = new Label();
                lbl.Text = String.Format("({0} xp)", nodeIter.Current.SelectSingleNode("Cost").Value);
                lbl.Height = 28;
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                _formCreation.pnlDevotions.Controls.Add(cbx);
                _formCreation.pnlDevotions.Controls.Add(lbl);
                _formCreation.pnlDevotions.SetFlowBreak(lbl, true);

                metPrereqs = 0;
            }
        }

        private void Devotion_Hover(object sender, EventArgs e)
        {
            Control lbl = (Control)sender;
            XPathNavigator nav = cvDevotionXml.CreateNavigator().SelectSingleNode(String.Format("Devotions/Devotion[@Name='{0}']", lbl.Text));
            LoadDevotionDetail(nav);
        }

        private void LoadDevotionDetail(XPathNavigator nav)
        {                        
            _formCreation.lblDevotionName.Text = nav.SelectSingleNode("@Name").Value;
            _formCreation.lblDevotionAttr.Text = nav.SelectSingleNode("Attribute").Value;
            _formCreation.lblDevotionSkill.Text = nav.SelectSingleNode("Skill").Value;
            _formCreation.lblDevotionVitae.Text = nav.SelectSingleNode("Vitae_Cost").Value;
            _formCreation.lblDevotionWill.Text = nav.SelectSingleNode("Willpower_Cost").Value;
            _formCreation.lblDevotionDiscipline.Text = nav.SelectSingleNode("Discipline").Value;            
            _formCreation.imgDevotion.ImageLocation = _Disc_Img_Folder + nav.SelectSingleNode("Image").Value;
            _formCreation.pnlDevotionDetail.Visible = true;

            if (Player.Name != null)
            {
                XPathNodeIterator prereqIter = nav.Select("Prerequisite/Discipline");
                string rtf = RtfHelper.Begin();
                
                while (prereqIter.MoveNext())
                {
                    int discIndex = 99;
                    if (Player.Discipline.TryGetValue(prereqIter.Current.Value, out discIndex) && discIndex != 99)
                    {
                        RtfHelper.ConvertText(ref rtf, prereqIter.Current.Value + ":" + prereqIter.Current.SelectSingleNode("@Level"));
                        RtfHelper.EndLine(ref rtf);
                    }
                    else
                    {
                        RtfHelper.Bold(ref rtf, prereqIter.Current.Value + ":" + prereqIter.Current.SelectSingleNode("@Level"));
                        RtfHelper.EndLine(ref rtf);
                    }
                }
                RtfHelper.EndLine(ref rtf);

                RtfHelper.ConvertText(ref rtf, nav.SelectSingleNode("Description").Value);
                RtfHelper.End(ref rtf);

                _formCreation.txtDevotionDescription.Rtf = rtf;
            }
            else
                _formCreation.txtDevotionDescription.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Description").Value);
        }

        private void Devotion_CheckChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            XPathNavigator nav = cvDevotionXml.CreateNavigator().SelectSingleNode(String.Format("Devotions/Devotion[@Name='{0}']", cbx.Text));            

            if (cbx.Checked)
            {
                LoadDevotionDetail(nav);
                Player.Experience -= nav.SelectSingleNode("Cost").ValueAsInt;                
            }                
            else
            {
                _formCreation.pnlDevotionDetail.Visible = false;
                Player.Experience += nav.SelectSingleNode("Cost").ValueAsInt;
            }               
        }

        private void SaveDevotions(XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Devotions");

            foreach (Control lvControl in _formCreation.pnlDevotions.Controls)
            {
                if (lvControl.GetType() == typeof(CheckBox) && ((CheckBox)lvControl).Checked)
                {
                    CheckBox cbx = ((CheckBox)lvControl);

                    textWriter.WriteStartElement("Devotion");
                    textWriter.WriteStartAttribute("Name");
                    textWriter.WriteString(cbx.Text);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();
                }
            }

            textWriter.WriteEndElement();
        }

        private int DevotionTotal()
        {
            _formCreation.pnlDevotions.Visible = true;
            int sum = 0;

            XPathNavigator nav = cvDevotionXml.CreateNavigator();

            foreach (Control cntrl in _formCreation.pnlDevotions.Controls)
            {
                if (cntrl.GetType() == typeof(CheckBox))
                {
                    CheckBox cbx = (CheckBox)cntrl;

                    if (cbx.Checked)
                    {
                        sum += nav.SelectSingleNode(String.Format("Devotions/Devotion[@Name='{0}']/@Cost", cbx.Text)).ValueAsInt;
                    }
                }
            }

            return sum;
        }
        #endregion

        #region Blood Potency
        public void LoadBloodPotency()
        {
            _formCreation.rdoPotency.AbilityRank = Player.Potency;
            _bloodPotencyTotal = BloodPotencyTotal();
        }        

        private int BloodPotencyTotal()
        {
            return _formCreation.rdoPotency.AbilityRank * _bloodPotencyCost;
        }
        #endregion             
    }
}
