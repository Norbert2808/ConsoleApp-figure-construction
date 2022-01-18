
using Project1.Shapes;

namespace Project1
{
    internal class Helpers
    {
        public static readonly string _saveFileName = "scene.txt";

        public static void AddMenu()
        {
            var args = new string[]
            {
        "Enter action: ",
        "1 - add circle",
        "2 - add rectangle",
        "3 - add triangle",
        "4 - add line",
        "otherwise - back"
            };
            Menu.ClientMenu(args);
        }

        public static void AddHelper(ref List<ConsoleShape> cs)
        {
            string key;
            do
            {
                Menu.ClearMenu();
                AddMenu();
                key = Console.ReadLine();
                Menu.ClearMenu();
                Console.SetCursorPosition(1, 1);
                var symbol = $"{cs.Count}"[0];
                string[] args;
                switch (key)
                {
                    case "1":
                        args = new string[]
                        {
                            "Add Circle",
                            "Enter \"d\" for default",
                            "Or enter \"startPosX, startPosY, radius, color, filling\"",
                            "",
                            "startPosX = 0 && startPosY = 0 - first cell in scene",
                            "startPos - left top point of the circumscribed square",
                            "down - positive y-axis, right - positive x-axis",
                            "",
                            "startPosX, startPosY, radius - uint",
                            "color - enum(Blue, Red, Gray, Magenta, Yellow, DarkGray...)",
                            "filling - bool(true, false)",
                            "if invalid args - back"
                        };
                        Menu.ClientMenu(args);
                        var addC = Console.ReadLine();
                        Circle circle;
                        if (addC == "d")
                        {
                            circle = new Circle(symbol, Menu.startForShape);
                            circle.Print();
                            cs.Add(circle);
                        }
                        if (Validation.AddCircleValid(addC, symbol, out circle))
                        {
                            circle.Print();
                            cs.Add(circle);
                        }
                        break;
                    case "2":
                        args = new string[]
                        {
                            "Add Rectangle",
                            "Enter \"d\" for default",
                            "Or enter \"startPosX, startPosY, width, height, color, filling\"",
                            "",
                            "startPosX = 0 && startPosY = 0 - first cell in scene",
                            "down - positive y-axis, right - positive x-axis",
                            "startPos - left top point",
                            "",
                            "startPosX, startPosY, width, height - uint",
                            "color - enum(Blue, Red, Gray, Magenta, Yellow, DarkGray...)",
                            "filling - bool(true, false)",
                            "if invalid args - back"
                        };
                        Menu.ClientMenu(args);
                        var addRec = Console.ReadLine();
                        Rectangle rectangle;
                        if (addRec == "d")
                        {
                            rectangle = new Rectangle(symbol,
                                Menu.startForShape + new ConsolePoint(30, 0), filling: true);
                            rectangle.Print();
                            cs.Add(rectangle);
                        }
                        if (Validation.AddRectValid(addRec, symbol, out rectangle))
                        {
                            rectangle.Print();
                            cs.Add(rectangle);
                        }
                        break;
                    case "3":
                        args = new string[]
                        {
                            "Add Triangle",
                            "You can only add a right-angled isosceles triangle",
                            "Enter \"d\" for default",
                            "Or enter \"AX, AY, BX, BY, CX, CY, color\"",
                            "down - positive y-axis, right - positive x-axis",
                            "",
                            "AX, AY, BX, BY, CX, CY - uint",
                            "color - enum(Blue, Red, Gray, Magenta, Yellow, DarkGray...)",
                            "if invalid args - back"
                        };
                        Menu.ClientMenu(args);
                        var addT = Console.ReadLine();
                        Triangle triangle;
                        if (addT == "d")
                        {
                            triangle = new Triangle(symbol, Menu.startForShape,
                                new ConsolePoint(50, 10), new ConsolePoint(60, 20), new ConsolePoint(50, 20));
                            triangle.Print();
                            cs.Add(triangle);
                        }
                        if (Validation.AddTriangleValid(addT, symbol, out triangle))
                        {
                            triangle.Print();
                            cs.Add(triangle);
                        }
                        break;
                    case "4":
                        args = new string[]
                        {
                            "Add Line",
                            "You can only add straight or diagonal line:",
                            @"     \ | /",
                             "     -   -",
                            @"     / | \",
                            "Enter \"d\" for default",
                            "Or enter \"AX, AY, BX, BY, color\"",
                            "down - positive y-axis, right - positive x-axis",
                            "",
                            "AX, AY, BX, BY - uint",
                            "color - enum(Blue, Red, Gray, Magenta, Yellow, DarkGray...)",
                            "if invalid args - back"
                        };
                        Menu.ClientMenu(args);
                        var addL = Console.ReadLine();
                        Line line;
                        if (addL == "d")
                        {
                            line = new Line(symbol, Menu.startForShape, new ConsolePoint(5, 5),
                                new ConsolePoint(20, 20));
                            line.Print();
                            cs.Add(line);
                        }
                        if (Validation.AddLineValid(addL, symbol, out line))
                        {
                            line.Print();
                            cs.Add(line);
                        }
                        break;
                    default:
                        key = "exit";
                        break;
                }
            } while (key != "exit");

        }

