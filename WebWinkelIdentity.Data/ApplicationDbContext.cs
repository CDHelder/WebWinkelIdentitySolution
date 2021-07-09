﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebWinkelIdentity.Core;

namespace WebWinkelIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Store dbsets
        public DbSet<WeekOpeningTimes> WeekOpeningTimes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }

        //Products dbsets
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        //User dbsets
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //Order dbsets
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        //Webshop dbsets
        //public DbSet<CartProduct> CartProducts { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<WeekOpeningTimes> WeekOpeningTimes { get; set; }

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

            //builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var customer1Id = "52a5d716-a649-4476-b316-108d96c56112";
            var employee1Id = "7036d951-7cc8-488f-b95b-10c2e96c31c9";
            var supplier1Id = 1;

            var addresses = new List<Address>
            {
            new Address { Id = 1, City = "Amsterdam", Country = "Netherlands", HouseNumber = 15, PostalCode = "1264 KJ", Streetname = "Polderweg", SupplierId = supplier1Id, },
            new Address { Id = 2, City = "Rotterdam", Country = "Netherlands", HouseNumber = 5, PostalCode = "7431 GG", Streetname = "Sesamstraat", CustomerId = customer1Id },
            new Address { Id = 3, City = "Den Haag", Country = "Netherlands", HouseNumber = 26, PostalCode = "8137 YA", Streetname = "Korte poten" },
            new Address { Id = 4, City = "Rotterdam", Country = "Netherlands", HouseNumber = 12, PostalCode = "6573 IK", Streetname = "Lijnbaan" }
            };

            var categories = new List<Category>
            {
            new Category { Id = 1, Name = "Broek", Description = "Broek met wijde pijpen" },
            new Category { Id = 2, Name = "T-shirt", Description = "T-shirt met korte mouwen" }
            };
            var brands = new List<Brand>
            {
            new Brand { Id = 1, Name = "Gucci", Description = "Veel te duur", SupplierId = 1 },
            new Brand { Id = 2, Name = "Versace", Description = "Veel te duur", SupplierId = 1 }
            };

            var suppliers = new List<Supplier>
            {
            new Supplier
            {
                Id = supplier1Id,
                Name = "Kleding Groothandel de Bos",
                Description = "groothandel merkkleding",
                Email = "GroothandelDeBos@gmail.com",
                PhoneNumber = 01012346543
            }
            };
            var customers = new List<Customer>
            {
            new Customer
            {
                Id = customer1Id,
                Name = "Jaap",
                Email = "Jaap@gmail.com",
                UserName = "Jaap123"
            }
            };
            var employees = new List<Employee>
            {
            new Employee
            {
                Id = employee1Id,
                AddressId = 3,
                IBAN = "NL76 INGB 007 4201 6969",
                Name = "Samantha"
            }
            };

            var orderproducts = new List<OrderProduct>
            {
                new OrderProduct{ Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
                new OrderProduct{ Id = 2, OrderId = 1, ProductId = 2, Quantity = 1 },
                new OrderProduct{ Id = 3, OrderId = 1, ProductId = 3, Quantity = 1 },
                new OrderProduct{ Id = 4, OrderId = 1, ProductId = 4, Quantity = 1 }
            };
            var orders = new List<Order>
            {
                new Order
                { Id = 1, AddressId = 2, CustomerId = customer1Id, IsDelivered = false }
            };

            var stores = new List<Store>
            {
            new Store { Id = 1, AddressId = 4, WeekOpeningTimesId = 1 }
            };
            var storeemployees = new List<StoreEmployee>
            {
                new StoreEmployee{ Id = 1, EmployeeId = employee1Id, StoreId = 1  }
            };
            var storeproducts = new List<StoreProduct>
            { 
                new StoreProduct { StoreId = 1, ProductId = 1 },
                new StoreProduct { StoreId = 1, ProductId = 2 },
                new StoreProduct { StoreId = 1, ProductId = 3 },
                new StoreProduct { StoreId = 1, ProductId = 4 }
            };

            //TODO: Dataseeding van ProductDetails verplaatsen naar Products
            var products = new List<Product>
            {
            new Product { Id = 1, Name = "Gucci T-shirt", Price = 39.95M, Description = "Witte kleur met gucci logo", BrandId = 1, CategoryId = 2, Color = "White", Fabric = "100% Cotton", Size = "S", AmountInStock = 2 },
            new Product { Id = 2, Name = "Gucci T-shirt", Price = 39.95M, Description = "Witte kleur met gucci logo", BrandId = 1, CategoryId = 2, Color = "White", Fabric = "100% Cotton", Size = "M", AmountInStock = 2},
            new Product { Id = 3, Name = "Gucci T-shirt", Price = 39.95M, Description = "Witte kleur met gucci logo", BrandId = 1, CategoryId = 2, Color = "White", Fabric = "100% Cotton", Size = "L", AmountInStock = 2 },
            new Product { Id = 4, Name = "Gucci T-shirt", Price = 39.95M, Description = "Witte kleur met gucci logo", BrandId = 1, CategoryId = 2, Color = "White", Fabric = "100% Cotton", Size = "XL", AmountInStock = 1 },
            new Product { Id = 5, Name = "Gucci Broek", Price = 59.95M, Description = "Lichte broek met gucci logo", BrandId = 1, CategoryId = 1, Color = "Light-Blue", Fabric = "100% Cotton"},
            new Product { Id = 9, Name = "Versace T-shirt", Price = 45.95M, Description = "Licht shirt met versace logo", BrandId = 2, CategoryId = 2,  Color = "Light-Yellow", Fabric = "100% Cotton" },
            new Product { Id = 13, Name = "Versace Broek", Price = 69.95M, Description = "Donkere broek met versace logo", BrandId = 2, CategoryId = 1,  Color = "Dark-Blue", Fabric = "100% Cotton"}
            };
            var productdetails = new List<ProductDetails>
            {
            new ProductDetails { Id = 1, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, ProductId = 1,},
            new ProductDetails { Id = 2, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, ProductId = 1,},
            new ProductDetails { Id = 3, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, ProductId = 1,},
            new ProductDetails { Id = 4, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, ProductId = 1,},
            new ProductDetails { Id = 5, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, ProductId = 2,},
            new ProductDetails { Id = 6, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, ProductId = 2,},
            new ProductDetails { Id = 7, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, ProductId = 2, },
            new ProductDetails { Id = 8, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, ProductId = 2,},
            new ProductDetails { Id = 9, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, ProductId = 3,},
            new ProductDetails { Id = 10, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, ProductId = 3,},
            new ProductDetails { Id = 11, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, ProductId = 3,},
            new ProductDetails { Id = 12, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, ProductId = 3,},
            new ProductDetails { Id = 13, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, ProductId = 4,},
            new ProductDetails { Id = 14, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, ProductId = 4,},
            new ProductDetails { Id = 15, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, ProductId = 4,},
            new ProductDetails { Id = 16, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, ProductId = 4,}
            };

            var timespan9 = new TimeSpan(9, 0, 0);
            var timespan17 = new TimeSpan(17, 0, 0);
            var dayopeningtimes = new List<DayOpeningTime>
            {
            new DayOpeningTime { Id = 1, WeekOpeningTimesId = 1, Day = "Monday", OpeningTime = timespan9, ClosingTime = timespan17, IsClosed = false },
            new DayOpeningTime { Id = 2, WeekOpeningTimesId = 1, Day = "Tuesday", OpeningTime = timespan9, ClosingTime = timespan17, IsClosed = false },
            new DayOpeningTime { Id = 3, WeekOpeningTimesId = 1, Day = "Wednesday", OpeningTime = timespan9, ClosingTime = timespan17, IsClosed = false },
            new DayOpeningTime { Id = 4, WeekOpeningTimesId = 1, Day = "Thursday", OpeningTime = timespan9, ClosingTime = timespan17, IsClosed = false },
            new DayOpeningTime { Id = 5, WeekOpeningTimesId = 1, Day = "Friday", OpeningTime = timespan9, ClosingTime = timespan17, IsClosed = false },
            new DayOpeningTime { Id = 6, WeekOpeningTimesId = 1, Day = "Saterday", OpeningTime = timespan9, ClosingTime = timespan17, IsClosed = false },
            new DayOpeningTime { Id = 7, WeekOpeningTimesId = 1, Day = "Sunday", IsClosed = true }
            };
            var weekopeningtimes = new List<WeekOpeningTimes>
            {
            new WeekOpeningTimes { Id = 1 }
            };

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //TODO: ~Extra~ Refactor code per entity

            builder.Entity<Store>(s =>
            {
                s.ToTable("Stores");
                s.HasData(stores);
                s.HasOne(u => u.Address).WithOne().HasForeignKey<Store>(s => s.AddressId);
                s.HasMany(u => u.StoreEmployees).WithOne(se => se.Store).HasForeignKey(se => se.StoreId);
                s.HasOne(u => u.WeekOpeningTimes).WithOne().HasForeignKey<Store>(s => s.WeekOpeningTimesId);
            });

            builder.Entity<Product>(ps =>
            {
                ps.ToTable("Products");
                ps.HasData(products);
                ps.HasMany(u => u.ProductDetails).WithOne();
                //.HasForeignKey(pd => pd.ProductId);
                ps.HasOne(u => u.Brand).WithMany(b => b.Products).HasForeignKey(p => p.BrandId);
                ps.HasOne(u => u.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            });

            builder.Entity<StoreProduct>(sp => 
            {
                sp.ToTable("StoreProducts");
                sp.HasData(storeproducts);
                sp.HasKey(sp => new { sp.ProductId, sp.StoreId });
                sp.HasOne(sp => sp.Store).WithMany(s => s.StoreProducts).HasForeignKey(sp => sp.StoreId);
                sp.HasOne(sp => sp.Product).WithMany(s => s.StoreProducts).HasForeignKey(sp => sp.ProductId);
            });

            builder.Entity<ProductDetails>(ps =>
            {
                ps.ToTable("ProductDetails");
                ps.HasData(productdetails);
                ps.HasOne(pd => pd.Product).WithMany(p => p.ProductDetails).HasForeignKey(pd => pd.ProductId);
            });

            builder.Entity<WeekOpeningTimes>(wot =>
            {
                wot.ToTable("WeekOpeningTimes");
                wot.HasData(weekopeningtimes);
                wot.HasMany(u => u.DayOpeningTimes).WithOne().HasForeignKey(dot => dot.WeekOpeningTimesId);
            });

            builder.Entity<DayOpeningTime>(dot =>
            {
                dot.ToTable("DayOpeningTimes");
                dot.HasData(dayopeningtimes);
            });

            builder.Entity<Supplier>(s =>
            {
                s.ToTable("Suppliers");
                s.HasData(suppliers);
                s.HasMany(u => u.Addresses).WithOne().HasForeignKey(a => a.SupplierId);
                s.HasMany(u => u.Brands).WithOne(b => b.Supplier).HasForeignKey(f => f.SupplierId);
            });

            builder.Entity<Customer>(c =>
            {
                c.ToTable("Customers");
                c.HasData(customers);
                c.HasMany(u => u.Addresses).WithOne().HasForeignKey(a => a.CustomerId);
                c.HasMany(u => u.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);
            });

            builder.Entity<Order>(o =>
            {
                o.ToTable("Orders");
                o.HasData(orders);
                o.Property(o => o.CustomerId).IsRequired();
                o.HasMany(o => o.OrderProducts).WithOne().HasForeignKey(o => o.OrderId);
                o.HasOne(o => o.Address).WithMany().HasForeignKey(o => o.AddressId);
            });

            builder.Entity<OrderProduct>(op =>
            {
                op.ToTable("OrderProducts");
                op.HasData(orderproducts);
            });

            builder.Entity<Employee>(e =>
            {
                e.ToTable("Employees");
                e.HasData(employees);
                e.HasOne(u => u.Address).WithOne().HasForeignKey<Employee>(a => a.AddressId);
                e.HasMany(u => u.EmployeeStores).WithOne(es => es.Employee).HasForeignKey(es => es.EmployeeId);
            });

            builder.Entity<StoreEmployee>(se =>
            {
                se.ToTable("StoreEmployees");
                se.HasData(storeemployees);
            });

            builder.Entity<Address>(a =>
            {
                a.ToTable("Addresses");
                a.HasData(addresses);
            });

            builder.Entity<Brand>(b =>
            {
                b.ToTable("Brands");
                b.HasData(brands);
                b.HasMany(u => u.Products).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId);
                b.HasOne(u => u.Supplier).WithMany(s => s.Brands).HasForeignKey(b => b.SupplierId);
            });

            builder.Entity<Category>(c =>
            {
                c.ToTable("Categories");
                c.HasData(categories);
                c.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            });

            //TODO: ~WebWinkel~ Implement ShoppingCart
        }
    }
}
