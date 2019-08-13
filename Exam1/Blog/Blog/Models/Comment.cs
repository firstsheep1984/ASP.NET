using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Display(Name ="Creation Date")]
        public DateTime CreatedOn { get; set; }
        [Display(Name ="Modification Date")]
        public DateTime UpdatedOn { get; set; }
        [Required]
        [Display(Name ="Commented By")]
        public string UserFullName { get; set; }
        [Display(Name ="Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        [Display(Name ="Is published?")]
        public bool IsPublished { get; set; }
    }
}