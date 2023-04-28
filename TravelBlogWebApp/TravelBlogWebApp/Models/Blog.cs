namespace TravelBlogWebApp.Models
{
    public class Blog:ModelEntity
    {
       
        public string Author { get; set; }
        public string Name { get; set; }

        public ICollection<Post>? Posts { get; set; }

        public ICollection<Destination>? Destinations { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
