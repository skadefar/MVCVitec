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
     public class ApiUsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly List<User> users = new List<User>();

        public ApiUsersController(ApplicationDbContext context)
        {
            this.context = context;

            if (this.context.User.Count() == 0)
            {
                FillThatDb.PushProducts(context);
            }
        }

        // GET: api/ApiUsers
        [HttpGet]
        public List<User> GetUser()
        {
            var getUsers = context.User;
            foreach (var u in getUsers)
            {
                users.Add(u);
            }
            return users;
        }

        // GET: api/ApiUsers/5
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return users.Find(u => u.UserID == id);

        }
        // POST: api/ApiUsers

        public void PostUser(User users)
        {
            context.Add(users);
            context.SaveChanges();
        }

        // PUT: api/ApiUsers/5
        [HttpPut("{id}")]
        public void Put(int id, User user)
        {
            if (id != user.UserID)
            {
                BadRequest();
            }

            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
        // DELETE: api/ApiUsers/5
        [HttpDelete("{id}")]
        public void DeleteUser( int id)
        {
            var user = context.User.Find(id);
            try
            {
                context.User.Remove(user);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new Exception();
            }
        }

       }
    }
