using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class CharDisplay : UserControl
    {
        public static string CharName { get; set; }

        public static string Type { get; set; }

        public static string Image { get; set; }

        public static int Health { get; set; }

        public static int Bash { get; set; }

        public static int Lethal { get; set; }

        public static int Aggravated { get; set; }

        public static int WillpowerMax { get; set; }

        public static int WillpowerCurrent { get; set; }

        private static List<string> _Status = new List<string>();

        public static List<string> Status
        {
            get { return _Status; }
            set { _Status = value;  }
        }

        public enum CharType
        {
            NPC,
            Character
        }

        public static Global.CharType DisplayType { get; set; }

        public CharDisplay()
        {
            InitializeComponent();

            lblName.Text = CharName;
            lblType.Text = Type;
            //lblMorality.Text = lvDistance;

            foreach (string status in _Status)
            {
                XPathDocument xStatusDoc = new XPathDocument(Global.StatusXml);
                XPathNavigator xNav = xStatusDoc.CreateNavigator();

                txtStatus.AppendText(xNav.SelectSingleNode(@"Statuses/Status[@Name='" + status + @"']/@Text").Value + Environment.NewLine);
            }

            #region Health
            if (Health > 0)
            {
                rdoHealth1.Checked = true;
            }
            if (Health > 1)
            {
                rdoHealth2.Checked = true;
            }
            if (Health > 2)
            {
                rdoHealth3.Checked = true;
            }
            if (Health > 3)
            {
                rdoHealth4.Checked = true;
            }
            if (Health > 4)
            {
                rdoHealth5.Checked = true;
            }
            if (Health > 5)
            {
                rdoHealth6.Checked = true;
            }
            if (Health > 6)
            {
                rdoHealth7.Checked = true;
            }
            if (Health > 7)
            {
                rdoHealth8.Checked = true;
            }
            if (Health > 8)
            {
                rdoHealth9.Checked = true;
            }
            if (Health > 9)
            {
                rdoHealth10.Checked = true;
            }

            UpdateHealthState();
            #endregion

            #region Willpower
            if (WillpowerMax > 0)
            {
                rdoWill1.Checked = true;
            }
            if (WillpowerMax > 1)
            {
                rdoWill2.Checked = true;
            }
            if (WillpowerMax > 2)
            {
                rdoWill3.Checked = true;
            }
            if (WillpowerMax > 3)
            {
                rdoWill4.Checked = true;
            }
            if (WillpowerMax > 4)
            {
                rdoWill5.Checked = true;
            }
            if (WillpowerMax > 5)
            {
                rdoWill6.Checked = true;
            }
            if (WillpowerMax > 6)
            {
                rdoWill7.Checked = true;
            }
            if (WillpowerMax > 7)
            {
                rdoWill8.Checked = true;
            }
            if (WillpowerMax > 8)
            {
                rdoWill9.Checked = true;
            }
            if (WillpowerMax > 9)
            {
                rdoWill10.Checked = true;
            }

            if (WillpowerCurrent > 0)
            {
                chkWill1.Checked = true;
            }
            if (WillpowerCurrent > 1)
            {
                chkWill2.Checked = true;
            }
            if (WillpowerCurrent > 2)
            {
                chkWill3.Checked = true;
            }
            if (WillpowerCurrent > 3)
            {
                chkWill4.Checked = true;
            }
            if (WillpowerCurrent > 4)
            {
                chkWill5.Checked = true;
            }
            if (WillpowerCurrent > 5)
            {
                chkWill6.Checked = true;
            }
            if (WillpowerCurrent > 6)
            {
                chkWill7.Checked = true;
            }
            if (WillpowerCurrent > 7)
            {
                chkWill8.Checked = true;
            }
            if (WillpowerCurrent > 8)
            {
                chkWill9.Checked = true;
            }
            if (WillpowerCurrent > 9)
            {
                chkWill10.Checked = true;
            }
            #endregion

            switch (DisplayType)
            {
                case Global.CharType.NPC:
                    lblStatusText.Text = "Info";

                    imgCharacter.ImageLocation = Properties.Settings.Default.DataLocation + @"NPC_Images\" + Image;
                    XPathDocument xNpcDocument = new XPathDocument(Global.NpcFolder + @"\" + CharName + ".xml");
                    XPathNavigator xNpcNav = xNpcDocument.CreateNavigator();
                    txtStatus.AppendText("Size: " + xNpcNav.SelectSingleNode(@"Character/Attributes/Size").Value + Environment.NewLine);
                    txtStatus.AppendText("Defense: " + xNpcNav.SelectSingleNode(@"Character/Attributes/Defense").Value + Environment.NewLine);
                    txtStatus.AppendText("Initiative: " + xNpcNav.SelectSingleNode(@"Character/Attributes/Initiative").Value + Environment.NewLine);
                    txtStatus.AppendText("Speed: " + xNpcNav.SelectSingleNode(@"Character/Attributes/Speed").Value + Environment.NewLine);
                    //txtStatus.AppendText("Armor: " + xNpcNav.SelectSingleNode(@"Character/Attributes/Armor").Value + Environment.NewLine);
                    txtStatus.AppendText("Vitae: " + xNpcNav.SelectSingleNode(@"Character/Attributes/Vitae").Value + Environment.NewLine);
                    //txtStatus.AppendText("Blood Potency: " + xNpcNav.SelectSingleNode(@"Character/Attributes/BloodPotency").Value + Environment.NewLine);
                    break;
                case Global.CharType.Character:
                    imgCharacter.ImageLocation = Properties.Settings.Default.DataLocation + @"Character_Images\" + Image;
                    break;
                default:
                    break;
            }
        }

        private void UpdateHealthState()
        {
            int lvAggravated = Aggravated;
            int lvLethal = Lethal;
            int lvBash = Bash;
            int lvHealthPointIndex = 1;

            while (lvAggravated > 0)
            {
                HealthPoint lvHp = ((HealthPoint)this.Controls.Find("healthPoint" + lvHealthPointIndex, true)[0]);
                lvHp.State = HealthPoint.StateEnum.Aggravated;
                lvHp.SetHealthState();
                lvHealthPointIndex++;
                lvAggravated--;
            }

            while (lvLethal > 0)
            {
                HealthPoint lvHp = ((HealthPoint)this.Controls.Find("healthPoint" + lvHealthPointIndex, true)[0]);
                lvHp.State = HealthPoint.StateEnum.Lethal;
                lvHp.SetHealthState();
                lvHealthPointIndex++;
                lvLethal--;
            }

            while (lvBash > 0)
            {
                HealthPoint lvHp = ((HealthPoint)this.Controls.Find("healthPoint" + lvHealthPointIndex, true)[0]);
                lvHp.State = HealthPoint.StateEnum.Bash;
                lvHp.SetHealthState();
                lvHealthPointIndex++;
                lvBash--;
            }
        }

    }
}
