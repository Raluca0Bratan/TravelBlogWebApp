using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class PostService : IPostService
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public PostService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }
        public IQueryable<Post> FindAll()
        {
            return repositoryWrapper.PostRepository.FindAll();
        }


        public IQueryable<Post> FindByCondition(Expression<Func<Post, bool>> expression)
        {
            return repositoryWrapper.PostRepository.FindByCondition(expression);
        }


        public void Create(Post entity)
        {
            repositoryWrapper.PostRepository.Create(entity);
            repositoryWrapper.Save();
        }


        public void Update(Post entity)
        {
            repositoryWrapper.PostRepository.Update(entity);
            repositoryWrapper.Save();
        }


        public void Delete(Post entity)
        {
            repositoryWrapper.PostRepository.Delete(entity);
            repositoryWrapper.Save();
        }

        public Post GetPostWithSectionsAndComments(int postId)
        {
           return repositoryWrapper.PostRepository.GetPostWithSectionsAndComments(postId);
        }

        public void AddCommentToPost(int postId, Comment comment)
        {
            repositoryWrapper.PostRepository.AddCommentToPost(postId, comment);
            repositoryWrapper.Save();
        }

        public void AddSectionToPost(int postId, Section section)
        {
            repositoryWrapper.PostRepository.AddSectionToPost(postId, section);
            repositoryWrapper.Save();
        }

    }
}
