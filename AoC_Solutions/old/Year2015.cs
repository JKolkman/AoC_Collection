using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AoC_Collection
{
    public static class Year2015
    {
        public static void Main2015()
        {
        }

        public static void D1P1(List<string> input)
        {
            var floor = input[0]
                .ToCharArray()
                .Sum(c => c switch
                {
                    '(' => 1,
                    ')' => -1,
                    _ => 0
                });

            Console.WriteLine(floor);
        } // Day1 Part1

        public static void D1P2(List<string> input)
        {
            var floor = 0;
            var step = 1;
            foreach (var c in input[0].ToCharArray())
            {
                floor += c switch
                {
                    '(' => 1,
                    ')' => -1,
                    _ => 0
                };
                if (floor == -1)
                {
                    Console.WriteLine(step);
                    break;
                }

                step++;
            }
        } // Day1 Part2

        public static void D2P1(List<string> input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var split = Array.ConvertAll(line.Split("x"), s => s.Trim());
                var num1 = int.Parse(split[0]);
                var num2 = int.Parse(split[1]);
                var num3 = int.Parse(split[2]);


                var side1 = num1 * num2;
                var smallest = side1;
                var side2 = num2 * num3;
                if (side2 < smallest) smallest = side2;
                var side3 = num1 * num3;
                if (side3 < smallest) smallest = side3;

                total += 2 * side1;
                total += 2 * side2;
                total += 2 * side3;
                total += smallest;
            }

            Console.WriteLine(total);
        } // Day2 Part1

        public static void D2P2(List<string> input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var split = Array.ConvertAll(line.Split("x"), s => s.Trim());
                var num1 = int.Parse(split[0]);
                var num2 = int.Parse(split[1]);
                var num3 = int.Parse(split[2]);

                var small1 = num1;
                var small2 = num2;
                if (num3 < small1)
                {
                    small1 = num3;
                    if (num1 < small2)
                    {
                        small2 = num1;
                    }
                }
                else if (num3 < small2)
                {
                    small2 = num3;
                    if (num2 < small1)
                    {
                        small1 = num2;
                    }
                }

                total += 2 * small1;
                total += 2 * small2;
                total += num1 * num2 * num3;
            }

            Console.WriteLine(total);
        } // Day2 Part2

        public static void D3P1(List<string> input)
        {
            var loc = (0, 0);
            var grid = new Dictionary<(int, int), int>();
            grid.Add((0, 0), 1);
            var roboTurn = false;
            foreach (var c in input[0].ToCharArray())
            {
                loc = c switch
                {
                    '^' => (loc.Item1 + 1, loc.Item2),
                    '>' => (loc.Item1, loc.Item2 + 1),
                    'v' => (loc.Item1 - 1, loc.Item2),
                    '<' => (loc.Item1, loc.Item2 - 1)
                };

                if (grid.ContainsKey(loc))
                {
                    grid[loc]++;
                }
                else
                {
                    grid.Add(loc, 1);
                }
            }

            Console.WriteLine(grid.Count);
        } // Day3 Part1

        public static void D3P2(List<string> input)
        {
            var locSanta = (0, 0);
            var locRobot = (0, 0);
            var grid = new Dictionary<(int, int), int>();
            grid.Add((0, 0), 2);
            var roboTurn = false;
            foreach (var c in input[0].ToCharArray())
            {
                var t = c switch
                {
                    '^' => (1, 0),
                    '>' => (0, 1),
                    'v' => (-1, 0),
                    '<' => (0, -1),
                    _ => throw new ArgumentOutOfRangeException()
                };
                (int, int) loc;
                if (roboTurn)
                {
                    locRobot.Item1 += t.Item1;
                    locRobot.Item2 += t.Item2;
                    loc = locRobot;
                }
                else
                {
                    locSanta.Item1 += t.Item1;
                    locSanta.Item2 += t.Item2;
                    loc = locSanta;
                }

                if (grid.ContainsKey(loc))
                {
                    grid[loc]++;
                }
                else
                {
                    grid.Add(loc, 1);
                }

                roboTurn = !roboTurn;
            }

            Console.WriteLine(grid.Count);
        } // Day3 Part2

        public static void D4P1(List<string> input)
        {
            var counter = 0;
            var done = false;
            while (!done)
            {
                counter++;
                done = true;
                var toHash = input[0] + counter.ToString();
                MD5 md5 = MD5.Create();
                var inputBytes = Encoding.ASCII.GetBytes(toHash);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();

                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                for (var i = 0; i < 5; i++)
                {
                    if (sb.ToString()[i] != '0')
                    {
                        done = false;
                    }
                }
            }

            Console.WriteLine(counter);
        } // Day4 Part1

        public static void D4P2(List<string> input)
        {
            var counter = 0;
            var done = false;
            while (!done)
            {
                counter++;
                done = true;
                var toHash = input[0] + counter.ToString();
                MD5 md5 = MD5.Create();
                var inputBytes = Encoding.ASCII.GetBytes(toHash);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();

                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                for (var i = 0; i < 6; i++)
                {
                    if (sb.ToString()[i] != '0')
                    {
                        done = false;
                    }
                }
            }

            Console.WriteLine(counter);
        } // Day4 Part2

        public static void D5P1(List<string> input)
        {
            var disallowedSubstrings = new[] {"ab", "cd", "pq", "xy"}.ToList();
            var vowels = new char[] {'a', 'e', 'i', 'o', 'u'};
            var counter = 0;
            foreach (var line in input)
            {
                var repeated = false;
                var vowelCount = 0;
                var illegalChar = false;
                for (var i = 0; i < line.ToCharArray().Length; i++)
                {
                    var c = line.ToCharArray()[i];
                    if (vowels.Contains(c))
                    {
                        vowelCount++;
                    }

                    if (i == 0) continue;
                    if (c == line.ToCharArray()[i - 1])
                    {
                        repeated = true;
                    }

                    var s = "";
                    s += line.ToCharArray()[i - 1];
                    s += c;
                    if (disallowedSubstrings.Contains(s))
                    {
                        illegalChar = true;
                    }
                }

                if (repeated && !illegalChar && vowelCount >= 3)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        } // Day5 Part1

        public static void D5P2(List<string> input)
        {
            var counter = 0;
            foreach (var line in input)
            {
                var cArray = line.ToCharArray();
                var repeatSet = false;
                var repeatBetween = false;
                for (var i = 1; i < cArray.Length; i++)
                {
                    var s = "";
                    s += cArray[i - 1];
                    s += cArray[i];

                    if (line[(i + 1)..].Contains(s))
                    {
                        repeatSet = true;
                    }

                    ;

                    if (i == 1) continue;
                    if (cArray[i] == cArray[i - 2])
                    {
                        repeatBetween = true;
                    }
                }

                if (repeatBetween && repeatSet)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        } // Day5 Part2

        public static void D6P1(List<string> input)
        {
            var grid = new bool[1000, 1000];

            foreach (var line in input)
            {
                var action = 0; // 0-Toggle, 1-Turn On, 2- Turn Off
                var ySet = (0, 0);
                var xSet = (0, 0);
                var l = "";
                if (line.StartsWith("toggle"))
                {
                    action = 0;
                    l = line.Replace("toggle", "");
                }

                if (line.StartsWith("turn on"))
                {
                    action = 1;
                    l = line.Replace("turn on", "");
                }

                if (line.StartsWith("turn off"))
                {
                    action = 2;
                    l = line.Replace("turn off", "");
                }

                l = l.Trim();
                var split = l.Split(" through ");
                ySet.Item1 = int.Parse(split[0].Split(",")[0]);
                ySet.Item2 = int.Parse(split[1].Split(",")[0]);
                xSet.Item1 = int.Parse(split[0].Split(",")[1]);
                xSet.Item2 = int.Parse(split[1].Split(",")[1]);

                for (var y = ySet.Item1; y <= ySet.Item2; y++)
                {
                    for (var x = xSet.Item1; x <= xSet.Item2; x++)
                    {
                        grid[y, x] = action switch
                        {
                            0 => !grid[y, x],
                            1 => true,
                            2 => false,
                            _ => throw new ArgumentOutOfRangeException()
                        };
                    }
                }
            }

            var count = grid.Cast<bool>().Count(b => b);
            Console.WriteLine(count);
        } // Day6 Part1

        public static void D6P2(List<string> input)
        {
            var grid = new int[1000, 1000];

            foreach (var line in input)
            {
                var action = 0; // 0-Toggle, 1-Turn On, 2- Turn Off
                var ySet = (0, 0);
                var xSet = (0, 0);
                var l = "";
                if (line.StartsWith("toggle"))
                {
                    action = 0;
                    l = line.Replace("toggle", "");
                }

                if (line.StartsWith("turn on"))
                {
                    action = 1;
                    l = line.Replace("turn on", "");
                }

                if (line.StartsWith("turn off"))
                {
                    action = 2;
                    l = line.Replace("turn off", "");
                }

                l = l.Trim();
                var split = l.Split(" through ");
                ySet.Item1 = int.Parse(split[0].Split(",")[0]);
                ySet.Item2 = int.Parse(split[1].Split(",")[0]);
                xSet.Item1 = int.Parse(split[0].Split(",")[1]);
                xSet.Item2 = int.Parse(split[1].Split(",")[1]);

                for (var y = ySet.Item1; y <= ySet.Item2; y++)
                {
                    for (var x = xSet.Item1; x <= xSet.Item2; x++)
                    {
                        grid[y, x] += action switch
                        {
                            0 => 2,
                            1 => 1,
                            2 => -1,
                            _ => throw new ArgumentOutOfRangeException()
                        };
                        if (grid[y, x] < 0)
                        {
                            grid[y, x] = 0;
                        }
                    }
                }
            }

            var sum = grid.Cast<int>().Sum();
            Console.WriteLine(sum);
        } // Day6 Part2

        public static void D7P1(List<string> input)
        {
            Dictionary<string, string> wires = new();
            Dictionary<string, ushort> knownWires = new Dictionary<string, ushort>();

            foreach (var line in input)
            {
                var split = line.Split(" -> ");
                wires.Add(split[1], split[0]);
            }

            Console.WriteLine(Convert.ToInt32(ParseWire("a")));

            ushort ParseWire(string wire)
            {
                ushort r;
                if (knownWires.ContainsKey(wire))
                {
                    //Console.WriteLine(wire + " - " + knownWires[wire]);
                    return knownWires[wire];
                }

                var action = wires[wire];
                var split = action.Split(" ");
                if (split.Length == 1)
                {
                    r = int.TryParse(action, out var i) ? Convert.ToUInt16(i) : ParseWire(action);
                }
                else if (split[0] == "NOT")
                {
                    r = (ushort) ~ParseWire(split[1]);
                }
                else
                {
                    var i1 = int.TryParse(split[0], out var t1) ? Convert.ToUInt16(t1) : ParseWire(split[0]);
                    var i2 = int.TryParse(split[2], out var t2) ? Convert.ToUInt16(t2) : ParseWire(split[2]);

                    r = split[1] switch
                    {
                        "AND" => (ushort) (i1 & i2),
                        "OR" => (ushort) (i1 | i2),
                        "LSHIFT" => (ushort) (i1 << i2),
                        "RSHIFT" => (ushort) (i1 >> i2),
                    };
                }

                knownWires.Add(wire, r);
                return r;
            }
        } // Day7 Part1

        public static void D7P2(List<string> input)
        {
            Dictionary<string, string> wires = new();
            Dictionary<string, ushort> knownWires = new Dictionary<string, ushort>();

            foreach (var line in input)
            {
                var split = line.Split(" -> ");
                wires.Add(split[1], split[0]);
            }

            var a = ParseWire("a");
            knownWires = new Dictionary<string, ushort> {{"b", a}};
            Console.WriteLine(Convert.ToInt32(ParseWire("a")));

            ushort ParseWire(string wire)
            {
                ushort r;
                if (knownWires.ContainsKey(wire))
                {
                    //Console.WriteLine(wire + " - " + knownWires[wire]);
                    return knownWires[wire];
                }

                var action = wires[wire];
                var split = action.Split(" ");
                if (split.Length == 1)
                {
                    r = int.TryParse(action, out var i) ? Convert.ToUInt16(i) : ParseWire(action);
                }
                else if (split[0] == "NOT")
                {
                    r = (ushort) ~ParseWire(split[1]);
                }
                else
                {
                    var i1 = int.TryParse(split[0], out var t1) ? Convert.ToUInt16(t1) : ParseWire(split[0]);
                    var i2 = int.TryParse(split[2], out var t2) ? Convert.ToUInt16(t2) : ParseWire(split[2]);

                    r = split[1] switch
                    {
                        "AND" => (ushort) (i1 & i2),
                        "OR" => (ushort) (i1 | i2),
                        "LSHIFT" => (ushort) (i1 << i2),
                        "RSHIFT" => (ushort) (i1 >> i2),
                    };
                }

                knownWires.Add(wire, r);
                return r;
            }
        } // Day7 Part2

        public static void D8P1(List<string> input)
        {
            long codeChars = 0;
            long stringChars = 0;
            /*
            input = new List<string>
            {
                "\"\"",
                "\"abc\"",
                "\"aaa\\\"aaa\"",
                "\"\\x27\""
            };
            */

            foreach (var line in input)
            {
                //Console.WriteLine(line);
                var temp = 0;
                codeChars += 2;
                temp += 2;
                var chars = line.ToCharArray();
                for (var i = 1; i < chars.Length - 1; i++)
                {
                    if (chars[i] != '\\')
                    {
                        codeChars++;
                        temp++;
                        stringChars++;
                    }
                    else
                    {
                        if (chars[i + 1] == 'x')
                        {
                            codeChars += 4;
                            temp += 4;
                            stringChars++;
                            i += 3;
                        }
                        else
                        {
                            codeChars += 2;
                            temp += 2;
                            stringChars++;
                            i++;
                        }
                    }
                }
                //Console.WriteLine($"{temp} - {line}");
            }

            Console.WriteLine($"{codeChars} - {stringChars}");
            Console.WriteLine($"{codeChars - stringChars}");
        } // Day8 Part1

        public static void D8P2(List<string> input)
        {
            long codeChars = 0;
            long stringChars = 0;

            /*input = new List<string>
            {
                "\"\"",
                "\"abc\"",
                "\"aaa\\\"aaa\"",
                "\"\\x27\""
            };
*/
            foreach (var line in input)
            {
                stringChars += 2;
                var chars = line.ToCharArray();
                for (var i = 0; i < chars.Length; i++)
                {
                    if (chars[i] != '\\' && chars[i] != '\"')
                    {
                        codeChars++;
                        stringChars++;
                    }
                    else
                    {
                        codeChars++;
                        stringChars += 2;
                    }
                }
            }

            Console.WriteLine($"{stringChars} - {codeChars}");
            Console.WriteLine($"{stringChars - codeChars}");
        } // Day8 Part2

        public static void D9P1(List<string>? input)
        {
            input ??= new List<string>
            {
                "London to Dublin = 464",
                "London to Belfast = 518",
                "Dublin to Belfast = 141"
            };

            var cities = new Dictionary<string, D9City>();
            var cityList = new List<string>();
            var shortestPath = long.MaxValue;
            foreach (var split in input.Select(line => line.Split()))
            {
                if (!cities.ContainsKey(split[0]))
                {
                    cities.Add(split[0], new D9City());
                    cityList.Add(split[0]);
                }

                if (!cities.ContainsKey(split[2]))
                {
                    cities.Add(split[2], new D9City());
                    cityList.Add(split[2]);
                }

                cities[split[0]].AddNeighbour(split[2], int.Parse(split[4]));
                cities[split[2]].AddNeighbour(split[0], int.Parse(split[4]));
            }

            foreach (var c in cityList)
            {
                FindPath(c, new HashSet<string>(), 0);
            }

            Console.WriteLine(shortestPath);

            (string, HashSet<string>, int dist)? FindPath(string cur, HashSet<string> vis, long dist)
            {
                var curCity = cities[cur];
                var neighbours = curCity.GetNeighbours(vis).ToList();
                if (neighbours.Count == 0)
                {
                    if (dist < shortestPath)
                    {
                        shortestPath = dist;
                    }

                    return null;
                }

                var v2 = new HashSet<string>(vis) {cur};
                foreach (var (cName, distance) in neighbours)
                {
                    FindPath(cName, v2, (dist + distance));
                }

                return null;
            }
        } // Day9 Part1

        public static void D9P2(List<string>? input)
        {
            input ??= new List<string>
            {
                "London to Dublin = 464",
                "London to Belfast = 518",
                "Dublin to Belfast = 141"
            };

            var cities = new Dictionary<string, D9City>();
            var cityList = new List<string>();
            var shortestPath = long.MinValue;
            foreach (var split in input.Select(line => line.Split()))
            {
                if (!cities.ContainsKey(split[0]))
                {
                    cities.Add(split[0], new D9City());
                    cityList.Add(split[0]);
                }

                if (!cities.ContainsKey(split[2]))
                {
                    cities.Add(split[2], new D9City());
                    cityList.Add(split[2]);
                }

                cities[split[0]].AddNeighbour(split[2], int.Parse(split[4]));
                cities[split[2]].AddNeighbour(split[0], int.Parse(split[4]));
            }

            foreach (var c in cityList)
            {
                FindPath(c, new HashSet<string>(), 0);
            }

            Console.WriteLine(shortestPath);

            (string, HashSet<string>, int dist)? FindPath(string cur, HashSet<string> vis, long dist)
            {
                var curCity = cities[cur];
                var neighbours = curCity.GetNeighbours(vis).ToList();
                if (neighbours.Count == 0)
                {
                    if (dist > shortestPath)
                    {
                        shortestPath = dist;
                    }

                    return null;
                }

                var v2 = new HashSet<string>(vis) {cur};
                foreach (var (cName, distance) in neighbours)
                {
                    FindPath(cName, v2, (dist + distance));
                }

                return null;
            }
        } // Day9 Part1

        public static void D10P1(List<string> input)
        {
            //var line = input[0].ToCharArray();
            var curList = new List<(long, long)>
            {
                (1, 1),
                (1, 3),
                (1, 2),
                (2, 1),
                (1, 3),
                (3, 1),
                (1, 2)
            };

            for (var j = 0; j < 40; j++)
            {
                var bufferList = new List<(long, long)>();
                var c = curList[0].Item1;
                var count = 0;
                for (var i = 0; i < curList.Count; i++)
                {
                    if (curList[i].Item1 == c)
                    {
                        count++;
                    }
                    else
                    {
                        bufferList.Add((count, c));
                        c = curList[i].Item1;
                        count = 1;
                    }

                    if (curList[i].Item2 == c)
                    {
                        count++;
                    }
                    else
                    {
                        bufferList.Add((count, c));
                        c = curList[i].Item2;
                        count = 1;
                    }
                }

                bufferList.Add((count, c));
                curList = bufferList;
            }

            Console.WriteLine(curList.Sum(x => x.Item1));
        } // Day10 Part1

        public static void D10P2(List<string> input)
        {
            //var line = input[0].ToCharArray();
            var curList = new List<(long, long)>
            {
                (1, 1),
                (1, 3),
                (1, 2),
                (2, 1),
                (1, 3),
                (3, 1),
                (1, 2)
            };

            for (var j = 0; j < 50; j++)
            {
                var bufferList = new List<(long, long)>();
                var c = curList[0].Item1;
                var count = 0;
                for (var i = 0; i < curList.Count; i++)
                {
                    if (curList[i].Item1 == c)
                    {
                        count++;
                    }
                    else
                    {
                        bufferList.Add((count, c));
                        c = curList[i].Item1;
                        count = 1;
                    }

                    if (curList[i].Item2 == c)
                    {
                        count++;
                    }
                    else
                    {
                        bufferList.Add((count, c));
                        c = curList[i].Item2;
                        count = 1;
                    }
                }

                bufferList.Add((count, c));
                curList = bufferList;
            }

            Console.WriteLine(curList.Sum(x => x.Item1));
        } // Day10 Part2

        public static void D11P1(List<string> input)
        {
            var password = input[0];
            var valid = false;
            while (!valid)
            {
                password = D11IncrementPassword(password);
                if (D11ValidatePassword(password))
                {
                    valid = true;
                }
            }

            Console.WriteLine(password);
        } // Day11 Part1

        public static void D11P2(List<string> input)
        {
            var password = input[0];
            var count = 0;
            while (count < 2)
            {
                password = D11IncrementPassword(password);
                if (D11ValidatePassword(password)) count++;
            }

            Console.WriteLine(password);
        } // Day11 Part2

        public static void D12P1(List<string> input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var array = new JArray();
                if (line.StartsWith("["))
                {
                    array = JArray.Parse(line);
                }
                else
                {
                    array.Add(JObject.Parse(line));
                }


                foreach (var i in array)
                {
                    FindNum(i);
                }
            }

            Console.WriteLine(total);

            void FindNum(JToken item)
            {
                switch (item.Type)
                {
                    case JTokenType.Array or JTokenType.Object or JTokenType.Property:
                    {
                        foreach (var i in item)
                        {
                            FindNum(i);
                        }

                        break;
                    }
                    case JTokenType.Integer:
                        total += item.Value<int>();
                        break;
                }
            }
        } // Day12 Part1

        public static void D12P2(List<string> input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var array = new JArray();
                if (line.StartsWith("["))
                {
                    array = JArray.Parse(line);
                }
                else
                {
                    array.Add(JObject.Parse(line));
                }


                foreach (var i in array)
                {
                    FindNum(i);
                }
            }

            Console.WriteLine(total);

            void FindNum(JToken item)
            {
                switch (item.Type)
                {
                    case JTokenType.Property:
                    case JTokenType.Array:
                    {
                        foreach (var i in item)
                        {
                            FindNum(i);
                        }

                        break;
                    }
                    case JTokenType.Object:
                    {
                        var cancel = false;
                        foreach (var i in item.Values())
                        {
                            if (i.Type != JTokenType.String) continue;
                            if (i.Value<string>() is "red")
                            {
                                cancel = true;
                            }
                        }

                        if (cancel) return;
                        foreach (var i in item)
                        {
                            FindNum(i);
                        }

                        break;
                    }
                    case JTokenType.Integer:
                        total += item.Value<int>();
                        break;
                }
            }
        } // Day12 Part2

        public static void D13P1(List<string> input)
        {
            input = new List<string>()
            {
                "Alice would gain 54 happiness units by sitting next to Bob.",
                "Alice would lose 79 happiness units by sitting next to Carol.",
                "Bob would gain 83 happiness units by sitting next to Alice.",
                "Bob would lose 7 happiness units by sitting next to Carol.",
                "Bob would lose 63 happiness units by sitting next to David.",
                "Carol would gain 60 happiness units by sitting next to Bob.",
                "Carol would gain 55 happiness units by sitting next to David.",
                "David would gain 46 happiness units by sitting next to Alice.",
                "David would lose 7 happiness units by sitting next to Bob.",
                "David would gain 41 happiness units by sitting next to Carol."
            };
        } // Day13 Part1

        public static void D14(List<string>? input)
        {
            input ??= new List<string>
            {
                "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.",
                "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds."
            };

            var reindeers = new List<Reindeer>();
            foreach (var split in input.Select(line => line.Split(" ")))
            {
                var reindeer = new Reindeer(split[0], int.Parse(split[6]), int.Parse(split[13]), int.Parse(split[3]));
                reindeers.Add(reindeer);
            }

            for (var i = 0; i < 2503; i++)
            {
                foreach (var r in reindeers)
                {
                    if (r.resting)
                    {
                        r.currentRestTime++;
                        if (!r.currentRestTime.Equals(r.restTime)) continue;
                        r.resting = false;
                        r.currentRestTime = 0;
                    }
                    else
                    {
                        r.distance += r.speed;
                        r.currentSpeedTime++;
                        if (!r.currentSpeedTime.Equals(r.speedTime)) continue;
                        r.currentSpeedTime = 0;
                        r.resting = true;
                    }
                }

                var h = 0;
                var w = new List<Reindeer>();
                foreach (var r in reindeers)
                {
                    if (r.distance == h)
                    {
                        w.Add(r);
                    }

                    if (r.distance <= h) continue;
                    h = r.distance;
                    w.Clear();
                    w.Add(r);
                }

                foreach (var r in w)
                {
                    r.points++;
                }
            }

            foreach (var r in reindeers)
            {
                Console.WriteLine(r.name + " - " + r.distance);
                Console.WriteLine(r.name + " - " + r.points);
                Console.WriteLine();
            }
        } //Day14 Part1 

