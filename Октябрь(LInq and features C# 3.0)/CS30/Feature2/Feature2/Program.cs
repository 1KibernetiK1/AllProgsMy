using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature2
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# 2.0
            Vector v1 = new Vector(0,0);
            v1.X = 15;
            v1.Y = 20;

            // C# 3.0 object initializer
            var v2 = new Vector { Y = 20 };
        }
    }
}
