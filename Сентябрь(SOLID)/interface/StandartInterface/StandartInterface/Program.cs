using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartInterface
{
    class Program
    {
        static void Main(string[] args)
        {

            Vector[] vectors =
            {
                new Vector(3, 4),
                new Vector(1, 2),
                new Vector(4, 2),
                new Vector(7, 5)

            };

            foreach (var vector in vectors)
            {
                Console.WriteLine(vector);
            }


            Console.WriteLine("Сортировка векторов");

            // compare - сравнить  IComparable
            Array.Sort(vectors);

            foreach (var vector in vectors)
            {
                Console.WriteLine(vector);
            }

            Console.ReadLine();
        }
    }
}
