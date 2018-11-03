using System.Drawing;

namespace tp_nuisibles
{
    public class Rat: Nuisible
    {
        public Rat(Ecosystem ecosystem, int speed, Position position, STATE state = STATE.Alive) : base(ecosystem, speed, position, state)
        {
            this.Color = Color.Blue;
        }
        
        public override void GetCollided(ICollideable collider)
        {
            base.GetCollided(collider);
            if (this.IsCollideable())
            {
                if (collider.GetType() == typeof(Pigeon)) 
                {
                    this.Die();
                }
            }
        }
        
    }
}