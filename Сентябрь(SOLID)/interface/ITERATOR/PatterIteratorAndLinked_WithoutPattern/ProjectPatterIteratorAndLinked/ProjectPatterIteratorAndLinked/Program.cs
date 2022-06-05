using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatterIteratorAndLinked
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Связанный список");
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(50);

            Console.WriteLine("Вывести все элементы на экран");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
