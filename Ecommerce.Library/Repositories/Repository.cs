using EcommerceApp.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Library.Repositories
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
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            Table.Remove(entity);
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
