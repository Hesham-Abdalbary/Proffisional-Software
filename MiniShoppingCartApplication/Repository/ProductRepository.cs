using MiniShoppingCartApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Repository
{
    public class ProductRepository
    {
        private Context db = new Context();
        public List<Product> GetAll()
        {
            var products = db.Products.ToList();
            return products;
        }

        public Product GetByID(int productID)
        {
            var product = db.Products.Find(productID);
            return product;
        }

        public int Add(Product product)
        {
            db.Products.Add(product);
            var addProductResult = db.SaveChanges();
            return addProductResult;
        }

        public int Update(Product product)
        {
            db.Products.Update(product);
            return db.SaveChanges();
        }

        public int Delete(int productID)
        {
            db.Products.Remove(new Product() { ProductID = productID });
            return db.SaveChanges();
        }
    }
}
