using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame2D
{
    class Program
    {
        // координаты глобальные
        static int MX = 10, MY = 5;

        static int[,] Map =
        {
            { 1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,1 },
            { 1,0,1,0,1,0,0,0,0,1 },
            { 1,0,1,0,1,0,0,0,0,0 },
            { 1,0,1,1,1,0,0,0,0,1 },
            { 0,0,1,0,1,0,0,0,0,1 },
            { 1,0,1,0,1,1,1,1,1,1 },
            { 1,0,1,0,1,0,0,1,0,1 },
            { 1,0,0,0,0,0,0,1,0,1 },
            { 1,1,1,1,1,1,1,1,1,1 }
        };

        static void Draw(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.SetCursorPosition(MX+j, MY+i);
                    if (Map[i, j] == 1)
                    {
                        Console.Write("█"); // 219
                    }
                }
            }
        }


        static void Walk(int x, int y)
        {
            // главный игровой цикл
            while(true)
            {
                // рисуем персонажа
                Console.SetCursorPosition(x, y);
                Console.Write("☺"); // Alt  1
                // ждём клавишу
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        y--;
                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        x--;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ЭЛЕМЕНТЫ 2Д игр:");
            Draw(Map);
            Walk(1, 1);
            Console.ReadLine();
        }
    }
}
