using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Data.Enitities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public bool IsDelivered { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}
