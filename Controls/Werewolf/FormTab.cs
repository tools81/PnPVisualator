using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Controls.Werewolf
{
    public partial class FormTab : UserControl
    {
        private static readonly string _formsXml = Properties.Settings.Default.DataLocation + @"Lists\Forms.xml";
        private static string _boostSource = "Form";

        public FormTab()
        {
            InitializeComponent();

            foreach (Control control in pnlForms.Controls)
            {
                if (control.Name.Replace("rdo", "") == Player.Form)
                {
                    ((RadioButton)control).Select();
                    XPathDocument xDoc = new XPathDocument(_formsXml);
                    XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode(String.Format("Forms/Werewolf/Form[@Name='{0}']", Player.Form));
                    SetInfo(xNav);
                }                    

                if (control.GetType() == typeof(RadioButton))
                    ((RadioButton)control).Click += FormSelected;
            }
        }

        private void FormSelected(object sender, EventArgs e)
        {
            XPathDocument xDoc = new XPathDocument(_formsXml);
            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode(String.Format("Forms/Werewolf/Form[@Name='{0}']", ((RadioButton)sender).Text));
            
            CharacterUpdate.UpdatePlayerForm(Global.CharacterFolder + Player.Name + ".xml", ((RadioButton)sender).Text);

            SetInfo(xNav);
            //Global.PlayerForm.RefreshAll();
        }

        private void SetInfo(XPathNavigator xNav)
        {
            CharacterUpdate.RemoveBoosts(Global.CharacterFolder + Player.Name + ".xml", _boostSource);

            txtTraits.Clear();
            XPathNodeIterator xNodeIter = xNav.SelectSingleNode("Traits").SelectChildren(XPathNodeType.All);

            while(xNodeIter.MoveNext())
            {
                txtTraits.Text += xNodeIter.Current.Name + " - " + xNodeIter.Current.Value + " : " + xNodeIter.Current.SelectSingleNode("@Value").Value;
                txtTraits.Text += Environment.NewLine;

                CharacterUpdate.AddBoost(Global.CharacterFolder + Player.Name + ".xml", _boostSource, xNodeIter.Current.Name, xNodeIter.Current.Value, xNodeIter.Current.SelectSingleNode("@Value").Value);
            }

            txtDescription.Clear();
            txtDescription.Rtf = RtfHelper.PlainTextToRtf(xNav.SelectSingleNode("Description").Value);

            imgForm.ImageLocation = Properties.Settings.Default.DataLocation + @"Form_Images\" + xNav.SelectSingleNode("Image").Value;

            txtDescription.Refresh();
            txtTraits.Refresh();
            imgForm.Refresh();
        }
    }
}
