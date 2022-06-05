using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatternStrategy.Behavior
{
    public class SupportPrint : Iprintable
    {
        public void Print()
        {
            Console.WriteLine("Печать документов");
        }
    }
}
