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

namespace WpfApp1
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

        private void BtnPrintClick(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            fd.PageHeight = pd.PrintableAreaHeight;
            fd.PageWidth = pd.PrintableAreaWidth;
            fd.PagePadding = new Thickness(50);
            fd.ColumnGap = 0;
            fd.ColumnWidth = pd.PrintableAreaWidth;

            IDocumentPaginatorSource dps = fd;
            pd.PrintDocument(dps.DocumentPaginator, "flow doc");
        }
    }
}
