using System.Data.Entity;
using SystemSales.Domain.Entities;
using SystemSales.Infrastructure.EntityConfig;

namespace SystemSales.Infrastructure
{
    public class SalesContext : DbContext
    {
        public SalesContext() : base("SystemSales") { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ManagerConfiguration());
            modelBuilder.Configurations.Add(new SaleConfiguration());
        }
    }
}
