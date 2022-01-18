﻿
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
        public int HypotenuseLenght { get; set; }
        public int CathetusLenght { get; set; }

        public Triangle(char symbol, ConsolePoint startPos, ConsolePoint a, ConsolePoint b,
            ConsolePoint c, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            Symbol = symbol;
            StartPoint = startPos;
            Color = color;
            AP = a;
            BP = b;
            CP = c;
            A = new Line(symbol, startPos, a, b, color);
            B = new Line(symbol, startPos, b, c, color);
            C = new Line(symbol, startPos, c, a, color);
        }
        public override int Area()
        {
            var al = A.Perimeter();
            var bl = B.Perimeter();
            var cl = C.Perimeter();
            HypotenuseLenght = Math.Max(Math.Max(al, bl), cl);
            CathetusLenght = Math.Min(Math.Min(al, bl), cl);
            // arithmetic progression from cathetus to 1 - count of symbols
            //return CathetusLenght * (CathetusLenght + 1) / 2;
            return Perimeter();
        }

        public override int Perimeter()
        {
            // vertices are taken into account 2 times
            return A.Perimeter() + B.Perimeter() + C.Perimeter() - 3;
        }

        public override void Print()
        {
            A.Symbol = Symbol; // for rePrint after delete
            A.Print();
            B.Symbol = Symbol;
            B.Print();
            C.Symbol = Symbol;
            C.Print();
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
