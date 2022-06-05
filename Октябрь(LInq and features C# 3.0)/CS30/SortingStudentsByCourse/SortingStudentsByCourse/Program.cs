using SortingStudentsByCourse.SortingByIComparable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortingStudentsByCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> people = new List<string[]>();

            people.Add(new string[] { "Иван", "1980", "1" , "ПИ-126" });
            people.Add(new string[] { "Яна", "1987", "2", "БИ-108" });
            people.Add(new string[] { "Михаил", "1990", "1", "Э-234" });
            people.Add(new string[] { "Анна", "1992", "3", "Э-123" });

            Output Out = new Output();

            Out.OutputList(people, "Список до сортировки");

            NameComparer nc = new NameComparer();
            people.Sort(nc);
            Out.OutputList(people, "Список после сортировки по длине имён");

            YearComparer yc = new YearComparer();
            people.Sort(yc);
            Out.OutputList(people, "Список после сортировки по году рождения");

            CourseComparer cc = new CourseComparer();
            people.Sort(cc);
            Out.OutputList(people, "Список после сортировки по Курсу");

            GroupComparer gc = new GroupComparer();
            people.Sort(gc);
            Out.OutputList(people, "Список после сортировки по Группе");

            Console.ReadLine();
        }

       
    }
}
