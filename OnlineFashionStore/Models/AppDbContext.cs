﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineFashionStore.Models.DataModels;
using OnlineFashionStore.Models.ViewModels;

namespace OnlineFashionStore.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole,int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<About> Abouts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductColor>().HasKey(pc=>new {pc.ProductId,pc.ColorId});
            modelBuilder.Entity<ProductSize>().HasKey(ps=>new {ps.ProductId,ps.SizeId});
            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    Name = "New Trend",
                    Title = "Summer Sale Stylish",
                    Description = "TestDescription",
                    Image = "slideshow-character2.png"
                },
                new Slider
                {
                    Id = 2,
                    Name = "Another Trend",
                    Title = "Winter Sale Fashionable",
                    Description = "AnotherDescription",
                    Image = "slideshow-character1.png"
                }
                );

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                  new AppRole { Id = 2, Name = "User", NormalizedName = "USER" }
              );
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
              new AppUser
              {
                  Id = 1,
                  UserName = "sadiq.admin",
                  Name = "Ilkin",
                  Surname = "Novruzov",
                  PasswordHash = hasher.HashPassword(null, "Admin.1234"),
                  Email = "aynoagency@gmail.com",
                  EmailConfirmed = true,
                  NormalizedUserName= "SADIQ.ADMIN",
                  NormalizedEmail="aynoagency@GMAIL.COM",
                  LockoutEnabled=true,
                  SecurityStamp = Guid.NewGuid().ToString()
              }
              );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
       new IdentityUserRole<int> { UserId = 1, RoleId = 1 }
   );
            base.OnModelCreating(modelBuilder);
        }
    }
}
