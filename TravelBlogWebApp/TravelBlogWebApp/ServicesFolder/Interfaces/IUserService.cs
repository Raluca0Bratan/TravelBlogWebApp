using NuGet.Protocol.Core.Types;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.ServicesFolder.Interfaces
{
    public interface IUserService
    {
        public void Add(User entity);


        public void Delete(User entity);


        public IEnumerable<User> GetAll();


        public User GetById(int id);


        public void Update(User entity);
       
    }
}
