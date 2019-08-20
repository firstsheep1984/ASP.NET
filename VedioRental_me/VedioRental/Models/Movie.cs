using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VedioRental.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        [Display(Name = "Added Date")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
        [Min18YearsIfAMember]
        public DateTime ReleaseDate { get; set; }
        [Range(1,20)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}