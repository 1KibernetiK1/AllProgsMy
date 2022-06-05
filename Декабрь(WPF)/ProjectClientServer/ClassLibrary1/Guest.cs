using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace LibraryClientServer
{
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

        public void SendRegularPublicMessage(string text)
        {
            var protocolIte = new ProtocolmessageHeader
        }

        private void SendMessage(string rawMessage)
        {
            if (!IsOnline)
            {
                Console.WriteLine($"Client {UserName} is offline");
                return;
            }

            _sw.WriteLine(rawMessage);
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

                    Console.WriteLine($"Error for '{_tcp.Client.RemoteEndPoint}': " +ex.Message);
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
