namespace tp_nuisibles
{
    public class Nuisible
    {
        public enum STATE
        {
            DEAD = 0,
            ALIVE = 1
        }
        public float speed { get; set; }
        public STATE state { get; set; }
    }
}