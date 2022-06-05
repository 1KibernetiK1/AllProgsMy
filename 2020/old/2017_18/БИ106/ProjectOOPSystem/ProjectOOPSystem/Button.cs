using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOPSystem
{
    public class Button : Control
    {
        public override void Draw()
        {
            base.Draw();
            Console.SetCursorPosition(_x+_delta.X, 
                                      _y+_delta.Y);
            Console.ForegroundColor =
                _textColor;
            Console.Write("["+CutText(_text)+"]");
        }
    }
}
