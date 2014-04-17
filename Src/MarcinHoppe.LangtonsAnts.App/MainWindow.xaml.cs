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
    public partial class MainWindow : Window
    {
        private UniformGridBoard board;
        private Simulation simulation;

        public MainWindow()
        {
            InitializeComponent();
            CreateSimulationOnBoard();
            StartTimerForSimulation();
        }

        private void CreateSimulationOnBoard()
        {
            board = new UniformGridBoard(grid);
            simulation = new Simulation(board);
        }

        private void StartTimerForSimulation()
        {
            var timer = new DispatcherTimer();
            timer.Tick += MakeSimulationStep;
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Start();
        }

        private void MakeSimulationStep(object sender, EventArgs e)
        {
            simulation.MakeStep();
        }
    }
}
