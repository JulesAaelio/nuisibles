using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace tp_nuisibles
{
    public class Ecosystem
    {
        private Random random = new Random();
        private List<Nuisible> Nuisibles { get; set; } = new List<Nuisible>();
        public int DimX { get; set; }
        public int DimY { get; set; }

        public Ecosystem(int x, int y)
        {
            this.DimX = x;
            this.DimY = y;
            this.init();
        }

        public void show()
        {
            return;
        }

        private void init()
        {
            int x, y;
            for (int i = 0; i < this.Nuisibles.Count; i++)
            {
                x = random.Next(0, this.DimX);
                y = random.Next(0, this.DimY);

                this.Nuisibles.Add((new Rat(2, new Position(x, y))));
            }

            for (int i = 0; i < this.Nuisibles.Count; i++)
            {
                x = random.Next(0, this.DimX);
                y = random.Next(0, this.DimY);

                this.Nuisibles.Add(new Pigeon(2, new Position(x, y)));
            }

            x = random.Next(0, this.DimX);
            y = random.Next(0, this.DimY);
            Nuisible nuisible = new Pigeon(2, new Position(x, y), Nuisible.STATE.ZOMBIE);
            this.Nuisibles.Add(nuisible);
            
            this.move(nuisible);
        }

        private void collide(Nuisible a, Nuisible b)
        {
        }

        private void move(Nuisible nuisible)
        {
            List<Position> positions = new List<Position>();
            int xMax = nuisible.Position.X + nuisible.Speed;
            int yMax = nuisible.Position.Y + nuisible.Speed;
            int xMin = nuisible.Position.X - nuisible.Speed;
            int yMin = nuisible.Position.Y - nuisible.Speed;

            if (xMax > DimX)
                xMax = DimX;

            if (yMax > DimY)
                yMax = DimY;

            if (yMin < 0)
                yMin = 0;

            if (xMin < 0)
                xMin = 0;

            positions.Add(new Position(yMax, xMin));
            positions.Add(new Position(yMax, nuisible.Position.X));
            positions.Add(new Position(yMax, xMax));

            positions.Add(new Position(nuisible.Position.Y, xMin));
            positions.Add(new Position(nuisible.Position.Y, nuisible.Position.X));
            positions.Add(new Position(nuisible.Position.Y, xMax));

            positions.Add(new Position(yMin, xMin));
            positions.Add(new Position(yMin, nuisible.Position.X));
            positions.Add(new Position(yMin, xMax));

            Position position = positions.ElementAt(this.random.Next(0, positions.Count));
            Console.WriteLine(position.X);
            Console.WriteLine(position.Y);
        }
    }
}