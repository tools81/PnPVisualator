using System;
using System.Windows.Forms;
using System.IO;
using Pen_and_Paper_Visualator.Class;
using System.Xml.XPath;
using System.Xml;
using System.Drawing;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class GMAdministerExperience : UserControl
    {
        public GMAdministerExperience()
        {
            InitializeComponent();

            int characterLength = 0;
            DirectoryInfo dir = new DirectoryInfo(Global.CharacterFolder);
            FileInfo[] lvFile;
            lvFile = dir.GetFiles("*.xml");

            for (int i = 0; i < lvFile.Length; i++)
            {
                XPathDocument xDoc = new XPathDocument($"{Global.CharacterFolder}{lvFile[i].Name}");
                XPathNavigator xNav = xDoc.CreateNavigator();
                IconLabel character = new IconLabel();
                character.DisplayType = IconLabel.Type.Character;
                character.DisplaySize = IconLabel.ControlSize.Medium;
                character.Name = $"char{Path.GetFileNameWithoutExtension(lvFile[i].Name)}";
                character.Display = Path.GetFileNameWithoutExtension(lvFile[i].Name);                
                character.Image = xNav.SelectSingleNode("Character/Image").Value;
                character.BackColor = characterLength % 2 == 0 ? Color.SkyBlue : Color.Silver;

                NumericUpDown num = new NumericUpDown();
                num.Name = $"num{Path.GetFileNameWithoutExtension(lvFile[i].Name)}";
                num.Width = 40;
                num.Minimum = 0;
                num.Maximum = 300;

                pnlCharacters.Controls.Add(character);
                pnlCharacters.Controls.Add(num);
                pnlCharacters.SetFlowBreak(num, true);
                characterLength++;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent.Hide();
        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Global.CharacterFolder);
            FileInfo[] lvFile;
            lvFile = dir.GetFiles("*.xml");

            for (int i = 0; i < lvFile.Length; i++)
            {
                var lvControl = (NumericUpDown)Controls.Find($"num{Path.GetFileNameWithoutExtension(lvFile[i].Name)}", true)[0];

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load($"{Global.CharacterFolder}{lvFile[i].Name}");
                var xNode = xDoc.SelectSingleNode("Character/Background/Experience");
                xNode.InnerText = (int.Parse(xNode.InnerText) + lvControl.Value).ToString();

                FileStream lvFS = new FileStream($"{Global.CharacterFolder}{lvFile[i].Name}", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                xDoc.Save(lvFS);
                lvFS.Close();
            }
                
            this.Parent.Hide();
        }
    }
}
