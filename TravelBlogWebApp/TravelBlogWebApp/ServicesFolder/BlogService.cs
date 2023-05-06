using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class BlogService:IBlogService
    {
        private readonly IBlogRepository repository;

        public BlogService(IBlogRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Blog entity)
        {
           repository.Add(entity);
        }

        public void Delete(Blog entity)
        {
          repository.Delete(entity);
        }

        public IEnumerable<Blog> GetAll()
        {
           return repository.GetAll();  
        }

        public Blog GetById(int id)
        {
           return repository.GetById(id);
        }

        public void Update(Blog entity)
        {
            repository.Update(entity);
        }
        public Blog GetBlogWithDestinationsAndPosts(int id)
        {
            return repository.GetBlogWithDestinationsAndPosts(id);
        }
    }
}
