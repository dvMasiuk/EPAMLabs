using System.Collections.Generic;
using System.Linq;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.Repositories
{
    public class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
        public IEnumerable<Manager> SearchByName(string name)
        {
            return Db.Managers.Where(x => x.Name == name);
        }
    }
}
