using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Markup;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            string fname = "MyGrid.xaml";
            string path = AppDomain.CurrentDomain.BaseDirectory;

            fname = System.IO.Path.Combine(path, fname);

            using (var fs = File.Open(fname, FileMode.Open))
            {
                DependencyObject dobj = (DependencyObject) XamlReader.Load(fs);
                this.Content = dobj;
            }
        }
    }
}
