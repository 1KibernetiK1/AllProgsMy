using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingStudentsByCourse.SortingByIComparable
{
    public class GroupComparer : IComparer<string[]>
    {
        public int Compare(string[] x, string[] y)
        {
            

            if (x[0].Length > y[0].Length)
            {
                return 1;
            }
            else if (x[0].Length < y[0].Length)
            {
                return -1;
            }

            return 0;
        }
    }
}
