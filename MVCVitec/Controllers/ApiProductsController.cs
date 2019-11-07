using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCVitec.Data;
using UCLVitecMV.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCVitec.Controllers
{
    [Route("api/[controller]")]
    public class ApiProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly List<Product> products = new List<Product>();

        public ApiProductsController (ApplicationDbContext context)
        {
            this.context = context;

            if (this.context.Product.Count() == 0)
            {
                FillThatDb.PushProducts(context);
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public List<Product> Get()
        {
            var getProducts = context.Product;
            foreach(var p in getProducts)
            {
                products.Add(p);
            }
            return products;
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return products.Find(p => p.ProductID == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async void Put(int id)
        {
            if(id == null)
            {
                BadRequest();
            }
            var p = context.Product.Find(id);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = context.Product.Find(id);
            try
            {
                context.Product.Remove(product);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new Exception();
            }
        }
    }
}
