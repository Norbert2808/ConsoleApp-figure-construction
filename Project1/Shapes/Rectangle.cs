namespace Project1.Shapes
{
    internal class Rectangle : ConsoleShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Filling { get; set; }
        // for drawing menu and scene without validation
        public bool ValidDrawing { get; set; }
        private int AreaValue { get; set; }
        private int PerimeterValue { get; set; }

        public Rectangle(char symbol, ConsolePoint startPos, int width = 15, int height = 7,
            ConsoleColor color = ConsoleColor.Red, bool filling = true)
        {
            Symbol = symbol;
            StartPoint = startPos;
            Color = color;
            Width = width;
            Height = height;
            Filling = filling;
            ValidDrawing = true;
            PerimeterValue = 2 * (Width + Height);
            AreaValue = filling ? Width * Height : PerimeterValue;
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
            Points = new List<ConsolePoint>() { };

            Console.SetCursorPosition(StartPoint.X, StartPoint.Y);
            var startX = StartPoint.X;
            var startY = StartPoint.Y;
            int left, top;

            for (var i = 0; i < Width; i++)
            {
                (left, top) = Console.GetCursorPosition();
                Points.Add(new ConsolePoint(left, top));
                PaintValidation.Paint(Symbol, ValidDrawing);
            }
            Console.WriteLine();

            for (var i = 1; i < Height - 1; i++)
            {
                Console.SetCursorPosition(startX, Console.GetCursorPosition().Top);
                Points.Add(new ConsolePoint(startX, Console.GetCursorPosition().Top));
                PaintValidation.Paint(Symbol, ValidDrawing);
                if (Filling)
                {
                    for (var j = 1; j < Width - 1; j++)
                    {
                        (left, top) = Console.GetCursorPosition();
                        Points.Add(new ConsolePoint(left, top));
                        PaintValidation.Paint(Symbol, ValidDrawing);
                    }
                }
                Console.SetCursorPosition(startX + Width - 1, startY + i);
                PaintValidation.Paint(Symbol, ValidDrawing);
                Points.Add(new ConsolePoint(startX + Width - 1, startY + i));
                Console.WriteLine();
            }

            Console.SetCursorPosition(startX, Console.GetCursorPosition().Top);
            for (var i = 0; i < Width; i++)
            {
                (left, top) = Console.GetCursorPosition();
                Points.Add(new ConsolePoint(left, top));
                PaintValidation.Paint(Symbol, ValidDrawing);
            }
            Console.WriteLine();

            Console.ForegroundColor = startColor;
        }
    }
}
