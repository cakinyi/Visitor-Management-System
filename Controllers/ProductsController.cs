using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using InventoryManagement.Repository;
using Rotativa;
using Rotativa.AspNetCore;

namespace InventoryManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;
        ProductRepository productRepository = new ProductRepository();


        public ProductsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name, Email,Phone,VisitingDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                if (_context.Products.Any(a => a.Phone.Equals(products.Phone)) || _context.Products.Any(a => a.Email.Equals(products.Email)))
                {
                    return BadRequest("Email Id or Phone Number already exists. Go back to edit");
                }
                else
                {
                    _context.Add(products);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId, Name, Email, Phone, VisitingDate")] Products products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductId))
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
            return View(products);
        }

        public ActionResult Approve(Products model)
        {
            int data = productRepository.Approve(model);
            if (data != 0)
            {
                TempData["Approve"] = data;
                TempData["res"] = 1;
                return RedirectToAction("Index");
            }
            else
                return View("Index");

        }

        public ActionResult Reject(Products model)
        {
            int data = productRepository.Reject(model);
            if (data != 0)
            {
                TempData["Reject"] = data;
                TempData["res"] = 1;
                return RedirectToAction("Index");
            }
            else
                return View("Index");

        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
  
        public ActionResult ConvertToPdf(int productId)
        {
            var model = productRepository.GetVisitors(productId);
            return new ViewAsPdf("Visitor", model)
            { FileName = "Visitor.pdf" }; 
        }
        //public ActionResult ConvertToPdf_Dates(Products model)
        //{
        //    return new ViewAsPdf("Visitors", model)
        //    { FileName = "Visitors.pdf" };
        //}
        public async Task<IActionResult> SortByDate()
        {
            return View(await _context.Products.ToListAsync());
        }
        
        [HttpPost]
        public ActionResult SortByDate(DateTime Start, DateTime End)
        {
            var model = productRepository.SearchDate(Start, End);
            return View(model);
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
