using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = { 10, 20, 30, 40, 50, 60 };
            // новый метод
            mas.Print(); // .Print() - метод расширения массив

            // это синтакисческий сахар
            // На самом деле - синтаксис не красивый

            ArrayExtension.Print(mas);

         

            Console.ReadLine();
        }
    }
}