// Classes 
        private class D9City
        {
            private readonly List<(string, int)> _neighbours;

            public D9City()
            {
                _neighbours = new List<(string, int)>();
            }

            public void AddNeighbour(string c, int d)
            {
                _neighbours.Add((c, d));
            }

            public IEnumerable<(string, int)> GetNeighbours(IReadOnlySet<string> vis)
            {
                var res = _neighbours.Where(x => !vis.Contains(x.Item1));
                return res;
            }
        }
        
        private class Reindeer
        {
            public string name;
            public int restTime;
            public bool resting;
            public int currentRestTime;
            public int speed;
            public int speedTime;
            public int currentSpeedTime;
            public int distance;
            public int points;

            public Reindeer(string name, int speedTime, int restTime, int speed)
            {
                this.name = name;
                this.restTime = restTime;
                this.currentRestTime = 0;
                this.speed = speed;
                this.resting = false;
                this.speedTime = speedTime;
                this.currentSpeedTime = 0;
                this.distance = 0;
                this.points = 0;
            }
        }

//Functions
        private static string D11IncrementPassword(string p)
        {
            var c = p.ToCharArray();
            var currentChar = c.Length - 1;

            while (true)
            {
                if (c[currentChar] != 'z')
                {
                    c[currentChar] = (char) (c[currentChar] + 1);
                    p = new string(c);
                    if (!p.Contains('i') && !p.Contains('j') && !p.Contains('o')) return new string(c);
                    var found = false;
                    for (var i = 0; i < c.Length; i++)
                    {
                        if ((c[i] == 'i' || c[i] == 'l' || c[i] == 'o') && !found)
                        {
                            c[i] = (char) (c[i] + 1);
                            found = true;
                            continue;
                        }

                        if (found)
                        {
                            c[i] = 'a';
                        }
                    }

                    return new string(c);
                }
                else
                {
                    c[currentChar] = 'a';
                    if (currentChar != 0)
                    {
                        currentChar--;
                    }
                    else
                    {
                        currentChar = c.Length - 1;
                    }
                }
            }
        }

        private static bool D11ValidatePassword(string p)
        {
            var c = p.ToCharArray();
            var repeatCount = 1;
            var repeat = false;
            var pairCount = 0;
            var lastpair = '0';

            for (var i = 1; i < c.Length; i++)
            {
                if (c[i] == (char) (c[i - 1] + 1))
                {
                    repeatCount++;
                    if (repeatCount >= 3)
                    {
                        repeat = true;
                    }
                }
                else
                {
                    repeatCount = 1;
                }

                if (c[i] != c[i - 1] || c[i] == lastpair) continue;
                pairCount++;
                lastpair = c[i];
            }

            return repeat && pairCount >= 2;
        }
    }
}