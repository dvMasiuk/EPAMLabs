﻿using SystemSales.Domain.Contracts;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>,ICustomerRepository
    {
    }
}
