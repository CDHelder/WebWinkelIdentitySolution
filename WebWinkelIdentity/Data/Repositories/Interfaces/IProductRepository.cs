using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.ProductEntities;
using WebWinkelIdentity.Data.Enitities.StoreEntities;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> SearchProduct(string searchTerm);
        public List<Product> SearchProduct(string searchTerm, int storeId);

        public Product GetProduct(int id);
        public List<Product> GetAllProducts();
        public List<Product> GetAllStoreProducts(int storeid);
        public List<Product> GetProductsByBrand(int brandId);
        public List<Product> GetProductsByCategory(int categoryId);

        public ProductDetails GetProductDetails(int productId);
        public List<ProductDetails> GetAllProductDetails();
        public List<ProductDetails> GetAllProductDetails(int productId);
        public List<ProductDetails> GetAllStoreProductDetails(int storeid);

        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int id);
        public bool SaveChanges();

        public List<Brand> GetAllBrands();
        public List<Category> GetAllCategories();
    }
}
