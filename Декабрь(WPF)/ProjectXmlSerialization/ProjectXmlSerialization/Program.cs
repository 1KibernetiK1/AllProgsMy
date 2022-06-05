using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectXmlSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Age = 18,
                    Name = "Алексей",
                    Group = "ПИ-124"
                },
                new Student
                {
                    Id = 2,
                    Age = 19,
                    Name = "Максим",
                    Group = "ПИ-225"
                }
            };

            // 1) рефлексия
            Type t1 = students.GetType();
            // 2) typeof()
            Type t2 = typeof(List<Student>);

            XmlSerializer xms = new XmlSerializer(t2); 
            using(var fs = File.Create("students.xml"))
            {
                xms.Serialize(fs, students);
            }
            Console.WriteLine("Готово!");
            Console.ReadKey();
        }
    }
}
