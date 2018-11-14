using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace TCPServer
{
    class Program
    {
        const int BUFFER_SIZE = 1024;

        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static string path = System.Configuration.ConfigurationManager.AppSettings["rootPath"];
        //static string path = "C://Users//Admin//Desktop//ProgEng//lab03//TCPServer//Root";

        static void Main(string[] args)
        {
            //socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1408));
            socket.Bind(new IPEndPoint(IPAddress.Any, 1408));
            while(true)
            {
                socket.Listen(5);
                Socket client = socket.Accept();
                Console.WriteLine("New connect spotted");
                Console.WriteLine(client.RemoteEndPoint);
                byte[] buffer = new byte[BUFFER_SIZE];
                int bufferSize = client.Receive(buffer); // кол-во символов отправленных клиентом
                string decodeString = "";
                if (bufferSize != BUFFER_SIZE)
                {
                    for (int i = 0; i < bufferSize; i++)
                    {
                        decodeString += Convert.ToChar(buffer[i]);
                    }
                }
                else
                {
                    decodeString = Encoding.ASCII.GetString(buffer);
                }
                Console.WriteLine(decodeString);
                switch(decodeString)
                {
                    case "/ls":
                        if (Directory.Exists(path))
                        {
                            Console.WriteLine("Подкаталоги:");
                            string[] dirs = Directory.GetDirectories(path);
                            foreach (string s in dirs)
                            {
                                Console.WriteLine(s);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Файлы:");
                            string[] files = Directory.GetFiles(path);
                            foreach (string s in files)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Client message: {0}", decodeString);
                        break;
                }
            }
        }
    }
}