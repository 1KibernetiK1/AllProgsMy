using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_v2
{
    public enum Campare
    {
        course,
        first_name,
        last_name,
        marks,
        height,
        weight
    }

    public class Student : IComparable
    {

        public static Campare Campare;

        public override string ToString()
        {
            return string.Format("Курс-{0}, {1} {2}, средняя оценка - {3}, рост - {4}, вес - {5},", _course, _firstname, _lastname, _marks, _height, _weight);
        }

        public Student(int Course, string FirstName, string LastName, int Marks, int Height, int Weight)
        {
            _course = Course;
            _firstname = FirstName;
            _lastname = LastName;
            _marks = Marks;
            _height = Height;
            _weight = Weight;
        }

        private string _firstname;

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }



        private string _lastname;

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private int _marks;

        public int Marks
        {
            get { return _marks; }
            set { _marks = value; }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int _weight;

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private int _course;

        public int Course
        {
            get { return _course; }
            set { _course = value; }
        }



        public int CompareTo(object obj)
        {
            switch (Campare)
            {
                case Campare.weight:
                    return Compareweight(obj);
                case Campare.height:
                    return Compareheight(obj);
                case Campare.marks:
                    return Comparemarks(obj);
                case Campare.course:
                    return Comparecourse(obj);
                case Campare.first_name:
                    return CompareFirstName(obj);
                case Campare.last_name:
                    return CompareLastName(obj);

            }
            return 0;
        }


        private int CompareFirstName(object obj)
        {
            Student student = (Student)obj;

            if (student != null)
            {
                return _firstname.CompareTo(student._firstname);
            }
            else
                throw new Exception("Ошибка");
        }


        private int CompareLastName(object obj)
        {
            Student student = (Student)obj;

           

            if (student != null)
            {
                return _lastname.CompareTo(student._lastname);
            }
            else
                throw new Exception("Ошибка");

        }

        private int Comparecourse(object obj)
        {
            Student student = (Student)obj;

            if (student != null)
            {
                return _course.CompareTo(student._course);
            }
            else
                throw new Exception("Ошибка");
        }

        private int Comparemarks(object obj)
        {
            Student student = (Student)obj;

            int a = student.Marks;

            if (a == this.Marks) return 0;
            if (a > Marks) return -1;
            return 1;
        }

        private int Compareheight(object obj)
        {
            Student student = (Student)obj;

            int a = student.Height;

            if (a == this.Height) return 0;
            if (a > Height) return -1;
            return 1;
        }

        private int Compareweight(object obj)
        {
            Student student = (Student)obj;

            int d = student.Weight;

            if (d == this.Weight) return 0;
            if (d > Weight) return -1;
            return 1;
        }

       

    }
}
