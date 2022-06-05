using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature2
{
    public class Vector
    {
        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Vector(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Vector() { }
    }

}
