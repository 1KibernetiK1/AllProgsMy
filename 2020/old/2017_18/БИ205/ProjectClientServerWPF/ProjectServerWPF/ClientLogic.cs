using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows;

namespace ProjectServerWPF
{
    public class ClientLogic
    {
        // СОБЫТИЯ КЛИЕНТА
        public event Action<string, ClientLogic> Authorize;
        public event Action<string, string> IncomingMessage;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // IP -клиента
        private TcpClient _client;
        // нить для чтения сообщений клиента
        private Thread _threadRead;
        // сетевой поток для передачи данных
        private NetworkStream _stream;
        private StreamReader _sr;
        private StreamWriter _sw;

        public ClientLogic(TcpClient client)
        {
            _client = client;
            _stream = _client.GetStream();
            _sr = new StreamReader(_stream);
            _sw = new StreamWriter(_stream);
            _threadRead = new Thread(WaitMessages);
           _name = null;
        }

        public void WaitAuthorize()
        {
            _threadRead.Start();
        }

        public void WaitMessages()
        {
            while(true)
            {
                string msg = _sr.ReadLine();
                if (string.IsNullOrEmpty(msg))
                    continue;
                if (_name == null)
                { // самое первое сообщение от клиента - ИМЯ
                    _name = msg;
                    // вызов события - АВТОРИЗАЦИЯ
                    Authorize?.Invoke(_name, this);
                } else
                {
                    IncomingMessage?.Invoke(_name, msg);
                }
            }
        }

        public void Send(string data)
        {
            try
            {
                _sw.WriteLine(data);
                _sw.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                      
        }
    }
}
