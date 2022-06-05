using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatternStrategy.Devices
{
    public class Xerox : UniversalDevice, Iprintable, ICopyable
    {
        public void Copy()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
