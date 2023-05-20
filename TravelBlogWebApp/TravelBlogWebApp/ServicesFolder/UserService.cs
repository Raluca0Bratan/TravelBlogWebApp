using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class UserService:IUserService
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public UserService(RepositoryWrapper repository)
        {
            this.repositoryWrapper = repository;
        }

      
    }
}
