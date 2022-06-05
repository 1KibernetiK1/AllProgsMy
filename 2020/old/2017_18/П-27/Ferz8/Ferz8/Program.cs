using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferz8
{
    class Program
    {
        // шахматная доска
        static int [,] desk = new int[8,8];

        static int DX = 15, DY = 5;
        static void DrawDesk()
        {
            bool flag = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.SetCursorPosition(DX+j, DY+i);
                    flag = ! flag;
                    if (flag)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    } else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (desk[i,j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(desk[i,j]);
                }
                flag = !flag;
            }
        }

        // column - столбец
        // row - строка
        static void SetFerz(int col, int row)
        {
            // единицами в массиве отметить
            for (int i = 0; i < 8; i++)
            {
                desk[i, col] += 1;
                desk[row, i] += 1;
            }
            //-------------------------
            int x = col, y = row;
            while(x > 0 && y > 0)
            {
                x--; y--;
                desk[y, x] += 1;
            }
            x = col; y = row;
            while (x <7 && y < 7)
            {
                x++; y++;
                desk[y, x] += 1;
            }
            x = col; y = row;
            while (x > 0 && y < 7)
            {
                x--; y++;
                desk[y, x] += 1;
            }
            x = col; y = row;
            while (x < 7 && y > 0)
            {
                x++; y--;
                desk[y, x] += 1;
            }
            desk[row, col] = 9;
        }

        static void RemoveFerz(int col, int row)
        {
            // единицами в массиве отметить
            for (int i = 0; i < 8; i++)
            {
                desk[i, col] -= 1;
                desk[row, i] -= 1;
            }
            //-------------------------
            int x = col, y = row;
            while (x > 0 && y > 0)
            {
                x--; y--;
                desk[y, x] -= 1;
            }
            x = col; y = row;
            while (x < 7 && y < 7)
            {
                x++; y++;
                desk[y, x] -= 1;
            }
            x = col; y = row;
            while (x > 0 && y < 7)
            {
                x--; y++;
                desk[y, x] -= 1;
            }
            x = col; y = row;
            while (x < 7 && y > 0)
            {
                x++; y--;
                desk[y, x] -= 1;
            }
            desk[row, col] = 0;
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DrawDesk();

            Console.ReadKey(true);
            SetFerz(4, 2);
            SetFerz(2, 6);
            DrawDesk();

            Console.ReadKey(true);
            RemoveFerz(4, 2);
            DrawDesk();

            Console.ReadKey(true);
            RemoveFerz(2, 6);
            DrawDesk();

            Console.ReadLine();
        }
    }
}
