using System;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Controls;
using Pen_and_Paper_Visualator.Class;
using System.IO;
using System.Configuration;

namespace Pen_and_Paper_Visualator
{
    public partial class frmWelcome : Form
    {       
        public frmWelcome()
        {
            InitializeComponent();
            lblDataFolder.Text = Properties.Settings.Default.DataLocation;
            chkSounds.Checked = Properties.Settings.Default.PlaySounds;
            FileInfo introSound = new FileInfo(Global.Sound_Scary);

            if (introSound.Exists)
                Global.PlaySound(Global.Sound_Scary, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ddlCharacters.Items.Clear();

            DirectoryInfo dir = new DirectoryInfo(Global.CharacterFolder);
            FileInfo[] lvFile;
            lvFile = dir.GetFiles("*.xml");
            
            foreach (FileInfo lvInfo in lvFile)
            {
                ddlCharacters.Items.Add(Path.GetFileNameWithoutExtension("Characters/" + lvInfo.Name)); 
            }
        }

        private void ddlCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.ShortName = ddlCharacters.SelectedItem.ToString();
            new Character_Init(ddlCharacters.SelectedItem.ToString());
            Global._UserState = Global.UserState.Player;
            Global.AddCombatActor(Player.ShortName, "Character");

            Global.PlayerForm = new frmVisualator();
            Global.PlayerForm.Show();
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateCharacter lvCreateCharacter = new CreateCharacter();

            Form lvForm = new Form();
            lvForm.Controls.Add(lvCreateCharacter);
            lvForm.Width = lvCreateCharacter.Width + 20;
            lvForm.Height = lvCreateCharacter.Height + 20;
            lvForm.Show();
            lvForm.BringToFront();
            Global.PlaySound(Global.Music_Theme, true);
            lvForm.Closed += CloseCreateForm;
        }

        private void CloseCreateForm(object sender, EventArgs e)
        {
            Global.StopSound();
        }

        private void btnGM_Click(object sender, EventArgs e)
        {
            Global._UserState = Global.UserState.GM;
            Global.GameManagerForm = new GMForm();
            Global.GameManagerForm.Show();
            this.Hide();
        }

        private void btnDataFolder_Click(object sender, EventArgs e)
        {
            if (fbdDataFolder.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Properties.Settings.Default.DataLocation = fbdDataFolder.SelectedPath + @"\";
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read directory. Original error: " + ex.Message);
                }
            }
        }

        private void chkSounds_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PlaySounds = chkSounds.Checked;
            Properties.Settings.Default.Save();
        }
    }
}