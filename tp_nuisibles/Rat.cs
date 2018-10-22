namespace tp_nuisibles
{
    public class Rat: Nuisible
    {
        public Rat(int speed, Position position, STATE state = STATE.ALIVE) : base(speed, position, state)
        {
        }

        public override string ToString()
        {
            if (this.State == STATE.ZOMBIE)
            {
                return "Z";
            }
            else
            {
                return "R";
            }
        }
    }
}