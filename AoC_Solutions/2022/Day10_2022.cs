namespace AoC_Collection._2022;

public class Day10_2022
{
    public static void P1(List<string> input)
    {
        var cycle = 0;
        var x = 1;
        var cycleToCheck = 20;
        var cycleResults = new List<int>();
        foreach (var line in input.Select(x => x.Split(' ')))
        {
            if (cycle == cycleToCheck)
            {
                cycleResults.Add(cycleToCheck * x);
                if (cycleToCheck == 220)
                {
                    break;
                }

                cycleToCheck += 40;
            }

            if (line[0] == "noop")
            {
                cycle++;
                continue;
            }
            else
            {
                if (cycleToCheck - cycle <= 2)
                {
                    cycleResults.Add(cycleToCheck * x);
                    if (cycleToCheck == 220)
                    {
                        break;
                    }

                    cycleToCheck += 40;
                }

                cycle += 2;
                x += int.Parse(line[1]);
            }
        }

        Console.WriteLine(cycleResults.Sum());
    }

    public static void P2(List<string> input)
    {
        var x = 1;
        var cycle = 0;
        var crt = new List<string> {""};
        var lines = input.Select(s => s.Split(' '));
        DrawPixel();
        foreach (var line in lines)
        {
            if (line.Length == 1)
            {
                cycle++;
                DrawPixel();
                continue;
            }
            else
            {
                cycle++;
                DrawPixel();
                cycle++;
                DrawPixel();
                x += int.Parse(line[1]);
            }
        }

        foreach (var l in crt)
        {
            Console.WriteLine(l);
        }


        void DrawPixel()
        {
            if (cycle % 40 == 0)
            {
                crt.Add("");
            }

            var index = crt[^1].Length - 1;
            if (index == x || index == x + 1 || index == x - 1)
            {
                crt[^1] += "#";
            }
            else
            {
                crt[^1] += ".";
            }
        }

    }
}