
namespace Project1.Shapes
{
    internal class Triangle : ConsoleShape
    {
        public Line A { get; set; }
        public Line B { get; set; }
        public Line C { get; set; }
        public ConsolePoint AP { get; set; }
        public ConsolePoint BP { get; set; }
        public ConsolePoint CP { get; set; }
        public bool Filling { get; set; }
        public int HypotenuseLenght { get; set; }
        public int CathetusLenght { get; set; }
        private int AreaValue { get; set; }
        private int PerimeterValue { get; set; }

        public Triangle(char symbol, ConsolePoint startPos, ConsolePoint a, ConsolePoint b,
            ConsolePoint c, ConsoleColor color = ConsoleColor.DarkYellow, bool filling = false)
        {
            Symbol = symbol;
            StartPoint = startPos;
            Color = color;
            Filling = filling;
            AP = a;
            BP = b;
            CP = c;
            A = new Line(symbol, startPos, a, b, color);
            B = new Line(symbol, startPos, b, c, color);
            C = new Line(symbol, startPos, c, a, color);

            // vertices are taken into account 2 times
            PerimeterValue = A.Perimeter() + B.Perimeter() + C.Perimeter() - 3;
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
            if (!Filling)
            {
                A.Symbol = Symbol; // for rePrint after delete
                A.Print();
                B.Symbol = Symbol;
                B.Print();
                C.Symbol = Symbol;
                C.Print();
            }
            else
            {
                var startColor = Console.ForegroundColor;
                Console.ForegroundColor = Color;

                AreaValue = Perimeter();
                var maxY = Math.Max(Math.Max(AP.Y, BP.Y), CP.Y);
                var minY = Math.Min(Math.Min(AP.Y, BP.Y), CP.Y);
                var maxX = Math.Max(Math.Max(AP.X, BP.X), CP.X);
                var minX = Math.Min(Math.Min(AP.X, BP.X), CP.X);
                var points = new List<ConsolePoint>() { AP, BP, CP };

                if (points.Where(x => x.Y == maxY).Count() == 2)
                {
                    // 1 point is upper, 2 - lower  
                    var upperPoint = points.FirstOrDefault(x => x.Y == minY);
                    if (points.Where(x => x.X == upperPoint.X).Count() == 1)
                    {
                        // hypotenuse is lower
                        var lowerPointsY = points.FirstOrDefault(x => x.X != upperPoint.X).Y;
                        var steps = lowerPointsY - upperPoint.Y + 1;
                        for (var i = 0; i < steps; i++)
                        {
                            var startPosX = upperPoint.X - i;
                            var posY = upperPoint.Y + i;
                            for (var j = 0; j < (i * 2) + 1; j++)
                            {
                                Console.SetCursorPosition(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                PaintValidation.Paint(Symbol);
                                AreaValue++;
                            }
                        }
                    }
                    else
                    {
                        // cathetus is lower
                        var pointWithAnotherX = points.FirstOrDefault(x => x.X != upperPoint.X);
                        if (pointWithAnotherX.X > upperPoint.X)
                        {
                            // point with another X is right
                            var steps = pointWithAnotherX.Y - upperPoint.Y + 1;
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = upperPoint.X;
                                var posY = upperPoint.Y + i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    Console.SetCursorPosition(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                    PaintValidation.Paint(Symbol);
                                    AreaValue++;
                                }
                            }
                        }
                        else
                        {
                            // point with another X is left
                            var steps = pointWithAnotherX.Y - upperPoint.Y + 1;
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = upperPoint.X - i;
                                var posY = upperPoint.Y + i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    Console.SetCursorPosition(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                    PaintValidation.Paint(Symbol);
                                    AreaValue++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    // 2 point is upper, 1 - lower  
                    var lowerPoint = points.FirstOrDefault(x => x.Y == maxY);
                    if (points.Where(x => x.X == lowerPoint.X).Count() == 1)
                    {
                        // hypotenuse is upper
                        var upperPointsY = points.FirstOrDefault(x => x.X != lowerPoint.X).Y;
                        var steps = lowerPoint.Y - upperPointsY + 1;
                        for (var i = 0; i < steps; i++)
                        {
                            var startPosX = lowerPoint.X - i;
                            var posY = lowerPoint.Y - i;
                            for (var j = 0; j < (i * 2) + 1; j++)
                            {
                                Console.SetCursorPosition(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                PaintValidation.Paint(Symbol);
                                AreaValue++;
                            }
                        }
                    }
                    else
                    {
                        // cathetus is upper
                        var pointWithAnotherX = points.FirstOrDefault(x => x.X != lowerPoint.X);
                        if (pointWithAnotherX.X > lowerPoint.X)
                        {
                            // point with another X is right
                            var steps = lowerPoint.Y - pointWithAnotherX.Y + 1;
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = lowerPoint.X;
                                var posY = lowerPoint.Y - i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    Console.SetCursorPosition(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                    PaintValidation.Paint(Symbol);
                                    AreaValue++;
                                }
                            }
                        }
                        else
                        {
                            // point with another X is left
                            var steps = lowerPoint.Y - pointWithAnotherX.Y + 1;
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = lowerPoint.X - i;
                                var posY = lowerPoint.Y - i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    Console.SetCursorPosition(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                    PaintValidation.Paint(Symbol);
                                    AreaValue++;
                                }
                            }
                        }
                    }
                }
                Console.ForegroundColor = startColor;
            }
        }

        public void ChangeForMoving(ConsolePoint point)
        {
            AP += point;
            BP += point;
            CP += point;
            A = new Line(Symbol, StartPoint, AP, BP, Color);
            B = new Line(Symbol, StartPoint, BP, CP, Color);
            C = new Line(Symbol, StartPoint, CP, AP, Color);
        }

        public override void AddInListForFile(ref List<List<char>> scene)
        {
            A.Symbol = Symbol;
            A.AddInListForFile(ref scene);
            B.Symbol = Symbol;
            B.AddInListForFile(ref scene);
            C.Symbol = Symbol;
            C.AddInListForFile(ref scene);
        }
    }
}
