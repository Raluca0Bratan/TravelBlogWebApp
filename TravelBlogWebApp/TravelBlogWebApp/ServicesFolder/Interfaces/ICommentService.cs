using System.Linq.Expressions;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface ICommentService
    {
        public IEnumerable<Comment> FindAll();

        public IQueryable<Comment> FindByCondition(Expression<Func<Comment, bool>> expression);


        public void Create(Comment entity);


        public void Update(Comment entity);


        public void Delete(Comment entity);
    }
}
