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

        int rows = args[0];
        int cols = args[1];
        int zRows = args[2];
        int zCols = args[3];

        char[,] inputMatrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string line = Console.ReadLine();

            for (int j = 0; j < cols; j++)
            {
                inputMatrix[i, j] = line[j];
            }
        }

        string[,] outputMatrix = new string[rows * zRows, cols * zCols];

        for (int i = 0; i < rows * zRows; i++)
        {
            for (int iCopy = 0; iCopy < zRows; iCopy++)
            {
                for (int j = 0; j < cols * zCols; j++)
                {
                    for (int jCopy = 0; jCopy < zCols; jCopy++)
                    {
                        outputMatrix[i, j] = inputMatrix[i / zRows, j / zCols].ToString();
                    }
                }
            }
        }

        for (int i = 0; i < outputMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < outputMatrix.GetLength(1); j++)
            {
                Console.Write(outputMatrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}
