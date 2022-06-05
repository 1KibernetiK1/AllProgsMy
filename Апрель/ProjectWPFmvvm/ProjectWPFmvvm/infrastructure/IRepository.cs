using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFmvvm.infrastructure
{

    /// <summary>
    /// Интерфейс Generic для репозитория
    /// Паттерн CRUD - Create, Read, Update, Delete
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetItems();

        void AddItem(T item);

        void DeleteItem(long id);

        void UpdateItem(long id);
    }
}
