using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DuplicateCount("Indivisabilit"));
        }

        public static int DuplicateCount(string str)
        {
            
            var test = new HashSet<char>();
            str = str.ToLower();
            for(int i = 0; i < str.Length; i++)
            {
                for (int j = i+1; j < str.Length; j++)
                {
                    
                    if (str[i] == str[j]&&test.Contains(str[i])==false)
                    {
                        
                        test.Add(str[i]);
                        break;
                    }
                }
            }
            

            
            return test.Count;
        }
    }
}
