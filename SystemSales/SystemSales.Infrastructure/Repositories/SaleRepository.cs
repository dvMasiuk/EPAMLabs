using System.Data.Entity;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public new void Update(Sale entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.Entry(entity.Manager).State = EntityState.Modified;
            Db.Entry(entity.Customer).State = EntityState.Modified;
            Db.Entry(entity.Product).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}