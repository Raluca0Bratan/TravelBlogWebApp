using System.Linq.Expressions;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface ISectionService
    {
        public IQueryable<Section> FindAll();


        public void Create(Section entity);


        public void Update(Section entity);


        public void Delete(Section entity);
    }
}
