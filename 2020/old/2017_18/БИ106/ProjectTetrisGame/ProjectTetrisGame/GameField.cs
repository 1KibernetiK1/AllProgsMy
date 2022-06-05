using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTetrisGame
{
    public class GameField : GameObject
    {
        public GameField(int x, int y, 
                         int w, int h)
            :base(x,y,w,h)
        {
        }

        public override void Draw()
        {
            for (int i = _y; i <= _y + _h; i++)
            {
                Console.SetCursorPosition(_x, i);
                Console.Write("█"); // 219
                Console.SetCursorPosition(_x + _w, i);
                Console.Write("█"); // 219
            }
            for (int i = _x; i < _x + _w; i++)
            {
                Console.SetCursorPosition(i, _y);
                Console.Write("█"); // 219
                Console.SetCursorPosition(i, _y + _h);
                Console.Write("█"); // 219
            }
        }
    }
}
