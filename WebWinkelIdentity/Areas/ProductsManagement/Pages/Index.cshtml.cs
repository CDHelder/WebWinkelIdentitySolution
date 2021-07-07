using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWinkelIdentity.Data;
using WebWinkelIdentity.Data.Repositories.Interfaces;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IList<Product> Product { get;set; }

        public void OnGetAsync()
        {
            Product = _productRepository.GetAllProducts();
        }
    }
}
