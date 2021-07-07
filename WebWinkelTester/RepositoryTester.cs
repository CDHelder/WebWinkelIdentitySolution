using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWinkelIdentity.Data;
using WebWinkelIdentity.Data.Enitities.StoreEntities;
using WebWinkelIdentity.Data.Repositories;
using WebWinkelIdentity.Data.Repositories.Interfaces;
using WebWinkelIdentity.Data.StoreEntities;
using Xunit;

namespace WebWinkelTester
{
    public class RepositoryTester
    {
        [Fact]
        public void SearchProducts()
        {
            
        }

        public void SearchProductsInStore(string searchTerm, int storeId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllStoreProducts(int storeid)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ProductDetails GetProductDetails(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetails> GetAllProductDetails()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetails> GetAllProductDetails(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetails> GetAllStoreProductDetails(int storeid)
        {
            throw new NotImplementedException();
        }
    }
}
