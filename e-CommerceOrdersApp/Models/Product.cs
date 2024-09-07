using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace e_CommerceOrdersApp.Models
{
    public class Product
    {
        [DisplayName("Product Price")]
        [Required]
        [Range(1,99999,ErrorMessage = $"{nameof(this.Price)} should be between a valid number")]
        public double? Price { get; set; }

        [DisplayName("Product Quantity")]
        [Required]
        [Range(1, 99999, ErrorMessage = $"{nameof(this.Quantity)} should be between a valid number")]
        public int? Quantity { get; set; }
        
        [Required]
        public int? ProductCode { get; set; }
    }
}