using System;

namespace MarcinHoppe.LangtonsAnts
{
    class Ant
    {
        Direction direction = Direction.Up();

        public Position Position { get; set; }

        public void MoveOn(Board board)
        {
            if (SquareIsWhiteOn(board))
            {
                TurnRight();
            }
            else if (SquareIsBlackOn(board))
            {
                TurnLeft();
            }
            MoveForward();
        }

        private bool SquareIsWhiteOn(Board board)
        {
            return board.ColorAt(Position) == Colors.White;
        }

        private bool SquareIsBlackOn(Board board)
        {
            return board.ColorAt(Position) == Colors.Black;
        }

        private void TurnRight()
        {
            direction = direction.TurnRight();
        }

        private void TurnLeft()
        {
            direction = direction.TurnLeft();
        }

        private void MoveForward()
        {
            Position = direction.Translate(Position);
        }
    }
}
