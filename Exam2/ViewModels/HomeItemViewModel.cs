using HomeInventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeInventory.ViewModels
{
    public class HomeItemViewModel
    {
        public int HomeItemId { get; set; }
        [StringLength(100)]
        public string Model { get; set; }
        [StringLength(100)]
        public string SerialNumber { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public DateTime? When { get; set; }
        [StringLength(255)]
        public string Where { get; set; }
        [StringLength(255)]
        public string Warranty { get; set; }
        public double Price { get; set; }
    }
}