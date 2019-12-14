using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCVitec.Data;
using MVCVitec.Models;

namespace MVCVitec.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserConnection connect = new UserConnection();

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<User> users = connect.GetData();
            return View(users);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = connect.GetData().Find(x => x.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserID, OwnerID, Email, Password, LastName, FirstMidName, Birthday, ZipCode, Phonenumber, RowVersion, Abonnoments, UserIs")] User user)
        {
            if (ModelState.IsValid)
            {
                string response = connect.PostData(user);
                return LocalRedirect(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = connect.GetData().Find(x => x.UserID == id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, [Bind("UserID, OwnerID, Email, Password, LastName, FirstMidName, Birthday, ZipCode, Phonenumber, RowVersion, Abonnoments, UserIs")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    connect.PostData(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
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
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = connect.DeleteData(id);
            if (user == null)
            {
                return NotFound();
            }

            return LocalRedirect(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = connect.GetData().Find(x => x.UserID == id);
            connect.DeleteData(id);
            return LocalRedirect(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return connect.GetData().Any(e => e.UserID == id);
        }
    }
}