using System;

namespace Mumbling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Accum("aBcD"));
        }
        public static String Accum(string s)
        {
            string str=null;
            
            int j = 0;
            foreach (char c in s.ToLower())
            {
                if(j>0)
                    str += "-";
                str += Convert.ToString(c).ToUpper();
                for (int i = 0; i < j; i++)
                {

                    str += c;
                }
                                
                j += 1;
            }
            // your code
            return str;
        }
    }
}
