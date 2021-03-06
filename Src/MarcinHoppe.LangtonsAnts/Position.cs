﻿using System;

namespace MarcinHoppe.LangtonsAnts
{
    public struct Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public override string ToString()
        {
            return string.Format("({0},{1})", Row, Column);
        }

        public static Position At(int row, int column)
        {
            return new Position { Row = row, Column = column };
        }
    }
}
