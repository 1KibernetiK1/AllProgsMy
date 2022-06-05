using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOPSystem
{
    public class Window : Control
    {
        protected ArrayList _controls;

        public Window():base()
        {
            _text = "Window";
            _controls = new ArrayList();
        }

        public override void Draw()
        {
            base.Draw();
            Console.ForegroundColor =
                ConsoleColor.White;
            for (int i = Left; i <= Right; i++)
            {
                Console.SetCursorPosition(i, Top);
                Console.Write("═");//205
                Console.SetCursorPosition(i, Bottom);
                Console.Write("═");//205
            }
            for (int i = Top; i <= Bottom; i++)
            {
                Console.SetCursorPosition(Left, i);
                Console.Write("║");//186
                Console.SetCursorPosition(Right, i);
                Console.Write("║");//186
            }
            Console.SetCursorPosition(Left, Top);
            Console.Write("╔"); // 201
            Console.SetCursorPosition(Right, Top);
            Console.Write("╗"); // 187
            Console.SetCursorPosition(Left, Bottom);
            Console.Write("╚"); // 200
            Console.SetCursorPosition(Right, Bottom);
            Console.Write("╝"); // 188
            //------------------------
            Console.SetCursorPosition(Left+1, Top);
            Console.Write("["+CutText(_text)+"]");
            // рисуем все элементы управления
            for (int i = 0; i < _controls.Count; i++)
            {
                Control c = (Control) _controls[i];
                c.Draw();
            }
        }

        public void Add(Control c)
        {
            _controls.Add(c);
            c.Parent = this;
            c._delta = new Point(_x, _y);
        }
    }
}
