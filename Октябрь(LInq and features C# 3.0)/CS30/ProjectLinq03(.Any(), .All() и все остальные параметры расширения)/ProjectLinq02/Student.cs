using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLinq02
{
    public enum Gender { Male, Female}

    public class Student
    {
        public int Money { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Course { get; set; }

        public string Group { get; set; }

        public string Profile { get; set; }

        public int Height { get; set; }

        public bool IsHonor { get; set; }

        public Gender Gender { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} years, ({2}), [{3}], {4} cm", Name, Age, Group, Profile, Height);
        }
    }
}
