


using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface IBlogService
    {

        public IQueryable<Blog> FindAll();

        public void Create(Blog entity);


        public void Update(Blog entity);


        public void Delete(Blog entity);
       

    }
}
