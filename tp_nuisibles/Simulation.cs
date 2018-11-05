using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace tp_nuisibles
{
    

    public class Simulation
    {
        public Timer timer = new System.Timers.Timer();
        public Ecosystem Ecosystem { get; set; }

        public Simulation(int timerInterval = 500)
        {
            this.timer.Interval = timerInterval; //one minute
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            this.Ecosystem = new CitadinEcosystemFactory().Generate(4,4);
        }

        public void Start()
        {
            this.timer.Start();
            Application.Run(this.Ecosystem.EcosystemForm);
        }

       
        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
           this.Ecosystem.MoveAllRandomly();
        }
        
    }
}