
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface IPostService
    {
        public void Add(Post entity);


        public void Delete(Post entity);


        public IEnumerable<Post> GetAll();


        public Post GetById(int id);


        public void Update(Post entity);


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
