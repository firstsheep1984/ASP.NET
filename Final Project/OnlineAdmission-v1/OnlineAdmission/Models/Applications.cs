using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdmission.Models
{
    
    public class Applications
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ApplicationID")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="User Account")]
        public string Userid { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Birthday")]
        public DateTime BirhtDate { get; set; }

        public Gender gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string TelephoneNumber { get; set; }

        public byte[] Photo { get; set; }

        public Program program { get; set; }

        [Display(Name = "Branch Office")]
        public Branch branch { get; set; }

        [Display(Name = "Registry Date")]
        public string RegistrationDate { get; set; }

        [Display(Name = "Application Status")]
        public Status status { get; set; }

    }

    public enum Status {
        Drafted,
        Submited,       
        Approved }
    public enum Gender { Male, Female, Other }
    public enum Program {Math, Science, Computer, Arts}

    public enum Branch { Lasalle, Laval, WestIsland, Downtown}

}



