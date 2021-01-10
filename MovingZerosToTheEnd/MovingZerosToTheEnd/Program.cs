using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingZerosToTheEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Zeros(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
        }
        static int[] Zeros(int[] array)
        {

            return  array.Where(i => i != 0).Concat(array.Where(i=>i==0)).ToArray();
                 

            

        }
    }
}
