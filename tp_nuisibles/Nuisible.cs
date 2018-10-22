namespace tp_nuisibles
{
    public class Nuisible
    {
        public enum STATE
        {
            DEAD = 0,
            ALIVE = 1,
            ZOMBIE = 2
        }
        public int Speed { get; set; }
        public STATE State { get; set; }
        public Position Position { get; set; }

        public Nuisible(int speed, Position position, STATE state = STATE.ALIVE)
        {
            this.Speed = speed;
            this.State = state;
            this.Position = position;
        }
    }
}