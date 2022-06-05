using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfDZ_Ellipse_state
{
    public class Widget
    {
        private readonly IState _state;

        public Widget(IState state)
        {
            _state = state;
        }

        public Grid UI()
        {
            return _state.UI();
        }
    }
}
