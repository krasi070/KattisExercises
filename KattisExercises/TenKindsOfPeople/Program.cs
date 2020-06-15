using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        string[] map = ReadMap(dimensions);
        int numberOfQueries = int.Parse(Console.ReadLine());

        int[,] areas = GetAreas(map, dimensions);

        for (int i = 0; i < numberOfQueries; i++)
        {
            int[] args = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n) - 1)
                .ToArray();

            if (areas[args[0], args[1]] == areas[args[2], args[3]])
            {
                if (map[args[0]][args[1]] == '0')
                {
                    Console.WriteLine("binary");
                }
                else
                {
                    Console.WriteLine("decimal");
                }
            }
            else
            {
                Console.WriteLine("neither");
            }
        }
    }

    private static string[] ReadMap(int[] dimensions)
    {
        string[] map = new string[dimensions[0]];

        for (int i = 0; i < dimensions[0]; i++)
        {
            map[i] = Console.ReadLine();
        }

        return map;
    }

    private static int[,] GetAreas(string[] map, int[] dimensions)
    {
        int[,] areas = new int[dimensions[0], dimensions[1]];
        int areaCode = 1;

        for (int i = 0; i < dimensions[0]; i++)
        {
            for (int j = 0; j < dimensions[1]; j++)
            {
                if (areas[i, j] == 0)
                {
                    SearchArea(map, areas, i, j, areaCode);
                    areaCode++;
                }
            }
        }

        return areas;
    }

    private static void SearchArea(string[] map, int[,] areas, int row, int col, int areaCode)
    {
        Queue<int[]> positions = new Queue<int[]>();
        positions.Enqueue(new int[] { row, col });
        areas[row, col] = areaCode;

        while (positions.Count > 0)
        {
            int[] currPosition = positions.Dequeue();

            if (currPosition[0] - 1 >= 0 &&
                map[currPosition[0] - 1][currPosition[1]] == map[currPosition[0]][currPosition[1]] &&
                areas[currPosition[0] - 1, currPosition[1]] == 0)
            {
                positions.Enqueue(new int[] { currPosition[0] - 1, currPosition[1] });
                areas[currPosition[0] - 1, currPosition[1]] = areaCode;
            }

            if (currPosition[1] + 1 < map[0].Length &&
                map[currPosition[0]][currPosition[1] + 1] == map[currPosition[0]][currPosition[1]] &&
                areas[currPosition[0], currPosition[1] + 1] == 0)
            {
                positions.Enqueue(new int[] { currPosition[0], currPosition[1] + 1 });
                areas[currPosition[0], currPosition[1] + 1] = areaCode;
            }

            if (currPosition[0] + 1 < map.Length &&
                map[currPosition[0] + 1][currPosition[1]] == map[currPosition[0]][currPosition[1]] &&
                areas[currPosition[0] + 1, currPosition[1]] == 0)
            {
                positions.Enqueue(new int[] { currPosition[0] + 1, currPosition[1] });
                areas[currPosition[0] + 1, currPosition[1]] = areaCode;
            }

            if (currPosition[1] - 1 >= 0 &&
                map[currPosition[0]][currPosition[1] - 1] == map[currPosition[0]][currPosition[1]] &&
                areas[currPosition[0], currPosition[1] - 1] == 0)
            {
                positions.Enqueue(new int[] { currPosition[0], currPosition[1] - 1 });
                areas[currPosition[0], currPosition[1] - 1] = areaCode;
            }
        }
    }
}
