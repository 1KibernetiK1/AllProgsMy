using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfAdd
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static RoutedEventHandler[] methods;

        private int counter = 1;

        public MainWindow()
        {
            InitializeComponent();
            methods = new RoutedEventHandler[2];
            methods[0] = Btn_Click1;
            methods[1] = Btn_Click2;
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            var btn = new Button()
            {
                Content = "Новая кнопка" + counter,
                Margin = new Thickness(10),
                Width = 200,
                Tag = counter
            };
            btn.Click += Btn_Click1;
            stackPanel1.Children.Add(btn);
            counter++;
        }

        private void Btn_Click1(object sender, RoutedEventArgs e)
        {
            int index = (int)((Button)sender).Tag;
            switch (index)
            {
                case 1: MessageBox.Show("btn 1"); break;
                case 2: MessageBox.Show("btn 2"); break;
            }
            MessageBox.Show("button click");
        }


        private void Btn_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button click");
        }
    }
}
