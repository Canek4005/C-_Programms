using System;

namespace Tortoise_racing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Race(80, 100, 40).ToString());
        }
        public static int Race(int v1, int v2, int g)
        {
            int t = g / ((v2 - v1)*3600);
            int h = (int)(g / (v2 - v1));
            int m = (int)(g * 60 / (v2 - v1)  - h * 60);
            int s = (int)(g * 3600 / (v2 - v1)  - h * 60*60 - m * 60);


            return s;//new int[] { h, m, s };
        }
    }
}
