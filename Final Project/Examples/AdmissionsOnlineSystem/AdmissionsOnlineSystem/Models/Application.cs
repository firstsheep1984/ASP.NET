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

        public ICollection<EducationDetail> EducationDetails { get; set; }
        public ICollection<EnclosedDocument> EnclosedDocuments { get; set; }

        public virtual User User { get; set; }
    }
}