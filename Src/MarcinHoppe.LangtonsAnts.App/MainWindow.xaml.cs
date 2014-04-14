using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MarcinHoppe.LangtonsAnts.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Board
    {
        private const int BoardSize = 11;

        public MainWindow()
        {
            InitializeComponent();
            SetupGrid();
            StartSimulation();
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

        private void StartSimulation()
        {
            var simulation = new Simulation(this);
            var timer = new DispatcherTimer();
            timer.Tick += (object sender, EventArgs args) => simulation.MakeStep();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }
    }
}
