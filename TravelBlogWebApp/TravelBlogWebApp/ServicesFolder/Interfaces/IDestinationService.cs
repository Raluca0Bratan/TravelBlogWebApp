using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface IDestinationService
    {
        public IQueryable<Destination> FindAll();


        public IQueryable<Destination> FindByCondition(Expression<Func<Destination, bool>> expression);


        public void Create(Destination entity);


        public void Update(Destination entity);


        public void Delete(Destination entity);
       
    }
}
