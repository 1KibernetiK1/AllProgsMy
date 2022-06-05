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

namespace ProjectServerWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Server _server; 
        public MainWindow()
        {
            InitializeComponent();
            textBoxIP.Text = "192.168.2.143";
            
            _server = new Server();
            _server.UserJoin += UserJoin;
            _server.UserMessage += UserMessage;
        }

        private void UserMessage(string arg1, string arg2)
        {
            string msg = arg1+": " + arg2;
            Dispatcher.BeginInvoke((Action)(() => listBoxChat.Items.Add(msg)));
        }

        private void UserJoin(string name)
        {
            // безопасный доступ к интерфейсу
            Dispatcher.BeginInvoke((Action)(() => listBoxUsers.Items.Add(name)));
        }

        private void BtnStartClick(object sender, RoutedEventArgs e)
        {
            Server.IP = IPAddress.Parse(textBoxIP.Text);
            Server.Port = 8000;
            _server.Start();
            btnStart.IsEnabled = false;
        }
    }
}
