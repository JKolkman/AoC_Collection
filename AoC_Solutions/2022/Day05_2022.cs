namespace AoC_Collection._2022;

public class Day05_2022
{
    public static void P1(List<string> input)
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
        var l = new List<char> {'D', 'M', 'S', 'Z', 'R', 'F', 'W', 'N'};
        l.ForEach(x => stacks[0].Push(x));

        l = new List<char> {'W', 'P', 'Q', 'G', 'S'};
        l.ForEach(x => stacks[1].Push(x));

        l = new List<char> {'W', 'R', 'V', 'Q', 'F', 'N', 'J', 'C'};
        l.ForEach(x => stacks[2].Push(x));

        l = new List<char> {'F', 'Z', 'P', 'C', 'G', 'D', 'L'};
        l.ForEach(x => stacks[3].Push(x));

        l = new List<char> {'T', 'P', 'S'};
        l.ForEach(x => stacks[4].Push(x));

        l = new List<char> {'H', 'D', 'F', 'W', 'R', 'L'};
        l.ForEach(x => stacks[5].Push(x));

        l = new List<char> {'Z', 'N', 'D', 'C'};
        l.ForEach(x => stacks[6].Push(x));

        l = new List<char> {'W', 'N', 'R', 'F', 'V', 'S', 'J', 'Q'};
        l.ForEach(x => stacks[7].Push(x));

        l = new List<char> {'R', 'M', 'S', 'G', 'Z', 'W', 'V'};
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
    public static void P2(List<string> input)
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
        var l = new List<char> {'D', 'M', 'S', 'Z', 'R', 'F', 'W', 'N'};
        l.ForEach(x => stacks[0].Push(x));

        l = new List<char> {'W', 'P', 'Q', 'G', 'S'};
        l.ForEach(x => stacks[1].Push(x));

        l = new List<char> {'W', 'R', 'V', 'Q', 'F', 'N', 'J', 'C'};
        l.ForEach(x => stacks[2].Push(x));

        l = new List<char> {'F', 'Z', 'P', 'C', 'G', 'D', 'L'};
        l.ForEach(x => stacks[3].Push(x));

        l = new List<char> {'T', 'P', 'S'};
        l.ForEach(x => stacks[4].Push(x));

        l = new List<char> {'H', 'D', 'F', 'W', 'R', 'L'};
        l.ForEach(x => stacks[5].Push(x));

        l = new List<char> {'Z', 'N', 'D', 'C'};
        l.ForEach(x => stacks[6].Push(x));

        l = new List<char> {'W', 'N', 'R', 'F', 'V', 'S', 'J', 'Q'};
        l.ForEach(x => stacks[7].Push(x));

        l = new List<char> {'R', 'M', 'S', 'G', 'Z', 'W', 'V'};
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
}