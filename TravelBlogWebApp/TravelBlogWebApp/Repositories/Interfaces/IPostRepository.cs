using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.Repositories.Interfaces
{
    public interface IPostRepository:IBaseRepository<Post>
    {
        public Post GetPostWithSectionsAndComments(int postId);

        public void AddCommentToPost(int postId, Comment comment);

        public void AddSectionToPost(int postId, Section section);
    }
}
