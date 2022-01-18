using Project1.Shapes;

namespace Project1.Helpers
{
    internal static class DeleteHelper
    {
        public static void Helper(ref List<ConsoleShape> cs)
        {
            if (!ListIsEmpty(cs))
            {
                var args = new string[]
                            {
                            "Delete Shape",
                            $"Enter index for delete[0;{cs.Count - 1}]",
                            "if invalid args - back"
                            };
                Menu.ClientMenu(args);

                var mes = Console.ReadLine();
                if (AddValidation.UintValid(mes, out var index) && index < cs.Count)
                {
                    cs.RemoveAt(index);
                    Repaint(cs);
                }
            }
        }

        public static void Repaint(List<ConsoleShape> cs)
        {
            Menu.ClearScene();
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i].Symbol = $"{i}"[0];
                cs[i].Print();
            }
        }

        public static bool ListIsEmpty(List<ConsoleShape> cs)
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
    }
}
