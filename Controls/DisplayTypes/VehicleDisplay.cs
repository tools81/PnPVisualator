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
    public partial class VehicleDisplay : UserControl
    {
        private static string _Name;

        public static string VehicleName
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private static string _Image;

        public static string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        private static int _Cost;

        public static int Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        private static int _Size;

        public static int ItemSize
        {
            get { return _Size; }
            set { _Size = value; }
        }

        private static int _Durability;

        public static int Durability
        {
            get { return _Durability; }
            set { _Durability = value; }
        }

        private static int _Structure;

        public static int Structure
        {
            get { return _Structure; }
            set { _Structure = value; }
        }

        private static int _Acceleration;

        public static int Acceleration
        {
            get { return _Acceleration; }
            set { _Acceleration = value; }
        }

        private static int _Speed;

        public static int Speed
        {
            get { return _Speed; }
            set { _Speed = value; }
        }

        private static int _Safe_Speed;

        public static int Safe_Speed
        {
            get { return _Safe_Speed; }
            set { _Safe_Speed = value; }
        }

        private static int _Handling;

        public static int Handling
        {
            get { return _Handling; }
            set { _Handling = value; }
        }

        private static int _Occupancy;

        public static int Occupancy
        {
            get { return _Occupancy; }
            set { _Occupancy = value; }
        }

        private static int _Capacity;

        public static int Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }

        private static string _Description;

        public static string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public VehicleDisplay()
        {
            InitializeComponent();

            lblActiveVehicle.Text = _Name;
            lblCost.Text = _Cost.ToString();
            lblSize.Text = _Size.ToString();
            lblDurability.Text = _Durability.ToString();
            lblStucture.Text = _Structure.ToString();
            lblAcceleration.Text = _Acceleration.ToString();
            lblMaxSpeed.Text = _Speed.ToString();
            lblSafeSpeed.Text = _Safe_Speed.ToString();
            lblHandling.Text = _Handling.ToString();
            lblOccupancy.Text = _Occupancy.ToString();
            lblCapacity.Text = _Capacity.ToString();
            txtDesc.Rtf = RtfHelper.PlainTextToRtf(_Description);
            imgVehicle.ImageLocation = Properties.Settings.Default.DataLocation + @"Vehicle_Images\" + _Image;
        }
    }
}
