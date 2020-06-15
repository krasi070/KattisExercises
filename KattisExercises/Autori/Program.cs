using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string longVariation = Console.ReadLine();
        string shortVariation = string.Join(
            string.Empty, longVariation.Split('-').Select(s => s[0].ToString()));

        Console.WriteLine(shortVariation);
    }
}
