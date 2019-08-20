using System;
using System.ComponentModel.DataAnnotations;

namespace VideoRental.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1) //allow for pay as you go
                return ValidationResult.Success;
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Customer should be at least 18 years old to go to a membership");
        }
    }
}