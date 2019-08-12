using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvc.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    
        [Required]
        [StringLength(255)]
        public string UserFullName { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public bool IsPublished { get; set; }
    }
   
}