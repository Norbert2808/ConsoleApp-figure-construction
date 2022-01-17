
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
                            "startPosX, startPosY, radius - uint",
                            "startPosX = 0 && startPosY = 0 - first cell in scene",
                            "color - enum(Blue, Red, Gray, Green ...)",
                            "filling - bool",
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
                            "startPosX, startPosY, width, height - uint",
                            "startPosX = 0 && startPosY = 0 - first cell in scene",
                            "color - enum(Blue, Red, Gray, Green ...)",
                            "filling - bool",
                            "if invalid args - back"
                        };
                        Menu.ClientMenu(args);
                        var addRec = Console.ReadLine();
                        Rectangle rectangle;
                        if (addRec == "d")
                        {
                            rectangle = new Rectangle(symbol, Menu.startForShape + new ConsolePoint(30, 0));
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
                            "Сan only add a right-angled isosceles triangle",
                            "Enter \"d\" for default",
                            "Or enter \"AX, AY, BX, BY, CX, CY, color\"",
                            "AX, AY, BX, BY, CX, CY - uint",
                            "color - enum(Blue, Red, Gray, Green ...)",
                            "if invalid args - back"
                        };
                        Menu.ClientMenu(args);
                        var addT = Console.ReadLine();
                        Triangle triangle;
                        if (addT == "d")
                        {
                            triangle = new Triangle(symbol, Menu.startForShape + new ConsolePoint(50, 10),
                                new ConsolePoint(0, 0), new ConsolePoint(10, 10), new ConsolePoint(0, 10));
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
                            "Can only add straight or diagonal line:",
                            @"     \ | /",
                             "     -   -",
                            @"     / | \",
                            "Enter \"d\" for default",
                            "Or enter \"AX, AY, BX, BY, color\"",
                            "AX, AY, BX, BY - uint",
                            "color - enum(Blue, Red, Gray, Green ...)",
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

        public static void SaveHelper(ref List<ConsoleShape> cs)
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
                            $"index - index for delete[0;{cs.Count - 1}]",
                            "side - enum(Left, Right, Up, Down)",
                            "number - uint",
                            "if invalid args - back"
                            };
                Menu.ClientMenu(args);
                var mes = Console.ReadLine();
                if (Validation.MoveValid(mes, cs.Count, out var index,
                    out var num, out var side))
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

                    Repaint(cs);
                }
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
