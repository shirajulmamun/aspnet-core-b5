
using Ecommerce.Repositories.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.BLL.Abstraction.Base
{
    public abstract class Manager<T> where T:class
    {
        IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }
      
        public virtual bool Add(T entity)
        {
            _repository.Add(entity);
            return true;

        }

        public virtual bool Update(T entity)
        {
            _repository.Update(entity);
            return true;
        }

        public virtual bool Remove(T entity)
        {
            _repository.Remove(entity);
            return true;
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
