using MiniShoppingCartApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Repository
{
    public class CustomerOrderRepository
    {
        private Context db = new Context();
        public List<CustomerOrder> GetAll()
        {
            var customerOrders = db.CustomerOrders.ToList();
            return customerOrders;
        }

        public CustomerOrder GetByID(int customerOrderID)
        {
            var customerOrders = db.CustomerOrders.Find(customerOrderID);
            return customerOrders;
        }

        public int Add(CustomerOrder customerOrder)
        {
            db.CustomerOrders.Add(customerOrder);
            var addCustomerOrderResult = db.SaveChanges();
            return addCustomerOrderResult;
        }

        public int Update(CustomerOrder customerOrder)
        {
            db.CustomerOrders.Update(customerOrder);
            return db.SaveChanges();
        }

        public int Delete(int customerOrderID)
        {
            db.CustomerOrders.Remove(new CustomerOrder() { CustomerOrderID = customerOrderID });
            return db.SaveChanges();
        }
    }
}
