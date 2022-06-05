using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;


namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client");            
            var client = new TcpClient();

            Console.WriteLine("Please, press enter to connect");
            Console.ReadLine();

            client.Connect("localhost",8000);
            Console.WriteLine("Successfull connected!\r\n");

            NetworkStream stream = client.GetStream();
            StreamWriter sw = new StreamWriter(stream);

            while (true)
            {
                Console.Write("enter message > ");
                string message = Console.ReadLine();


                sw.WriteLine(message);
                sw.Flush();
                Console.WriteLine("was sent");
            }
 
            Console.ReadLine();
        }
    }
}
