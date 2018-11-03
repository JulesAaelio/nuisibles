using System.Drawing;

namespace tp_nuisibles
{
    public class Zombie: Nuisible
    {
        public Zombie(Ecosystem ecosystem, int speed, Position position, STATE state = STATE.Alive) : base(ecosystem, speed, position, state)
        {
            this.Color = Color.Black;
        }

        public override void Zombify() {}


    }
}