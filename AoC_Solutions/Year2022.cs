using System.Collections;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.XPath;

namespace AoC_Collection;

public class Year2022
{
    public static void Main()
    {
        D10P2(DataGatherer.GetDataFromFileAsList(
            "C:\\Users\\Joost Kolkman\\RiderProjects\\AoC_Collection\\AoC_Solutions\\TestInput"));
    }

    //Day 1
    public static void D1P1(string input)
    {
        var l = input.Split("\n\n").Select(i => i.Split("\n").Select(int.Parse).Sum()).ToList();
        l.Sort((x, y) => y.CompareTo(x));
        Console.WriteLine(l[0]);

    }
    public static void D1P2(string input)
    {
        var l = input.Split("\n\n").Select(i => i.Split("\n").Select(int.Parse).Sum()).ToList();
        l.Sort((x, y) => y.CompareTo(x));
        Console.WriteLine(l.GetRange(0, 3).Sum());
    }

    //Day 2
    public static void D2P1(IEnumerable<string> input)
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
    public static void D2P2(IEnumerable<string> input)
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
    
    //Day 3
    public static void D3P1(List<string> input)
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
    public static void D3P2(List<string> input)
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

    //Day 4
    public static void D4P1(List<string> input)
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
    public static void D4P2(List<string> input)
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

    //Day 5
    public static void D5P1(List<string> input)
    {
        var stacks = new List<Stack<char>>
        {
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
        };
        var l = new List<char> {'B', 'L', 'D', 'T', 'W', 'C', 'F', 'M'};
        l.ForEach(x => stacks[0].Push(x));

        l = new List<char> {'M', 'B', 'L'};
        l.ForEach(x => stacks[1].Push(x));

        l = new List<char> {'J', 'C', 'H', 'T', 'L', 'V'};
        l.ForEach(x => stacks[2].Push(x));

        l = new List<char> {'S', 'P', 'J', 'W'};
        l.ForEach(x => stacks[3].Push(x));

        l = new List<char> {'Z', 'S', 'C', 'F', 'T', 'L', 'R'};
        l.ForEach(x => stacks[4].Push(x));

        l = new List<char> {'W', 'D', 'G', 'B', 'H', 'N', 'Z'};
        l.ForEach(x => stacks[5].Push(x));

        l = new List<char> {'F', 'M', 'S', 'P', 'V', 'G', 'C', 'N'};
        l.ForEach(x => stacks[6].Push(x));

        l = new List<char> {'W', 'Q', 'R', 'J', 'F', 'V', 'C', 'Z'};
        l.ForEach(x => stacks[7].Push(x));

        l = new List<char> {'R', 'P', 'M', 'L', 'H'};
        l.ForEach(x => stacks[8].Push(x));

        foreach (var s in from line in input where line.StartsWith("move") select line.Split(" "))
        {
            for (var i = 0; i < int.Parse(s[1]); i++)
            {
                if (stacks[int.Parse(s[3]) - 1].TryPop(out var result))
                {
                    stacks[int.Parse(s[5]) - 1].Push(result);
                }

            }
        }

        foreach (var s in stacks)
        {
            Console.Write(s.Peek());
        }
    }
    public static void D5P2(List<string> input)
    {
        var stacks = new List<Stack<char>>
        {
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
        };
        var l = new List<char> {'B', 'L', 'D', 'T', 'W', 'C', 'F', 'M'};
        l.ForEach(x => stacks[0].Push(x));

        l = new List<char> {'M', 'B', 'L'};
        l.ForEach(x => stacks[1].Push(x));

        l = new List<char> {'J', 'C', 'H', 'T', 'L', 'V'};
        l.ForEach(x => stacks[2].Push(x));

        l = new List<char> {'S', 'P', 'J', 'W'};
        l.ForEach(x => stacks[3].Push(x));

        l = new List<char> {'Z', 'S', 'C', 'F', 'T', 'L', 'R'};
        l.ForEach(x => stacks[4].Push(x));

        l = new List<char> {'W', 'D', 'G', 'B', 'H', 'N', 'Z'};
        l.ForEach(x => stacks[5].Push(x));

        l = new List<char> {'F', 'M', 'S', 'P', 'V', 'G', 'C', 'N'};
        l.ForEach(x => stacks[6].Push(x));

        l = new List<char> {'W', 'Q', 'R', 'J', 'F', 'V', 'C', 'Z'};
        l.ForEach(x => stacks[7].Push(x));

        l = new List<char> {'R', 'P', 'M', 'L', 'H'};
        l.ForEach(x => stacks[8].Push(x));

        foreach (var s in from line in input where line.StartsWith("move") select line.Split(" "))
        {
            var t = new Stack<char>();
            for (var i = 0; i < int.Parse(s[1]); i++)
            {
                if (stacks[int.Parse(s[3]) - 1].TryPop(out var result))
                {
                    t.Push(result);
                }

            }

            while (t.Count > 0)
            {
                stacks[int.Parse(s[5]) - 1].Push(t.Pop());
            }
        }

        foreach (var s in stacks)
        {
            Console.Write(s.Peek());
        }
    }

