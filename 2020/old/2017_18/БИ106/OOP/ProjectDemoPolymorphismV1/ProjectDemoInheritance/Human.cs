using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemoInheritance
{
    public class Human
    {
        protected string _name;
        protected int _age;

        public Human()
        {
            _name = "Аноним";
            _age = 0;
        }

        public Human(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Человек имя {0} возраст {1}",
                              _name, _age);
        }
    }
}
 