using Project1.Shapes;

namespace Project1.Helpers
{
    internal static class MoveHelper
    {
        public enum Side
        {
            Left,
            Right,
            Up,
            Down
        }

        public static void Helper(ref List<ConsoleShape> cs)
        {
            if (!DeleteHelper.ListIsEmpty(cs))
            {
                var args = new string[]
                            {
                            "Move Shape",
                            "Up and to the left you can move the figure only to the border",
                            "Enter \"index, side, number\"",
                            $"index - index for move[0;{cs.Count - 1}]",
                            "side - enum(Left, Right, Up, Down)",
                            "number - uint(>= 0 && <= 100)",
                            "if invalid args - back"
                            };
                Menu.ClientMenu(args);

                var mes = Console.ReadLine();
                if (MoveValid(mes, cs.Count, out var index,
                    out var num, out var side))
                {
                    var el = cs[index];
                    if (el is Rectangle or Circle)
                        MovingForRectOrCircle(ref cs, index, num, side);
                    else if (el is Line)
                        MovingForLine(ref cs, index, num, side);
                    else if (el is Triangle)
                        MovingForTriangle(ref cs, index, num, side);
                    DeleteHelper.Repaint(cs);
                }
            }
        }

        private static void MovingForRectOrCircle(ref List<ConsoleShape> cs, int index,
            int num, Side side)
        {
            switch (side)
            {
                case Side.Left:
                    var newX = Math.Max(cs[index].StartPoint.X - num, 1);
                    cs[index].StartPoint = new ConsolePoint(newX, cs[index].StartPoint.Y);
                    break;
                case Side.Right:
                    cs[index].StartPoint += new ConsolePoint(num, 0);
                    break;
                case Side.Up:
                    var newY = Math.Max(cs[index].StartPoint.Y - num, Menu.menuH + 1);
                    cs[index].StartPoint = new ConsolePoint(cs[index].StartPoint.X, newY);
                    break;
                case Side.Down:
                    cs[index].StartPoint += new ConsolePoint(0, num);
                    break;
                default:
                    break;
            }
        }

        private static void MovingForLine(ref List<ConsoleShape> cs, int index,
            int num, Side side)
        {
            var el = cs[index];

            switch (side)
            {
                case Side.Left:
                    var minXInLine = Math.Min((el as Line).A.X, (el as Line).B.X);
                    var change = minXInLine - num > 1 ? -num : -minXInLine;
                    (cs[index] as Line).ChangeForMoving(new ConsolePoint(change, 0));
                    break;
                case Side.Right:
                    (cs[index] as Line).ChangeForMoving(new ConsolePoint(num, 0));
                    break;
                case Side.Up:
                    var minYInLine = Math.Min((el as Line).A.Y, (el as Line).B.Y);
                    change = minYInLine - num > 1 ? -num : -minYInLine;
                    (cs[index] as Line).ChangeForMoving(new ConsolePoint(0, change));
                    break;
                case Side.Down:
                    (cs[index] as Line).ChangeForMoving(new ConsolePoint(0, num));
                    break;
                default:
                    break;
            }
        }

        private static void MovingForTriangle(ref List<ConsoleShape> cs, int index,
            int num, Side side)
        {
            var el = cs[index];

            switch (side)
            {
                case Side.Left:
                    var minXInTri = Math.Min(Math.Min((el as Triangle).AP.X, (el as Triangle).BP.X),
                        (el as Triangle).CP.X);
                    var change = minXInTri - num > 1 ? -num : -minXInTri;
                    (cs[index] as Triangle).ChangeForMoving(new ConsolePoint(change, 0));
                    break;
                case Side.Right:
                    (cs[index] as Triangle).ChangeForMoving(new ConsolePoint(num, 0));
                    break;
                case Side.Up:
                    var minYInTri = Math.Min(Math.Min((el as Triangle).AP.Y, (el as Triangle).BP.Y),
                        (el as Triangle).CP.Y);
                    change = minYInTri - num > 1 ? -num : -minYInTri;
                    (cs[index] as Triangle).ChangeForMoving(new ConsolePoint(0, change));
                    break;
                case Side.Down:
                    (cs[index] as Triangle).ChangeForMoving(new ConsolePoint(0, num));
                    break;
                default:
                    break;
            }
        }

        private static bool MoveValid(string el, int count, out int index, out int number, out Side side)
        {
            index = default;
            number = default;
            side = Side.Left;

            var args = el.Split(", ");
            return args.Length == 3 && AddValidation.UintValid(args[0], out index, max: count - 1) &&
                AddValidation.UintValid(args[2], out number) && Enum.TryParse(args[1], true, out side);
        }
    }
}
