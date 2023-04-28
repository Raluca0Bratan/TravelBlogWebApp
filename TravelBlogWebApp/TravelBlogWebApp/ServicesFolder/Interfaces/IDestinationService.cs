using NuGet.Protocol.Core.Types;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface IDestinationService
    {
        public void Add(Destination entity);


        public void Delete(Destination entity);

        public IEnumerable<Destination> GetAll();


        public Destination GetById(int id);


        public void Update(Destination entity);
       
    }
}
