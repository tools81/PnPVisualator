using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class DisciplineTab : UserControl
    {
        XPathDocument cvDiscXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Discipline.xml");
        XPathDocument cvDevXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Devotions.xml");
        XPathNavigator nav;
        XPathNavigator devNav;

        public DisciplineTab()
        {
            InitializeComponent();

            nav = cvDiscXml.CreateNavigator();
            devNav = cvDevXml.CreateNavigator();

            foreach (var lvDiscipline in Player.Discipline)
            {
                Label lbl = new Label();
                rdoAbilityRank rdo = new rdoAbilityRank();

                lbl.Text = lvDiscipline.Key;
                rdo.RadioCount = 5;
                rdo.AbilityRank = lvDiscipline.Value;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Height = 28;
                rdo.Height = 25;

                lbl.MouseClick += (sender, e) => { SelectDiscipline(lvDiscipline); };

                pnlDiscipline.Controls.Add(lbl);
                pnlDiscipline.Controls.Add(rdo);
                pnlDiscipline.SetFlowBreak(rdo, true);
            }          

            foreach (string lvDevotion in Player.Devotion)
            {
                Label lbl = new Label();
                lbl.Text = lvDevotion;
                pnlDevotion.Controls.Add(lbl);

                lbl.MouseClick += (sender, e) => { SelectDevotion(lvDevotion); };
            }          
        }        

        private void SelectDiscipline(KeyValuePair<string, int> lvDisc)
        {
            pnlDiscDesc.Visible = true;
            ddlDisciplineLevel.Visible = true;            
            ddlDisciplineLevel.Items.Clear();
            lblActiveDiscipline.Text = lvDisc.Key;
            XPathNodeIterator lvDiscIter = nav.Select("Disciplines/Discipline[@Name = '" + lvDisc.Key + "']/Sub");

            while (lvDiscIter.MoveNext())
            {
                if (lvDiscIter.Current.SelectSingleNode("@Level").ValueAsInt <= lvDisc.Value)
                    ddlDisciplineLevel.Items.Add(lvDiscIter.Current.SelectSingleNode("@LevelName").Value);
                else
                    break;
            }
            ddlDisciplineLevel.SelectedIndex = 0;

            imgDiscipline.ImageLocation = Properties.Settings.Default.DataLocation + "Discipline_Images/" + nav.SelectSingleNode("Disciplines/Discipline[@Name = '" + lvDisc.Key + "']/@Image").Value;
        }

        private void ddlDisciplineLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDisciplineLevel.SelectedIndex != -1)
            {
                txtDisciplineDescription.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Disciplines/Discipline[@Name = '" + lblActiveDiscipline.Text + "']/Sub[@LevelName = '" + ddlDisciplineLevel.SelectedItem + "']/Description").Value);
            }
        }

        private void SelectDevotion(string lvDevotion)
        {
            pnlDiscDesc.Visible = true;
            ddlDisciplineLevel.Visible = false;
            lblActiveDiscipline.Text = lvDevotion;
            txtDisciplineDescription.Rtf = RtfHelper.PlainTextToRtf(devNav.SelectSingleNode(String.Format("Devotions/Devotion[@Name='{0}']/Description", lvDevotion)).Value);
            imgDiscipline.ImageLocation = Properties.Settings.Default.DataLocation + "Discipline_Images/" + devNav.SelectSingleNode("Devotions/Devotion[@Name = '" + lvDevotion + "']/Image").Value; ;
        }
    }
}
