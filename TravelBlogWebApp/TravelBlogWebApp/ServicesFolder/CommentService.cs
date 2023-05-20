using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class CommentService : ICommentService
    {

        private readonly RepositoryWrapper repositoryWrapper;

        public CommentService(RepositoryWrapper repository)
        {
            this.repositoryWrapper = repository;
        }

        public void Create(Comment entity)
        {
           repositoryWrapper.CommentRepository.Create(entity);
            repositoryWrapper.Save();
        }

        public void Delete(Comment entity)
        {
            repositoryWrapper.CommentRepository.Delete(entity);
            repositoryWrapper.Save();
        }

        public IEnumerable<Comment> FindAll()
        {
            return repositoryWrapper.CommentRepository.FindAll();
        }

        public IQueryable<Comment> FindByCondition(Expression<Func<Comment, bool>> expression)
        {
            return repositoryWrapper.CommentRepository.FindByCondition(expression); 
        }

        public void Update(Comment entity)
        {
            repositoryWrapper.CommentRepository.Update(entity);
            repositoryWrapper.Save();
        }
    }
}
