using Project1.Shapes;

namespace Project1.Helpers
{
    internal static class AddHelper
    {
        private static void AddMenu()
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

        public static void Helper(ref List<ConsoleShape> cs)
        {
            string key;
            do
            {
                Menu.ClearMenu();
                AddMenu();
                key = Console.ReadLine();
                Menu.ClearMenu();
                Console.SetCursorPosition(1, 1);
                // symbol for drawing
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
                        else if (AddValidation.CircleValid(addC, symbol, out circle))
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
                                Menu.startForShape + new ConsolePoint(30, 0));
                            rectangle.Print();
                            cs.Add(rectangle);
                        }
                        else if (AddValidation.RectValid(addRec, symbol, out rectangle))
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
                        else if (AddValidation.TriangleValid(addT, symbol, out triangle))
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
                        else if (AddValidation.LineValid(addL, symbol, out line))
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
    }
}
