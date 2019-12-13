
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Repositories.Abstraction.Base
{
    public abstract class Repository<T> where T:class
    {
        DbContext _dbContext;

        DbSet<T> Table
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public virtual void Add(T entity)
        {
            Table.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual void Remove(T entity)
        {
            Table.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual T GetById(int id)
        {
           return Table.Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }
    }
}
