
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
            if (!Filling)
                AreaValue = PerimeterValue;
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
            Points = new List<ConsolePoint>() { };

            if (!Filling)
            {
                A.Symbol = Symbol; // for rePrint after delete
                B.Symbol = Symbol;
                C.Symbol = Symbol;
                A.Print();
                B.Print();
                C.Print();
                Points = A.Points.Concat(B.Points.Concat(C.Points).ToList()).ToList();
            }
            else
            {
                var startColor = Console.ForegroundColor;
                Console.ForegroundColor = Color;

                AreaValue = 0;
                var maxY = Math.Max(Math.Max(AP.Y, BP.Y), CP.Y);
                var minY = Math.Min(Math.Min(AP.Y, BP.Y), CP.Y);
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
                                WtiteSymbolIncrementAreaAddPoint(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                            }
                        }
                    }
                    else
                    {
                        // cathetus is lower
                        var pointWithAnotherX = points.FirstOrDefault(x => x.X != upperPoint.X);
                        var steps = pointWithAnotherX.Y - upperPoint.Y + 1;
                        if (pointWithAnotherX.X > upperPoint.X)
                        {
                            // point with another X is right
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = upperPoint.X;
                                var posY = upperPoint.Y + i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    WtiteSymbolIncrementAreaAddPoint(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                }
                            }
                        }
                        else
                        {
                            // point with another X is left
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = upperPoint.X - i;
                                var posY = upperPoint.Y + i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    WtiteSymbolIncrementAreaAddPoint(StartPoint.X + startPosX + j, StartPoint.Y + posY);
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
                                WtiteSymbolIncrementAreaAddPoint(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                            }
                        }
                    }
                    else
                    {
                        // cathetus is upper
                        var pointWithAnotherX = points.FirstOrDefault(x => x.X != lowerPoint.X);
                        var steps = lowerPoint.Y - pointWithAnotherX.Y + 1;
                        if (pointWithAnotherX.X > lowerPoint.X)
                        {
                            // point with another X is right
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = lowerPoint.X;
                                var posY = lowerPoint.Y - i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    WtiteSymbolIncrementAreaAddPoint(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                }
                            }
                        }
                        else
                        {
                            // point with another X is left
                            for (var i = 0; i < steps; i++)
                            {
                                var startPosX = lowerPoint.X - i;
                                var posY = lowerPoint.Y - i;
                                for (var j = 0; j < i + 1; j++)
                                {
                                    WtiteSymbolIncrementAreaAddPoint(StartPoint.X + startPosX + j, StartPoint.Y + posY);
                                }
                            }
                        }
                    }
                }
                Console.ForegroundColor = startColor;
            }
        }

        private void WtiteSymbolIncrementAreaAddPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            PaintValidation.Paint(Symbol);
            AreaValue++;
            Points.Add(new ConsolePoint(x, y));
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
    }
}
