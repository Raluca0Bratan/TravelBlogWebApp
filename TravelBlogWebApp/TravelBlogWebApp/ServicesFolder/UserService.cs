using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class UserService:IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Add(User entity)
        {
            repository.Add(entity);
        }

        public void Delete(User entity)
        {
            repository.Delete(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        public User GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(User entity)
        {
            repository.Update(entity);
        }
    }
}
