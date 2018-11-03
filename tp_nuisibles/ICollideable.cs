namespace tp_nuisibles
{
    public interface ICollideable
    {
        void Collide(ICollideable collided);

        void GetCollided(ICollideable collider);
    }
}