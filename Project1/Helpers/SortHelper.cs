using Project1.Shapes;

namespace Project1.Helpers
{
    internal static class SortHelper
    {
        public static void Helper(ref List<ConsoleShape> cs)
        {
            if (!DeleteHelper.ListIsEmpty(cs))
            {
                var args = new string[]
                            {
                            "Sort Shape",
                            "You can sort by perimeter(number of boundary symb)/area(number of symb), ascending/descending",
                            "In unfilled figures or in line perimeter = area",
                            "",
                            "Enter \"x, y\"",
                            "x - \"p\" or \"a\"",
                            "y - \"a\" or \"d\"",
                            "if invalid args - back"
                            };
                Menu.ClientMenu(args);

                var mes = Console.ReadLine();
                if (SortValid(mes, out var prop, out var type))
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
                    DeleteHelper.Repaint(cs);
                    StatisticsHelper.AddStatistics(cs);
                }
            }

        }

        public static bool SortValid(string el, out string prop, out string type)
        {
            prop = default;
            type = default;

            var args = el.Split(", ");
            if (args.Length != 2)
                return false;
            if ((args[0] != "a" && args[0] != "p") || (args[1] != "a" && args[1] != "d"))
                return false;

            prop = args[0];
            type = args[1];
            return true;
        }
    }
}
