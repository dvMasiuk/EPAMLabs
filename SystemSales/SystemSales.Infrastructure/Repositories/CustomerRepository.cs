﻿using System.Collections.Generic;
using System.Linq;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public IEnumerable<Customer> SearchByName(string name)
        {
            return Db.Customers.Where(x => x.Name == name);
        }
    }
}
