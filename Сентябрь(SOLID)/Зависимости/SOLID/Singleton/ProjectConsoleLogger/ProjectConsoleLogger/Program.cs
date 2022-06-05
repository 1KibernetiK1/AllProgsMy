using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectConsoleLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.instance.Add("обработка данных...");
            Thread.Sleep(800); 
            Logger.instance.Add("обработка завершена");
            Console.WriteLine("Готово"); 
            Console.ReadLine();
        }
    }
}
