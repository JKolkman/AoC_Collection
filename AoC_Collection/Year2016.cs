namespace AoC_Collection;

public class Year2016
{
    public static void Main2016()
    {
        D2P2(null);
    }
    
    //Day 1
    public static void D1P1(string input)
    {
        var heading = 0; // 0-North, 1-East, 2-South, 3-West
        var N = 0;
        var E = 0;
        var S = 0;
        var W = 0;

        var i = input.Replace(" ", "").Split(",");
        foreach (var line in i)
        {
            heading += line.ToCharArray()[0] switch
            {
                'R' => 1,
                'L' => -1,
                _ => throw new ArgumentOutOfRangeException()
            };
            if (heading == -1) heading = 3;
            if (heading == 4) heading = 0;

            var num = int.Parse(line[1..]);
            
            switch (heading)
            {
                case 0:
                    N += num;
                    S -= num;
                    break;
                case 1:
                    E += num;
                    W -= num;
                    break;
                case 2:
                    S += num;
                    N -= num;
                    break;
                case 3:
                    W += num;
                    E -= num;
                    break;
            }
        }
        
        Console.WriteLine("N: " + N + "\nE: " + E + "\nS: " + S + "\nW: " + W);
    }
    public static void D1P2(string input)
    {
        var heading = 0; // 0-North, 1-East, 2-South, 3-West
        var N = 0;
        var E = 0;
        var S = 0;
        var W = 0;
        var visited = new List<string>();

        var i = input.Replace(" ", "").Split(",");
        foreach (var line in i)
        {
            heading += line.ToCharArray()[0] switch
            {
                'R' => 1,
                'L' => -1,
                _ => throw new ArgumentOutOfRangeException()
            };
            if (heading == -1) heading = 3;
            if (heading == 4) heading = 0;

            var num = int.Parse(line[1..]);
            
            for (var j = 0; j < num; j++)
            {
                switch (heading)
                {
                    case 0:
                        N++;
                        S--;
                        break;
                    case 1:
                        E++;
                        W--;
                        break;
                    case 2:
                        S++;
                        N--;
                        break;
                    case 3:
                        W++;
                        E--;
                        break;
                }

                var locString = $"{N} -  {E} - {S} - {W}";
                if (visited.Contains(locString))
                {
                    Console.WriteLine("N: " + N + "\nE: " + E + "\nS: " + S + "\nW: " + W);
                    return;
                }
                else
                {
                    visited.Add(locString);
                }
            }
        }
    }
    
    //Day 2
    public static void D2P1(List<string> input)
    {
        //input = new List<string> {"ULL", "RRDDD", "LURDL", "UUUUD"};
        var loc = 5;
        var code = "";
        foreach (var line in input)
        {
            foreach (var i in line.ToCharArray())
            {
                switch (i)
                {
                    case 'U':
                        if (loc >= 4)
                        {
                            loc -= 3;
                        }
                        
                        break;
                    case 'D':
                        if (loc <= 6)
                        {
                            loc += 3;
                        }

                        break;
                    case 'R':
                        if (loc is not (3 or 6 or 9))
                        {
                            loc++;
                        }

                        break;
                    case 'L':
                        if (loc is not (1 or 4 or 7))
                        {
                            loc--;
                        }

                        break;
                }
            }

            code += loc;
        }

        Console.WriteLine(code);
    }
    public static void D2P2(List<string> input)
    {
        var keypad = new char[5, 5]
        {
            {'X', 'X', '1', 'X', 'X'},
            {'X', '2', '3', '4', 'X'},
            {'5', '6', '7', '8', '9'},
            {'X', 'A', 'B', 'C', 'X'},
            {'X', 'X', 'D', 'X', 'X'}
        };
        var (x, y) = (2, 0);
        var code = "";
        foreach (var line in input)
        {
            foreach (var i in line.ToCharArray())
            {
                try
                {
                    switch (i)
                    {
                        case 'U':
                            if (keypad[x - 1, y] != 'X') x--;
                            break;
                        case 'D':
                            if (keypad[x + 1, y] != 'X') x++;
                            break;
                        case 'R':
                            if (keypad[x, y + 1] != 'X') y++;
                            break;
                        case 'L':
                            if (keypad[x, y - 1] != 'X') y--;
                            break;
                    }
                }
                catch (Exception e)
                {
                    //IGNORED
                }

            }

            code += keypad[x, y] + "";
        }
        Console.WriteLine(code);
    }
    
    //Day 3
    public static void D3P1(List<string> input)
    {
        var count = 0;
        foreach (var line in input)
        {
            var array = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            if ((array[0] + array[1] > array[2]) && (array[0] + array[2] > array[1]) &&
                (array[1] + array[2] > array[0])) count++;
        }

        Console.WriteLine(count);
    }
    public static void D3P2(List<string> input)
    {
        var count = 0;
        for (var i = 0; i < input.Count; i+=3)
        {
            var a1 = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var a2 = input[i+1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var a3 = input[i+2].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            if (a1[0] + a2[0] > a3[0] && a1[0] + a3[0] > a2[0] && a2[0] + a3[0] > a1[0]) count++;
            if (a1[1] + a2[1] > a3[1] && a1[1] + a3[1] > a2[1] && a2[1] + a3[1] > a1[1]) count++;
            if (a1[2] + a2[2] > a3[2] && a1[2] + a3[2] > a2[2] && a2[2] + a3[2] > a1[2]) count++;
        }
        Console.WriteLine(count);
    }
    
    //Day 4
    public static void D4P1(List<string> input)
    {
    }
    public static void D4P2(List<string> input)
    {
            
    }
    
    //Day 5
    public static void D5P1(List<string> input)
    {
    }
    public static void D5P2(List<string> input)
    {
            
    }
    
    //Day 6
    public static void D6P1(List<string> input)
    {
    }
    public static void D6P2(List<string> input)
    {
            
    }
    
    //Day 7
    public static void D7P1(List<string> input)
    {
    }
    public static void D7P2(List<string> input)
    {
            
    }
    
    //Day 8
    public static void D8P1(List<string> input)
    {
    }
    public static void D8P2(List<string> input)
    {
            
    }
    
    //Day 9
    public static void D9P1(List<string> input)
    {
    }
    public static void D9P2(List<string> input)
    {
            
    }
    
    //Day 10
    public static void D10P1(List<string> input)
    {
    }
    public static void D10P2(List<string> input)
    {
            
    }
    
    //Day 11
    public static void D11P1(List<string> input)
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