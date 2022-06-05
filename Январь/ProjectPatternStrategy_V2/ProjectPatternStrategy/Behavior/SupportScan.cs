using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatternStrategy.Behavior
{
    public class SupportScan : Iscanable
    {
        public void scan()
        {
            Console.WriteLine("Скан есть");
        }
    }
}
