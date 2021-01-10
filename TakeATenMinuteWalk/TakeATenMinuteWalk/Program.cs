using System;
using System.Linq;


namespace TakeATenMinuteWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValidWalk(new string[] {"n", "s", "n", "s", "w", "e", "n", "s", "w", "s"}).ToString());
        }
        public static bool IsValidWalk(string[] walk)
        {
            int count = walk.Count(t => t == "n");
            if (walk.Length == 10&& walk.Count(t => t == "n")== walk.Count(t => t == "s")&& walk.Count(t => t == "w") == walk.Count(t => t == "e"))
                return true;
            else
                return false;
        }
    }
}
