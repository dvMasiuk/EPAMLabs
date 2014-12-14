using System.Collections.Generic;
using SystemSales.Domain.Entities;

namespace SystemSales.Domain.Contracts.Repositories
{
    public interface IManagerRepository : IRepositoryBase<Manager>
    {
        IEnumerable<Manager> SearchByName(string name);
    }
}
