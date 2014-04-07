using System;

namespace MarcinHoppe.LangtonsAnts
{
    public struct Position : IEquatable<Position>
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool Equals(Position other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", Row, Column);
        }
    }
}
