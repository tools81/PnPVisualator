using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class GMWeaponControl : UserControl
    {
        public static string WeaponName { get; set; }
        public static string WeaponId { get; set; }
        public static string Image { get; set; }
        public static string Damage { get; set; }
        public static string CapacityCurrent { get; set; }
        public static string CapacityMax { get; set; }
        public static string Range { get; set; }
        public static bool ShowAmmoControl { get; set; }

        public GMWeaponControl()
        {
            InitializeComponent();

            lblName.Text = WeaponName;
            lblWeaponId.Text = WeaponId;
            lblDamage.Text = Damage;
            lblCapacityCurrent.Text = CapacityCurrent;
            lblCapacityMax.Text = CapacityMax;
            lblAmmo.Text = CapacityCurrent + "/" + CapacityMax;
            lblRange.Text = Range;
            imgWeapon.ImageLocation = Image;
            pnlAmmoControl.Visible = ShowAmmoControl;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Global.SelectedActorType == Global.CharType.Character)
            {
                CharacterUpdate.ManageAmmo(Global.CharacterFolder + Global.SelectedActorID + ".xml", lblWeaponId.Text, Convert.ToInt32(numAdd.Value));
            }
            else if (Global.SelectedActorType == Global.CharType.NPC)
            {
                CharacterUpdate.ManageAmmo(Global.NpcFolder + Global.SelectedActorID + ".xml", lblWeaponId.Text, Convert.ToInt32(numAdd.Value));
            }
            else
            {
                //TODO: Exception
            }
            lblAmmo.Text = (Convert.ToInt32(lblCapacityCurrent.Text) + numAdd.Value) + "/" + lblCapacityMax.Text;
        }

        private void btnSubt_Click(object sender, EventArgs e)
        {
            if (Global.SelectedActorType == Global.CharType.Character)
            {
                CharacterUpdate.ManageAmmo(Global.CharacterFolder + Global.SelectedActorID + ".xml", lblWeaponId.Text, Convert.ToInt32(numSubt.Value * -1));
            }
            else if (Global.SelectedActorType == Global.CharType.NPC)
            {
                CharacterUpdate.ManageAmmo(Global.NpcFolder + Global.SelectedActorID + ".xml", lblWeaponId.Text, Convert.ToInt32(numSubt.Value * -1));
            }
            else
            {
                //TODO: Exception
            }
            lblAmmo.Text = (Convert.ToInt32(lblCapacityCurrent.Text) - numSubt.Value) + "/" + lblCapacityMax.Text;
        }

        private void imgAmmo_Click(object sender, EventArgs e)
        {
            int fullReload = Convert.ToInt32(lblCapacityMax.Text) - Convert.ToInt32(lblCapacityCurrent.Text);
            if (Global.SelectedActorType == Global.CharType.Character)
            {
                CharacterUpdate.ManageAmmo(Global.CharacterFolder + Global.SelectedActorID + ".xml", lblWeaponId.Text, fullReload);
            }
            else if (Global.SelectedActorType == Global.CharType.NPC)
            {
                CharacterUpdate.ManageAmmo(Global.NpcFolder + Global.SelectedActorID + ".xml", lblWeaponId.Text, fullReload);
            }
            else
            {
                //TODO: Exception
            }
            Global.PlaySound(Global.Sound_Reload, false);

            lblAmmo.Text = lblCapacityMax.Text + "/" + lblCapacityMax.Text;
        }

        private void imgBreak_Click(object sender, EventArgs e)
        {
            Global.PlaySound(Global.Sound_Break, false);
            //TODO: Add weapon break functionality
        }
    }
}
