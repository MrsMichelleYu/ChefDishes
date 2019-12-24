using System.ComponentModel.DataAnnotations;
using System;

namespace ChefDishes.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public FutureDateAttribute()
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            var dt = (DateTime)value;
            if (dt <= DateTime.Now) //want a date in the past
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date must not be in the future");
        }
    }
    public class OlderAttribute : ValidationAttribute
    {
        public OlderAttribute()
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            var dt = (DateTime)value;
            if (DateTime.Now.Year - dt.Year >= 18) //want a date in the past
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Chef must be at least 18 years old");
        }
    }
}