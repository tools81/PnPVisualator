using System.Data;

namespace Pen_and_Paper_Visualator.Class
{
    internal class Item
    {
        public static string Name { get; set; }
        public static int Durability { get; set; }
        public static int Size { get; set; }
        public static int Cost { get; set; }
        public static int Structure { get; set; }
        public static string Image { get; set; }
        public static string Description { get; set; }
        public static DataTable ItemTable { get; set; }
    }
}