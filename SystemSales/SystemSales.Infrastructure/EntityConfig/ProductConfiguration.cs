using System.Data.Entity.ModelConfiguration;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.EntityConfig
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name)
                .IsRequired();
        }
    }
}
