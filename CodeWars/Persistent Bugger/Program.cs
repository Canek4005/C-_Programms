using System;
using System.Linq;

namespace Persistent_Bugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Persistence(39));
        }
        public static int Persistence(long n)
        {
            
            int i = 0;
            if(n.ToString().Length>1)
            do
            {
                    var sum = 1;
                foreach (char s in n.ToString())
                {
                    sum *= int.Parse(s.ToString());
                    
                }
                i++;
                n = Convert.ToInt64(sum);
            }
            while (n>=10);

            return i;
        }
    }
}
