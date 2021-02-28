using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GendacMVCForAPI.Data;
using GendacMVCForAPI.Models;

namespace GendacMVCForAPI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Products
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }*/
        public async Task<IActionResult> Index(string productcategory, string searchString)
        {
            //ViewData["CurrentFilter"] = searchString;
            IQueryable<string> productQuery = from n in _context.Products
                                              orderby n.Category
                                              select n.Category;

            var products = from p in _context.Products
                           select p;

            if (!String.IsNullOrEmpty(productcategory))
            {
                products = products.Where(p => p.Category == productcategory);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            var prodCategoryVM = new ProductCategoryViewModel
            {
                CategoryList = new SelectList(await productQuery.Distinct().ToListAsync()),
                Products = await products.ToListAsync()
            };

            return View(prodCategoryVM);
        }
        
        /*
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "";

            var products = from s in _context.Products
                           select s;

            switch (sortOrder)
            {
                case "category_desc":
                    products = products.OrderByDescending(s => s.Category);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Id);
                    break;
            }

            return View(await products.AsNoTracking().ToListAsync());
        }*/

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.CategoryTypeId = new List<SelectListItem>
            {
                new SelectListItem {Text = "CategoryA", Value = "CategoryA"},
                new SelectListItem {Text = "CategoryB", Value = "CategoryB"},
                new SelectListItem {Text = "CategoryC", Value = "CategoryC"}
            };
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Id,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryTypeId = new List<SelectListItem>
            {
                new SelectListItem {Text = "CategoryA", Value = "CategoryA"},
                new SelectListItem {Text = "CategoryB", Value = "CategoryB"},
                new SelectListItem {Text = "CategoryC", Value = "CategoryC"}
            };
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Category,Id,Name,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
