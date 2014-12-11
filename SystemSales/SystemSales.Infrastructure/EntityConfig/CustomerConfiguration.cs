using System.Data.Entity.ModelConfiguration;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.EntityConfig
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.Name)
                .IsRequired();
        }
    }
}
