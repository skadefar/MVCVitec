using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCVitec.Data;
using MVCVitec.Models;

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

        //public ActionResult<IEnumerable<Product>> Show()
        //{
        //    List<Product> getProducts = context.Product.ToList();

        //    return getProducts;
        //}
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
        public void Put(int id, Product product)
        {
            if(id != product.ProductID)
            {
                BadRequest();
            }

            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
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
