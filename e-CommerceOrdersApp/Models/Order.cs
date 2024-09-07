using e_CommerceOrdersApp.Validations;
using System.ComponentModel.DataAnnotations;

namespace e_CommerceOrdersApp.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }
        
        [Required]
        [MinimumDateValidator]
        public string? OrderDate { get; set; }

        [Required]
        [InvoicePriceValidation(nameof(Products), ErrorMessage = "InvoicePrice doesn't match with the total cost of the specified products in the order.")]
        public double? InvoicePrice { get; set; }
        [Required]
        public List<Product>? Products { get; set; }
    }
}
