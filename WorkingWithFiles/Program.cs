using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WorkingWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {


            Dummy dummy = new Dummy(20, true);
            WriteData(dummy);
            ReadData();
            

            Console.ReadKey();
        }
        static void WriteData(Dummy dummy)
        {
            // создаем каталог для файла
            string path = @"C:\Users\Gentl\Desktop\DataDir";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream filestream = new FileStream(@"C:\Users\Gentl\Desktop\DataDir\Data.dat", FileMode.Create, FileAccess.Write);
            formatter.Serialize(filestream, dummy);
            filestream.Close();
        }
        static void ReadData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream filestream = new FileStream(@"C:\Users\Gentl\Desktop\DataDir\Data.dat", FileMode.Open, FileAccess.Read);
            Dummy dummy = (Dummy)formatter.Deserialize(filestream);
            filestream.Close();
            Console.WriteLine(dummy.Number.ToString(), dummy.Booler.ToString());
        }

        [Serializable]
        class Dummy
        {
           public float Number;
           public bool Booler;
            public Dummy(float number,bool booler)
            {
                Number = number;
                Booler = booler;
            }
        }
    }
}
