using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    public class DetailsModel : PageModel
    {
        //TODO: Voorraad weergave van elke maat in elke winkel (VAN DIT PRODUCT)
        private readonly IProductRepository _productRepository;

        public DetailsModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public Product Product { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
