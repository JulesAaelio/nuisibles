using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace tp_nuisibles
{
    public class Ecosystem
    {
        public Random Random { get; set; } = new Random();
        public  List<Nuisible> Nuisibles { get; set; } = new List<Nuisible>();
        public int DimX { get; set; }
        public int DimY { get; set; }
        public EcosystemForm EcosystemForm { get; set; }

        public Ecosystem(int x, int y)
        {
            this.DimX = x;
            this.DimY = y;
            this.EcosystemForm = new EcosystemForm(this);
            this.Init();
        }

        public void Show()
        {
            return;
        }

        private void Init()
        {
//            this.Nuisibles.Add((new Rat(this, 1, new Position(0,0))));
            int x, y;
            for (int i = 0; i < 10 && i < (DimX * DimY) / 10; i++)
            {
                x = Random.Next(0, this.DimX);
                y = Random.Next(0, this.DimY);

                this.Nuisibles.Add((new Rat(this, 2, new Position(x, y))));
            }

            for (int i = 0; i < 10 && i < (DimX * DimY) / 10; i++)
            {
                x = Random.Next(0, this.DimX);
                y = Random.Next(0, this.DimY);

                this.Nuisibles.Add(new Pigeon(this, 2, new Position(x, y)));
            }
            
            
            for (int i = 0; i < 2 && i < (DimX * DimY) / 10; i++)
            {
                x = Random.Next(0, this.DimX);
                y = Random.Next(0, this.DimY);

                Nuisible nuisible = new Zombie(this, 2, new Position(x, y));
                this.Nuisibles.Add(nuisible);
            }
            
           
            
        }

        public void MoveAllRandomly()
        {
            Console.WriteLine("move all");
            foreach (var nuisible in Nuisibles)
            {
                nuisible.MoveRandomly();
            }
            Console.WriteLine("end move all");
        }

        public List<Nuisible> NuisiblesAtPosition(Position position)
        {
            return this.Nuisibles.FindAll(nuisible => nuisible.Position.Equals(position) );
        }

        public void ReplaceNuisible(Nuisible toReplace, Nuisible replacement)
        {
            this.Nuisibles.Add(replacement);
            this.Nuisibles.Remove(toReplace);
        }
    }
    
    
}