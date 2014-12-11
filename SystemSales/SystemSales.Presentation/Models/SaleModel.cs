using System;
using System.ComponentModel.DataAnnotations;

namespace SystemSales.Presentation.Models
{
    public class SaleModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Product { get; set; }
        public string Customer { get; set; }
        public string Manager { get; set; }
    }
}