using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCVitec.Data;
using MVCVitec.Models;

namespace MVCVitec.Controllers
{
    [Route("api/[controller]")]
    public class ApiAbonnomentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly List<Abonnoment> abonnoments = new List<Abonnoment>();
        public ApiAbonnomentsController(ApplicationDbContext contextt)
        {
            this.context = contextt;
            if (this.context.Abonnoment.Count() == 0)
            {
                FillThatDb.PushProducts(contextt);
            }
        }

        // GET: api/ApiAbonnoments
        [HttpGet]
        public List<Abonnoment> GetAbonnoment()
        {
            var getAbonnoment = context.Abonnoment;
            foreach (var a in getAbonnoment)
            {
                abonnoments.Add(a);
            }
            return abonnoments;
        }

        // GET: api/ApiAbonnoments/5
        [HttpGet("{id}")]
        public Abonnoment GetAbonnoment( int id)
        {
            return abonnoments.Find(a => a.AbonnomentId == id);
            
        }

        // PUT: api/ApiAbonnoments/5
        [HttpPut("{id}")]
        public void PutAbonnoment(int id, Abonnoment abonnoment)
        {
            if (id != abonnoment.AbonnomentId)
            {
                BadRequest();
            }


            context.Entry(abonnoment).State = EntityState.Modified;
            context.SaveChanges(); }

        // POST: api/ApiAbonnoments
        [HttpPost]
        public void PostAbonnoment( Abonnoment abonnoment)
        {
            context.Add(abonnoment);
            context.SaveChanges();
               }

        // DELETE: api/ApiAbonnoments/5
        [HttpDelete("{id}")]
        public void DeleteAbonnoment( int id)
        {
            var abonnoment = context.Abonnoment.Find(id);
            try
            {
                context.Abonnoment.Remove(abonnoment);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {

                throw new Exception();
            }
        }

        private bool AbonnomentExists(int id)
        {
            return context.Abonnoment.Any(e => e.AbonnomentId == id);
        }
    }
}