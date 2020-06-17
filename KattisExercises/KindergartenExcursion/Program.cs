using System;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();

        long swaps = 0;
        int zoo = 0;
        int lake = 0;

        int[] zeroesBefore = new int[line.Length];

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '0')
            {
                swaps += (i - zoo);
                zoo++;
            }
            else if (line[i] == '1')
            {
                zeroesBefore[i] = zoo;
            }
        }

        long lakeSwaps = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '1')
            {
                lakeSwaps += i - zoo + (zoo - zeroesBefore[i]) - lake;
                lake++;
            }
        }

        Console.WriteLine(swaps + lakeSwaps);
    }
}
