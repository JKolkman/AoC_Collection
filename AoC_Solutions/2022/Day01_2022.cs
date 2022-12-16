namespace AoC_Collection._2022
{
    public class Day01_2022
    {
        public static void P1(string input)
        {
            var l = input.Split("\n\n").Select(i => i.Split("\n").Select(int.Parse).Sum()).ToList();
            l.Sort((x, y) => y.CompareTo(x));
            Console.WriteLine(l[0]);

        }
        public static void P2(string input)
        {
            var l = input.Split("\n\n").Select(i => i.Split("\n").Select(int.Parse).Sum()).ToList();
            l.Sort((x, y) => y.CompareTo(x));
            Console.WriteLine(l.GetRange(0, 3).Sum());
        }
    }
}