    //Day 6
    public static void D6P1(string input)
    {
        var queue = new Queue<char>();

        for (var i = 0; i < input.ToCharArray().Length; i++)
        {
            var c = input[i];
            if (queue.Count != 4)
            {
                queue.Enqueue(c);
            }
            else
            {
                queue.Dequeue();
                queue.Enqueue(c);

                if (queue.Distinct().Count() != 4) continue;
                Console.WriteLine(i + 1);
                break;
            }

        }
    }
    public static void D6P2(string input)
    {
        var queue = new Queue<char>();

        for (var i = 0; i < input.ToCharArray().Length; i++)
        {
            var c = input[i];
            if (queue.Count != 14)
            {
                queue.Enqueue(c);
            }
            else
            {
                queue.Dequeue();
                queue.Enqueue(c);

                if (queue.Distinct().Count() != 14) continue;
                Console.WriteLine(i + 1);
                break;
            }

        }
    }
    
    //Day 7
    public static void D7P1(List<string> input)
    {
        /*input = new List<string>
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };*/

        var dirStack = new Stack<Directory>();
        var allDirectories = new List<Directory>();
        dirStack.Push(new Directory("/"));
        allDirectories.Add(dirStack.Peek());
        input.RemoveAt(0);
        foreach (var commands in input.Select(line => line.Split(" ")))
        {
            switch (commands[0])
            {
                case "$":
                    switch (commands[1])
                    {
                        case "cd" when commands[2] == "..":
                            dirStack.Pop();
                            break;
                        case "cd":
                        {
                            var dir = dirStack.Peek().Directories.Find(x => x.Name == commands[2]);
                            if (dir == null)
                            {
                                dir = new Directory(commands[2]);
                                allDirectories.Add(dir);
                                dirStack.Peek().Directories.Add(dir);
                            }

                            dirStack.Push(dir);
                            break;
                        }
                        case "ls":
                            continue;
                    }

                    break;
                case "dir":
                {
                    var dir = dirStack.Peek().Directories.Find(x => x.Name == commands[1]);
                    if (dir != null) continue;
                    dir = new Directory(commands[1]);
                    allDirectories.Add(dir);
                    dirStack.Peek().Directories.Add(dir);
                    break;
                }
                default:
                {
                    var dir = dirStack.Peek();
                    dir.Files.Add((commands[1], int.Parse(commands[0])));

                    break;
                }
            }
        }

        var counter = allDirectories.Where(dir => dir.GetSize() <= 100000).Sum(dir => dir.GetSize());
        Console.WriteLine(counter);
    }
    public static void D7P2(List<string> input)
    {
        /*input = new List<string>
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };*/

        var dirStack = new Stack<Directory>();
        var allDirectories = new List<Directory>();
        dirStack.Push(new Directory("/"));
        allDirectories.Add(dirStack.Peek());
        input.RemoveAt(0);
        foreach (var commands in input.Select(line => line.Split(" ")))
        {
            switch (commands[0])
            {
                case "$":
                    switch (commands[1])
                    {
                        case "cd" when commands[2] == "..":
                            dirStack.Pop();
                            break;
                        case "cd":
                        {
                            var dir = dirStack.Peek().Directories.Find(x => x.Name == commands[2]);
                            if (dir == null)
                            {
                                dir = new Directory(commands[2]);
                                allDirectories.Add(dir);
                                dirStack.Peek().Directories.Add(dir);
                            }

                            dirStack.Push(dir);
                            break;
                        }
                        case "ls":
                            continue;
                    }

                    break;
                case "dir":
                {
                    var dir = dirStack.Peek().Directories.Find(x => x.Name == commands[1]);
                    if (dir != null) continue;
                    dir = new Directory(commands[1]);
                    allDirectories.Add(dir);
                    dirStack.Peek().Directories.Add(dir);
                    break;
                }
                default:
                {
                    var dir = dirStack.Peek();
                    dir.Files.Add((commands[1], int.Parse(commands[0])));

                    break;
                }
            }
        }

        var freeSpace = 70000000 - allDirectories[0].GetSize();
        var requiredSpace = 30000000 - freeSpace;
        var smallestDirSize = Double.MaxValue;

        foreach (var dir in allDirectories)
        {
            var size = dir.GetSize();
            if (size > requiredSpace && size < smallestDirSize)
            {
                smallestDirSize = dir.GetSize();
            }
        }

        Console.WriteLine(smallestDirSize);


    }

