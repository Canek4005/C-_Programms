using System;
using System.Linq;

namespace Meeting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Meeting("Alex:Arno;Alissa:Cornwell;Sarah:Bell;Andrew:Dorries;Ann:Kern;Haley:Arno;Paul:Dorny;Madison:Kern"));
        }
        public static string Meeting(string s)
        {
            

                string[] name = s.Split(new char[] { ';', ':' });

                string[] family = new string[name.Length / 2];
                int j = 1;
                for (int i = 0; i < family.Length; i++)
                {
                    family[i] = name[j].ToLower() + ", " + name[j - 1].ToLower();
                    j += 2;
                }
                
                var fam = from t in family
                          orderby t.Substring(0, t.IndexOf(",") - 1), t.Substring(t.IndexOf(",") + 1, t.Length- t.IndexOf(",")-1)
                          select t;
                        
                string message = null;
                foreach (string n in fam)
                    message += "(" + n + ")";
                return message.ToUpper();
            

        }
    }
}