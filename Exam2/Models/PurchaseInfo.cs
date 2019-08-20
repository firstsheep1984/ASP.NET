using System;
using System.ComponentModel.DataAnnotations;

namespace HomeInventory.Models
{
    public class PurchaseInfo
    {
        public int PurchaseInfoId { get; set; }
        public DateTime? When { get; set; }
        [StringLength(255)]
        public string Where { get; set; }
        [StringLength(255)]
        public string Warranty { get; set; }
        public double Price { get; set; }

        public virtual HomeItem HomeItem { get; set; }
    }
}