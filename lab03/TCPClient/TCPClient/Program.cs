using System;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Console.WriteLine("Query: ");
            string message = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            socket.Connect("127.0.0.1", 1408);
            socket.Send(buffer);
            socket.Close();
            Console.WriteLine("Query was successful delivered to host. Press any key to exit.");
            Console.ReadKey();
        }
    }
}