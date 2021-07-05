using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities;

namespace WebWinkelIdentity.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            //builder.HasData(
            //    new Customer
            //    {
            //        Address = new List<Address>
            //        {
            //            new Address
            //            {
            //                Id = 1,
            //                City = "Rotterdam",
            //                Country = "Netherlands",
            //                HouseNumber = 12,
            //                PostalCode = "3541 GH",
            //                Streetname = "Sesamstraat"
            //            }
            //        },
            //        Email = "Jaap@gmail.com",
            //        Name = "Jaap",
            //        UserName = "Jaap123"
            //    },
            //    new Customer
            //    {
            //        Address = new List<Address>
            //        {
            //            new Address
            //            {
            //                Id = 2,
            //                City = "Rotterdam",
            //                Country = "Netherlands",
            //                HouseNumber = 67,
            //                PostalCode = "3754 JK",
            //                Streetname = "Winkelstraat"
            //            }
            //        },
            //        Email = "Henk@gmail.com",
            //        Name = "Henk",
            //        UserName = "HenkvandeBakker"
            //    });
        }
    }
}
