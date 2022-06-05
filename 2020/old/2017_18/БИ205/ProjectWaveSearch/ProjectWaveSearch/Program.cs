using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWaveSearch
{
    class Program
    {
        static int MX = 10, MY = 5;

        static int[,] map =
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0 },
            { 0, 0,-1, 0, 0, 0, 0,-1, 0, 0, 0, 0 },
            { 0, 0,-1, 0, 0, 0, 0,-1, 0, 0, 0, 0 },
            { 0, 0,-1, 0, 0, 0, 0,-1,-1,-1, 0, 0 },
            { 0, 0,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0,-1,-1,-1, 0,-1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        static void Draw(Point p1, Point p2)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(MX+ j*2, MY+i);
                    if (map[i, j] == -1)
                    {
                        Console.Write("██"); //219
                    } else if (map[i, j] == 0)
                    {
                        Console.Write("  "); //219
                    } else
                    {
                        Console.Write( "{0:D2}",map[i, j] );
                    }
                }
            }
            ShowPoints(p1, p2);
        }

        static void ShowPoints(Point p1, Point p2)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(MX + p1.X*2, MY + p1.Y);
            Console.Write("E ");
            Console.SetCursorPosition(MX + p2.X*2, MY + p2.Y);
            Console.Write("P ");
        }

        static Point[] neighbors =
        {
            new Point( 0,  -1),
            new Point(-1,   0),
            new Point( 0,  +1),
            new Point(+1,   0),
            new Point(+1,  +1),
            new Point(-1,  -1),
            new Point(-1,  +1),
            new Point(+1,  -1)
        };

        static void BuildWaves(Point p1, Point p2)
        {
            // границы карты
            int left = -1;
            int top = -1;
            int right = map.GetLength(1);
            int bottom = map.GetLength(0);
            // 1) стеки для хранения волнового фронта
            var waveFirst = new Stack<Point>();
            var waveSecond = new Stack<Point>();
            // счётчик волн
            int waveCounter = 1;
            // 2) первую точку ложим в стек
            waveFirst.Push(p1);// бросили камень в воду
            // 3) 
            do
            {
                // пока в волне есть нерасмотреные точки
                while (waveFirst.Count > 0)
                {
                    // достаём очередную волн точку
                    var pt = waveFirst.Pop();
                    // просматриваем всех соседей и строим фронт
                    for (int i = 0; i < neighbors.Length; i++)
                    {
                        // вычисляем координаты каждого соседа
                        int x = pt.X + neighbors[i].X;
                        int y = pt.Y + neighbors[i].Y;
                        // защита границ массива
                        if (x > left && y > top &&
                            x < right && y < bottom)
                        {
                            // если точка пустая - то это волна
                            if (map[y, x] == 0)
                            {
                                // помещаем во второй волновой фронт
                                waveSecond.Push(new Point(x, y));
                                // на карте пометим
                                map[y, x] = waveCounter;
                                // нарисуем
                                Draw(p1, p2);
                            }
                        }
                    }
                }
                // переключаем волны
                waveFirst = waveSecond;
                waveSecond = new Stack<Point>();
                waveCounter++;
                Console.ReadKey(true);
            } while (true);

        }

        static void Main(string[] args)
        {
            var start = new Point(0, 11);
            var end = new Point(8, 3);

            Draw(start, end);
            BuildWaves(start, end);

            Console.ReadLine();
        }
    }
}
