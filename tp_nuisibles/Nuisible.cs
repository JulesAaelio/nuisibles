using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace tp_nuisibles
{
    public abstract class Nuisible : ICollideable
    {
        public enum STATE
        {
            Dead = 0,
            Alive = 1
        }

        public virtual int Speed { get; set; }
        public virtual STATE State { get; set; }
        public virtual Position Position { get; set; }
        public virtual Ecosystem Ecosystem { get; set; }
        public virtual Color Color { get; set; }
        public virtual Guid Guid { get; set; } = Guid.NewGuid();
        public virtual IMovingStrategy MovingStrategy { get; set; }

        protected Nuisible()
        {
        }

        public Nuisible(Ecosystem ecosystem, int speed, Position position, STATE state = STATE.Alive)
        {
            this.Ecosystem = ecosystem;
            this.Speed = speed;
            this.State = state;
            this.Position = position;
            this.Color = Color.Gray;
            this.MovingStrategy = new PeacefulMovingStrategy(this);
        }

        public Position SelectNextPosition()
        {
            return this.MovingStrategy.SelectNextPosition();
        }

        public void MoveRandomly()
        {
            this.MoveTo(this.SelectNextPosition());
        }

        public void MoveTo(Position position)
        {
            if (this.State != STATE.Dead)
            {
                this.Position = position;
                foreach (Nuisible nuisible in this.Ecosystem.NuisiblesAtPosition(this.Position))
                {
                    if (!nuisible.Equals(this))
                    {
                        this.Collide(nuisible);
                    }
                }

                this.Ecosystem.OnNuisibleMove();
            }
        }

        public virtual void Collide(ICollideable collided)
        {
            if (this.IsCollideable())
            {
                Console.WriteLine($" {this.ToString()} is colliding {collided.ToString()}");
                collided.GetCollided(this);
                if (collided.GetType() == typeof(Zombie) && this.GetType() != typeof(Zombie))
                {
                    this.Zombify();
                    Console.WriteLine($" {this.ToString()} turned into a Zombie. A");
                }
            }
        }

        public virtual void GetCollided(ICollideable collider)
        {
            if (this.IsCollideable())
            {
                Console.WriteLine($" {this.ToString()} is getting collided by {collider.ToString()}");
                if (collider.GetType() == typeof(Zombie) && this.GetType() != typeof(Zombie))
                {
                    this.Zombify();
                    Console.WriteLine($" {this.ToString()} turned into a Zombie. B");
                }
            }
        }

        public bool IsCollideable()
        {
            return this.State != STATE.Dead;
        }

        public void Die()
        {
            Console.WriteLine($" {this.ToString()} died");
            this.State = STATE.Dead;
            this.Color = Color.White;
        }

        public virtual void Zombify()
        {
            Zombie zombie = new Zombie(this.Ecosystem, this.Speed, this.Position);
            this.Ecosystem.ReplaceNuisible(this, zombie);
        }

        public override string ToString()
        {
            switch (State)
            {
                case STATE.Dead:
                    return this.Guid.ToString();
                default:
                    return this.GetType().ToString() + this.Guid.ToString();
            }
        }

        public override int GetHashCode()
        {
            return this.Guid.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Guid == ((Nuisible) obj).Guid;
        }
    }
}