using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class UserRepository : BaseRepository<IdentityUser>, IUserRepository
    {
        public UserRepository(TravelBlogDbContext context) : base(context)
        {
         
        }
    }
}
