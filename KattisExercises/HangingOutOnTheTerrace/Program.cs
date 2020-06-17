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

        int safetyLimit = args[0];
        int n = args[1];

        int currentCapacity = 0;
        int turnedDownCounter = 0;

        for (int i = 0; i < n; i++)
        {
            string[] eventArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int numberOfPeople = int.Parse(eventArgs[1]);

            if (eventArgs[0] == "enter")
            {
                if (currentCapacity + numberOfPeople <= safetyLimit)
                {
                    currentCapacity += numberOfPeople;
                }
                else
                {
                    turnedDownCounter++;
                }
            }
            else
            {
                currentCapacity -= numberOfPeople;
            }
        }

        Console.WriteLine(turnedDownCounter);
    }
}
