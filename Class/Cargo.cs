using System;
using System.Collections.Generic;
using System.Text;

namespace Pen_and_Paper_Visualator.Class
{
    public class Cargo
    {
        private Guid VehicleID { get; set; }
        private Guid ItemID { get; set; }
        private string Type { get; set; }
        private string Item { get; set; }

        public Cargo(Guid vehicleID, Guid itemID, string type, string item)
        {
            VehicleID = vehicleID;
            ItemID = itemID;
            Type = type;
            Item = item;
        }
    }
}