        public static void DeleteHelper(ref List<ConsoleShape> cs)
        {
            if (!CheckCount(cs))
            {
                var args = new string[]
                            {
                            "Delete Shape",
                            $"Enter index for delete[0;{cs.Count - 1}]",
                            "if invalid args - back"
                            };
                Menu.ClientMenu(args);
                var mes = Console.ReadLine();
                if (Validation.UintValid(mes, out var index) && index < cs.Count)
                {
                    cs.RemoveAt(index);
                    Repaint(cs);
                }
            }

        }

        public static void SaveHelper(List<ConsoleShape> cs)
        {
            if (!CheckCount(cs))
            {
                //using var fs = new FileStream(_saveFileName, FileMode.OpenOrCreate);
                using var writer = new StreamWriter(_saveFileName);
                var scene = new List<List<char>>();
                for (var i = 0; i < Menu.sceneH - 2; i++)
                {
                    scene.Add(Enumerable.Repeat(' ', Menu.menuW - 2).ToList());
                }

                foreach (var el in cs)
                    el.AddInListForFile(ref scene);

                for (var i = 0; i < Menu.sceneH - 2; i++)
                {
                    for (var j = 0; j < Menu.menuW - 2; j++)
                    {
                        writer.Write(scene[i][j]);
                    }
                    writer.WriteLine();
                }


                var args = new string[]
                                {
                            $"Scene was saved in a file \"{_saveFileName}\"!",
                            "Press to continue..."
                                };
                Menu.ClientMenu(args);
                _ = Console.ReadLine();
            }
        }

        public static void SortHelper(ref List<ConsoleShape> cs)
        {
            if (!CheckCount(cs))
            {
                var args = new string[]
                            {
                            "Sort Shape",
                            "You can sort by perimeter(number of boundary symb)/area(number of symb), ascending/descending",
                            "",
                            "Enter \"x, y\"",
                            "x - \"p\" or \"a\"",
                            "y - \"a\" or \"d\"",
                            "if invalid args - back"
                            };
                Menu.ClientMenu(args);
                var mes = Console.ReadLine();
                if (Validation.SortValid(mes, out var prop, out var type))
                {
                    if (prop == "p")
                    {
                        if (type == "a")
                            cs.Sort((ConsoleShape a, ConsoleShape b) => a.Perimeter().CompareTo(b.Perimeter()));
                        else
                            cs.Sort((ConsoleShape a, ConsoleShape b) => b.Perimeter().CompareTo(a.Perimeter()));
                    }
                    else
                    {
                        if (type == "a")
                            cs.Sort((ConsoleShape a, ConsoleShape b) => a.Area().CompareTo(b.Area()));
                        else
                            cs.Sort((ConsoleShape a, ConsoleShape b) => b.Area().CompareTo(a.Area()));
                    }
                    Repaint(cs);
                    AddStatistics(cs);
                }
            }

        }

        public static void StatisticsHelper(List<ConsoleShape> cs)
        {
            if (!CheckCount(cs))
            {
                AddStatistics(cs);
            }
        }

        private static void AddStatistics(List<ConsoleShape> cs)
        {
            Menu.ClearMenu();
            var ar = new string[Math.Min(cs.Count + 3, Menu.menuH - 3)];
            int i;
            ar[0] = "---STATISTICS---";
            for (i = 0; i < cs.Count && i < ar.Length - 3; i++)
            {
                var typeShape = string.Empty;
                if (cs[i] is Circle)
                    typeShape = nameof(Circle);
                else if (cs[i] is Rectangle)
                    typeShape = nameof(Rectangle);
                else if (cs[i] is Triangle)
                    typeShape = nameof(Triangle);
                else if (cs[i] is Line)
                    typeShape = nameof(Line);
                ar[i + 1] = $"{i} -- {cs[i].Color} {typeShape}, area - {cs[i].Area()}, " +
                    $"perimeter - {cs[i].Perimeter()}";
            }
            i++;
            if (cs.Count > Menu.menuH - 6)
            {
                ar[i] = "...";
            }
            i++;
            ar[i] = "Press to continue...";
            Menu.ClientMenu(ar);
            _ = Console.ReadLine();
        }

        public enum Side
        {
            Left,
            Right,
            Up,
            Down
        }
        public static void MoveHelper(ref List<ConsoleShape> cs)
        {
            if (!CheckCount(cs))
            {
                var args = new string[]
                            {
                            "Move Shape",
                            "Up and to the left you can move the figure only to the border",
                            "Enter \"index, side, number\"",
                            $"index - index for move[0;{cs.Count - 1}]",
                            "side - enum(Left, Right, Up, Down)",
                            "number - uint",
                            "if invalid args - back"
                            };
                Menu.ClientMenu(args);
                var mes = Console.ReadLine();
                if (Validation.MoveValid(mes, cs.Count, out var index,
                    out var num, out var side))
                {
                    var el = cs[index];
                    if (el is Rectangle or Circle)
                        MovingForRectOrCircle(ref cs, index, num, side);
                    else if (el is Line)
                        MovingForLine(ref cs, index, num, side);
                    else if (el is Triangle)
                        MovingForTriangle(ref cs, index, num, side);
                    Repaint(cs);
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

        private static bool CheckCount(List<ConsoleShape> cs)
        {
            if (cs.Count == 0)
            {
                var args = new string[]
                    {
                        "No shapes",
                        "Press to continue..."
                    };
                Menu.ClientMenu(args);
                _ = Console.ReadLine();
                return true;
            }
            return false;
        }

        private static void Repaint(List<ConsoleShape> cs)
        {
            Menu.ClearScene();
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i].Symbol = $"{i}"[0];
                cs[i].Print();
            }
        }

    }
}
