
using Project1.Shapes;
using static Project1.Helpers;

namespace Project1
{
    internal static class Validation
    {
        public static bool AddRectValid(string el, char symbol, out Rectangle rec)
        {
            rec = default;
            var args = el.Split(", ");
            if (args.Length != 6)
                return false;
            if (!UintValid(args[0], out var startX) || !UintValid(args[1], out var startY)
                || !UintValid(args[2], out var width) || !UintValid(args[3], out var height)
                || !Enum.TryParse(args[4], true, out ConsoleColor color) || !bool.TryParse(args[5], out var filling))
            {
                return false;
            }
            rec = new Rectangle(symbol, new ConsolePoint(startX, startY) + Menu.startForShape, width, height, color, filling);
            return true;
        }

        public static bool AddTriangleValid(string el, char symbol, out Triangle tri)
        {
            tri = default;
            var args = el.Split(", ");
            if (args.Length != 7)
                return false;
            if (!UintValid(args[0], out var ax) || !UintValid(args[1], out var ay)
                || !UintValid(args[2], out var bx) || !UintValid(args[3], out var by)
                || !UintValid(args[4], out var cx) || !UintValid(args[5], out var cy)
                || !Enum.TryParse(args[6], true, out ConsoleColor color))
            {
                return false;
            }
            var a = GetLenght(bx, by, cx, cy);
            var b = GetLenght(cx, cy, ax, ay);
            var c = GetLenght(ax, ay, bx, by);
            // check rectangular triangle
            if (Math.Round((a * a) + (c * c) - (b * b)) != 0 && Math.Round((a * a) + (b * b) - (c * c)) != 0
                && Math.Round((c * c) + (b * b) - (a * a)) != 0)
            {
                return false;
            }
            // check isosceles triangle
            if (a != b && b != c && c != a)
                return false;

            tri = new Triangle(symbol, Menu.startForShape, new ConsolePoint(ax, ay), new ConsolePoint(bx, by),
                new ConsolePoint(cx, cy), color);
            return true;
        }

        public static bool AddCircleValid(string el, char symbol, out Circle cir)
        {
            cir = default;
            var args = el.Split(", ");
            if (args.Length != 5)
                return false;
            if (!UintValid(args[0], out var startX) || !UintValid(args[1], out var startY)
                || !UintValid(args[2], out var radius) || !Enum.TryParse(args[3], true, out ConsoleColor color)
                || !bool.TryParse(args[4], out var filling))
            {
                return false;
            }
            cir = new Circle(symbol, new ConsolePoint(startX, startY) + Menu.startForShape, radius, color, filling);
            return true;
        }

        public static bool AddLineValid(string el, char symbol, out Line line)
        {
            line = default;
            var args = el.Split(", ");
            if (args.Length != 5)
                return false;
            if (!UintValid(args[0], out var ax) || !UintValid(args[1], out var ay)
                || !UintValid(args[2], out var bx) || !UintValid(args[3], out var by)
                || !Enum.TryParse(args[4], true, out ConsoleColor color))
            {
                return false;
            }
            if (Math.Abs(ax - bx) != Math.Abs(ay - by) && ax - bx != 0 && ay - by != 0)
                return false;
            line = new Line(symbol, Menu.startForShape, new ConsolePoint(ax, ay),
                new ConsolePoint(bx, by), color);
            return true;
        }

        public static bool MoveValid(string el, int count, out int index, out int number, out Side side)
        {
            index = default;
            number = default;
            side = Side.Left;

            var args = el.Split(", ");
            return args.Length == 3 && UintValid(args[0], out index) && index < count &&
                UintValid(args[2], out number) && Enum.TryParse(args[1], true, out side);
        }

        public static bool SortValid(string el, out string prop, out string type)
        {
            prop = default;
            type = default;

            var args = el.Split(", ");
            if (args.Length != 2)
                return false;
            if ((args[0] != "a" && args[0] != "p") || (args[1] != "a" && args[1] != "d"))
                return false;
            prop = args[0];
            type = args[1];
            return true;
        }

        private static double GetLenght(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static bool UintValid(string el, out int res)
        {
            return int.TryParse(el, out res) && res >= 0;
        }

        private static readonly int _topBoundary = Menu.menuH + Menu.sceneH - 1;
        private static readonly int _rightBoundary = Menu.menuW - 2;
        public static void ValidDrawing(char symbol, bool ValidDrawing = true)
        {
            if (!ValidDrawing)
            {
                Console.Write(symbol);
                return;
            }

            (var left, var top) = Console.GetCursorPosition();
            if (top >= _topBoundary || left >= _rightBoundary)
            {
                return;
            }
            else
            {
                Console.Write(symbol);
            }
        }
        public static void ValidAddInList(char symbol, ref List<List<char>> scene, ref int posX, ref int posY)
        {
            if (posY >= _topBoundary || posX >= _rightBoundary)
            {
                return;
            }
            else
            {
                scene[posY - Menu.startForShape.Y][posX] = symbol;
                posX++;
            }
        }
    }
}
