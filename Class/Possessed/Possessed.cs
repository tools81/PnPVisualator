using Pen_and_Paper_Visualator.Class.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pen_and_Paper_Visualator.Controls;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class.Possessed
{
    public class Possessed : ITemplateRules
    {
        public void PopulateAdvancedGMControlAbilities(AdvancedGMControl advancedGMControl, XPathNavigator xPathNav)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerTabControlStyle(PlayerTab playerTab)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerTemplateStyle(frmVisualator frmVis)
        {
            frmVis.pnlInteractive.BackgroundImage = Properties.Resources.Inferno_Logo;
        }
    }
}
