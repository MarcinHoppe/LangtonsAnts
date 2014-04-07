using System;

namespace MarcinHoppe.LangtonsAnts
{
    public class Position : IEquatable<Position>
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool Equals(Position other)
        {
            return Row == other.Row && Column == other.Column;
        }
    }
}
