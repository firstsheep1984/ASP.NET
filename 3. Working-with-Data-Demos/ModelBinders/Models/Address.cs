using System.ComponentModel.DataAnnotations;

namespace ModelBinders.Models
{
    public class Address
    {
        [Display(Name = "Town")]
        public string Town { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}
