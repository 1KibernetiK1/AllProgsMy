using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWpf_MVVM.Infrastructure
{
    /// <summary>
    /// Интерфейс Generic для репозитория -
    /// паттерн CRUD - Create, Read, Update, Delete
    /// </summary>
    public interface IRepository<T>  
        where T : class, new()
    {
        IEnumerable<T> GetItems();

        void AddItem(T item);

        void DeleteItem(long id);

        void UpdateItem(long id);
    }
}
