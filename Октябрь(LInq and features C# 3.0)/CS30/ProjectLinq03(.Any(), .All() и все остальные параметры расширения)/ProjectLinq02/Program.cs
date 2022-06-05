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
            Console.WriteLine("Квантификация: ");
            var students = StudentsStorage.GetStudents();
            Console.WriteLine("Есть хотя бы один отличник = {0}", students.Any(s=>s.IsHonor));

            Console.WriteLine("Все студенты - первокурсники? = {0}", students.All(s => s.Course == 1));

            Console.WriteLine("Количество второкурсников = {0}", students.Count(s => s.Course == 2));

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Аггрегация");

            Console.WriteLine("Средний возраст студентов парней = {0}", students.Where(s=> s.Gender == Gender.Male)
                .Average(s=>s.Age));

            Console.WriteLine("Общая сумма наличными у студентов = {0}", students.Sum(s => s.Money));

            Console.WriteLine("Минимальный возраст студентов = {0}", students.Min(s => s.Age));

            Console.WriteLine("Максимальный рост возраст студентов = {0}", students.Max(s => s.Height));

            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("Методы поиска:");

            Console.WriteLine("Первый отличник в списке: {0}", students.First(s => s.IsHonor));

            Student s1 = students.FirstOrDefault(s => s.Height == 175);
            if (s1 == null)
            {
                Console.WriteLine("Студент по такому критерию отсутствует");
            }
            else
            {
                Console.WriteLine("Найден = {0}", s1);
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Группировка");
            var studentsByCourse = from s in students
                                   group s by s.Course 
                                   into course select course;

            Console.WriteLine("Разбили студентов по курсу:");
            foreach (var gr in studentsByCourse)
            {
                Console.WriteLine("Курс = {0}",gr.Key);
                foreach (var s in gr)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }

            var studentsByGender = students.GroupBy(s => s.Gender);
            Console.WriteLine("Группировка по полу");
            foreach (var gr in studentsByGender)
            {
                Console.WriteLine(gr.Key);
                foreach (var s in gr)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine("Разбиение");
            // кол-во студентов на одной странице
            int pageSize = 4;
            Console.WriteLine("Перелистывание страниц...");
            int page = 1;
            int pageCount = (int) Math.Ceiling(students.Count() / (float)pageSize);
            while (page <= pageCount)
            {
                Console.WriteLine("стр. {0}/{1}", page, pageCount);
                var studentsForPage = students.Skip(pageSize*(page-1)).Take(pageSize).ToList();

                if (studentsForPage.Count() == 0) break;
              

                studentsForPage.ForEach(Console.WriteLine);
                Console.WriteLine("\r\n Нажмите кнопку перехода на след. страницу");
                Console.ReadKey();
                Console.Clear();

                page++;
            }
            Console.WriteLine("Студенты кончились");
            Console.Clear();

            Console.WriteLine("TakeWhile и SkipWhile");
            Console.WriteLine("Из списка студентов первых направления Бизнес");

            var business = students.SkipWhile(s => s.Profile != "Бизнес")
            .TakeWhile(s => s.Profile == "Бизнес")
            .ToList();
            business.ForEach(Console.WriteLine);

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Студенты-парни по росту");
            var boysByHeight = students.Where(s => s.Gender == Gender.Male).OrderBy(s => s.Height).ThenBy(s => s.Name).ToList();
            boysByHeight.ForEach(Console.WriteLine);


            Console.ReadLine();
        }
    }
}
