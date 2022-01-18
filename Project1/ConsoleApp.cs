using Project1.Helpers;
using Project1.Shapes;

namespace Project1
{
    internal static class ConsoleApp
    {

        public static void Run()
        {
            Menu.AddStartField();
            var consoleShapes = new List<ConsoleShape>();

            string key;
            do
            {
                Menu.ClearMenu();
                StartMenu();
                key = Console.ReadLine();
                Menu.ClearMenu();
                switch (key)
                {
                    case "1":
                        AddHelper.Helper(ref consoleShapes);
                        break;
                    case "2":
                        DeleteHelper.Helper(ref consoleShapes);
                        break;
                    case "3":
                        MoveHelper.Helper(ref consoleShapes);
                        break;
                    case "4":
                        SortHelper.Helper(ref consoleShapes);
                        break;
                    case "5":
                        SaveHelper.Helper(consoleShapes);
                        break;
                    case "6":
                        StatisticsHelper.Helper(consoleShapes);
                        break;
                    default:
                        key = "exit";
                        Console.SetCursorPosition(Menu.endForExit.X, Menu.endForExit.Y);
                        break;
                }
            } while (key != "exit");
        }

        private static void StartMenu()
        {
            var args = new string[]
            {
        "Enter action: ",
        "1 - add shape",
        "2 - delete shape",
        "3 - move shape",
        "4 - sort shape",
        "5 - save scene in file",
        "6 - statistics",
        "otherwise - stop program"
            };
            Menu.ClientMenu(args);
        }
    }
}
