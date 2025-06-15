using System;
using System.ComponentModel.DataAnnotations;

namespace BookModelValidation.Models
{
    public class PublishedDateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Today;
            }
            return false;
        }
    }
}
