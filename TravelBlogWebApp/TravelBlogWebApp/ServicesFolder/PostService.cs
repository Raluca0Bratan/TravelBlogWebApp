using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class PostService
    {
        private readonly IPostRepository repository;

        public PostService(IPostRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Post entity)
        {
            repository.Add(entity);
        }

        public void Delete(Post entity)
        {
            repository.Delete(entity);
        }

        public IEnumerable<Post> GetAll()
        {
            return repository.GetAll();
        }

        public Post GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Post entity)
        {
            repository.Update(entity);
        }

        public IEnumerable<Post> GetPostWithSectionsAndComments(int postId)
        {
            return repository.GetPostWithSectionsAndComments(postId);
        }
        public IEnumerable<Section> GetAllSectionsFromPost(int postId)
        {
           return repository.GetAllSectionsFromPost(postId);
        }

        public void AddSection(Section section, int postId)
        {
            repository.AddSection(section,postId);
        }

        public void RemoveSection(Section section, int postId)
        {
           repository.RemoveSection(section,postId);
        }

        public void UpdateSection(Section section)
        {
            repository.UpdateSection(section);
        }

        public void AddCommentToPost(Comment comment, int postId, int userId)
        {
            repository.AddCommentToPost(comment,postId,userId);
        }
        public void RemoveCommentFromPost(Comment comment, int postId, int userId)
        {
           repository.RemoveCommentFromPost(comment,postId,userId); 
        }

        public void UpdateComment(Comment comment)
        {
            repository.UpdateComment(comment);  
        }
    }
}
