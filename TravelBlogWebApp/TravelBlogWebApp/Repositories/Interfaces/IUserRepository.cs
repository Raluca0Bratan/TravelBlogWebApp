using Microsoft.AspNetCore.Identity;
using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.Repositories.Interfaces
{
    public interface IUserRepository:IBaseRepository<IdentityUser>
    {
        //public IdentityUser GetCurrentUserAsync();
    }
}
