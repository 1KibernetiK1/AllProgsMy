using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTetrisGame
{
    abstract public class GameObject
    {
        protected int[,] _body;

        protected int _x;
        protected int _y;
        protected int _w;
        protected int _h;

        public int Left
        {
            get { return _x; }
        }

        public int Right
        {
            get { return _x + _w; }
        }

        public int Bottom
        {
            get { return _y + _h; }
        }

        abstract public void Draw();

        public GameObject(int x, int y,
                          int w, int h)
        {
            _x = x; _y = y;
            _w = w; _h = h;
            _body = new int[_h, _w];
        }
    }
}
