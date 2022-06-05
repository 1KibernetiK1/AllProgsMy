using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNorton
{
    class Program
    {
        static void Draw(int x, int y, string[] menu, int active)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(menu[i]);
            }

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y + active);
            Console.Write(menu[active]);
        }

        static void FillScreen(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.Clear();
        }

        // Зачем? Что он делает?
        static int Select(int x, int y, string[] menu)
        {
            bool isWorking = true;
            int active = 0;
            while (isWorking)
            {
                Draw(x, y, menu, active);
                // чтение нажатой клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                // смотрим - что за кнопка?
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (active > 0)
                            active--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (active<menu.Length-1)
                            active++;
                        break;
                    case ConsoleKey.Enter:
                        isWorking = false;
                        break;
                }
            }

            return active;
        }

        static void FillFrame(int left, int top, int width, int height)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            int right = left + width - 1;
            int bottom = top + height - 1;

            Console.SetCursorPosition(left, top);
            Console.Write("╔");
            Console.SetCursorPosition(right, top);
            Console.Write("╗");
            Console.SetCursorPosition(left, bottom);
            Console.Write("╚");
            Console.SetCursorPosition(right, bottom);
            Console.Write("╝");

            string horizontal = new string('═', width - 2);
            Console.SetCursorPosition(left + 1, top);
            Console.Write(horizontal);
            Console.SetCursorPosition(left + 1, bottom);
            Console.Write(horizontal);

            string spaces = new string(' ', width - 2);

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write("║" + spaces + "║");
            }
        }

        static void DrawFrame(int left, int top, int width, int height)
        {
            int right = left + width-1;
            int bottom = top + height-1;

            Console.SetCursorPosition(left, top);
            Console.Write("╔");
            Console.SetCursorPosition(right, top);
            Console.Write("╗");
            Console.SetCursorPosition(left, bottom);
            Console.Write("╚");
            Console.SetCursorPosition(right, bottom);
            Console.Write("╝");

            string horizontal = new string('═', width-2);
            Console.SetCursorPosition(left+1, top);
            Console.Write(horizontal);
            Console.SetCursorPosition(left + 1, bottom);
            Console.Write(horizontal);

            // левую вертикаль
            for (int i = 1; i < height-1; i++)
            {
                Console.SetCursorPosition(left, top+i);
                Console.Write("║");
                Console.SetCursorPosition(right, top + i);
                Console.Write("║");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Рисование псевдографика");

            FillFrame(19, 2, 10, 6);

            string[] menu = { "первое", "второе", "третье", "купить" };
            int n = Select(20+1, 2+1, menu);

            Console.ReadLine();
        }
    }
}
