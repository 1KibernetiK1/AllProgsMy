using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifications
{
    public class StudentsStorage
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student()
                {
                    Money = 5000,
                    Age = 18, Course = 3, Gender = Gender.Other, Group = "ПИ-126", Height = 170, IsHonor = false, Name = "Коля", Profile = "Информатика"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 19, Course = 2, Gender = Gender.Other, Group = "ПИ-126", Height = 190, IsHonor = false, Name = "Коля", Profile = "Бизнес"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 25, Course = 1, Gender = Gender.Male, Group = "ПИ-128", Height = 186, IsHonor = false, Name = "Оля", Profile = "Бизнес"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 18, Course = 2, Gender = Gender.Female, Group = "ПИ-126", Height = 186, IsHonor = true, Name = "Оля", Profile = "Информатика"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 18, Course = 3, Gender = Gender.Other, Group = "ПИ-128", Height = 190, IsHonor = false, Name = "Коля", Profile = "Информатика"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 25, Course = 1, Gender = Gender.Male, Group = "ПИ-126", Height = 186, IsHonor = true, Name = "Коля", Profile = "Информатика"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 18, Course = 1, Gender = Gender.Male, Group = "ПИ-126", Height = 170, IsHonor = false, Name = "Коля", Profile = "Информатика"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 25, Course = 1, Gender = Gender.Other, Group = "ПИ-128", Height = 186, IsHonor = true, Name = "Оля", Profile = "Информатика"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 20, Course = 2, Gender = Gender.Male, Group = "ПИ-126", Height = 190, IsHonor = false, Name = "Оля", Profile = "Бизнес"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 17, Course = 3, Gender = Gender.Male, Group = "ПИ-126", Height = 170, IsHonor = true, Name = "Оля", Profile = "Бизнес"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 25, Course = 2, Gender = Gender.Female, Group = "ПИ-126", Height = 190, IsHonor = true, Name = "Коля", Profile = "Бизнес"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 17, Course = 3, Gender = Gender.Other, Group = "ПИ-128", Height = 186, IsHonor = true, Name = "Оля", Profile = "Информатика"
                },
                new Student()
                {
                    Money = 5000,
                    Age = 17, Course = 2, Gender = Gender.Female, Group = "ПИ-126", Height = 186, IsHonor = false, Name = "Коля", Profile = "Бизнес"
                }
            };
        }
    }
}
