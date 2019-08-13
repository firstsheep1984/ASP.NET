using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class AddCommentViewModel
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        public string Content { get; set; }
    }
}