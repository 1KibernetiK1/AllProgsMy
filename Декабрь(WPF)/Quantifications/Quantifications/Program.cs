using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifications
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Квантификация");
            var students = StudentsStorage.GetStudents();
            Console.WriteLine("Если хотя бы один отличник = {0}", students.Any(s => s.IsHonor));

            Console.WriteLine("Все студенты - первокурсники = {0}", students.All(s => s.Course == 1));

            Console.WriteLine("Количество второкурсников = {0}", students.Count(s => s.Course == 2));

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Агрегация");
            Console.WriteLine("Средний возраст студентов-парней = {0}", students.Where(s => s.Gender == Gender.Male).Average(s => s.Age));
            Console.WriteLine("Общая сумма наличных студентов = {0}", students.Sum(s => s.Money));
            Console.WriteLine("Минимальный возраст среди студентов = {0}", students.Min(s => s.Age));
            Console.WriteLine("Максимальный рост среди студентов = {0}", students.Max(s => s.Height));

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Методы поиска:");
            Console.WriteLine("Первый отличник в списке = {0}", students.First(s => s.IsHonor));

            Student s1 = students.FirstOrDefault(s => s.Height == 150);
            if (s1 == null)
            {
                Console.WriteLine("Студент по такому критерию отсутствует");
            }
            else
            {
                Console.WriteLine(s1);
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Группировка");
            var studentsByCourse = from s in students
                                   group s by s.Course
                                   into course
                                   select course;
            Console.WriteLine("Разбили студентов на группы по курсу");
            foreach (var group in studentsByCourse)
            {
                Console.WriteLine("Курс = {0}", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

            var studentsByGender = students.GroupBy(s => s.Gender);
            Console.WriteLine("Группировка по гендеру");
            foreach (var group in studentsByGender)
            {
                Console.WriteLine(group.Key);
                foreach (var s in group)
                {
                    Console.WriteLine(s);
                }
            }

            Console.Clear();
            Console.WriteLine("Разбиения");
            int pageSize = 4;
            Console.WriteLine("Перелистывание СТРАНИЦ со студентами...");
            int page = 1;
            int pageCount = (int)Math.Ceiling(students.Count() / (float)pageSize);

            while(page <= pageCount)
            {
                Console.WriteLine("СТР. {0}/{1}", page, pageCount);
                var studentsForPage = students
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
                    .ToList();

                //if (studentsForPage.Count() == 0) break;

                studentsForPage.ForEach(Console.WriteLine);
                Console.ReadKey();

                page++;
            }

            Console.WriteLine("Студенты закончились");
            Console.WriteLine("TakeWhile и SkipWhile");
            Console.WriteLine("Из списка студентов первых направления Бизнес");

            var business = students.SkipWhile(s => s.Profile != "Бизнес")
                .TakeWhile(s => s.Profile == "Бизнес")
                .ToList();

            business.ForEach(Console.WriteLine);

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Студенты-парни по росту:");
            var byHeightAndName = students.Where(s => s.Gender == Gender.Male).OrderBy(s => s.Height).ThenBy(s => s.Name).ToList();
            byHeightAndName.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
