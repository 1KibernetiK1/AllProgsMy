using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ProjectXmlSerialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student
                {
                    id = 1,
                    Age = 18,
                    Name = "Петя",
                    Group = "ПИ-124"
                },
                new Student
                {
                    id = 2,
                    Age = 19,
                    Name = "Ваня",
                    Group = "ПИ-125"
                }
            };

            // 1) Рефлексия
            Type t1 = students.GetType();

            // 2) либо специальный оператор Typeof()
            Type t2 = typeof(List<Student>);

            var xml = new XmlSerializer(t1);
            using (var fs = File.Create("students.xml"))
            {
                xml.Serialize(fs, students);
            }
            Console.WriteLine("Готово");
            Console.ReadLine();
        }
    }
}
