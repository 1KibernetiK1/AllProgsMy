using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2DArray
{
    class Program
    {
        static void FillRandom(int[,]m)
        {
            Random rnd = new Random();
            // первый цикл - пробегаем по СТРОКАМ
            for (int i = 0; i < m.GetLength(0); i++)
            {
                // второй - по столбцам внутри строки
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    m[i, j] = rnd.Next(0,3);
                }
            }
        }

        static void PrintArray(int[,]m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write("{0:d2}, ", m[i,j]);
                }
                Console.WriteLine();
            }
        }

        static int Perimeter(int[,]m)
        {
            int top = 0;
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                top += m[0,i];
            }
            int bottom = 0;
            for (int i = 0; i < cols; i++)
            {
                bottom += m[rows-1, i];
            }
            int left = 0;
            for (int i = 1; i < rows-1; i++)
            {
                left += m[i,0];
            }
            int right = 0;
            for (int i = 1; i < rows - 1; i++)
            {
                right += m[i, cols-1];
            }
            return left + right + top + bottom;
        }

        static int Diagonal(int[,]m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            int diagonal = 0;
            for (int i = 0; i < rows; i++)
            {
                diagonal = m[i, i];
            }
            int diagonal2 = 0;
            for (int i = 0; i < rows; i++)
            {
                int c = rows - i - 1;
                diagonal2 = m[i, c];
            }
            return diagonal + diagonal2;
        }

        static void Main(string[] args)
        {
            int[,] grid = new int[4, 5];
            FillRandom(grid);
            PrintArray(grid);
            Console.WriteLine();
            // sdfsd
            int s = Diagonal(grid);
            Console.WriteLine(s); 
            Console.ReadLine();
        }
    }
}
