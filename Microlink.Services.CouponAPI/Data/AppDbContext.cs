using Microlink.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microlink.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { 
                    CouponId=1,
                    CouponCode="100FF",
                    DiscountAmount=10,
                    MinAmount=10,
                },
                new Coupon
                {
                    CouponId = 2,
                    CouponCode = "200FF",
                    DiscountAmount = 20,
                    MinAmount = 20,
                },
                new Coupon
                {
                    CouponId = 3,
                    CouponCode = "300FF",
                    DiscountAmount = 30,
                    MinAmount = 30,
                }
                );
        }
    }
}
