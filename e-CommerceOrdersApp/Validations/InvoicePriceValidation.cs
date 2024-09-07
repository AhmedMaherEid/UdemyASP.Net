using e_CommerceOrdersApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace e_CommerceOrdersApp.Validations
{
    public class InvoicePriceValidation : ValidationAttribute
    {
        public string Products { get; set; }

        public InvoicePriceValidation(string products)
        {
            this.Products = products;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value != null)
            {
                PropertyInfo? produdsPropertyInfo = validationContext.ObjectType.GetProperty(Products);
                if (produdsPropertyInfo != null)
                {
                    List<Product>? productsList = produdsPropertyInfo.GetValue(validationContext.ObjectInstance) as List<Product>;

                    double? sum = 0;
                    if (productsList != null)
                    {
                        foreach (Product product in productsList)
                        {
                            sum += product.Price * product.Quantity;
                        }
                        
                        if ((double)value == sum) return ValidationResult.Success;
                        else
                        {
                            return new ValidationResult(ErrorMessage);
                        }
                    }

                }
                return null;
            }
            return null;

        }
    }
}
