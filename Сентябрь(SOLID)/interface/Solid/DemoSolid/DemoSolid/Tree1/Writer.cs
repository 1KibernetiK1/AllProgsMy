using DemoSolid.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSolid.Tree1
{
    public class Writer : Human, IPrintable
    {
        public void Print()
        {
            Console.WriteLine("писатель печатает роман...");
        }

        public override void Work()
        {

        }
    }
}
