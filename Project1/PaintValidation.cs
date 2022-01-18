
namespace Project1
{
    internal static class PaintValidation
    {
        private static readonly int _downBoundary = Menu.menuH + Menu.sceneH - 1;
        private static readonly int _rightBoundary = Menu.menuW - 2;

        public static void Paint(char symbol, bool ValidDrawing = true)
        {
            if (!ValidDrawing)
            {
                Console.Write(symbol);
                return;
            }

            (var left, var top) = Console.GetCursorPosition();
            if (top < _downBoundary && left < _rightBoundary)
                Console.Write(symbol);
        }

        public static void AddInList(char symbol, ref List<List<char>> scene, ref int posX, ref int posY)
        {
            if (posY < _downBoundary && posX < _rightBoundary)
                scene[posY - Menu.startForShape.Y][posX++] = symbol;
        }
    }
}
