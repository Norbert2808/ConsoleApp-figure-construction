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
            Console.SetCursorPosition(StartPoint.X, StartPoint.Y);
            var thickness = 0.5;
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
                            Validation.ValidDrawing(Symbol);
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
                            Validation.ValidDrawing(Symbol);
                            AreaValue++;
                            PerimeterValue++;
                            continue;
                        }
                    }
                    var (left, top) = Console.GetCursorPosition();
                    Console.SetCursorPosition(left + 1, top);

                }
                Console.WriteLine();
                Console.SetCursorPosition(StartPoint.X, Console.GetCursorPosition().Top);
            }
            Console.ForegroundColor = startColor;
        }

        public override void AddInListForFile(ref List<List<char>> scene)
        {
            var posX = StartPoint.X;
            var posY = StartPoint.Y;

            var thickness = 0.5;
            var rIn = Radius - thickness;
            var rOut = Radius + thickness;

            for (var y = Radius; y >= -Radius; --y)
            {
                for (var x = -Radius; x < rOut; x += 0.5)
                {
                    var value = (x * x) + (y * y);
                    if (Filling)
                    {
                        if (value <= rOut * rOut)
                        {
                            Validation.ValidAddInList(Symbol, ref scene, ref posX, ref posY);
                            continue;
                        }
                    }
                    else
                    {
                        if (value <= rOut * rOut && value >= rIn * rIn)
                        {
                            Validation.ValidAddInList(Symbol, ref scene, ref posX, ref posY);
                            continue;
                        }
                    }
                    posX++;
                }
                posY++;
                posX = StartPoint.X;
            }
        }


    }
}
