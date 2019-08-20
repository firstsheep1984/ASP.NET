using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPartialViewResultDemo.Models
{
    public class CustomerModel
    {
        public int CustmerId { get; set; }
        public string CustomerName { get; set; }
        public CustomerAddress PermanantAddress { get; set; }
        public CustomerAddress PresentAddress { get; set; }

    }

    public class CustomerAddress
    {
        public string DoorNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinNumber { get; set; }
    }
}