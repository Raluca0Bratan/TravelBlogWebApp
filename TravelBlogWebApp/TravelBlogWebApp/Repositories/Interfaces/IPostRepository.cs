using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.Repositories.Interfaces
{
    public interface IPostRepository:IBaseRepository<Post>
    {
        public IEnumerable<Post> GetPostWithSectionsAndComments(int postId);

        public IEnumerable<Section> GetAllSectionsFromPost(int postId);


        public void AddSection(Section section, int postId);


        public void RemoveSection(Section section, int postId);


        public void UpdateSection(Section section);

        public void AddCommentToPost(Comment comment, int postId, int userId);

        public void RemoveCommentFromPost(Comment comment, int postId, int userId);


        public void UpdateComment(Comment comment);
       
    }
}
