using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas1 = { 10, 20, 30, 40, 50 };
            string[] mas2 = { "a", "b", "c", "d", "e" };
            for (int i = 0; i < mas1.Length; i++)
            {
                //обработка
                int value = mas1[i] * 2;
                string st = mas2[i] + "!";
                // хотелось бы сохранить полученные результаты
                // C# 2.0
                Pair p = new Pair();
                p.Value = value;
                p.Text = st;

                // C# 3.0 создается объект анонимного класса
                var p2 = new { Number = value, Title = st };
            }
        }
    }

    // C# 2.0 - необходимо создать было классы
    public class Pair
    {
        // auto properties (C# 3.0)
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
