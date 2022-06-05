using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStrategyClassic
{
    public class Xerox : Printer
    {
        public override void Description()
        {
            Console.WriteLine("Это Xerox");
        }

        public override void Copy()
        {
            Console.WriteLine("Копирование");
            base.Print();
        }
    }
}
