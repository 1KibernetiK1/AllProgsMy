using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача Знак Зодиака");
            //------------------------------
            #region Здесь ввод данных
            Console.Write("Введите номер месяца > ");
            string st = Console.ReadLine();
            int month = Convert.ToInt32(st);
            //------------------------------
            Console.Write("Введите день > ");
            st = Console.ReadLine();
            int day = Convert.ToInt32(st);
            //----------------------------
            #endregion
            string nameMonth = "";
            #region Здесь определяем месяц
            if (month == 1)
                nameMonth = "январь";
            else if (month == 2)
                nameMonth = "февраль";
            else if (month == 3)
                nameMonth = "март";
            else if (month == 4)
                nameMonth = "апрель";
            else if (month == 5)
                nameMonth = "май";
            else if (month == 6)
                nameMonth = "июнь";
            else if (month == 7)
                nameMonth = "июль";
            else if (month == 8)
                nameMonth = "август";
            else if (month == 9)
                nameMonth = "сентябрь";
            else if (month == 10)
                nameMonth = "октябрь";
            else if (month == 11)
                nameMonth = "ноябрь";
            else if (month == 12)
                nameMonth = "декабрь";
            #endregion
            Console.WriteLine(nameMonth);
            string zodiac = "";
            if (month == 1)
            {
                if (day <= 19)
                    zodiac = "Козерог";
                else zodiac = "Водолей";
            }
            else if (month == 2)
            {
                if (day <= 18)
                    zodiac = "Водолей";
                else zodiac = "Рыбы";
            }
            else if (month == 3)
            {
                if (day <= 20)
                    zodiac = "Рыбы";
                else zodiac = "Овен";
            }
        }
    }
}
