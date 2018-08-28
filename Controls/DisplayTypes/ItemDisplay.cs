using Pen_and_Paper_Visualator.Class;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class ItemDisplay : UserControl
    {
        public static string ItemName { get; set; }
        public static string Image { get; set; }
        public static int Cost { get; set; }
        public static int ItemSize { get; set; }
        public static int Durability { get; set; }
        public static int Structure { get; set; }
        public static string Description { get; set; }
        public static string Scope { get; set; }
        public static string Damage_Prim { get; set; }
        public static string Damage_Sec { get; set; }
        public static string Capacity { get; set; }
        public static string Range { get; set; }
        public static int Def_General { get; set; }
        public static int Def_Ballistic { get; set; }

        public ItemDisplay()
        {
            InitializeComponent();

            lblActiveItem.Text = ItemName;
            lblCost.Text = Cost.ToString();
            lblSize.Text = ItemSize.ToString();

            gridDetails.Rows.Clear();

            if (Scope != null)
            {
                gridDetails.Rows.Add("Scope", Scope);
            }
            if (Damage_Prim != null)
            {
                gridDetails.Rows.Add("Primary", Damage_Prim);
            }
            if (Damage_Sec != null)
            {
                gridDetails.Rows.Add("Secondary", Damage_Sec);
            }
            if (Capacity != null)
            {
                gridDetails.Rows.Add("Capacity", Capacity);
            }
            if (Range != null)
            {
                gridDetails.Rows.Add("Range", Range);
            }
            if (Def_General > 0)
            {
                gridDetails.Rows.Add("General", Def_General.ToString());
            }
            if (Def_Ballistic > 0)
            {
                gridDetails.Rows.Add("Ballistic", Def_Ballistic.ToString());
            }
            if (Durability > 0)
            {
                gridDetails.Rows.Add("Durability", Durability.ToString());
            }
            if (Structure > 0)
            {
                gridDetails.Rows.Add("Structure", Structure.ToString());
            }

            gridDetails.ColumnHeadersVisible = false;

            txtDesc.Rtf = RtfHelper.PlainTextToRtf(Description);
            imgItem.ImageLocation = Properties.Settings.Default.DataLocation + @"Item_Images\" + Image;
        }       
    }
}