using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineAdmission.Models
{
    public class EducationalDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Applications application { get; set; }

        //FK - Refer to Applications.Id
        public int applicationId { get; set; }

        public Qualification qualification { get; set; }

        public YearPassing yearPassing { get; set; }

        public DateTime DurationFrom { get; set; }

        public DateTime DurationTo { get; set; }

        [Display(Name="University")]
        public string BoardUniversity { get; set; }

        public string Subjects { get; set; }

        public double Percentage { get; set; }


    }


    public enum Qualification {

        HighSchool,
        College,
        Bachelor,
        Master,
        PhD
    }


    public enum YearPassing {
        OneYear,
        TwoYear,
        ThreeYear,
        FourYear
    }
}