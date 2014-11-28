using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
