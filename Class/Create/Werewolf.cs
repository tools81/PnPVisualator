using Pen_and_Paper_Visualator.Class.Interfaces;
using Pen_and_Paper_Visualator.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class.Create
{
    class Werewolf : ITemplateCreate
    {
        private CreateCharacter _formCreation;
        private XPathDocument cvGiftsXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Gifts.xml");
        private XPathDocument cvRitesXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Rites.xml");
        private XPathDocument cvTribeXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Clans.xml");
        private XPathDocument cvAuspiceXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Covenants.xml");
        private XPathDocument cvTemplateXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Templates.xml");
        private string _Gift_Img_Folder = Properties.Settings.Default.DataLocation + @"Discipline_Images\";

        private int _giftTotal;
        private int _primalUrgeTotal;
        private int _renownTotal;
        private int _riteTotal;

        private const int _knownGiftCost = 5;
        private const int _unknownGiftCost = 7;
        private const int _riteCost = 2;
        private const int _totemMeritCost = 3;  //not multiplied by rank
        private const int _knownRenownCost = 6;
        private const int _unknownRenownCost = 8;
        private const int _primalUrgeCost = 8;

        public Werewolf(CreateCharacter createChar)
        {
            _formCreation = createChar;            
        }

        public void Populate()
        {
            PopulateGifts();
            PopulateRites();
        }        

        public void Load()
        {
            LoadCharacterGifts();
            LoadCharacterRites();
            LoadCharacterRenown();
            LoadPrimalUrge();
            SetTribeGift(Player.Clan);
            SetAuspiceSkills(Player.Covenant);
            SetTribeRenown(Player.Clan);            
        }        

        public void Screen()
        {
            _formCreation.lblCovenant.Text = "Auspice";
            _formCreation.lblClan.Text = "Tribe";
            _formCreation.lblDiscText.Text = "Gifts:";
            _formCreation.lblHumanity.Text = "Harmony";
            _formCreation.lblSecDisc.Text = String.Empty;
            _formCreation.lblTertDisc.Text = String.Empty;
            _formCreation.lblPotency.Text = "Primal Urge";
            _formCreation.lblVitae.Text = "Essence";
            _formCreation.ShowControls(true);
        }

        public void Save(XmlTextWriter xmlTextWriter)
        {
            SaveGifts(xmlTextWriter);
            SaveRites(xmlTextWriter);
            SaveRenown(xmlTextWriter);
        }       

        public void ExperienceCount()
        {
            int lvGiftTotal = GiftTotal();
            int lvRiteTotal = RiteTotal();
            int lvPrimalUrgeTotal = PrimalUrgeTotal();
            int lvRenownTotal = RenownTotal();

            Player.Experience += _giftTotal - lvGiftTotal;
            _giftTotal = lvGiftTotal;
            Player.Experience += _riteTotal - lvRiteTotal;
            _riteTotal = lvRiteTotal;
            Player.Experience += _primalUrgeTotal - lvPrimalUrgeTotal;
            _primalUrgeTotal = lvPrimalUrgeTotal;
            Player.Experience += -_renownTotal - lvRenownTotal;
            _renownTotal = lvRenownTotal;
            Player.Experience += _riteTotal - lvRiteTotal;
            _riteTotal = lvRiteTotal;
        }        

        #region Gifts
        private void PopulateGifts()
        {
            XPathNavigator nav = cvGiftsXml.CreateNavigator();
            XPathNodeIterator nodeIter = nav.Select("Gifts/Gift");
            _formCreation.pnlGifts.Controls.Clear();
            Label lvGiftLabel;
            CheckBox lvGiftCheck;

            while (nodeIter.MoveNext())
            {
                lvGiftLabel = new Label();
                FontFamily fontFam = new FontFamily("Microsoft Sans Serif");
                lvGiftLabel.Font = new Font(fontFam, 16.0f, FontStyle.Bold);
                lvGiftLabel.Text = nodeIter.Current.SelectSingleNode("@Name").Value;
                lvGiftLabel.Width = 260;
                lvGiftLabel.Height = 28;
                lvGiftLabel.MouseClick += lblGift_Clicked;
                lvGiftLabel.MouseHover += lblGift_MouseHover;

                _formCreation.pnlGifts.Controls.Add(lvGiftLabel);
                _formCreation.pnlGifts.SetFlowBreak(lvGiftLabel, true);

                XPathNodeIterator subIter = nodeIter.Current.Select("Sub");

                while (subIter.MoveNext())
                {
                    lvGiftCheck = new CheckBox();
                    lvGiftCheck.Width = 230;
                    lvGiftCheck.BackColor = Color.Transparent;
                    lvGiftCheck.Name = "cbxGift" + subIter.Current.SelectSingleNode("@Name").Value.Replace(" ", String.Empty);
                    lvGiftCheck.Text = subIter.Current.SelectSingleNode("@Name").Value;
                    lvGiftCheck.CheckedChanged += cbxGift_CheckChanged;

                    _formCreation.pnlGifts.Controls.Add(lvGiftCheck);
                    _formCreation.pnlGifts.SetFlowBreak(lvGiftCheck, true);
                }
            }
        }

        public void LoadCharacterGifts()
        {
            foreach (string g in Player.Gift)
            {
                foreach (Control giftControl in _formCreation.pnlGifts.Controls)
                {
                    if (giftControl.Name.Contains(g.Replace(" ", "")))
                    {
                        ((CheckBox)giftControl).Checked = true;
                        break;
                    }
                }
            }
        }

        public void SaveGifts(XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Gifts");
            foreach (Control lvControl in _formCreation.tabGifts.Controls)
            {
                if (lvControl.Name.StartsWith("cbxGift") && ((CheckBox)lvControl).Checked)
                {
                    string lvGift = ((CheckBox)lvControl).Text;
                    textWriter.WriteStartElement("Gift");
                    textWriter.WriteStartAttribute("Name");
                    textWriter.WriteString(lvGift);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();
                }
            }
            textWriter.WriteEndElement();
        }

        private int GiftTotal()
        {
            int sum = 0;

            foreach (Control cntrl in _formCreation.pnlGifts.Controls)
            {
                if (cntrl.GetType() == typeof(CheckBox))
                {
                    CheckBox cbx = (CheckBox)cntrl;

                    XPathNodeIterator tribeGiftIter = cvTribeXml.CreateNavigator().Select(String.Format("Clans/Template[@Name='{0}']/Clan[@Name='{1}']/Gifts/Gift", Player.Template, Player.Clan));
                    XPathNodeIterator auspGiftIter = cvAuspiceXml.CreateNavigator().Select(String.Format("Covenants/Template[@Name='{0}']/Covenant[@Name='{1}']/Gifts/Gift", Player.Template, Player.Clan));

                    //TODO: Handle names with apostrophes
                    XPathNavigator giftParentNav = cvGiftsXml.CreateNavigator().SelectSingleNode(String.Format("Gifts/Gift/Sub[@Name='{0}']/..", cbx.Text));
                    string lvGiftName = giftParentNav.SelectSingleNode("@Name").Value;

                    bool match = false;
                    while (tribeGiftIter.MoveNext())
                    {
                        match = tribeGiftIter.Current.Value == lvGiftName ? true : false;
                        if (match)
                            break;
                    }

                    if (!match)
                    {
                        while (auspGiftIter.MoveNext())
                        {
                            match = tribeGiftIter.Current.Value == lvGiftName ? true : false;
                            if (match)
                                break;
                        }
                    }

                    if (match)
                        sum += _knownGiftCost;
                    else
                        sum += _unknownGiftCost;
                }
            }

            return sum;
        }
        
        public void lblGift_MouseHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Cursor = Cursors.Help;
        }

        public void lblGift_Clicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;
            Label lbl = (Label)sender;
            XPathNavigator xNav = cvGiftsXml.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name=\"{lbl.Text}\"]");

            _formCreation.lblActiveItem.Text = lbl.Text;
            string rtf = RtfHelper.Begin();
            RtfHelper.ConvertText(ref rtf, xNav.SelectSingleNode("Description").Value);
            RtfHelper.End(ref rtf);
            _formCreation.txtDescription.Rtf = rtf;
        }

        public void cbxGift_CheckChanged(object sender, EventArgs e)
        {
            _formCreation.pnlGiftDesc.Visible = true;
            String lvGift = ((CheckBox)sender).Text;
            XPathNavigator nav = cvGiftsXml.CreateNavigator().SelectSingleNode($"Gifts/Gift/Sub[@Name=\"{lvGift}\"]");

            _formCreation.lblGiftName.Text = lvGift;
            _formCreation.lblGiftAttribute.Text = nav.SelectSingleNode("Attribute").Value;
            _formCreation.lblGiftSkill.Text = nav.SelectSingleNode("Skill").Value;
            _formCreation.lblGiftTrait.Text = nav.SelectSingleNode("Trait").Value;
            _formCreation.lblGiftEssenceCost.Text = nav.SelectSingleNode("Essence_Cost").Value;
            _formCreation.lblGiftWillCost.Text = nav.SelectSingleNode("Willpower_Cost").Value;
            _formCreation.txtGiftDetail.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Description").Value);
            nav.MoveToParent();
            _formCreation.imgGift.ImageLocation = _Gift_Img_Folder + nav.SelectSingleNode("@Image");
        }

        public void SetTribeGift(string lvClan)
        {
            XPathNodeIterator xClanIter = cvTribeXml.CreateNavigator().Select(String.Format("Clans/Template[@Name='Werewolf']/Clan[@Name='{0}']/Gifts/Gift", lvClan));

            foreach (Control lvControl in _formCreation.pnlGifts.Controls)
            {
                if (lvControl.GetType() == typeof(Label))
                    ((Label)lvControl).ForeColor = SystemColors.ControlText;
            }

            while (xClanIter.MoveNext())
            {
                foreach (Control lvControl in _formCreation.pnlGifts.Controls)
                {
                    if (lvControl.GetType() == typeof(Label) && lvControl.Text == xClanIter.Current.Value)
                    {
                        ((Label)lvControl).ForeColor = Color.DarkGoldenrod;
                    }
                }
            }

            if (!String.IsNullOrEmpty(_formCreation.ddlCovenant.Text))
                SetAuspiceGift(_formCreation.ddlCovenant.Text);
        }

        public void SetAuspiceGift(string lvCovenant)
        {
            XPathNodeIterator xAuspIter = cvAuspiceXml.CreateNavigator().Select(String.Format("Covenants/Template[@Name='Werewolf']/Covenant[@Name='{0}']/Gifts/Gift", lvCovenant));

            while (xAuspIter.MoveNext())
            {
                foreach (Control lvControl in _formCreation.pnlGifts.Controls)
                {
                    if (lvControl.GetType() == typeof(Label) && lvControl.Text == xAuspIter.Current.Value)
                    {
                        ((Label)lvControl).ForeColor = Color.SaddleBrown;
                    }
                }
            }
        }
                
        #endregion

        #region Rites
        private void PopulateRites()
        {
            XPathNavigator nav = cvRitesXml.CreateNavigator();
            XPathNodeIterator nodeIter = nav.Select("Rites/Rite");
            _formCreation.pnlRites.Controls.Clear();
            CheckBox lvRiteCheck;
            rdoAbilityRank lvAr;

            while (nodeIter.MoveNext())
            {
                lvRiteCheck = new CheckBox();
                lvRiteCheck.Width = 230;
                lvRiteCheck.BackColor = Color.Transparent;
                lvRiteCheck.Name = "cbxRite" + nodeIter.Current.SelectSingleNode("@Name").Value.Replace(" ", String.Empty);
                lvRiteCheck.Text = nodeIter.Current.SelectSingleNode("@Name").Value;
                lvRiteCheck.CheckedChanged += cbxRite_CheckChanged;

                lvAr = new rdoAbilityRank();
                lvAr.RadioCount = 5;
                lvAr.AbilityRank = nodeIter.Current.SelectSingleNode("@Rituals").ValueAsInt;

                _formCreation.pnlRites.Controls.Add(lvRiteCheck);
                _formCreation.pnlRites.Controls.Add(lvAr);
                _formCreation.pnlRites.SetFlowBreak(lvAr, true);
            }
        }

        private void cbxRite_CheckChanged(object sender, EventArgs e)
        {
            _formCreation.pnlRiteDesc.Visible = true;
            String lvRite = ((CheckBox)sender).Text;
            XPathNavigator nav = cvRitesXml.CreateNavigator().SelectSingleNode($"Rites/Rite[@Name='{lvRite}']");

            _formCreation.lblRiteName.Text = lvRite;
            _formCreation.lblRiteAttribute.Text = nav.SelectSingleNode("Attribute").Value;
            _formCreation.lblRiteSkill.Text = nav.SelectSingleNode("Skill") != null ? nav.SelectSingleNode("Skill").Value : "";
            _formCreation.lblRiteDivider.Text = nav.SelectSingleNode("Divider") != null ? nav.SelectSingleNode("Divider").Value : "";
            _formCreation.lblRiteEssenceCost.Text = nav.SelectSingleNode("Essence_Cost").Value;
            _formCreation.txtRitePerform.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Perform").Value);
            _formCreation.txtRiteDesc.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Description").Value);
            _formCreation.imgGift.ImageLocation = _Gift_Img_Folder + nav.SelectSingleNode("@Image");
        }

        private void LoadCharacterRites()
        {
            foreach (string r in Player.Rite)
            {
                foreach (Control riteControl in _formCreation.pnlRites.Controls)
                {
                    if (riteControl.Name.Contains(r.Replace(" ", "")))
                    {
                        ((CheckBox)riteControl).Checked = true;
                        break;
                    }
                }
            }
        }

        private void SaveRites(XmlTextWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Rites");
            foreach (Control lvControl in _formCreation.tabGifts.Controls)
            {
                if (lvControl.Name.StartsWith("cbxRite") && ((CheckBox)lvControl).Checked)
                {
                    string lvGift = ((CheckBox)lvControl).Text;
                    xmlTextWriter.WriteStartElement("Rite");
                    xmlTextWriter.WriteStartAttribute("Name");
                    xmlTextWriter.WriteString(lvGift);
                    xmlTextWriter.WriteEndAttribute();
                    xmlTextWriter.WriteEndElement();
                }
            }
            xmlTextWriter.WriteEndElement();
        }

        private int RiteTotal()
        {
            _formCreation.pnlRites.Visible = true;
            int sum = 0;

            foreach (Control cntrl in _formCreation.pnlRites.Controls)
            {
                if (cntrl.GetType() == typeof(CheckBox))
                {
                    CheckBox cbx = (CheckBox)cntrl;
                    
                    if (cbx.Checked)
                        sum += _riteCost;
                }
            }

            return sum;
        }
        #endregion

        #region Primal Urge
        public void LoadPrimalUrge()
        {
            _formCreation.rdoPotency.AbilityRank = Player.Potency;
            _primalUrgeTotal = PrimalUrgeTotal();
        }

        private int PrimalUrgeTotal()
        {
            return _formCreation.rdoPotency.AbilityRank * _primalUrgeCost;
        }
        #endregion

        #region Renown
        public void LoadCharacterRenown()
        {
            _formCreation.rdoPurity.AbilityRank = Player.RenownPurity;
            _formCreation.rdoPurity.Refresh();
            _formCreation.rdoGlory.AbilityRank = Player.RenownGlory;
            _formCreation.rdoGlory.Refresh();
            _formCreation.rdoHonor.AbilityRank = Player.RenownHonor;
            _formCreation.rdoHonor.Refresh();
            _formCreation.rdoWisdom.AbilityRank = Player.RenownWisdom;
            _formCreation.rdoWisdom.Refresh();
            _formCreation.rdoCunning.AbilityRank = Player.RenownCunning;
            _formCreation.rdoCunning.Refresh();
        }

        private int RenownTotal()
        {
            int sum = 0;

            foreach (Control cntrl in _formCreation.pnlRenown.Controls)
            {
                if (cntrl.GetType() == typeof(rdoAbilityRank))
                {
                    rdoAbilityRank rank = (rdoAbilityRank)cntrl;

                    XPathNavigator tribeRenownNav = cvTribeXml.CreateNavigator().SelectSingleNode(String.Format("Clans/Template[@Name='{0}']/Clan[@Name='{1}']/Renown", Player.Template, Player.Clan));
                    XPathNavigator auspRenownNav = cvAuspiceXml.CreateNavigator().SelectSingleNode(String.Format("Covenants/Template[@Name='{0}']/Covenant[@Name='{1}']/Renown", Player.Template, Player.Clan));

                    if (rank.Name.Replace("rdo", "") == tribeRenownNav.Value || rank.Name.Replace("rdo", "") == auspRenownNav.Value)
                        sum += rank.AbilityRank * _knownRenownCost;
                    else
                        sum += rank.AbilityRank * _unknownRenownCost;
                }
            }

            return sum;
        }

        public void SaveRenown(XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Renown");
            textWriter.WriteStartElement("Purity");
            textWriter.WriteString(_formCreation.rdoPurity.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Glory");
            textWriter.WriteString(_formCreation.rdoGlory.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Honor");
            textWriter.WriteString(_formCreation.rdoHonor.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Wisdom");
            textWriter.WriteString(_formCreation.rdoWisdom.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Cunning");
            textWriter.WriteString(_formCreation.rdoCunning.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();
        }

        public void SetTribeRenown(string lvClan)
        {
            XPathNavigator xClanNav = cvTribeXml.CreateNavigator().SelectSingleNode(String.Format("Clans/Template[@Name='Werewolf']/Clan[@Name='{0}']/Renown", lvClan));

            foreach (Control xControl in _formCreation.pnlRenown.Controls)
            {
                if (xControl.GetType() == typeof(Label))
                    ((Label)xControl).ForeColor = SystemColors.ControlText;
            }

            Control lvControl = _formCreation.pnlRenown.Controls.Find("lblRenown" + xClanNav.Value, true)[0];
            ((Label)lvControl).ForeColor = Color.DarkGoldenrod;

            if (!String.IsNullOrEmpty(_formCreation.ddlCovenant.Text))
                SetAuspiceRenown(_formCreation.ddlCovenant.Text);
        }

        public void SetAuspiceRenown(string lvCovenant)
        {
            XPathNavigator xAuspNav = cvAuspiceXml.CreateNavigator().SelectSingleNode(String.Format("Covenants/Template[@Name='Werewolf']/Covenant[@Name='{0}']/Renown", lvCovenant));

            Control lvControl = _formCreation.pnlRenown.Controls.Find("lblRenown" + xAuspNav.Value, true)[0];
            ((Label)lvControl).ForeColor = Color.SaddleBrown;
        }
        #endregion

        #region Skills
        public void SetAuspiceSkills(string lvCovenant)
        {
            XPathNodeIterator xAuspIter = cvAuspiceXml.CreateNavigator().Select(String.Format("Covenants/Template[@Name='Werewolf']/Covenant[@Name='{0}']/Skills/Skill", lvCovenant));

            foreach (Control lvControl in _formCreation.tabSkills.Controls)
            {
                if (lvControl.GetType() == typeof(Label))
                    ((Label)lvControl).ForeColor = SystemColors.ControlText;
            }

            while (xAuspIter.MoveNext())
            {
                foreach (Control lvControl in _formCreation.tblSkills.Controls)
                {
                    if (lvControl.GetType() == typeof(Label) && lvControl.Text == xAuspIter.Current.Value)
                    {
                        ((Label)lvControl).ForeColor = Color.SaddleBrown;
                    }
                }
            }
        }
        #endregion        
    }
}
