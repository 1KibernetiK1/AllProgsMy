using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemoInheritance
{
    public class Student : Human
    {
        protected string _inst;

        public Student() : base()
        {
            _inst = "нет института";
        }

        public Student(string name, int age, string inst)
            :base(name, age)
        {
            _inst = inst;
            /* _name = name;
            _age = age;*/
        }

        // здесь происходит "скрытие"
        // наследуемого метода
        // - РАНЕЕ СВЯЗЫВНИЕ!!!
        new public void ShowInfo()
        {
            Console.WriteLine("Студент имя {0} возраст {1} институт {2}",
                              _name, _age, _inst);
        }
    }
}
