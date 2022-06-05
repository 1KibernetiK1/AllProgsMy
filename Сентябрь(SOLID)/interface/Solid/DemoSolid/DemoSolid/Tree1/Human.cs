using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSolid.Tree1
{
    public abstract class Human
    {
        protected int _age;
        protected string _name;

        public Human()
        {
            _age = 10;
            _name = "Иван";
        }

        public abstract void Work();
    }
}
