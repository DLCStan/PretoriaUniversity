using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Data;
using RazorPagesProduct.Models;

namespace RazorPagesProduct.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesProductContext _context;

        public IndexModel(RazorPagesProduct.Data.RazorPagesProductContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
