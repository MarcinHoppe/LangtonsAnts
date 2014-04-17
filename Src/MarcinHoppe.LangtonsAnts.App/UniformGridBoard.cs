﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MarcinHoppe.LangtonsAnts.App
{
    class UniformGridBoard : Board
    {
        private const int BoardSize = 71;
        private UniformGrid grid;

        public UniformGridBoard(UniformGrid grid)
        {
            this.grid = grid;
            SetupGrid();
        }

        private void SetupGrid()
        {
            SetDimensions();
            DrawRectangles();
        }

        private void SetDimensions()
        {
            grid.Rows = grid.Columns = BoardSize;
        }

        private void DrawRectangles()
        {
            for (int row = 0; row < BoardSize; ++row)
                for (int column = 0; column < BoardSize; ++column)
                    DrawRectangleAt(row, column);
        }

        private void DrawRectangleAt(int row, int column)
        {
            grid.Children.Add(new Rectangle
            {
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 0.2
            });
        }

        public Position Center
        {
            get { return Position.At(BoardSize / 2, BoardSize / 2); }
        }

        public bool Contains(Position position)
        {
            return OnBoard(position.Row) && OnBoard(position.Column);
        }

        private bool OnBoard(int coordinate)
        {
            return 0 <= coordinate && coordinate < BoardSize;
        }

        public void FlipColorAt(Position position)
        {
            var rectangle = RectangleAt(position);
            rectangle.Fill = FlipFill(rectangle.Fill);
        }

        private Rectangle RectangleAt(Position position)
        {
            return grid.Children[IndexOf(position)] as Rectangle;
        }

        private int IndexOf(Position position)
        {
            return position.Row * BoardSize + position.Column;
        }

        private Brush FlipFill(Brush brush)
        {
            if (brush == Brushes.White)
            {
                return Brushes.Black;
            }
            else
            {
                return Brushes.White;
            }
        }

        public Colors ColorAt(Position position)
        {
            var rectangle = RectangleAt(position);
            if (rectangle.Fill == Brushes.White)
            {
                return Colors.White;
            }
            else
            {
                return Colors.Black;
            }
        }
    }
}