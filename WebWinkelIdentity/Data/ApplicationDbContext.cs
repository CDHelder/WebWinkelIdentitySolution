using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebWinkelIdentity.Data.Enitities;
using WebWinkelIdentity.Data.Enitities.ProductEntities;
using WebWinkelIdentity.Data.Enitities.StoreEntities;
using WebWinkelIdentity.Data.Enitities.Users;
using WebWinkelIdentity.Data.Enitities.WebshopEntities;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Store dbsets
        public DbSet<WeekOpeningTimes> WeekOpeningTimes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }

        //Products dbsets
        public DbSet<StoreProductDetails> StoreProductDetails { get; set; }
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

            var supplier1Id = Guid.NewGuid().ToString();
            var customer1Id = Guid.NewGuid().ToString();
            var employee1Id = Guid.NewGuid().ToString();

            var addresses = new List<Address>
            {
            new Address { Id = 1, City = "Amsterdam", Country = "Netherlands", HouseNumber = 15, PostalCode = "1264 KJ", Streetname = "Polderweg", SupplierId = supplier1Id },
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
            new Brand { Id = 1, Name = "Gucci", Description = "Veel te duur", SupplierId = supplier1Id },
            new Brand { Id = 2, Name = "Versace", Description = "Veel te duur", SupplierId = supplier1Id }
            };
            var products = new List<Product>
            {
            new Product { Id = 1, Name = "Gucci T-shirt", Price = 39.95M, Description = "Witte kleur met gucci logo", BrandId = 1, CategoryId = 2, SupplierId = supplier1Id },
            new Product { Id = 2, Name = "Gucci Broek", Price = 59.95M, Description = "Lichte broek met gucci logo", BrandId = 1, CategoryId = 1, SupplierId = supplier1Id },
            new Product { Id = 3, Name = "Versace T-shirt", Price = 45.95M, Description = "Licht shirt met versace logo", BrandId = 2, CategoryId = 2, SupplierId = supplier1Id },
            new Product { Id = 4, Name = "Versace Broek", Price = 69.95M, Description = "Donkere broek met versace logo", BrandId = 2, CategoryId = 1, SupplierId = supplier1Id }
            };

            var suppliers = new List<Supplier>
            {
            new Supplier
            {
                Id = supplier1Id,
                Name = "Kleding Groothandel de Bos",
                Description = "groothandel merkkleding",
                Email = "GroothandelDeBos@gmail.com",
                PhoneNumber = "01012346543",
                UserName = "Groothandeldebos"
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
                Name = "Samantha",
                StoreId = 1
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
            new Store { Id = 1, AddressId = 4, WeekOpeningTimesId = 1,  }
            };
            var storeproducts = new List<StoreProduct>
            {
            new StoreProduct { Id = 1, ProductId = 1, StoreId = 1 },
            new StoreProduct { Id = 2, ProductId = 2, StoreId = 1 },
            new StoreProduct { Id = 3, ProductId = 3, StoreId = 1 },
            new StoreProduct { Id = 4, ProductId = 4, StoreId = 1 }
            };
            var storeproductdetails = new List<StoreProductDetails>
            {
            new StoreProductDetails { Id = 1, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, StoreProductId = 1},
            new StoreProductDetails { Id = 2, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, StoreProductId = 1},
            new StoreProductDetails { Id = 3, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, StoreProductId = 1},
            new StoreProductDetails { Id = 4, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, StoreProductId = 1},
            new StoreProductDetails { Id = 5, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, StoreProductId = 2},
            new StoreProductDetails { Id = 6, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, StoreProductId = 2},
            new StoreProductDetails { Id = 7, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, StoreProductId = 2},
            new StoreProductDetails { Id = 8, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, StoreProductId = 2},
            new StoreProductDetails { Id = 9, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, StoreProductId = 3},
            new StoreProductDetails { Id = 10, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, StoreProductId = 3},
            new StoreProductDetails { Id = 11, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, StoreProductId = 3},
            new StoreProductDetails { Id = 12, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, StoreProductId = 3},
            new StoreProductDetails { Id = 13, InternationalSizingType = "EU", Size = "S", AmountInStock = 2, StoreProductId = 4},
            new StoreProductDetails { Id = 14, InternationalSizingType = "EU", Size = "M", AmountInStock = 2, StoreProductId = 4},
            new StoreProductDetails { Id = 15, InternationalSizingType = "EU", Size = "L", AmountInStock = 2, StoreProductId = 4},
            new StoreProductDetails { Id = 16, InternationalSizingType = "EU", Size = "XL", AmountInStock = 1, StoreProductId = 4}
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
            //TODO: ~BIG~ Refactor code per entity

            builder.Entity<Store>(s =>
            {
                s.ToTable("Stores");
                s.HasData(stores);
                s.HasOne(u => u.Address).WithOne().HasForeignKey<Store>(s => s.AddressId);
                s.HasMany(u => u.Employees).WithOne();
                s.HasMany(u => u.StoreProducts).WithOne(ps => ps.Store).HasForeignKey(ps => ps.StoreId);
                s.HasOne(u => u.WeekOpeningTimes).WithOne().HasForeignKey<Store>(s => s.WeekOpeningTimesId);
            });

            builder.Entity<StoreProduct>(ps =>
            {
                ps.ToTable("StoreProducts");
                ps.HasData(storeproducts);
                ps.HasOne(u => u.Product).WithOne().HasForeignKey<StoreProduct>(ps => ps.ProductId);
                ps.HasOne(u => u.Store).WithMany(s => s.StoreProducts).HasForeignKey(ps => ps.StoreId);
                ps.HasMany(u => u.StoreProductDetails).WithOne().HasForeignKey(spd => spd.StoreProductId);
            });

            builder.Entity<StoreProductDetails>(ps =>
            {
                ps.ToTable("StoreProductDetails");
                ps.HasData(storeproductdetails);
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
                s.HasMany(u => u.Products).WithOne().HasForeignKey(p => p.SupplierId);
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
                e.HasOne(u => u.Address).WithOne().HasForeignKey<Address>(a => a.EmployeeId);
            });

            builder.Entity<Address>(a =>
            {
                a.ToTable("Addresses");
                a.HasData(addresses);
            });

            builder.Entity<Product>(p =>
            {
                p.ToTable("Products");
                p.HasData(products);
                p.HasOne(u => u.Brand).WithMany(b => b.Products).HasForeignKey(p => p.BrandId);
                p.HasOne(u => u.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
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

            //TODO: Implement ShoppingCart
        }
    }
}
