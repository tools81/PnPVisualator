using System;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.IO;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class ChatTab : UserControl
    {
        public string ChatRtf
        {
            get { return txtChat.Rtf; }
            set { txtChat.Rtf = value; }
        }

        public ChatTab()
        {
            InitializeComponent();

            if (Global._UserState == Global.UserState.Player)
            {
                string rfString =
                    @"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset0 Arial;}} {\colortbl ;\red50\green205\blue50;\red255\green255\blue255;\red230\green255\blue230;\red99\green184\blue255;\red0\green0\blue0;\red0\green0\blue100;\red255\green255\blue153;}\fs20\cf3\par " +
                    Player.Name + " joined at: " + DateTime.Now;

                using (FileStream stream = new FileStream(Global.ChatFile, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(rfString);
                    writer.Flush();
                    writer.Close();
                }
            }

            string fileContents;

            using (FileStream stream = new FileStream(Global.ChatFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    fileContents = reader.ReadToEnd();
                }
            }
            txtChat.Rtf = fileContents;

            txtChat.SelectionStart = txtChat.Text.Length;
            txtChat.ScrollToCaret();
        }       
    }
}
