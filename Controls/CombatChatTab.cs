using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.IO;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class CombatChatTab : UserControl
    {
        public string CombatChatRtf
        {
            get { return txtCombatChat.Rtf; }
            set { txtCombatChat.Rtf = value; }
        }

        public CombatChatTab()
        {
            InitializeComponent();

            string fileContents;

            using (FileStream stream = new FileStream(Global.CombatChatFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    fileContents = reader.ReadToEnd();
                }
            }
            txtCombatChat.Rtf = fileContents;

            txtCombatChat.SelectionStart = txtCombatChat.Text.Length;
            txtCombatChat.ScrollToCaret();
        }
    }
}
