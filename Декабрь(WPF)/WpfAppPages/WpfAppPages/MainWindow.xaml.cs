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

namespace WpfAppPages
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

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();
            // $"" - Интерполяция строк (C# 4.0)
            string pageName = $"Page{tag}.xaml";
            //pageName = string.Format("Page{0}.xaml", tag);
            var uri = new Uri("Pages/"+pageName, UriKind.Relative);
            mainFrame.Navigate(uri);
        }
    }
}
