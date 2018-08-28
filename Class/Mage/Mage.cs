using Pen_and_Paper_Visualator.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Pen_and_Paper_Visualator.Controls;
using System.Xml.XPath;
using System.Drawing;

namespace Pen_and_Paper_Visualator.Class.Mage
{
    public class Mage : ITemplateRules
    {
        private AdvancedGMControl _advancedGMControl;

        public void PopulateAdvancedGMControlAbilities(AdvancedGMControl advancedGMControl, XPathNavigator xPathNav)
        {
            _advancedGMControl = advancedGMControl;

            XPathNodeIterator xRotesIter = xPathNav.Select("Rotes/Rote");

            while (xRotesIter.MoveNext())
            {
                _advancedGMControl.lstAbilities.Items.Add(xRotesIter.Current.SelectSingleNode("@Name").Value);
            }
        }

        public void SetPlayerTemplateStyle(frmVisualator frmVis)
        {
            frmVis.BackColor = Color.DarkGreen;
            frmVis.BackgroundImage = Properties.Resources.nebula;
            frmVis.pnlInteractive.BackgroundImage = Properties.Resources.Mage_Logo;
            frmVis.tabPageDiscipline.Text = "Arcana";
            frmVis.lblVitae.Text = "Mana";
            frmVis.lblPotency.Text = "Gnosis";
            frmVis.lblHumanity.Text = "Wisdom";

            ArcanaTab lvCharArcana = new ArcanaTab();
            frmVis.tabPageDiscipline.Controls.Clear();
            frmVis.tabPageDiscipline.Controls.Add(lvCharArcana);
        }

        public void SetPlayerTabControlStyle(PlayerTab playerTab)
        {
            playerTab.imgChar.Image = Properties.Resources.MageAwakeningBox;
            playerTab.lblIsClan.Text = "Path:";
            playerTab.lblIsCovenant.Text = "Order:";
            playerTab.lblISCoterie.Text = "Legacy:";
        }
    }
}
