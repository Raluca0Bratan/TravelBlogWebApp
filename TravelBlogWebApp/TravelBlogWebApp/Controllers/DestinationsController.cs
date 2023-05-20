using Microsoft.AspNetCore.Mvc;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService destinationService;

        public DestinationsController(IDestinationService destinationService)
        {
            this.destinationService = destinationService;
        }

        // GET: Destinations
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //return View(destinationService.;
            return View();
        }
    }
}
