using System;

namespace MarcinHoppe.LangtonsAnts
{
    public class Simulation
    {
        private Board board;
        private Ant ant = new Ant();

        public Simulation(Board board)
        {
            this.board = board;
            ant.Position = board.Center;
        }

        public void MakeStep()
        {
            if (AntOnBoard())
            {
                FlipColor();
                MoveAnt();
            }
        }

        private bool AntOnBoard()
        {
            return board.Contains(ant.Position);
        }

        private void FlipColor()
        {
            board.ToggleColorAt(ant.Position);
        }

        private void MoveAnt()
        {
            ant.MoveOn(board);
        }
    }
}
