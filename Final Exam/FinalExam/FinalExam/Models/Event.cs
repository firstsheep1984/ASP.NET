using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalExam.Models
{
    public class Event
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public bool? IsClosed { get; set; }
    }
}
