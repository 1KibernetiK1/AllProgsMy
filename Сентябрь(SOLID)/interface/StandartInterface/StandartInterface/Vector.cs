using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartInterface
{
    public class Vector : IComparable
    {
        protected int _x;
        protected int _y;

        public override string ToString()
        {
            return string.Format("({0}; {1})", _x, _y);
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(_x * _x + _y * _y);
            }
        }

        private int AgeCompareTo()
        {

        }

        public int CompareTo(object obj)
        {
            double len1 = this.Length;
            Vector v2 = (Vector)obj;
            double len2 = v2.Length;

            if (len1 == len2) return 0;
            if (len1 < len2) return -1;

            return 1;
        }

        public Vector()
        { }

        public Vector(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
