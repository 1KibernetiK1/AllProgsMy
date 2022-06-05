using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfInheritense
{
    public class TextBoxWithPlaceHolder : TextBox
    {
        private string _placeholder;

        public string PlaceHolder { get => _placeholder; set
            {
                _placeholder = value;
                this.Text = _placeholder;
                this.Foreground = Brushes.Gray;
            }
        }

        public TextBoxWithPlaceHolder()
        {
           
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (string.IsNullOrEmpty(Text))
            {
                this.Text = _placeholder;
                this.Foreground = Brushes.Gray;
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (Text == _placeholder)
            {
                this.Text = string.Empty;
                this.Foreground = Brushes.Black;
            }
           
        }
    }
}
