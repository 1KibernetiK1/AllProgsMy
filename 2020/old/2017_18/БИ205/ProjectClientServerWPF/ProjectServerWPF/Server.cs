using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows;

namespace ProjectServerWPF
{
    public class Server
    {
        public event Action<string> UserJoin;
        public event Action<string> UserLeaf;
        public event Action<string, string> UserMessage;
        static public string ListNameAu ="Список имён/";
        static public IPAddress IP;
        static public int Port;

        private TcpListener _listener;
        private Thread _threadWaitConnections;
        //словарь содержащих всех подключеных клиентов
        private Dictionary<string, ClientLogic> _clients;

        public Server()
        {
            
            _clients = new Dictionary<string, ClientLogic>();
             _threadWaitConnections = new Thread(WaitConnections);    
        }

        public void Start()
        {
            try
            {
                _listener = new TcpListener(IP, Port);
                _listener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _threadWaitConnections.Start();
        }

        private void WaitConnections()
        {
            while (true)
            {
                TcpClient tcpClient =
                    _listener.AcceptTcpClient();

                var client = new ClientLogic(tcpClient);

                client.Authorize += ClientAuthorize;
                client.IncomingMessage += ClientIncomingMessage;

                client.WaitAuthorize();
            }
        }

        public void SendMessageTo(string name,string msg)
        {
            string data = "usr|msg|"+msg;
            ClientLogic client = _clients[name];
            client.Send(data);
        }
        public void SendListClient(string name)
        {
            string msg = "";
            string [] names= _clients.Keys.ToArray();
            msg = string.Join(",", names);
            string data = "srv|listUsers|" + msg;
            ClientLogic client = _clients[name];
            client.Send(data);
        }
        private void ClientIncomingMessage(string name, string msg)
        {
            // сообщаем UI
            UserMessage?.Invoke(name, msg);

        }

        private void ClientAuthorize(string name, ClientLogic cl)
        {
            // клиента запоминаем
            _clients.Add(name, cl);
            //сообщаем UI
            UserJoin?.Invoke(name);
        }
    }
}
