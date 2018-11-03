using System;
using System.Timers;

namespace tp_nuisibles
{
    

    public class Simulation
    {
        public Timer timer = new System.Timers.Timer();
        public Ecosystem Ecosystem { get; set; } = new Ecosystem(8, 8);

        public Simulation(int timerInterval = 100)
        {
            this.timer.Interval = timerInterval; //one minute
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
        }

        public void Start()
        {
            this.timer.Start();
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
           this.Ecosystem.MoveAllRandomly();
        }
        
    }
}