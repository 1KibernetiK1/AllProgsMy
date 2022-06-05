using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectCinema
{
    class Program
    {
        // глобальный 2-х мерн массив
        // места в кинозале/ бронь
        static int[,] currentHall;

        // глобальная переменная
        static int currentFilm;

        static string[] films =
        {
            "Дедпул2",
            "Война бесконечности",
            "Чёрная пантера",
            "Такси 5",
            "  X. Выход"
        };

        static void SaveSession(string fname)
        {
            string fpath = "Database\\" + fname;
            var fs = new FileStream(fpath, FileMode.Create);
            var sw = new StreamWriter(fs);
            // узнаём размер зала
            // читаем первую строку
            int r = currentHall.GetLength(0);
            int c = currentHall.GetLength(1);
            sw.WriteLine("{0},{1}",r,c);
            // читаем из файла ряды (брони)
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (currentHall[i, j] == 2)
                        currentHall[i, j] = 1;
                    sw.Write("{0},", currentHall[i, j]);
                    // "0" => 0
                }
                sw.WriteLine();
            }
            sw.Close();
            fs.Close();
        }

        static void LoadSession(string fname)
        {
            string fpath = "Database\\" + fname;
            var fs = new FileStream(fpath, FileMode.Open);
            var sr = new StreamReader(fs);
            // узнаём размер зала
            // читаем первую строку
            string st = sr.ReadLine();
            string[] mass = st.Split(','); // "5,10"
            // кол-во строк
            int rows = int.Parse(mass[0]);// "5"=>5
            int cols = int.Parse(mass[1]);// "10"=>10
            // задаём размер массива глобального
            currentHall = new int[rows, cols];
            // читаем из файла ряды (брони)
            for (int i = 0; i < rows; i++)
            {
                // считывается сразу целый ряд
                st = sr.ReadLine();// "0,1,0,0,1,0"
                mass = st.Split(','); // ["0" "1" "0"]
                for (int j = 0; j < cols; j++)
                {
                    currentHall[i, j] = int.Parse(mass[j]);
                    // "0" => 0
                }
            }
            fs.Close();
        }

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

        static void FillFrame(int x, int y, int w, int h)
        {
            // 218 ┌
            // 191 ┐
            // 192 └
            // 217 ┘
            // 179  │
            // 196 ─
            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌");
            Console.SetCursorPosition(x + w, y);
            Console.WriteLine("┐");
            Console.SetCursorPosition(x, y + h);
            Console.WriteLine("└");
            Console.SetCursorPosition(x + w, y + h);
            Console.WriteLine("┘");
            for (int i = 1; i < w; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("─");
                Console.SetCursorPosition(x + i, y + h);
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
                Console.SetCursorPosition(x + w, y + i);
                Console.Write("│");
            }
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
            Console.SetCursorPosition(x + w, y);
            Console.WriteLine("┐");
            Console.SetCursorPosition(x, y + h);
            Console.WriteLine("└");
            Console.SetCursorPosition(x + w, y + h);
            Console.WriteLine("┘");
            for (int i = 1; i < w; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("─");
                Console.SetCursorPosition(x + i, y + h);
                Console.Write("─");
            }
            for (int i = 1; i < h; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("│");
                Console.SetCursorPosition(x + w, y + i);
                Console.Write("│");
            }
        }

        static void Clear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        static void ScreenMenuFilms()
        {
            Clear();
            Console.BackgroundColor
                = ConsoleColor.Blue;
            int h = films.Length + 1;
            FillFrame(10, 5, 20, h);
            Console.SetCursorPosition(11, 5);
            Console.BackgroundColor
                = ConsoleColor.DarkMagenta;
            Console.WriteLine("Выберите фильм:");
            
            currentFilm = Select(11, 6, films);
        }

        static void DrawHall(int x, int y, int rows, int cols)
        {
            int sx = x, sy = y;
            int w = 3, h = 2;
            int dx = 3, dy = 2;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (currentHall[i,j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        FillFrame(sx, sy, w, h);
                        //--------------------
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(sx + 1, sy + 1);
                        Console.WriteLine(j + 1);
                    } else if (currentHall[i,j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        FillFrame(sx, sy, w, h);
                        //--------------------
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(sx + 1, sy + 1);
                        Console.WriteLine(j + 1);
                    }
                    else if (currentHall[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        FillFrame(sx, sy, w, h);
                        //--------------------
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(sx + 1, sy + 1);
                        Console.WriteLine(j + 1);
                    }

                    //------------------------------
                    sx += w + dx;
                }
                Console.SetCursorPosition(1, sy+1);
                Console.WriteLine("Ряд" + (i + 1));
                Console.SetCursorPosition(sx+3, sy + 1);
                Console.WriteLine("Ряд" + (i + 1));
                sx = x;
                sy += h + dy;
                
            }
        }

        static void SelectSeat(int x, int y, int rows, int cols)
        {
            int sx = x, sy = y;
            int w = 3, h = 2;
            int dx = 3, dy = 2;
            // номер ряда и номер места
            int r = 4, c = 5;
            // старые координаты ряда и места
            int pr = r, pc = c;
            while (true)
            {
                if (pr != r || pc != c)
                {
                    #region Затираем предыдущее положение рамки!
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    sx = x + (w + dx) * pc;
                    sy = y + (h + dy) * pr;
                    DrawFrame(sx - 1, sy - 1, w + 2, h + 2);
                    #endregion
                }
                #region Выделяем место
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                sx = x + (w + dx) * c;
                sy = y + (h + dy) * r;
                DrawFrame(sx - 1, sy - 1, w + 2, h + 2);
                #endregion
                ConsoleKeyInfo info =
                    Console.ReadKey(true);
                pr = r; pc = c;
                switch (info.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.LeftArrow:
                        c--;
                        break;
                    case ConsoleKey.RightArrow:
                        c++;
                        break;
                    case ConsoleKey.UpArrow:
                        r--;
                        break;
                    case ConsoleKey.DownArrow:
                        r++;
                        break;
                    case ConsoleKey.Enter:
                        if (currentHall[r, c] == 2)
                        {
                            currentHall[r, c] = 0;
                        } else
                        if (currentHall[r, c] != 1)
                        {
                            currentHall[r, c] = 2;
                        } 
                        DrawHall(x,y,rows, cols);
                        break;
                }
            }
        }

        private static void ScreenCinemaHall()
        {
            Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(10, 0);
            string text = films[currentFilm];
            Console.WriteLine("Фильм: " + text);
            Console.BackgroundColor = ConsoleColor.Blue;
            FillFrame(6, 2, 93, 25);
            int rows = currentHall.GetLength(0);
            int cols = currentHall.GetLength(1);
            DrawHall(8, 3, rows, cols);
            SelectSeat(8, 3, rows, cols);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ScreenMenuFilms();
                if (currentFilm == films.Length-1)
                {
                    break; // выход из программы
                }
                string fname = string.Format("session_{0:d2}.txt",currentFilm+1);
                LoadSession(fname);
                ScreenCinemaHall();
                SaveSession(fname);
            }
        }

        
    }
}
