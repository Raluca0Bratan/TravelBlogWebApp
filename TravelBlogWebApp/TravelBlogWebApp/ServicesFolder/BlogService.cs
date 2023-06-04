using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class BlogService:IBlogService
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public BlogService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public void Create(Blog entity)
        {
            repositoryWrapper.BlogRepository.Create(entity);
            repositoryWrapper.Save();
        }

        public void Delete(Blog entity)
        {
           repositoryWrapper.BlogRepository.Delete(entity);
           repositoryWrapper.Save();
        }

        public IQueryable<Blog> FindAll()
        {
           return repositoryWrapper.BlogRepository.FindAll();
        }

        public void Update(Blog entity)
        {
            repositoryWrapper.BlogRepository.Update(entity);
            repositoryWrapper.Save();
        }
    }
}
