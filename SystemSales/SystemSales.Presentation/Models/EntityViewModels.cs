using System;
using System.ComponentModel.DataAnnotations;
using Grid.Mvc.Ajax.GridExtensions;

namespace SystemSales.Presentation.Models
{
    public class SalesDataViewModel
    {
        public AjaxGrid<SaleViewModel> SaleGrid;
    }

    public class SaleViewModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Manager Name")]
        public ManagerViewModel Manager { get; set; }

        [Display(Name = "Customer Name")]
        public CustomerViewModel Customer { get; set; }

        [Display(Name = "Product Name")]
        public ProductViewModel Product { get; set; }

        [Required]
        public double Sum { get; set; }
    }

    public class CustomerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class ManagerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}