using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;


namespace BFS_c_sharp
{
    class Program
    {
        static RandomDataGenerator generator = new RandomDataGenerator();
        static List<UserNode> users = generator.Generate();
        
        static void Main(string[] args)
        {
            
            foreach (UserNode user in users)
            {
                Console.WriteLine(user);
            }
            var root = users[0];
            var goal = users[5];

            int distance = Search(root, goal);
            Console.WriteLine("Searching. Root: " + root.FirstName + " " + root.LastName +
                ". Distance to: " + goal.FirstName + " " + goal.LastName + " is: " + distance);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public static int Search(UserNode start, UserNode searchFor)
        {
            int DistanceCounter = 1;
            Queue<UserNode> SearchQueue = new Queue<UserNode>();
            HashSet<UserNode> AlreadySearchedSet = new HashSet<UserNode>();
            //Queue<UserNode> NextSearch = new Queue<UserNode>();
            SearchQueue.Enqueue(start);


            while (SearchQueue.Count > 0)
            {
                UserNode Current = SearchQueue.Dequeue();
                if (AlreadySearchedSet.Contains(Current))
                {
                    continue;
                }
                Console.WriteLine("Checking "+ Current.FirstName +" " + Current.LastName + "'s friends. Current distance is: " + DistanceCounter);
                if (Current.Friends.Contains(searchFor))
                {
                    return DistanceCounter;
                }
                AlreadySearchedSet.Add(Current);
                foreach (UserNode friend in Current.Friends)
                {
                    if (!AlreadySearchedSet.Contains(friend))
                    {
 
                        SearchQueue.Enqueue(friend);
                    }

                }
                
                DistanceCounter++; /
            }
            return DistanceCounter;
        }
    }
}