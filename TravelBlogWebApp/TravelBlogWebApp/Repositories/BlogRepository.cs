using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        private readonly TravelBlogDbContext context;
        public BlogRepository(TravelBlogDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
