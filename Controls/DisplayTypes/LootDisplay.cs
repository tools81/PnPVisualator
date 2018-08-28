using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class LootDisplay : UserControl
    {
        public static string ItemName { get; set; }

        public static string ID { get; set; }

        public static string Image { get; set; }

        public static int ItemSize { get; set; }

        public static int Value { get; set; }

        public static string Type { get; set; }

        public LootDisplay()
        {
            InitializeComponent();

            lblName.Text = ItemName;
            lblID.Text = ID;
            lblSize.Text = ItemSize.ToString();
            lblValue.Text = Value.ToString();
            lblType.Text = Type.ToString();

            imgItem.ImageLocation = Properties.Settings.Default.DataLocation + @"Item_Images\" + Image;
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (Type != "Cash")
            {
                CharacterUpdate.AddItemToCharacter(lblName.Text, Type, lblID.Text);
            }
            else
            {
                CharacterUpdate.AddItemToCharacter(lblName.Text, Type, lblID.Text, Convert.ToInt32(lblValue.Text));
            }
            Global.RemoveLootItem(ID);
            Global.PlayerForm.UpdateEquipmentTab();
        }
    }
}
