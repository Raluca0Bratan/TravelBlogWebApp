using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class PostService:IPostService
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public PostService(RepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

       
    }
}
