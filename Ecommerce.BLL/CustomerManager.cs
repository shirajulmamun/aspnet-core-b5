﻿using Ecommerce.BLL.Abstraction.Base;
using Ecommerce.BLL.Abstractions.Contracts;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstraction.Contracts;
using Ecommerce.Repositories.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class CustomerManager : Manager<Customer>, ICustomerManager
    {
        ICustomerRepository _customerRepository; 
        public CustomerManager(ICustomerRepository repository) : base(repository)
        {
            _customerRepository = repository;
        }
    }
}
