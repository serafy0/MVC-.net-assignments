using System.ComponentModel.DataAnnotations;

namespace task.Helper
{
    public class ManufactureDateAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (date >= DateTime.Now)
            {
                return new ValidationResult("Manufacture date must be in the past.");
            }

            return ValidationResult.Success;
        }
    }
}
