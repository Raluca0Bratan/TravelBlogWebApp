using NuGet.Packaging.Core;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(TravelBlogDbContext context) : base(context)
        {
        }
    }
}
