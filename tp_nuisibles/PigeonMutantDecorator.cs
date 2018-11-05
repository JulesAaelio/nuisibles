using System;
using System.Drawing;

namespace tp_nuisibles
{
    public class PigeonMutantDecorator: NuisibleDecorator
    {
        public PigeonMutantDecorator(Pigeon nuisible) : base(nuisible)
        {
        }

        public override void GetCollided(ICollideable collider)
        {
            if (collider.GetType() == typeof(Rat))
            {
                Console.WriteLine($"{this.ToString()} survived to rat attack");
            }
            else
            {
                this.Nuisible.GetCollided(collider);
            }
        }

        public override Color Color
        {
            get
            {
                return Color.Fuchsia;
            }
        }
    }
}