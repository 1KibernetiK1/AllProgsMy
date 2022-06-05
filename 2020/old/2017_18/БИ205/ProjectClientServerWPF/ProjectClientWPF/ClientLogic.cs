using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows;

namespace ProjectClientWPF
{
    class ClientLogic
    {
        public event Action<string> ReceiveMessage;
        public event Action<string[]> GetChatUsersList;
        static public IPAddress IPServer;
        static public int Port;
        private TcpClient _client;
        private string _name;
        private NetworkStream _stream;
        private StreamReader _sr;
        private StreamWriter _sw;
        private Thread _thWaitMessages;
        public void SendMessage(string text)
        {
            try
            {
                _sw.WriteLine(text);
                _sw.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public ClientLogic()
        {
            _client = new TcpClient();
            _thWaitMessages = new Thread(WaitMessage);
            
        }
        public void Connect(string name)
        {
            try
            {
                _client.Connect(IPServer, Port);
                _name = name;
                _stream = _client.GetStream();
                _sr = new StreamReader(_stream);
                _sw = new StreamWriter(_stream);
                Login();
            }
            catch (Exception ex)
            {
            }
        }

        private void Login()
        {
            try
            {
                _sw.WriteLine(_name);
                _sw.Flush();
                _thWaitMessages.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void WaitMessage()
        {
            while (true)
            {
               string msg= _sr.ReadLine();
               if (string.IsNullOrEmpty(msg)) continue;
                ProccessingMessage(msg);
            }
        }

        private void ProccessingMessage(string data)
        {
            // используем протокол
            string[] parts= data.Split('|');
            if (parts[0]=="srv")
            {
                switch (parts[1])
                {
                    case "listUsers":
                        string st = parts[2];
                        var list = st.Split(',');
                        GetChatUsersList?.Invoke(list);
                        break;
                    case "userLeave":
                        break;
                    case "serverOff":
                        break;
                    case "userJoin":
                        break;
                }
            }
            if (parts[0]=="usr")
            {
                string name = parts[1];
                string msg = parts[2];
            }
        }
    }
}
