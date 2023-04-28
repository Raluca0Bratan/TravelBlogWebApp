namespace TravelBlogWebApp.Models
{
    public class Section:ModelEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }
        public int PostId { get; set; }

        public Post? Post { get; set; }
    }
}
