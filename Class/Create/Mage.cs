using Pen_and_Paper_Visualator.Class.Interfaces;
using Pen_and_Paper_Visualator.Controls;
using System;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Xml;
using System.Windows.Forms;

namespace Pen_and_Paper_Visualator.Class.Create
{
    class Mage : ITemplateCreate
    {
        private CreateCharacter _formCreation;
        private XPathDocument cvArcanaXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Arcana.xml");
        private XPathDocument cvClanXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Clans.xml");
        private XPathDocument cvCovenantXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Covenants.xml");
        private string _Arcane_Img_Folder = Properties.Settings.Default.DataLocation + @"Discipline_Images\";

        private int _gnosisTotal;
        private int _roteTotal;
        private int _arcanaTotal;

        private const int _gnosisCost = 8;
        private const int _arcanaRulingCost = 6;
        private const int _arcanaCommonCost = 7;
        private const int _arcanaInferiorCost = 8;
        private const int _roteCost = 2;

        public Mage(CreateCharacter createChar)
        {
            _formCreation = createChar;
        }

        public void Populate()
        {
            PopulateRotes();
        }        

        public void Load()
        {
            LoadCharacterRotes();
        }        

        public void Screen()
        {
            _formCreation.lblClan.Text = "Path";
            _formCreation.lblCovenant.Text = "Order";
            _formCreation.lblDiscText.Text = "Arcana:";
            _formCreation.lblHumanity.Text = "Wisdom";
            _formCreation.lblPrimDisc.Text = "2";
            _formCreation.lblSecDisc.Text = "2";
            _formCreation.lblTertDisc.Text = "1+1";
            _formCreation.lblRotesText.Visible = true;
            _formCreation.lblRotes.Visible = true;
            _formCreation.ShowControls(true);
        }

        public void ExperienceCount()
        {
            int lvGnosisTotal = GnosisTotal();
        }

        public void Save(XmlTextWriter xmlTextWriter)
        {
            SaveRotes(xmlTextWriter);
        }

        #region Rotes
        private void PopulateRotes()
        {
            AddRotesToTab("Death", _formCreation.pnlRoteDeath);
            AddRotesToTab("Fate", _formCreation.pnlRoteFate);
            AddRotesToTab("Forces", _formCreation.pnlRoteForces);
            AddRotesToTab("Life", _formCreation.pnlRoteLife);
            AddRotesToTab("Matter", _formCreation.pnlRoteMatter);
            AddRotesToTab("Mind", _formCreation.pnlRoteMind);
            AddRotesToTab("Prime", _formCreation.pnlRotePrime);
            AddRotesToTab("Spirit", _formCreation.pnlRoteSpirit);
            AddRotesToTab("Space", _formCreation.pnlRoteSpace);
            AddRotesToTab("Time", _formCreation.pnlRoteTime);
        }

        private void AddRotesToTab(string arcana, FlowLayoutPanel pnl)
        {
            XPathNavigator xNav = cvArcanaXml.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name=\"{arcana}\"]");
            XPathNodeIterator xNodeIter = xNav.Select("Rote");

            while (xNodeIter.MoveNext())
            {
                string rote = xNodeIter.Current.SelectSingleNode("@Name").Value;
                int roteLevel = xNodeIter.Current.SelectSingleNode("@Level").ValueAsInt;

                CheckBox cbx = new CheckBox();
                cbx.Name = "cbxRote" + rote.Replace(" ", "");
                cbx.Text = rote;
                cbx.Width = 160;
                cbx.Height = 28;

                cbx.CheckedChanged += rote_CheckedChanged;

                rdoAbilityRank rdo = new rdoAbilityRank();
                rdo.AbilityRank = roteLevel;
                rdo.RadioCount = roteLevel;
                rdo.ReadOnly = true;
                rdo.Height = 28;

                pnl.Controls.Add(cbx);
                pnl.Controls.Add(rdo);
                pnl.SetFlowBreak(rdo, true);
            }
        }

        private void rote_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            XPathNavigator xNav = cvArcanaXml.CreateNavigator().SelectSingleNode($"Arcanum/Arcana/Rote[@Name=\"{cbx.Text}\"]");

            _formCreation.lblArcanaName.Text = cbx.Text;
            string rtf = RtfHelper.Begin();
            RtfHelper.ConvertText(ref rtf, xNav.SelectSingleNode("Description").Value);
            RtfHelper.End(ref rtf);
            _formCreation.txtArcanaDesc.Rtf = rtf;
            _formCreation.lblArcanaAttribute.Text = xNav.SelectSingleNode("Attribute").Value;
            _formCreation.lblArcanaSkill.Text = xNav.SelectSingleNode("Skill").Value;
            _formCreation.lblArcanaAspect.Text = xNav.SelectSingleNode("Aspect").Value;
            _formCreation.lblArcanaManaCost.Text = xNav.SelectSingleNode("Cost").Value;

            xNav.MoveToParent();
            _formCreation.imgArcana.ImageLocation = _Arcane_Img_Folder + xNav.SelectSingleNode("@Image").Value;

