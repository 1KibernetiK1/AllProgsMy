using DemoSolid.Abstract;
using DemoSolid.Tree1;
using DemoSolid.Tree2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSolid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демо Интерфейсы");
            Writer writer = new Writer();
            Printer printer = new Printer();
            writer.Print();
            printer.Print();

            // Попробуем универсальный алгоритм
            object[] subject = { writer, printer };

            for (int i = 0; i < subject.Length; i++)
            {
                //1)//subject[i].Print();
                //2)Printer pr = (Printer) subject[i];
                //pr.Print();
                /*3)*/ /* if (subject[i] is Printer)
                        {
                        Printer pr = (Printer)subject[i];
                        pr.Print();
                        }
                if (subject[i] is Writer)
                {
                    Writer wr = (Writer)subject[i];
                    wr.Print();
                }*/

                //4) Через интерфейсы
                Console.WriteLine("Вариант через интерфейс");
                IPrintable[] printers = { printer, writer };
                foreach (IPrintable item in printers)
                {
                    item.Print();
                }

            }


            Console.ReadLine();
        }
    }
}
