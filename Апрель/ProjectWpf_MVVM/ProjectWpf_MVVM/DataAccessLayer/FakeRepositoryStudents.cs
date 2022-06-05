using ProjectWpf_MVVM.Domains;
using ProjectWpf_MVVM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWpf_MVVM.DataAccessLayer
{
    public class FakeRepositoryStudents :
        IRepository<Student>
    {
        protected List<Student> _list;

        public FakeRepositoryStudents()
        {
            _list = new List<Student>
            {
                new Student
                {
                    Age = 18,
                    Name = "Вася"
                },
                new Student
                {
                    Age = 18,
                    Name = "Петя"
                },
                new Student
                {
                    Age = 18,
                    Name = "Коля"
                },
                new Student
                {
                    Age = 18,
                    Name = "Толя"
                },
                new Student
                {
                    Age = 18,
                    Name = "Федя"
                }
            };
        }

        public void AddItem(Student item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetItems() => _list;

        public void UpdateItem(long id)
        {
            throw new NotImplementedException();
        }
    }
}
