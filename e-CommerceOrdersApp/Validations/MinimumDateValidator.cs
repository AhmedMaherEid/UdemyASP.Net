using System.ComponentModel.DataAnnotations;

namespace e_CommerceOrdersApp.Validations
{
    public class MinimumDateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime asDateAndTime;
                if (DateTime.TryParse((string)value, out asDateAndTime))
                {
                    if (asDateAndTime.Year >= 2000)
                    {
                        if (asDateAndTime.Month >= 1)
                        {
                            if (asDateAndTime.Day >= 1)
                            {
                                return ValidationResult.Success;
                            }
                            return new ValidationResult(ErrorMessage); ;
                        }
                        return new ValidationResult(ErrorMessage); ;
                    }
                    return new ValidationResult(ErrorMessage); 
                }
                return new ValidationResult("date has no valid value");
            }
            return new ValidationResult("OrderDate can't be blank");
        }
    }
}
