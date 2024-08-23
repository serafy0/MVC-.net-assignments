using System.ComponentModel.DataAnnotations;
using task.Context;

namespace task.Helper
{
    public class UniqueCompanyNameAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ITIContext)validationContext.GetService(typeof(ITIContext));
            var companyName = value as string;

            if (context.Companies.Any(c => c.Name == companyName))
            {
                return new ValidationResult("Company name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
