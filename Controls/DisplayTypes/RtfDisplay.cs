using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls.DisplayTypes
{
    public partial class RtfDisplay : UserControl
    {
        public static string Description { get; set; }

        public RtfDisplay()
        {
            InitializeComponent();
            txtDescription.Rtf = Description;
        }
    }
}
