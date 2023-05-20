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
    public class CommentsController : Controller
    {
        private readonly TravelBlogDbContext _context;
        private readonly ICommentService commentService;

        public CommentsController(TravelBlogDbContext context, ICommentService commentService)
        {
            _context = context;
            this.commentService = commentService;   
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var travelBlogDbContext = _context.Comments.Include(c => c.Post);
            return View(await travelBlogDbContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? commentId)
        {
            if (commentId == null || commentService.FindAll() == null)
            {
                return NotFound();
            }

            var comment = commentService.FindByCondition(c=>c.Id== commentId).FirstOrDefault();  
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PostId,DateTime,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? commentId)
        {
            if (commentId == null || commentService.FindAll() == null)
            {
                return NotFound();
            }

            var comment = commentService.FindByCondition(c=> c.Id== commentId).FirstOrDefault();    
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", comment.PostId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PostId,DateTime,Content")] Comment comment)
        {
            //if (id != comment.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    commentService.Update(comment);
                 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? commentId)
        {
            if (commentId == null || commentService.FindAll() == null)
            {
                return NotFound();
            }

            var comment = commentService.FindByCondition(c=>c.Id == commentId).FirstOrDefault(); 
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (commentService.FindAll() == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Comments'  is null.");
            }
            var comment = commentService.FindByCondition(c=>c.Id==id).FirstOrDefault();  
            if (comment != null)
            {
                commentService.Delete(comment);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
          return (_context.Comments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
