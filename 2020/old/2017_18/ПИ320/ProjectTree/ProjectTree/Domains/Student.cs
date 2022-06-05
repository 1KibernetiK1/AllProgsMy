using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTree.Domains
{
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public string Serialize()
        {
            return $"{Name} {Lastname} {Age}";
        }

        public static Student Parse(string text)
        {
            string[] parts = text.Split();
            var stud = new Student();
            stud.Name = parts[0];
            stud.Lastname = parts[1];
            int.TryParse(parts[2], out int age);
            stud.Age = age;
            return stud;
        }

        public override string ToString()
        {
            return $"Имя {Name} {Lastname}, {Age} лет";
            /*
                string.Format("Имя {0} {1}, {2} лет",
                               Name, Lastname, Age);
            */
        }
    }
}
