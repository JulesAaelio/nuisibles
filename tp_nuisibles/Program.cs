using System;
using System.Drawing;
using System.Windows.Forms; 

namespace tp_nuisibles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Simulation simulation = new Simulation();
            simulation.Interval = 500;
            simulation.SizeX = 10;
            simulation.SizeY = 10;
            simulation.EcosystemType = EcosystemType.Citadin;
            simulation.Init();
            simulation.Start();
        }
    }
}