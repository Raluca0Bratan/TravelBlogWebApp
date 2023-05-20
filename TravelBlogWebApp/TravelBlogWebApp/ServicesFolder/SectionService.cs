using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class SectionService:ISectionService
    {

        private readonly RepositoryWrapper repositoryWrapper;

        public SectionService(RepositoryWrapper repository)
        {
            this.repositoryWrapper = repository;
        }
    }

}

