using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalExam.Models
{
    public class Runner
    {
        public int RunnerId { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        [StringLength(15)]
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ContactPersonName { get; set; }
        [StringLength(15)]
        public string ContactPersonTelephone { get; set; }
        public Event Event { get; set; }
        public int EventId { get; set; }

    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}