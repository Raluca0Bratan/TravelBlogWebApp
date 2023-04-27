using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.Controllers
{
    public class SectionsController : Controller
    {
        private readonly TravelBlogDbContext _context;

        public SectionsController(TravelBlogDbContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var travelBlogDbContext = _context.Sections.Include(s => s.Post);
            return View(await travelBlogDbContext.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sections == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Post)
                .FirstOrDefaultAsync(m => m.SectionID == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            ViewData["PostID"] = new SelectList(_context.Posts, "PostID", "PostID");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectionID,Title,Content,ImagePath,PostID")] Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostID"] = new SelectList(_context.Posts, "PostID", "PostID", section.PostID);
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sections == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            ViewData["PostID"] = new SelectList(_context.Posts, "PostID", "PostID", section.PostID);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionID,Title,Content,ImagePath,PostID")] Section section)
        {
            if (id != section.SectionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(section);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.SectionID))
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
            ViewData["PostID"] = new SelectList(_context.Posts, "PostID", "PostID", section.PostID);
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sections == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Post)
                .FirstOrDefaultAsync(m => m.SectionID == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sections == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Sections'  is null.");
            }
            var section = await _context.Sections.FindAsync(id);
            if (section != null)
            {
                _context.Sections.Remove(section);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionExists(int id)
        {
          return (_context.Sections?.Any(e => e.SectionID == id)).GetValueOrDefault();
        }
    }
}
