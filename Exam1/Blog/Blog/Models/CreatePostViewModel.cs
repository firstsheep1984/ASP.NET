﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class CreatePostViewModel
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? PostedOn { get; set; }
    }
}