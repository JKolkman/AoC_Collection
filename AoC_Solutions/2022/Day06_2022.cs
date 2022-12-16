namespace AoC_Collection._2022;

public class Day06_2022
{
    public static void P1(string input)
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
    public static void P2(string input)
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
}