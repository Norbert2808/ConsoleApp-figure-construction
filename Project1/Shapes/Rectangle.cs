namespace Project1.Shapes
{
    internal class Rectangle : ConsoleShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Filling { get; set; }
        private int AreaValue { get; set; }
        private int PerimeterValue { get; set; }

        public Rectangle(char symbol, ConsolePoint startPos, int width = 15, int height = 7,
            ConsoleColor color = ConsoleColor.Red, bool filling = false)
        {
            Symbol = symbol;
            StartPoint = startPos;
            Color = color;
            Width = width;
            Height = height;
            Filling = filling;
            AreaValue = Width * Height;
            PerimeterValue = 2 * (Width + Height);
        }
        public override int Area()
        {
            return AreaValue;
        }

        public override int Perimeter()
        {
            return PerimeterValue;
        }

        public override void Print()
        {
            var startColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(StartPoint!.X, StartPoint.Y);
            var startX = StartPoint.X;
            var startY = StartPoint.Y;
            for (var i = 0; i < Width; i++)
            {
                Console.Write(Symbol);
            }
            Console.WriteLine();

            for (var i = 1; i < Height - 1; i++)
            {
                Console.SetCursorPosition(startX, Console.GetCursorPosition().Top);
                Console.Write(Symbol);
                for (var j = 1; j < Width - 1; j++)
                {
                    if (Filling)
                        Console.Write(Symbol);
                }
                Console.SetCursorPosition(startX + Width - 1, startY + i);
                Console.WriteLine(Symbol);
            }
            Console.SetCursorPosition(startX, Console.GetCursorPosition().Top);
            for (var i = 0; i < Width; i++)
            {
                Console.Write(Symbol);
            }
            Console.WriteLine();

            Console.ForegroundColor = startColor;

        }

    }
}
