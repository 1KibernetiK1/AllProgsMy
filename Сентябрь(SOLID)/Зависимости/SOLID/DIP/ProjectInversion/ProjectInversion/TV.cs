using ProjectInversion.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInversion
{
    public class TV : IStateSwitchable
    {
        public void SwitchOff()
        {
            Console.WriteLine("Телевидение - нет сигнала");
        }

        public void SwitchOn()
        {
            Console.WriteLine("Телевидение - есть сигнал");
        }
    }
}
