using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstraction.Base;
using Ecommerce.Repositories.Abstractions.Contracts;
using EcommerceApp.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        EcommerceDbContext _db; 
        public CustomerRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
