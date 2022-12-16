namespace AoC_Collection._2022;

public class Day07_2022
{
    public static void P1(List<string> input)
    { 
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
    public static void P2(List<string> input)
    { 
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
}