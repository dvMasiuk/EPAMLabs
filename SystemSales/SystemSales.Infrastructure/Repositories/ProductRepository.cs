using System.Collections.Generic;
using System.Linq;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public IEnumerable<Product> SearchByName(string name)
        {
            return Db.Products.Where(x => x.Name == name);
        }
    }
}