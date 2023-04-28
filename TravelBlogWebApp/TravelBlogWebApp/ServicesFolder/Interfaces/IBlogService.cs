
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface IBlogService
    {
        public void Add(Blog entity);


        public void Delete(Blog entity);


        public IEnumerable<Blog> GetAll();


        public Blog GetById(int id);


        public void Update(Blog entity);

        public Blog GetBlogWithDestinationsAndPosts(int id);
       

    }
}