            _formCreation.pnlArcanaDetails.Visible = true;
        }

        private void SaveRotes(XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Arcana");
            textWriter.WriteStartElement("Death");
            textWriter.WriteString(_formCreation.rdoArcanaDeath.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Fate");
            textWriter.WriteString(_formCreation.rdoArcanaFate.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Forces");
            textWriter.WriteString(_formCreation.rdoArcanaForces.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Life");
            textWriter.WriteString(_formCreation.rdoArcanaLife.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Matter");
            textWriter.WriteString(_formCreation.rdoArcanaMatter.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Mind");
            textWriter.WriteString(_formCreation.rdoArcanaMind.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Prime");
            textWriter.WriteString(_formCreation.rdoArcanaPrime.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Space");
            textWriter.WriteString(_formCreation.rdoArcanaSpace.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Spirit");
            textWriter.WriteString(_formCreation.rdoArcanaSpirit.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Time");
            textWriter.WriteString(_formCreation.rdoArcanaTime.AbilityRank.ToString());
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            
            textWriter.WriteStartElement("Rotes");
            AddSaveRotes(textWriter, _formCreation.pnlRoteDeath, "Death");
            AddSaveRotes(textWriter, _formCreation.pnlRoteFate, "Fate");
            AddSaveRotes(textWriter, _formCreation.pnlRoteForces, "Forces");
            AddSaveRotes(textWriter, _formCreation.pnlRoteLife, "Life");
            AddSaveRotes(textWriter, _formCreation.pnlRoteMatter, "Matter");
            AddSaveRotes(textWriter, _formCreation.pnlRoteMind, "Mind");
            AddSaveRotes(textWriter, _formCreation.pnlRotePrime, "Prime");
            AddSaveRotes(textWriter, _formCreation.pnlRoteSpace, "Space");
            AddSaveRotes(textWriter, _formCreation.pnlRoteSpirit, "Spirit");
            AddSaveRotes(textWriter, _formCreation.pnlRoteTime, "Time");
            textWriter.WriteEndElement();
        }

        private void AddSaveRotes(XmlTextWriter textWriter, FlowLayoutPanel pnl, string arcana)
        {
            foreach (Control lvControl in pnl.Controls)
            {
                if (lvControl.Name.StartsWith("cbxRote") && ((CheckBox)lvControl).Checked)
                {
                    string lvRote = ((CheckBox)lvControl).Text;
                    textWriter.WriteStartElement("Rote");
                    textWriter.WriteStartAttribute("Name");
                    textWriter.WriteString(lvRote);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteStartAttribute("Arcana");
                    textWriter.WriteString(arcana);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteEndElement();
                }
            }
        }

        private void LoadCharacterRotes()
        {
            foreach (KeyValuePair<string, int> d in Player.Arcana)
            {
                if (!String.IsNullOrEmpty(d.Key))
                {
                    rdoAbilityRank rdoArcana = (rdoAbilityRank)_formCreation.tblArcana.Controls.Find("rdoArcana" + d.Key, true)[0];
                    rdoArcana.AbilityRank = d.Value;
                    rdoArcana.Refresh();
                }
            }

            foreach (KeyValuePair<string, string> d in Player.Rote)
            {
                CheckBox cbx;
                switch (d.Value)
                {
                    case "Death":
                        cbx = (CheckBox)_formCreation.pnlRoteDeath.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Fate":
                        cbx = (CheckBox)_formCreation.pnlRoteFate.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Forces":
                        cbx = (CheckBox)_formCreation.pnlRoteForces.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Life":
                        cbx = (CheckBox)_formCreation.pnlRoteLife.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Matter":
                        cbx = (CheckBox)_formCreation.pnlRoteMatter.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Mind":
                        cbx = (CheckBox)_formCreation.pnlRoteMind.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Prime":
                        cbx = (CheckBox)_formCreation.pnlRotePrime.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Space":
                        cbx = (CheckBox)_formCreation.pnlRoteSpace.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Spirit":
                        cbx = (CheckBox)_formCreation.pnlRoteSpirit.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    case "Time":
                        cbx = (CheckBox)_formCreation.pnlRoteTime.Controls.Find("cbxRote" + d.Key.Replace(" ", ""), true)[0];
                        cbx.Checked = true;
                        cbx.Refresh();
                        break;
                    default:
                        break;
                }
            }
        }

        private int RoteTotal()
        {
            int sum = 0;

            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteDeath);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteFate);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteForces);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteLife);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteMatter);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteMind);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRotePrime);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteSpace);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteSpirit);
            sum = GetSumOfArcanaTree(sum, _formCreation.pnlRoteTime);

            return sum;
        }

        private int GetSumOfArcanaTree(int sum, FlowLayoutPanel panel)
        {
            //TODO: Look up the rules and get this straight
            foreach (Control cntrl in panel.Controls)
            {
                if (cntrl.GetType() == typeof(Label))
                {
                    Label lbl = (Label)cntrl;
                    CheckBox cbx = (CheckBox)panel.Controls.Find("cbxRote" + lbl.Text.Replace(" ", String.Empty), true)[0];

                    if (cbx.Checked)
                    {
                        sum += _roteCost;
                    }
                }
            }

            return sum;
        }
        #endregion

        #region Gnosis
        public void LoadGnosis()
        {
            _formCreation.rdoPotency.AbilityRank = Player.Potency;
            _gnosisTotal = GnosisTotal();
        }

        private int GnosisTotal()
        {
            return _formCreation.rdoPotency.AbilityRank * _gnosisCost;
        }        
        #endregion
    }
}
