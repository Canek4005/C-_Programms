using System;
using System.Linq;

namespace Vowel_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetVowelCount("abracadabra"));
        }
        public static int GetVowelCount(string str)
        {
           
            char[] alfabet = new char[] { 'a', 'e', 'i', 'o', 'u' };
            
            return (from t in str where alfabet.Contains(t) select t).Count();
        }
    }
}
