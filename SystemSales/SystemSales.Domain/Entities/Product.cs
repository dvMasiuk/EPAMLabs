using System.Collections.Generic;

namespace SystemSales.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Sale> Sales { get; set; }
    }
}
