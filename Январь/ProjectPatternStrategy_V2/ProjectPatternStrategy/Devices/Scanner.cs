using ProjectPatternStrategy.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatternStrategy.Devices
{
    public class Scanner: UniversalDevice
    {
        public void Scan()
        {
            scanable = new SupportScan();
        }
    }
}
