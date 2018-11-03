using System;
using System.Collections.Generic;

namespace tp_nuisibles
{
    public class Ecosystem
    {
        public Random Random { get; set; } = new Random();
        private List<Nuisible> Nuisibles { get; set; } = new List<Nuisible>();
        public int DimX { get; set; }
        public int DimY { get; set; }

        public Ecosystem(int x, int y)
        {
            this.DimX = x;
            this.DimY = y;
            this.Init();
        }

        public void Show()
        {
            return;
        }

        private void Init()
        {
            int x, y;
            for (int i = 0; i < (DimX * DimY) / 4; i++)
            {
                x = Random.Next(0, this.DimX);
                y = Random.Next(0, this.DimY);

                this.Nuisibles.Add((new Rat(this, 2, new Position(x, y))));
            }

            for (int i = 0; i < (DimX * DimY) / 4; i++)
            {
                x = Random.Next(0, this.DimX);
                y = Random.Next(0, this.DimY);

                this.Nuisibles.Add(new Pigeon(this, 2, new Position(x, y)));
            }

            x = Random.Next(0, this.DimX);
            y = Random.Next(0, this.DimY);
            Nuisible nuisible = new Zombie(this, 2, new Position(x, y));
            this.Nuisibles.Add(nuisible);
        }

        public void MoveAllRandomly()
        {
            foreach (var nuisible in Nuisibles)
            {
                nuisible.MoveRandomly();
            }
        }

        public List<Nuisible> NuisiblesAtPosition(Position position)
        {
            return this.Nuisibles.FindAll(nuisible => nuisible.Position.Equals(position) );
        }

        public void  ReplaceNuisible(Nuisible toReplace, Nuisible replacement)
        {
            this.Nuisibles.Add(replacement);
            this.Nuisibles.Remove(toReplace);
        }
    }
    
    
}