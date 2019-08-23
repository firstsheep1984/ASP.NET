using FinalExam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalExam.ViewModels
{
    public class RunnersViewModel
    {
        public int RunnerId { get; set; }
        public string Name { get; set; }
        
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string EventName { get; set; }
        public string EventStatus { get; set; }
    }
}