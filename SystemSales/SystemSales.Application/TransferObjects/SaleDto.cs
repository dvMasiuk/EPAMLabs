using System;

namespace SystemSales.Application.TransferObjects
{
    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public ProductDto Product { get; set; }
        public CustomerDto Customer { get; set; }
        public ManagerDto Manager { get; set; }
    }
}