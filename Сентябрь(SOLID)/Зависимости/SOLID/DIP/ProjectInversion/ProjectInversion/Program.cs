using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демо инверсия зависимости");
            Console.WriteLine("Система управления освещения");

            new MainSysstem(new TV()).Run();


            // слой бизнес логики 
            //Button btn = new Button(new Lamp()); // создается кнопка



           /* while (true)
            {
                Console.ReadKey();
                btn.Click();
            }*/

            Console.ReadLine();
        }
    }
}
