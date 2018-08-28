using Pen_and_Paper_Visualator.Controls;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Controls.Werewolf;

namespace Pen_and_Paper_Visualator.Class.Werewolf
{
    public class Werewolf : ITemplateRules
    {
        private AdvancedGMControl _advancedGMControl;

        public void PopulateAdvancedGMControlAbilities(AdvancedGMControl advancedGMControl, XPathNavigator xPathNav)
        {
            _advancedGMControl = advancedGMControl;

            XPathNodeIterator xGiftsIter = xPathNav.Select("Gifts/Gift");

            while (xGiftsIter.MoveNext())
            {
                _advancedGMControl.lstAbilities.Items.Add(xGiftsIter.Current.SelectSingleNode("@Name").Value);
            }

            XPathNodeIterator xRitesIter = xPathNav.Select("Rites/Rite");

            while (xRitesIter.MoveNext())
            {
                _advancedGMControl.lstAbilities.Items.Add(xRitesIter.Current.SelectSingleNode("@Name").Value);
            }
        }

        public void SetPlayerTemplateStyle(frmVisualator frmVis)
        {
            frmVis.BackColor = Color.Sienna;
            frmVis.BackgroundImage = Properties.Resources.moon;
            frmVis.pnlInteractive.BackgroundImage = Properties.Resources.Wolf_Logo;
            frmVis.tabPageDiscipline.Text = "Gifts";
            frmVis.lblVitae.Text = "Essence";
            frmVis.lblPotency.Text = "Primal Urge";
            frmVis.lblHumanity.Text = "Harmony";

            GiftTab lvCharGift = new GiftTab();
            frmVis.tabPageDiscipline.Controls.Clear();
            frmVis.tabPageDiscipline.Controls.Add(lvCharGift);
        }

        public void AddFormTab(frmVisualator frmVis)
        {
            TabPage tabPage = new TabPage("Forms");
            tabPage.Controls.Add(new FormTab());
            frmVis.tabInfo.TabPages.Insert(3, tabPage);
        }

        public void SetPlayerTabControlStyle(PlayerTab playerTab)
        {
            playerTab.imgChar.Image = Properties.Resources.WerewolfForsakenBox;
            playerTab.lblIsClan.Text = "Tribe:";
            playerTab.lblIsCovenant.Text = "Auspice:";
            playerTab.lblISCoterie.Text = "Lodge:";
        }
    }
}
