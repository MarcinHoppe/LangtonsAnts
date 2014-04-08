using System;

namespace MarcinHoppe.LangtonsAnts
{
    public abstract class Direction
    {
        public abstract Direction TurnRight();

        public abstract Direction TurnLeft();

        public abstract Position Translate(Position position);

        public static Direction Up() { return new Up(); }

        public static Direction Down() { return new Down(); }

        public static Direction Left() { return new Left(); }

        public static Direction Right() { return new Right(); }
    }

    public class Up : Direction
    {
        public override Direction TurnRight() { return Direction.Right(); }

        public override Direction TurnLeft() { return Direction.Left(); }

        public override Position Translate(Position position)
        {
            return Position.At(position.Row - 1, position.Column);
        }
    }

    public class Down : Direction
    {
        public override Direction TurnRight() { return Direction.Left(); }

        public override Direction TurnLeft() { return Direction.Right(); }

        public override Position Translate(Position position)
        {
            return Position.At(position.Row + 1, position.Column);
        }
    }

    public class Left : Direction
    {
        public override Direction TurnRight() { return Direction.Up(); }

        public override Direction TurnLeft() { return Direction.Down(); }

        public override Position Translate(Position position)
        {
            return Position.At(position.Row, position.Column - 1);
        }
    }

    public class Right : Direction
    {
        public override Direction TurnRight() { return Direction.Down(); }

        public override Direction TurnLeft() { return Direction.Up(); }

        public override Position Translate(Position position)
        {
            return Position.At(position.Row, position.Column + 1);
        }
    }
}
