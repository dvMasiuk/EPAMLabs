using System.Data.Entity.ModelConfiguration;
using SystemSales.Domain.Entities;

namespace SystemSales.Infrastructure.EntityConfig
{
    public class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            Property(m => m.Name)
                .IsRequired();
        }
    }
}
