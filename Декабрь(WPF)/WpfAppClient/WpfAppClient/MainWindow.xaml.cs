using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Client");
                var client = new TcpClient();

                Console.WriteLine("Please, press enter to connect");
                Console.ReadLine();

                client.Connect("localhost", 8000);
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

            public class Guest
            {
                public bool IsOnline { get; set; }

                public string UserName { get; set; }
                private TcpClient _tcp;
                private NetworkStream _stream;
                private StreamWriter _sw;
                private StreamReader _sr;
                private Thread _threadMessages;

                public Guest(TcpClient tcp)
                {
                    _tcp = tcp;
                    _stream = tcp.GetStream();
                    _sw = new StreamWriter(_stream);
                    _sr = new StreamReader(_stream);
                    _threadMessages = new Thread(WaitingIncMes);
                }

                public void SendMessage(string message)
                {
                    if (!IsOnline)
                    {
                        Console.WriteLine($"Client {UserName} is offline");
                        return;
                    }

                    _sw.WriteLine(message);
                    _sw.Flush();
                }

                public void RunService()
                {
                    IsOnline = true;
                    _threadMessages.Start();
                }

                private void WaitingIncMes()
                {

                    string message = null;
                    while (IsOnline)
                    {

                        try
                        {
                            message = _sr.ReadLine();
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error: " + ex.Message);
                            IsOnline = false;
                            break;
                        }

                        if (!string.IsNullOrEmpty(message))
                        {
                            Console.WriteLine($"recieve message: '{message}'");
                        }

                    }
                }
            }
        }
    }
}
