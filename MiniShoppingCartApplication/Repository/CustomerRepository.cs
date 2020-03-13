using MiniShoppingCartApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Repository
{
    public class CustomerRepository
    {
        private Context db = new Context();
        public List<Customer> GetAll()
        {
            var customers = db.Customers.ToList();
            return customers;
        }

        public Customer GetByID(int customerID)
        {
            var customer = db.Customers.Find(customerID);
            return customer;
        }

        public int Add(Customer customer)
        {
            db.Customers.Add(customer);
            var addCustomerResult = db.SaveChanges();
            return addCustomerResult;
        }

        public int Update(Customer customer)
        {
            db.Customers.Update(customer);
            return db.SaveChanges();
        }

        public int Delete(int customerID)
        {
            db.Customers.Remove(new Customer() { CustomerID = customerID });
            return db.SaveChanges();
        }
    }
}
