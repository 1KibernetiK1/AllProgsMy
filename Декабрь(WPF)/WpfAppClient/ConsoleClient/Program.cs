using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;


namespace WpfAppClient
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

            var guest = new Guest(client);
            guest.RunService();

            while (true)
            {
                Console.Write("enter message > ");
                string message = Console.ReadLine();

                guest.SendMessage(message);
              
                Console.WriteLine("was sent");
            }
 
            Console.ReadLine();
        }
    }
}
