using AdmissionsOnlineSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdmissionsOnlineSystem.Models
{
    public class Application
    {
        [ForeignKey("User")]
        public string ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelePhoneNumber { get; set; }
        public Department Department { get; set; }
        public Program Program { get; set; }
        public DateTime? RegistrationDate { get; set; }

        [Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<Status>(); }
        }

        [NotMapped]
        public Status Status { get; set; }

        public ICollection<EducationDetail> EducationDetails { get; set; }
        public ICollection<EnclosedDocument> EnclosedDocuments { get; set; }

        public virtual User User { get; set; }
    }
}