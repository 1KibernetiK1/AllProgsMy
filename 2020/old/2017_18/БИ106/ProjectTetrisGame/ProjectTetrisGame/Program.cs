using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTetrisGame
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameField g = new GameField(1,1,18,22);
            Figure square = new Figure(2,2,3,3);
            square.SetShape(new string[] { "111",
                                           "100",
                                           "100" });
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                g.Draw();
                Console.ForegroundColor = ConsoleColor.White;
                square.Draw();
                square.Fall();
                Console.ReadKey();
            }
            Console.ReadLine();
        }
    }
}
