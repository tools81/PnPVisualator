using System.Data;

namespace Pen_and_Paper_Visualator.Class
{
    internal class Trait
    {
        public static string Name { get; set; }
        public static string Type { get; set; }
        public static int Cost { get; set; }
        public static string Attribute { get; set; }
        public static string Skill { get; set; }
        public static int Bonus { get; set; }
        public static int Impairment { get; set; }
        public static string Automatic { get; set; }
        public static string Description { get; set; }
        public static DataTable TraitTable { get; set; }
    }
}