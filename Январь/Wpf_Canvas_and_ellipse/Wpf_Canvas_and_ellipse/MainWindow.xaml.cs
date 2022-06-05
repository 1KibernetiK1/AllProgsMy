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

namespace Wpf_Canvas_and_ellipse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Ellipse ellipse;
        private Vector pos;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSystem();

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            pos.X++;
            pos.Y++;
            Canvas.SetLeft(ellipse, pos.X);
            Canvas.SetTop(ellipse, pos.Y);
        }

        private void InitializeSystem()
        {
            pos = new Vector(300, 150);

            ellipse = new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.Yellow),
                Stroke = new SolidColorBrush(Colors.Red),
                Width = 50,
                Height = 50
            };

            Canvas.SetLeft(ellipse, pos.X);
            Canvas.SetTop(ellipse, pos.Y);

            myCanvas.Children.Add(ellipse);
        }
    }
}

