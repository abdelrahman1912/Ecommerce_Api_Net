using ECommerce.db.Entities;
using ECommerce.db.Entities.Identity;
using ECommerce.db.Entities.Payments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.db.Context
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
       public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
              new IdentityRole
            {
                Id = "1986e795-108a-4627-b3c9-92b180942de8",
                  Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "5a516631-e39e-4da6-be12-b5984c83158f",
                Name = "User",
                NormalizedName = "USER"
            });

            builder.Entity<PaymentMethod>().HasData(
            new PaymentMethod
            {
                Id = Guid.Parse("84434475-45f6-445f-93d4-5e7d68f88f0b"),
                Name = "Cash"
            },
            new PaymentMethod
            {
                Id = Guid.Parse("3725624f-97e9-4c2f-837c-75422d6e5514"),
                Name = "Visa Card"
            });
        }
    }
}
