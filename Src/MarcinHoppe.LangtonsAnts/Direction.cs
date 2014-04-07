using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinHoppe.LangtonsAnts
{
    abstract class Direction
    {
        public abstract Direction TurnRight();

        public abstract Direction TurnLeft();

        public abstract Position Translate(Position position);

        public static Direction Up() { return new Up(); }

        public static Direction Down() { return new Down(); }

        public static Direction Left() { return new Left(); }

        public static Direction Right() { return new Right(); }
    }

    class Up : Direction
    {
        public override Direction TurnRight() { return Direction.Right(); }

        public override Direction TurnLeft() { return Direction.Left(); }

        public override Position Translate(Position position)
        {
            return new Position { Row = position.Row - 1, Column = position.Column };
        }
    }

    class Down : Direction
    {
        public override Direction TurnRight() { return Direction.Left(); }

        public override Direction TurnLeft() { return Direction.Right(); }

        public override Position Translate(Position position)
        {
            return new Position { Row = position.Row + 1, Column = position.Column };
        }
    }

    class Left : Direction
    {
        public override Direction TurnRight() { return Direction.Up(); }

        public override Direction TurnLeft() { return Direction.Down(); }

        public override Position Translate(Position position)
        {
            return new Position { Row = position.Row, Column = position.Column - 1 };
        }
    }

    class Right : Direction
    {
        public override Direction TurnRight() { return Direction.Down(); }

        public override Direction TurnLeft() { return Direction.Up(); }

        public override Position Translate(Position position)
        {
            return new Position { Row = position.Row, Column = position.Column + 1 };
        }
    }
}
