using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebWinkelIdentity.Data.Enitities;

namespace WebWinkelIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var category1 = new Category { Id = 1, Name = "Broek", Description = "Broek met wijde pijpen" };
            var category2 = new Category { Id = 2, Name = "T-shirt", Description = "T-shirt met korte mouwen" };

            var supplier1Id = Guid.NewGuid().ToString();
            var customer1Id = Guid.NewGuid().ToString();

            var address1 = new Address { Id = 1, City = "Amsterdam", Country = "Netherlands", HouseNumber = 15, PostalCode = "1264 KJ", Streetname = "Polderweg", SupplierId = supplier1Id };
            var address2 = new Address { Id = 2, City = "Rotterdam", Country = "Netherlands", HouseNumber = 5, PostalCode = "7431 GG", Streetname = "Sesamstraat", CustomerId = customer1Id };

            var product1 = new Product { Id = 1, Name = "Gucci T-shirt", AmountInStock = 4, Price = 39.95M, Description = "Witte kleur met gucci logo", BrandId = 1, CategoryId = 2, SupplierId = supplier1Id };
            var product2 = new Product { Id = 2, Name = "Gucci Broek", AmountInStock = 3, Price = 59.95M, Description = "Lichte broek met gucci logo", BrandId = 1, CategoryId = 1, SupplierId = supplier1Id };
            var product3 = new Product { Id = 3, Name = "Versace T-shirt", AmountInStock = 6, Price = 45.95M, Description = "Licht shirt met versace logo", BrandId = 2, CategoryId = 2, SupplierId = supplier1Id };
            var product4 = new Product { Id = 4, Name = "Versace Broek", AmountInStock = 2, Price = 69.95M, Description = "Donkere broek met versace logo", BrandId = 2, CategoryId = 1, SupplierId = supplier1Id };

            var brand1 = new Brand { Id = 1, Name = "Gucci", Description = "Veel te duur", SupplierId = supplier1Id };
            var brand2 = new Brand { Id = 2, Name = "Versace", Description = "Veel te duur", SupplierId = supplier1Id };

            var supplier1 = new Supplier
            {
                Id = supplier1Id,
                Name = "Kleding Groothandel de Bos",
                Description = "groothandel merkkleding",
                Email = "GroothandelDeBos@gmail.com",
                PhoneNumber = "01012346543",
                UserName = "Groothandeldebos"
            };
            var customer1 = new Customer
            {
                Id = customer1Id,
                Name = "Jaap",
                Email = "Jaap@gmail.com",
                UserName = "Jaap123"
            };

            //TODO: Refactor code per entity
            builder.Entity<Supplier>(s =>
            {
                s.ToTable("Suppliers");
                s.HasData(supplier1);
                s.HasMany(u => u.Addresses).WithOne().HasForeignKey(a => a.SupplierId);
                s.HasMany(u => u.Brands).WithOne(b => b.Supplier).HasForeignKey(f => f.SupplierId);
                s.HasMany(u => u.Products).WithOne().HasForeignKey(p => p.SupplierId);
            });

            builder.Entity<Customer>(c =>
            {
                c.ToTable("Customers");
                c.HasData(customer1);
                c.HasMany(u => u.Addresses).WithOne().HasForeignKey(a => a.CustomerId);
                c.HasMany(u => u.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);
            });

            builder.Entity<Product>(p =>
            {
                p.HasData(product1, product2, product3, product4);
                p.HasOne(u => u.Brand).WithMany(b => b.Products).HasForeignKey(p => p.BrandId);
                p.HasOne(u => u.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            });

            builder.Entity<Brand>(b =>
            {
                b.HasData(brand1, brand2);
                b.HasMany(u => u.Products).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId);
                b.HasOne(u => u.Supplier).WithMany(s => s.Brands).HasForeignKey(b => b.SupplierId);
            });

            builder.Entity<Address>(a =>
            {
                a.HasData(address1, address2);
            });

            builder.Entity<Category>(c =>
            {
                c.HasData(category1, category2);
                c.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            });

            builder.Entity<Order>(o =>
            {
                o.ToTable("Orders");
                o.Property(o => o.CustomerId).IsRequired();
            });
        }
    }
}
