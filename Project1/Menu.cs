
using Project1.Shapes;

namespace Project1
{
    internal static class Menu
    {
        public static ConsolePoint startForShape;
        public static ConsolePoint endForExit;
        public static int menuW;
        public static int menuH;
        public static int sceneH;
        public static void AddStartField(int menuW = 100, int menuH = 20, int sceneH = 30)
        {
            // for Windows
            // Console.WindowHeight = Console.LargestWindowHeight;
            // Console.WindowWidth = Console.LargestWindowWidth;
            Menu.menuW = menuW;
            Menu.menuH = menuH;
            Menu.sceneH = sceneH;
            startForShape = new ConsolePoint(1, menuH + 1);
            endForExit = new ConsolePoint(0, sceneH + menuH + 1);
            ConsoleShape menuRect = new Rectangle('#', new ConsolePoint(0, 0), menuW, menuH, ConsoleColor.Blue);
            menuRect.Print();
            Console.SetCursorPosition(1, 0);
            Console.Write("MENU");
            ConsoleShape sceneRect = new Rectangle('#', new ConsolePoint(0, menuH), menuW, sceneH, ConsoleColor.Blue);
            sceneRect.Print();
            Console.SetCursorPosition(1, menuH);
            Console.Write("SCENE");
            Console.SetCursorPosition(1, 1);
        }

        public static void ClearMenu()
        {
            Console.SetCursorPosition(1, 1);
            var args = new string[menuH - 2];
            for (var i = 0; i < menuH - 2; i++)
            {
                args[i] = string.Empty.PadLeft(menuW - 2);
            }
            ClientMenu(args);
        }

        public static void ClearScene()
        {
            var args = new string[sceneH - 2];
            for (var i = 0; i < sceneH - 2; i++)
            {
                args[i] = string.Empty.PadLeft(menuW - 2);
            }
            ClientMenu(args, menuH);
        }

        public static void ClientMenu(string[] args, int startCursorY = 0)
        {
            foreach (var el in args)
            {
                Console.SetCursorPosition(1, ++startCursorY);
                Console.WriteLine(el);
            }
            Console.SetCursorPosition(1, ++startCursorY);
        }


    }
}
