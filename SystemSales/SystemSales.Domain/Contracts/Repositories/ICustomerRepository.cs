using System.Collections.Generic;
using SystemSales.Domain.Entities;

namespace SystemSales.Domain.Contracts.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> SearchByName(string name);
    }
}
