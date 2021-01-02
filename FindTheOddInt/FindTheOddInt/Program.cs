using System;
using System.Collections;

namespace FindTheOddInt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(Find_it(new[]{ 1,2,3,3,2,1,3}));
        }
        public static int Find_it(int[] seq)
        {

            for(int i = 0; i < seq.Length; i++)
            {

                for(int j = i + 1; j < seq.Length; j++)
                {
                    if (seq[i] == seq[j] && seq[i] != 0)
                    {
                        seq[i] = 0;
                        seq[j] = 0;
                        break; 
                    }                    
                }
                if (seq[i] != 0)
                {
                    return seq[i];
                }
            }
            return -1;
        }
    }
}
