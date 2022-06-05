using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWaveAlg
{
    class Program
    {
        static int MX = 10, MY = 5;

        static int[,] Map =
        {
            {  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {  0, 0, 0,-1,-1,-1,-1,-1,-1,-1, 0, 0 },
            {  0, 0, 0,-1, 0, 0, 0, 0, 0,-1, 0, 0 },
            {  0, 0, 0, 0, 0, 0,-1,-1,-1,-1,-1, 0 },
            {  0,-1,-1,-1,-1, 0,-1, 0, 0, 0, 0, 0 },
            {  0, 0, 0, 0,-1, 0,-1,-1,-1,-1, 0, 0 },
            {  0, 0, 0, 0,-1, 0, 0, 0, 0,-1, 0, 0 },
            {  0, 0, 0, 0,-1,-1,-1,-1, 0,-1,-1,-1 },
            {  0, 0, 0, 0, 0,-1, 0,-1, 0, 0, 0, 0 },
            {  0,-1,-1,-1,-1,-1, 0,-1, 0, 0, 0, 0 },
            {  0, 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0 },
            {  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        static void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(MX+ j*2 , MY+i);
                    if (Map[i, j] == -1)
                    {
                        Console.WriteLine("██"); // 219
                    } else
                    if (Map[i, j] == 0)
                    {
                        Console.WriteLine("  "); // 219
                    } else
                    {
                        // цифры - для обозначения волны...
                        Console.WriteLine("{0:d2}", Map[i,j]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Point start = new Point(0, 11);
            Point end = new Point(8, 2);
            Draw();
            Show2Point(start, end);
            Console.ReadLine();
        }

        private static void Show2Point(Point start, Point end)
        {
            Console.SetCursorPosition(MX+start.X,
                                      MY+start.Y);
            Console.WriteLine("St");
            Console.SetCursorPosition(MX + end.X,
                                      MY + end.Y);
            Console.WriteLine("Ed");
        }
    }
}
