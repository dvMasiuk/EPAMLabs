using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SystemSales.Presentation.Models
{
    public class SaleViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ManagerViewModel Manager { get; set; }

        public CustomerViewModel Customer { get; set; }

        public ProductViewModel Product { get; set; }

        [Required]
        public double Sum { get; set; }
    }

    public class CustomerViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
    }

    public class ProductViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
    }

    public class ManagerViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Manager Name")]
        public string Name { get; set; }
    }
}