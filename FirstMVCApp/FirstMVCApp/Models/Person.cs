using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMVCApp.Models
{
    public class Person
    {
        [Required(ErrorMessage = "The name is mandatory")]
        public string Name { get; set; }
        [Range(18,100,ErrorMessage = "The minimum age for registration is 18 years old")]
        public int Age { get; set; }
    }
}