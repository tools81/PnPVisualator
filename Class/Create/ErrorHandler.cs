using System.Text;

namespace Pen_and_Paper_Visualator.Class.Create
{
    public static class ErrorHandler
    {
        public static StringBuilder Errors = new StringBuilder();

        public static void CheckAttributes(int power, int finesse, int resistance)
        {
            if (power > 5 || finesse > 5 || resistance > 5)
            {
                Errors.AppendLine("No attribute branch may be greater than 5 at creation.");
            }
        }

        public static void CheckSkills(int mental, int physical, int social)
        {
            if (mental > 11 || physical > 11 || social > 11)
            {
                Errors.AppendLine("No skill branch may be greater than 11 at creation.");
            }
        }

        public static void CheckMerits(int meritTotal)
        {
            if (meritTotal > 7)
            {
                Errors.AppendLine($"Merit points at creation are limited to 7. {meritTotal} was given.");
            }
        }
    }
}
