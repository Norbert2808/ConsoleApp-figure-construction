
namespace Project1.Shapes
{
    internal abstract class ConsoleShape
    {
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsolePoint StartPoint { get; set; }
        public List<ConsolePoint> Points { get; set; }

        public abstract void Print();
        public abstract int Area();
        public abstract int Perimeter();
        public void AddInListForFile(ref List<List<char>> scene)
        {
            if (Points != null)
            {
                foreach (var point in Points)
                {
                    PaintValidation.AddInList(Symbol, ref scene, point.X, point.Y);
                }
            }
        }

    }
}
