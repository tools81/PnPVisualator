using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class CashControl : UserControl
    {
        private readonly string SmallCash = Global.ItemImagesFolder + "Cash_Image.jpg";
        private readonly string MedCash = Global.ItemImagesFolder + "Cash2_Image.jpg";
        private readonly string LargeCash = Global.ItemImagesFolder + "Cash3_Image.jpg";

        public CashControl()
        {
            InitializeComponent();

            imgCash1.ImageLocation = SmallCash;
            imgCash2.ImageLocation = MedCash;
            imgCash3.ImageLocation = LargeCash;
        }

        private void btnCash10_Click(object sender, EventArgs e)
        {
            Global.AddLootItem("Cash", 0, 10, "Cash_Image.jpg", "Cash");
        }

        private void btnCash20_Click(object sender, EventArgs e)
        {
            Global.AddLootItem("Cash", 0, 20, "Cash_Image.jpg", "Cash");
        }

        private void btnCash50_Click(object sender, EventArgs e)
        {
            Global.AddLootItem("Cash", 0, 50, "Cash_Image.jpg", "Cash");
        }

        private void btnCash100_Click(object sender, EventArgs e)
        {
            Global.AddLootItem("Cash", 0, 100, "Cash2_Image.jpg", "Cash");
        }

        private void btnCash250_Click(object sender, EventArgs e)
        {
            Global.AddLootItem("Cash", 0, 250, "Cash2_Image.jpg", "Cash");
        }

        private void btnCash500_Click(object sender, EventArgs e)
        {
            Global.AddLootItem("Cash", 0, 500, "Cash2_Image.jpg", "Cash");
        }

        private void btnCash1000_Click(object sender, EventArgs e)
        {
            Global.AddLootItem("Cash", 0, 1000, "Cash3_Image.jpg", "Cash");
        }

        private void btnAddCash_Click(object sender, EventArgs e)
        {
            int lvCashValue = Convert.ToInt32(numCash.Value);
            string lvCashImage = "Cash_Image.jpg";

            if (lvCashValue >= 100)
                lvCashImage = "Cash2_Image.jpg";
            if (lvCashValue >= 1000)
                lvCashImage = "Cash3_Image.jpg";

            Global.AddLootItem("Cash", 0, lvCashValue, lvCashImage, "Cash");
        }
    }
}
