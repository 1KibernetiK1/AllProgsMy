using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingStudentsByCourse
{
    public class Output
    {
        public void OutputList(List<string[]> list, string label)
        {
            Console.WriteLine(label);
            Console.WriteLine();

            foreach (string[] item in list)
                Console.WriteLine(item[0] + ", дата рождения: " + item[1] + ", Курс:" + item[2] + ", Группа: " + item[3]);

            Console.WriteLine();
        }
    }

}
