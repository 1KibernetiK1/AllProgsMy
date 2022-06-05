using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectImage
{
    class Program
    {
        static int[,] image =
        {
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,1,0,0 },
            { 0,0,0,0,0,0,1,1,0,0 },
            { 0,0,0,0,0,1,0,1,0,0 },
            { 0,0,0,0,1,0,0,1,0,0 },
            { 0,0,0,1,0,0,0,1,0,0 },
            { 0,0,1,1,1,1,1,1,0,0 },
            { 0,0,1,0,0,0,0,1,0,0 },
            { 0,0,1,0,0,0,0,1,0,0 },
            { 0,0,1,0,0,0,0,1,0,0 }
        };

        static void DrawImage(int x, int y, int[,]m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == 1)
                    {
                        Console.SetCursorPosition(x + i*2, y + j);
                        Console.Write("██");//219
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            DrawImage(30,6,image);
            Console.ReadLine();
        }
    }
}
