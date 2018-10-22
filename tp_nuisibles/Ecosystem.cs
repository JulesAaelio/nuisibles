using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace tp_nuisibles
{
    public class Ecosystem
    {
        private Random random  = new Random();
        private Nuisible[,] nuisibles { get; set; }
        
        public Ecosystem(int x, int y)
        {
            this.nuisibles = new Nuisible[y, x];
            this.init();
        }

        public void show()
        {
            for(int i = 0; i <= nuisibles.GetUpperBound(1); i++)
            {
                for(int j = 0; j <= nuisibles.GetUpperBound(0); j++)
                {
                    if (nuisibles[j,i] != null && nuisibles[j, i].GetType() == typeof(Nuisible))
                    {
                        Console.Write('A');
                    }
                    else
                    {
                        Console.Write('x');
                    }
                    Console.Write(' ');
                }
                Console.WriteLine(' ');
            }
        }

        private void init()
        {
            for (int i = 0; i < nuisibles.Length / 2; i++)
            {
                int x = random.Next(0, this.nuisibles.GetUpperBound(1));
                int y = random.Next(0, this.nuisibles.GetUpperBound(0));
            
                this.nuisibles[y,x] = new Nuisible();
            }
            
     
            
        }
    }
}