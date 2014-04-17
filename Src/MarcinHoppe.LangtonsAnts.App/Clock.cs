using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MarcinHoppe.LangtonsAnts.App
{
    class Clock
    {
        private Simulation simulation;

        public Clock(Simulation simulation)
        {
            this.simulation = simulation;
        }

        public void Start()
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
