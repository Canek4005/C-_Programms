using System;
using System.Collections;
using System.Collections.Generic;

namespace UniqueInOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UniqueInOrder("AAAABBBCCDAABBB"));
        }
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            var keeper = new HashSet<char>();
            string text = iterable.ToString();
            IEnumerable str;
            IEnumerable items;
            foreach (char c in text)
            {
                if (keeper.Contains(c)!)
                {
                    keeper.Add(c);
                    str.Add(c);
                    str = str.Concat(new[] { "foo" });
                    items = items.Add("bar");
                    
                }
            }




        }
    }    
}
