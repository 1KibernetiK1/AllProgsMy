using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStrategyClassic
{
    public class Printer : UniversalDriverDevice
    {
        // обязательная
        public override void Description()
        {
            Console.WriteLine("Это принтер HP");
        }

        public override void Plug()
        {
            Console.WriteLine("Готов к работе");
        }

        // Необязательное

        public override void Print()
        {
            Console.WriteLine("Печатаем документ");
        }
    }
}
