using System;
using System.Windows.Forms;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class ArcanaTab : UserControl
    {
        private XPathDocument cvArcanaXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Arcana.xml");
        private string cvRoteImagesFolder = Properties.Settings.Default.DataLocation + "Discipline_Images/";
        XPathNavigator nav;

        public ArcanaTab()
        {
            InitializeComponent();
            nav = cvArcanaXml.CreateNavigator();

            rdoArcanaDeath.AbilityRank = Player.Arcana["Death"];
            rdoArcanaFate.AbilityRank = Player.Arcana["Fate"];
            rdoArcanaForces.AbilityRank = Player.Arcana["Forces"];
            rdoArcanaLife.AbilityRank = Player.Arcana["Life"];
            rdoArcanaMatter.AbilityRank = Player.Arcana["Matter"];
            rdoArcanaMind.AbilityRank = Player.Arcana["Mind"];
            rdoArcanaPrime.AbilityRank = Player.Arcana["Prime"];
            rdoArcanaSpace.AbilityRank = Player.Arcana["Space"];
            rdoArcanaSpirit.AbilityRank = Player.Arcana["Spirit"];
            rdoArcanaTime.AbilityRank = Player.Arcana["Time"];

            foreach (var rote in Player.Rote)
            {
                IconLabel iLbl = new IconLabel();
                iLbl.DisplayType = IconLabel.Type.Rote;
                XPathNavigator xParent = nav.SelectSingleNode(String.Format("Arcanum/Arcana/Rote[@Name='{0}']", rote.Key));
                xParent.MoveToParent();
                iLbl.Image = xParent.SelectSingleNode("@Image").Value;
                iLbl.Display = rote.Key;
                iLbl.Click += Rote_Click;

                iLbl.MouseClick += Rote_Click;
                foreach (Control c in iLbl.Controls)
                {
                    c.MouseClick += (sender, e) => { DescribeRote(iLbl.Display, iLbl.Image); };
                }

                pnlRotes.Controls.Add(iLbl);
            }
        }

        private void DescribeRote(string display, string image)
        {
            nav = cvArcanaXml.CreateNavigator().SelectSingleNode("Arcanum/Arcana/Rote[@Name='" + display + "']");
            lblActiveRote.Text = display;
            imgRote.ImageLocation = cvRoteImagesFolder + image;
            txtRoteDescription.Rtf = RtfHelper.PlainTextToRtf(nav.SelectSingleNode("Description").Value);
            pnlRoteDesc.Visible = true;
        }

        private void Rote_Click(object sender, EventArgs e)
        {
            DescribeRote(((IconLabel)sender).Display, ((IconLabel)sender).Image);
        }
    }
}
