using AdmissionsOnlineSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionsOnlineSystem.ViewModels
{
    public class ApplicationViewModel
    {
        public string ApplicationId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelePhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
    }
}