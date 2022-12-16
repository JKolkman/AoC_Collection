namespace AoC_Collection._2022;

public class Day03_2022 {
    public static void P1(List<string> input)
    {
        var score = 0;
        foreach (var line in input)
        {
            var a = line[..(line.Length / 2)];
            var b = line.Substring(line.Length / 2, line.Length / 2);

            foreach (var c in a.ToCharArray())
            {
                if (!b.Contains(c)) continue;
                score += c % 32;
                if (char.IsUpper(c)) score += 26;
                break;
            }
        }

        Console.WriteLine(score);
    }
    public static void P2(List<string> input)
    {
        var score = 0;
        for (var i = 0; i < input.Count; i += 3)
        {
            foreach (var c in input[i].ToCharArray())
            {
                if (!input[i + 1].Contains(c) || !input[i + 2].Contains(c)) continue;
                score += c % 32;
                if (char.IsUpper(c)) score += 26;
                break;
            }
        }

        Console.WriteLine(score);
    }
    
}