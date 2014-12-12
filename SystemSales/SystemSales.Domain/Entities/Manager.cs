using System.Collections.Generic;

namespace SystemSales.Domain.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Sale> Sales { get; set; }
    }
}
