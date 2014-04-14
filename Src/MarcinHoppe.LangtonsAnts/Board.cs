using System;

namespace MarcinHoppe.LangtonsAnts
{
    public interface Board
    {
        Position Center { get; }

        bool Contains(Position position);

        void FlipColorAt(Position position);

        Colors ColorAt(Position position);
    }
}
