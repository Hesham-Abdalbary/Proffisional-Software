using Microsoft.EntityFrameworkCore;

namespace MiniShoppingCartApplication.Models
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ACER\HBARY;Initial Catalog=ShoppingCart;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(o => new { o.OrderID, o.ProductID });
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
