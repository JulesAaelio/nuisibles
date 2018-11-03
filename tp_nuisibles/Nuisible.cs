using System;
using System.Collections.Generic;
using System.Linq;

namespace tp_nuisibles
{
    public class Nuisible: ICollideable
    {
        public enum STATE
        {
            Dead = 0,
            Alive = 1
        }
        public int Speed { get; set; }
        public STATE State { get; set; }
        public Position Position { get; set; }
        private Ecosystem Ecosystem { get; set;  }

        public Nuisible(Ecosystem ecosystem, int speed, Position position, STATE state = STATE.Alive)
        {
            this.Ecosystem = ecosystem;
            this.Speed = speed;
            this.State = state;
            this.Position = position;
        }

        public Position SelectNextPosition()
        {
            List<Position> positions = new List<Position>();
            int xMax = this.Position.X + this.Speed;
            int yMax = this.Position.Y + this.Speed;
            int xMin = this.Position.X - this.Speed;
            int yMin = this.Position.Y - this.Speed;

            if (xMax > this.Ecosystem.DimX)
                xMax = this.Ecosystem.DimX;

            if (yMax > this.Ecosystem.DimY)    
                yMax = this.Ecosystem.DimY;

            if (yMin < 0)
                yMin = 0;

            if (xMin < 0)
                xMin = 0;

            positions.Add(new Position(yMax, xMin));
            positions.Add(new Position(yMax, this.Position.X));
            positions.Add(new Position(yMax, xMax));

            positions.Add(new Position(this.Position.Y, xMin));
            positions.Add(new Position(this.Position.Y, this.Position.X));
            positions.Add(new Position(this.Position.Y, xMax));

            positions.Add(new Position(yMin, xMin));
            positions.Add(new Position(yMin, this.Position.X));
            positions.Add(new Position(yMin, xMax));

            Position position = positions.ElementAt(this.Ecosystem.Random.Next(0, positions.Count));
            return position;
        }

        public void MoveRandomly()
        {
            this.MoveTo(this.SelectNextPosition());
        }

        public void MoveTo(Position position)
        {
            this.Position = position;
            foreach (Nuisible nuisible in this.Ecosystem.NuisiblesAtPosition(this.Position))
            {
                this.Collide(nuisible);
            }
        }

        public virtual void Collide(ICollideable collided)
        {
            if (this.IsCollideable())
            {
                Console.WriteLine($" {this.ToString()} is colliding {collided.ToString()}");
                collided.GetCollided(this);
            }
        }

        public virtual void GetCollided(ICollideable collider)
        {
            if (this.IsCollideable())
            {
                Console.WriteLine($" {this.ToString()} is getting collided by {collider.ToString()}");
                if (collider.GetType() == typeof(Zombie))
                {
                    this.Zombify();
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
                        return "DEAD";
                    default:
                        return this.GetType().ToString();
            }
        }
    }
}