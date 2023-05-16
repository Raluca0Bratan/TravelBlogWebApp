
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
        private readonly IBlogService blogService;

        public DestinationsController(IDestinationService destinationService, IBlogService blogService)
        {
            this.destinationService = destinationService;
            this.blogService = blogService;
        }

        // GET: Destinations
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(destinationService.GetAll());
        }

        // GET: Destinations/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || destinationService.GetAll() == null)
            {
                return NotFound();
            }

            var destination = destinationService.GetById(id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: Destinations/Create
        [HttpPost]
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("City,Country,Date,BlogId,LikesNumber,Id")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                destinationService.Add(destination);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", destination.BlogId); ;
            return View(destination);
        }

        // GET: Destinations/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || destinationService.GetAll == null)
            {
                return NotFound();
            }

            var destination = destinationService.GetById(id);  
            if (destination == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(destinationService.GetAll(), "Id", "Id", destination.BlogId);
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("City,Country,Date,BlogId,LikesNumber,Id")] Destination destination)
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
            ViewData["BlogId"] = new SelectList(blogService.GetAll(), "Id", "Id", destination.BlogId);
            return View(destination);
        }

        // GET: Destinations/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null ||destinationService.GetAll() == null)
            {
                return NotFound();
            }

            var destination = destinationService.GetById(id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (destinationService.GetAll() == null)
            {
                return Problem("Entity set 'TravelBlogDbContext.Destinations'  is null.");
            }
            var destination = destinationService.GetById(id);
            if (destination != null)
            {
                destinationService.Delete(destination);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
          return destinationService.GetAll().Any(d=>d.Id==id);
        }

        //public IActionResult SearchedDestination(string searchString)
        //{
        //    var destinations = destinationService.GetAll();

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        // Filter destinations based on the search string
        //        destinations = destinations.Where(d =>
        //            d.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase)
        //            || d.City.Contains(searchString, StringComparison.OrdinalIgnoreCase))
        //            .ToList();
        //    }

        //    return View("Index",destinations);
        //}
        public async Task<IActionResult> Index(string searchString)
        {
            if (destinationService == null)
            {
                return Problem("Destination service is null.");
            }

            var destinations = destinationService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                destinations = destinations.Where(d =>
                    d.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    || d.City.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(destinations);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        public IActionResult Alicante()
        {
            return View();
        }
    }
    }

