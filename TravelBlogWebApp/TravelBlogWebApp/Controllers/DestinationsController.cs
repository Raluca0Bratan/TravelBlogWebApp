using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService destinationService;
        private readonly TravelBlogDbContext _context;

        public DestinationsController(TravelBlogDbContext context,IDestinationService destinationService)
        {
            this.destinationService = destinationService;
            this._context = context; 
        }

        // GET: Destinations
        public async Task<IActionResult> Index()
        {
            var list = destinationService.FindAll();
            return View(list);
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || destinationService.FindAll() == null)
            {
                return NotFound();
            }

            var destination = destinationService.FindByCondition(d=>d.Id==id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: Destinations/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id");
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,City,Country,Date,BlogId,LikesNumber")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                destinationService.Create(destination);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id", destination.BlogId);
            return View(destination);
        }

        // GET: Destinations/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || destinationService.FindAll()== null)
            {
                return NotFound();
            }

            var destination = destinationService.FindByCondition(d=>d.Id==id).FirstOrDefault();
            if (destination == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id", destination.BlogId);
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Country,Date,BlogId,LikesNumber")] Destination destination)
        {
            if (id != destination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    destinationService.Update(destination);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationExists(destination.Id))
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
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Id", destination.BlogId);
            return View(destination);
        }

        // GET: Destinations/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || destinationService.FindAll() == null)
            {
                return NotFound();
            }

            var destination = destinationService.FindByCondition(d=>d.Id == id).FirstOrDefault();
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: Destinations/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (destinationService.FindAll() == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Destinations'  is null.");
            }
            var destination = destinationService.FindByCondition(d=>d.Id == id).FirstOrDefault();
            if (destination != null)
            {
                destinationService.Delete(destination);
            }
          
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
          return (_context.Destinations?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public ActionResult Search(string searchString)
        {
            var destinations = destinationService.FindByCondition(d =>
                d.City.Contains(searchString) ||
                d.Country.Contains(searchString)).ToList();

           return RedirectToAction("Index", new { destinations = destinations });
        }
    }
       
   
    }

