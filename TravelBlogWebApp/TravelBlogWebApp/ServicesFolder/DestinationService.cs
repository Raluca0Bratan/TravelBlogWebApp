
using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class DestinationService:IDestinationService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        
        public DestinationService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper; 
        }
        public IQueryable<Destination> FindAll()
        {
            return repositoryWrapper.DestinationRepository.FindAll();
        }


        public IQueryable<Destination> FindByCondition(Expression<Func<Destination, bool>> expression)
        {
            return repositoryWrapper.DestinationRepository.FindByCondition(expression);
        }


        public void Create(Destination entity)
        {
            repositoryWrapper.DestinationRepository.Create(entity);
            repositoryWrapper.Save();
        }


        public void Update(Destination entity)
        {
            repositoryWrapper.DestinationRepository.Update(entity);
            repositoryWrapper.Save();
        }


        public void Delete(Destination entity)
        {
            repositoryWrapper.DestinationRepository.Delete(entity);
            repositoryWrapper.Save();
        }

    }
}
