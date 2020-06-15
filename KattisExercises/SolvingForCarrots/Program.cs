using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] args = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int contestants = args[0];
        int carrotsGiven = args[1];

        for (int i = 0; i < contestants; i++)
        {
            Console.ReadLine();
        }

        Console.WriteLine(carrotsGiven);
    }
}