using Pen_and_Paper_Visualator.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Pen_and_Paper_Visualator.Controls;
using System.Xml.XPath;
using System.Drawing;

namespace Pen_and_Paper_Visualator.Class.Human
{
    public class Human : ITemplateRules
    {
        public void PopulateAdvancedGMControlAbilities(AdvancedGMControl advancedGMControl, XPathNavigator xPathNav)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerTemplateStyle(frmVisualator frmVis)
        {
            frmVis.BackColor = Color.DarkGoldenrod;
            frmVis.BackgroundImage = Properties.Resources.alley;
            frmVis.pnlInteractive.BackgroundImage = Properties.Resources.world_of_darkness;
            frmVis.tabPageDiscipline.Text = "Unused";
            frmVis.lblVitae.Text = "Unused";
            frmVis.lblPotency.Text = "Unused";
            frmVis.lblHumanity.Text = "Morality";
            //foreach (Control ctl in tblVitals.Controls)
            //    if (tblVitals.GetRow(ctl) == 0 || tblVitals.GetRow(ctl) == 2) ctl.Visible = false;

            frmVis.tabInfo.TabPages.Remove(frmVis.tabPageDiscipline);
        }

        public void SetPlayerTabControlStyle(PlayerTab playerTab)
        {
            playerTab.imgChar.Image = Properties.Resources.green;
            playerTab.lblIsClan.Text = "Faction:";
            playerTab.lblIsCovenant.Text = "Unused:";
            playerTab.lblISCoterie.Text = "Unused:";
        }
    }
}
