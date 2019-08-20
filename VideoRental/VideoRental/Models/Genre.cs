using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Genre
    {
        [Required]
        public byte Id { get; set; }
        [StringLength(255)]
        [Required]
        [Display(Name="Genre")]
        public string Name { get; set; }

    }
}