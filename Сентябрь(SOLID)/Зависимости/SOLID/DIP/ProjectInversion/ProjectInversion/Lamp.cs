using ProjectInversion.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInversion
{
    public class Lamp : IStateSwitchable
    {
        public void SwitchOff()
        {
            Console.WriteLine("Лампа накаливания нагревается и светит");
        }

        public void SwitchOn()
        {
            Console.WriteLine("Лампа остывает и не светит");
        }
    }
}
