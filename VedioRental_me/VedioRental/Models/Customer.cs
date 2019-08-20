using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VedioRental.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            //     if(customer.MembershipTypeId == 1)
            // return ValidationResult.Success;
            if (movie.ReleaseDate == null)
                yield return new ValidationResult("Release Date is required");
            var age = DateTime.Today.Year - movie.ReleaseDate.Year;
            yield return (age >= 18) ? ValidationResult.Success :
                            new ValidationResult("Customer should be at least 18 years old to subscribe.");

            // if(age<18)
            // yield return new ValidationResult("Customer should be at least 18 years old to subscribe.", new[]{"Birthdate"});
            //yield return new ValidationResult("whatever happened", new[]{"Name"});
        }
    }
}