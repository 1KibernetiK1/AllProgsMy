using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using LibraryClientServer;

namespace ConsoleProjectServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server");
            var server = new TcpListener(IPAddress.Any, 8000);
            Console.WriteLine("Please press enter to start server...");
            Console.ReadLine();
            server.Start();
            Console.WriteLine("Server started succesfull!");
            Console.Write("\nWaiting incoming connection...");

            while (true)
            {
                TcpClient tcp = server.AcceptTcpClient();
                Console.WriteLine($"\nClient '{tcp.Client.RemoteEndPoint}' connected!");
                var guest = new Guest(tcp);
                guest.RunService();
            }
          
            Console.ReadLine();
        }
    }
}
