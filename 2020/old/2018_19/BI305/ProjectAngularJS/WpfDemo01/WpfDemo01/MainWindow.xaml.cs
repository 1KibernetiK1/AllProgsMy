using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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

namespace WpfDemo01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow :
        Window, INotifyPropertyChanged
    {
        private string _name;
        public string UserName
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("UserName");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            panel.DataContext = this;
        }

        private void BtnReadyClick(object sender, RoutedEventArgs e)
        {
            UserName = textBox.Text.ToUpper()+"!";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
