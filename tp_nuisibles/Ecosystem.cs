using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace tp_nuisibles
{
    public abstract class Ecosystem
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

        protected abstract void Init();

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

        public void ReplaceNuisible(Nuisible toReplace, Nuisible replacement)
        {
            if (this.Nuisibles.Remove(toReplace))
            {
                this.Nuisibles.Add(replacement);
            };

        }

        public void OnNuisibleMove()
        {
            this.EcosystemForm.Refresh();
        }
    }
    
    
}