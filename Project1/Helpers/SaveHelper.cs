using Project1.Shapes;

namespace Project1.Helpers
{
    internal static class SaveHelper
    {
        public static readonly string _saveFileName = "scene.txt";

        public static void Helper(List<ConsoleShape> cs)
        {
            if (!DeleteHelper.ListIsEmpty(cs))
            {
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

    }
}
