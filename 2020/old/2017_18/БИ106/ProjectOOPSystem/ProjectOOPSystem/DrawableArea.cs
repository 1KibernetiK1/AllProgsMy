using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOPSystem
{
    public class DrawableArea
        : Rectangle
    {
        public Point _delta = new Point(0,0);

        private ConsoleColor _backColor;

        public ConsoleColor BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        virtual public void Draw()
        {
            Console.BackgroundColor = _backColor;
            for (int i = Top; i <= Bottom; i++)
            {
                for (int j = Left; j <= Right; j++)
                {
                    Console.SetCursorPosition(j+_delta.X,
                                              i+_delta.Y);
                    Console.Write(" ");
                }
            }
        }

        public DrawableArea()
        {
            _x = 1; _y = 1;
            _w = 6; _h = 4;
            _backColor = ConsoleColor.Blue;
        }

        public DrawableArea(int x, int y, int w, int h)
        {
            _x = x;
            _y = y;
            _w = w;
            _h = h;
            _backColor = ConsoleColor.Blue;
        }

    }
}
