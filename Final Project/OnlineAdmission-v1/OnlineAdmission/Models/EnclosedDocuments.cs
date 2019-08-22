using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineAdmission.Models
{
    public class EnclosedDocuments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Applications application { get; set; }

        //FK - Refer to Applications.Id
        public int applicationId { get; set; }

        [Display(Name = "Qualification")]
        public Qualification qualification { get; set; }

        [Display(Name = "Document Type")]
        public DocType doctype { get; set; }

        [Display(Name = "Document Name")]
        public DocName docname { get; set; }

        [Display(Name = "Document Links")]
        public string DocURL { get; set; }
    }

    public enum DocType {

        Language,
        Diploma,
        Award,
        Other
    }

    public enum DocName
    {

        TOEFL,
        ITELS,
        Bachelor,
        Master,
        PhD,
        Certificate,
        Other
    }

}