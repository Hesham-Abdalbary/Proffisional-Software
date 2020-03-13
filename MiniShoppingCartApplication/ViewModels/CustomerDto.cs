using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.ViewModels
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public List<CustomerOrderDto> CustomerOrders { get; set; }
    }
}
