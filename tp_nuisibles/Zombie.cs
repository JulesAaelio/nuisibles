namespace tp_nuisibles
{
    public class Zombie: Nuisible
    {
        public Zombie(Ecosystem ecosystem, int speed, Position position, STATE state = STATE.Alive) : base(ecosystem, speed, position, state)
        {
        }

        public override void Zombify() {}

    }
}