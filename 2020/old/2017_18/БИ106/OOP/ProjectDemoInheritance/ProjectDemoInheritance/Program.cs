using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemoInheritance
{
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
