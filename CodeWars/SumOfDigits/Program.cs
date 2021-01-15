using System;
using System.Linq;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitalRoot(1235685));
        
        
        }
        public static int DigitalRoot(long n)
        {
            int sum = 0;
            var mes = n.ToString();
            foreach (char i in mes)
            {
                sum += int.Parse(i.ToString());
            }
            
            if ((sum / 10) >= 1)
            {
               return DigitalRoot(sum);
                
            }
            else
            {
                return sum;
                
            }
            
            

            
        }
    }
}
