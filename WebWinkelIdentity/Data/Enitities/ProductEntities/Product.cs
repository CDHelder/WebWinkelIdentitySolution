using System.Collections.Generic;
using WebWinkelIdentity.Data.Enitities.StoreEntities;

namespace WebWinkelIdentity.Data.Enitities.ProductEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Fabric { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
    }
}