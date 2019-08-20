using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Customer //: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime? Birthdate { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId != 1) //allow for pay as you go
            {
                var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
                if (age < 18)
                    yield return new ValidationResult("Customer should be at least 18 years old to go to a membership", new[] { "Birthdate"});
            }

            yield return new ValidationResult("Whatever happened", new[] { "Name" });
        }*/
    }
}