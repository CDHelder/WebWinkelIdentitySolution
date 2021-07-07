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
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DeleteModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
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

        public IActionResult OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isDeleted = _productRepository.DeleteProduct(id);

            if (isDeleted == true)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
