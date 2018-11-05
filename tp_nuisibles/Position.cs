using System.Drawing;

namespace tp_nuisibles
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static explicit operator Point(Position position)
        {
            return new Point(position.X,position.Y);
        }
        

        public override bool Equals(object obj)
        {
            return (((Position)obj).X == this.X && ((Position)obj).Y == this.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 1 + Y.GetHashCode() * 2;
        }
    }
}