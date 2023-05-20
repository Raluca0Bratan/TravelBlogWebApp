
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
