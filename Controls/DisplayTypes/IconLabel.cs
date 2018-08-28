using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class IconLabel : UserControl
    {    
        private string _Image;

        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        private string _Display;

        public string Display
        {
            get { return _Display; }
            set { _Display = value; }
        }

        private Guid _ID;

        public Guid ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private Type _Type;

        public enum Type
        {
            Item,
            Vehicle,
            Discipline,
            Gift,
            Rote,
            Character
        }

        private ControlSize _Size;

        public enum ControlSize
        {
            Small,
            Medium,
            Large
        }

        public Type DisplayType
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public ControlSize DisplaySize
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public IconLabel()
        {
            InitializeComponent();           
        }

        private void IconLabel_Load(object sender, EventArgs e)
        {
            lblString.Text = _Display;

            switch (_Type)
            {
                case Type.Item:
                    imgIcon.ImageLocation = Properties.Settings.Default.DataLocation + @"Item_Images\" + _Image;
                    break;
                case Type.Vehicle:
                    imgIcon.ImageLocation = Properties.Settings.Default.DataLocation + @"Vehicle_Images\" + _Image;
                    break;
                case Type.Discipline:
                    imgIcon.ImageLocation = Properties.Settings.Default.DataLocation + @"Discipline_Images\" + _Image;
                    break;
                case Type.Gift:
                    imgIcon.ImageLocation = Properties.Settings.Default.DataLocation + @"Discipline_Images\" + _Image;
                    break;
                case Type.Rote:
                    imgIcon.ImageLocation = Properties.Settings.Default.DataLocation + @"Discipline_Images\" + _Image;
                    break;
                case Type.Character:
                    imgIcon.ImageLocation = Properties.Settings.Default.DataLocation + @"Character_Images\" + _Image;
                    break;
                default:
                    break;
            }

            Font fnt;
            switch (_Size)
            {
                case ControlSize.Large:
                    this.Height *= 3;
                    this.Width += 120;
                    imgIcon.Height *= 3;
                    imgIcon.Width *= 3;

                    fnt = new Font(Font.FontFamily, 18);
                    lblString.Font = fnt;
                    lblString.Left += 50;
                    break;
                case ControlSize.Medium:
                    this.Height *= 2;
                    this.Width += 90;
                    imgIcon.Height *= 2;
                    imgIcon.Width *= 2;

                    fnt = new Font(Font.FontFamily, 15);
                    lblString.Font = fnt;
                    lblString.Left += 20;
                    break;
                default:
                    break;
            }
        }
    }
}
