using System;
using System.ComponentModel.DataAnnotations;

namespace ModelBinders.Models
{
    public class MovieDetailedInputModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Review")]
        public string Review { get; set; }

        [Display(Name = "Length in minutes")]
        public int LengthInMinutes { get; set; }

        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        public Address Address { get; set; }
    }
}