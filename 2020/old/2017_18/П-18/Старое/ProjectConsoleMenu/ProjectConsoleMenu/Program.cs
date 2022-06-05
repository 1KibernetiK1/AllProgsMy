using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsoleMenu
{
    class Program
    {

        static void DrawMenu(int x, int y, string[] m, int number)
        {
            for(int i=0; i<m.Length; i++)
            {
                if (i == number)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                } else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(x, y+i);
                Console.Write(m[i]);
            }
        }

        static int Select(int x, int y, string[]m)
        {
            int current = 0; // номер текущий элемент
            while (true) // бесконечный цикл выбора
            {
                // рисуем меню, подкрашиваем текущий
                DrawMenu(x,y,m,current);
                // ожидаем нажатие клавиши
                ConsoleKeyInfo info = Console.ReadKey(true);
                // проверить какая кнопка
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        current--;
                        break;
                    case ConsoleKey.DownArrow:
                        current++;
                        break;
                    case ConsoleKey.Enter:
                        return current;
                }
            }
        }

        static string[] menu1 =
        {
            "борщ",
            "солянка",
            "харчо",
            "бульон",
            "отказ"
        };
        static string[] menu2 =
            {
                "котлета",
                "отбивная",
                "пельмени",
                "курица",
                "отказ"
            };
        static string[] menu3 =
            {
                "пюре",
                "рис",
                "гречка",
                "овощи",
                "отказ"
            };
        static string[] menu4 =
            {
                "цезарь",
                "витаминный",
                "зимний",
                "отказ"
            };
        static string[] menu5 =
            {
                "чай",
                "компот",
                "кофе",
                "отказ"
            };

        // в этом массиве будем запоминать номера выбора
        static int[] choice = { -1, -1, -1, -1, -1 };

        static void FirstDishes()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ShowChoice();
            int n = Select(30, 5, menu1);
            choice[0] = n;
            if (n == menu1.Length - 1)
                choice[0] = -1;
        }

        static void SecondDishes()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ShowChoice();
            int n = Select(30, 5, menu2);
            choice[1] = n;
            if (n == menu2.Length - 1)
                choice[1] = -1;
        }

        static void GarnirsDishes()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ShowChoice();
            int n = Select(30, 5, menu3);
            choice[2] = n;
            if (n == menu3.Length - 1)
                choice[2] = -1;
        }

        static void SalatsDishes()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ShowChoice();
            int n = Select(30, 5, menu4);
            choice[3] = n;
            if (n == menu4.Length - 1)
                choice[3] = -1;
        }

        static void Drinks()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ShowChoice();
            int n = Select(30, 5, menu5);
            choice[4] = n;
            if (n == menu5.Length - 1)
                choice[4] = -1;
        }

        static int MainDishes()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ShowChoice();
            string[] menu =
            {
                "первое",
                "второе",
                "гарниры",
                "салаты",
                "напитки"
            };
            int n = Select(30, 5, menu);
            return n;
        }

        static void ShowChoice()
        {
            Console.SetCursorPosition(1,1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < choice.Length; i++)
            {
                if (choice[i] >= 0)
                {
                    int n = choice[i];
                    switch (i)
                    {
                        case 0: Console.Write("[" + menu1[n] + ", ");break;
                        case 1: Console.Write(menu2[n] + ", "); break;
                        case 2: Console.Write(menu3[n] + ", "); break;
                        case 3: Console.Write(menu4[n] + ", "); break;
                        case 4: Console.Write(menu5[n] + "]"); break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int n = MainDishes();
                switch (n)
                {
                    case 0:
                        FirstDishes();
                        break;
                    case 1:
                        SecondDishes();
                        break;
                    case 2:
                        GarnirsDishes();
                        break;
                    case 3:
                        SalatsDishes();
                        break;
                    case 4:
                        Drinks();
                        break;
                }
            }


            Console.ReadLine();
        }
    }
}
