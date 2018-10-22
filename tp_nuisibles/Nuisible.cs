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
        public float speed { get; set; }
        public STATE state { get; set; }

        public Nuisible(float speed, STATE state = STATE.ALIVE)
        {
            this.speed = speed;
            this.state = state;
        }
    }
}