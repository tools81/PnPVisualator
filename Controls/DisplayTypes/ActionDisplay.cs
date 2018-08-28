using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class ActionDisplay : UserControl
    {
        public static string ActionName { get; set; }
        //public static string Image { get; set; }
        public static string Extended { get; set; }
        public static string Success { get; set; }
        public static DataTable Data { get; set; }
        public static DataTable Contested { get; set; }

        public ActionDisplay()
        {
            InitializeComponent();

            lblName.Text = ActionName;
            lblExtended.Text = Extended;
            lblSuccess.Text = Success;

            gridDetails.DataSource = Data;
            gridDetails.Columns[0].Width = 90;
            gridDetails.Columns[1].Width = 115;
            gridDetails.Columns[2].Width = 40;

            if (Contested.Rows.Count < 1)
                gridContested.Visible = false;
            else
            {
                gridContested.DataSource = Contested;
                gridContested.Columns[0].Width = 70;
                gridContested.Columns[1].Width = 80;
                gridContested.Columns[2].Width = 95;
            }            

            int sum = 0;
            for (int i = 0; i < gridDetails.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(gridDetails.Rows[i].Cells[2].Value);
            }
            lblTotal.Text = sum.ToString();
        }
    }
}
