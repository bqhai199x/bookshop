using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(x => new { x.OrderId, x.ProductId});
        }

        public virtual DbSet<Account> Accounts{ get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}
