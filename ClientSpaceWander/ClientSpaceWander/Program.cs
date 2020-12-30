using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Newtonsoft.Json;

namespace ClientSpaceWander
{
    class Program
    {
        static int port = 14880;
        static string adress = "195.133.196.5";

        struct User
        {
            public int Id  { get; set; }
            public string Name { get; set; }
            public int Score { get; set; }

        }


        static void Main(string[] args)
        {
            User user = new User { Id = 0, Name = "", Score = 0 };
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(adress), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);

                //READ MIND OF PHONE
                if (user.Name == "")
                {
                    for (; ; )
                    {
                        Console.WriteLine("Привет как тебя зовут?: ");
                        user.Name = Console.ReadLine();
                        if (user.Name.Length < 3)
                        {
                            Console.WriteLine("Имя должно быть больше 3");
                            continue;
                        }
                        Console.WriteLine("Сколько очков ты набрал?: ");
                        user.Score = Convert.ToInt32(Console.ReadLine());

                        break;
                    }
                }
                //формирую и отправляю данные
                var json = JsonConvert.SerializeObject(user);
                
                byte[] data = new byte[1024];
                data = Encoding.UTF8.GetBytes(json);
                //DEBUG
               // Console.WriteLine(user.Name);
                //Console.WriteLine(data);
                //Console.WriteLine(json_message);
                //DEBUG
                socket.Send(data);
                Console.WriteLine("Ожидаем ответа...");
                //принимаем данные
                data = new byte[256];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.UTF8.GetString(data, 0, bytes));

                }
                while (socket.Available > 0);
                Console.WriteLine(builder);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Отсутствует подключение к серверу");
            }
        }
        public void queryTable()
        {
            User user = new User { Id = 0, Name = "x", Score = 281330800 };
            
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(adress), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);

                //формирую и отправляю данные
                string json_message = JsonConvert.SerializeObject(user);
                byte[] data = new byte[1024];
                data= Encoding.UTF8.GetBytes(json_message);
                socket.Send(data);
                Console.WriteLine("Ожидаем ответа...");
                //принимаем данные
                
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.UTF8.GetString(data, 0, bytes));

                }
                while (socket.Available > 0);
                User[] table = { };
                table= (User[])JsonConvert.DeserializeObject(builder.ToString());
                Console.WriteLine(table);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        } 
    }

}
