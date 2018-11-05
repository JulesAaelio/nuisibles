using System;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;

namespace tp_nuisibles
{
    public abstract class NuisibleDecorator: Nuisible
    {
        protected Nuisible Nuisible { get; set; }

        public override STATE State
        {
            get { return Nuisible.State; }
            set { Nuisible.State = value; }
        }

        public override Position Position
        {
            get { return Nuisible.Position; }
            set { Nuisible.Position = value; }
        }

        public override Ecosystem Ecosystem
        {
            get { return this.Nuisible.Ecosystem; }
            set { Nuisible.Ecosystem = value; }
        }

        public override Color Color
        {
            
            get { return this.Nuisible.Color; }
            set { Nuisible.Color = value; }
        }

        public override int Speed
        {
            get { return Nuisible.Speed; }
            set { Nuisible.Speed = value; }
        }

        public override Guid Guid
        {
            get { return Nuisible.Guid; }
        }

        public override IMovingStrategy MovingStrategy
        {
            get { return this.Nuisible.MovingStrategy; }
            set { this.Nuisible.MovingStrategy = value; }
        }

        public NuisibleDecorator(Nuisible nuisible)
        {
            this.Nuisible = nuisible;
        }

        public override void Collide(ICollideable collided)
        {
            Nuisible.Collide(collided);
        }

        public override void GetCollided(ICollideable collider)
        {
            Nuisible.GetCollided(collider);
        }

        public override void Zombify()
        {
            Nuisible.Zombify();
        }

        public override string ToString()
        {
            return Nuisible.ToString();
        }
        
    }
}