using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] args = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        double hypotenuse = Math.Sqrt(args[1] * args[1] + args[2] * args[2]);

        for (int i = 0; i < args[0]; i++)
        {
            int matchLength = int.Parse(Console.ReadLine());

            if (matchLength <= hypotenuse)
            {
                Console.WriteLine("DA");
            }
            else
            {
                Console.WriteLine("NE");
            }
        }
    }
}
