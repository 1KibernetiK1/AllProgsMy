using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLinq02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linq");
            var students = StudentsStorage.GetStudents();

            Console.WriteLine("Все второкурсники:");
            var secondCourse = students.Where(s => s.Course==2).ToList();
            secondCourse.ForEach(s => Console.WriteLine(s));

            var serviceStudent = students.Where(s => s.Gender == Gender.Male && s.Age >= 18 && s.Age <= 27).ToList();// фильтрация

            Console.WriteLine("\r\nservice");
            //serviceStudent.ForEach(s => Console.WriteLine(s));
            serviceStudent.ForEach(Console.WriteLine); // можно так писать

            Console.WriteLine("\r\n projections");
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight" };
            int[] numbers = {2,0,2,1 };

            var wordsYear = numbers.Select(n => words[n]).ToList();// проекция
            Console.WriteLine(string.Join(" ", wordsYear));

            List<string> namesOfHonor = students.Where(s => s.IsHonor).Select(s=>s.Name).ToList();// Фильтрация+проекция
            Console.WriteLine(string.Join(", ", namesOfHonor));

            var championship = students.Where(s => s.Course != 1).Select(s => new { nameofStudent = s.Name, AcademicGroup = s.Group }).ToList();// Фильтр+проекция
            championship.ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
