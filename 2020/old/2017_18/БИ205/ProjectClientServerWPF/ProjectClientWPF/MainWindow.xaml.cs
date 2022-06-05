using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

namespace ProjectClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ClientLogic _client;
        public MainWindow()
        {
            InitializeComponent();
            _client = new ClientLogic();
            _client.ReceiveMessage += ClientReceiveMessage;
            _client.GetChatUsersList += ClientGetChatUserList;
        }

        private void ClientGetChatUserList(string [] obj )
        {
            Dispatcher.Invoke((Action)(() => listBox.ItemsSource=obj));
        }

        private void ClientReceiveMessage(string msg)
        {
            Dispatcher.Invoke((Action)(()=>ForChat.Items.Add(msg)));
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            string st = textBoxIP.Text;
            var ip = IPAddress.Parse(st);
            st = textBoxPort.Text;
            int port = int.Parse(st);
            ClientLogic.IPServer = ip;
            ClientLogic.Port = port;
            string name = textBoxName.Text;
            _client.Connect(name);
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            string msg = textBoxMsg.Text;
            _client.SendMessage(msg);
        }
    }
}
