using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinHoppe.LangtonsAnts
{
    public interface Board
    {
        Position Center { get; }

        bool Contains(Position position);

        void ToggleColorAt(Position position);

        Colors ColorAt(Position Position);
    }
}
