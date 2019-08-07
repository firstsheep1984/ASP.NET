using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scaffolding2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsFeatured { get; set; }
        public PostType Type { get; set; }
    }

    public enum PostType
    {
        BlogPost,
        NewsPost,
        ShopPost
    }
}