    private class Directory
    {
        public string Name;
        public List<(string, double)> Files;
        public List<Directory> Directories;

        public Directory(string name)
        {
            Name = name;
            Files = new List<(string, double)>();
            Directories = new List<Directory>();
        }

        public double GetSize()
        {
            return Files.Sum(file => file.Item2) + Directories.Sum(dir => dir.GetSize());
        }
    }

    //Day 8
    public static void D8P1(List<string> input)
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

    public static void D8P2(List<string> input)
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

    //Day 9
    public static void D9P1(List<string> input)
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

    public static void D9P2(List<string> input)
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

    //Day 10
    public static void D10P1(List<string> input)
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

    public static void D10P2(List<string> input)
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

    //Day 11
    public static void D11P1(string input)
    {
    }
    public static void D11P2(List<string> input)
    {
            
    }

    //Day 12
    public static void D12P1(List<string> input)
    {
    }
    public static void D12P2(List<string> input)
    {
            
    }
    
    //Day 13
    public static void D13P1(List<string> input)
    {
    }
    public static void D13P2(List<string> input)
    {
            
    }
    
    //Day 14
    public static void D14P1(List<string> input)
    {
    }
    public static void D14P2(List<string> input)
    {
            
    }
    
    //Day 15
    public static void D15P1(List<string> input)
    {
    }
    public static void D15P2(List<string> input)
    {
            
    }
    
    //Day 16
    public static void D16P1(List<string> input)
    {
    }
    public static void D16P2(List<string> input)
    {
            
    }
    
    //Day 17
    public static void D17P1(List<string> input)
    {
    }
    public static void D17P2(List<string> input)
    {
            
    }
    
    //Day 18
    public static void D18P1(List<string> input)
    {
    }
    public static void D18P2(List<string> input)
    {
            
    }
    
    //Day 19
    public static void D19P1(List<string> input)
    {
    }
    public static void D19P2(List<string> input)
    {
            
    }
    
    //Day 20
    public static void D20P1(List<string> input)
    {
    }
    public static void D20P2(List<string> input)
    {
            
    }
    
    //Day 21
    public static void D21P1(List<string> input)
    {
    }
    public static void D21P2(List<string> input)
    {
            
    }
    
    //Day 22
    public static void D22P1(List<string> input)
    {
    }
    public static void D22P2(List<string> input)
    {
            
    }
    
    //Day 23
    public static void D23P1(List<string> input)
    {
    }
    public static void D23P2(List<string> input)
    {
            
    }
    
    //Day 24
    public static void D24P1(List<string> input)
    {
    }
    public static void D24P2(List<string> input)
    {
            
    }
    
    //Day 25
    public static void D25P1(List<string> input)
    {
    }
    public static void D25P2(List<string> input)
    {
            
    }
}