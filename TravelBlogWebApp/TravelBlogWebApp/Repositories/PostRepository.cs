
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly TravelBlogDbContext context;
        public PostRepository(TravelBlogDbContext context) : base(context)
        {
            this.context = context;
        }

        public void AddCommentToPost(int postId, Comment comment)
        {
            this.context.Set<Post>().Where(p => p.Id == postId).FirstOrDefault().Comments.Add(comment);
        }

        public void AddSectionToPost(int postId, Section section)
        {
            this.context.Set<Post>().Where(p => p.Id == postId).FirstOrDefault().Sections.Add(section);
        }

        public Post GetPostWithSectionsAndComments(int postId)
        {
            var post = this.context.Set<Post>()
                .Include(p => p.Sections)
                .Include(p => p.Comments)
                .Where(p => p.Id == postId).FirstOrDefault();
                
            return post;
        }

    }
}
