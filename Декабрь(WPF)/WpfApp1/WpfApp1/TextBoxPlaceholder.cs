using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    class TextBoxPlaceholder : TextBox
    {
        private string _placeholder;
        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                Text = _placeholder;
                Foreground = Brushes.Gray;
            }
        }

        public TextBoxPlaceholder()
        {
            
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if(string.IsNullOrEmpty(Text))
            {
                this.Text = _placeholder;
                this.Foreground = Brushes.Gray;
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if(Text == _placeholder)
            {
                Text = string.Empty;
                Foreground = Brushes.Black;
            }
        }
    }
}
