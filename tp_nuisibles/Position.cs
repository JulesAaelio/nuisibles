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

        public override bool Equals(object obj)
        {
            return (((Position)obj).X == this.X && ((Position)obj).Y == this.Y);
        }
    }
}