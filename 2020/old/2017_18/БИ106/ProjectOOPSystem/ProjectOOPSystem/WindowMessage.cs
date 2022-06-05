using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOPSystem
{
    public class WindowMessage
        : Window
    {
        public WindowMessage()
        {
            Button b1 = new Button();
            b1.TextColor = ConsoleColor.White;
            b1.Text = "Ok";
            b1.Left = 2;
            b1.Top = 3;
            b1.Height = 1;
            b1.Width = 5;
            _controls.Add(b1);
            Button b2 = new Button();
            b2.TextColor = ConsoleColor.White;
            b2.Text = "Отмена";
            b2.Left = 10;
            b2.Top = 3;
            b2.Height = 1;
            b2.Width = 8;
            _controls.Add(b2);
        }
    }
}
