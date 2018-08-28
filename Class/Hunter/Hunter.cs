using Pen_and_Paper_Visualator.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Pen_and_Paper_Visualator.Controls;
using System.Xml.XPath;
using System.Drawing;

namespace Pen_and_Paper_Visualator.Class.Hunter
{
    public class Hunter : ITemplateRules
    {
        public void PopulateAdvancedGMControlAbilities(AdvancedGMControl advancedGMControl, XPathNavigator xPathNav)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerTemplateStyle(frmVisualator frmVis)
        {
            frmVis.BackColor = Color.Black;
            frmVis.BackgroundImage = Properties.Resources.skulls;
            frmVis.pnlInteractive.BackgroundImage = Properties.Resources.Hunter_Logo;
            frmVis.tabPageDiscipline.Text = "Tactics";
            frmVis.lblVitae.Text = "Unused";
            frmVis.lblPotency.Text = "Unused";
            frmVis.lblHumanity.Text = "Morality";
        }

        public void SetPlayerTabControlStyle(PlayerTab playerTab)
        {
            playerTab.imgChar.Image = Properties.Resources.Hunter_Box;
            playerTab.lblIsClan.Text = "Path:";
            playerTab.lblIsCovenant.Text = "Order:";
            playerTab.lblISCoterie.Text = "Legacy:";
        }
    }
}
