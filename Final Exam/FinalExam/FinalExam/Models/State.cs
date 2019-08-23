using System.ComponentModel.DataAnnotations;

namespace FinalExam.Models
{
    public class State
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}