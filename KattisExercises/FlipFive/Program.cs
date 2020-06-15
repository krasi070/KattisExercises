using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> memory = GetTransformations();
        int numberOfProblems = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfProblems; i++)
        {
            string[] inputGrid = ReadMatrix();
            int clicks = memory[string.Join(string.Empty, inputGrid)];
            Console.WriteLine(clicks);
        }
    }

    private static string[] ReadMatrix()
    {
        string[] inputMatrix = new string[3];

        for (int i = 0; i < inputMatrix.Length; i++)
        {
            inputMatrix[i] = Console.ReadLine();
        }

        return inputMatrix;
    }

    private static Dictionary<string, int> GetTransformations()
    {
        Queue<Tuple<string[], int>> queue = new Queue<Tuple<string[], int>>();
        Dictionary<string, int> gridMemory = new Dictionary<string, int>();
        string[] grid = { "...", "...", "..." };

        gridMemory.Add(string.Join(string.Empty, grid), 0);
        queue.Enqueue(new Tuple<string[], int>(grid, 0));

        while (gridMemory.Count < Math.Pow(2, 9))
        {
            Tuple<string[], int> currTuple = queue.Dequeue();
            string[] currGrid = currTuple.Item1;
            int currCount = currTuple.Item2;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string[] flippedGrid = Flip(currGrid, i, j);

                    if (!gridMemory.Keys.Any(g => g == string.Join(string.Empty, flippedGrid)))
                    {
                        queue.Enqueue(new Tuple<string[], int>(flippedGrid, currCount + 1));
                        gridMemory.Add(string.Join(string.Empty, flippedGrid), currCount + 1);
                    }
                }
            }
        }

        return gridMemory;
    }

    private static string[] Flip(string[] grid, int rowPos, int colPos)
    {
        string[] flippedGrid = new string[3];
        Array.Copy(grid, flippedGrid, 3);
        flippedGrid[rowPos] = FlipCell(flippedGrid[rowPos], colPos);

        if (rowPos - 1 >= 0)
        {
            flippedGrid[rowPos - 1] = FlipCell(flippedGrid[rowPos - 1], colPos);
        }

        if (colPos + 1 < flippedGrid.Length)
        {
            flippedGrid[rowPos] = FlipCell(flippedGrid[rowPos], colPos + 1);
        }

        if (rowPos + 1 < flippedGrid.Length)
        {
            flippedGrid[rowPos + 1] = FlipCell(flippedGrid[rowPos + 1], colPos);
        }

        if (colPos - 1 >= 0)
        {
            flippedGrid[rowPos] = FlipCell(flippedGrid[rowPos], colPos - 1);
        }

        return flippedGrid;
    }

    private static string FlipCell(string row, int index)
    {
        return row[index] == '.' ? 
            row.Substring(0, index) + "*" + row.Substring(index + 1) :
            row.Substring(0, index) + "." + row.Substring(index + 1);
    }
}
