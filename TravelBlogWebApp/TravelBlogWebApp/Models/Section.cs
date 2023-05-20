namespace TravelBlogWebApp.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }
        public int PostId { get; set; }

        public Post? Post { get; set; }
    }
}
