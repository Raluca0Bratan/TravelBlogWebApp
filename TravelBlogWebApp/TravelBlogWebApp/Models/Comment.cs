namespace TravelBlogWebApp.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public string Author { get; set; }

        public int PostID { get; set; }
        public Post? Post { get; set; }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }
    }
}
