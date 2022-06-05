using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo01Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создадим класс с самым простым алгоритмом
            int q = 5, r = 7;
            Console.WriteLine("q={0} r={1}", q, r);
            Console.WriteLine("ОБМЕН");
            // Alg alg = new Alg();
            Alg.Swap(ref q, ref r);
            Console.WriteLine("q={0} r={1}", q, r);
            //--------------------------------------
            string sq = "5", sr = "7";
            Console.WriteLine("строки");
            Console.WriteLine("sq={0} sr={1}", sq, sr);
            Console.WriteLine("ОБМЕН");
            Alg.Swap(ref sq, ref sr);
            Console.WriteLine("sq={0} sr={1}", sq, sr);

            Console.ReadLine();

        }
    }
}
