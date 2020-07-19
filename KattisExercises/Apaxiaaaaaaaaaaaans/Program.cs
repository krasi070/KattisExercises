using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string result = input[0].ToString();

        char currChar = input[0];

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != currChar)
            {
                currChar = input[i];
                result += input[i].ToString();
            }
        }

        Console.WriteLine(result);
    }
}