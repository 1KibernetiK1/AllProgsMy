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
using System.Xml.Serialization;

namespace WpfDeserializationAndDataTemplate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Student> students;

        public MainWindow()
        {
            InitializeComponent();
            var xms = new XmlSerializer(typeof(List<Student>));
            using (var fs = File.OpenRead("students.xml"))
            {
                students = (List<Student>)xms.Deserialize(fs);
            }
            //listboxStud.DisplayMemberPath = "Name";
            listboxStud.ItemsSource = students;
        }
    }
}
