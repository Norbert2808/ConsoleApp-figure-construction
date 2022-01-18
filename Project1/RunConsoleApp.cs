﻿
using Project1.Shapes;

namespace Project1
{
    public static class RunConsoleApp
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
                        Helpers.AddHelper(ref consoleShapes);
                        break;
                    case "2":
                        Helpers.DeleteHelper(ref consoleShapes);
                        break;
                    case "3":
                        Helpers.MoveHelper(ref consoleShapes);
                        break;
                    case "4":
                        Helpers.SortHelper(ref consoleShapes);
                        break;
                    case "5":
                        Helpers.SaveHelper(consoleShapes);
                        break;
                    case "6":
                        Helpers.StatisticsHelper(consoleShapes);
                        break;
                    default:
                        key = "exit";
                        Console.SetCursorPosition(Menu.endForExit.X, Menu.endForExit.Y);
                        break;
                }
            } while (key != "exit");
        }

        public static void StartMenu()
        {
            var args = new string[]
            {
        "Enter action: ",
        "1 - add shape",
        "2 - delete shape",
        "3 - move shape",
        "4 - sort shape",
        "5 - save in file scene",
        "6 - statistics",
        "otherwise - stop program"
            };
            Menu.ClientMenu(args);
        }
    }
}
