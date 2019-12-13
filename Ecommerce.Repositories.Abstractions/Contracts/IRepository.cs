using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories.Abstraction.Contracts
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
    }
}
