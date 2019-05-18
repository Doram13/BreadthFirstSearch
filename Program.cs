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

        public static int Search(UserNode root, UserNode searchFor)
        {
            int DistanceCounter = 1;
            Queue<UserNode> SearchQueue = new Queue<UserNode>();
            HashSet<UserNode> AlreadySearchedSet = new HashSet<UserNode>();
            Queue<UserNode> NextSearch = new Queue<UserNode>();
            SearchQueue.Enqueue(root);
            AlreadySearchedSet.Add(root);

            while (SearchQueue.Count > 0)
            {
                UserNode Current = SearchQueue.Dequeue();
                if (Current.Friends.Contains(searchFor))
                {
                    return DistanceCounter;
                }
                
                foreach (UserNode friend in Current.Friends)
                {
                    if (!AlreadySearchedSet.Contains(friend))
                    {
                        // Maybe a SearchNext Queue, where I ENqueue the friends..
                        SearchQueue.Enqueue(friend);
                        AlreadySearchedSet.Add(friend);
                    }

                }
                
                DistanceCounter++; //this shouldn't be here, but then where should it be??
            }
            return DistanceCounter;
        }
    }
}
    /* public static int DistanceBetweenTwoUser(UserNode starting, UserNode ending)
     {
         Queue<UserNode> UserToCheckNow = new Queue<UserNode>();
         List<UserNode> alreadyChecked = new List<UserNode>();
         List<UserNode> toCheckNext = new List<UserNode>() { starting };

         int distance = 1;
         //check friends of starting

         if (starting.Friends.Contains(ending))
         {
             return distance;
         }
         UserToCheckNow.Enqueue(starting);
         while (UserToCheckNow.Count > 0)
         {
             foreach 
         }



         {
             foreach(UserNode friend in starting.Friends)
             {
                 toCheckNext.Add(friend);
                 distance++;
             }

             UserToCheckNow.Enqueue(friend);

             if (friend.Friends.Contains(starting))
             {

             }


         }

         /*  private static int CheckFirstConnection(UserNode starting, ref int distance)
           {
               foreach (UserNode friend in starting.Friends)
               {
                   toCheckNext.Add(friend);
                   if (friend.Friends.Contains(starting))
                   {
                       alreadyChecked.Add(friend);
                       distance++;
                       return distance;
                   } 
                   // Recursive check of friends of friends
                   foreach (UserNode SecondFriend in toCheckNext)
                   {
                       if (alreadyChecked.Contains(SecondFriend))
                       {
                           continue;
                       }
                       distance = CheckFirstConnection(SecondFriend, ref distance);
                   }

               }
               return distance; */




