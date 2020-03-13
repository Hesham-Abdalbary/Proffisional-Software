using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public virtual List<CustomerOrder> CustomerOrders { get; set; }
    }
}
