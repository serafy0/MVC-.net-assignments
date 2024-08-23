using System.ComponentModel.DataAnnotations;

namespace task.Helper
{
    public class ExipirationDateAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (date <= DateTime.Now)
            {
                return new ValidationResult("Expiration date must be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
