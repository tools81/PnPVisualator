using Pen_and_Paper_Visualator.Controls;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class.Interfaces;
using System;
using System.Drawing;

namespace Pen_and_Paper_Visualator.Class.Vampire
{
    public class Vampire : ITemplateRules
    {
        private AdvancedGMControl _advancedGMControl;

        public void PopulateAdvancedGMControlAbilities(AdvancedGMControl advancedGMControl, XPathNavigator xPathNav)
        {
            _advancedGMControl = advancedGMControl;

            XPathNodeIterator xDiscIter = xPathNav.Select("Disciplines/Discipline");

            while (xDiscIter.MoveNext())
            {
                _advancedGMControl.lstAbilities.Items.Add(xDiscIter.Current.SelectSingleNode("@Name").Value);
            }

            XPathNodeIterator xDevotionIter = xPathNav.Select("Devotions/Devotion");

            while (xDevotionIter.MoveNext())
            {
                _advancedGMControl.lstAbilities.Items.Add(xDevotionIter.Current.Value);
            }
        }

        public void SetPlayerTemplateStyle(frmVisualator frmVis)
        {
            frmVis.BackColor = Color.DarkRed;
            frmVis.BackgroundImage = Properties.Resources.terror;
            frmVis.pnlInteractive.BackgroundImage = Properties.Resources.Vamp_Logo;

            DisciplineTab lvCharDisc = new DisciplineTab();
            frmVis.tabPageDiscipline.Controls.Clear();
            frmVis.tabPageDiscipline.Controls.Add(lvCharDisc);
        }

        public void SetPlayerTabControlStyle(PlayerTab playerTab)
        {
            playerTab.imgChar.Image = Properties.Resources.VampireRequiemBox1;
            playerTab.lblIsClan.Text = "Clan:";
            playerTab.lblIsCovenant.Text = "Covenant:";
            playerTab.lblISCoterie.Text = "Coterie:";
        }
    }
}
