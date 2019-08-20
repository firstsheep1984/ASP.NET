using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VedioRental.Models
{
    public class MembershipType
    {
        [Required]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [Display(Name = "Payment Type")]
        public string Name { get; set; }
        
        public int SingUpfee { get; set; }
        public int DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}