using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("СТУДЕНТЫ");

            Student[] studentsCourse =
            {
                new Student(3,"Иван", "Петров",4,167,67 ),
                new Student(2,"Александр", "Иванов", 3, 175, 88),
                new Student(1,"Никита", "Губцов", 4, 187, 75),
                new Student( 2,"Варвара", "Милицкая", 4, 165, 56),
                new Student(3,"Григорий", "Тушев", 3, 196, 97),
                new Student(4,"Георгий", "Гончаров", 5, 182, 79 ),
            };

           

            foreach (var s in studentsCourse)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nСОРТИРОВКА СТУДЕНТОВ ПО ИМЕНИ");

            Array.Sort(studentsCourse);

            foreach (var stud in studentsCourse)
            {
                Console.WriteLine(stud);
            }

            


            Console.ReadLine();

        }
    }
}
