
using System.Linq.Expressions;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface IPostService
    {
        public IQueryable<Post> FindAll();


        public IQueryable<Post> FindByCondition(Expression<Func<Post, bool>> expression);


        public void Create(Post entity);


        public void Update(Post entity);


        public void Delete(Post entity);

        public Post GetPostWithSectionsAndComments(int postId);

        public void AddCommentToPost(int postId, Comment comment);

        public void AddSectionToPost(int postId, Section section);
    }
}
