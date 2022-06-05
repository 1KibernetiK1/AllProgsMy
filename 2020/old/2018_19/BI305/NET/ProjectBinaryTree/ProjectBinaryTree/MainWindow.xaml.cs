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
using ProjectBinaryTree.DAL;
using ProjectBinaryTree.Domains;
using ProjectBinaryTree.Tree;

namespace ProjectBinaryTree
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

        private void BtnClickSave(object sender, RoutedEventArgs e)
        {
            FileStorage.SaveList(Customer.GetGustomers());
            MessageBox.Show("OK!");
        }

        private void BtnClickLoad(object sender, RoutedEventArgs e)
        {
            FileStorage.OpenFile();
            while (true)
            {
                var c = FileStorage.NextCustomer(out long index);
                if (c == null) break;
                listBox.Items.Add(c.ToString());
            }
        }

        private void BtnClickBuild(object sender, RoutedEventArgs e)
        {
            var tree = new BinaryTree<string>();
            FileStorage.OpenFile();
            while(true)
            {
                var c = FileStorage.NextCustomer(out long index);
                if (c == null) break;
                tree.AddNode(c.LastName, index);
            }
            tree.Save();
            MessageBox.Show("Done");
        }
    }
}
