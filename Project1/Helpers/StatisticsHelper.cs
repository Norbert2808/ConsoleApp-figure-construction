using Project1.Shapes;

namespace Project1.Helpers
{
    internal static class StatisticsHelper
    {
        public static void Helper(List<ConsoleShape> cs)
        {
            if (!DeleteHelper.ListIsEmpty(cs))
            {
                AddStatistics(cs);
            }
        }

        public static void AddStatistics(List<ConsoleShape> cs)
        {
            Menu.ClearMenu();
            var ar = new string[Math.Min(cs.Count + 3, Menu.menuH - 3)];
            int i;
            ar[0] = "---STATISTICS---";
            for (i = 0; i < cs.Count && i < ar.Length - 3; i++)
            {
                var typeShape = string.Empty;
                if (cs[i] is Circle)
                    typeShape = nameof(Circle);
                else if (cs[i] is Rectangle)
                    typeShape = nameof(Rectangle);
                else if (cs[i] is Triangle)
                    typeShape = nameof(Triangle);
                else if (cs[i] is Line)
                    typeShape = nameof(Line);
                ar[i + 1] = $"{i} -- {cs[i].Color} {typeShape}, area - {cs[i].Area()}, " +
                    $"perimeter - {cs[i].Perimeter()}";
            }

            if (cs.Count > Menu.menuH - 6)
                ar[++i] = "...";
            ar[++i] = "Press to continue...";
            Menu.ClientMenu(ar);
            _ = Console.ReadLine();
        }
    }
}
