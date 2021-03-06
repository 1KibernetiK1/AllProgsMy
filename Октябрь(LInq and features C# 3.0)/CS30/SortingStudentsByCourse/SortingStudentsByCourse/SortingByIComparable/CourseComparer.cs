using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingStudentsByCourse.SortingByIComparable
{
    public class CourseComparer : IComparer<string[]>
    {
        public int Compare(string[] x, string[] y)
        {
            int a = Convert.ToInt32(x[2]);
            int b = Convert.ToInt32(y[2]);

            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }

            return 0;
        }
    }
}
