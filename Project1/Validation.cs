
using Project1.Shapes;

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
            if (Math.Round((a * a) - (b * b) + (c * c)) != 0 && Math.Round((a * a) + (b * b) - (c * c)) != 0
                && Math.Round((a * a) + (c * c) - (b * b)) != 0)
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
                || !Enum.TryParse(args[5], true, out ConsoleColor color))
            {
                return false;
            }
            if (Math.Abs(ax - bx) != Math.Abs(ay - by) && ax - bx != 0 && bx - by != 0)
                return false;
            line = new Line(symbol, Menu.startForShape, new ConsolePoint(ax, ay),
                new ConsolePoint(bx, by), color);
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

        public static void ValidDrawing(char symbol)
        {
            (var left, var top) = Console.GetCursorPosition();
            if (top >= Menu.menuH + Menu.sceneH || top <= Menu.menuH
                || left < 1 || left >= Menu.menuW)
            {
                return;
            }
            else
            {
                Console.Write(symbol);
            }
        }
    }
}
