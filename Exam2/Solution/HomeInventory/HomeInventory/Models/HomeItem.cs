using System.ComponentModel.DataAnnotations;

namespace HomeInventory.Models
{
    public class HomeItem
    {
        public int HomeItemId { get; set; }
        [StringLength(100)]
        public string Model { get; set; }
        [StringLength(100)]
        [Display(Name ="Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name ="Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public int PurchaseInfoId { get; set; }
        [Required]
        [Display(Name ="Purchase Info")]
        public PurchaseInfo PurchaseInfo { get; set; }
    }
}