using System.ComponentModel.DataAnnotations;

namespace AdmissionsOnlineSystem.ViewModels
{
    public class EducationDetailViewModel
    {
        public int? Id { get; set; }
        public string ApplicationId { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public string BoardUniversity { get; set; }
        [Required]
        public string Subjects { get; set; }
        [Required]
        public int Percentage { get; set; }
    }
}