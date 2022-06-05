using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemoInheritance
{
    // ПРимер Полиморфизма
    // 1) ранее связывание
    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human();
            Student s1 = new Student();
            h1.ShowInfo();
            s1.ShowInfo();
            Console.ReadLine();
        }
    }
}
