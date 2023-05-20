
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.ServicesFolder;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.Controllers
{
    public class SectionsController : Controller
    {
        private readonly TravelBlogDbContext _context;
        private readonly ISectionService sectionService;


        public SectionsController(TravelBlogDbContext context,ISectionService sectionService)
        {
            _context = context;
            this.sectionService = sectionService;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,ImagePath,PostId")] Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", section.PostId);
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? sectionId)
        {
            if (sectionId == null )
            {
                return NotFound();
            }

            var section = sectionService.FindByCondition(s => s.Id == sectionId).FirstOrDefault();
            if (section == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", section.PostId);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int sectionId, [Bind("Id,Title,Content,ImagePath,PostId")] Section section)
        {
            if (sectionId != section.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sectionService.Update(section);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", section.PostId);
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? sectionId)
        {
            if (sectionId == null || sectionService.FindAll() == null)
            {
                return NotFound();
            }

            var section = sectionService.FindByCondition(s=>s.Id == sectionId).FirstOrDefault();
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
            if (sectionService.FindAll() == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Sections'  is null.");
            }
            var section = sectionService.FindByCondition(s=> s.Id == id).FirstOrDefault();  
            sectionService.Delete(section);
            
            return RedirectToAction(nameof(Index));
        }

        private bool SectionExists(int id)
        {
          return (_context.Sections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
