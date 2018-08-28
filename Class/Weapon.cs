using System.Data;

namespace Pen_and_Paper_Visualator.Class
{
    internal class Weapon
    {
        public static string Name { get; set; }
        public static int Range { get; set; }
        public static int Size { get; set; }
        public static int Damage { get; set; }
        public static string Threat { get; set; }
        public static int Requirement { get; set; }
        public static string Material { get; set; }
        public static int Durability { get; set; }
        public static int Structure { get; set; }
        public static int Cost { get; set; }
        public static string Trained { get; set; }
        public static string Image { get; set; }
        public static string Description { get; set; }
        public static DataTable WeaponTable { get; set; }
    }
}