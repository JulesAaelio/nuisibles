using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace tp_nuisibles
{
    

    public class Simulation
    {
        public static int Tick = 0;
        public Timer timer = new System.Timers.Timer();
        public Ecosystem Ecosystem { get; set; } = new Ecosystem(20, 20);


        
        public Simulation(int timerInterval = 500)
        {
            this.timer.Interval = timerInterval; //one minute
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
        }

        public void Start()
        {
            this.timer.Start();
            Application.Run(this.Ecosystem.EcosystemForm);
        }

       
        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Tick++;
           this.Ecosystem.MoveAllRandomly();
            Console.WriteLine("refresh");
            this.Ecosystem.EcosystemForm.Refresh();
        }
        
    }
}