
namespace Project1
{
    internal class ConsolePoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public ConsolePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(ConsolePoint first, ConsolePoint second) => first.X == second.X && first.Y == second.Y;
        public static bool operator !=(ConsolePoint first, ConsolePoint second) => !(first == second);
        public static ConsolePoint operator +(ConsolePoint first, ConsolePoint second) =>
            new(first.X + second.X, first.Y + second.Y);

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is not null && GetType() == obj.GetType() && this == (ConsolePoint)obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
