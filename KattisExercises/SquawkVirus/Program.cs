using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private class User
    {
        public User(bool infected)
        {
            SquawksToAdd = 0;
            SquawksToSend = infected ? 1 : 0;
            Neighbours = new HashSet<User>();
        }

        public HashSet<User> Neighbours { get; set; }

        public long SquawksToSend { get; set; }

        public long SquawksToAdd { get; set; }
    }

    static void Main()
    {
        int[] args = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int numberOfUsers = args[0];
        int numberOfLinks = args[1];
        int initiallyInfected = args[2];
        int time = args[3];

        User[] users = new User[numberOfUsers];

        for (int i = 0; i < numberOfUsers; i++)
        {
            if (i == initiallyInfected)
            {
                users[i] = new User(true);
            }
            else
            {
                users[i] = new User(false);
            }
        }

        for (int i = 0; i < numberOfLinks; i++)
        {
            int[] linksArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            users[linksArgs[0]].Neighbours.Add(users[linksArgs[1]]);
            users[linksArgs[1]].Neighbours.Add(users[linksArgs[0]]);
        }

        for (int i = 0; i < time; i++)
        {
            for (int j = 0; j < users.Length; j++)
            {
                if (users[j].SquawksToSend > 0)
                {
                    foreach (User neighbour in users[j].Neighbours)
                    {
                        neighbour.SquawksToAdd += users[j].SquawksToSend;
                    }
                }
            }

            foreach (User user in users)
            {
                user.SquawksToSend = user.SquawksToAdd;
                user.SquawksToAdd = 0;
            }
        }

        if (time == 0)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(users.Sum(u => u.SquawksToSend));
        }
    }
}
