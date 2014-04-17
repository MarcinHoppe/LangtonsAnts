using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MarcinHoppe.LangtonsAnts.App
{
    static class BrushExtensions
    {
        static Dictionary<Brush, Colors> colorMapping = new Dictionary<Brush, Colors>
        {
            { Brushes.White, Colors.White },
            { Brushes.Black, Colors.Black }
        };

        static Dictionary<Brush, Brush> flipMapping = new Dictionary<Brush, Brush>
        {
            { Brushes.White, Brushes.Black },
            { Brushes.Black, Brushes.White }
        };

        public static Colors AsColor(this Brush brush)
        {
            return colorMapping[brush];
        }

        public static Brush Flip(this Brush brush)
        {
            return flipMapping[brush];
        }
    }
}
