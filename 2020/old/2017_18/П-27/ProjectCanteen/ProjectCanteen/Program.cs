using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanteen
{
    class Program
    {
        static void DrawVMenu(int MX, int MY, string[] menu, int active)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(MX, MY + i);
                Console.WriteLine(menu[i]);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(MX, MY + menu.Length-1);
            Console.WriteLine(menu[menu.Length - 1]);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(MX, MY + active);
            Console.WriteLine(menu[active]);
        }

        static int SelectV(int x, int y, string[] menu)
        {
            Console.CursorVisible = false;
            int active = 0;
            bool IsWorking = true;
            while (IsWorking)
            {
                DrawVMenu(x,y,menu, active);
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

        static void DrawHMenu(int x, int y, string[]m, int active)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            int[] coordX = new int[m.Length];
            for (int i = 0; i < m.Length; i++)
            {
                coordX[i] = Console.CursorLeft;
                Console.Write("  {0}  ", m[i]);
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(coordX[active], y);
            Console.Write("[{0}]", m[active]);
        }

        static int SelectH(int x, int y, string[] m)
        {
            Console.CursorVisible = false;
            int current = 0;
            bool IsWorking = true;
            while(IsWorking)
            {
                DrawHMenu(x,y,m,current);
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (current > 0)
                            current--;
                        else current = m.Length - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (current < m.Length - 1)
                            current++;
                        else current = 0;
                        break;
                    case ConsoleKey.Enter:
                        IsWorking = false;
                        break;
                }
            }
            Console.CursorVisible = true;
            return current;
        }

        static void DrawWindow(int x, int y, int w, int h)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            Console.SetCursorPosition(x + w, y);
            Console.Write("╗");
            Console.SetCursorPosition(x, y + h);
            Console.Write("╚");
            Console.SetCursorPosition(x + w, y + h);
            Console.Write("╝");
            for (int i = 1; i < w; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("═");
                Console.SetCursorPosition(x + i, y + h);
                Console.Write("═");
            }
            for (int i = 1; i < h; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("║");
                for (int j = 1; j < w; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + w, y + i);
                Console.Write("║");
            }
        }

        static void Main(string[] args)
        {
            string[] menu = {"первое", "второе", "третье", "касса" };
            string[] first = { "борщ", "солянка", "щи", "отказ" };
            int[] first_p = { 35, 45, 30 };
            string[] second = { "пюре", "гречка", "рис", "горох", "отказ" };
            int[] second_p = { 30, 20, 15, 18 };
            string[] third = { "чай", "компот", "отказ" };
            int[] third_p = { 10, 15 };

            string[][] mass = { first, second, third };
            int[][] prices = { first_p, second_p, third_p};

            int[] choice = { -1, -1, -1 };

            while(true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                DrawWindow(10,1,30,2);
                Console.SetCursorPosition(11, 1);
                Console.Write("Вы выбрали:");
                Console.SetCursorPosition(12,2);
                for (int i = 0; i < 3; i++)
                {
                    int c = choice[i];
                    if (c > -1)
                        Console.Write("{0}, ", mass[i][c]);
                }
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                DrawWindow(10, 4, 40, 2);
                int n = SelectH(11, 5, menu);
                if (n == 3)
                {
                    // касса
                    break;
                }
                string[] dishes = mass[n];
                // выбираем блюда
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                DrawWindow(10+10*n, 7, 10, dishes.Length + 1);
                int m = SelectV(11+10*n, 8, dishes);
                if (m == dishes.Length - 1)
                    choice[n] = -1;
                else choice[n] = m;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            DrawWindow(5,5, 25, 5);
            Console.SetCursorPosition(6, 5);
            Console.Write("ЧЕК:");
            int summa = 0;
            for (int i = 0; i < 3; i++)
            {
                int n = choice[i];
                if (n > -1)
                {
                    Console.SetCursorPosition(6,6+i);
                    Console.Write("Блюдо {0} цена {1}",
                        mass[i][n], prices[i][n]);
                    summa += prices[i][n];
                }
            }
            Console.SetCursorPosition(6, 10);
            Console.WriteLine("Итого {0} руб", summa);
            Console.ReadLine();
        }
    }
}
