using ProjectWPFmvvm.Domains;
using ProjectWPFmvvm.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFmvvm.dataAccessLayer
{
    /// <summary>
    /// Для бд(прописывать все сюда с бд)
    /// </summary>
    public class FakeRepositoryStudents : IRepository<Student>
    {
        protected List<Student> _list;

        public FakeRepositoryStudents()
        {
            _list = new List<Student>
            {
                new Student
                {
                    Name = "Маша",
                    Age = 19
                },
                 new Student
                {
                    Name = "Маша",
                    Age = 19
                },
                  new Student
                {
                    Name = "Маша",
                    Age = 19
                },
                   new Student
                {
                    Name = "Маша",
                    Age = 19
                },
                    new Student
                {
                    Name = "Маша",
                    Age = 19
                },
                     new Student
                {
                    Name = "Маша",
                    Age = 19
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
