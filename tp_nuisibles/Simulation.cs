using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace tp_nuisibles
{
    

    public class Simulation
    {
        public Timer timer = new System.Timers.Timer();
        public Ecosystem Ecosystem { get; set; }
        public int Interval { get; set; } = 500;
        public int SizeX { get; set; } = 20;
        public int SizeY { get; set; } = 20;
        public EcosystemType EcosystemType { get; set; } = EcosystemType.Random;

        public Simulation()
        {
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
        }

        public void Init()
        {
            this.timer.Interval = this.Interval; 
            this.Ecosystem = new EcosystemFactory().Generate(this.EcosystemType ,this.SizeX,this.SizeY);
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