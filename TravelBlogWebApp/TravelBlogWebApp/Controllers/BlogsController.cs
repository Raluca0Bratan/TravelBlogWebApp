
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService blogService;

        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(blogService.GetAll());
        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || blogService.GetAll() == null)
            {
                return NotFound();
            }

            var blog = blogService.GetBlogWithDestinationsAndPosts(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogID,Author,Name")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blogService.Add(blog);
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || blogService.GetAll() == null)
            {
                return NotFound();
            }

            var blog =  blogService.GetById(id);
            if (blog == null) 
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,Name")] Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    blogService.Update(blog);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
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
            return View(blog);
        }

        // GET: Blogs/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || blogService.GetAll() == null)
            {
                return NotFound();
            }

            var blog = blogService.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (blogService.GetAll() == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Blogs'  is null.");
            }
            var blog = blogService.GetById(id);
            if (blog != null)
            {
                blogService.Delete(blog);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return (blogService.GetAll().Any(e => e.Id == id));
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult TravelTips()
        {
            return View();
        }
    }
}
