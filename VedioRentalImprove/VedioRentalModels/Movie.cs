using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name="Movie Name")]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        [Display(Name="Added Date")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Range(1,20)]
        [Display(Name="Number in stock")]
        public byte NumberInStock { get; set; }
        [Display(Name="Number Available")]
        public byte NumberAvailable { get; set; }
    }
}