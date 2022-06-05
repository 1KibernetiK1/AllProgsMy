using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFeature4
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# 2.0
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            // C# 3.0
            var list2 = new List<int> { 10, 20, 30, 40, 50, 60 };

            // На словарях
            // C# 2.0
            Dictionary<int, string> dict1 = new Dictionary<int, string>();
            dict1.Add(74, "chelyabinsk");
            dict1.Add(45, "Kurgan");
            dict1.Add(96, "Ekat");
            dict1.Add(74, "");
            dict1.Add(74, "");

            // C# 3.0
            var dict2 = new Dictionary<int, string>()
            {
                {74, "chelyabinsk" },
                {45, "Kurgan" },
                {96, "Ekat" }
            };
        }
    }
}
