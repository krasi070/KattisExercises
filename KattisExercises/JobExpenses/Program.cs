using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int arrLength = int.Parse(Console.ReadLine());
        int expensesSum = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n < 0)
            .Sum();

        Console.WriteLine(Math.Abs(expensesSum));
    }
}
