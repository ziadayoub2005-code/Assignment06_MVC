using MVCGiza02.Data.DbContexts;
using MVCGiza02.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCGiza02.Validators
{
    // act as annotation - decorators - ...
    // implement - inherit
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // when value is valid / not valid
            // value : value or null
            if (value == null)
                return null; // skip validation
            // catch value/input (Name) - explicit casting 
            string Name = value.ToString();

            // search in DB with this value : 
            // found -> not unique -> Invalid
            // Not found -> unique -> valid
            // context -> Dbcontext
            using DigitalDbContext context = new DigitalDbContext();
            Employee Emp = context.Employees.FirstOrDefault(E => E.Name == Name);

            if(Emp != null)
            {
                //return new ValidationResult("Name Must Be unique");
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
