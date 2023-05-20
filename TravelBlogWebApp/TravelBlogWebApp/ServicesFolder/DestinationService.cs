
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class DestinationService:IDestinationService
    {
        private readonly RepositoryWrapper repositoryWrapper;
        
        public DestinationService(RepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper; 
        }

       
    }
}
