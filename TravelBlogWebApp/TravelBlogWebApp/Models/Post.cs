namespace TravelBlogWebApp.Models
{
    public class Post
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public int LikesNumber { get; set; }

        public int BlogID { get; set; }

        public Blog? Blog { get; set; }

        public ICollection<Section>? Sections { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
