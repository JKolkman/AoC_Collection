namespace AoC_Collection._2022;

public class Day09_2022
{
    public static void P1(List<string> input)
    {
        var hCoords = (0, 0);
        var tCoords = (0, 0);

        var uniques = new List<(int, int)>();
        uniques.Add((0, 0));

        foreach (var line in input.Select(x => x.Split(" ")))
        {
            for (var i = 0; i < int.Parse(line[1]); i++)
            {
                switch (line[0])
                {
                    case "U":
                        if (hCoords != tCoords)
                        {
                            if (hCoords.Item1 == tCoords.Item1 && hCoords.Item2 == tCoords.Item2 + 1)
                            {
                                tCoords.Item2++;
                            }
                            else if (hCoords.Item1 == tCoords.Item1 + 1)
                            {
                                if (hCoords.Item2 > tCoords.Item2)
                                {
                                    tCoords.Item1++;
                                    tCoords.Item2++;
                                }
                            }
                            else if (hCoords.Item1 == tCoords.Item1 - 1)
                            {
                                if (hCoords.Item2 > tCoords.Item2)
                                {
                                    tCoords.Item1--;
                                    tCoords.Item2++;
                                }
                            }
                        }

                        hCoords.Item2++;
                        break;
                    case "D":
                        if (hCoords != tCoords)
                        {
                            if (hCoords.Item1 == tCoords.Item1 && hCoords.Item2 == tCoords.Item2 - 1)
                            {
                                tCoords.Item2--;
                            }
                            else if (hCoords.Item1 == tCoords.Item1 - 1)
                            {
                                if (hCoords.Item2 < tCoords.Item2)
                                {
                                    tCoords.Item1--;
                                    tCoords.Item2--;
                                }
                            }
                            else if (hCoords.Item1 == tCoords.Item1 + 1)
                            {
                                if (hCoords.Item2 < tCoords.Item2)
                                {
                                    tCoords.Item1++;
                                    tCoords.Item2--;
                                }
                            }
                        }

                        hCoords.Item2--;
                        break;
                    case "R":
                        if (hCoords != tCoords)
                        {
                            if (hCoords.Item2 == tCoords.Item2 && hCoords.Item1 == tCoords.Item1 + 1)
                            {
                                tCoords.Item1++;
                            }
                            else if (hCoords.Item2 == tCoords.Item2 + 1)
                            {
                                if (hCoords.Item1 > tCoords.Item1)
                                {
                                    tCoords.Item2++;
                                    tCoords.Item1++;
                                }
                            }
                            else if (hCoords.Item2 == tCoords.Item2 - 1)
                            {
                                if (hCoords.Item1 > tCoords.Item1)
                                {
                                    tCoords.Item2--;
                                    tCoords.Item1++;
                                }
                            }
                        }

                        hCoords.Item1++;
                        break;
                    case "L":
                        if (hCoords != tCoords)
                        {
                            if (hCoords.Item2 == tCoords.Item2 && hCoords.Item1 == tCoords.Item1 - 1)
                            {
                                tCoords.Item1--;
                            }
                            else if (hCoords.Item2 == tCoords.Item2 + 1)
                            {
                                if (hCoords.Item1 < tCoords.Item1)
                                {
                                    tCoords.Item2++;
                                    tCoords.Item1--;
                                }
                            }
                            else if (hCoords.Item2 == tCoords.Item2 - 1)
                            {
                                if (hCoords.Item1 < tCoords.Item1)
                                {
                                    tCoords.Item2--;
                                    tCoords.Item1--;
                                }
                            }
                        }

                        hCoords.Item1--;
                        break;
                }

                if (!uniques.Contains(tCoords)) uniques.Add(tCoords);
            }
        }

        Console.WriteLine(uniques.Count);
    }

    public static void P2(List<string> input)
    {
        var knotPositions = new (int x, int y)[10];
        var ropeLocations = new HashSet<(int, int)>();

        foreach (var line in input.Select(x => x.Trim().Split(' ')))
        {
            var direction = line[0];
            var steps = int.Parse(line[1]);

            for (var i = 0; i < steps; i++)
            {
                switch (direction)
                {
                    case "R":
                        knotPositions[0].x += 1;
                        break;
                    case "L":
                        knotPositions[0].x -= 1;
                        break;
                    case "U":
                        knotPositions[0].y -= 1;
                        break;
                    case "D":
                        knotPositions[0].y += 1;
                        break;
                    default:
                        throw new Exception();
                }

                for (var j = 1; j < 10; j++)
                {
                    var dx = knotPositions[j - 1].x - knotPositions[j].x;
                    var dy = knotPositions[j - 1].y - knotPositions[j].y;

                    if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1) continue;
                    knotPositions[j].x += Math.Sign(dx);
                    knotPositions[j].y += Math.Sign(dy);
                }

                ropeLocations.Add(knotPositions[10 - 1]);
            }
        }

        Console.WriteLine($"{ropeLocations.Count}");
    }
}