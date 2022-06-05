using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLinq02
{
    public class StudentsStorage
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student()
                {
                    Money= 5000,
                    Age = 19,
                    Course = 1,
                    Gender = Gender.Male,
                    Group = "ПИ-126",
                    Height = 186,
                    IsHonor = false,
                    Name = "Коля",
                    Profile = "Информатика"
                },
                new Student()
               {
                Money= 5000,
                Age = 18,
                Course = 1,
                Gender = Gender.Female,
                Group = "ПИ-126",
                Height = 170,
                IsHonor = false,
                Name = "Надежда",
                Profile = "Информатика"
            },
            new Student()
            {
                Money= 5000,
                Age = 19,
                Course = 2,
                Gender = Gender.Male,
                Group = "ПИ-226",
                Height = 190,
                IsHonor = false,
                Name = "Анатолий",
                Profile = "Информатика"
            },
            new Student()
            {
                Money= 5000,
                Age = 18,
                Course = 2,
                Gender = Gender.Female,
                Group = "ПИ-226",
                Height = 1165,
                IsHonor = false,
                Name = "Нинель",
                Profile = "Информатика"
            },
            new Student()
            {
                Money= 5000,
                Age = 19,
                Course = 2,
                Gender = Gender.Male,
                Group = "БИ-208",
                Height = 165,
                IsHonor = true,
                Name = "Олег",
                Profile = "Бизнес"
            },
            new Student()
            {
                Money= 5000,
                Age = 18,
                Course = 2,
                Gender = Gender.Male,
                Group = "БИ-208",
                Height = 175,
                IsHonor = true,
                Name = "Ильяз",
                Profile = "Бизнес"
            },
             new Student()
            {
                Money= 5000,
                Age = 20,
                Course = 3,
                Gender = Gender.Male,
                Group = "ПИ-322",
                Height = 182,
                IsHonor = true,
                Name = "Олегсей",
                Profile = "Программирование"
            }
            };
            
        }
    }
}
