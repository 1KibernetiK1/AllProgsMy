using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsoleMenu
{
    class Program
    {

        static void DrawMenu(int x, int y, string[] m, int number)
        {
            for(int i=0; i<m.Length; i++)
            {
                if (i == number)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                } else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(x, y+i);
                Console.Write(m[i]);
            }
        }

        static int Select(int x, int y, string[]m)
        {
            int current = 0; // номер текущий элемент
            while (true) // бесконечный цикл выбора
            {
                // рисуем меню, подкрашиваем текущий
                DrawMenu(x,y,m,current);
                // ожидаем нажатие клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                // проверить какая кнопка
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        current--;
                        break;
                    case ConsoleKey.DownArrow:
                        current++;
                        break;
                    case ConsoleKey.Enter:
                        return current;
                }
            }
        }


        // в этом массиве будем запоминать номера выбора
        static int[] choice = { -1, -1, -1, -1, -1 };


        static void Main(string[] args)
        {
            while (true)
            {
                
            }


            Console.ReadLine();
        }
    }
}
