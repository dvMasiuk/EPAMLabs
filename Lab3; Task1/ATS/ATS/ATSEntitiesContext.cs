namespace ATS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ATSEntitiesContext : DbContext
    {
        public ATSEntitiesContext()
            : base("name=ATSEntitiesContext")
        {
        }

        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Port> Ports { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<TariffPlan> TariffPlans { get; set; }
        public virtual DbSet<TelephoneNumber> TelephoneNumbers { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Call>()
                .Property(e => e.Duration)
                .HasPrecision(0);

            modelBuilder.Entity<Subscriber>()
                .HasMany(e => e.Calls)
                .WithRequired(e => e.Subscriber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TariffPlan>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TelephoneNumber>()
                .Property(e => e.Number)
                .IsFixedLength();
        }
    }
}
