namespace AoC_Collection._2022;

public class Day02_2022
{
    public static void P1(IEnumerable<string> input)
    {
        var score = input.Sum(line => line switch
        {
            "A X" => 4,
            "A Y" => 8,
            "A Z" => 3,
            "B X" => 1,
            "B Y" => 5,
            "B Z" => 9,
            "C X" => 7,
            "C Y" => 2,
            "C Z" => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(line), line, "Error: Someone fucked up. Its probably me.")
        });

        Console.WriteLine(score);
    }
    public static void P2(IEnumerable<string> input)
    {
        var score = input.Sum(line => line switch
        {
            "A X" => 3,
            "A Y" => 4,
            "A Z" => 8,
            "B X" => 1,
            "B Y" => 5,
            "B Z" => 9,
            "C X" => 2,
            "C Y" => 6,
            "C Z" => 7,
            _ => throw new ArgumentOutOfRangeException(nameof(line), line, "Error: Someone fucked up. Its probably me.")
        });
        Console.WriteLine(score);
    }
}