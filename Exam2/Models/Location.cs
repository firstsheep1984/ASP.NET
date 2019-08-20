using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeInventory.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}