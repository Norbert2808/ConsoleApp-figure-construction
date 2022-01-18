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

        public static void AddStartField(int _menuW = 100, int _menuH = 20, int _sceneH = 30)
        {
            // for Windows
            // Console.WindowHeight = Console.LargestWindowHeight;
            // Console.WindowWidth = Console.LargestWindowWidth;

            menuW = _menuW;
            menuH = _menuH;
            sceneH = _sceneH;
            startForShape = new ConsolePoint(1, _menuH + 1);
            endForExit = new ConsolePoint(0, _sceneH + _menuH + 1);

            var menuRect = new Rectangle('#', new ConsolePoint(0, 0), _menuW, _menuH,
                ConsoleColor.Blue, filling: false)
            {
                ValidDrawing = false
            };
            menuRect.Print();
            Console.SetCursorPosition(1, 0);
            Console.Write("MENU");

            var sceneRect = new Rectangle('#', new ConsolePoint(0, _menuH), _menuW, _sceneH,
                ConsoleColor.Blue, filling: false)
            {
                ValidDrawing = false
            };
            sceneRect.Print();
            Console.SetCursorPosition(1, _menuH);
            Console.Write("SCENE");
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
