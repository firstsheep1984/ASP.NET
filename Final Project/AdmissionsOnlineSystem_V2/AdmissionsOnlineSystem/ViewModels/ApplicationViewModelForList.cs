using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionsOnlineSystem.ViewModels
{
    public class ApplicationViewModelForList
    {
        [Display(Name ="Application Id")]
        public string ApplicationId { get; set; }
        [Display(Name ="Student Name")]
        public string StudentName { get; set; }
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name ="Program Name")]
        public string ProgramName { get; set; }
        [Display(Name ="Registration Date")]
        public DateTime? RegistrationDate { get; set; }
        [Display(Name ="Status")]
        public string Status { get; set; }
    }
}