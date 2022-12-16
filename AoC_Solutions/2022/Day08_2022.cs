namespace AoC_Collection._2022;

public class Day08_2022
{
    public static void P1(List<string> input)
    {
        var heightmap = new int[input[0].ToCharArray().Length, input.Count];
        var visibleTrees = new List<(int, int)>();
        for (var y = 0; y < input.Count; y++)
        {
            for (var x = 0; x < input[y].ToCharArray().Length; x++)
            {
                heightmap[x, y] = int.Parse(input[y].ToCharArray()[x].ToString());
            }
        }

        // LR
        for (var y = 0; y < heightmap.GetLongLength(1); y++)
        {
            var high = heightmap[0, y];
            if (!visibleTrees.Contains((0, y))) visibleTrees.Add((0, y));
            for (var x = 0; x < heightmap.GetLength(0); x++)
            {
                if (heightmap[x, y] <= high) continue;
                high = heightmap[x, y];
                if (visibleTrees.Contains((x, y))) continue;
                visibleTrees.Add((x, y));
            }
        }

        // RL
        for (var y = 0; y < heightmap.GetLongLength(1); y++)
        {
            var high = heightmap[heightmap.GetLength(0) - 1, y];
            if (!visibleTrees.Contains((heightmap.GetLength(0) - 1, y)))
                visibleTrees.Add((heightmap.GetLength(0) - 1, y));
            for (var x = heightmap.GetLength(0) - 1; x >= 0; x--)
            {
                if (heightmap[x, y] <= high) continue;
                high = heightmap[x, y];
                if (visibleTrees.Contains((x, y))) continue;
                visibleTrees.Add((x, y));
            }
        }

        //TB
        for (var x = 0; x < heightmap.GetLongLength(0); x++)
        {
            var high = heightmap[x, 0];
            if (!visibleTrees.Contains((x, 0))) visibleTrees.Add((x, 0));
            for (var y = 0; y < heightmap.GetLength(1); y++)
            {
                if (heightmap[x, y] <= high) continue;
                high = heightmap[x, y];
                if (visibleTrees.Contains((x, y))) continue;
                visibleTrees.Add((x, y));
            }
        }

        //BT
        for (var x = 0; x < heightmap.GetLongLength(0); x++)
        {
            var high = heightmap[x, heightmap.GetLength(1) - 1];
            if (!visibleTrees.Contains((x, heightmap.GetLength(1) - 1)))
                visibleTrees.Add((x, heightmap.GetLength(1) - 1));
            for (var y = heightmap.GetLength(1) - 1; y >= 0; y--)
            {
                if (heightmap[x, y] <= high) continue;
                high = heightmap[x, y];
                if (visibleTrees.Contains((x, y))) continue;
                visibleTrees.Add((x, y));
            }
        }

        Console.WriteLine(visibleTrees.Count);

        for (var y = 0; y < heightmap.GetLongLength(1); y++)
        {
            for (var x = 0; x < heightmap.GetLength(0); x++)
            {
                Console.Write(visibleTrees.Contains((x, y)) ? "X," : "O,");
            }

            Console.WriteLine();
        }
    }
    public static void P2(List<string> input)
    {
        var heightmap = new int[input[0].ToCharArray().Length, input.Count];
        for (var y = 0; y < input.Count; y++)
        {
            for (var x = 0; x < input[y].ToCharArray().Length; x++)
            {
                heightmap[x, y] = int.Parse(input[y].ToCharArray()[x].ToString());
            }
        }

        var scenicScore = int.MinValue;
        for (var y = 0; y < heightmap.GetLongLength(1); y++)
        {
            for (var x = 0; x < heightmap.GetLength(0); x++)
            {
                var values = (0, 0, 0, 0);
                var treeHeight = heightmap[x, y];

                for (var x2 = x - 1; x2 >= 0; x2--)
                {
                    values.Item1++;
                    if (heightmap[x2, y] >= treeHeight)
                    {
                        break;
                    }
                }

                for (var x2 = x + 1; x2 < heightmap.GetLength(0); x2++)
                {
                    values.Item2++;
                    if (heightmap[x2, y] >= treeHeight)
                    {
                        break;
                    }
                }

                for (var y2 = y - 1; y2 >= 0; y2--)
                {
                    values.Item3++;
                    if (heightmap[x, y2] >= treeHeight)
                    {
                        break;
                    }
                }

                for (var y2 = y + 1; y2 < heightmap.GetLength(1); y2++)
                {
                    values.Item4++;
                    if (heightmap[x, y2] >= treeHeight)
                    {
                        break;
                    }
                }

                var cur = values.Item1 * values.Item2 * values.Item3 * values.Item4;
                if (cur > scenicScore) scenicScore = cur;
            }
        }

        Console.WriteLine(scenicScore);
    }
}