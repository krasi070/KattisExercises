using System;
using System.Linq;

// Too slow
class Program
{
    static void Main()
    {
        int testCases = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCases; i++)
        {
            string instructions = Console.ReadLine().Replace("RR", string.Empty);
            int drops = instructions.Count(c => c == 'D');
            int listLength = int.Parse(Console.ReadLine());
            string[] list = Console.ReadLine().Split(new[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int start = 0;
            int end = list.Length - 1;

            bool reversed = false;

            if (drops > list.Length)
            {
                Console.WriteLine("error");
                continue;
            }
            else if (drops == list.Length)
            {
                Console.WriteLine("[]");
                continue;
            }

            for (int j = 0; j < instructions.Length; j++)
            {
                if (instructions[j] == 'R')
                {
                    reversed = !reversed;
                }
                else if (reversed)
                {
                    end--;
                }
                else
                {
                    start++;
                }
            }

            if (reversed)
            {
                Console.Write("[");

                for (int j = end; j >= start; j--)
                {
                    Console.Write(list[j]);

                    if (j > start)
                    {
                        Console.Write(",");
                    }
                }

                Console.WriteLine($"]");
            }
            else
            {
                Console.Write("[");

                for (int j = start; j <= end; j++)
                {
                    Console.Write(list[j]);

                    if (j < end)
                    {
                        Console.Write(",");
                    }
                }

                Console.WriteLine($"]");
            }
        }
    }
}
