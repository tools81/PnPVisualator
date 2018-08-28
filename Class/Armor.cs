using System.Data;

namespace Pen_and_Paper_Visualator.Class
{
    internal class Armor
    {
        public static string Name { get; set; }
        public static int General { get; set; }
        public static int Ballistic { get; set; }
        public static string Threat_Down { get; set; }
        public static int Requirement { get; set; }
        public static int Defense_Penalty { get; set; }
        public static int Speed_Penalty { get; set; }
        public static int Cost { get; set; }
        public static string Image { get; set; }
        public static string Description { get; set; }
        public static DataTable ArmorTable { get; set; }
    }
}