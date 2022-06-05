using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //singleton s1 = new singleton();

            singleton s1 = singleton.GetInstance();
            singleton s2 = singleton.GetInstance();
            singleton s3 = singleton.GetInstance();

           /* s1.Name = "Вася";
            Console.WriteLine(s2.Name);*/
        }
    }
}
