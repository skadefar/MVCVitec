using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCVitec.Data;
using Newtonsoft.Json;
using MVCVitec.Models;

namespace MVCVitec.Controllers
{

    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductConnection connect = new ProductConnection();

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public IActionResult Index()
        {
            List<Product> products = connect.GetData();
            return View(products);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = connect.GetData().Find(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Price,ProductType,ProductKey,Description,RowVersion,ProductId")] Product product)
        {
            if (ModelState.IsValid)
            {
                string response = connect.PostData(product);
                return LocalRedirect(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = connect.GetData().Find(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, [Bind("Name,Price,ProductType,ProductKey,Description,RowVersion,ProductID")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    connect.PostData(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return LocalRedirect(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = connect.DeleteData(id);
            if (product == null)
            {
                return NotFound();
            }

            return LocalRedirect(nameof(Index));
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = connect.GetData().Find(x => x.ProductId == id);
            connect.DeleteData(id);
            return LocalRedirect(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return connect.GetData().Any(e => e.ProductId == id);
        }
    }
}
