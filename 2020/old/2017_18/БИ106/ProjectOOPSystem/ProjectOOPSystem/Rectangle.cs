using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOPSystem
{
    public class Rectangle
    {
        // координаты, ширина, высота
        protected int _x;

        public int Left
        {
            get { return _x; }
            set { _x = value; }
        }

        protected int _y;

        public int Top
        {
            get { return _y; }
            set { _y = value; }
        }


        protected int _w;

        public int Width
        {
            get { return _w; }
            set { _w = value; }
        }

        protected int _h;

        public int Height
        {
            get { return _h; }
            set { _h = value; }
        }

        public int Right
        {
            get
            {
                return _x + _w;
            }
        }

        public int Bottom
        {
            get
            {
                return _y + _h;
            }
        }

    }
}
