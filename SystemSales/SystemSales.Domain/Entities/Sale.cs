using System;

namespace SystemSales.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int ManagerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
