
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
       
        public PostRepository(TravelBlogDbContext context) : base(context)
        {
            
        }
        
    }
}
