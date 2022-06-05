using DemoSolid.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSolid.Tree2
{
    public class Printer : Device, IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Пинтер печатает документы");
        }

        public Printer()
        {
            _manufacture = "Samsung";
            _model = "SCX4000";
            _price = 6500;
        }

        public override void Connect()
        {
            Console.WriteLine("Принтер подключен через WIFI");
        }
    }
}
