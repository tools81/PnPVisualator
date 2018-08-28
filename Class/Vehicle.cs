using System.Data;

namespace Pen_and_Paper_Visualator.Class
{
    internal class Vehicle
    {
        public static string Name { get; set; }
        public static int Durability { get; set; }
        public static int Size { get; set; }
        public static int Acceleration { get; set; }
        public static int Safe_Speed { get; set; }
        public static int Speed { get; set; }
        public static int Handling { get; set; }
        public static int Cost { get; set; }
        public static int Occupancy { get; set; }
        public static int Structure { get; set; }
        public static int Capacity { get; set; }
        public static string Image { get; set; }
        public static string Description { get; set; }
        public static DataTable VehicleTable { get; set; }
        public static string[] Vehicle_Cargo { get; set; }
    }
}