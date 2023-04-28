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

        public Blog GetBlogWithDestinationsAndPosts(int id)
        {
            return this.context.Set<Blog>()
                .Where(b=>b.Id==id)
                .Include(b=>b.Destinations)
                .Include(b => b.Posts)
                .ThenInclude(p => p.Sections)
                .FirstOrDefault(); 
        }

    }
}
