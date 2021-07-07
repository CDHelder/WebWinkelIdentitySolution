using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.ProductEntities;
using WebWinkelIdentity.Data.Enitities.StoreEntities;
using WebWinkelIdentity.Data.Repositories.Interfaces;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Brand> GetAllBrands()
        {
            var brands = _dbContext.Brands
                .Include(b => b.Products)
                .Include(b => b.Supplier)
                .ToList();
            return brands;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _dbContext.Categories
                .Include(c => c.Products)
                .ToList();
            return categories;
        }

        public List<ProductDetails> GetAllProductDetails()
        {
            var productdetails = _dbContext.ProductDetails
                .Include(pd => pd.Product)
                .ToList();
            return productdetails;
        }

        public List<ProductDetails> GetAllProductDetails(int productId)
        {
            var productdetails = _dbContext.ProductDetails.Where(pd => pd.ProductId == productId)
                .Include(pd => pd.Product)
                .ToList();
            return productdetails;
        }

        public List<Product> GetAllProducts()
        {
            var products = _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductDetails)
                .Include(p => p.StoreProducts)
                .ToList();
            return products;
        }

        public List<ProductDetails> GetAllProductDetails(int productId, int storeid)
        {
            var productdetails = _dbContext.StoreProducts.Where(sp => sp.StoreId == storeid && sp.ProductId == productId).SelectMany(sp => sp.Product.ProductDetails)
                .Include(sp => sp.Product)
                .ToList();
            return productdetails;
        }

        public List<Product> GetAllStoreProducts(int storeid)
        {
            var products = _dbContext.StoreProducts.Where(sp => sp.StoreId == storeid).Select(sp => sp.Product)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductDetails)
                .ToList();
            return products;
        }

        public Product GetProduct(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductDetails)
                .FirstOrDefault(p => p.Id == id);
            return product;
        }

        public ProductDetails GetProductDetails(int productId)
        {
            var productdetails = _dbContext.ProductDetails
                .Include(sp => sp.Product)
                .FirstOrDefault(pd => pd.Id == productId);
            return productdetails;
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            var products = _dbContext.Products.Where(p => p.BrandId == brandId)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductDetails)
                .Include(p => p.StoreProducts)
                .ToList();
            return products;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            var products = _dbContext.Products.Where(p => p.CategoryId == categoryId)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductDetails)
                .Include(p => p.StoreProducts)
                .ToList();
            return products;
        }

        public Product AddProduct(Product product)
        {
            if(product != null)
            {
                _dbContext.Products.Add(product);
                foreach (var ProductDetail in product.ProductDetails)
                {
                    _dbContext.Add(ProductDetail);
                }
                if (SaveChangesAtleastOne() == true)
                {
                    return product;
                }
            }
            return null;
        }

        public List<Product> SearchProduct(string searchTerm)
        {
            var productdetails = _dbContext.StoreProducts.Where(pd =>
                pd.Product.Brand.Name.Contains(searchTerm) ||
                pd.Product.Brand.Supplier.Name.Contains(searchTerm) ||
                pd.Product.Category.Name.Contains(searchTerm) ||
                pd.Product.Color.Contains(searchTerm) ||
                pd.Product.Fabric.Contains(searchTerm) ||
                pd.Product.Name.Contains(searchTerm)
                ).Select(s => s.Product)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductDetails)
                .Include(p => p.StoreProducts)
                .ToList();

            return productdetails;
        }

        public List<Product> SearchProduct(string searchTerm, int storeId)
        {
            var productdetails = _dbContext.StoreProducts.Where(pd =>
                pd.Product.Brand.Name.Contains(searchTerm) ||
                pd.Product.Brand.Supplier.Name.Contains(searchTerm) ||
                pd.Product.Category.Name.Contains(searchTerm) ||
                pd.Product.Color.Contains(searchTerm) ||
                pd.Product.Fabric.Contains(searchTerm) ||
                pd.Product.Name.Contains(searchTerm) &&
                pd.StoreId == storeId
                ).Select(s => s.Product)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductDetails)
                .Include(p => p.StoreProducts)
                .ToList();

            return productdetails;
        }

        public Product UpdateProduct(Product product)
        {
            var excistingproduct = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (excistingproduct != null)
            {
                return product;
            }

            _dbContext.Products.Attach(product).State = EntityState.Modified;
            if (SaveChangesAtleastOne() == true)
            {
                return product;
            }

            return null;
        }

        public bool SaveChangesAtleastOne()
        {
            if(_dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                _dbContext.Products.Remove(product);
                if (SaveChangesAtleastOne() == true)
                {
                    return true;
                }
            }
            return false;
        }

        public int AddAllProductDetails(List<ProductDetails> productDetails, int productId)
        {
            foreach (var productDetail in productDetails)
            {
                if (productDetail != null && productId > 0 && productDetail.ProductId == productId)
                {
                    _dbContext.ProductDetails.Add(productDetail);
                }
            }

            if (SaveChangesAtleastOne() == true)
            {
                return productId;
            }

            return 0;
        }
    }
}
