using ProjectPatternStrategy.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatternStrategy
{
    public class UniversalDevice
    {
        // Description, Plug
        protected Iprintable printable = new NotSupportPrint();

        protected Iscanable scanable = new NotSupportScan();
    }
}
