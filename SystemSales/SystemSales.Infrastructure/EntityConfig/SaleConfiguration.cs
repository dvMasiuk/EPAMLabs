using System.Data.Entity.ModelConfiguration;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.EntityConfig
{
    public class SaleConfiguration : EntityTypeConfiguration<Sale>
    {
        public SaleConfiguration()
        {
            Property(s => s.Date)
                .IsRequired();
            Property(s => s.Sum)
                .IsRequired();
        }
    }
}
