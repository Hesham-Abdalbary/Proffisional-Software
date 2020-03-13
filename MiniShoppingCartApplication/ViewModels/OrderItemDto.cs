using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.ViewModels
{
    public class OrderItemDto
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public CustomerOrderDto CustomerOrders { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
