using System;

namespace DecryptionOlimp
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine(Decrypt("tmjtwpcfcrqkphqtocvmoi645dzxziv2517224"));
            Console.ReadKey();
        }
        static string Decrypt(string crypto)
        {
            int sizeOfKey = fiboSizer(crypto.Length);
            string key = crypto.Substring(crypto.Length - sizeOfKey);
            crypto = crypto.Substring(0, crypto.Length - key.Length);
            string answer = "";
            int n = 0;
            for (int step = 0; step < key.Length; step++)
            {
                
                int f = fibo(n);
                int g = crypto.Length;
                for (int i = 0; i < g; i++)
                {

                    if (i < f&&crypto!=null)
                    {
                       int k = int.Parse(key[step].ToString());
                       answer+= Dvisitel(crypto[0], k);
                       crypto=crypto.Remove(0,1);
                    }
                    
                }
                n++;
            }

            return answer;
        }
        static int fiboSizer(int size)
        {
            int n = 0;
            int fuc = 1;
            int a = 1;
            int sum = 1;

            do
            {
                var c = fuc;
                fuc = fuc + a;
                a = c;
                n++;
                sum += fuc;

            } while (sum < size);
            return n;
        }
        static int fibo(int size)
        {
            
            int fuc = 1;
            int a = 1;           

            for(int i=0;i<size;i++)
            {
                var c = fuc;
                fuc = fuc + a;
                a = c;
                
                

            }
            return fuc;
        }
        static char Dvisitel(int let,int step)
        {
            int index = ((int)let - step);
            if (index < 48)
            {
                index = 123 - (48 - index);
            }
            if (index > 57 && index < 97)
                index = 58 - (97 - index);
            let = (char)index;
            return (char)let;



        }
    }
}
