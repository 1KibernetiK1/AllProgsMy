using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace ConsoleProjectServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server");
            var server = new TcpListener(IPAddress.Any, 8000);
            Console.Write("Please press enter to start server...");
            Console.ReadLine();
            server.Start();
            Console.Write("Server started succesfull!");
            Console.Write("\nWaiting incoming connection...");

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine($"\nClient '{client.Client.RemoteEndPoint}' connected!");

            NetworkStream stream = client.GetStream();
            StreamReader sr = new StreamReader(stream);

            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine($"recieve message: '{message}'");
            }
         
            Console.ReadLine();
        }
    }
}
