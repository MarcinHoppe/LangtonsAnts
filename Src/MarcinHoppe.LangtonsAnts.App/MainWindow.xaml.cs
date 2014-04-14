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

namespace MarcinHoppe.LangtonsAnts.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int BoardSize = 11;

        public MainWindow()
        {
            InitializeComponent();
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
            grid.Children.Add(new Rectangle() 
            { 
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 0.2
            });
        }
    }
}
