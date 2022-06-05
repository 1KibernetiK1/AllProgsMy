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

            server.AcceptTcpClient();
            Console.WriteLine("\nClient connected!");

            Console.ReadLine();
        }
    }
}
