using System;
using System.Collections.Generic;
using System.Linq;

namespace tp_nuisibles
{
    public class RandomMovingStrategy: IMovingStrategy
    {
        private Nuisible _nuisible;
        public RandomMovingStrategy(Nuisible nuisible)
        {
            this._nuisible = nuisible;
            Console.WriteLine(this._nuisible);
        }

        public Position SelectNextPosition()
        {
            HashSet<Position> positions = new HashSet<Position>();
            int xMax = this._nuisible.Position.X + this._nuisible.Speed;
            int yMax = this._nuisible.Position.Y + this._nuisible.Speed;
            int xMin = this._nuisible.Position.X - this._nuisible.Speed;
            int yMin = this._nuisible.Position.Y - this._nuisible.Speed;
        

            if (xMax > this._nuisible.Ecosystem.DimX)
                xMax = this._nuisible.Ecosystem.DimX;

            if (yMax > this._nuisible.Ecosystem.DimY)    
                yMax = this._nuisible.Ecosystem.DimY;

            if (yMin < 0)
                yMin = 0;

            if (xMin < 0)
                xMin = 0;

            positions.Add(new Position(xMin, yMax));
            positions.Add(new Position(this._nuisible.Position.X,yMax));
            positions.Add(new Position(xMax,yMax));

            positions.Add(new Position(xMin, this._nuisible.Position.Y));
            positions.Add(new Position(xMax, this._nuisible.Position.Y));

            positions.Add(new Position(xMin, yMin));
            positions.Add(new Position(this._nuisible.Position.X, yMin));
            positions.Add(new Position(xMax, yMin));

            positions.RemoveWhere((Position pos) => { return pos.Equals(this._nuisible.Position); });

            Position position = positions.ElementAt(this._nuisible.Ecosystem.Random.Next(0, positions.Count));
            
            return position;
        }
    }
}