using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n) + 2)
            .ToArray();

        int[,] map = new int[dimensions[0], dimensions[1]];
        string line = string.Empty;

        for (int i = 0; i < dimensions[0]; i++)
        {
            if (i != 0 && i != dimensions[0] - 1)
            {
                line = $"0{Console.ReadLine()}0";
            }
            else
            {
                line = new string('0', dimensions[1]);
            }

            for (int j = 0; j < dimensions[1]; j++)
            {
                map[i, j] = int.Parse(line[j].ToString());
            }
        }

        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { 0, 0 });
        bool[,] passed = new bool[dimensions[0], dimensions[1]];
        int coastLength = 0;

        while (queue.Count > 0)
        {
            int[] currTile = queue.Dequeue();
            coastLength += GetNumberOfNeighbouringLandTiles(map, currTile[0], currTile[1]);

            if (currTile[0] - 1 >= 0 && map[currTile[0] - 1, currTile[1]] == 0 && !passed[currTile[0] - 1, currTile[1]])
            {
                queue.Enqueue(new int[] { currTile[0] - 1, currTile[1] });
                passed[currTile[0] - 1, currTile[1]] = true;
            }

            if (currTile[1] + 1 < dimensions[1] && map[currTile[0], currTile[1] + 1] == 0 && !passed[currTile[0], currTile[1] + 1])
            {
                queue.Enqueue(new int[] { currTile[0], currTile[1] + 1 });
                passed[currTile[0], currTile[1] + 1] = true;
            }

            if (currTile[0] + 1 < dimensions[0] && map[currTile[0] + 1, currTile[1]] == 0 && !passed[currTile[0] + 1, currTile[1]])
            {
                queue.Enqueue(new int[] { currTile[0] + 1, currTile[1] });
                passed[currTile[0] + 1, currTile[1]] = true;
            }

            if (currTile[1] - 1 >= 0 && map[currTile[0], currTile[1] - 1] == 0 && !passed[currTile[0], currTile[1] - 1])
            {
                queue.Enqueue(new int[] { currTile[0], currTile[1] - 1 });
                passed[currTile[0], currTile[1] - 1] = true;
            }
        }

        Console.WriteLine(coastLength);
    }

    private static int GetNumberOfNeighbouringLandTiles(int[,] map, int i, int j)
    {
        int count = 0;

        if (i - 1 >= 0 && map[i - 1, j] == 1)
        {
            count++;
        }

        if (j + 1 < map.GetLength(1) && map[i, j + 1] == 1)
        {
            count++;
        }

        if (i + 1 < map.GetLength(0) && map[i + 1, j] == 1)
        {
            count++;
        }

        if (j - 1 >= 0 && map[i, j - 1] == 1)
        {
            count++;
        }

        return count;
    }
}
