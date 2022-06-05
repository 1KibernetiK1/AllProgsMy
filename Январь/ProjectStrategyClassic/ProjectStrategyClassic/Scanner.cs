using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStrategyClassic
{
    public class Scanner : UniversalDriverDevice
    {
        public override void Description()
        {
            Console.WriteLine("Это сканер");
        }

        public override void Plug()
        {
            Console.WriteLine("Готов к работе");
        }

        public override void Scan()
        {
            Console.WriteLine("Сканируем");
        }
    }
}
