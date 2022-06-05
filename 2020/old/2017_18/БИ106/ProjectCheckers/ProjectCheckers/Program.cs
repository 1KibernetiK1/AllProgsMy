using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckers
{
    class Program
    {

        static int[,] board =
        {
            { 1,0,1,0,1,0,1,0 },
            { 0,1,0,1,0,1,0,1 },
            { 1,0,0,0,1,0,1,0 },
            { 0,0,0,1,0,0,0,0 },
            { 0,0,0,0,2,0,0,0 },
            { 0,2,0,2,0,0,0,2 },
            { 2,0,2,0,2,0,2,0 },
            { 0,2,0,2,0,2,0,2 }
        };

        static int DX = 10, DY = 3;

        static void Draw()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.SetCursorPosition(DX+j, DY+i);
                    if ( (i+j)%2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    } else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (board[i,j] == 0)
                    {
                        Console.Write(" ");
                    }
                    if (board[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("☺"); // 1
                    }
                    if (board[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("☻"); // 2
                    }
                }
            }
        }

        static int[] shiftX = {+1, -1, -1, +1 };
        static int[] shiftY = {-1, -1, +1, +1 };

        static void CheckCut2(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                int nx = x + shiftX[i];
                int ny = y + shiftY[i];


                if (nx >=0 && ny >=0 &&
                    nx <=7 && ny <= 7)
                {
                    if (board[ny, nx] == 1)
                    {
                        int sx = nx + shiftX[i];
                        int sy = ny + shiftY[i];
                        if (sx >= 0 && sy >= 0 &&
                            sx <= 7 && sy <= 7)
                        {
                            if (board[sy, sx] == 0)
                            {
                                Remove(nx, ny);
                                CheckerMove(x, y, sx, sy);
                            }
                        }
                    }
                }
            }
        }

        private static void CheckerMove(int x, int y, int sx, int sy)
        {
            board[y, x] = 0;
            Console.ReadKey(true);
            Draw();
            board[sy, sx] = 2;
            Console.ReadKey(true);
            Draw();
            //---------------

        }

        private static void Remove(int nx, int ny)
        {
            board[ny, nx] = 0; // анимация
            Console.ReadKey(true);
            Draw();
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Draw();
            Console.ReadKey();
            CheckCut2(4,4);
            Console.ReadLine();
        }
    }
}
