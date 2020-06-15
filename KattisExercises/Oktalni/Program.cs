using System;

class Program
{
    static void Main()
    {
        string binary = Console.ReadLine();
        binary = binary.PadLeft(binary.Length + Math.Abs(3 - (binary.Length % 3 == 0 ? 3 : binary.Length % 3)), '0');

        string octal = string.Empty;

        for (int i = 0; i < binary.Length; i += 3)
        {
            switch (binary.Substring(i, 3))
            {
                case "000":
                    octal += "0";
                    break;
                case "001":
                    octal += "1";
                    break;
                case "010":
                    octal += "2";
                    break;
                case "011":
                    octal += "3";
                    break;
                case "100":
                    octal += "4";
                    break;
                case "101":
                    octal += "5";
                    break;
                case "110":
                    octal += "6";
                    break;
                case "111":
                    octal += "7";
                    break;
            }
        }

        Console.WriteLine(octal);
    }
}