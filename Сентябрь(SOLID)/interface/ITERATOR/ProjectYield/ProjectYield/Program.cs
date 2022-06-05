using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYield
{
    class Program
    {
        static IEnumerable<string> EnumerateDays()
        {
            yield return "Понедельник";
            yield return "Вторник";
            yield return "Среда";
            yield return "Четверг";
            yield return "Пятница";
            yield return "Суббота";
            yield return "Воскресение";
        }

        static IEnumerable<string> EnumerateDays2()
        {
            string[] days = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресение" };

            for (int i = 0; i < days.Length; i++)
            {
                if (i == 3) yield break; // Прерываем работу итератора        
                yield return days[i];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("yield\n");
            foreach (var item in EnumerateDays2())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
