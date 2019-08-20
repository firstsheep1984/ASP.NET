using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationSystem.Models
{
    public class Application
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
        //public int GenderId { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public Byte[] Photo { get; set; }

        public Program Program { get; set; }
        //public int ProgramId { get; set; }

        public Branch Branch { get; set; }
        //public int BranchId { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }




    }

    public enum Branch
    {
        DownTown,
        MacDonaldCampus
    }

    public enum Program
    {
        IPD,
        Network,
        Cisco,
        WebSecurity,
        WebDesign,
        MobileApplication
    }

    public enum Gender
    {
        Male,
        Female
    }
}