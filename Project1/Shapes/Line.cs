
namespace Project1.Shapes
{
    internal class Line : ConsoleShape
    {
        public ConsolePoint A { get; set; }
        public ConsolePoint B { get; set; }
        private int PerimeterValue { get; set; }

        public Line(char symbol, ConsolePoint startPos, ConsolePoint a,
            ConsolePoint b, ConsoleColor color = ConsoleColor.DarkMagenta)
        {
            Symbol = symbol;
            StartPoint = startPos;
            Color = color;
            A = a;
            B = b;
        }
        public override int Area()
        {
            return PerimeterValue;
        }

        public override int Perimeter()
        {
            return PerimeterValue;
        }

        public override void Print()
        {
            var startColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;

            var x = B.X - A.X;
            var y = B.Y - A.Y;
            // 8 cases of possible movement
            if (x > 0)
            {
                if (y > 0)
                    CreateLine(1, 1);
                else if (y < 0)
                    CreateLine(1, -1);
                else
                    CreateLine(1, 0);
            }
            else if (x < 0)
            {
                if (y > 0)
                    CreateLine(-1, 1);
                else if (y < 0)
                    CreateLine(-1, -1);
                else
                    CreateLine(-1, 0);
            }
            else
            {
                if (y > 0)
                    CreateLine(0, 1);
                else if (y < 0)
                    CreateLine(0, -1);
            }
            Console.ForegroundColor = startColor;
        }

        private void CreateLine(int x, int y)
        {
            PerimeterValue = 0;
            var currentPos = A;
            Console.SetCursorPosition(StartPoint.X + currentPos.X, StartPoint.Y + currentPos.Y);
            PaintValidation.Paint(Symbol);
            PerimeterValue++;
            while (currentPos != B)
            {
                currentPos = new ConsolePoint(currentPos.X + x, currentPos.Y + y);
                Console.SetCursorPosition(StartPoint.X + currentPos.X, StartPoint.Y + currentPos.Y);
                PaintValidation.Paint(Symbol);
                PerimeterValue++;
            }
        }

        public void ChangeForMoving(ConsolePoint point)
        {
            A += point;
            B += point;
        }

        private void AddInList(int x, int y, ref int posX, ref int posY, ref List<List<char>> scene)
        {
            var currentPos = A;
            posX = StartPoint.X + currentPos.X;
            posY = StartPoint.Y + currentPos.Y;
            PaintValidation.AddInList(Symbol, ref scene, ref posX, ref posY);
            while (currentPos != B)
            {
                currentPos = new ConsolePoint(currentPos.X + x, currentPos.Y + y);
                posX = StartPoint.X + currentPos.X;
                posY = StartPoint.Y + currentPos.Y;
                PaintValidation.AddInList(Symbol, ref scene, ref posX, ref posY);
            }
        }

        public override void AddInListForFile(ref List<List<char>> scene)
        {
            var posX = Menu.startForShape.X;
            var posY = Menu.startForShape.Y;

            var x = B.X - A.X;
            var y = B.Y - A.Y;
            if (x > 0)
            {
                if (y > 0)
                    AddInList(1, 1, ref posX, ref posY, ref scene);
                else if (y < 0)
                    AddInList(1, -1, ref posX, ref posY, ref scene);
                else
                    AddInList(1, 0, ref posX, ref posY, ref scene);
            }
            else if (x < 0)
            {
                if (y > 0)
                    AddInList(-1, 1, ref posX, ref posY, ref scene);
                else if (y < 0)
                    AddInList(-1, -1, ref posX, ref posY, ref scene);
                else
                    AddInList(-1, 0, ref posX, ref posY, ref scene);
            }
            else
            {
                if (y > 0)
                    AddInList(0, 1, ref posX, ref posY, ref scene);
                else if (y < 0)
                    AddInList(0, -1, ref posX, ref posY, ref scene);
            }
        }
    }
}
