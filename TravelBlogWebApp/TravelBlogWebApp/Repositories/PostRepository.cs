
using Microsoft.EntityFrameworkCore;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly TravelBlogDbContext context;
        private readonly IUserRepository userRepository;
        public PostRepository(TravelBlogDbContext context, IUserRepository userRepository) : base(context)
        {
            this.userRepository = userRepository;
        }
        public IEnumerable<Post> GetPostWithSectionsAndComments(int postId)
        {
            return this.context.Set<Post>()
                .Where(p=>p.Id==postId)
                .Include(p => p.Sections)
                .Include(p => p.Comments)
                .AsEnumerable();
        }
        public IEnumerable<Section> GetAllSectionsFromPost(int postId)
        {
            var post =  GetById(postId);
            return post.Sections;
        }

        public void AddSection(Section section, int postId)
        {
            var post = GetById(postId);
            post.Sections.Add(section);
            this.context.Set<Section>().Add(section);
            this.context.SaveChanges();
        }

        public void RemoveSection(Section section,int postId) 
        {

            var post = GetById(postId);
            post.Sections.Remove(section);
            this.context.Set<Section>().Remove(section);  
            this.context.SaveChanges();
        }

        public void UpdateSection(Section section)
        {
            this.context.Set<Section>().Update(section);
            this.context.SaveChanges();
        }

        public void AddCommentToPost(Comment comment,int postId,int userId)
        {
            var post = GetById(postId);
            var user = userRepository.GetById(userId);
            post.Comments.Add(comment);
            user.Comments.Add(comment);
            this.context.Set<Comment>().Remove(comment);
            this.context.SaveChanges();
        }
        public void RemoveCommentFromPost(Comment comment, int postId, int userId)
        {
            var post = GetById(postId);
            var user = userRepository.GetById(userId);
            post.Comments.Remove(comment);
            user.Comments.Remove(comment);
            this.context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
           this.context.Set<Comment>().Update(comment);
           this.context.SaveChanges();
        }

    }
}
