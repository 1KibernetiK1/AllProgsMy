using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStrategyClassic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Система классов офисной техники");

            var printer = new Printer();
            printer.Description();
            printer.Plug();
            printer.Print();

            var scanner = new Scanner();
            scanner.Description();
            scanner.Plug();
            scanner.Scan();

            var xerox = new Xerox();
            xerox.Description();
            xerox.Plug();
            xerox.Copy();

            Console.ReadLine();
        }
    }
}
