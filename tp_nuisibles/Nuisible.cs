using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace tp_nuisibles
{
    public abstract class Nuisible: ICollideable
    {
        public enum STATE
        {
            Dead = 0,
            Alive = 1
        }
        public virtual int Speed { get; set; }
        public virtual  STATE State { get; set; }
        public virtual Position Position { get; set; }
        public virtual Ecosystem Ecosystem { get; set;  }
        public virtual Color Color { get; set; }

        protected Nuisible() {}
        
        public Nuisible(Ecosystem ecosystem, int speed, Position position, STATE state = STATE.Alive)
        {
            this.Ecosystem = ecosystem;
            this.Speed = speed;
            this.State = state;
            this.Position = position;
            this.Color = Color.Gray;
        }

        public Position SelectNextPosition()
        {
            HashSet<Position> positions = new HashSet<Position>();
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

            positions.Add(new Position(xMin, yMax));
            positions.Add(new Position(this.Position.X,yMax));
            positions.Add(new Position(xMax,yMax));

            positions.Add(new Position(xMin, this.Position.Y));
            positions.Add(new Position(xMax, this.Position.Y));

            positions.Add(new Position(xMin, yMin));
            positions.Add(new Position(this.Position.X, yMin));
            positions.Add(new Position(xMax, yMin));

            positions.RemoveWhere((Position pos) => { return pos.Equals(this.Position); });

            Position position = positions.ElementAt(this.Ecosystem.Random.Next(0, positions.Count));
            
            return position;
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
                    Console.WriteLine($" {this.ToString()} turned into a Zombie.");
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
                        return "DEAD";
                    default:
                        return this.GetType().ToString();
            }
        }
    }
}