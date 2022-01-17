
namespace Project1.Shapes
{
    internal abstract class ConsoleShape
    {
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsolePoint StartPoint { get; set; }

        public abstract void Print();
        public abstract int Area();
        public abstract int Perimeter();

    }
}
