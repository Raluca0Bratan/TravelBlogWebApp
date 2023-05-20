using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class BlogService:IBlogService
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public BlogService(RepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        
    }
}
