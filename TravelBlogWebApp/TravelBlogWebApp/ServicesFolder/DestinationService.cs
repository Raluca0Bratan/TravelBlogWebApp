
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class DestinationService:IDestinationService
    {
        private readonly IDestinationRepository repository;

        public DestinationService(IDestinationRepository destinationRepository)
        {
            this.repository = destinationRepository;
        }

        public void Add(Destination entity)
        {
            repository.Add(entity);
        }

        public void Delete(Destination entity)
        {
            repository.Delete(entity);
        }

        public IEnumerable<Destination> GetAll()
        {
            return repository.GetAll();
        }

        public Destination GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Destination entity)
        {
            repository.Update(entity);
        }
    }
}
