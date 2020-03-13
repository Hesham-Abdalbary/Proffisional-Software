using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.ViewModels
{
    public class CustomerOrderDto
    {
        public int CustomerOrderID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public int? CustomerID { get; set; }
        public CustomerDto Customer { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
