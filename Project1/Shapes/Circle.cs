namespace Project1.Shapes
{
    internal class Circle : ConsoleShape
    {
        public double Radius { get; set; }
        public bool Filling { get; set; }
        private int AreaValue { get; set; }
        private int PerimeterValue { get; set; }

        public Circle(char symbol, ConsolePoint startPos, double radius = 5,
            ConsoleColor color = ConsoleColor.White, bool filling = false)
        {
            Symbol = symbol;
            StartPoint = startPos;
            Color = color;
            Radius = radius;
            Filling = filling;
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
            var thickness = 0.5;
            int left, top;
            var rIn = Radius - thickness;
            var rOut = Radius + thickness;
            AreaValue = 0;
            PerimeterValue = 0;

            for (var y = Radius; y >= -Radius; --y)
            {
                for (var x = -Radius; x < rOut; x += 0.5)
                {
                    var value = (x * x) + (y * y);
                    if (Filling)
                    {
                        if (value <= rOut * rOut)
                        {
                            (left, top) = Console.GetCursorPosition();
                            Points.Add(new ConsolePoint(left, top));
                            PaintValidation.Paint(Symbol);
                            AreaValue++;
                            if (value >= rIn * rIn)
                                PerimeterValue++;
                            continue;
                        }
                    }
                    else
                    {
                        if (value <= rOut * rOut && value >= rIn * rIn)
                        {
                            (left, top) = Console.GetCursorPosition();
                            Points.Add(new ConsolePoint(left, top));
                            PaintValidation.Paint(Symbol);
                            AreaValue++;
                            PerimeterValue++;
                            continue;
                        }
                    }
                    (left, top) = Console.GetCursorPosition();
                    Console.SetCursorPosition(left + 1, top);

                }
                Console.WriteLine();
                Console.SetCursorPosition(StartPoint.X, Console.GetCursorPosition().Top);
            }
            Console.ForegroundColor = startColor;
        }


    }
}
