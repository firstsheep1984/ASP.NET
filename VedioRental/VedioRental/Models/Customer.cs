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
    }
}