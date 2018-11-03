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
            simulation.Start();
        }
    }
}