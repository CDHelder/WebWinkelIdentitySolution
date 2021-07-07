using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWinkelIdentity.Data;
using WebWinkelIdentity.Data.Enitities.StoreEntities;
using WebWinkelIdentity.Data.Repositories.Interfaces;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    public class EditStocksModel : PageModel
    {
        //TODO: Voorraad weergave van elke maat in elke winkel (VAN ALLEEN DIT PRODUCT) + mogelijkheid voorraad te wijzigen
        private readonly IProductRepository _productRepository;

        public EditStocksModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public List<ProductDetails> ProductDetails { get; set; }
        public Product Product { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);
            ProductDetails = _productRepository.GetAllProductDetails(id);

            if (ProductDetails == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (_productRepository.AddAllProductDetails(ProductDetails, Product.Id) != 0)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                return RedirectToPage($"./Details/{Product.Id}");
            }

            return Page();
        }
    }
}
