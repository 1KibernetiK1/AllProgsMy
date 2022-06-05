using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMyReadLine
{
    class Program
    {
        static string MyReadLine()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            int c = 0; // позиция курсора относительно начала
            string text = "";
            while (true)
            {
                ConsoleKeyInfo inf = Console.ReadKey(true);
                char ch = inf.KeyChar;
                switch (inf.Key)
                {
                    case ConsoleKey.Delete:
                        if (c <= text.Length-1)
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
                        text = text.Insert(c, ch+"");
                        c++;
                        break;
                }
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.Write(text+" ");
                Console.CursorVisible = true;
                Console.SetCursorPosition(x+c,y);
                
            }
        }
        static string MyReadLineFixed(int maxLen)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            int c = 0; // позиция курсора относительно начала
            string text = "";
            while (true)
            {
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
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.Write(text + " ");
                Console.CursorVisible = true;
                Console.SetCursorPosition(x + c, y);

            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите имя ");
            string st = MyReadLineFixed(11);

            Console.WriteLine();
            Console.WriteLine(st);

            Console.ReadLine();
        }
    }
}
