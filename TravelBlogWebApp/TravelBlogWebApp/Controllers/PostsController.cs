
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly IBlogService blogService;

        public PostsController(IPostService postService)
        {
           this.postService = postService;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(postService.GetAll());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || postService.GetAll == null)
            {
                return NotFound();
            }

            var post = postService.GetPostWithSectionsAndComments(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,DateTime,LikesNumber,BlogId,Id")] Post post)
        {
            if (ModelState.IsValid)
            {
                postService.Add(post);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", post.BlogId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || postService.GetAll() == null)
            {
                return NotFound();
            }

            var post =  postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", post.BlogId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,DateTime,LikesNumber,BlogId,Id")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    postService.Update(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", post.BlogId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || postService.GetAll() == null)
            {
                return NotFound();
            }

            var post = postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (postService.GetAll() == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Posts'  is null.");
            }
            var post = postService.GetById(id);
            if (post != null)
            {
                postService.Delete(post);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return postService.GetAll().Any(p => p.Id == id);
        }
    }
}
