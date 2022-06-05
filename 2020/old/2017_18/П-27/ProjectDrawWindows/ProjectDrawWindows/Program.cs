using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDrawWindows
{
    class Program
    {
        static void DrawMenu(int MX, int MY, string[] menu, int active)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(MX, MY + i);
                Console.WriteLine(menu[i]);
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(MX, MY + active);
            Console.WriteLine(menu[active]);
        }

        static int Select(int MX, int MY, string[] menu)
        {
            Console.CursorVisible = false;
            int active = 0;
            bool IsWorking = true;
            while (IsWorking)
            {
                DrawMenu(MX, MY, menu, active);
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.Enter:
                        IsWorking = false;
                        break;
                    case ConsoleKey.UpArrow:
                        if (active > 0)
                            active--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (active < menu.Length - 1)
                            active++;
                        break;
                }
            }
            Console.CursorVisible = true;
            return active;
        }

        static void DrawFrame(int x, int y, int w, int h)
        {
            // 218 ┌
            // 191 ┐
            // 192 └
            // 217 ┘
            // 179  │
            // 196 ─
            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌");
            Console.SetCursorPosition(x+w, y);
            Console.WriteLine("┐");
            Console.SetCursorPosition(x, y+h);
            Console.WriteLine("└");
            Console.SetCursorPosition(x + w, y+h);
            Console.WriteLine("┘");
            for (int i = 1; i < w; i++)
            {
                Console.SetCursorPosition(x+i,y);
                Console.Write("─");
                Console.SetCursorPosition(x + i, y+h);
                Console.Write("─");
            }
            for (int i = 1; i < h; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("│");
                for (int j = 1; j < w; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x+w, y + i);
                Console.Write("│");
            }
        }

        static void Main(string[] args)
        {
            string[] menu =
                { "первое", "второе", "третье", "касса"};
            string[] first = {"борщ", "солянка", "отказаться" };
            int[] first_price = { 30, 45 };
            string[] second = { "пюре","гречка","рис", "отказаться" };
            int[] second_price = {25, 20, 15 };
            string[] third = { "чай","компот", "отказаться" };
            int[] third_price = {10, 15 };
            //---------------------------------
            string [][] dishes = { first, second, third };
            int[][] prices = { first_price, second_price, third_price };

            int[] numbersChoice = { -1, -1, -1 };

            while (true)
            {
                Console.SetCursorPosition(1,1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Вы выбрали: ");
                for (int i = 0; i < 3; i++)
                {
                    int c = numbersChoice[i];
                    if (c > -1)
                        Console.Write("{0}, ", dishes[i][c]);
                }
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                DrawFrame(9, 4, 7, 5);
                int n = Select(10, 5, menu);
                if (n == 3) break; // касса
                // достаём цены и блюда
                string[] dish = dishes[n];
                int[] price = prices[n];
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                DrawFrame(9, 4, 15, 6);
                int m = Select(10,5,dish);
                // запоминаем наш выбор!
                if (m == dish.Length - 1)
                    numbersChoice[n] = -1;
                else numbersChoice[n] = m;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            DrawFrame(5, 5, 25, 5);
            Console.SetCursorPosition(7, 5);
            Console.WriteLine("ЧЕК");
            int summa = 0;
            for (int i = 0; i < 3; i++)
            {
                int n = numbersChoice[i];
                if (n>-1)
                {
                    Console.SetCursorPosition(6, 6+i);
                    Console.Write("блюдо {0}, ", dishes[i][n]);
                    Console.WriteLine("цена {0}", prices[i][n]);
                    summa += prices[i][n];
                }
            }
            Console.SetCursorPosition(6, 10);
            Console.WriteLine("Итого {0} руб", summa);
            Console.ReadLine();
        }
    }
}
