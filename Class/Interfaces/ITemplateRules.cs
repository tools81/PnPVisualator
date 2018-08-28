using System;
using System.Collections.Generic;
using System.Text;
using Pen_and_Paper_Visualator.Controls;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class.Interfaces
{
    public interface ITemplateRules
    {
        void SetPlayerTemplateStyle(frmVisualator frmVis);
        void PopulateAdvancedGMControlAbilities(AdvancedGMControl advancedGMControl, XPathNavigator xPathNav);
        void SetPlayerTabControlStyle(PlayerTab playerTab);
    }
}
