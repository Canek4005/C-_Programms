using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace BasicServer_Client_test
{
    class Server
    {
        static int port = 4545; // порт для приема входящих запросов
        
        static void Main(string[] args)
        {
            //получаем адрес запуска сервера
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            //создаем сокет
            Socket listenSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //связываем сокет с локальной точкой, по которой будем принимать данные
                listenSoket.Bind(ipPoint);
                //начинаем прослушивание (запускаем сервер)
                listenSoket.Listen(10);

                Console.WriteLine("Server is listening...");

                while (true)
                {
                    Socket handler = listenSoket.Accept();
                    //получение сообщения
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;//количество полученных байтов
                    byte[] data = new byte[256];//Буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());
                    //отправляем ответ
                    string message = "Сообщение доставлено";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    //закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
