using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class TraitTab : UserControl
    {
        XPathDocument lvMeritXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Merits.xml");
        XPathDocument lvFlawXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Flaws.xml"); 

        public TraitTab()
        {
            InitializeComponent();           
        }

        private void TraitTab_Load(object sender, EventArgs e)
        {
            lblArmor.Text = (Player.Defense + Player.Armor_General) + "/" + (Player.Defense + Player.Armor_Ballistic);
            lblDefense.Text = Player.Defense.ToString();
            lblInitiative.Text = Player.Initiative.ToString();
            lblSize.Text = Player.Size.ToString();
            lblSpeed.Text = Player.Speed.ToString();
            lbxFlaw.DataSource = Player.Flaw;
            lbxMerit.DataSource = new List<string>(Player.Merit.Keys);

            if (Player.Template == Global.Template.Werewolf)
            {
                pnlRenown.Visible = true;
                rdoPurity.AbilityRank = Player.RenownPurity;
                rdoPurity.Refresh();
                rdoGlory.AbilityRank = Player.RenownGlory;
                rdoGlory.Refresh();
                rdoHonor.AbilityRank = Player.RenownHonor;
                rdoHonor.Refresh();
                rdoWisdom.AbilityRank = Player.RenownWisdom;
                rdoWisdom.Refresh();
                rdoCunning.AbilityRank = Player.RenownCunning;
                rdoCunning.Refresh();
            }               
            else
                pnlRenown.Visible = false;            
        }

        private void DescribeTrait(string pvLabel, string pvTraitType)
        {
            if (pvTraitType == "Merit")
            {
                XPathNavigator nav = lvMeritXml.CreateNavigator();
                lblMeritFlaw.Text = pvLabel;
                txtMeritFlawDesc.Text = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Merits/Merit[@Name = '" + pvLabel + "']/Description").Value);
            }
            else if (pvTraitType == "Flaw")
            {
                XPathNavigator nav = lvFlawXml.CreateNavigator();
                lblMeritFlaw.Text = pvLabel;
                txtMeritFlawDesc.Text = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Flaws/Flaw[@Name = '" + pvLabel + "']/Description").Value);
            }
            
        }

        private void lbxMerit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMerit.SelectedIndex != -1)
            {
                lbxFlaw.SelectedIndex = -1;
                DescribeTrait(lbxMerit.SelectedValue.ToString(), "Merit");
            }
        }

        private void lbxFlaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxFlaw.SelectedIndex != -1)
            {
                lbxMerit.SelectedIndex = -1;
                DescribeTrait(lbxFlaw.SelectedValue.ToString(), "Flaw");
            }
        }
    }
}
