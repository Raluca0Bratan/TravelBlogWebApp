using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly TravelBlogDbContext _context;
        private readonly IPostService postService;
        private readonly ICommentService commentService;
     

        public PostsController(TravelBlogDbContext context,IPostService postService)
        {
            _context = context;
            this.postService = postService; 
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
          var posts = postService.FindAll(); 
           return View(posts);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || postService.FindAll() == null)
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
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DateTime,LikesNumber,BlogId")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id", post.BlogId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id", post.BlogId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DateTime,LikesNumber,BlogId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
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
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id", post.BlogId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Posts == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int postId, string content)
        {
            var post = postService.GetPostWithSectionsAndComments(postId);
            if (post == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(content))
            {
                var comment = new Comment
                {
                    PostId = postId,
                    UserId = 23 /* Get the currently logged in user's ID */,
                    DateTime = DateTime.Now,
                    Content = content
                };

                postService.AddCommentToPost(postId,comment);
               
            }

            return RedirectToAction("Details", new { id = postId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSection(int postId, string content, string title, IFormFile image)
        {
            var post = postService.GetPostWithSectionsAndComments(postId);
            if (post == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content) && image != null)
            {
                var section = new Section
                {
                    PostId = postId,
                    Title = title,
                    Content = content,
                    ImagePath = "/Images/rome.jpg",

                };

                postService.AddSectionToPost(postId,section);   
            }

            return RedirectToAction("Details", new { id = postId });
        }
    }
}
