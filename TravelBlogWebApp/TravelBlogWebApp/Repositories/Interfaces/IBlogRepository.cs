using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.Repositories.Interfaces
{
    public interface IBlogRepository : IBaseRepository<Blog>
    {
        public Blog GetBlogWithDestinationsAndPosts(int id);
       
    }
}
