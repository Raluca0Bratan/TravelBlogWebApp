namespace TravelBlogWebApp.Models
{
    public class Comment:ModelEntity
    {
      
        public int UserId { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }
    }
}
