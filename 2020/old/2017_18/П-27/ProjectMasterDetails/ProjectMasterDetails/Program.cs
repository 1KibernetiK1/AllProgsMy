using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectMasterDetails
{
    class Program
    {
        // глобальные массивы с данными
        static string[] names;
        static string[] lastnames;
        static string[] secondnames;
        static int[] ages;
        static int[] salaries;
        static string[] roles;


        static int CountLinesInFile(string fname)
        {
            var fs = new FileStream(fname, FileMode.Open);
            var sr = new StreamReader(fs);
            int c = 0;
            while(!sr.EndOfStream)
            {
                sr.ReadLine();
                c++;
            }
            fs.Close();
            return c;
        }

        static void LoadCustomers()
        {
            string fname = "DataBase\\customers.txt";
            int n = CountLinesInFile(fname);
            names = new string[n];
            lastnames = new string[n];
            secondnames = new string[n];
            salaries = new int[n];
            ages = new int[n];
            roles = new string[n];
            //--------------------
            var fs = new FileStream(fname, FileMode.Open);
            var sr = new StreamReader(fs);
            int c = 0;
            while (!sr.EndOfStream)
            {
                string st = sr.ReadLine();
                string[] parts = st.Split('|');
                lastnames[c] = parts[0];
                names[c] = parts[1];
                secondnames[c] = parts[2];
                ages[c] = int.Parse(parts[3]);
                roles[c] = parts[4];
                salaries[c] = int.Parse(parts[5]);
                c++;
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
        static void Main(string[] args)
        {
            LoadCustomers();
            while (true)
            {
                Clear();
                
                int h = names.Length + 3;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                FillFrame(10, 3, 10, h);
                int i = Select(11, 4, lastnames);
                ShowDetails(i);
            }
        }

        private static void ShowDetails(int i)
        {
            while (true)
            {
                Clear();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                FillFrame(10, 3, 30, 10);
                Console.SetCursorPosition(11, 4);
                Console.Write("Фамилия:    [{0}]", lastnames[i]);
                Console.SetCursorPosition(11, 5);
                Console.Write("Имя:        [{0}]", names[i]);
                Console.SetCursorPosition(11, 6);
                Console.Write("Отчество:   [{0}]", secondnames[i]);
                Console.SetCursorPosition(11, 7);
                Console.Write("Возраст:    [{0} лет]", ages[i]);
                Console.SetCursorPosition(11, 8);
                Console.Write("Должность:  [{0}]", roles[i]);
                Console.SetCursorPosition(11, 9);
                Console.Write("Зарплата:   [{0} руб.]", salaries[i]);
                int c = ButtonsSelect(16, 11, 8, 3, new string[] { "Ред.", "ОК" });
                if (c == 1) break;
                if (c == 0)
                {
                    // редактирование
                    EditCustomer(i);
                }
            }
        }

        static string MyReadLineFixed(string text, int maxLen)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            int c = 0; // позиция курсора относительно начала
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.Write(text + " ");
                Console.CursorVisible = true;
                Console.SetCursorPosition(x + c, y);
                ConsoleKeyInfo inf = Console.ReadKey(true);
                char ch = inf.KeyChar;
                switch (inf.Key)
                {
                    case ConsoleKey.Delete:
                        if (c <= text.Length - 1)
                        {
                            text = text.Remove(c, 1);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (c > 0)
                        {
                            text = text.Remove(c - 1, 1);
                            c--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        c--;
                        break;
                    case ConsoleKey.RightArrow:
                        c++;
                        break;
                    case ConsoleKey.Enter:
                        return text;
                    default:
                        //text += ch;
                        if (text.Length < maxLen)
                        {
                            text = text.Insert(c, ch + "");
                            c++;
                        }

                        break;
                }
                

            }
        }

        static int MyReadIntegerFixed(int value)
        {
            int maxLen = 10;
            string text = value.ToString();
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            int c = 0; // позиция курсора относительно начала
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.Write(text + " ");
                Console.CursorVisible = true;
                Console.SetCursorPosition(x + c, y);
                ConsoleKeyInfo inf = Console.ReadKey(true);
                char ch = inf.KeyChar;
                switch (inf.Key)
                {
                    case ConsoleKey.Delete:
                        if (c <= text.Length - 1)
                        {
                            text = text.Remove(c, 1);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (c > 0)
                        {
                            text = text.Remove(c - 1, 1);
                            c--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        c--;
                        break;
                    case ConsoleKey.RightArrow:
                        c++;
                        break;
                    case ConsoleKey.Enter:
                        return int.Parse(text);
                    default:
                        //text += ch;
                        if (char.IsDigit(ch))
                        if (text.Length < maxLen)
                        {
                            text = text.Insert(c, ch + "");
                            c++;
                        }

                        break;
                }
            }
        }

        private static void EditCustomer(int i)
        {
            while (true)
            {
                Clear();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                FillFrame(10, 3, 15, 8);
                int n = Select(11, 4, new string[]
                {
                "фамилию","имя", "отчество",
                "возраст", "должность", "зарплата",
                "  X. Выход"
                });
                Clear();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                FillFrame(12, 5, 25, 3);
                Console.SetCursorPosition(13, 6);
                switch (n)
                {
                    case 0:
                        lastnames[i] = MyReadLineFixed(lastnames[i], 20);
                        break;
                    case 1:
                        names[i] = MyReadLineFixed(names[i], 20);
                        break;
                    case 2:
                        secondnames[i] = MyReadLineFixed(names[i], 20);
                        break;
                    case 3:
                        ages[i] = MyReadIntegerFixed(ages[i]);
                        break;
                    case 4:
                        roles[i] = MyReadLineFixed(roles[i], 20);
                        break;
                    case 5:
                        salaries[i] = MyReadIntegerFixed(salaries[i]);
                        break;
                    case 6:
                        return;
                }
            }
        }

        private static void ShowButtons(int x, int y, 
                                 int w, int delta, 
                                 string[] text,
                                 int active) 
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < text.Length; i++)
            {
                if ( i == active )
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                } else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(x+(w+delta)*i, y);
                string st = text[i];
                if (st.Length < w)
                {
                    int dx = w - st.Length;
                    int add = dx / 2;
                    st = st.PadLeft(st.Length+add);
                    st = st.PadRight(st.Length+add);
                }
                Console.Write(st);
            }
        }

        private static int ButtonsSelect(int x, int y,
                                 int w, int delta,
                                 string[] text)
        {
            int active = 0;
            while(true)
            {
                ShowButtons(x,y,w,delta,text,active);
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (active == 0)
                            active = text.Length - 1;
                        else active--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (active == text.Length - 1)
                            active = 0;
                        else active++;
                        break;
                    case ConsoleKey.Enter:
                        return active;
                }
            }
        }
    }
}
