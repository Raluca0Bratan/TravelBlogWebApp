namespace TravelBlogWebApp.Models
{
    public class Post:ModelEntity
    {

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public int LikesNumber { get; set; }

        public int BlogId { get; set; }

        public Blog? Blog { get; set; }

        public ICollection<Section>? Sections { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
