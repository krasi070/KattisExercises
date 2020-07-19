using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int arrLength = int.Parse(Console.ReadLine());
        int[] days = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int dayToLaunch = 0;

        for (int i = 1; i < arrLength; i++)
        {
            if (days[i] < days[dayToLaunch])
            {
                dayToLaunch = i;
            }
        }

        Console.WriteLine(dayToLaunch);
    }
}
