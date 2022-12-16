namespace AoC_Collection._2022;

public class Day04_2022
{
    public static void P1(List<string> input)
    {
        var count = 0;
        foreach (var line in input)
        {
            var split = line.Split(",");
            var val1 = split[0].Split("-").Select(int.Parse).ToArray();
            var val2 = split[1].Split("-").Select(int.Parse).ToArray();
            if (val1[0] <= val2[0] && val1[1] >= val2[1])
            {
                count++;
                continue;
            }

            if (val2[0] <= val1[0] && val2[1] >= val1[1]) count++;
        }

        Console.WriteLine(count);
    }
    public static void P2(List<string> input)
    {
        var count = 0;
        foreach (var line in input)
        {
            var split = line.Split(",");
            var val1 = split[0].Split("-").Select(int.Parse).ToArray();
            var val2 = split[1].Split("-").Select(int.Parse).ToArray();
            if (val1[0] <= val2[0] && val1[1] >= val2[0]) count++;
            else if (val1[0] <= val2[1] && val1[1] >= val2[1]) count++;
            else if (val2[0] <= val1[0] && val2[1] >= val1[0]) count++;
            else if (val2[0] <= val1[1] && val2[1] >= val1[1]) count++;
        }

        Console.WriteLine(count);
    }
}