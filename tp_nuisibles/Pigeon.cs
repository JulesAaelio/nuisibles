namespace tp_nuisibles
{
    public class Pigeon:Nuisible
    {
        public Pigeon(Ecosystem ecosystem, int speed, Position position, STATE state = STATE.Alive) : base(ecosystem, speed, position, state)
        {
        }

        public override void GetCollided(ICollideable collider)
        {
            base.GetCollided(collider);
            if (this.IsCollideable())
            {
                if (collider.GetType() == typeof(Rat)) 
                {
                    this.Die();
                }
            }
        }
    }
}