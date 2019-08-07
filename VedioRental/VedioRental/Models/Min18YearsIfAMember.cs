using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VedioRental.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            //     if(customer.MembershipTypeId == 1)
           // return ValidationResult.Success;
            if (movie.ReleaseDate == null)
                return new ValidationResult("Release Date is required");
            var age = DateTime.Today.Year - movie.ReleaseDate.Year;
            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Customer should be at least 18 years old to subscribe.");            
        }
    }
}