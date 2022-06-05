using ProjectConsoleCommand.PatternCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsoleCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демка Команда - 'Вакуум'");

            //var receiver = new Receiver();

            var command = new CommandConcrete(new Receiver());
            var Button = new invoker(command);

            Console.WriteLine("Нажмите кнопку Enter");
            Console.ReadLine();
            Button.Click();
            Console.ReadLine();
        }
    }
}
