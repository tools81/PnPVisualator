using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class GiftTab : UserControl
    {
        XPathDocument cvGiftXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Gifts.xml");
        XPathDocument cvRiteXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Rites.xml");
        XPathDocument xAuspiceDoc = new XPathDocument(Global.CovenantXml);
        private string cvGiftImagesFolder = Properties.Settings.Default.DataLocation + "Discipline_Images/";
        XPathNavigator nav;

        public GiftTab()
        {
            InitializeComponent();
            nav = cvGiftXml.CreateNavigator();
            bool includeParent = false;
            ArrayList childGifts = new ArrayList();

            foreach (XPathNavigator lvGiftParent in nav.Select("Gifts/Gift"))
            {
                IconLabel iLbl = new IconLabel();
                iLbl.DisplayType = IconLabel.Type.Gift;
                iLbl.Image = lvGiftParent.SelectSingleNode("@Image").Value;
                iLbl.Display = lvGiftParent.SelectSingleNode("@Name").Value;

                foreach (string lvGift in Player.Gift)
                {
                    if (lvGiftParent.SelectSingleNode("Sub[@Name='" + lvGift + "']") != null)
                    {
                        childGifts.Add(lvGift);
                        includeParent = true;
                    }
                }

                if (includeParent)
                {
                    pnlGifts.Controls.Add(iLbl);

                    foreach (string lvChild in childGifts)
                    {
                        Label cLbl = new Label();
                        cLbl.Text = lvChild;
                        pnlGifts.Controls.Add(cLbl);

                        cLbl.Click += lblOnClick;
                    }
                    childGifts.Clear();
                    includeParent = false;
                }
            }         

            foreach (string rite in Player.Rite)
            {
                Label lbl = new Label();
                lbl.Text = rite;
                pnlRites.Controls.Add(lbl);

                lbl.Click += riteOnClick;
            }          
            
            XPathNavigator xAuspiceNav = xAuspiceDoc.CreateNavigator().SelectSingleNode(String.Format("Covenants/Template[@Name='Werewolf']/Covenant[@Name='{0}']/Ability", Player.Covenant));
            lblAuspiceAbility.Text = xAuspiceNav.SelectSingleNode("@Name").Value;         
        }

        private void riteOnClick(object sender, EventArgs e)
        {
            string lvName = ((Label)sender).Text;
            nav = cvRiteXml.CreateNavigator().SelectSingleNode("Rites/Rite[@Name='" + lvName + "']");

            lblActiveGift.Text = lvName;
            txtGiftDescription.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Description").Value);

            imgGift.ImageLocation = cvGiftImagesFolder + nav.SelectSingleNode("@Image").Value;

            pnlGiftDesc.Visible = true;
        }

        private void lblOnClick(object sender, EventArgs eventArgs)
        {
            string lvName = ((Label) sender).Text;
            nav = cvGiftXml.CreateNavigator().SelectSingleNode("Gifts/Gift/Sub[@Name='" + lvName + "']");

            lblActiveGift.Text = lvName;            
            txtGiftDescription.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Description").Value);

            nav.MoveToParent();
            imgGift.ImageLocation = cvGiftImagesFolder + nav.SelectSingleNode("@Image").Value;

            pnlGiftDesc.Visible = true;
        }

        private void lblAuspiceAbility_Click(object sender, EventArgs e)
        {
            XPathNavigator xAuspiceNav = xAuspiceDoc.CreateNavigator().SelectSingleNode(String.Format("Covenants/Template[@Name='Werewolf']/Covenant[@Name='{0}']/Ability", Player.Covenant));
            lblActiveGift.Text = xAuspiceNav.SelectSingleNode("@Name").Value;
            txtGiftDescription.Rtf = RtfHelper.PlainTextToRtf(xAuspiceNav.SelectSingleNode("Description").Value);
            imgGift.Image = Properties.Resources.WerewolfForsakenBox;
        }
    }
}
