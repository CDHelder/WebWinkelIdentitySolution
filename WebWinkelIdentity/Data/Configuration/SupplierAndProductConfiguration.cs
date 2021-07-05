using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities;

namespace WebWinkelIdentity.Data.Configuration
{
    public class SupplierAndProductConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            //var supplier1 = new Supplier{ Name = "Kleding Groothandel de Bos", Description = "groothandel merkkleding", Email = "GroothandelDeBos@gmail.com", PhoneNumber = "01012346543", UserName = "Groothandeldebos"};

            //var address1 = new Address { Id = 1, City = "Amsterdam", Country = "Netherlands", HouseNumber = 15, PostalCode = "1264 KJ", Streetname = "Polderweg"};

            //var brand1 = new Brand { Id = 1, Name = "Gucci", Description = "Veel te duur"};
            //var brand2 = new Brand { Id = 2, Name = "Versace", Description = "Veel te duur"};

            //var product1 = new Product{ Name = "Gucci T-shirt", AmountInStock = 4, Price = 39.95M, Description = "Witte kleur met gucci logo"};
            //var product2 = new Product{ Name = "Gucci Broek", AmountInStock = 3, Price = 59.95M, Description = "Lichte broek met gucci logo"};
            //var product3 = new Product{ Name = "Versace T-shirt", AmountInStock = 6, Price = 45.95M, Description = "Licht shirt met versace logo"};
            //var product4 = new Product{ Name = "Versace Broek", AmountInStock = 2, Price = 69.95M, Description = "Donkere broek met versace logo"};

            //var category1 = new Category{ Id = 1, Name = "Broek", Description = "Broek met wijde pijpen"};
            //var category2 = new Category{ Id = 2, Name = "T-shirt", Description = "T-shirt met korte mouwen"};

            //product1.Category.Id = 2;
            //product1.BrandId = 1;
            //product2.Category.Id = 1;
            //product2.BrandId = 1;
            //product3.Category.Id = 2;
            //product3.BrandId = 2;
            //product4.Category.Id = 1;
            //product4.BrandId = 2;

            //brand1.Products.Add(product1);
            //brand1.Products.Add(product2);
            //brand2.Products.Add(product3);
            //brand2.Products.Add(product4);

            //supplier1.Address.Add(address1);
            //supplier1.Brands.Add(brand1);
            //supplier1.Brands.Add(brand2);
            //supplier1.Products.Add(product1);
            //supplier1.Products.Add(product2);
            //supplier1.Products.Add(product3);
            //supplier1.Products.Add(product4);

            //builder.HasData(
            //    new Supplier
            //    {
            //        Address = new List<Address>
            //        {
            //            new Address
            //            {
            //                Id = 3,
            //                City = "Amsterdam",
            //                Country = "Netherlands",
            //                HouseNumber = 15,
            //                PostalCode = "1264 KJ",
            //                Streetname = "Polderweg"
            //            }
            //        },

            //        Name = "Kleding Groothandel de Bos",
            //        Description = "groothandel merkkleding",
            //        Email = "GroothandelDeBos@gmail.com",
            //        PhoneNumber = "01012346543",
            //        UserName = "Groothandeldebos",
            //        Brands = new List<Brand>
            //        {
            //            new Brand
            //            {
            //                Id = 1,
            //                Name = "Gucci",
            //                Description = "Veel te duur",
            //                Products = new List<Product>
            //                {
            //                    new Product
            //                    {
            //                        Id = 1,
            //                        Name = "Gucci T-shirt",
            //                        AmountInStock = 4,
            //                        Price = 39.95M,
            //                        Description = "Witte kleur met gucci logo",
            //                        BrandId = 1,
            //                        Category = new Category
            //                        {
            //                            Id = 1,
            //                            Name = "T-shirt",
            //                            Description = "T-shirt met korte mouwen"
            //                        }
            //                    },
            //                    new Product
            //                    {
            //                        Id = 2,
            //                        Name = "Gucci Broek",
            //                        AmountInStock = 3,
            //                        Price = 69.96M,
            //                        Description = "Licht gekleurde gucci broek",
            //                        BrandId = 1,
            //                        Category = new Category
            //                        {
            //                            Id = 2,
            //                            Name = "Broek",
            //                            Description = "Broek met wijde pijpen"
            //                        }
            //                    }
            //                }
            //            },
            //            new Brand
            //            {
            //                Id = 2,
            //                Name = "Versace",
            //                Description = "Normaal doen met die prijs",
            //                Products = new List<Product>
            //                {
            //                    new Product
            //                    {
            //                        Id = 3,
            //                        Name = "Versace T-shirt",
            //                        AmountInStock = 6,
            //                        Price = 46.95M,
            //                        BrandId = 2,
            //                        Description = "Witte kleur met versace logo",
            //                        CategoryId = 1
            //                    },
            //                    new Product
            //                    {
            //                        Id = 4,
            //                        Name = "Gucci Broek",
            //                        AmountInStock = 3,
            //                        Price = 69.96M,
            //                        Description = "Licht gekleurde gucci broek",
            //                        BrandId = 2,
            //                        CategoryId = 2
            //                    }
            //                }
            //            }
            //        },
            //        Products = new List<Product>
            //        {
            //            new Product
            //            {
            //                Id = 1
            //            },
            //            new Product
            //            {
            //                Id = 2
            //            },
            //            new Product
            //            {
            //                Id = 3
            //            },
            //            new Product
            //            {
            //                Id = 4
            //            }
            //        }
            //    });

            //builder.OwnsMany(s => s.Address).HasData(
            //    new Address
            //    {
            //        Id = 3,
            //        City = "Amsterdam",
            //        Country = "Netherlands",
            //        HouseNumber = 15,
            //        PostalCode = "1264 KJ",
            //        Streetname = "Polderweg"
            //    });
        }
    }
}
