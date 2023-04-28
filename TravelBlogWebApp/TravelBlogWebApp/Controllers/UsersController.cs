using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IBlogService blogService;  

        public UsersController(IUserService userService)
        {
           this.userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
        
            return View(userService.GetAll());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || userService.GetAll()==null)
            {
                return NotFound();
            }

            var user = userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Email,Password,ProfilePicturePath,BlogId,Id")] User user)
        {
            if (ModelState.IsValid)
            {
               userService.Add(user);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", user.BlogId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null ||userService.GetAll() == null)
            {
                return NotFound();
            }

            var user = userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", user.BlogId); ;
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Username,Email,Password,ProfilePicturePath,BlogId,Id")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userService.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", user.BlogId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || userService.GetAll() == null)
            {
                return NotFound();
            }

            var user = userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (userService.GetAll() == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Users'  is null.");
            }
            var user = userService.GetById(id);
            if (user != null)
            {
                userService.Delete(user);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return userService.GetAll().Any(x => x.Id == id); 
        }
    }
}
