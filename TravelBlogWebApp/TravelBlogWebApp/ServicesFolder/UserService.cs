using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class UserService:IUserService
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public UserService(IRepositoryWrapper repository)
        {
            this.repositoryWrapper = repository;
        }

      
    }
}
