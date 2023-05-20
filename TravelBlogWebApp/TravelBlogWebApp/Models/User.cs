using Microsoft.AspNetCore.Identity;

namespace TravelBlogWebApp.Models
{
    public class User:IdentityUser
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string ProfilePicturePath { get; set; }
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }

        public ICollection<Comment>? Comments { get; set; }  
    }
}

